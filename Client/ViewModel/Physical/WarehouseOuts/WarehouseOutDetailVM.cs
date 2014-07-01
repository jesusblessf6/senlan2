using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.View.Physical.WarehouseOuts;
using Client.WarehouseOutServiceReference;
using DBEntity;
using Utility.ServiceManagement;
using Client.SystemParameterServiceReference;
using DBEntity.EnableProperty;
using Client.BusinessPartnerServiceReference;

namespace Client.ViewModel.Physical.WarehouseOuts
{
    public class WarehouseOutDetailVM : BaseVM
    {
        #region Member

        private int _bpId;
        private string _comment;
        private int _commodityId;
        private string _commodityName;
        private int _internalCustomerID;
        private int _quotaId;
        private string _quotaNo;
        private int _warehouseId;
        private string _warehouseName;
        private DateTime? _warehouseOutDate = DateTime.Now.Date;
        private List<WarehouseOutLine> _warehouseOutLines;
        public decimal? TotalPackingQty = 0;
        public decimal TotalQty = 0;
        public decimal TotalVerQty = 0;
        private string _warehouseOutNo;
        private string _businessPartnerName;
        private int? _businessPartnerId;
        private List<int> _idList;
        private string _contractInfo;

        #region 出库行列表维护

        private List<WarehouseOutLine> _addWarehouseOutLines;
        private List<WarehouseOutLine> _deleteWarehouseOutLines;
        private List<WarehouseOutLine> _updateWarehouseOutLines;
        private List<WarehouseInLine> _warehouseInLines;

        #endregion

        #endregion

        #region Property
        public string ContractInfo
        {
            get { return _contractInfo; }
            set
            {
                if (_contractInfo != value)
                {
                    _contractInfo = value;
                    Notify("ContractInfo");
                }
            }
        }

        public List<int> IdList
        {
            get { return _idList; }
            set
            {
                if (_idList != value)
                {
                    _idList = value;
                    Notify("IdList");
                }
            }
        }

        public int? BusinessPartnerId
        {
            get { return _businessPartnerId; }
            set { 
                if(_businessPartnerId != value)
                {
                    _businessPartnerId = value;
                    Notify("BusinessPartnerId");
                }
            }
        }

        public string BusinessPartnerName
        {
            get { return _businessPartnerName; }
            set { 
                if(_businessPartnerName != value)
                {
                    _businessPartnerName = value;
                    Notify("BusinessPartnerName");
                }
            }
        }

        public string WarehouseOutNo
        {
            get { return _warehouseOutNo; }
            set { 
                if(_warehouseOutNo != value)
                {
                    _warehouseOutNo = value;
                    Notify("WarehouseOutNo");
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

        public List<WarehouseOutLine> DeleteWarehouseOutLines
        {
            get { return _deleteWarehouseOutLines; }
            set
            {
                if (_deleteWarehouseOutLines != value)
                {
                    _deleteWarehouseOutLines = value;
                    Notify("DeleteWarehouseOutLines");
                }
            }
        }

        public List<WarehouseOutLine> UpdateWarehouseOutLines
        {
            get { return _updateWarehouseOutLines; }
            set
            {
                if (_updateWarehouseOutLines != value)
                {
                    _updateWarehouseOutLines = value;
                    Notify("UpdateWarehouseOutLines");
                }
            }
        }

        public List<WarehouseOutLine> AddWarehouseOutLines
        {
            get { return _addWarehouseOutLines; }
            set
            {
                if (_addWarehouseOutLines != value)
                {
                    _addWarehouseOutLines = value;
                    Notify("AddWarehouseOutLines");
                }
            }
        }

        public List<WarehouseInLine> WarehouseInLines
        {
            get { return _warehouseInLines; }
            set
            {
                if (_warehouseInLines != value)
                {
                    _warehouseInLines = value;
                    Notify("WarehouseInLines");
                }
            }
        }

        public int BPId
        {
            get { return _bpId; }
            set
            {
                if (_bpId != value)
                {
                    _bpId = value;
                    Notify("BPId");
                }
            }
        }

        public List<WarehouseOutLine> Lines { get; set; }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    Notify("Comment");
                }
            }
        }

        public DateTime? WarehouseOutDate
        {
            get { return _warehouseOutDate; }
            set
            {
                if (_warehouseOutDate != value)
                {
                    _warehouseOutDate = value;
                    Notify("WarehouseOutDate");
                }
            }
        }

        public string CommodityName
        {
            get { return _commodityName; }
            set
            {
                if (_commodityName != value)
                {
                    _commodityName = value;
                    Notify("CommodityName");
                }
            }
        }

        public List<WarehouseOutLine> WarehouseOutLines
        {
            get { return _warehouseOutLines; }
            set
            {
                if (_warehouseOutLines != value)
                {
                    _warehouseOutLines = value;
                    Notify("WarehouseOutLines");
                }
            }
        }

        public int CommodityId
        {
            get { return _commodityId; }
            set
            {
                if (_commodityId != value)
                {
                    _commodityId = value;
                    Notify("CommodityId");
                }
            }
        }

        public int WarehouseId
        {
            get { return _warehouseId; }
            set
            {
                if (_warehouseId != value)
                {
                    _warehouseId = value;
                    Notify("WarehouseId");
                }
            }
        }

        public string WarehouseName
        {
            get { return _warehouseName; }
            set
            {
                if (_warehouseName != value)
                {
                    _warehouseName = value;
                    Notify("WarehouseName");
                }
            }
        }

        public int QuotaId
        {
            get { return _quotaId; }
            set
            {
                if (_quotaId != value)
                {
                    _quotaId = value;
                    Notify("QuotaId");
                }
            }
        }

        public string QuotaNo
        {
            get { return _quotaNo; }
            set
            {
                if (_quotaNo != value)
                {
                    _quotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        #endregion

        #region Constructor

        public WarehouseOutDetailVM()
        {
            ObjectId = 0;
            GetIDList();
            AddWarehouseOutLines = new List<WarehouseOutLine>();
            WarehouseInLines = new List<WarehouseInLine>();
            WarehouseOutLines = new List<WarehouseOutLine>();
            LoadDocumentEnableProperty(ObjectId);
        }

        public WarehouseOutDetailVM(int warehouseOutId)
        {
            ObjectId = warehouseOutId;
            GetIDList();
            AddWarehouseOutLines = new List<WarehouseOutLine>();
            UpdateWarehouseOutLines = new List<WarehouseOutLine>();
            DeleteWarehouseOutLines = new List<WarehouseOutLine>();
            WarehouseInLines = new List<WarehouseInLine>();
            LoadWarehouseOut();
            LoadDocumentEnableProperty(ObjectId);
        }

        #endregion

        #region Method
        #region 加载当前用户关联内部客户
        public void GetIDList()
        {
            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    IdList = list.Select(c => c.Id).ToList();
                }
            }
        }
        #endregion

        public void SetWarehouseOutNo()
        {
            using (var systemParameterService = SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
            {
                List<SystemParameter> systemParameterList = systemParameterService.GetAll();
                if(systemParameterList.Count > 0)
                {
                    SystemParameter systemParameter = systemParameterList[0];
                    if(systemParameter != null)
                    {
                        string year = DateTime.Now.ToString("yy");
                        if (string.IsNullOrEmpty(systemParameter.WarehouseOutNo))
                        {
                            WarehouseOutNo = year + "-0001";
                        }
                        else
                        {
                            string lastY =  systemParameter.WarehouseOutNo.Substring(0,2);
                            if (Math.Abs(Convert.ToDouble(year) - Convert.ToDouble(lastY)) < double.Epsilon)
                            {
                                string value = systemParameter.WarehouseOutNo.Substring(3);
                                int maxValue = Convert.ToInt32(value) + 1;
                                string maxResult = maxValue.ToString(CultureInfo.InvariantCulture);
                                for (int i = 1; i <= (4 - maxValue.ToString(CultureInfo.InvariantCulture).Length); i++)
                                {
                                    maxResult = ("0" + maxResult);
                                }
                                WarehouseOutNo = lastY + "-" + maxResult;
                            }
                            else
                            {
                                string nowYear = DateTime.Now.ToString("yy");
                                WarehouseOutNo = nowYear + "-0001";
                            }
                        }
                    }
                }
            }
        }

        public void SetQty(List<WarehouseOutLine> lines)
        {
            if (lines.Count > 0)
            {
                Lines = new List<WarehouseOutLine>();
                TotalQty = 0;
                TotalVerQty = 0;
                TotalPackingQty = 0;
                foreach (WarehouseOutLine line in lines)
                {
                    TotalQty += Convert.ToDecimal(line.Quantity);
                    TotalVerQty += Convert.ToDecimal(line.VerifiedQuantity);
                    TotalPackingQty += line.PackingQuantity;
                    Lines.Add(line);
                }
                Lines.Add(new WarehouseOutLine
                              {Quantity = TotalQty, VerifiedQuantity = TotalVerQty, PackingQuantity = TotalPackingQty});
            }
            else
            {
                TotalQty = 0;
                TotalVerQty = 0;
                Lines = new List<WarehouseOutLine>();
            }
        }

        public void LoadWarehouseOut()
        {
            if (ObjectId > 0)
            {
                using (
                    var warehouseOutService =
                        SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
                {
                    const string str = "it.Id = @p1 ";
                    var parameters = new List<object> {ObjectId};
                    List<WarehouseOut> warehouseOuts = warehouseOutService.Select(str, parameters,
                                                                                  new List<string>
                                                                                      {
                                                                                          "Quota",
                                                                                          "Warehouse",
                                                                                          "BusinessPartner",
                                                                                          "Quota.Contract.BusinessPartner",
                                                                                          "Quota.Contract.InternalCustomer",
                                                                                          "Quota.Commodity",
                                                                                          "Quota.QuotaBrandRels",
                                                                                          "WarehouseOutLines",
                                                                                          "WarehouseOutLines.WarehouseInLine.DeliveryLine.Delivery.Quota.Commodity",
                                                                                          "WarehouseOutLines.WarehouseInLine",
                                                                                          "WarehouseOutLines.Brand",
                                                                                          "WarehouseOutLines.CommodityType",
                                                                                          "WarehouseOutLines.WarehouseOutDeliveryPersons"
                                                                                      });
                    if (warehouseOuts.Count > 0)
                    {
                        WarehouseOut warehouseOut = warehouseOuts[0];
                        FilterDeleted(warehouseOut.WarehouseOutLines);
                        QuotaNo = warehouseOut.Quota.QuotaNo;
                        QuotaId = warehouseOut.Quota.Id;
                        WarehouseId = warehouseOut.Warehouse.Id;
                        WarehouseOutDate = warehouseOut.WarehouseOutDate;
                        WarehouseName = warehouseOut.Warehouse.Name;
                        Comment = warehouseOut.Comment;
                        CommodityId = warehouseOut.Quota.Commodity.Id;
                        InternalCustomerID = warehouseOut.Quota.Contract.InternalCustomerId ?? 0;
                        WarehouseOutLines = warehouseOut.WarehouseOutLines.Where(c => c.IsDeleted == false).ToList();
                        WarehouseOutNo = warehouseOut.WarehouseOutNo;
                        if(warehouseOut.BusinessPartner != null)
                        {
                            BusinessPartnerName = warehouseOut.BusinessPartner.ShortName;
                            BusinessPartnerId = warehouseOut.BusinessPartner.Id;
                        }
                        ContractInfo = warehouseOut.Quota.ContractInfo;
                    }
                }
            }
        }

        /// <summary>
        /// 新增出库
        /// </summary>
        protected override void Create()
        {
            //SetWarehouseOutNo();
            var warehouseOut = new WarehouseOut
                                   {
                                       QuotaId = QuotaId,
                                       WarehouseOutDate = WarehouseOutDate,
                                       Comment = Comment,
                                       WarehouseId = WarehouseId,
                                       ActualDeliveryBPId = BusinessPartnerId
                                   };
            using (
                var warehouseOutService =
                    SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
            {
                warehouseOutService.CreateDocument(CurrentUser.Id, warehouseOut, AddWarehouseOutLines, WarehouseInLines,
                                                   QuotaId);
            }
        }

        /// <summary>
        /// 更新出库
        /// </summary>
        protected override void Update()
        {
            using (
                var warehouseOutService =
                    SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
            {
                WarehouseOut warehouseOut = warehouseOutService.GetById(ObjectId);
                if (warehouseOut != null)
                {
                    warehouseOut.Comment = Comment;
                    warehouseOut.QuotaId = QuotaId;
                    warehouseOut.ActualDeliveryBPId = BusinessPartnerId;
                    warehouseOut.WarehouseId = WarehouseId;
                    warehouseOut.WarehouseOutDate = WarehouseOutDate;
                    warehouseOut.WarehouseOutNo = WarehouseOutNo;
                }
                warehouseOutService.UpdateDocument(CurrentUser.Id, warehouseOut, AddWarehouseOutLines,
                                                   UpdateWarehouseOutLines, DeleteWarehouseOutLines, WarehouseInLines,
                                                   QuotaId);
            }
        }

        public void DelWarehouseOutLine(int warehouseOutLineID)
        {
            if (WarehouseOutLines.Count > 0)
            {
                List<WarehouseOutLine> lines = WarehouseOutLines.Where(c => c.Id == warehouseOutLineID).ToList();
                WarehouseOutLine line = lines[0];
                WarehouseOutLines.Remove(line);
                if (line.Id > 0)
                {
                    DeleteWarehouseOutLines.Add(line);
                }
                else
                {
                    AddWarehouseOutLines.Remove(line);
                }
            }
        }

        public bool ValidateAdd()
        {
            if (QuotaId == 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }
            if (WarehouseId == 0)
            {
                throw new Exception(Properties.Resources.WarehouseRequired);
            }
            return true;
        }

        public override bool Validate()
        {
            if (QuotaId == 0)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }

            if (string.IsNullOrEmpty(WarehouseName))
            {
                throw new Exception(Properties.Resources.WarehouseRequired);
            }

            if (WarehouseOutLines.Count <= 0)
            {
                throw new Exception(ResWarehouseOut.WarehouseOutLineRequired);
            }

            return true;
        }
        //控件编辑属性
        private bool _isWarehouseEnable;
        private bool _isQuotaEnable;

        public bool IsWarehouseEnable
        {
            get { return _isWarehouseEnable; }
            set
            {
                if (_isWarehouseEnable != value)
                {
                    _isWarehouseEnable = value;
                    Notify("IsWarehouseEnable");
                }
            }
        }

        public bool IsQuotaEnable
        {
            get { return _isQuotaEnable; }
            set
            {
                if (_isQuotaEnable != value)
                {
                    _isQuotaEnable = value;
                    Notify("IsQuotaEnable");
                }
            }
        }

        private void LoadDocumentEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsWarehouseEnable = true;
                IsQuotaEnable = true;
            }
            else
            {
                using (var warehouseOutService =
                    SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
                {
                    WarehouseOutEnableProperty woep = warehouseOutService.SetElementsEnableProperty(id);
                    IsWarehouseEnable = woep.IsWarehouseEnable;
                    IsQuotaEnable = woep.IsQuotaEnable;
                }
            }
        }

        #endregion
    }
}