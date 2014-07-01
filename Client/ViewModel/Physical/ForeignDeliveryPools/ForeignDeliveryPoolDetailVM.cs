using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Client.AttachmentServiceReference;
using Client.Base.BaseClientVM;
using Client.CommodityServiceReference;
using Client.CountryServiceReference;
using Client.ForeignDeliveryPoolServiceReference;
using Client.ForeignDeliveryPoolLineServiceReference;
using Client.PortServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using DBEntity.EnableProperty;

namespace Client.ViewModel.Physical.ForeignDeliveryPools
{
    public class ForeignDeliveryPoolDetailVM : ObjectBaseVM
    {
        #region Members & Properties

        public int DeliveryTypeId { get; set; }
        public string DeliveryTypeName { get; set; }
        public List<ForeignDeliveryPoolLine> NewAddedLines { get; set; }
        public List<ForeignDeliveryPoolLine> ModifiedLines { get; set; }
        public List<ForeignDeliveryPoolLine> DeletedLines { get; set; }
        public List<Attachment> NewAddAttachments { get; set; }
        public List<Attachment> DeletedAttachments { get; set; }
        public List<FDPStorageFeeSEDate> NewAddedStorageDateLines { get; set; }
        public List<FDPStorageFeeSEDate> ModifiedStorageDateLines { get; set; }
        public List<FDPStorageFeeSEDate> DeletedStorageDateLines { get; set; }
        private string _MarkNo { get; set; }
        public string MarkNo
        {
            get { return _MarkNo; }
            set
            {
                if (_MarkNo != value)
                {
                    _MarkNo = value;
                    Notify("MarkNo");
                }
            }
        }

        private string _deliveryNo;
        public string DeliveryNo
        {
            get { return _deliveryNo; }
            set
            {
                if (_deliveryNo != value)
                {
                    _deliveryNo = value;
                    Notify("DeliveryNo");
                }
            }
        }

        private List<Commodity> _commodities;
        public List<Commodity> Commodities
        {
            get { return _commodities; }
            set
            {
                _commodities = value;
                Notify("Commodities");
            }
        }

        private int _selectedCommodityId;
        public int SelectedCommodityId
        {
            get { return _selectedCommodityId; }
            set
            {
                if (_selectedCommodityId != value)
                {
                    _selectedCommodityId = value;
                    Notify("SelectedCommodityId");
                }
            }
        }

        private int _shipperId;
        public int ShipperId
        {
            get { return _shipperId; }
            set
            {
                if (_shipperId != value)
                {
                    _shipperId = value;
                    Notify("ShipperId");
                }
            }
        }

        private string _shipperName;
        public string ShipperName
        {
            get { return _shipperName; }
            set
            {
                if (_shipperName != value)
                {
                    _shipperName = value;
                    Notify("ShipperName");
                }
            }
        }

        private string _vesselNo;
        public string VesselNo
        {
            get { return _vesselNo; }
            set
            {
                if (_vesselNo != value)
                {
                    _vesselNo = value;
                    Notify("VesselNo");
                }
            }
        }

        private int _shipperPartyId;
        public int ShipperPartyId
        {
            get { return _shipperPartyId; }
            set
            {
                if (_shipperPartyId != value)
                {
                    _shipperPartyId = value;
                    Notify("ShipperPartyId");
                }
            }
        }

        private string _shipperPartyName;
        public string ShipperPartyName
        {
            get { return _shipperPartyName; }
            set
            {
                if (_shipperPartyName != value)
                {
                    _shipperPartyName = value;
                    Notify("ShipperPartyName");
                }
            }
        }

        private int _notifyPartyId;
        public int NotifyPartyId
        {
            get { return _notifyPartyId; }
            set
            {
                if (_notifyPartyId != value)
                {
                    _notifyPartyId = value;
                    Notify("NotifyPartyId");
                }
            }
        }

        private string _notifyPartyName;
        public string NotifyPartyName
        {
            get { return _notifyPartyName; }
            set
            {
                if (_notifyPartyName != value)
                {
                    _notifyPartyName = value;
                    Notify("NotifyPartyName");
                }
            }
        }

        private DateTime? _issueDate;
        public DateTime? IssueDate
        {
            get { return _issueDate; }
            set
            {
                if (_issueDate != value)
                {
                    _issueDate = value;
                    Notify("IssueDate");
                }
            }
        }

        private DateTime? _onBoardDate;
        public DateTime? OnBoardDate
        {
            get { return _onBoardDate; }
            set
            {
                if (_onBoardDate != value)
                {
                    _onBoardDate = value;
                    Notify("OnBoardDate");
                }
            }
        }

        private int _warehouseProviderId;
        public int WarehouseProviderId
        {
            get { return _warehouseProviderId; }
            set
            {
                if (_warehouseProviderId != value)
                {
                    _warehouseProviderId = value;
                    Notify("WarehouseProviderId");
                }
            }
        }

        private string _warehouseProviderName;
        public string WarehouseProviderName
        {
            get { return _warehouseProviderName; }
            set
            {
                if (_warehouseProviderName != value)
                {
                    _warehouseProviderName = value;
                    Notify("WarehouseProviderName");
                }
            }
        }

        private int _warehouseId;
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

        private string _warehouseName;
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

        private string _packingStandard;
        public string PackingStandard
        {
            get { return _packingStandard; }
            set
            {
                if (_packingStandard != value)
                {
                    _packingStandard = value;
                    Notify("PackingStandard");
                }
            }
        }

        private List<Country> _countries;
        public List<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                Notify("Countries");
            }
        }

        private int _selectedLoadingPlaceId;
        public int SelectedLoadingPlaceId
        {
            get { return _selectedLoadingPlaceId; }
            set
            {
                if (_selectedLoadingPlaceId != value)
                {
                    _selectedLoadingPlaceId = value;
                    Notify("SelectedLoadingPlaceId");
                }
            }
        }

        private int _selectedDischargePlaceId;
        public int SelectedDischargePlaceId
        {
            get { return _selectedDischargePlaceId; }
            set
            {
                if (_selectedDischargePlaceId != value)
                {
                    _selectedDischargePlaceId = value;
                    Notify("SelectedDischargePlaceId");
                }
            }
        }

        private int _selectedLoadingPortId;
        public int SelectedLoadingPortId
        {
            get { return _selectedLoadingPortId; }
            set
            {
                if (_selectedLoadingPortId != value)
                {
                    _selectedLoadingPortId = value;
                    Notify("SelectedLoadingPortId");
                }
            }
        }

        private List<Port> _loadingPorts;
        public List<Port> LoadingPorts
        {
            get { return _loadingPorts; }
            set
            {
                _loadingPorts = value;
                Notify("LoadingPorts");
            }
        }

        private int _selectedDischargePortId;
        public int SelectedDischargePortId
        {
            get { return _selectedDischargePortId; }
            set
            {
                if (_selectedDischargePortId != value)
                {
                    _selectedDischargePortId = value;
                    Notify("SelectedDischargePortId");
                }
            }
        }

        private List<Port> _dischargePorts;
        public List<Port> DischargePorts
        {
            get { return _dischargePorts; }
            set
            {
                _dischargePorts = value;
                Notify("DischargePorts");
            }
        }

        private List<ForeignDeliveryPoolLine> _details;
        public List<ForeignDeliveryPoolLine> Details
        {
            get { return _details; }
            set
            {
                _details = value;
                Notify("Details");
            }
        }

        private List<Attachment> _attachments;
        public List<Attachment> Attachments
        {
            get { return _attachments; }
            set
            {
                _attachments = value;
                Notify("Attachments");
            }
        }

        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    Notify("Comments");
                }
            }
        }

        private List<FDPStorageFeeSEDate> _storageDates;
        public List<FDPStorageFeeSEDate> StorageDates
        {
            get { return _storageDates; }
            set
            {
                _storageDates = value;
                Notify("StorageDates");
            }
        }

        #region Properties related to the items' attributes

        public string DeliveryNoContent
        {
            get
            {
                if (DeliveryTypeId == (int)DeliveryType.ExternalTDBOL)
                {
                    return "外贸提单号";
                }

                if (DeliveryTypeId == (int)DeliveryType.ExternalTDWW)
                {
                    return "外贸仓单号";
                }

                return "";
            }
        }

        public string VisibilityForBL
        {
            get
            {
                if (DeliveryTypeId == (int)DeliveryType.ExternalTDBOL)
                {
                    return "Visible";
                }

                if (DeliveryTypeId == (int)DeliveryType.ExternalTDWW)
                {
                    return "Collapsed";
                }

                return "Collapsed";
            }
        }

        public string VisibilityForWR
        {
            get
            {
                if (DeliveryTypeId == (int)DeliveryType.ExternalTDBOL)
                {
                    return "Collapsed";
                }

                if (DeliveryTypeId == (int)DeliveryType.ExternalTDWW)
                {
                    return "Visible";
                }

                return "Collapsed";
            }
        }

        #endregion

        #endregion

        #region Constructor

        public ForeignDeliveryPoolDetailVM(int deliveryTypeId)
        {
            ObjectId = 0;
            DeliveryTypeId = deliveryTypeId;
            LoadDocumentEnableProperty(ObjectId);
            Initialize();
        }

        public ForeignDeliveryPoolDetailVM(int id, int deliveryTypeId)
        {
            DeliveryTypeId = deliveryTypeId;
            ObjectId = id;
            LoadDocumentEnableProperty(ObjectId);
            Initialize();
        }

        #endregion

        #region Method

        private void Initialize()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
                _commodities.Insert(0, new Commodity());
            }

            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                _countries = countryService.GetAll().OrderBy(o => o.Name).ToList();
                _countries.Insert(0, new Country());
            }

            DeliveryTypeName = EnumHelper.GetDesByValue<DeliveryType>(DeliveryTypeId);


            using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
            {
                var tmpPorts = portService.GetAll().OrderBy(o => o.Name).ToList();
                tmpPorts.Insert(0, new Port());
                _loadingPorts = tmpPorts;
                _dischargePorts = tmpPorts;
                //SelectedLoadingPortId = -1;
                SelectedLoadingPortId = 0;
                SelectedDischargePortId = 0;
            }

            //_loadingPorts = new List<Port> { new Port() };
            //_dischargePorts = new List<Port> { new Port() };

            _details = new List<ForeignDeliveryPoolLine>();
            NewAddedLines = new List<ForeignDeliveryPoolLine>();
            ModifiedLines = new List<ForeignDeliveryPoolLine>();
            DeletedLines = new List<ForeignDeliveryPoolLine>();

            NewAddAttachments = new List<Attachment>();
            DeletedAttachments = new List<Attachment>();
            _attachments = new List<Attachment>();

            _storageDates = new List<FDPStorageFeeSEDate>();
            NewAddedStorageDateLines = new List<FDPStorageFeeSEDate>();
            ModifiedStorageDateLines = new List<FDPStorageFeeSEDate>();
            DeletedStorageDateLines = new List<FDPStorageFeeSEDate>();

            if (ObjectId > 0)
            {
                using (var dpService = SvcClientManager.GetSvcClient<ForeignDeliveryPoolServiceClient>(SvcType.ForeignDeliveryPoolSvc))
                {
                    var dp = dpService.SelectById(new List<string>
                                                     {
                                                         "Shipper",
                                                         "ShippingParty",
                                                         "NotifyParty",
                                                         "WarehouseProvider",
                                                         "Warehouse",
                                                         "Document",
                                                         "ForeignDeliveryPoolLines",
                                                         "ForeignDeliveryPoolLines.CommodityType",
                                                         "ForeignDeliveryPoolLines.Brand",
                                                         "ForeignDeliveryPoolLines.Specification",
                                                         "ForeignDeliveryPoolLines.OriginCountry",
                                                         "FDPStorageFeeSEDates"
                                                     }, ObjectId);
                    _deliveryNo = dp.DeliveryNo;
                    _selectedCommodityId = dp.CommodityId;
                    _shipperId = dp.ShipperId ?? 0;
                    _shipperName = dp.Shipper == null ? null : dp.Shipper.ShortName;
                    _vesselNo = dp.VesselNo;
                    _shipperPartyId = dp.ShippingPartyId ?? 0;
                    _shipperPartyName = dp.ShippingParty == null ? null : dp.ShippingParty.ShortName;
                    _notifyPartyId = dp.NotifyPartyId ?? 0;
                    _notifyPartyName = dp.NotifyParty == null ? null : dp.NotifyParty.ShortName;
                    _issueDate = dp.IssueDate;
                    _onBoardDate = dp.OnBoardDate;
                    _warehouseProviderId = dp.WarehouseProviderId ?? 0;
                    _warehouseProviderName = dp.WarehouseProvider == null ? null : dp.WarehouseProvider.ShortName;
                    _warehouseId = dp.WarehouseId ?? 0;
                    _warehouseName = dp.Warehouse == null ? null : dp.Warehouse.Name;
                    _packingStandard = dp.PackingStandard;
                    _comments = dp.Comment;
                    MarkNo = dp.MarkNo;

                    //装运地和装运港
                    _selectedLoadingPlaceId = dp.LoadingPlaceId ?? 0;
                    if (_selectedLoadingPlaceId > 0)
                    {
                        using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                        {
                            _loadingPorts = portService.GetPortsByCountry(_selectedLoadingPlaceId).OrderBy(o => o.Name).ToList();
                            _loadingPorts.Insert(0, new Port());
                            _selectedLoadingPortId = dp.LoadingPortId ?? 0;
                        }
                    }

                    //卸货地和卸货港
                    _selectedDischargePlaceId = dp.DischargePlaceId ?? 0;
                    if (_selectedDischargePlaceId > 0)
                    {
                        using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                        {
                            _dischargePorts = portService.GetPortsByCountry(_selectedDischargePlaceId).OrderBy(o => o.Name).ToList(); ;
                            _dischargePorts.Insert(0, new Port());
                            _selectedDischargePortId = dp.DischargePortId ?? 0;
                        }
                    }

                    //明细
                    FilterDeleted(dp.ForeignDeliveryPoolLines);
                    _details = dp.ForeignDeliveryPoolLines.ToList();

                    //Storage Dates
                    FilterDeleted(dp.FDPStorageFeeSEDates);
                    _storageDates = dp.FDPStorageFeeSEDates.ToList();

                    //附件
                    using (var attachService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
                    {
                        var atts = attachService.GetAttachments(dp.DocumentId, dp.Id);
                        _attachments = attachService.ChangeAttachmentName(atts);
                    }
                }
            }
            else
            {
                _packingStandard = "IN BUNDLES";
                _issueDate = DateTime.Today;
            }


            PropertyChanged += OnPropertyChanged;
        }

        protected override void Create()
        {
            using (var dpService = SvcClientManager.GetSvcClient<ForeignDeliveryPoolServiceClient>(SvcType.ForeignDeliveryPoolSvc))
            {
                var dp = new ForeignDeliveryPool
                             {
                                 DeliveryNo = DeliveryNo,
                                 IssueDate = IssueDate,
                                 WarehouseProviderId = ConvertZeroToNull(WarehouseProviderId),
                                 WarehouseId = ConvertZeroToNull(WarehouseId),
                                 Comment = Comments,
                                 ShipperId = ConvertZeroToNull(ShipperId),
                                 NotifyPartyId = ConvertZeroToNull(NotifyPartyId),
                                 ShippingPartyId = ConvertZeroToNull(ShipperPartyId),
                                 OnBoardDate = OnBoardDate,
                                 VesselNo = VesselNo,
                                 LoadingPortId = ConvertZeroToNull(SelectedLoadingPortId),
                                 LoadingPlaceId = ConvertZeroToNull(SelectedLoadingPlaceId),
                                 DischargePlaceId = ConvertZeroToNull(SelectedDischargePlaceId),
                                 DischargePortId = ConvertZeroToNull(SelectedDischargePortId),
                                 PackingStandard = PackingStandard,
                                 CommodityId = SelectedCommodityId,
                                 DeliveryType = DeliveryTypeId,
                                 MarkNo = MarkNo
                             };

                dpService.CreateDocument(dp, NewAddedLines, NewAddAttachments, NewAddedStorageDateLines, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var dpService = SvcClientManager.GetSvcClient<ForeignDeliveryPoolServiceClient>(SvcType.ForeignDeliveryPoolSvc))
            {
                var olddp = dpService.GetById(ObjectId);

                olddp.DeliveryNo = DeliveryNo;
                olddp.IssueDate = IssueDate;
                olddp.WarehouseProviderId = ConvertZeroToNull(WarehouseProviderId);
                olddp.WarehouseId = ConvertZeroToNull(WarehouseId);
                olddp.Comment = Comments;
                olddp.ShipperId = ConvertZeroToNull(ShipperId);
                olddp.NotifyPartyId = ConvertZeroToNull(NotifyPartyId);
                olddp.ShippingPartyId = ConvertZeroToNull(ShipperPartyId);
                olddp.OnBoardDate = OnBoardDate;
                olddp.VesselNo = VesselNo;
                olddp.LoadingPortId = ConvertZeroToNull(SelectedLoadingPortId);
                olddp.LoadingPlaceId = ConvertZeroToNull(SelectedLoadingPlaceId);
                olddp.DischargePlaceId = ConvertZeroToNull(SelectedDischargePlaceId);
                olddp.DischargePortId = ConvertZeroToNull(SelectedDischargePortId);
                olddp.PackingStandard = PackingStandard;
                olddp.CommodityId = SelectedCommodityId;
                olddp.DeliveryType = DeliveryTypeId;
                olddp.MarkNo = MarkNo;

                dpService.UpdateDocument(olddp, NewAddedLines, ModifiedLines, DeletedLines, NewAddAttachments,
                                         DeletedAttachments, NewAddedStorageDateLines, ModifiedStorageDateLines, DeletedStorageDateLines, CurrentUser.Id);
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(DeliveryNo))
            {
                throw new Exception("请输入提单/仓单号");
            }

            if (SelectedCommodityId == 0)
            {
                throw new Exception("请选择金属");
            }

            //if (ShipperId == 0 && DeliveryTypeId == (int) DeliveryType.ExternalTDBOL)
            //{
            //    throw new Exception("请选择发货人");
            //}

            if (WarehouseId == 0 && DeliveryTypeId == (int)DeliveryType.ExternalTDWW)
            {
                throw new Exception("请选择仓库");
            }

            if (IssueDate == null)
            {
                throw new Exception("请输入开具日期");
            }

            if (Details.Count == 0)
            {
                throw new Exception("请输入明细行");
            }

            if (CheckDeliveryNo(DeliveryNo))
            {
                throw new Exception("提单/仓单号已存在");
            }

            return true;
        }


        private bool CheckDeliveryNo(string deliveryNo)
        {
            bool flag = false;
            using (var poolService = SvcClientManager.GetSvcClient<ForeignDeliveryPoolServiceClient>(SvcType.ForeignDeliveryPoolSvc))
            {
                string queryStr = "it.DeliveryNo = '" + deliveryNo.Trim() + "'";
                if (ObjectId > 0)
                {
                    queryStr += " and it.Id !=" + ObjectId;
                }
                List<ForeignDeliveryPool> list = poolService.Select(queryStr, null,null);
                if (list.Count > 0)
                    flag = true;
            }
            return flag;
        }

        public string GetAttachmentFileName(int id)
        {
            return Attachments.Single(o => o.Id == id).FileName;
        }

        public void RemoveDetailLine(int poolLineId)
        {
            if (poolLineId > 0)
            {
                ModifiedLines.RemoveAll(o => o.Id == poolLineId);
                DeletedLines.Add(Details.Single(o => o.Id == poolLineId));
            }

            if (poolLineId < 0)
            {
                NewAddedLines.RemoveAll(o => o.Id == poolLineId);
            }

            Details.RemoveAll(o => o.Id == poolLineId);

            //如何获得pool的id？
            //LoadDocumentEnableProperty();
            using (var dpLineService = SvcClientManager.GetSvcClient<ForeignDeliveryPoolLineServiceClient>(SvcType.ForeignDeliveryPoolLineSvc))
            {
                LoadDocumentEnableProperty(dpLineService.GetById(poolLineId).ForeignDeliveryPoolId);
            }
        }

        public void RemoveAttachment(int attachmentId)
        {
            var att = Attachments.Single(o => o.Id == attachmentId);
            if (att != null)
            {
                Attachments.Remove(att);
            }

            var addatt = NewAddAttachments.SingleOrDefault(o => o.Id == attachmentId);
            if (addatt != null)
            {
                //如果是新增的附件
                NewAddAttachments.Remove(addatt);
            }
            else
            {
                //增加到删除列表里
                DeletedAttachments.Add(att);
            }
        }

        public void RemoveStorageDateById(int id)
        {
            if (id > 0)
            {
                var line = StorageDates.Single(o => o.Id == id);
                DeletedStorageDateLines.Add(line);
                ModifiedStorageDateLines.RemoveAll(o => o.Id == id);
            }

            if (id < 0)
            {
                NewAddedStorageDateLines.RemoveAll(o => o.Id == id);
            }

            StorageDates.RemoveAll(o => o.Id == id);
        }

        public void ChangeAttFileName()
        {
            using (var attService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
            {
                Attachments = attService.ChangeAttachmentName(_attachments);
                NewAddAttachments = attService.ChangeAttachmentName(NewAddAttachments);
            }
        }

        #endregion

        #region Event

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedLoadingPlaceId":
                    using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                    {
                        if (SelectedLoadingPlaceId != 0)
                        {
                            var tmpPorts = portService.GetPortsByCountry(SelectedLoadingPlaceId).OrderBy(o => o.Name).ToList();
                            tmpPorts.Insert(0, new Port());
                            LoadingPorts = tmpPorts;
                            SelectedLoadingPortId = -1;
                            SelectedLoadingPortId = 0;
                        }
                        else
                        {
                            var tmpPorts = portService.GetAll().OrderBy(o => o.Name).ToList();
                            tmpPorts.Insert(0, new Port());
                            LoadingPorts = tmpPorts;
                            SelectedLoadingPortId = -1;
                            SelectedLoadingPortId = 0;
                        }
                    }
                    break;

                case "SelectedDischargePlaceId":
                    using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                    {
                        if (SelectedDischargePlaceId != 0)
                        {
                            var tmpPorts = portService.GetPortsByCountry(SelectedDischargePlaceId).OrderBy(o => o.Name).ToList();
                            tmpPorts.Insert(0, new Port());
                            DischargePorts = tmpPorts;
                            SelectedDischargePortId = -1;
                            SelectedDischargePortId = 0;
                        }
                        else
                        {
                            var tmpPorts = portService.GetAll().OrderBy(o => o.Name).ToList();
                            tmpPorts.Insert(0, new Port());
                            DischargePorts = tmpPorts;
                            SelectedDischargePortId = -1;
                            SelectedDischargePortId = 0;
                        }
                    }
                    break;
            }
        }

        #endregion

        #region 控件编辑属性设置
        private bool _isCommodityEnable;
        private bool _isLineDeleteBtnEnable;
        private bool _isLineNewBtnEnable;

        public bool IsCommodityEnable
        {
            get { return _isCommodityEnable; }
            set
            {
                if (_isCommodityEnable != value)
                {
                    _isCommodityEnable = value;
                    Notify("IsCommodityEnable");
                }
            }
        }

        public bool IsLineNewBtnEnable
        {
            get { return _isLineNewBtnEnable; }
            set
            {
                if (_isLineNewBtnEnable != value)
                {
                    _isLineNewBtnEnable = value;
                    Notify("IsLineNewBtnEnable");
                }
            }
        }

        public bool IsLineDeleteBtnEnable
        {
            get { return _isLineDeleteBtnEnable; }
            set
            {
                if (_isLineDeleteBtnEnable != value)
                {
                    _isLineDeleteBtnEnable = value;
                    Notify("IsLineDeleteBtnEnable");
                }
            }
        }

        private void LoadDocumentEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsCommodityEnable = true;
                IsLineDeleteBtnEnable = true;
                IsLineNewBtnEnable = true;
            }
            else
            {
                using (var fdpService = SvcClientManager.GetSvcClient<ForeignDeliveryPoolServiceClient>(SvcType.ForeignDeliveryPoolSvc))
                {
                    ForeignDeliveryPoolEnableProperty fdpep = fdpService.SetElementsEnableProperty(id);
                    IsCommodityEnable = fdpep.IsCommodityEnable;
                    IsLineDeleteBtnEnable = fdpep.IsLineDeleteBtnEnable;
                    IsLineNewBtnEnable = fdpep.IsLineNewBtnEnable;
                }
            }
        }

        #endregion
    }
}
