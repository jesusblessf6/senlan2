using System;
using System.Collections.Generic;
using System.IO;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.SHFEPositionServiceReference;
using Client.SHFEServiceReference;
using Client.View.Futures.SHFE;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Futures.SHFE
{
    public class SHFEPositionImportVM : BaseVM
    {
        #region Member

        private List<BusinessPartner> _brokers;
        private string _fileName;
        private List<BusinessPartner> _innerCustomer;
        private int? _selectedBrokerId;
        private int? _selectedInnerCustomer;

        #endregion

        #region Property

        /// <summary>
        /// 选择的经纪行
        /// </summary>
        public int? SelectedBrokerId
        {
            get { return _selectedBrokerId; }
            set
            {
                if (_selectedBrokerId != value)
                {
                    _selectedBrokerId = value;
                    Notify("SelectedBrokerId");
                }
            }
        }

        /// <summary>
        /// 选择的内部客户
        /// </summary>
        public int? SelectedInnerCustomer
        {
            get { return _selectedInnerCustomer; }
            set
            {
                if (_selectedInnerCustomer != value)
                {
                    _selectedInnerCustomer = value;
                    Notify("SelectedInnerCustomer");
                }
            }
        }

        public List<BusinessPartner> Brokers
        {
            get { return _brokers; }
            set
            {
                if (_brokers != value)
                {
                    _brokers = value;
                    Notify("Brokers");
                }
            }
        }

        public List<BusinessPartner> InnerCustomer
        {
            get { return _innerCustomer; }
            set
            {
                if (_innerCustomer != value)
                {
                    _innerCustomer = value;
                    Notify("InnerCustomer");
                }
            }
        }

        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    Notify("FileName");
                }
            }
        }

        #endregion

        #region Constructor

        public SHFEPositionImportVM()
        {
            LoadData();
        }

        #endregion

        #region Method

        private void LoadData()
        {
            LoadBroker();
            LoadInnerCustomer();
        }

        /// <summary>
        /// 获取经纪行
        /// </summary>
        private void LoadBroker()
        {
            using (
                var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc)
                )
            {
                _brokers = busService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                _brokers.Insert(0, new BusinessPartner {Id = 0, Name = string.Empty});
            }
        }

        /// <summary>
        /// 获取内部客户
        /// </summary>
        private void LoadInnerCustomer()
        {
            using (
                var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc)
                )
            {
                _innerCustomer = busService.GetInternalCustomersByUser(CurrentUser.Id);
                _innerCustomer.Insert(0, new BusinessPartner {Id = 0, Name = string.Empty});
            }
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="fileStream"></param>
        public void ImportPosition(FileStream fileStream)
        {
            Validate();
            var excelHelper = new ImportExcelHelper(fileStream);
            List<string> codes = excelHelper.GetAllSHFECode();
            List<SHFECodeClass> shfeCodeClasses = AnalysisSHFECodes(codes);
            //交易日期
            DateTime dateTime = excelHelper.GetSHFEPositionDateTime();
            string capitalAccount = excelHelper.GetSHFEPositionCapitalAccount();

            //资金明细数据
            SHFECapitalDetail capitalDetail = excelHelper.GetSHFECapitalDetail();
            capitalDetail.CapitalAccount = capitalAccount;
            capitalDetail.TradeDate = dateTime;
            if (_selectedBrokerId != null) capitalDetail.AgentId = _selectedBrokerId.Value;
            if (_selectedInnerCustomer != null) capitalDetail.InternalBPId = _selectedInnerCustomer.Value;

            //成交汇总数据
            List<SHFEPosition> shfePositionList = excelHelper.GetSHFEPosition(shfeCodeClasses);

            //持仓汇总数据
            List<SHFEHoldingPosition> shfeHoldingPositions = excelHelper.GetSHFEHoldingPosition(shfeCodeClasses);

            List<SHFEFundFlow> shfeFundFlows = excelHelper.GetSHFEFundFlow();

            using (
                var shfePositionService =
                    SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
            {
                shfePositionService.ImportSHFEPosition(capitalDetail, shfePositionList, shfeHoldingPositions,shfeFundFlows,CurrentUser.Id);
            }
        }

        private List<SHFECodeClass> AnalysisSHFECodes(IEnumerable<string> codes)
        {
            var list = new List<SHFECodeClass>();
            foreach (string code in codes)
            {
                var shfeCodeClass = new SHFECodeClass {Code = code};
                string commodityCode = code.Substring(0, code.Length - 4);
                if (!ImportExcelHelper.Metals.Contains(commodityCode))
                    continue;
                shfeCodeClass.CommodityCode = commodityCode;
                string month = code.Substring(code.Length - 2);
                string year = "20" + code.Substring(code.Length - 4, 2);
                var promptDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 15);
                shfeCodeClass.PromptDate = promptDate;
                string shfeAlias = commodityCode + month;
                int commodityId = GetCommodityIdByCode(commodityCode);
                int shfeId;
                try
                {
                    shfeId = GetShfeIdByAlias(shfeAlias);
                }
                catch
                {
                    throw new Exception(ResSHFE.ContractError);
                }
                if (commodityId != 0)
                {
                    shfeCodeClass.CommodityId = commodityId;
                }
                if (shfeId != 0)
                {
                    shfeCodeClass.SHFEId = shfeId;
                }
                list.Add(shfeCodeClass);
            }
            return list;
        }

        private int GetCommodityIdByCode(string code)
        {
            int commodityId;
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Commodity commodity = commodityService.GetCommoditiyByCode(code);
                if (commodity != null)
                    commodityId = commodity.Id;
                else
                    commodityId = 0;
            }
            return commodityId;
        }

        private int GetShfeIdByAlias(string alias)
        {
            int shfeId;
            using (var shfeService = SvcClientManager.GetSvcClient<SHFEServiceClient>(SvcType.SHFESvc))
            {
                DBEntity.SHFE shfe = shfeService.GetShfeByAlias(alias);
                shfeId = shfe.Id;
            }
            return shfeId;
        }

        public override bool Validate()
        {
            if (!_selectedBrokerId.HasValue)
            {
                throw new Exception(Properties.Resources.BrokerRequired);
            }
            if (!_selectedInnerCustomer.HasValue)
            {
                throw new Exception(Properties.Resources.InternalCustomerRequired);
            }
            return true;
        }

        #endregion
    }
}