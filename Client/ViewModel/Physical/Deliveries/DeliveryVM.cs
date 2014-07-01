using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Client.AttachmentServiceReference;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CountryServiceReference;
using Client.DeliveryLineServiceReference;
using Client.DeliveryServiceReference;
using Client.DocumentServiceReference;
using Client.PortServiceReference;
using Client.QuotaServiceReference;
using Client.View.Physical.Deliveries;
using Client.View.PopUpDialog;
using Client.WarehouseServiceReference;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.Deliveries
{
    public class DeliveryVM : BaseVM
    {
        #region Member

        private List<DeliveryLine> _addedDeliveryLines = new List<DeliveryLine>();
        private DateTime? _arrivedDate; //到达日期
        private Brand _brand;
        private string _comment;
        private Commodity _commodity;
        private CommodityType _commodityType;
        private List<DeliveryLine> _deletedDeliveryLines = new List<DeliveryLine>();
        private Delivery _deliveryHeader;
        private List<DeliveryLine> _deliveryLines = new List<DeliveryLine>();
        private string _deliveryNo;
        private DeliveryType _deliveryType;
        private string _deliveryTypeName;
        private int? _dischargePlaceId; //卸货地
        private string _dischargePlaceName;
        private List<Country> _dischargePlaces; //卸货地
        private int? _dischargePortId; //卸货港
        private string _dischargePortName;
        private List<Port> _dischargePorts; //卸货港
        private int _financeStatus; //财务状态
        private bool _isCopy; //是否是复印件
        private bool _isCopyFirst;
        private bool _isCopySecond;
        private bool _isCustomed; //是否报关
        private Dictionary<string, bool> _isCustomeds;
        private DateTime _issueDate = DateTime.Now.Date;
        private int? _loadingPlaceId; //装运地
        private string _loadingPlaceName;
        private List<Country> _loadingPlaces; //装运地
        private int? _loadingPortId; //装运港
        private string _loadingPortName;
        private List<Port> _loadingPorts; //装运港
        private int? _notifyPartyId; //通知人
        private string _notifyPartyName;
        private DateTime? _onBoardDate; //装运日期
        private string _packingStandard; //打包规格
        private int? _quotaId;
        private string _quotaNo;
        private int? _shipperId; //发货人
        private string _shipperName;
        private int? _shippingPartyId; //承运商
        private string _shippingPartyName;
        private Specification _specification;
        private Dictionary<string, int> _statusTypes;
        private Delivery _tDelivery; //发货单或转口单据对应的提单或仓单
        private string _tDeliveryNo; //发货单或转口单据对应的提单或仓单
        private List<DeliveryLine> _updatedDeliveryLines = new List<DeliveryLine>();
        private string _vesselNo; //船号
        private int? _warehouseId; //仓库
        private string _warehouseName;
        private int? _warehouseProviderId; //仓储商
        private string _warehouseProviderName;
        private string _circulNo;
        private List<Attachment> _addAttachments;
        private List<Attachment> _attachments;
        private List<Attachment> _deleteAttachments;
        private bool? _isVerified;
        private int _contentId;
        private string _warehouseOutNo;
        private int? _actualDeliveryBPId;
        private string _actualDeliveryBPName;
        private int _fdpId;
        private bool _allEntrepot = true;
        private string _contractInfo;
        private decimal? _quotaQty;
        private int _tdId;
        private bool _isConvertWR = false;

        private List<Delivery> _DeliveryList = new List<Delivery>();
        private List<Delivery> _AddDeliveryList = new List<Delivery>();
        private List<Delivery> _UpdateDeliveryList = new List<Delivery>();
        private List<Delivery> _DeleteDeliveryList = new List<Delivery>();
        private string _Title;
        private string _lbContent;
        #endregion

        #region Property

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    Notify("Title");
                }
            }
        }

        public string lbContent
        {
            get { return _lbContent; }
            set
            {
                if (_lbContent != value)
                {
                    _lbContent = value;
                    Notify("lbContent");
                }
            }
        }

        public List<Delivery> DeleteDeliveryList
        {
            get { return _DeleteDeliveryList; }
            set
            {
                if (_DeleteDeliveryList != value)
                {
                    _DeleteDeliveryList = value;
                    Notify("DeleteDeliveryList");
                }
            }
        }

        public List<Delivery> UpdateDeliveryList
        {
            get { return _UpdateDeliveryList; }
            set
            {
                if (_UpdateDeliveryList != value)
                {
                    _UpdateDeliveryList = value;
                    Notify("UpdateDeliveryList");
                }
            }
        }

        public List<Delivery> AddDeliveryList
        {
            get { return _AddDeliveryList; }
            set
            {
                if (_AddDeliveryList != value)
                {
                    _AddDeliveryList = value;
                    Notify("AddDeliveryList");
                }
            }
        }

        public List<Delivery> DeliveryList
        {
            get { return _DeliveryList; }
            set
            {
                if (_DeliveryList != value)
                {
                    _DeliveryList = value;
                    Notify("DeliveryList");
                }
            }
        }

        public bool IsConvertWR
        {
            get { return _isConvertWR; }
            set
            {
                if (_isConvertWR != value)
                {
                    _isConvertWR = value;
                    Notify("IsConvertWR");
                }
            }
        }

        public int TdId { get; set; }

        public decimal? QuotaQty
        {
            get { return _quotaQty; }
            set
            {
                if (_quotaQty != value)
                {
                    _quotaQty = value;
                    Notify("QuotaQty");
                }
            }
        }

        public int? ActualDeliveryBPId
        {
            get { return _actualDeliveryBPId; }
            set
            {
                if (_actualDeliveryBPId != value)
                {
                    _actualDeliveryBPId = value;
                    Notify("ActualDeliveryBPId");
                }
            }
        }
        public string ActualDeliveryBPName
        {
            get { return _actualDeliveryBPName; }
            set
            {
                if (_actualDeliveryBPName != value)
                {
                    _actualDeliveryBPName = value;
                    Notify("ActualDeliveryBPName");
                }
            }
        }
        public string WarehouseOutNo
        {
            get { return _warehouseOutNo; }
            set
            {
                if (_warehouseOutNo != value)
                {
                    _warehouseOutNo = value;
                    Notify("WarehouseOutNo");
                }
            }
        }

        public int? CommercialInvoiceId { get; set; }
        public int? LCId { get; set; }
        public int? PaymentRequestId { get; set; }

        public bool? IsVerified
        {
            get { return _isVerified; }
            set
            {
                if (_isVerified != value)
                {
                    _isVerified = value;
                    Notify("IsVerified");
                }
            }
        }

        /// <summary>
        /// 新增附件列表
        /// </summary>
        public List<Attachment> AddAttachments
        {
            get { return _addAttachments; }
            set
            {
                if (_addAttachments != value)
                {
                    _addAttachments = value;
                    Notify("AddAttachments");
                }
            }
        }

        public List<Attachment> Attachments
        {
            get { return _attachments; }
            set
            {
                if (_attachments != value)
                {
                    _attachments = value;
                    Notify("Attachments");
                }
            }
        }

        /// <summary>
        /// 删除附件列表
        /// </summary>
        public List<Attachment> DeleteAttachments
        {
            get { return _deleteAttachments; }
            set
            {
                if (_deleteAttachments != value)
                {
                    _deleteAttachments = value;
                    Notify("DeleteAttachments");
                }
            }
        }

        /// <summary>
        /// 流转标识号
        /// </summary>
        public string CirculNo
        {
            get { return _circulNo; }
            set
            {
                if (_circulNo != value)
                {
                    _circulNo = value;
                    Notify("CirculNo");
                }
            }
        }

        /// <summary>
        /// 发货单或转口单据对应的提单或仓单
        /// </summary>
        public string TDeliveryNo
        {
            get { return _tDeliveryNo; }
            set
            {
                if (_tDeliveryNo != value)
                {
                    _tDeliveryNo = value;
                    Notify("TDeliveryNo");
                }
            }
        }

        /// <summary>
        /// 发货单或转口单据对应的提单或仓单
        /// </summary>
        public Delivery TDelivery
        {
            get { return _tDelivery; }
            set
            {
                if (_tDelivery != value)
                {
                    _tDelivery = value;
                    Notify("TDelivery");
                }
            }
        }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string DeliveryTypeName
        {
            get { return _deliveryTypeName; }
            set
            {
                if (_deliveryTypeName != value)
                {
                    _deliveryTypeName = value;
                    Notify("DeliveryTypeName");
                }
            }
        }

        /// <summary>
        /// 船号
        /// </summary>
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

        /// <summary>
        /// 打包规格
        /// </summary>
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

        /// <summary>
        /// 是否报关
        /// </summary>
        public bool IsCustomed
        {
            get { return _isCustomed; }
            set
            {
                if (_isCustomed != value)
                {
                    _isCustomed = value;
                    Notify("IsCustomed");
                }
            }
        }

        /// <summary>
        /// 是否报关
        /// </summary>
        public Dictionary<string, bool> IsCustomeds
        {
            get { return _isCustomeds; }
            set
            {
                if (_isCustomeds != value)
                {
                    _isCustomeds = value;
                    Notify("IsCustomeds");
                }
            }
        }

        /// <summary>
        /// 转运日期
        /// </summary>
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

        /// <summary>
        /// 到达日期
        /// </summary>
        public DateTime? ArrivedDate
        {
            get { return _arrivedDate; }
            set
            {
                if (_arrivedDate != value)
                {
                    _arrivedDate = value;
                    Notify("ArrivedDate");
                }
            }
        }

        /// <summary>
        /// 提单号
        /// </summary>
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

        /// <summary>
        /// 备注
        /// </summary>
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

        /// <summary>
        /// 开具日期
        /// </summary>
        public DateTime IssueDate
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

        /// <summary>
        /// 仓库Id
        /// </summary>
        public int? WarehouseId
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

        /// <summary>
        /// 仓库名称
        /// </summary>
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

        /// <summary>
        /// 批次Id
        /// </summary>
        public int? QuotaId
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

        /// <summary>
        /// 批次号
        /// </summary>
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

        /// <summary>
        /// 仓储商Id
        /// </summary>
        public int? WarehouseProviderId
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

        /// <summary>
        /// 仓储商名称
        /// </summary>
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

        /// <summary>
        /// 发货人Id
        /// </summary>
        public int? ShipperId
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

        /// <summary>
        /// 发货人名称
        /// </summary>
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

        /// <summary>
        /// 承运商Id
        /// </summary>
        public int? ShippingPartyId
        {
            get { return _shippingPartyId; }
            set
            {
                if (_shippingPartyId != value)
                {
                    _shippingPartyId = value;
                    Notify("ShippingPartyId");
                }
            }
        }

        /// <summary>
        /// 承运商名称
        /// </summary>
        public string ShippingPartyName
        {
            get { return _shippingPartyName; }
            set
            {
                if (_shippingPartyName != value)
                {
                    _shippingPartyName = value;
                    Notify("ShippingPartyName");
                }
            }
        }

        /// <summary>
        /// 通知人Id
        /// </summary>
        public int? NotifyPartyId
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

        /// <summary>
        /// 通知人名称
        /// </summary>
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

        /// <summary>
        /// 状态
        /// </summary>
        public Dictionary<string, int> StatusTypes
        {
            get { return _statusTypes; }
            set
            {
                if (_statusTypes != value)
                {
                    _statusTypes = value;
                    Notify("StatusTypes");
                }
            }
        }

        /// <summary>
        /// 财务状态
        /// </summary>
        public int FinanceStatus
        {
            get { return _financeStatus; }
            set
            {
                if (_financeStatus != value)
                {
                    _financeStatus = value;
                    Notify("FinanceStatus");
                }
            }
        }

        /// <summary>
        /// 金属
        /// </summary>
        public Commodity Commodity
        {
            get { return _commodity; }
            set
            {
                if (_commodity != value)
                {
                    _commodity = value;
                    Notify("Commodity");
                }
            }
        }

        /// <summary>
        /// 金属类型
        /// </summary>
        public CommodityType CommodityType
        {
            get { return _commodityType; }
            set
            {
                if (_commodityType != value)
                {
                    _commodityType = value;
                    Notify("CommodityType");
                }
            }
        }

        /// <summary>
        /// 品牌
        /// </summary>
        public Brand Brand
        {
            get { return _brand; }
            set
            {
                if (_brand != value)
                {
                    _brand = value;
                    Notify("Brand");
                }
            }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public Specification Specification
        {
            get { return _specification; }
            set
            {
                if (_specification != value)
                {
                    _specification = value;
                    Notify("Specification");
                }
            }
        }

        /// <summary>
        /// 提单行
        /// </summary>
        public List<DeliveryLine> DeliveryLines
        {
            get { return _deliveryLines; }
            set
            {
                if (_deliveryLines != value)
                {
                    _deliveryLines = value;
                    Notify("DeliveryLines");
                }
            }
        }

        /// <summary>
        /// 提单类型
        /// </summary>
        public Delivery DeliveryHeader
        {
            get { return _deliveryHeader; }
            set
            {
                if (_deliveryHeader != value)
                {
                    _deliveryHeader = value;
                    Notify("DeliveryHeader");
                }
            }
        }

        /// <summary>
        /// 新增的提单行列表
        /// </summary>
        public List<DeliveryLine> AddedDeliveryLines
        {
            get { return _addedDeliveryLines; }
            set
            {
                if (_addedDeliveryLines != value)
                {
                    _addedDeliveryLines = value;
                    Notify("AddedDeliveryLines");
                }
            }
        }

        /// <summary>
        /// 编辑的提单行列表
        /// </summary>
        public List<DeliveryLine> UpdatedDeliveryLines
        {
            get { return _updatedDeliveryLines; }
            set
            {
                if (_updatedDeliveryLines != value)
                {
                    _updatedDeliveryLines = value;
                    Notify("UpdatedDeliveryLines");
                }
            }
        }

        /// <summary>
        /// 删除的提单行列表
        /// </summary>
        public List<DeliveryLine> DeletedDeliveryLines
        {
            get { return _deletedDeliveryLines; }
            set
            {
                if (_deletedDeliveryLines != value)
                {
                    _deletedDeliveryLines = value;
                    Notify("DeletedDeliveryLines");
                }
            }
        }

        /// <summary>
        /// 提单类型
        /// </summary>
        public DeliveryType DeliveryType
        {
            get { return _deliveryType; }
            set
            {
                if (_deliveryType != value)
                {
                    _deliveryType = value;
                    Notify("DeliveryType");
                }
            }
        }

        /// <summary>
        /// 装运港Id
        /// </summary>
        public int? LoadingPortId
        {
            get { return _loadingPortId; }
            set
            {
                if (_loadingPortId != value)
                {
                    _loadingPortId = value;
                    Notify("LoadingPortId");
                }
            }
        }

        /// <summary>
        /// 装运港名称
        /// </summary>
        public string LoadingPortName
        {
            get { return _loadingPortName; }
            set
            {
                if (_loadingPortName != value)
                {
                    _loadingPortName = value;
                    Notify("LoadingPortName");
                }
            }
        }

        /// <summary>
        /// 装运地Id
        /// </summary>
        public int? LoadingPlaceId
        {
            get { return _loadingPlaceId; }
            set
            {
                if (_loadingPlaceId != value)
                {
                    _loadingPlaceId = value;
                    Notify("LoadingPlaceId");
                }
            }
        }

        /// <summary>
        /// 装运地名称
        /// </summary>
        public string LoadingPlaceName
        {
            get { return _loadingPlaceName; }
            set
            {
                if (_loadingPlaceName != value)
                {
                    _loadingPlaceName = value;
                    Notify("LoadingPlaceName");
                }
            }
        }

        /// <summary>
        /// 卸货港Id
        /// </summary>
        public int? DischargePortId
        {
            get { return _dischargePortId; }
            set
            {
                if (_dischargePortId != value)
                {
                    _dischargePortId = value;
                    Notify("DischargePortId");
                }
            }
        }

        /// <summary>
        /// 卸货港名称
        /// </summary>
        public string DischargePortName
        {
            get { return _dischargePortName; }
            set
            {
                if (_dischargePortName != value)
                {
                    _dischargePortName = value;
                    Notify("DischargePortName");
                }
            }
        }

        /// <summary>
        /// 卸货地Id
        /// </summary>
        public int? DischargePlaceId
        {
            get { return _dischargePlaceId; }
            set
            {
                if (_dischargePlaceId != value)
                {
                    _dischargePlaceId = value;
                    Notify("DischargePlaceId");
                }
            }
        }

        /// <summary>
        /// 卸货地名称
        /// </summary>
        public string DischargePlaceName
        {
            get { return _dischargePlaceName; }
            set
            {
                if (_dischargePlaceName != value)
                {
                    _dischargePlaceName = value;
                    Notify("DischargePlaceName");
                }
            }
        }

        /// <summary>
        /// 装运地
        /// </summary>
        public List<Country> LoadingPlaces
        {
            get { return _loadingPlaces; }
            set
            {
                if (_loadingPlaces != value)
                {
                    _loadingPlaces = value;
                    Notify("LoadingPlaces");
                }
            }
        }

        /// <summary>
        /// 卸货地
        /// </summary>
        public List<Country> DischargePlaces
        {
            get { return _dischargePlaces; }
            set
            {
                if (_dischargePlaces != value)
                {
                    _dischargePlaces = value;
                    Notify("DischargePlaces");
                }
            }
        }

        /// <summary>
        /// 装运港
        /// </summary>
        public List<Port> LoadingPorts
        {
            get { return _loadingPorts; }
            set
            {
                if (_loadingPorts != value)
                {
                    _loadingPorts = value;
                    Notify("LoadingPorts");
                }
            }
        }

        /// <summary>
        /// 卸货港
        /// </summary>
        public List<Port> DischargePorts
        {
            get { return _dischargePorts; }
            set
            {
                if (_dischargePorts != value)
                {
                    _dischargePorts = value;
                    Notify("DischargePorts");
                }
            }
        }

        /// <summary>
        /// 是否是复印件
        /// </summary>
        public bool IsCopy
        {
            get { return _isCopy; }
            set
            {
                if (_isCopy != value)
                {
                    _isCopy = value;
                    Notify("IsCopy");
                }
            }
        }

        /// <summary>
        /// 是否是复印件
        /// </summary>
        public bool IsCopyFirst
        {
            get { return _isCopyFirst; }
            set
            {
                if (_isCopyFirst != value)
                {
                    _isCopyFirst = value;
                    Notify("IsCopyFirst");
                }
            }
        }

        /// <summary>
        /// 是否是复印件
        /// </summary>
        public bool IsCopySecond
        {
            get { return _isCopySecond; }
            set
            {
                if (_isCopySecond != value)
                {
                    _isCopySecond = value;
                    Notify("IsCopySecond");
                }
            }
        }

        public bool AllEntrepot
        {
            get { return _allEntrepot; }
            set
            {
                if (_allEntrepot != value)
                {
                    _allEntrepot = value;
                    Notify("AllEntrepot");
                }
            }
        }

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


        #endregion

        #region Constructor

        public DeliveryVM()
        {
            LoadComboxValue();
        }

        public DeliveryVM(DeliveryType deliveryType, int tdId = 0)
        {
            ObjectId = 0;
            TdId = tdId;
            //IsConvertWR = isConvertWR;
            DeliveryType = deliveryType;
            DeliveryTypeName = EnumHelper.GetDescriptionByCulture(deliveryType);
            LoadComboxValue();
            if (deliveryType == DeliveryType.ExternalTDBOL || deliveryType == DBEntity.EnumEntity.DeliveryType.ExternalMDBOL)
            {
                Title = "进出口/转口提单";
                lbContent = "提单号";
            }
            else if (deliveryType == DeliveryType.ExternalTDWW || deliveryType == DBEntity.EnumEntity.DeliveryType.ExternalMDWW)
            {
                Title = "进出口/转口仓单";
                lbContent = "仓单号";
            }
            if (deliveryType == DeliveryType.ExternalTDBOL || deliveryType == DeliveryType.ExternalMDBOL)
            {
                LoadCountry();
                LoadPort();
            }
            if (deliveryType == DeliveryType.ExternalTDBOL || deliveryType == DeliveryType.ExternalTDWW ||
                deliveryType == DeliveryType.ExternalMDBOL || deliveryType == DeliveryType.ExternalMDWW)
            {
                LoadIsCustomed();
            }
            if (deliveryType == DeliveryType.ExternalTDBOL || deliveryType == DeliveryType.ExternalTDWW)
            {
                IsCopyFirst = false;
                IsCopySecond = true;
            }
            LoadDocumentEnableProperty(ObjectId);
            LoadPackingStandard();
            if (tdId != 0)
            {
                LoadConvertWR(tdId);
            }
        }

        //PackingStandard = "IN BUNDLES"

        public Delivery GetDeliveryByIdWithFetch(int id)
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                const string str = "it.Id = @p1 ";
                var parameters = new List<object> { id };
                Delivery delivery = deliveryService.Select(str, parameters, new List<string>
                                                                                        {
                                                                                            "Quota",
                                                                                            "Quota.Contract.BusinessPartner",
                                                                                            "Quota.Contract.InternalCustomer",
                                                                                            "Quota.QuotaBrandRels",
                                                                                            "Warehouse",
                                                                                            "WarehouseProvider",
                                                                                            "Shipper",
                                                                                            "BusinessPartner",
                                                                                            "ShippingParty",
                                                                                            "NotifyParty",
                                                                                            "Quota.Commodity",
                                                                                            "DeliveryLines.Country",
                                                                                            "LoadingPort",
                                                                                            "LoadingPlace",
                                                                                            "DischargePort",
                                                                                            "DischargePlace",
                                                                                            "DeliveryLines",
                                                                                            "DeliveryLines.Brand",
                                                                                            "DeliveryLines.CommodityType",
                                                                                            "DeliveryLines.Specification",
                                                                                            "DeliveryLines.WarehouseOutDeliveryPersons"
                                                                                        }).FirstOrDefault();
                if (delivery != null)
                {

                    FilterDeleted(delivery.DeliveryLines);
                    if (DeliveryList == null)
                    {
                        DeliveryList = new List<Delivery>();
                    }
                    if (delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL)
                    {
                        Title = "进出口/转口提单";
                        lbContent = "提单号";
                    }
                    else if (delivery.DeliveryType == (int)DeliveryType.ExternalTDWW || delivery.DeliveryType == (int)DeliveryType.ExternalMDWW)
                    {
                        Title = "进出口/转口仓单";
                        lbContent = "仓单号";
                    }
                    DeliveryList.Add(delivery);
                    GetSumNum();
                    if (DeliveryLines == null)
                    {
                        DeliveryLines = new List<DeliveryLine>();
                    }
                    DeliveryLines.AddRange(delivery.DeliveryLines);
                    return delivery;
                }
                return null;
            }
        }

        /// <summary>
        /// 编辑提单时，初始化构造函数
        /// </summary>
        /// <param name="deliveryId"></param>
        public DeliveryVM(int deliveryId)
        {
            Delivery delivery = GetDeliveryByIdWithFetch(deliveryId);
            ObjectId = delivery.Id;
            LoadComboxValue();
            if (delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL ||
                delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL)
            {
                LoadCountry();
                LoadPort();
            }
            if (delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL ||
                delivery.DeliveryType == (int)DeliveryType.ExternalTDWW ||
                delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL ||
                delivery.DeliveryType == (int)DeliveryType.ExternalMDWW)
            {
                LoadIsCustomed();
            }

            SetData(delivery);

            if (delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL ||
                delivery.DeliveryType == (int)DeliveryType.ExternalTDWW)
            {
                IsCopyFirst = delivery.IsCopy;
                IsCopySecond = !delivery.IsCopy;
            }

            LoadAttachments();
            LoadDocumentEnableProperty(ObjectId);

            var lines = SetIsVerified();
            DeliveryLines.Clear();
            foreach (var item in lines)
            {
                DeliveryLines.Add(item);
            }
            AddSumLine();
            if (delivery.WarrantId.HasValue)
            {
                IsConvertWR = true;
            }
        }

        private void LoadPackingStandard()
        {
            if (DeliveryType == DeliveryType.ExternalTDBOL || DeliveryType == DeliveryType.ExternalTDWW)
            {
                PackingStandard = "IN BUNDLES";
            }
            else
            {
                PackingStandard = string.Empty;
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// 显示批次弹出框
        /// </summary>
        public void ShowQuotaDialog()
        {
            string queryStr;
            var idList = new List<int>();
            if (DeliveryType == DeliveryType.InternalTDBOL || DeliveryType == DeliveryType.InternalTDWW)
            {
                queryStr =
                    string.Format(
                        "it.IsDraft = False and it.Contract.ContractType={0} and (it.Contract.TradeType={1} or it.Contract.TradeType={2}) and it.DeliveryStatus=False and (it.ApproveStatus={3} or it.ApproveStatus={4}) and it.RelQuotaId is null ",
                        (int)ContractType.Purchase, (int)TradeType.ShortDomesticTrade,
                        (int)TradeType.LongDomesticTrade, (int)ApproveStatus.NoApproveNeeded,
                        (int)ApproveStatus.Approved);
            }
            else if (DeliveryType == DeliveryType.ExternalTDBOL || DeliveryType == DeliveryType.ExternalTDWW)
            {
                queryStr =
                    string.Format(
                        "it.IsDraft = False and it.Contract.ContractType={0} and (it.Contract.TradeType={1} or it.Contract.TradeType={2}) and it.DeliveryStatus=False  and (it.ApproveStatus={3} or it.ApproveStatus={4}) ",
                        (int)ContractType.Purchase, (int)TradeType.ShortForeignTrade, (int)TradeType.LongForeignTrade,
                        (int)ApproveStatus.NoApproveNeeded, (int)ApproveStatus.Approved);
            }
            else if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.InternalMDWW)
            {
                queryStr =
                    string.Format(
                        "it.IsDraft = False and it.Contract.ContractType={0} and (it.Contract.TradeType={1} or it.Contract.TradeType={2}) and it.DeliveryStatus=False  and (it.ApproveStatus={3} or it.ApproveStatus={4}) and it.RelQuotaId is null ",
                        (int)ContractType.Sales, (int)TradeType.ShortDomesticTrade, (int)TradeType.LongDomesticTrade,
                        (int)ApproveStatus.NoApproveNeeded, (int)ApproveStatus.Approved);
            }
            else
            {
                queryStr =
                    string.Format(
                        "it.IsDraft = False and it.Contract.ContractType={0} and (it.Contract.TradeType={1} or it.Contract.TradeType={2}) and it.DeliveryStatus=False  and (it.ApproveStatus={3} or it.ApproveStatus={4}) ",
                        (int)ContractType.Sales, (int)TradeType.ShortForeignTrade, (int)TradeType.LongForeignTrade,
                        (int)ApproveStatus.NoApproveNeeded, (int)ApproveStatus.Approved);
            }

            using (var businessPartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                List<BusinessPartner> list = businessPartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (list.Count > 0)
                {
                    idList = list.Select(c => c.Id).ToList();
                }
            }
            if (idList.Count > 0)
            {
                queryStr += string.Format(" and (");
                for (int j = 0; j < idList.Count; j++)
                {
                    if (j == 0)
                    {
                        queryStr += string.Format(" it.Contract.InternalCustomerId = {0} ", idList[j]);
                    }
                    else
                    {
                        queryStr += string.Format(" or it.Contract.InternalCustomerId = {0}", idList[j]);
                    }
                }
                queryStr += string.Format(" )");
            }

            PopDialog dialog = PopDialogCreater.CreateDialog("Quota", queryStr, null, null, null, 0, 0, false,
                                                             new List<string>
                                                                 {
                                                                     "CommodityType",
                                                                     "Specification"
                                                                 });
            dialog.ShowDialog();
            var quota = dialog.SelectedItem as Quota;
            if (quota != null)
            {
                QuotaId = quota.Id;
                QuotaNo = quota.QuotaNo;
                Commodity = quota.Commodity;
                CommodityType = quota.CommodityType;
                Brand = quota.Brand;
                Specification = quota.Specification;
                ActualDeliveryBPId = quota.Contract.BPId;
                BusinessPartner actualDeliveryBP = GetBPById(quota.Contract.BPId.Value);
                ActualDeliveryBPName = actualDeliveryBP.ShortName;
                if (quota.Warehouse != null && (quota.QuotaBrandRels == null || quota.QuotaBrandRels.Count == 0))
                {
                    WarehouseName = quota.Warehouse.Name;
                    WarehouseId = quota.Warehouse.Id;
                }
                //货权人，显示合同的签署公司的名称
                //发货人，显示批次的业务伙伴
                var shipperCustomerId = (int)quota.Contract.BPId;
                BusinessPartner customer = GetBPById(shipperCustomerId);

                ShipperName = customer.ShortName;
                ShipperId = customer.Id;

                FilterDeleted(quota.Quota1);

                TDeliveryNo = string.Empty;
                _tdId = 0;

                decimal deliveryQty = GetDeliveryQty(quota.Id);

                QuotaQty = quota.Quantity - deliveryQty;

                ContractInfo = quota.ContractInfo;
            }
        }

        private decimal GetDeliveryQty(int quotaId)
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                decimal qty = 0;
                List<Delivery> deliveries = deliveryService.Select("it.QuotaId = " + quotaId, null,
                    new List<string> { "DeliveryLines", "DeliveryLines.Brand", "DeliveryLines.CommodityType" });
                foreach (var delivery in deliveries)
                {
                    FilterDeleted(delivery.DeliveryLines);
                    List<DeliveryLine> lines = delivery.DeliveryLines.ToList();
                    foreach (var line in lines)
                    {
                        if (delivery.DeliveryType == (int)DeliveryType.ExternalTDBOL
                            || delivery.DeliveryType == (int)DeliveryType.ExternalTDWW
                            || delivery.DeliveryType == (int)DeliveryType.InternalTDBOL
                            || delivery.DeliveryType == (int)DeliveryType.InternalTDWW)
                        {
                            qty += line.NetWeight ?? 0;
                        }
                    }
                }
                return qty;
            }
        }

        /// <summary>
        /// 显示仓储商弹出框
        /// </summary>
        public void ShowWarehouseProviderDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                WarehouseProviderId = bp.Id;
                WarehouseProviderName = bp.ShortName;
            }
        }

        /// <summary>
        /// 显示仓库弹出框
        /// </summary>
        public void ShowWarehouseDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("Warehouse");
            dialog.ShowDialog();
            var warehouse = dialog.SelectedItem as Warehouse;
            if (warehouse != null)
            {
                WarehouseId = warehouse.Id;
                WarehouseName = warehouse.Name;
            }
        }

        /// <summary>
        /// 显示发货人弹出框
        /// </summary>
        public void ShowShipperDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var shipper = dialog.SelectedItem as BusinessPartner;
            if (shipper != null)
            {
                ShipperId = shipper.Id;
                ShipperName = shipper.ShortName;
            }
        }

        /// <summary>
        /// 显示承运商弹出框
        /// </summary>
        public void ShowShippingPartyDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var shippingParty = dialog.SelectedItem as BusinessPartner;
            if (shippingParty != null)
            {
                ShippingPartyId = shippingParty.Id;
                ShippingPartyName = shippingParty.ShortName;
            }
        }

        /// <summary>
        /// 显示通知人弹出框
        /// </summary>
        public void ShowNotifyPartyDialog()
        {
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner");
            dialog.ShowDialog();
            var notifyParty = dialog.SelectedItem as BusinessPartner;
            if (notifyParty != null)
            {
                NotifyPartyId = notifyParty.Id;
                NotifyPartyName = notifyParty.ShortName;
            }
        }


        /// <summary>
        /// 显示原始提单/仓单弹出框
        /// </summary>
        public void ShowTDDialog()
        {
            Quota quota = GetQuotaById(QuotaId ?? 0);
            if (quota != null)
            {
                string queryStr = "";
                if (DeliveryType == DeliveryType.InternalMDBOL)
                {
                    queryStr =
                        string.Format(
                            "(it.DeliveryType={0} or it.DeliveryType={1}) and it.Quota.CommodityId={2} and it.Quota.Contract.InternalCustomerId = {3} and it.DeliveryStatus != true ",
                            (int)DeliveryType.InternalTDBOL, (int)DeliveryType.InternalTDWW, Commodity.Id, quota.Contract.InternalCustomerId);
                }
                else if (DeliveryType == DeliveryType.ExternalMDBOL)
                {
                    queryStr =
                        string.Format(
                            "it.DeliveryType={0} and it.IsCopy=False and it.IsCustomed=False and it.Quota.CommodityId={1} and it.Quota.Contract.InternalCustomerId = {2} and it.DeliveryStatus != true and (it.WarrantId is null or (it.WarrantId is not null and it.DeliveryType = " + (int)DeliveryType.ExternalTDWW + ")) ",
                            (int)DeliveryType.ExternalTDBOL, Commodity.Id, quota.Contract.InternalCustomerId);
                }
                else if (DeliveryType == DeliveryType.ExternalMDWW)
                {
                    queryStr =
                        string.Format(
                            "it.DeliveryType={0} and it.IsCopy=False and it.IsCustomed=False and it.Quota.CommodityId={1} and it.Quota.Contract.InternalCustomerId = {2} and it.DeliveryStatus != true ",
                            (int)DeliveryType.ExternalTDWW, Commodity.Id, quota.Contract.InternalCustomerId);
                }

                //中铜暂时不按照牌子过滤
                //if (Brand != null)
                //{
                //    queryStr += string.Format(" and (it.BrandId Like '%_{0}_%' or it.BrandId is null) ", Brand.Id.ToString());
                //}

                #region 去掉仓库的过滤
                //if (WarehouseId.HasValue && WarehouseId.Value != 0)
                //{
                //    queryStr += string.Format(" and it.WarehouseId = {0} ", WarehouseId.Value);
                //}
                #endregion

                if (DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDWW ||
                  DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDWW)
                {
                    PopDialog dialog = PopDialogCreater.CreateDialog("TDelivery", queryStr, null, null, null,
                                                                 _tdId, _contentId, false, null, new List<SortCol> { new SortCol { ColName = "IssueDate", ByDescending = true } });

                    dialog.ShowDialog();
                    var delivery = dialog.SelectedItem as Delivery;
                    if(delivery != null)
                    {
                        _tdId = delivery.Id;
                        if (DeliveryType != DBEntity.EnumEntity.DeliveryType.InternalMDBOL)
                        {
                            DeliveryNo = delivery.DeliveryNo;
                        }
                        IsVerified = delivery.IsVerified;
                        if (ObjectId != 0)
                        {
                            DeletedDeliveryLines = GetDeliveryLines(ObjectId);
                        }
                        AddedDeliveryLines = new List<DeliveryLine>();
                        TDeliveryNo = delivery.DeliveryNo;
                        TDelivery = delivery;

                        PackingStandard = delivery.PackingStandard;
                        VesselNo = delivery.VesselNo;
                        LoadingPortId = delivery.LoadingPortId;
                        DischargePortId = delivery.DischargePortId;
                        LoadingPlaceId = delivery.LoadingPlaceId;
                        DischargePlaceId = delivery.DischargePlaceId;

                        if (delivery.WarehouseId.HasValue)
                        {
                            using (
                                var warehouseService =
                                    SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
                            {
                                Warehouse warehouse = warehouseService.GetById(delivery.WarehouseId.Value);
                                WarehouseName = warehouse.Name;
                                WarehouseId = warehouse.Id;
                            }
                        }
                        LoadDeliveryLine(_tdId,0);//num参数是在外贸提单多选提单池的时候 为了将提单池行跟头对应的参数 这里不会用到
                    }
                }
                else
                {
                    PopDialog dialog = PopDialogCreater.CreateDialog("TDelivery", queryStr, null, null, null,
                                                                 _tdId, _contentId, true, null, new List<SortCol> { new SortCol { ColName = "IssueDate", ByDescending = true } });

                    dialog.ShowDialog();
                    var deliveryList = dialog.SelectedItemList;
                    if (deliveryList != null && deliveryList.Count > 0)
                    {
                        GetDataForSale(deliveryList.Cast<Delivery>().ToList());
                    }
                }
                //    _tdId = delivery.Id;
                //    if (DeliveryType != DBEntity.EnumEntity.DeliveryType.InternalMDBOL)
                //    {
                //        DeliveryNo = delivery.DeliveryNo;
                //    }
                //    IsVerified = delivery.IsVerified;
                //    if (ObjectId != 0)
                //    {
                //        DeletedDeliveryLines = GetDeliveryLines(ObjectId);
                //    }
                //    AddedDeliveryLines = new List<DeliveryLine>();
                //    TDeliveryNo = delivery.DeliveryNo;
                //    TDelivery = delivery;

                //    PackingStandard = delivery.PackingStandard;
                //    VesselNo = delivery.VesselNo;
                //    LoadingPortId = delivery.LoadingPortId;
                //    DischargePortId = delivery.DischargePortId;
                //    LoadingPlaceId = delivery.LoadingPlaceId;
                //    DischargePlaceId = delivery.DischargePlaceId;

                //    if (delivery.WarehouseId.HasValue)
                //    {
                //        using (
                //            var warehouseService =
                //                SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
                //        {
                //            Warehouse warehouse = warehouseService.GetById(delivery.WarehouseId.Value);
                //            WarehouseName = warehouse.Name;
                //            WarehouseId = warehouse.Id;
                //        }
                //    }
                //    LoadDeliveryLine(_tdId);

                //}
            }
        }

        private void LoadDeliveryLine(int id, int num)
        {
            using (var deliveryLineService = SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
            {
                if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.InternalMDWW)
                {
                    string strSql = "(it.Delivery.DeliveryType=" + (int)DeliveryType.InternalTDBOL + " or it.Delivery.DeliveryType=" + (int)DeliveryType.InternalTDWW + ") and it.Delivery.Id=" + id;
                    DeliveryLines = deliveryLineService.Select(strSql, null, new List<string> { "Country", "Delivery", "CommodityType", "CommodityType.Commodity", "Brand", "Specification", "SalesDeliveryLines", "WarehouseInLines" }).ToList();

                }
                else if (DeliveryType == DeliveryType.ExternalMDBOL)
                {
                    DeliveryLines =
                        deliveryLineService.Select(
                            "it.Delivery.DeliveryType=" + (int)DeliveryType.ExternalTDBOL + " and it.Delivery.Id=" + id,
                            null,
                            new List<string>
                                {
                                    "Delivery",
                                    "CommodityType",
                                    "CommodityType.Commodity",
                                    "Brand",
                                    "Specification",
                                    "Country",
                                    "SalesDeliveryLines",
                                    "WarehouseInLines"
                                }).ToList();
                }
                else if (DeliveryType == DeliveryType.ExternalMDWW)
                {
                    DeliveryLines =
                        deliveryLineService.Select(
                            "it.Delivery.DeliveryType=" + (int)DeliveryType.ExternalTDWW + " and it.Delivery.Id=" + id,
                            null,
                            new List<string>
                                {
                                    "Delivery",
                                    "CommodityType",
                                    "CommodityType.Commodity",
                                    "Brand",
                                    "Specification",
                                    "Country",
                                    "SalesDeliveryLines",
                                    "WarehouseInLines"
                                }).ToList();
                }
                if (DeliveryLines != null)
                {
                    foreach (var item in DeliveryLines)
                    {
                        item.DlvLineIsVerified = item.IsVerified;
                    }
                    if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.InternalMDWW)
                    {
                        //内贸
                        for (int i = DeliveryLines.Count - 1; i >= 0; i--)
                        {
                            DeliveryLines[i].NetWeight = DeliveryLines[i].OnlyQty;
                            DeliveryLines[i].VerifiedWeight = DeliveryLines[i].OnlyVerfiedQty;
                            DeliveryLines[i].PackingQuantity = DeliveryLines[i].OnlyPackingQuantity;
                            if (DeliveryLines[i].NetWeight == 0 && DeliveryLines[i].VerifiedWeight == 0)
                            {
                                DeliveryLines.RemoveAt(i);
                            }
                        }
                    }
                    else if (DeliveryType == DeliveryType.ExternalMDBOL || DeliveryType == DeliveryType.ExternalMDWW)
                    {
                        //外贸
                        for (int i = DeliveryLines.Count - 1; i >= 0; i--)
                        {
                            DeliveryLines[i].DeliveryPID = num;
                            DeliveryLines[i].NetWeight = DeliveryLines[i].OnlyQty;
                            DeliveryLines[i].GrossWeight = DeliveryLines[i].OnlyGrossWeight;
                            DeliveryLines[i].PackingQuantity = DeliveryLines[i].OnlyPackingQuantity;
                            if (DeliveryLines[i].NetWeight == 0 && DeliveryLines[i].GrossWeight == 0)
                            {
                                DeliveryLines.RemoveAt(i);
                            }
                        }
                    }

                    DeliveryLines.ForEach(o => AddedDeliveryLines.Add(o));
                }
                //AddSumLine();
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// 初始化页面数据
        /// </summary>
        /// <param name="d"></param>
        private void SetData(Delivery d)
        {
            //TDelivery = d.Delivery2;
            DeliveryNo = d.DeliveryNo;
            CirculNo = d.CirculNo;
            Comment = d.Comment;
            IssueDate = d.IssueDate ?? DateTime.Today;
            WarehouseId = d.WarehouseId;
            WarehouseName = d.Warehouse == null ? "" : d.Warehouse.Name;
            QuotaId = d.QuotaId;
            QuotaNo = d.Quota.QuotaNo;
            WarehouseProviderId = d.WarehouseProviderId;
            WarehouseProviderName = d.WarehouseProvider == null ? "" : d.WarehouseProvider.ShortName;
            ShipperId = d.ShipperId;
            ShipperName = d.Shipper == null ? "" : d.Shipper.ShortName;
            ShippingPartyId = d.ShippingPartyId;
            ShippingPartyName = d.ShippingParty == null ? "" : d.ShippingParty.ShortName;
            NotifyPartyId = d.NotifyPartyId;
            NotifyPartyName = d.NotifyParty == null ? "" : d.NotifyParty.ShortName;
            FinanceStatus = d.FinanceStatus == null ? 0 : ((bool)d.FinanceStatus ? 1 : 0);
            Commodity = d.Quota.Commodity;
            CommodityType = d.Quota.CommodityType;
            DeliveryType = (DeliveryType)d.DeliveryType;
            DeliveryTypeName = EnumHelper.GetDesByValue<DeliveryType>(d.DeliveryType);
            LoadingPortId = d.LoadingPortId;
            LoadingPortName = d.LoadingPort == null ? "" : d.LoadingPort.Name;
            LoadingPlaceId = d.LoadingPlaceId;
            LoadingPlaceName = d.LoadingPlace == null ? "" : d.LoadingPlace.Name;
            DischargePortId = d.DischargePortId;
            DischargePortName = d.DischargePort == null ? "" : d.DischargePort.Name;
            DischargePlaceId = d.DischargePlaceId;
            DischargePlaceName = d.DischargePlace == null ? "" : d.DischargePlace.Name;
            OnBoardDate = d.OnBoardDate;
            ArrivedDate = d.ArrivedDate;
            IsCustomed = d.IsCustomed;
            IsCopy = d.IsCopy;
            SetCheckCopy(IsCopy);
            VesselNo = d.VesselNo;
            PackingStandard = d.PackingStandard;
            LoadDeliveryLines(ObjectId);
            DeliveryLine firstDeliveryLine = DeliveryLines.FirstOrDefault();

            if (firstDeliveryLine != null && firstDeliveryLine.PurchaseDeliveryLine != null)
            {
                _tdId = firstDeliveryLine.PurchaseDeliveryLine.Delivery.Id;
                TDeliveryNo = firstDeliveryLine.PurchaseDeliveryLine.Delivery.DeliveryNo;
            }
            _contentId = _tdId;
            IsVerified = d.IsVerified;
            CommercialInvoiceId = d.CommercialInvoiceId;
            LCId = d.LCId;
            PaymentRequestId = d.PaymentRequestId;
            ActualDeliveryBPId = d.ActualDeliveryBPId;
            if (d.ActualDeliveryBPId.HasValue)
            {
                ActualDeliveryBPName = d.BusinessPartner.ShortName;
            }
            ContractInfo = d.Quota.ContractInfo;
        }

        /// <summary>
        /// 设置复印件和原始件
        /// </summary>
        /// <param name="isCopy"></param>
        private void SetCheckCopy(bool isCopy)
        {
            if (isCopy)
            {
                IsCopyFirst = true;
                IsCopySecond = false;
            }
            else
            {
                IsCopyFirst = false;
                IsCopySecond = true;
            }
        }

        /// <summary>
        /// 加载财务状态
        /// </summary>
        private void LoadComboxValue()
        {
            LoadStatus();
        }

        private IEnumerable<DeliveryLine> SetIsVerified()
        {
            var dline = new TrackableCollection<DeliveryLine>();
            foreach (var item in DeliveryLines)
            {
                if (item.IsDeleted)
                    continue;
                item.DlvLineIsVerified = item.IsVerified;
                dline.Add(item);
            }
            return dline;
        }

        /// <summary>
        /// 加载财务状态
        /// </summary>
        private void LoadStatus()
        {
            StatusTypes = new Dictionary<string, int>();
            StatusTypes = EnumHelper.GetEnumDic<StatusType>(StatusTypes);
        }

        /// <summary>
        /// 加载是否报关下拉框
        /// </summary>
        private void LoadIsCustomed()
        {
            IsCustomeds = new Dictionary<string, bool> { { ResDelivery.NotCustomed, false }, { ResDelivery.Customed, true } };
        }

        /// <summary>
        /// 加载装运地和卸货地
        /// </summary>
        public void LoadCountry()
        {
            using (var countryService = SvcClientManager.GetSvcClient<CountryServiceClient>(SvcType.CountrySvc))
            {
                List<Country> list = countryService.GetAll();
                list.Insert(0, new Country());
                LoadingPlaces = list;
                DischargePlaces = list;
            }
        }

        /// <summary>
        /// 加载装运港和卸货港
        /// </summary>
        public void LoadPort()
        {
            using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
            {
                List<Port> list = portService.GetAll();
                list.Insert(0, new Port());
                LoadingPorts = list;
                DischargePorts = list;
            }
        }

        /// <summary>
        /// 新增提单行
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="deliveryType"> </param>
        public void AddDeliveryLine(string moduleName, DeliveryType deliveryType)
        {
            var frm = new DeliveryLineDetail(moduleName, PageMode.AddMode, Commodity, CommodityType, Brand,
                                             Specification, deliveryType, DeliveryLines, AddedDeliveryLines, QuotaQty);
            frm.ShowDialog();
            DeliveryLines = frm.VM.DeliveryLines;
            AddedDeliveryLines = frm.VM.AddedDeliveryLines;
        }

        /// <summary>
        /// 编辑提单行
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moduleName"> </param>
        /// <param name="deliveryType"> </param>
        public void EditDeliveryLine(int id, string moduleName, DeliveryType deliveryType)
        {
            var frm = new DeliveryLineDetail(id, moduleName, PageMode.EditMode, Commodity, deliveryType, DeliveryLines, AddedDeliveryLines,
                                             UpdatedDeliveryLines, IsConvertWR);
            frm.ShowDialog();
        }

        public void DeleteDelivery(int id)
        {
            Delivery delivery = null;
            if (id < 0)
            {
                //新增的
                if (AddDeliveryList != null && AddDeliveryList.Count > 0)
                {
                    delivery = AddDeliveryList.Where(c => c.Id == id).FirstOrDefault();
                    if (delivery != null)
                    {
                        List<DeliveryLine> lines = AddedDeliveryLines.Where(c => c.DeliveryPID == delivery.ProvisionalID).ToList();
                        if (lines != null)
                        {
                            foreach (DeliveryLine line in lines)
                            {
                                AddedDeliveryLines.Remove(line);
                            }
                        }
                        AddDeliveryList.Remove(delivery);
                        DeliveryList.Remove(delivery);
                        GetSumNum();
                    }
                }
            }
            else
            {
                //编辑过来的删除操作
                if (DeliveryList != null && DeliveryList.Count > 0)
                {
                    delivery = DeliveryList.Where(c => c.Id == id).FirstOrDefault();
                    List<DeliveryLine> lines = DeliveryLines.Where(c => c.DeliveryId == id).ToList();
                    DeletedDeliveryLines.AddRange(lines);
                    DeleteDeliveryList.Add(delivery);
                    DeliveryList.Remove(delivery);
                    GetSumNum();
                }
            }
        }

        /// <summary>
        /// 删除提单行
        /// </summary>
        /// <param name="id"> </param>
        public void DeleteDeliveryLine(int id)
        {
            DeliveryLine deliveryLine = null;
            if (id < 0)
            {
                //新增的
                deliveryLine = GetDeliveryLineFromList(id, AddedDeliveryLines);
                if (deliveryLine != null)
                    AddedDeliveryLines.Remove(deliveryLine);
            }
            else if (id > 0)
            {
                //编辑的
                deliveryLine = GetDeliveryLineFromList(id, AddedDeliveryLines);
                if (deliveryLine != null)
                {
                    AddedDeliveryLines.Remove(deliveryLine);
                }
                else
                {
                    deliveryLine = GetDeliveryLineFromList(id, UpdatedDeliveryLines);
                    if (deliveryLine != null)
                    {
                        UpdatedDeliveryLines.Remove(deliveryLine);
                    }
                    deliveryLine = GetDeliveryLineFromList(id, DeliveryLines);
                    DeletedDeliveryLines.Add(deliveryLine);
                }
            }
            DeliveryLines.Remove(deliveryLine);
            DeliveryLine line = DeliveryLines.FirstOrDefault(o => o.Id == -Int32.MaxValue);
            if (line != null && DeliveryLines.Count == 1)
            {
                DeliveryLines = null;
            }
            else
            {
                AddSumLine();
            }
        }

        private DeliveryLine GetDeliveryLineFromList(int id, IEnumerable<DeliveryLine> deliveryLines)
        {
            if (deliveryLines != null)
            {
                return deliveryLines.FirstOrDefault(deliveryLine => deliveryLine.Id == id);
            }
            return null;
        }

        /// <summary>
        /// 根据id查询提单行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeliveryLine GetDeliveryLineById(int id)
        {
            //先从新增的列表里查找，再从更新的列表里查找，再从总数据源列表里查找
            IEnumerable<DeliveryLine> query = from deliveryLine in AddedDeliveryLines
                                              where deliveryLine.Id == id
                                              select deliveryLine;
            DeliveryLine q = query.ToList().FirstOrDefault();
            if (q != null)
                return q;

            query = from deliveryLine in UpdatedDeliveryLines where deliveryLine.Id == id select deliveryLine;
            q = query.ToList().FirstOrDefault();
            if (q != null)
                return q;

            query = from deliveryLine in DeliveryLines where deliveryLine.Id == id select deliveryLine;
            q = query.ToList().FirstOrDefault();
            if (q != null)
                return q;
            return null;
        }

        public DeliveryLine CancelSave(DeliveryLine delivery)
        {
            return null;
        }

        /// <summary>
        /// 提单新增
        /// </summary>
        protected override void Create()
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                //Delivery delivery = CreateDelivery();
                //AddedDeliveryLines = GetAddedDeliveryLines(AddedDeliveryLines);
                //if (delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || delivery.DeliveryType == (int)DeliveryType.InternalMDWW ||
                //    delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalMDWW)
                //{
                //    AddedDeliveryLines = SetTDeliveryLines(AddedDeliveryLines);
                //}
                //deliveryService.CreateDocument(CurrentUser.Id, delivery, AddedDeliveryLines, AddAttachments);
                if (DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDWW ||
                    DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDWW || IsConvertWR)
                {
                    Delivery delivery = CreateDelivery();
                    AddedDeliveryLines = GetAddedDeliveryLines(AddedDeliveryLines);
                    if (delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || delivery.DeliveryType == (int)DeliveryType.InternalMDWW ||
                        delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalMDWW)
                    {
                        AddedDeliveryLines = SetTDeliveryLines(AddedDeliveryLines);
                    }
                    deliveryService.CreateDataForInternal(CurrentUser.Id, delivery, AddedDeliveryLines, AddAttachments);
                }
                else
                {
                    AddedDeliveryLines = GetAddedDeliveryLines(AddedDeliveryLines);
                    if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.InternalMDWW ||
                        DeliveryType == DeliveryType.ExternalMDBOL || DeliveryType == DeliveryType.ExternalMDWW)
                    {
                        AddedDeliveryLines = SetTDeliveryLines(AddedDeliveryLines);
                    }
                    Delivery sumLine = DeliveryList.Where(c => c.Id == 0).FirstOrDefault();
                    if (sumLine != null)
                    {
                        DeliveryList.Remove(sumLine);
                    }
                    deliveryService.CreateData(CurrentUser.Id, DeliveryList, AddedDeliveryLines);
                }
            }
        }

        private List<DeliveryLine> SetTDeliveryLines(IEnumerable<DeliveryLine> addedDeliveryLines)
        {
            var lines = new List<DeliveryLine>();
            foreach (var line in addedDeliveryLines)
            {
                line.TDeliveryLineId = line.Id;
                lines.Add(line);
            }
            return lines;
        }

        private List<DeliveryLine> GetAddedDeliveryLines(IEnumerable<DeliveryLine> list)
        {
            if (list != null)
            {
                var newList = new List<DeliveryLine>();
                foreach (DeliveryLine line in list)
                {
                    var newLine = new DeliveryLine
                                      {
                                          Id = line.Id,
                                          BrandId = line.BrandId,
                                          Comment = line.Comment,
                                          CommodityTypeId = line.CommodityTypeId,
                                          CountryId = line.CountryId,
                                          DeliveryId = line.DeliveryId,
                                          DeliveryStatus = line.DeliveryStatus,
                                          GrossWeight = line.GrossWeight,
                                          NetWeight = line.NetWeight,
                                          PackingQuantity = line.PackingQuantity,
                                          PBNo = line.PBNo,
                                          SpecificationId = line.SpecificationId,
                                          VerifiedWeight = line.VerifiedWeight,
                                          IsVerified = line.IsVerified,
                                          TempUnitPrice = line.TempUnitPrice,
                                          TDeliveryLineId = line.TDeliveryLineId,
                                          BaseDeliveryLineId = line.BaseDeliveryLineId,
                                          FDPLineId = line.FDPLineId,
                                          DeliveryPID = line.DeliveryPID
                                      };
                    if (line.WarehouseOutDeliveryPersons.Count > 0)
                    {
                        foreach (WarehouseOutDeliveryPerson person in line.WarehouseOutDeliveryPersons)
                        {
                            var newPerson = new WarehouseOutDeliveryPerson
                                                {
                                                    Name = person.Name,
                                                    VehicleNo = person.VehicleNo,
                                                    IdentityCard = person.IdentityCard,
                                                    Id = person.Id,
                                                    DeliveryLineId = person.DeliveryLineId,
                                                    DeliveryQuantity = person.DeliveryQuantity,
                                                    IsDeleted = person.IsDeleted,
                                                    Tel = person.Tel
                                                };
                            newLine.WarehouseOutDeliveryPersons.Add(newPerson);
                        }
                    }

                    newList.Add(newLine);

                }
                return newList;
            }
            return null;
        }

        /// <summary>
        /// 根据不同的单据类型，生成不同的提单对象
        /// </summary>
        /// <returns></returns>
        private Delivery CreateDelivery()
        {
            var delivery = new Delivery
                               {
                                   QuotaId = QuotaId ?? 0,
                                   DeliveryType = (int)DeliveryType,
                                   IssueDate = IssueDate,
                                   Comment = Comment,
                                   FinanceStatus = FinanceStatus != 0,
                                   IsVerified = IsVerified,
                                   FDPId = ConvertZeroToNull(_fdpId)
                                   //WarehouseOutNo = WarehouseOutNo
                               };
            if (TdId > 0)
            {
                delivery.WarrantId = TdId;
            }
            switch (DeliveryType)
            {
                //内贸提单
                case DeliveryType.InternalTDBOL:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.WarehouseId = WarehouseId; //仓库
                    delivery.WarehouseProviderId = WarehouseProviderId; //仓储商
                    delivery.CommercialInvoiceId = CommercialInvoiceId;
                    delivery.LCId = LCId;
                    delivery.PaymentRequestId = PaymentRequestId;
                    break;
                //内贸仓单
                case DeliveryType.InternalTDWW:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.WarehouseId = WarehouseId; //仓库
                    delivery.WarehouseProviderId = WarehouseProviderId; //仓储商
                    delivery.CommercialInvoiceId = CommercialInvoiceId;
                    delivery.LCId = LCId;
                    delivery.PaymentRequestId = PaymentRequestId;
                    break;
                //外贸提单
                case DeliveryType.ExternalTDBOL:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.IsCopy = IsCopyFirst; //是否是复印件
                    delivery.ShipperId = ShipperId; //发货人
                    delivery.ShippingPartyId = ShippingPartyId; //承运商
                    delivery.NotifyPartyId = NotifyPartyId; //通知人
                    delivery.OnBoardDate = OnBoardDate; //装运日期
                    delivery.ArrivedDate = ArrivedDate; //到达日期
                    delivery.IsCustomed = IsCustomed; //报关状态
                    delivery.VesselNo = VesselNo; //船号
                    delivery.PackingStandard = PackingStandard; //打包规格
                    delivery.LoadingPortId = ConvertZeroToNull(LoadingPortId); //装运港
                    delivery.LoadingPlaceId = LoadingPlaceId; //装运地
                    delivery.DischargePortId = ConvertZeroToNull(DischargePortId); //卸货港
                    delivery.DischargePlaceId = DischargePlaceId; //卸货地
                    delivery.CirculNo = !string.IsNullOrEmpty(CirculNo) ? CirculNo : DeliveryNo;
                    delivery.CommercialInvoiceId = CommercialInvoiceId;
                    delivery.LCId = LCId;
                    delivery.PaymentRequestId = PaymentRequestId;
                    break;
                //外贸仓单
                case DeliveryType.ExternalTDWW:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.WarehouseId = WarehouseId; //仓库
                    delivery.WarehouseProviderId = WarehouseProviderId; //仓储商
                    delivery.IsCopy = IsCopyFirst; //是否是复印件
                    delivery.IsCustomed = IsCustomed; //报关状态
                    delivery.PackingStandard = PackingStandard; //打包规格
                    delivery.CirculNo = !string.IsNullOrEmpty(CirculNo) ? CirculNo : DeliveryNo;
                    delivery.CommercialInvoiceId = CommercialInvoiceId;
                    delivery.LCId = LCId;
                    delivery.PaymentRequestId = PaymentRequestId;
                    break;
                //内贸发货单 - 提单
                case DeliveryType.InternalMDBOL:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.WarehouseId = WarehouseId; //仓库
                    delivery.ActualDeliveryBPId = ActualDeliveryBPId;//实际提货人
                    break;
                //内贸发货单 - 仓单
                case DeliveryType.InternalMDWW:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.WarehouseId = WarehouseId; //仓库
                    delivery.ActualDeliveryBPId = ActualDeliveryBPId;//实际提货人
                    break;
                //外贸发货单 - 提单
                case DeliveryType.ExternalMDBOL:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.ShippingPartyId = ShippingPartyId; //承运商
                    delivery.NotifyPartyId = NotifyPartyId; //通知人
                    delivery.OnBoardDate = OnBoardDate; //装运日期
                    delivery.ArrivedDate = ArrivedDate; //到达日期
                    delivery.IsCustomed = IsCustomed; //报关状态
                    delivery.VesselNo = VesselNo; //船号
                    delivery.PackingStandard = PackingStandard; //打包规格
                    delivery.LoadingPortId = LoadingPortId; //装运港
                    delivery.LoadingPlaceId = LoadingPlaceId; //装运地
                    delivery.DischargePortId = DischargePortId; //卸货港
                    delivery.DischargePlaceId = DischargePlaceId; //卸货地
                    if (TDelivery != null)
                        delivery.FDPId = TDelivery.FDPId;
                    break;
                //外贸发货单 - 仓单
                default:
                    delivery.DeliveryNo = DeliveryNo;
                    delivery.IsCustomed = IsCustomed; //报关状态
                    delivery.PackingStandard = PackingStandard; //打包规格
                    delivery.WarehouseId = WarehouseId; //仓库
                    if (TDelivery != null)
                        delivery.FDPId = TDelivery.FDPId;
                    break;
            }
            return delivery;
        }

        /// <summary>
        /// 提单验证
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (string.IsNullOrEmpty(QuotaNo) || QuotaId == null)
            {
                throw new Exception(Properties.Resources.SelectQuotaWarning);
            }
            if (IssueDate == null)
            {
                throw new Exception(ResDelivery.IssuingDateRequired);
            }
            if (DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDWW ||
                   DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDWW)
            {
                if (DeliveryType == DeliveryType.ExternalTDBOL || DeliveryType == DeliveryType.ExternalTDWW)
                {
                    if (string.IsNullOrEmpty(DeliveryNo))
                    {
                        throw new Exception(ResDelivery.WRBLNoRequired);
                    }
                }
                if (DeliveryType == DeliveryType.InternalTDBOL || DeliveryType == DeliveryType.InternalTDWW ||
                    DeliveryType == DeliveryType.ExternalTDWW || DeliveryType == DeliveryType.InternalMDBOL ||
                    DeliveryType == DeliveryType.ExternalMDWW)
                {
                    if (WarehouseId == null || string.IsNullOrEmpty(WarehouseName))
                    {
                        throw new Exception(Properties.Resources.WarehouseRequired);
                    }
                }
                if (DeliveryType == DeliveryType.ExternalTDBOL)
                {
                    if (ShipperId == null || string.IsNullOrEmpty(ShipperName))
                    {
                        throw new Exception(ResDelivery.ConsignorRequired);
                    }
                }
                if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.ExternalMDBOL ||
                    DeliveryType == DeliveryType.ExternalMDWW)
                {
                    if (_tdId == 0)
                    {
                        throw new Exception(ResDelivery.OldWRBLNoRequired);
                    }
                }
            }
            if (DeliveryLines == null || DeliveryLines.Count == 0)
            {
                throw new Exception(ResDelivery.DetailRequired);
            }

            return true;
        }

        /// <summary>
        /// 提单更新
        /// </summary>
        protected override void Update()
        {
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                //Delivery delivery = CreateDelivery();
                //delivery.Id = ObjectId;
                //AddedDeliveryLines = GetAddedDeliveryLines(AddedDeliveryLines);
                //UpdatedDeliveryLines = GetAddedDeliveryLines(UpdatedDeliveryLines);
                //DeletedDeliveryLines = GetAddedDeliveryLines(DeletedDeliveryLines);
                //if (delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || delivery.DeliveryType == (int)DeliveryType.InternalMDWW ||
                //    delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalMDWW)
                //{
                //    AddedDeliveryLines = SetTDeliveryLines(AddedDeliveryLines);
                //    //UpdatedDeliveryLines = SetTDeliveryLines(UpdatedDeliveryLines);
                //}
                //deliveryService.UpdateDocument(CurrentUser.Id, delivery, AddedDeliveryLines, UpdatedDeliveryLines,
                //                               DeletedDeliveryLines,
                //                               AddAttachments, DeleteAttachments);

                if (DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalMDWW ||
                   DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDBOL || DeliveryType == DBEntity.EnumEntity.DeliveryType.InternalTDWW || DeliveryType == DeliveryType.ExternalMDWW || DeliveryType == DeliveryType.ExternalMDBOL)
                {
                    Delivery delivery = CreateDelivery();
                    delivery.Id = ObjectId;
                    AddedDeliveryLines = GetAddedDeliveryLines(AddedDeliveryLines);
                    UpdatedDeliveryLines = GetAddedDeliveryLines(UpdatedDeliveryLines);
                    DeletedDeliveryLines = GetAddedDeliveryLines(DeletedDeliveryLines);
                    if (delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || delivery.DeliveryType == (int)DeliveryType.InternalMDWW ||
                        delivery.DeliveryType == (int)DeliveryType.ExternalMDBOL || delivery.DeliveryType == (int)DeliveryType.ExternalMDWW )
                    {
                        AddedDeliveryLines = SetTDeliveryLines(AddedDeliveryLines);
                    }
                    deliveryService.UpdateDataForInternal(CurrentUser.Id, delivery, AddedDeliveryLines, UpdatedDeliveryLines,
                                                   DeletedDeliveryLines,
                                                   AddAttachments, DeleteAttachments);
                }
                else
                {
                    AddedDeliveryLines = GetAddedDeliveryLines(AddedDeliveryLines);
                    DeletedDeliveryLines = GetAddedDeliveryLines(DeletedDeliveryLines);
                    if (DeliveryType == DeliveryType.InternalMDBOL || DeliveryType == DeliveryType.InternalMDWW ||
                         DeliveryType == DeliveryType.ExternalMDBOL || DeliveryType == DeliveryType.ExternalMDWW)
                    {
                        AddedDeliveryLines = SetTDeliveryLines(AddedDeliveryLines);
                        //UpdatedDeliveryLines = SetTDeliveryLines(UpdatedDeliveryLines);
                    }
                    deliveryService.UpdateData(CurrentUser.Id, AddDeliveryList, DeleteDeliveryList, AddedDeliveryLines, DeletedDeliveryLines);
                }
            }
        }

        /// <summary>
        /// 根据id查找货权人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartner GetBPById(int id)
        {
            using (
                var bpService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                return bpService.GetById(id);
            }
        }

        /// <summary>
        /// 根据id查找批次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Quota GetQuotaById(int id)
        {
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                Quota quota = quotaService.SelectById(new List<string> { "Contract" }, id);
                return quota;
            }
        }

        /// <summary>
        /// 根据id查找提单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Delivery GetDeliveryById(int id)
        {
            using (var dService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                return dService.GetById(id);
            }
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="deleteId"></param>
        public void RemoveAttachment(int deleteId)
        {
            Attachment attachment = GetAttachmentById(deleteId, Attachments);
            if (attachment != null)
            {
                Attachments.Remove(attachment);
                if (Attachments.Count == 0)
                    Attachments = null;
            }

            Attachment addattachment = GetAttachmentById(deleteId, AddAttachments);
            {
                if (addattachment != null)
                {
                    //如果是新增的附件
                    AddAttachments.Remove(addattachment);
                    if (AddAttachments.Count == 0)
                        AddAttachments = null;
                }
                else
                {
                    //增加到删除列表里
                    if (DeleteAttachments == null)
                    {
                        DeleteAttachments = new List<Attachment>();
                    }
                    DeleteAttachments.Add(attachment);
                }
            }
        }

        /// <summary>
        /// 根据id获取附件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atts"> </param>
        /// <returns></returns>
        public Attachment GetAttachmentById(int id, List<Attachment> atts)
        {
            if (atts == null)
                return null;
            return atts.FirstOrDefault(attachment => attachment.Id == id);
        }

        /// <summary>
        /// 加载附件列表
        /// </summary>
        public void LoadAttachments()
        {
            //点编辑的时候
            if (ObjectId != 0)
            {
                //int id = GetDocumentId("Delivery");
                const int documentType = (int)DocumentType.Delivery;
                using (var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
                {
                    const string queryStr = "it.RecordId = @p1 and it.DocumentId= @p2";
                    var parameters = new List<object> { ObjectId, documentType };
                    _attachments = attachmentService.Query(queryStr, parameters);
                    Attachments = attachmentService.ChangeAttachmentName(_attachments);
                }
            }
        }

        private int GetDocumentId(string code)
        {
            int id;
            using (var documentService = SvcClientManager.GetSvcClient<DocumentServiceClient>(SvcType.DocumentSvc))
            {
                id = documentService.GetByTableCode(code).Id;
            }
            return id;
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="attachment"></param>
        public void AddAttachment(Attachment attachment)
        {
            int did = GetDocumentId("Delivery");
            if (Attachments == null)
                Attachments = new List<Attachment>();
            if (AddAttachments == null)
                AddAttachments = new List<Attachment>();
            attachment.DocumentId = did;
            int id = -GetMaxNum();
            attachment.Id = id;
            _attachments.Add(attachment);
            using (
                    var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc)
                    )
            {
                Attachments = attachmentService.ChangeAttachmentName(_attachments);
            }
            AddAttachments.Add(attachment);
        }

        /// <summary>
        /// 给新增的附件一个id值，方便删除操作定位
        /// </summary>
        /// <returns></returns>
        private int GetMaxNum()
        {
            if (Attachments.Count == 0)
                return 1;
            IEnumerable<int> query = from attachment in Attachments select Math.Abs(attachment.Id);
            int num = query.Max() + 1;
            return num;
        }

        public bool IsReexport()
        {
            using (var dService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                return dService.IsReexport(ObjectId, CurrentUser.Id);
            }
        }

        private int GetDeliveryId()
        {
            if (DeliveryList.Count == 0)
                return -1;
            int max = 0;
            foreach (var delivery in DeliveryList)
            {
                if (delivery.Id == -Int32.MaxValue)
                {
                    continue;
                }
                int id = delivery.Id;
                if (id < 0)
                    id = -id;
                if (id > max)
                    max = id;
            }
            return -(max + 1);
        }

        public void GetDataForSale(List<Delivery> itemList)
        {
            if (DeliveryLines == null)
            {
                DeliveryLines = new List<DeliveryLine>();
            }

            if (AddedDeliveryLines == null)
            {
                AddedDeliveryLines = new List<DeliveryLine>();
            }

            if (AddDeliveryList == null)
            {
                AddDeliveryList = new List<Delivery>();
            }

            int i;
            if (DeliveryList == null)
            {
                DeliveryList = new List<Delivery>();
                i = 0;
            }
            else
            {
                i = DeliveryList.Count;
            }

            foreach (Delivery delivery in itemList)
            {
                var sDelivery = new Delivery
                {
                    DeliveryType = (int)DeliveryType,
                    ProvisionalID = i,
                    TotalGrossWeight = delivery.DeliveryLines.Sum(c => c.OnlyGrossWeight),
                    TotalNetWeight = delivery.DeliveryLines.Sum(c => c.OnlyQty),
                    TotalPackingQty = delivery.DeliveryLines.Sum(c => c.OnlyPackingQuantity),
                    DeliveryNo = delivery.DeliveryNo,
                    QuotaId = QuotaId ?? 0,
                    FDPId = delivery.FDPId,
                    VesselNo = delivery.VesselNo,
                    ShippingPartyId = delivery.ShippingPartyId,
                    NotifyPartyId = delivery.NotifyPartyId,
                    IssueDate = delivery.IssueDate ?? DateTime.Today,
                    OnBoardDate = delivery.OnBoardDate,
                    PackingStandard = delivery.PackingStandard,
                    WarehouseProviderId = delivery.WarehouseProviderId,
                    WarehouseName = delivery.Warehouse == null ? "" : delivery.Warehouse.Name,
                    WarehouseId = delivery.WarehouseId,
                    CommodityTypeName = delivery.DeliveryLines.Where(c => c.CommodityTypeId != null).FirstOrDefault() == null ? "" : delivery.DeliveryLines.Where(c => c.CommodityTypeId != null).FirstOrDefault().CommodityType.Name,
                    BrandName = delivery.DeliveryLines.Where(c => c.BrandId != null).FirstOrDefault() == null ? "" : delivery.DeliveryLines.Where(c => c.BrandId != null).FirstOrDefault().Brand.Name,
                    LoadingPortId = ConvertZeroToNull(delivery.LoadingPortId), //装运港
                    LoadingPlaceId = delivery.LoadingPlaceId,//装运地
                    DischargePortId = ConvertZeroToNull(delivery.DischargePortId), //卸货港
                    DischargePlaceId = delivery.DischargePlaceId //卸货地
                };
                if (sDelivery.DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalMDBOL || sDelivery.DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalMDWW)
                {
                    sDelivery.CanEditEnable = true;
                }
                else {
                    sDelivery.CanEditEnable = false;
                }
                sDelivery.Id = GetDeliveryId();
                DeliveryList.Add(sDelivery);
                AddDeliveryList.Add(sDelivery);

                FilterDeleted(delivery.DeliveryLines);
                LoadDeliveryLine(delivery.Id,i);
                i++;
            }
        }

        public void GetData(List<ForeignDeliveryPool> itemList)
        {
            if (DeliveryLines == null)
            {
                DeliveryLines = new List<DeliveryLine>();
            }

            if (AddedDeliveryLines == null)
            {
                AddedDeliveryLines = new List<DeliveryLine>();
            }
            if (AddDeliveryList == null)
            {
                AddDeliveryList = new List<Delivery>();
            }

            int i;

            if (DeliveryList == null)
            {
                DeliveryList = new List<Delivery>();
                i = 0;
            }
            else
            {
                i = DeliveryList.Count;
            }

            foreach (ForeignDeliveryPool fdp in itemList)
            {
                var delivery = new Delivery
                {
                    DeliveryType = (int)DeliveryType,
                    ProvisionalID = i,

                    TotalGrossWeight = fdp.TotalGrossWeight,
                    TotalNetWeight = fdp.TotalNetWeight,
                    TotalPackingQty = fdp.TotalPackingQuantity,
                    DeliveryNo = fdp.DeliveryNo,
                    QuotaId = QuotaId ?? 0,
                    Comment = fdp.Comment,
                    FDPId = ConvertZeroToNull(fdp.Id),
                    VesselNo = fdp.VesselNo,
                    ShippingPartyId = fdp.ShippingPartyId,
                    NotifyPartyId = fdp.NotifyPartyId,
                    IssueDate = fdp.IssueDate ?? DateTime.Today,
                    OnBoardDate = fdp.OnBoardDate,
                    PackingStandard = fdp.PackingStandard,
                    WarehouseName = fdp.Warehouse == null ? "" : fdp.Warehouse.Name,
                    WarehouseProviderId = fdp.WarehouseProviderId,
                    WarehouseId = fdp.WarehouseId,
                    CommodityTypeName = fdp.ForeignDeliveryPoolLines.Where(c => c.CommodityTypeId != null).FirstOrDefault() == null ? "" : fdp.ForeignDeliveryPoolLines.Where(c => c.CommodityTypeId != null).FirstOrDefault().CommodityType.Name,
                    BrandName = fdp.ForeignDeliveryPoolLines.Where(c => c.BrandId != null).FirstOrDefault() == null ? "" : fdp.ForeignDeliveryPoolLines.Where(c => c.BrandId != null).FirstOrDefault().Brand.Name
                };
                //装运地和装运港
                LoadingPlaceId = fdp.LoadingPlaceId;
                if (LoadingPlaceId != null && LoadingPlaceId > 0)
                {
                    using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                    {
                        var tmpPorts = portService.GetPortsByCountry((int)LoadingPlaceId);
                        tmpPorts.Insert(0, new Port());
                        LoadingPorts = tmpPorts;
                        LoadingPortId = -1;
                        LoadingPortId = fdp.LoadingPortId;
                    }
                }
                else
                {
                    LoadingPorts = new List<Port> { new Port() };
                    LoadingPortId = -1;
                    LoadingPortId = 0;
                }

                //卸货地和卸货港
                DischargePlaceId = fdp.DischargePlaceId;
                if (DischargePlaceId != null && DischargePlaceId > 0)
                {
                    using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                    {
                        var tmpPorts = portService.GetPortsByCountry((int)DischargePlaceId);
                        tmpPorts.Insert(0, new Port());
                        DischargePorts = tmpPorts;
                        DischargePortId = -1;
                        DischargePortId = fdp.DischargePortId;
                    }
                }
                else
                {
                    DischargePorts = new List<Port> { new Port() };
                    DischargePortId = -1;
                    DischargePortId = 0;
                }
                delivery.LoadingPortId = ConvertZeroToNull(LoadingPortId); //装运港
                delivery.LoadingPlaceId = LoadingPlaceId; //装运地
                delivery.DischargePortId = ConvertZeroToNull(DischargePortId); //卸货港
                delivery.DischargePlaceId = DischargePlaceId; //卸货地
                delivery.Id = GetDeliveryId();

                DeliveryList.Add(delivery);
                AddDeliveryList.Add(delivery);
                FilterDeleted(fdp.ForeignDeliveryPoolLines);

                foreach (var line in fdp.ForeignDeliveryPoolLines)
                {
                    var newLine = new DeliveryLine
                    {
                        CommodityType = line.CommodityType,
                        Specification = line.Specification,
                        Country = line.OriginCountry,
                        NetWeight = line.NetWeight,
                        GrossWeight = line.GrossWeight,
                        PackingQuantity = line.PackingQuantity,
                        Comment = line.Comment,
                        Brand = line.Brand,
                        PBNo = line.PBNo,
                        FDPLineId = line.Id,
                        DeliveryPID = i
                    };
                    AddedDeliveryLines.Add(newLine);
                    DeliveryLines.Add(newLine);
                }
                i++;
                //AddedDeliveryLines.AddRange(DeliveryLines);
            }
        }

        public void GetSumNum()
        {
            decimal? sumG = 0;
            decimal? sumN = 0;
            decimal? sumP = 0;
            if (DeliveryList != null && DeliveryList.Count > 0)
            {
                if (DeliveryList.Count == 1 && DeliveryList.Where(c => c.Id == 0).FirstOrDefault() != null)
                {
                    Delivery delivery = DeliveryList.Where(c => c.Id == 0).FirstOrDefault();
                    DeliveryList.Remove(delivery);
                }
                else
                {
                    Delivery delivery = DeliveryList.Where(c => c.Id == 0).FirstOrDefault();
                    if (delivery != null)
                    {
                        DeliveryList.Remove(delivery);
                    }
                    sumG = DeliveryList.Sum(c => c.TotalGrossWeight);
                    sumN = DeliveryList.Sum(c => c.TotalNetWeight);
                    sumP = DeliveryList.Sum(c => c.TotalPackingQty);
                    DeliveryList.Add(new Delivery { Id = 0, DeliveryNo = "合计", TotalGrossWeight = sumG, TotalNetWeight = sumN, TotalPackingQty = sumP });
                }
            }
        }

        public void CopyFromFDP(ForeignDeliveryPool fdp)
        {
            _fdpId = fdp.Id;
            DeliveryNo = fdp.DeliveryNo;
            IsCopyFirst = false;
            IsCopySecond = true;
            //DeliveryType = (DeliveryType) fdp.DeliveryType;
            //DeliveryTypeName = EnumHelper.GetDesByValue<DeliveryType>(fdp.DeliveryType);
            if (ShipperId <= 0)
            {
                ShipperId = fdp.ShipperId;
                ShipperName = fdp.Shipper == null ? null : fdp.Shipper.ShortName;
            }

            VesselNo = fdp.VesselNo;
            ShippingPartyId = fdp.ShippingPartyId;
            ShippingPartyName = fdp.ShippingParty == null ? null : fdp.ShippingParty.ShortName;
            NotifyPartyId = fdp.NotifyPartyId;
            NotifyPartyName = fdp.NotifyParty == null ? null : fdp.NotifyParty.ShortName;
            IssueDate = fdp.IssueDate ?? DateTime.Today;
            OnBoardDate = fdp.OnBoardDate;
            PackingStandard = fdp.PackingStandard;
            WarehouseProviderId = fdp.WarehouseProviderId;
            WarehouseProviderName = fdp.WarehouseProvider == null ? null : fdp.WarehouseProvider.ShortName;
            WarehouseId = fdp.WarehouseId;
            WarehouseName = fdp.Warehouse == null ? null : fdp.Warehouse.Name;

            //装运地和装运港
            LoadingPlaceId = fdp.LoadingPlaceId;
            if (LoadingPlaceId != null && LoadingPlaceId > 0)
            {
                using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                {
                    var tmpPorts = portService.GetPortsByCountry((int)LoadingPlaceId);
                    tmpPorts.Insert(0, new Port());
                    LoadingPorts = tmpPorts;
                    LoadingPortId = -1;
                    LoadingPortId = fdp.LoadingPortId;
                }
            }
            else
            {
                LoadingPorts = new List<Port> { new Port() };
                LoadingPortId = -1;
                LoadingPortId = 0;
            }

            //卸货地和卸货港
            DischargePlaceId = fdp.DischargePlaceId;
            if (DischargePlaceId != null && DischargePlaceId > 0)
            {
                using (var portService = SvcClientManager.GetSvcClient<PortServiceClient>(SvcType.PortSvc))
                {
                    var tmpPorts = portService.GetPortsByCountry((int)DischargePlaceId);
                    tmpPorts.Insert(0, new Port());
                    DischargePorts = tmpPorts;
                    DischargePortId = -1;
                    DischargePortId = fdp.DischargePortId;
                }
            }
            else
            {
                DischargePorts = new List<Port> { new Port() };
                DischargePortId = -1;
                DischargePortId = 0;
            }

            if (DeliveryLines == null)
            {
                DeliveryLines = new List<DeliveryLine>();
            }
            else
            {
                if (DeletedDeliveryLines == null) DeletedDeliveryLines = new List<DeliveryLine>();
                foreach (var deliveryLine in DeliveryLines)
                {
                    if (deliveryLine.Id > 0)
                    {
                        DeletedDeliveryLines.Add(deliveryLine);
                    }
                }
                DeliveryLines.Clear();
            }

            if (AddedDeliveryLines == null)
            {
                AddedDeliveryLines = new List<DeliveryLine>();
            }
            else
            {
                AddedDeliveryLines.Clear();
            }

            //Copy Detail Lines
            FilterDeleted(fdp.ForeignDeliveryPoolLines);
            foreach (var line in fdp.ForeignDeliveryPoolLines)
            {
                DeliveryLines.Add(new DeliveryLine
                                      {
                                          CommodityType = line.CommodityType,
                                          Specification = line.Specification,
                                          Country = line.OriginCountry,
                                          NetWeight = line.NetWeight,
                                          GrossWeight = line.GrossWeight,
                                          PackingQuantity = line.PackingQuantity,
                                          Comment = line.Comment,
                                          Brand = line.Brand,
                                          PBNo = line.PBNo,
                                          FDPLineId = line.Id
                                      });
            }
            AddedDeliveryLines.AddRange(DeliveryLines);

            //Copy Attachment
            if (Attachments == null)
            {
                Attachments = new List<Attachment>();
            }
            else
            {
                Attachments.Clear();
            }

            if (AddAttachments == null)
            {
                AddAttachments = new List<Attachment>();
            }
            else
            {
                AddAttachments.Clear();
            }

            int deliveryDocId;
            using (var docService = SvcClientManager.GetSvcClient<DocumentServiceClient>(SvcType.DocumentSvc))
            {
                deliveryDocId = docService.GetByTableCode("Delivery").Id;
            }

            using (var attService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc))
            {
                var atts = attService.GetAttachments(fdp.DocumentId, fdp.Id);
                atts = attService.ChangeAttachmentName(atts);

                foreach (var a in atts)
                {
                    Attachments.Add(new Attachment
                                        {
                                            DocumentId = deliveryDocId,
                                            FileName = a.FileName,
                                            Name = a.Name
                                        });
                }

                if (AddAttachments == null)
                {
                    AddAttachments = new List<Attachment>();
                }
                AddAttachments.AddRange(Attachments);
            }

            Comment = fdp.Comment;
        }

        #endregion

        #region delivery 控件编辑

        private bool _isQuotaEnable;
        private bool _isTDEnable;
        private bool _isWarehouseEnable;
        private bool _isPoolNoBtnEnable;

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

        public bool IsPoolNoBtnEnable
        {
            get { return _isPoolNoBtnEnable; }
            set
            {
                if (_isPoolNoBtnEnable != value)
                {
                    _isPoolNoBtnEnable = value;
                    Notify("IsPoolNoBtnEnable");
                }
            }
        }

        public bool IsTDEnable
        {
            get { return _isTDEnable; }
            set
            {
                if (_isTDEnable != value)
                {
                    _isTDEnable = value;
                    Notify("IsTDEnable");
                }
            }
        }

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

        private void LoadDocumentEnableProperty(int id)
        {
            if (id <= 0)
            {
                IsQuotaEnable = true;
                IsTDEnable = true;
                IsWarehouseEnable = true;
                IsPoolNoBtnEnable = true;
            }
            else
            {
                using (var deliveryService =
                    SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
                {
                    DeliveryEnableProperty dep = deliveryService.SetElementsEnableProperty(id);
                    IsQuotaEnable = dep.IsQuotaEnable;
                    IsTDEnable = dep.IsTDEnable;
                    IsWarehouseEnable = dep.IsWarehouseEnable;
                    IsPoolNoBtnEnable = dep.IsPoolNoBtnEnable;
                }
            }
        }

        #endregion

        #region 货运状态

        private void LoadDeliveryLines(int deliveryId)
        {
            using (
                var deliveryLineService =
                    SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
            {
                DeliveryLines =
                    deliveryLineService.Select("it.Delivery.Id=" + deliveryId, null,
                                               new List<string>
                                                   {
                                                       "Delivery",
                                                       "CommodityType",
                                                       "CommodityType.Commodity",
                                                       "Brand",
                                                       "Specification",
                                                       "Country",
                                                       "WarehouseOutDeliveryPersons",
                                                       "PurchaseDeliveryLine.Delivery"
                                                   }).ToList();
                //foreach (var line in DeliveryLines)
                //{
                //    if (line.Delivery.DeliveryType == (int)DeliveryType.InternalMDBOL || line.Delivery.DeliveryType == (int)DeliveryType.InternalMDWW
                //        || line.Delivery.DeliveryType == (int)DeliveryType.InternalTDBOL || line.Delivery.DeliveryType == (int)DeliveryType.InternalTDWW)
                //    {
                //        line.OnlyQty = line.NetWeight.Value;
                //        line.OnlyVerfiedQty = line.VerifiedWeight;
                //        line.OnlyPackingQuantity = line.PackingQuantity;
                //    }
                //}
            }
        }

        private List<DeliveryLine> GetDeliveryLines(int deliveryId)
        {
            List<DeliveryLine> list;
            using (
                var deliveryLineService =
                    SvcClientManager.GetSvcClient<DeliveryLineServiceClient>(SvcType.DeliveryLineSvc))
            {
                list =
                    deliveryLineService.Select("it.Delivery.Id=" + deliveryId, null,
                                               new List<string>
                                                   {
                                                       "Delivery",
                                                       "CommodityType",
                                                       "CommodityType.Commodity",
                                                       "Brand",
                                                       "Specification",
                                                       "Country",
                                                       "WarehouseOutDeliveryPersons"
                                                   }).ToList();
            }
            return list;
        }




        #endregion

        #region 增加合计行

        public void AddSumLine()
        {
            if (DeliveryLines != null && DeliveryLines.Count > 0)
            {
                DeliveryLine deliveryLine = DeliveryLines.FirstOrDefault(o => o.Id == -Int32.MaxValue);
                if (deliveryLine != null)
                {
                    DeliveryLines.Remove(deliveryLine);
                }
                decimal sumNetWeight = 0M;
                decimal sumPackingQuantity = 0M;
                decimal sumVerifiedWeight = 0M;
                decimal sumGrossWeight = 0M;
                foreach (DeliveryLine line in DeliveryLines)
                {
                    if (line.NetWeight.HasValue)
                    {
                        sumNetWeight += line.NetWeight.Value;
                    }
                    if (line.PackingQuantity.HasValue)
                    {
                        sumPackingQuantity += line.PackingQuantity.Value;
                    }
                    if (line.VerifiedWeight.HasValue)
                    {
                        sumVerifiedWeight += line.VerifiedWeight.Value;
                    }
                    if (line.GrossWeight.HasValue)
                    {
                        sumGrossWeight += line.GrossWeight.Value;
                    }
                }
                var sumLine = new DeliveryLine();
                if (DeliveryType == DeliveryType.ExternalMDBOL || DeliveryType == DeliveryType.ExternalMDWW ||
                    DeliveryType == DeliveryType.ExternalTDBOL || DeliveryType == DeliveryType.ExternalTDWW)
                {
                    //foreach (DeliveryLine line in DeliveryLines)
                    //{
                    //    if (line.NetWeight.HasValue)
                    //    {
                    //        sumNetWeight += line.NetWeight.Value;
                    //    }
                    //    if (line.PackingQuantity.HasValue)
                    //    {
                    //        sumPackingQuantity += line.PackingQuantity.Value;
                    //    }

                    //    if (line.GrossWeight.HasValue)
                    //    {
                    //        sumGrossWeight += line.GrossWeight.Value;
                    //    }
                    //}

                    var commodityType = new CommodityType();
                    var commodity = new Commodity { Name = Properties.Resources.Summary };
                    commodityType.Commodity = commodity;
                    sumLine.CommodityType = commodityType;

                    //外贸
                    sumLine.NetWeight = sumNetWeight;
                    sumLine.PackingQuantity = sumPackingQuantity;
                    sumLine.GrossWeight = sumGrossWeight;
                }
                else
                {
                    //foreach (DeliveryLine line in DeliveryLines)
                    //{
                    //    if (line.OnlyQty.HasValue)
                    //    {
                    //        sumNetWeight += line.OnlyQty.Value;
                    //    }
                    //    if (line.OnlyPackingQuantity.HasValue)
                    //    {
                    //        sumPackingQuantity += line.OnlyPackingQuantity.Value;
                    //    }
                    //    if (line.OnlyVerfiedQty.HasValue)
                    //    {
                    //        sumVerifiedWeight += line.OnlyVerfiedQty.Value;
                    //    }
                    //}

                    sumLine.PBNo = Properties.Resources.Summary;

                    //内贸
                    sumLine.NetWeight = sumNetWeight;
                    sumLine.VerifiedWeight = sumVerifiedWeight;
                    sumLine.PackingQuantity = sumPackingQuantity;
                }
                sumLine.Id = -Int32.MaxValue;
                //sumLine.NetWeight = sumNetWeight;
                //sumLine.VerifiedWeight = sumVerifiedWeight;
                //sumLine.PackingQuantity = sumPackingQuantity;
                //sumLine.GrossWeight = sumGrossWeight;
                DeliveryLines.Add(sumLine);
            }
        }

        public void AddSumLineByInnerMD()
        {
            if (DeliveryLines != null && DeliveryLines.Count > 0)
            {
                DeliveryLine deliveryLine = DeliveryLines.FirstOrDefault(o => o.Id == -Int32.MaxValue);
                if (deliveryLine != null)
                {
                    DeliveryLines.Remove(deliveryLine);
                }
                decimal sumNetWeight = 0M;
                decimal sumPackingQuantity = 0M;
                decimal sumVerifiedWeight = 0M;
                decimal sumGrossWeight = 0M;
                foreach (DeliveryLine line in DeliveryLines)
                {
                    if (line.OnlyQty.HasValue)
                    {
                        sumNetWeight += line.OnlyQty.Value;
                    }
                    if (line.OnlyPackingQuantity.HasValue)
                    {
                        sumPackingQuantity += line.OnlyPackingQuantity.Value;
                    }
                    if (line.OnlyVerfiedQty.HasValue)
                    {
                        sumVerifiedWeight += line.OnlyVerfiedQty.Value;
                    }
                    if (line.GrossWeight.HasValue)
                    {
                        sumGrossWeight += line.GrossWeight.Value;
                    }
                }
                var sumLine = new DeliveryLine();
                if (DeliveryType == DeliveryType.ExternalMDBOL || DeliveryType == DeliveryType.ExternalMDWW ||
                    DeliveryType == DeliveryType.ExternalTDBOL || DeliveryType == DeliveryType.ExternalTDWW)
                {
                    //foreach (DeliveryLine line in DeliveryLines)
                    //{
                    //    if (line.NetWeight.HasValue)
                    //    {
                    //        sumNetWeight += line.NetWeight.Value;
                    //    }
                    //    if (line.PackingQuantity.HasValue)
                    //    {
                    //        sumPackingQuantity += line.PackingQuantity.Value;
                    //    }

                    //    if (line.GrossWeight.HasValue)
                    //    {
                    //        sumGrossWeight += line.GrossWeight.Value;
                    //    }
                    //}

                    var commodityType = new CommodityType();
                    var commodity = new Commodity { Name = Properties.Resources.Summary };
                    commodityType.Commodity = commodity;
                    sumLine.CommodityType = commodityType;

                    //外贸
                    sumLine.NetWeight = sumNetWeight;
                    sumLine.PackingQuantity = sumPackingQuantity;
                    sumLine.GrossWeight = sumGrossWeight;
                }
                else
                {
                    //foreach (DeliveryLine line in DeliveryLines)
                    //{
                    //    if (line.OnlyQty.HasValue)
                    //    {
                    //        sumNetWeight += line.OnlyQty.Value;
                    //    }
                    //    if (line.OnlyPackingQuantity.HasValue)
                    //    {
                    //        sumPackingQuantity += line.OnlyPackingQuantity.Value;
                    //    }
                    //    if (line.OnlyVerfiedQty.HasValue)
                    //    {
                    //        sumVerifiedWeight += line.OnlyVerfiedQty.Value;
                    //    }
                    //}

                    sumLine.PBNo = Properties.Resources.Summary;

                    //内贸
                    sumLine.OnlyQty = sumNetWeight;
                    sumLine.OnlyVerfiedQty = sumVerifiedWeight;
                    sumLine.OnlyPackingQuantity = sumPackingQuantity;
                }
                sumLine.Id = -Int32.MaxValue;
                //sumLine.NetWeight = sumNetWeight;
                //sumLine.VerifiedWeight = sumVerifiedWeight;
                //sumLine.PackingQuantity = sumPackingQuantity;
                //sumLine.GrossWeight = sumGrossWeight;
                DeliveryLines.Add(sumLine);
            }
        }

        #endregion

        #region 增加实际提货人
        public void ShowActualDeliveryBP()
        {
            string queryStr = "it.CustomerType=" + (int)BusinessPartnerType.Customer + "or it.CustomerType=" + (int)BusinessPartnerType.InternalCustomer;
            PopDialog dialog = PopDialogCreater.CreateDialog("BusinessPartner", queryStr, null);
            dialog.ShowDialog();
            var bp = dialog.SelectedItem as BusinessPartner;
            if (bp != null)
            {
                ActualDeliveryBPId = bp.Id;
                ActualDeliveryBPName = bp.ShortName;
            }
        }
        #endregion

        #region 提单转仓单
        private void LoadConvertWR(int tdId)
        {
            IsConvertWR = true;
            using (var deliveryService = SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                Delivery td = deliveryService.SelectById(new List<string> { "Quota", "Quota.Commodity", "DeliveryLines", "DeliveryLines.CommodityType", "DeliveryLines.Brand", "DeliveryLines.Country", "Warehouse" }, tdId);

                FilterDeleted(td.DeliveryLines);
                DeliveryLines = td.DeliveryLines.ToList();
                AddedDeliveryLines = td.DeliveryLines.ToList();
                QuotaId = td.Quota.Id;
                QuotaNo = td.Quota.QuotaNo;
                Commodity = td.Quota.Commodity;
                if (td.WarehouseId.HasValue)
                {
                    WarehouseName = td.Warehouse.Name;
                    WarehouseId = td.Warehouse.Id;
                }
                PackingStandard = td.PackingStandard;
                CirculNo = td.CirculNo;

                _fdpId = td.FDPId ?? 0;

            }
        }
        #endregion
    }
}