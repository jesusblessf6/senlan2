using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.LMEPositionServiceReference;
using Client.PricingServiceReference;
using Client.SHFEPositionServiceReference;
using Client.View.Reports;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using ZedGraph;

namespace Client.ViewModel.Reports
{
    public class ExposureChartVM : BaseVM
    {
        #region Member

        private int _commodityID;
        private List<Commodity> _commodityList;
        private DataTable _dt;
        private DateTime? _endDate;
        private int _internalCustomerID;
        private int _internalCustomerID2;
        private int _internalCustomerID3;
        private List<BusinessPartner> _internalCustomerList;
        private decimal? _proportionValue;
        private DateTime? _startDate;

        #endregion

        #region Property

        public decimal? ProportionValue
        {
            get { return _proportionValue; }
            set
            {
                if (_proportionValue != value)
                {
                    _proportionValue = value;
                    Notify("ProportionValue");
                }
            }
        }

        public DataTable DT
        {
            get { return _dt; }
            set
            {
                if (_dt != value)
                {
                    _dt = value;
                    Notify("DT");
                }
            }
        }

        public int InternalCustomerID3
        {
            get { return _internalCustomerID3; }
            set
            {
                if (_internalCustomerID3 != value)
                {
                    _internalCustomerID3 = value;
                    Notify("InternalCustomerID3");
                }
            }
        }

        public int InternalCustomerID2
        {
            get { return _internalCustomerID2; }
            set
            {
                if (_internalCustomerID2 != value)
                {
                    _internalCustomerID2 = value;
                    Notify("InternalCustomerID2");
                }
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    Notify("StartDate");
                }
            }
        }

        public int CommodityID
        {
            get { return _commodityID; }
            set
            {
                if (_commodityID != value)
                {
                    _commodityID = value;
                    Notify("CommodityID");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _commodityList; }
            set
            {
                if (_commodityList != value)
                {
                    _commodityList = value;
                    Notify("CommodityList");
                }
            }
        }

        public List<BusinessPartner> InternalCustomerList
        {
            get { return _internalCustomerList; }
            set
            {
                if (_internalCustomerList != value)
                {
                    _internalCustomerList = value;
                    Notify("InternalCustomerList");
                }
            }
        }

        public int InternalCustomerID
        {
            get { return _internalCustomerID; }
            set
            {
                if (_internalCustomerID != value)
                {
                    _internalCustomerID = value;
                    Notify("InternalCustomerID");
                }
            }
        }

        #endregion

        public ExposureChartVM()
        {
            ProportionValue = (decimal?)1.17;
            LoadInternalCustomer();
            LoadCommodityList();
        }

        #region Method

        private void LoadInternalCustomer()
        {
            using (
                var bpartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalCustomerList = bpartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (InternalCustomerList.Count > 0)
                {
                    InternalCustomerID = InternalCustomerList[0].Id;
                    InternalCustomerID2 = InternalCustomerList[0].Id;
                    InternalCustomerID3 = InternalCustomerList[0].Id;
                }
            }
        }

        private void LoadCommodityList()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commodityService.GetAll();
                if (CommodityList.Count > 0)
                {
                    if (CommodityID <= 0)
                    {
                        CommodityID = CommodityList[0].Id;
                    }
                }
            }
        }

        public override bool Validate()
        {
            if (StartDate == null)
            {
                throw new Exception(Properties.Resources.StartDateRequired);
            }

            if (EndDate == null)
            {
                throw new Exception(Properties.Resources.EndDateRequired);
            }

            if (EndDate < StartDate)
            {
                throw new Exception(Properties.Resources.DateLimitation);
            }

            //if (StartDate.Value.AddMonths(3) < EndDate)
            //{
            //    throw new Exception(ResReport.DateRangeLimit);
            //}

            if (ProportionValue == null)
            {
                throw new Exception(ResReport.DomesticHedgeRatioRequired);
            }

            return true;
        }

        #region 敞口折线图

        public void GetLine(ZedGraphControl zedGraphControl, DateTime? startDate, DateTime? endDate,
                            int commodityID, int internalCustomerID, decimal? proportionValue)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.IsVisible = true;
            myPane.XAxis.IsVisible = true;
            myPane.YAxis.IsVisible = true;
            myPane.YAxis.Title.Text = ResReport.Exposure;
            myPane.XAxis.Title.Text = Properties.Resources.Date;
            myPane.XAxis.Title.FontSpec.Size = 15.0F;
            myPane.YAxis.Title.FontSpec.Size = 15.0F;
            myPane.Title.Text = ResReport.ExposureTrend;
            TimeSpan? ts = endDate - startDate;
            int days = ts.Value.Days;
            var y = new double[days + 1];
            var x = new string[days + 1];
            var dt = new DataTable();
            dt.Columns.Add(Properties.Resources.Date);
            dt.Columns.Add(ResReport.Exposure);
            dt.Columns.Add(ResReport.PhysicalPurchase);
            dt.Columns.Add(ResReport.PhysicalSales);
            dt.Columns.Add(ResReport.LMELong);
            dt.Columns.Add(ResReport.LMEShort);
            dt.Columns.Add(ResReport.SHFELong);
            dt.Columns.Add(ResReport.SHFEShort);


            decimal? allQty1 = 0; //小于等于当天的所有现货采购量
            decimal? allQty2 = 0; //小于等于当天的所有现货销售量
            decimal? allLMEQty3 = 0; //小于等于当天的所有LME多头
            decimal? allLMEQty4 = 0;
            decimal? allSHFEQty3 = 0; //小于等于当天的所有SHFE多头
            decimal? allSHFEQty4 = 0;

            Commodity commodity;
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                commodity = commodityService.GetById(commodityID);
            }

            for (int i = 0; i < days + 1; i++)
            {
                DataRow dr = dt.NewRow();
                decimal? qty1; //当天现货采购
                decimal? qty2; //当天现货销售
                decimal? lmeQty3; //LME当天买入数量
                decimal? lmeQty4; //LME当天卖出数量
                decimal? shfeQty3; //SHFE当天买入数量
                decimal? shfeQty4; //SHFE当天卖出数量
                DateTime? start = startDate.Value.AddDays(i);
                x[i] = string.Format("{0:yyyy/MM/dd}", start);

                using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
                {
                    qty1 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "CurrentDay",
                                                             (int)ContractType.Purchase, CurrentUser.Id);
                    qty2 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "CurrentDay",
                                                             (int)ContractType.Sales, CurrentUser.Id);
                    if (start == startDate)
                    {
                        allQty1 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "All",
                                                                    (int)ContractType.Purchase, CurrentUser.Id);
                        allQty2 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "All",
                                                                    (int)ContractType.Sales, CurrentUser.Id);
                    }
                    else
                    {
                        allQty1 = allQty1 + qty1;
                        allQty2 = allQty2 + qty2;
                    }
                }
                using (
                    var lmePositionService =
                        SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
                {
                    lmeQty3 =
                        lmePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                              internalCustomerID, start, "CurrentDay", CurrentUser.Id) *
                        commodity.LMEQtyPerHand;
                    lmeQty4 =
                        lmePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                              internalCustomerID, start, "CurrentDay", CurrentUser.Id) *
                        commodity.LMEQtyPerHand;
                    if (start == startDate)
                    {
                        allLMEQty3 =
                            lmePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                                  internalCustomerID, start, "All", CurrentUser.Id) *
                            commodity.LMEQtyPerHand;
                        allLMEQty4 =
                            lmePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                                  internalCustomerID, start, "All", CurrentUser.Id) *
                            commodity.LMEQtyPerHand;
                    }
                    else
                    {
                        allLMEQty3 = allLMEQty3 + lmeQty3;
                        allLMEQty4 = allLMEQty4 + lmeQty4;
                    }
                }

                using (
                    var shfePositionService =
                        SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
                {
                    shfeQty3 =
                        shfePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                               internalCustomerID, start, "CurrentDay", CurrentUser.Id) *
                        commodity.SHFEQtyPerHand;
                    shfeQty4 =
                        shfePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                               internalCustomerID, start, "CurrentDay", CurrentUser.Id) *
                        commodity.SHFEQtyPerHand;
                    if (start == startDate)
                    {
                        allSHFEQty3 =
                            shfePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                                   internalCustomerID, start, "All", CurrentUser.Id) *
                            commodity.SHFEQtyPerHand;
                        allSHFEQty4 =
                            shfePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                                   internalCustomerID, start, "All", CurrentUser.Id) *
                            commodity.SHFEQtyPerHand;
                    }
                    else
                    {
                        allSHFEQty3 = allSHFEQty3 + shfeQty3;
                        allSHFEQty4 = allSHFEQty4 + shfeQty4;
                    }
                }
                double result =
                    Convert.ToDouble(allQty1 - allQty2 + allLMEQty3 - allLMEQty4 +
                                     (allSHFEQty3 - allSHFEQty4) * proportionValue);
                y[i] = result;
                dr[Properties.Resources.Date] = string.Format("{0:yyyy/MM/dd}", start);
                dr[ResReport.PhysicalPurchase] = qty1;
                dr[ResReport.PhysicalSales] = qty2;
                dr[ResReport.LMELong] = lmeQty3;
                dr[ResReport.LMEShort] = lmeQty4;
                dr[ResReport.SHFELong] = shfeQty3;
                dr[ResReport.SHFEShort] = shfeQty4;
                dr[ResReport.Exposure] = result;
                dt.Rows.Add(dr);
            }
            DT = dt;

            myPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "Curve 1" in the legend
            LineItem myCurve = myPane.AddCurve(ResReport.Exposure, null, y, Color.Red);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Display the Y axis grid lines
            myPane.XAxis.MajorTic.IsOpposite = true;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = x;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = true;
        }

        public void GetLineNew(ZedGraphControl zedGraphControl, DateTime? startDate, DateTime? endDate,
                            int commodityID, int internalCustomerID, decimal? proportionValue)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.IsVisible = true;
            myPane.XAxis.IsVisible = true;
            myPane.YAxis.IsVisible = true;
            myPane.YAxis.Title.Text = ResReport.Exposure;
            myPane.XAxis.Title.Text = Properties.Resources.Date;
            myPane.XAxis.Title.FontSpec.Size = 15.0F;
            myPane.YAxis.Title.FontSpec.Size = 15.0F;
            myPane.Title.Text = ResReport.ExposureTrend;
            TimeSpan? ts = endDate - startDate;
            int days = ts.Value.Days;
            var y = new double[days + 1];
            var x = new string[days + 1];
            var dt = new DataTable();
            dt.Columns.Add(Properties.Resources.Date);
            dt.Columns.Add(ResReport.Exposure);
            dt.Columns.Add(ResReport.PhysicalPurchase);
            dt.Columns.Add(ResReport.PhysicalSales);
            dt.Columns.Add(ResReport.LMELong);
            dt.Columns.Add(ResReport.LMEShort);
            dt.Columns.Add(ResReport.SHFELong);
            dt.Columns.Add(ResReport.SHFEShort);

            using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
            {
                List<ExposureChartClass> list = pricingService.GetLine(startDate, endDate, commodityID, internalCustomerID, proportionValue, CurrentUser.Id);
                int i = 0;
                foreach (ExposureChartClass item in list)
                {
                    DataRow dr = dt.NewRow();
                    dr[Properties.Resources.Date] = item.X;
                    dr[ResReport.PhysicalPurchase] = item.Qty1;
                    dr[ResReport.PhysicalSales] = item.Qty2;
                    dr[ResReport.LMELong] = item.LmeQty3;
                    dr[ResReport.LMEShort] = item.LmeQty4;
                    dr[ResReport.SHFELong] = item.ShfeQty3;
                    dr[ResReport.SHFEShort] = item.ShfeQty4;
                    dr[ResReport.Exposure] = item.Y;
                    dt.Rows.Add(dr);
                    x[i] = item.X;
                    y[i] = item.Y;
                    i++;
                }
            }

            DT = dt;

            myPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "Curve 1" in the legend
            LineItem myCurve = myPane.AddCurve(ResReport.Exposure, null, y, Color.Red);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Display the Y axis grid lines
            myPane.XAxis.MajorTic.IsOpposite = true;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = x;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = true;
        }

        public DataTable GetLineDateTable(int commodityID, int internalCustomerID, DateTime? startDate,
                                          DateTime? endDate, decimal? proportionValue)
        {
            var dt = new DataTable();
            dt.Columns.Add(Properties.Resources.Date);
            dt.Columns.Add(ResReport.Exposure);
            dt.Columns.Add(ResReport.PhysicalPurchase);
            dt.Columns.Add(ResReport.PhysicalSales);
            dt.Columns.Add(ResReport.LMELong);
            dt.Columns.Add(ResReport.LMEShort);
            dt.Columns.Add(ResReport.SHFELong);
            dt.Columns.Add(ResReport.SHFEShort);
            DateTime? start = startDate;
            while (start <= endDate)
            {
                decimal? qty1; //当天现货采购
                decimal? qty2; //当天现货销售
                decimal? lmeQty3; //LME当天买入数量
                decimal? lmeQty4; //LME当天卖出数量
                decimal? shfeQty3; //SHFE当天买入数量
                decimal? shfeQty4; //SHFE当天卖出数量
                decimal? allQty1; //小于等于当天的所有现货采购量
                decimal? allQty2; //小于等于当天的所有现货销售量
                decimal? allLMEQty3; //小于等于当天的所有LME多头
                decimal? allLMEQty4;
                decimal? allSHFEQty3; //小于等于当天的所有SHFE多头
                decimal? allSHFEQty4;

                DataRow dr = dt.NewRow();
                dr[Properties.Resources.Date] = string.Format("{0:yyyy/MM/dd}", start);
                using (var pricingService = SvcClientManager.GetSvcClient<PricingServiceClient>(SvcType.PricingSvc))
                {
                    qty1 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "CurrentDay",
                                                             (int)ContractType.Purchase, CurrentUser.Id);
                    qty2 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "CurrentDay",
                                                             (int)ContractType.Sales, CurrentUser.Id);
                    allQty1 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "All",
                                                                (int)ContractType.Purchase, CurrentUser.Id);
                    allQty2 = pricingService.GetQtyByParameters(commodityID, internalCustomerID, start, "All",
                                                                (int)ContractType.Sales, CurrentUser.Id);
                }

                using (
                    var lmePositionService =
                        SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
                {
                    lmeQty3 = lmePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                                    internalCustomerID, start, "CurrentDay",
                                                                    CurrentUser.Id);
                    allLMEQty3 = lmePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                                       internalCustomerID, start, "All", CurrentUser.Id);
                    lmeQty4 = lmePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                                    internalCustomerID, start, "CurrentDay",
                                                                    CurrentUser.Id);
                    allLMEQty4 = lmePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                                       internalCustomerID, start, "All", CurrentUser.Id);
                }

                using (
                    var shfePositionService =
                        SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
                {
                    shfeQty3 = shfePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                                      internalCustomerID, start, "CurrentDay",
                                                                      CurrentUser.Id);
                    allSHFEQty3 = shfePositionService.GetQtyByParameters((int)PositionDirection.Long, commodityID,
                                                                         internalCustomerID, start, "All",
                                                                         CurrentUser.Id);
                    shfeQty4 = shfePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                                      internalCustomerID, start, "CurrentDay",
                                                                      CurrentUser.Id);
                    allSHFEQty4 = shfePositionService.GetQtyByParameters((int)PositionDirection.Short, commodityID,
                                                                         internalCustomerID, start, "All",
                                                                         CurrentUser.Id);
                }
                dr[ResReport.PhysicalPurchase] = qty1;
                dr[ResReport.PhysicalSales] = qty2;
                dr[ResReport.LMELong] = lmeQty3;
                dr[ResReport.LMEShort] = lmeQty4;
                dr[ResReport.SHFELong] = shfeQty3;
                dr[ResReport.SHFEShort] = shfeQty4;
                dr[ResReport.Exposure] = allQty1 - allQty2 + allLMEQty3 - allLMEQty4 + (allSHFEQty3 - allSHFEQty4) * proportionValue;
                dt.Rows.Add(dr);
                start = start.Value.AddDays(1);
            }

            return dt;
        }

        #endregion

        #endregion
    }
}