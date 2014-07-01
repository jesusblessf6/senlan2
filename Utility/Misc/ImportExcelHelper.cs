using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using DBEntity;
using DBEntity.EnumEntity;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Utility.Misc
{
    public class ImportExcelHelper
    {
        private readonly ISheet _sheet = null;
        private readonly bool _xlsx;
        private HSSFWorkbook _hssfworkbook;
        private XSSFWorkbook _xssfWorkbook;

        #region 金属
        public static readonly List<string> Metals = new List<string>() { "CU", "AL", "ZN", "PB", "AU", "AG" };
        #endregion

        public ImportExcelHelper(FileStream file, bool xlsx = false)
        {
            if (file != null)
            {
                _xlsx = xlsx;
                InitializeWorkbook(file, xlsx);
                SetPositionType();
                SetPositionDirection();
                SetPositionOpenClose();
            }
            else
            {
                throw new Exception("读取Excel错误");
            }
        }

        public FileStream File { get; set; }

        private void InitializeWorkbook(FileStream file, bool xlsx)
        {
            if (xlsx)
            {
                _xssfWorkbook = new XSSFWorkbook(file);
            }
            else
            {
                _hssfworkbook = new HSSFWorkbook(file);
            }
        }

        /// <summary>
        ///     获取工作簿
        /// </summary>
        /// <param name="sheetNum"></param>
        /// <returns></returns>
        public ISheet GetSheet(int sheetNum)
        {
            if (!_xlsx)
            {
                if (_hssfworkbook == null)
                    return null;
                ISheet sheet = _hssfworkbook.GetSheetAt(sheetNum);
                return sheet;
            }
            else
            {
                if (_xssfWorkbook == null)
                    return null;
                ISheet sheet = _xssfWorkbook.GetSheetAt(sheetNum);
                return sheet;
            }
        }

        /// <summary>
        ///     获取单元格
        /// </summary>
        /// <param name="rowNum"></param>
        /// <param name="colNum"></param>
        /// <returns></returns>
        public string GetCell(int rowNum, int colNum)
        {
            //获取行
            IRow row = GetRow(rowNum);
            if (row.LastCellNum < colNum)
                return null;
            ICell cell = row.GetCell(colNum);
            return cell.ToString();
        }

        public IRow GetRow(int rowNum)
        {
            if (_sheet == null)
                return null;
            if (_sheet.LastRowNum < rowNum)
                return null;
            IRow row = _sheet.GetRow(rowNum);
            return row;
        }

        /// <summary>
        ///     把指定的工作簿转换成DataTable
        /// </summary>
        /// <param name="sheetNum"></param>
        /// <returns></returns>
        public DataTable ConvertToDataTable(int sheetNum)
        {
            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(sheetNum) : _xssfWorkbook.GetSheetAt(sheetNum);
            IEnumerator rows = sheet.GetRowEnumerator();

            var dt = new DataTable();
            for (int j = 0; j < 10; j++)
            {
                dt.Columns.Add(Convert.ToChar(('A') + j).ToString(CultureInfo.InvariantCulture));
            }
            while (rows.MoveNext())
            {
                IRow row = (HSSFRow) rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);


                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #region SHFE头寸导入专用

        private readonly List<string> _codes = new List<string>();

        /// <summary>
        ///     成交汇总数据
        /// </summary>
        /// <returns></returns>
        public List<SHFEPosition> GetSHFEPosition(List<SHFECodeClass> shfeCodeClasses)
        {
            var positions = new List<SHFEPosition>();

            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(0) : _xssfWorkbook.GetSheetAt(0);
            if (sheet == null)
            {
                throw new Exception("Excel格式错误");
            }
            IEnumerator rows = sheet.GetRowEnumerator();
            bool start = false;
            int num = 0;

            while (rows.MoveNext())
            {
                IRow row = !_xlsx ? (IRow) rows.Current : (XSSFRow) rows.Current;
                if (!start)
                {
                    ICell cell = row.GetCell(0);
                    if (cell != null && cell.ToString().Trim() == "成交汇总")
                    {
                        rows.MoveNext();
                        IRow rowHeader = (HSSFRow) rows.Current;
                        SetPositionHeaderIndex(rowHeader);
                        start = true;
                    }
                }
                else
                {
                    num++;
                    int? positionDirection = null; //头寸方向
                    int? positionType = null; //头寸类型
                    decimal? price = null; //成交价格
                    decimal? lotQuantity = null; //手数
                    int? openClose = null; //开平仓
                    decimal? commission = null; //手续费
                    decimal? pnl = null; //平仓盈亏
                    int? shfeId = null; //SHFE期货合约主键
                    int? commodityId = null; //金属品种
                    DateTime? promptDate = null; //截止日期
                    string alias = string.Empty; //合约名称

                    decimal temp;

                    ICell cellSHFECode = row.GetCell(_positionCodeIndex);
                    ICell cellTemp = row.GetCell(0);
                    if (cellTemp != null && cellSHFECode != null)
                    {
                        //期货合约
                        string shfeCode = cellSHFECode.ToString().Trim(); //期货合约

                        if (cellTemp.ToString().Trim() == "合计")
                        {
                            //数据EOF
                            break;
                        }
                        
                        alias = shfeCode;
                        SHFECodeClass codeClass = GetSHFECodeClassByCode(shfeCode, shfeCodeClasses);
                        if (codeClass == null)
                            continue;
                        shfeId = codeClass.SHFEId;
                        commodityId = codeClass.CommodityId;
                        promptDate = codeClass.PromptDate;
                    }
                    ICell cellPositionDirection = row.GetCell(_positionDirectionIndex);
                    if (cellPositionDirection != null)
                    {
                        //头寸方向
                        string strPositionDirection = cellPositionDirection.ToString().Trim();
                        positionDirection = GetPositionDirection(strPositionDirection);
                    }
                    ICell cellPositionType = row.GetCell(_positionTypeIndex);
                    if (cellPositionType != null)
                    {
                        //头寸类型
                        string strPositionType = cellPositionType.ToString().Trim();
                        positionType = GetPositionType(strPositionType);
                    }
                    ICell cellPrice = row.GetCell(_positionPriceIndex);
                    bool flagConvert;
                    if (cellPrice != null)
                    {
                        //成交价格
                        if (cellPrice.ToString().Trim() == "" || cellPrice.ToString().Trim() == "--")
                        {
                            price = null;
                        }
                        else
                        {
                            flagConvert = decimal.TryParse(cellPrice.ToString(), out temp);
                            if (!flagConvert)
                            {
                                throw new Exception("成交汇总第" + num + "行成交价有误");
                            }
                            
                            price = temp;
                        }
                    }
                    ICell cellLotQuantity = row.GetCell(_positionLotQuantityIndex);
                    if (cellLotQuantity != null)
                    {
                        //手数
                        if (cellLotQuantity.ToString().Trim() == "" || cellLotQuantity.ToString().Trim() == "--")
                        {
                            lotQuantity = null;
                        }
                        else
                        {
                            flagConvert = decimal.TryParse(cellLotQuantity.ToString(), out temp);
                            if (!flagConvert)
                            {
                                throw new Exception("成交汇总第" + num + "行手数有误");
                            }
                            
                            lotQuantity = temp;
                        }
                    }
                    ICell cellOpenClose = row.GetCell(_positionOpenCloseIndex);
                    if (cellOpenClose != null)
                    {
                        //开平仓
                        string strOpenClose = cellOpenClose.ToString().Trim();
                        openClose = GetPositionOpenClose(strOpenClose);
                    }
                    ICell cellCommission = row.GetCell(_positionCommissionIndex);
                    if (cellCommission != null)
                    {
                        //手续费
                        if (cellCommission.ToString().Trim() == "" || cellCommission.ToString().Trim() == "--")
                        {
                            commission = null;
                        }
                        else
                        {
                            flagConvert = decimal.TryParse(cellCommission.ToString(), out temp);
                            if (!flagConvert)
                            {
                                throw new Exception("成交汇总第" + num + "行手续费有误");
                            }
                            
                            commission = temp;
                        }
                    }
                    ICell cellPNL = row.GetCell(_positionPNLIndex);
                    if (cellPNL != null)
                    {
                        //手续费
                        if (cellPNL.ToString().Trim() == "" || cellPNL.ToString().Trim() == "--")
                        {
                            pnl = null;
                        }
                        else
                        {
                            flagConvert = decimal.TryParse(cellPNL.ToString(), out temp);
                            if (!flagConvert)
                            {
                                pnl = null;
                            }
                            else
                            {
                                pnl = temp;
                            }
                        }
                    }
                    var position = new SHFEPosition
                                       {
                                           SHFEId = shfeId,
                                           CommodityId = commodityId,
                                           PositionDirection = positionDirection,
                                           PositionType = positionType,
                                           Price = price,
                                           LotQuantity = lotQuantity,
                                           OpenClose = openClose,
                                           Commission = commission,
                                           PromptDate = promptDate,
                                           PNL = pnl,
                                           Alias = alias
                                       };
                    positions.Add(position);
                }
            }
            return positions;
        }

        /// <summary>
        ///     解析头寸类型
        /// </summary>
        /// <param name="positionType"></param>
        /// <returns></returns>
        private int? GetPositionType(string positionType)
        {
            int? value;
            switch (positionType)
            {
                case "保值":
                    value = _hedgeValue;
                    break;
                case "套利":
                    value = _arbitrageValue;
                    break;
                case "投机":
                    value = _speculationValue;
                    break;
                default:
                    value = null;
                    break;
            }
            return value;
        }

        /// <summary>
        ///     解析交易方向
        /// </summary>
        /// <param name="positionDirection"></param>
        /// <returns></returns>
        private int? GetPositionDirection(string positionDirection)
        {
            int? value;
            switch (positionDirection)
            {
                case "买":
                    value = _longValue;
                    break;
                case "卖":
                    value = _shortValue;
                    break;
                default:
                    value = null;
                    break;
            }
            return value;
        }

        /// <summary>
        ///     解析开仓平仓
        /// </summary>
        /// <param name="positionOpenClose"></param>
        /// <returns></returns>
        private int? GetPositionOpenClose(string positionOpenClose)
        {
            int? value;
            switch (positionOpenClose)
            {
                case "开":
                    value = _openValue;
                    break;
                case "平":
                    value = _closeValue;
                    break;
                default:
                    value = null;
                    break;
            }
            return value;
        }

        /// <summary>
        ///     获取客户的资金账户
        /// </summary>
        /// <returns></returns>
        public string GetSHFEPositionCapitalAccount()
        {
            string capitalAccount = string.Empty;
            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(0) : _xssfWorkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            bool start = false;
            while (rows.MoveNext())
            {
                IRow row = !_xlsx ? (IRow) rows.Current : (XSSFRow) rows.Current;
                if (!start)
                {
                    ICell cell = row.GetCell(0);
                    if (cell != null && cell.ToString().Trim() == "基本资料")
                    {
                        start = true;
                    }
                }
                else
                {
                    ICell cell = row.GetCell(2);
                    if (cell != null)
                    {
                        capitalAccount = cell.ToString();
                        break;
                    }

                    start = false;
                    break;
                }
            }
            if (!start)
            {
                //没找到
                throw new Exception("客户资金账户没找到");
            }
            return capitalAccount;
        }

        /// <summary>
        ///     获取交易日期
        /// </summary>
        /// <returns></returns>
        public DateTime GetSHFEPositionDateTime()
        {
            DateTime dateTime = DateTime.Now;
            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(0) : _xssfWorkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            bool start = false;
            while (rows.MoveNext())
            {
                IRow row = !_xlsx ? (IRow) rows.Current : (XSSFRow) rows.Current;
                if (!start)
                {
                    ICell cell = row.GetCell(0);
                    if (cell != null && cell.ToString().Trim() == "基本资料")
                    {
                        start = true;
                    }
                }
                else
                {
                    ICell cell = row.GetCell(7);
                    if (cell != null)
                    {
                        dateTime = Convert.ToDateTime(cell.ToString());
                        break;
                    }
                    
                    start = false;
                    break;
                }
            }
            if (!start)
            {
                //没找到
                throw new Exception("交易日期没找到");
            }
            return dateTime;
        }

        /// <summary>
        ///     根据合约获取金属Id和合约表外键
        /// </summary>
        /// <param name="code"></param>
        /// <param name="shfeCodeClasses"></param>
        /// <returns></returns>
        private SHFECodeClass GetSHFECodeClassByCode(string code, IEnumerable<SHFECodeClass> shfeCodeClasses)
        {
            SHFECodeClass shfeCodeClass = null;
            foreach (SHFECodeClass codeClass in shfeCodeClasses)
            {
                if (codeClass.Code == code)
                {
                    shfeCodeClass = codeClass;
                    if (!Metals.Contains(codeClass.CommodityCode))
                    {
                        return null;
                    }
                }
            }
            return shfeCodeClass;
        }

        /// <summary>
        ///     获取SHFE头寸的资金明细数据
        /// </summary>
        /// <returns></returns>
        public SHFECapitalDetail GetSHFECapitalDetail()
        {
            SHFECapitalDetail capitalDetail = null;
            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(0) : _xssfWorkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            bool start = false;
            while (rows.MoveNext())
            {
                IRow row = !_xlsx ? (IRow) rows.Current : (XSSFRow) rows.Current;
                if (!start)
                {
                    ICell cell = row.GetCell(0);
                    if (cell != null && cell.ToString().Trim() == "资金状况")
                    {
                        start = true;
                    }
                }
                else
                {
                    decimal? yesterdayBalance = null; //上日结存
                    decimal? equity = null; //客户权益
                    decimal? todayWDSum = null; //当日存取合计
                    decimal? pledge = null; //质押金
                    decimal? todayPNL = null; //当日盈亏
                    decimal? margin = null; //保证金占用
                    decimal? todayCommission = null; //当日手续费
                    decimal? availableCapital = null; //可用资金
                    decimal? todayBalance = null; //当日结存
                    decimal? risk = null; //风险度
                    decimal? supplementaryMargin = null; //追加保证金
                    decimal? floatPNL = null; //浮动盈亏

                    ICell cellYesterdayBalance = row.GetCell(2);
                    if (cellYesterdayBalance != null)
                    {
                        //上日结存
                        yesterdayBalance = Convert.ToDecimal(cellYesterdayBalance.ToString());
                    }
                    ICell cellEquity = row.GetCell(7);
                    if (cellEquity != null)
                    {
                        //客户权益
                        equity = Convert.ToDecimal(cellEquity.ToString());
                    }

                    rows.MoveNext();
                    row = (HSSFRow) rows.Current;

                    ICell cellTodayWDSum = row.GetCell(2);
                    if (cellTodayWDSum != null)
                    {
                        //当日存取合计
                        todayWDSum = Convert.ToDecimal(cellTodayWDSum.ToString());
                    }
                    ICell cellPledge = row.GetCell(7);
                    if (cellPledge != null)
                    {
                        //质押金
                        pledge = Convert.ToDecimal(cellPledge.ToString());
                    }

                    rows.MoveNext();
                    row = (HSSFRow) rows.Current;

                    ICell cellTodayPNL = row.GetCell(2);
                    if (cellTodayPNL != null)
                    {
                        //当日盈亏
                        todayPNL = Convert.ToDecimal(cellTodayPNL.ToString());
                    }
                    ICell cellMargin = row.GetCell(7);
                    if (cellMargin != null)
                    {
                        //保证金占用
                        margin = Convert.ToDecimal(cellMargin.ToString());
                    }

                    rows.MoveNext();
                    row = (HSSFRow) rows.Current;

                    ICell cellTodayCommission = row.GetCell(2);
                    if (cellTodayCommission != null)
                    {
                        //当日手续费
                        todayCommission = Convert.ToDecimal(cellTodayCommission.ToString());
                    }
                    ICell cellAvailableCapital = row.GetCell(7);
                    if (cellAvailableCapital != null)
                    {
                        //可用资金
                        availableCapital = Convert.ToDecimal(cellAvailableCapital.ToString());
                    }

                    rows.MoveNext();
                    row = (HSSFRow) rows.Current;

                    ICell cellTodayBalance = row.GetCell(2);
                    if (cellTodayBalance != null)
                    {
                        //当日结存
                        todayBalance = Convert.ToDecimal(cellTodayBalance.ToString());
                    }
                    ICell cellRisk = row.GetCell(7);
                    if (cellRisk != null)
                    {
                        //风险度
                        risk = Convert.ToDecimal(cellRisk.ToString().Substring(0, cellRisk.ToString().Length - 1))/100;
                    }

                    rows.MoveNext();
                    row = (HSSFRow) rows.Current;

                    ICell cellFloatPNL = row.GetCell(2);
                    if (cellFloatPNL != null && cellFloatPNL.ToString().Trim() != "")
                    {
                        //浮动盈亏
                        decimal tempFloatPNL;
                        bool flag = decimal.TryParse(cellFloatPNL.ToString(), out tempFloatPNL);
                        if (!flag)
                        {
                            floatPNL = null;
                        }
                        else
                        {
                            floatPNL = Convert.ToDecimal(cellFloatPNL.ToString());
                        }
                    }
                    ICell cellSupplementaryMargin = row.GetCell(7);
                    if (cellSupplementaryMargin != null)
                    {
                        supplementaryMargin = Convert.ToDecimal(cellSupplementaryMargin.ToString());
                    }
                    capitalDetail = new SHFECapitalDetail
                                        {
                                            YesterdayBalance = yesterdayBalance,
                                            Equity = equity,
                                            TodayWDSum = todayWDSum,
                                            Pledge = pledge,
                                            TodayPNL = todayPNL,
                                            Margin = margin,
                                            TodayCommission = todayCommission,
                                            AvailableCapital = availableCapital,
                                            TodayBalance = todayBalance,
                                            Risk = risk,
                                            FloatPNL = floatPNL,
                                            SupplementaryMargin = supplementaryMargin
                                        };
                    break;
                }
            }
            return capitalDetail;
        }

        private void SetHoldingHeaderIndex(IRow row)
        {
            for (int i = 0; i < 15; i++)
            {
                ICell cell = row.GetCell(i);
                if (cell != null && cell.ToString().Trim() == "合约")
                {
                    _holdingCodeIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "买持仓")
                {
                    _holdingBuyIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "买均价")
                {
                    _holdingBuyPriceIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "卖持仓")
                {
                    _holdingSellIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "卖均价")
                {
                    _holdingSellPriceIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "昨结算价")
                {
                    _holdingYesterdaySettlementPrice = i;
                }
                else if (cell != null && cell.ToString().Trim() == "今结算价")
                {
                    _holdingTodaySettlementPrice = i;
                }
                else if (cell != null && (cell.ToString().Trim() == "持仓盈亏" || cell.ToString().Trim() == "浮动盈亏"))
                {
                    _holdingPNLIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "交易保证金")
                {
                    _holdingMarginIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "投机/套保")
                {
                    _holdingPositionTypeIndex = i;
                }
            }
        }

        private void SetPositionHeaderIndex(IRow row)
        {
            for (int i = 0; i < 15; i++)
            {
                ICell cell = row.GetCell(i);
                if (cell != null && cell.ToString().Trim() == "合约")
                {
                    _positionCodeIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "买/卖")
                {
                    _positionDirectionIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "投机/套保")
                {
                    _positionTypeIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "成交价")
                {
                    _positionPriceIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "手数")
                {
                    _positionLotQuantityIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "开/平")
                {
                    _positionOpenCloseIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "手续费")
                {
                    _positionCommissionIndex = i;
                }
                else if (cell != null && cell.ToString().Trim() == "平仓盈亏")
                {
                    _positionPNLIndex = i;
                }
            }
        }

        /// <summary>
        ///     获取SHFE头寸的历持仓汇总数据
        /// </summary>
        /// <returns></returns>
        public List<SHFEHoldingPosition> GetSHFEHoldingPosition(List<SHFECodeClass> shfeCodeClasses)
        {
            var holdingPositions = new List<SHFEHoldingPosition>();

            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(0) : _xssfWorkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            bool start = false;
            int num = 0;
            while (rows.MoveNext())
            {
                IRow row = !_xlsx ? (IRow) rows.Current : (XSSFRow) rows.Current;
                if (!start)
                {
                    ICell cell = row.GetCell(0);
                    if (cell != null && cell.ToString().Trim() == "持仓汇总")
                    {
                        rows.MoveNext();
                        IRow rowHeader = (HSSFRow) rows.Current;

                        SetHoldingHeaderIndex(rowHeader);

                        start = true;
                    }
                }
                else
                {
                    var holdingPosition = new SHFEHoldingPosition();
                    num++;
                    int? positionDirection; //头寸方向
                    decimal? price; //价格
                    decimal? lotQuantity; //手数
                    decimal temp;
                    bool flag;

                    ICell cellSHFECode = row.GetCell(_holdingCodeIndex);
                    ICell cellTemp = row.GetCell(0);
                    if (cellTemp != null && cellSHFECode != null)
                    {
                        //期货合约
                        string shfeCode = cellSHFECode.ToString().Trim(); //期货合约
                        if (cellTemp.ToString().Trim() == "合计")
                        {
                            //数据EOF
                            break;
                        }
                        
                        holdingPosition.Alias = shfeCode;
                        SHFECodeClass codeClass = GetSHFECodeClassByCode(shfeCode, shfeCodeClasses);
                        if (codeClass == null)
                            continue;
                        int? shfeId = codeClass.SHFEId;
                        int? commodityId = codeClass.CommodityId;
                        if (shfeId != 0)
                        {
                            holdingPosition.SHFEId = shfeId;
                        }
                        if (commodityId != 0)
                        {
                            holdingPosition.CommodityId = commodityId;
                        }
                    }
                    ICell cellLotQuantity = row.GetCell(_holdingBuyIndex);
                    if (cellLotQuantity != null && cellLotQuantity.ToString().Trim() != string.Empty)
                    {
                        flag = decimal.TryParse(cellLotQuantity.ToString(), out temp);
                        if (!flag)
                        {
                            throw new Exception("持仓汇总第" + num + "行买持仓有误");
                        }
                        
                        lotQuantity = temp;
                        positionDirection = _longValue; //买入
                        holdingPosition.LotQuantity = lotQuantity;
                        holdingPosition.PositionDirection = positionDirection;

                        ICell cellPrice = row.GetCell(_holdingBuyPriceIndex);
                        if (cellPrice != null && cellPrice.ToString().Trim() != string.Empty)
                        {
                            //价格
                            flag = decimal.TryParse(cellPrice.ToString(), out temp);
                            if (!flag)
                            {
                                throw new Exception("持仓汇总第" + num + "行买均价有误");
                            }
                            
                            price = temp;
                            holdingPosition.Price = price;
                        }
                    }
                    else
                    {
                        cellLotQuantity = row.GetCell(_holdingSellIndex);
                        if (cellLotQuantity != null && cellLotQuantity.ToString().Trim() != string.Empty)
                        {
                            flag = decimal.TryParse(cellLotQuantity.ToString(), out temp);
                            if (!flag)
                            {
                                throw new Exception("持仓汇总第" + num + "行卖持仓有误");
                            }
                            
                            lotQuantity = temp;
                            positionDirection = _shortValue; //卖出
                            holdingPosition.LotQuantity = lotQuantity;
                            holdingPosition.PositionDirection = positionDirection;

                            ICell cellPrice = row.GetCell(_holdingSellPriceIndex);
                            if (cellPrice != null && cellPrice.ToString().Trim() != string.Empty)
                            {
                                //价格
                                flag = decimal.TryParse(cellPrice.ToString(), out temp);
                                if (!flag)
                                {
                                    throw new Exception("持仓汇总第" + num + "行卖均价有误");
                                }
                                
                                price = temp;
                                holdingPosition.Price = price;
                            }
                        }
                    }
                    ICell cellYesterdaySettlementPrice = row.GetCell(_holdingYesterdaySettlementPrice);
                    if (cellYesterdaySettlementPrice != null)
                    {
                        //昨日结算价
                        flag = decimal.TryParse(cellYesterdaySettlementPrice.ToString(), out temp);
                        if (!flag)
                        {
                            throw new Exception("持仓汇总第" + num + "行昨日结算有误");
                        }
                        
                        decimal? yesterdaySettlementPrice = temp; //上日结算价
                        holdingPosition.YesterdaySettlementPrice = yesterdaySettlementPrice;
                    }
                    ICell cellTodaySettlementPrice = row.GetCell(_holdingTodaySettlementPrice);
                    if (cellTodaySettlementPrice != null)
                    {
                        //今日结算价
                        flag = decimal.TryParse(cellTodaySettlementPrice.ToString(), out temp);
                        if (!flag)
                        {
                            throw new Exception("持仓汇总第" + num + "行今日结算有误");
                        }
                        
                        decimal? todaySettlementPrice = temp; //今日结算价
                        holdingPosition.TodaySettlementPrice = todaySettlementPrice;
                    }
                    ICell cellPNL = row.GetCell(_holdingPNLIndex);
                    if (cellPNL != null)
                    {
                        //持仓盈亏
                        flag = decimal.TryParse(cellPNL.ToString(), out temp);
                        if (!flag)
                        {
                            throw new Exception("持仓汇总第" + num + "行持仓盈亏有误");
                        }
                        
                        decimal? pnl = temp; //持仓盈亏
                        holdingPosition.PNL = pnl;
                    }
                    ICell cellMargin = row.GetCell(_holdingMarginIndex);
                    if (cellMargin != null)
                    {
                        //交易保证金
                        flag = decimal.TryParse(cellMargin.ToString(), out temp);
                        if (!flag)
                        {
                            throw new Exception("持仓汇总第" + num + "行交易保证金有误");
                        }
                        
                        decimal? margin = temp; //交易保证金
                        holdingPosition.Margin = margin;
                    }
                    ICell cellPositionType = row.GetCell(_holdingPositionTypeIndex);
                    if (cellPositionType != null)
                    {
                        //头寸类型
                        string strPositionType = cellPositionType.ToString().Trim();
                        int? positionType = GetPositionType(strPositionType); //头寸类型
                        holdingPosition.PositionType = positionType;
                    }
                    holdingPositions.Add(holdingPosition);
                }
            }
            return holdingPositions;
        }

        public List<string> GetAllSHFECode()
        {
            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(0) : _xssfWorkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            int start = 0;
            while (rows.MoveNext())
            {
                IRow row = !_xlsx ? (IRow) rows.Current : (XSSFRow) rows.Current;
                ICell cell = row.GetCell(0);


                if (start != 0)
                {
                    if (cell != null)
                    {
                        if (cell.ToString().Trim() == "合计")
                        {
                            start = 0;
                            continue;
                        }
                        
                        string code = string.Empty;
                        if (start == 1)
                        {
                            ICell cellCode = row.GetCell(_positionCodeIndex);
                            code = cellCode.ToString().Trim();
                        }
                        else if (start == 2)
                        {
                            ICell cellCode = row.GetCell(_holdingCodeIndex);
                            code = cellCode.ToString().Trim();
                        }
                        if (code != string.Empty)
                            SetCode(code);
                    }
                }
                if (cell != null && cell.ToString().Trim() == "成交汇总")
                {
                    start = 1;
                    rows.MoveNext();
                    IRow rowHeader = (HSSFRow) rows.Current;
                    SetPositionHeaderIndex(rowHeader);
                    continue;
                }
                if (cell != null && cell.ToString().Trim() == "持仓汇总")
                {
                    start = 2;
                    rows.MoveNext();
                    IRow rowHeader = (HSSFRow) rows.Current;
                    SetHoldingHeaderIndex(rowHeader);
                }
            }
            return _codes;
        }

        private void SetCode(string code)
        {
            if (!_codes.Contains(code))
            {
                _codes.Add(code);
            }
        }

        public List<SHFEFundFlow> GetSHFEFundFlow()
        {
            var shfeFundFlows = new List<SHFEFundFlow>();

            ISheet sheet = !_xlsx ? _hssfworkbook.GetSheetAt(0) : _xssfWorkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            bool start = false;
            int num = 0;
            while (rows.MoveNext())
            {
                IRow row = !_xlsx ? (IRow) rows.Current : (XSSFRow) rows.Current;
                if (!start)
                {
                    ICell cell = row.GetCell(0);
                    if (cell != null && cell.ToString().Trim() == "出入金明细")
                    {
                        rows.MoveNext();
                        start = true;
                    }
                }
                else
                {
                    var shfeFundFlow = new SHFEFundFlow();
                    num++;

                    ICell cellTradeDate = row.GetCell(0);
                    if (cellTradeDate != null)
                    {
                        //发生日期
                        string strTradeDate = cellTradeDate.ToString().Trim(); //发生日期
                        if (strTradeDate == "合计")
                        {
                            //数据EOF
                            break;
                        }

                        DateTime tradeDate;
                        bool flag = DateTime.TryParse(strTradeDate, out tradeDate);
                        if (flag)
                        {
                            shfeFundFlow.TradeDate = tradeDate;
                        }
                        else
                        {
                            throw new Exception("出入金明细第" + num + "行发生日期格式有误");
                        }

                        ICell cellAmountIn = row.GetCell(2);
                        decimal temp;
                        if (cellAmountIn != null)
                        {
                            //入金
                            flag = decimal.TryParse(cellAmountIn.ToString(), out temp);
                            decimal amountIn = !flag ? 0 : temp; //入金
                            shfeFundFlow.AmountIn = amountIn;
                        }

                        ICell cellAmountOut = row.GetCell(4);
                        if (cellAmountOut != null)
                        {
                            //出金
                            flag = decimal.TryParse(cellAmountOut.ToString(), out temp);
                            decimal amountOut = !flag ? 0 : temp; //出金
                            shfeFundFlow.AmountOut = amountOut;
                        }

                        ICell cellType = row.GetCell(6);
                        shfeFundFlow.Type = cellType != null ? cellType.ToString() : string.Empty;

                        ICell cellAbstract = row.GetCell(8);
                        shfeFundFlow.Abstract = cellAbstract != null ? cellAbstract.ToString() : string.Empty;

                        shfeFundFlows.Add(shfeFundFlow);
                    }
                }
            }
            return shfeFundFlows;
        }

        #region 设置枚举类型

        private int _arbitrageValue;
        private int _closeValue;
        private int _hedgeValue;
        private int _longValue;
        private int _openValue;
        private int _shortValue;
        private int _speculationValue;

        private void SetPositionType()
        {
            _hedgeValue = EnumHelper.GetValueByDes<PositionType>("保值");
            _arbitrageValue = EnumHelper.GetValueByDes<PositionType>("套利");
            _speculationValue = EnumHelper.GetValueByDes<PositionType>("投机");
        }

        private void SetPositionDirection()
        {
            _longValue = EnumHelper.GetValueByDes<PositionDirection>("买入");
            _shortValue = EnumHelper.GetValueByDes<PositionDirection>("卖出");
        }

        private void SetPositionOpenClose()
        {
            _openValue = EnumHelper.GetValueByDes<PositionOpenClose>("开仓");
            _closeValue = EnumHelper.GetValueByDes<PositionOpenClose>("平仓");
        }

        #endregion

        #region 定义变量

        private int _holdingBuyIndex;
        private int _holdingBuyPriceIndex;
        private int _holdingCodeIndex;
        private int _holdingMarginIndex;
        private int _holdingPNLIndex;
        private int _holdingPositionTypeIndex;
        private int _holdingSellIndex;
        private int _holdingSellPriceIndex;
        private int _holdingTodaySettlementPrice;
        private int _holdingYesterdaySettlementPrice;
        private int _positionCodeIndex;
        private int _positionCommissionIndex;
        private int _positionDirectionIndex;
        private int _positionLotQuantityIndex;
        private int _positionOpenCloseIndex;
        private int _positionPNLIndex;
        private int _positionPriceIndex;
        private int _positionTypeIndex;

        #endregion

        #endregion
    }

    public class SHFECodeClass
    {
        public string Code { get; set; }
        public string CommodityCode { get; set; }
        public int? CommodityId { get; set; }
        public int? SHFEId { get; set; }
        public DateTime? PromptDate { get; set; }
    }
}