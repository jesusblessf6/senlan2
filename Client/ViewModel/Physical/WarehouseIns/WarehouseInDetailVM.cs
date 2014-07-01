using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.View.Physical.WarehouseIns;
using Client.WarehouseInServiceReference;
using Client.WarehouseServiceReference;
using DBEntity;
using DBEntity.EnableProperty;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using Client.CommodityServiceReference;

namespace Client.ViewModel.Physical.WarehouseIns
{
    public class WarehouseInDetailVM : BaseVM
    {
        #region Member

        private string _comment;
        private Commodity _commodity;

        private DeliveryTypeWarehouseIn _deliveryTypeWarehouseIn;

        private List<WarehouseInLine> _lines;
        private int _warehouseId;
        private WarehouseIn _warehouseIn;
        private DateTime? _warehouseInDate = DateTime.Now.Date;
        private int _warehouseInId;
        private string _warehouseInLineComment;
        private int _warehouseInLineId;
        private List<WarehouseInLine> _warehouseInLines;
        private string _warehouseName;
        public decimal? TotalPackingQty = 0;
        public decimal TotalQty = 0;
        public decimal TotalVerQty = 0;
        private List<Commodity> _CommodityList;
        private int _SelectedCommodityId;

        #region 入库行列表维护

        private List<WarehouseInLine> _addWarehouseInLines;
        private List<WarehouseInLine> _allWarehouseInLines;
        private List<WarehouseInLine> _deleteWarehouseInLines;
        private List<WarehouseInLine> _updateWarehouseInLines;

        #endregion

        #endregion

        #region Property
        public int SelectedCommodityId
        {
            get { return _SelectedCommodityId; }
            set{
                if(_SelectedCommodityId != value)
                {
                    _SelectedCommodityId = value;
                    Notify("SelectedCommodityId");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _CommodityList; }
            set { 
                if(_CommodityList != value)
                {
                    _CommodityList = value;
                    Notify("CommodityList");
                }
            }
        }

        public List<WarehouseInLine> AllWarehouseInLines
        {
            get { return _allWarehouseInLines; }
            set
            {
                if (_allWarehouseInLines != value)
                {
                    _allWarehouseInLines = value;
                    Notify("AllWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> DeleteWarehouseInLines
        {
            get { return _deleteWarehouseInLines; }
            set
            {
                if (_deleteWarehouseInLines != value)
                {
                    _deleteWarehouseInLines = value;
                    Notify("DeleteWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> UpdateWarehouseInLines
        {
            get { return _updateWarehouseInLines; }
            set
            {
                if (_updateWarehouseInLines != value)
                {
                    _updateWarehouseInLines = value;
                    Notify("UpdateWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> AddWarehouseInLines
        {
            get { return _addWarehouseInLines; }
            set
            {
                if (_addWarehouseInLines != value)
                {
                    _addWarehouseInLines = value;
                    Notify("AddWarehouseInLines");
                }
            }
        }

        public List<WarehouseInLine> Lines
        {
            get { return _lines; }
            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    Notify("Lines");
                }
            }
        }

        public WarehouseIn WarehouseIn
        {
            get { return _warehouseIn; }
            set
            {
                if (_warehouseIn != value)
                {
                    _warehouseIn = value;
                    Notify("WarehouseIn");
                }
            }
        }

        public int WarehouseInId
        {
            get { return _warehouseInId; }
            set
            {
                if (_warehouseInId != value)
                {
                    _warehouseInId = value;
                    Notify("WarehouseInId");
                }
            }
        }

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

        public DeliveryTypeWarehouseIn DeliveryTypeWarehouseIn
        {
            get { return _deliveryTypeWarehouseIn; }
            set
            {
                if (_deliveryTypeWarehouseIn != value)
                {
                    _deliveryTypeWarehouseIn = value;
                    Notify("DeliveryTypeWarehouseIn");
                }
            }
        }


        public DateTime? WarehouseInDate
        {
            get { return _warehouseInDate; }
            set
            {
                _warehouseInDate = value;
                Notify("WarehouseInDate");
            }
        }

        public int WarehouseId
        {
            get { return _warehouseId; }
            set
            {
                _warehouseId = value;
                Notify("WarehouseId");
            }
        }

        public string WarehouseName
        {
            get { return _warehouseName; }
            set
            {
                _warehouseName = value;
                Notify("WarehouseName");
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                Notify("Comment");
            }
        }

        public string WarehouseInLineComment
        {
            get { return _warehouseInLineComment; }
            set
            {
                _warehouseInLineComment = value;
                Notify("WarehouseInLineComment");
            }
        }

        public List<WarehouseInLine> WarehouseInLines
        {
            get { return _warehouseInLines; }
            set
            {
                _warehouseInLines = value;
                Notify("WarehosueInLines");
            }
        }

        public int WarehouseInLineId
        {
            get { return _warehouseInLineId; }
            set
            {
                _warehouseInLineId = value;
                Notify("WarehouseInLineId");
            }
        }

        #endregion

        #region Constructor

        public WarehouseInDetailVM(DeliveryTypeWarehouseIn deliveryTypeWarehouseIn)
        {
            ObjectId = 0;
            AllWarehouseInLines = new List<WarehouseInLine>();
            AddWarehouseInLines = new List<WarehouseInLine>();
            LoadCommodity();
            DeliveryTypeWarehouseIn = deliveryTypeWarehouseIn;
            Initialize(ObjectId);
            LoadDocumentEnableProperty(ObjectId);
        }

        public WarehouseInDetailVM(int warehouseInId)
        {
            ObjectId = warehouseInId;
            AddWarehouseInLines = new List<WarehouseInLine>();
            UpdateWarehouseInLines = new List<WarehouseInLine>();
            DeleteWarehouseInLines = new List<WarehouseInLine>();
            LoadCommodity();
            Initialize(ObjectId);
            LoadDocumentEnableProperty(ObjectId);
        }

        #endregion

        #region Method
        private void LoadCommodity()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commService.GetCommoditiesByUser(CurrentUser.Id);
            }

            CommodityList.Insert(0, new Commodity { Id = 0, Name = string.Empty });
        }

        public void Initialize(int id)
        {
            if (ObjectId > 0)
            {
                using (
                    var warehouseInService =
                        SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
                {
                    const string str = "it.Id = @p1 ";
                    var parameters = new List<object> {id};
                    List<WarehouseIn> warehouseIns = warehouseInService.Select(str, parameters,
                                                                               new List<string>
                                                                                   {
                                                                                       "WarehouseInLines",
                                                                                       "WarehouseInLines.DeliveryLine",
                                                                                       "WarehouseInLines.DeliveryLine.Delivery.Quota.Commodity",
                                                                                       "WarehouseInLines.CommodityType",
                                                                                       "WarehouseInLines.Brand",
                                                                                       "WarehouseInLines.DeliveryLine.Delivery.Quota.Contract"
                                                                                   });
                    if (warehouseIns.Count > 0)
                    {
                        WarehouseIn warehouseIn = warehouseIns[0];
                        FilterDeleted(warehouseIn.WarehouseInLines);
                        WarehouseInDate = warehouseIn.WarehouseInDate;
                        WarehouseId = warehouseIn.WarehouseId;
                        Comment = warehouseIn.Comment;
                        SelectedCommodityId = warehouseIn.CommodityId ?? 0;
                        AllWarehouseInLines = warehouseIn.WarehouseInLines.Where(c => c.IsDeleted == false).ToList();
                        WarehouseInLine warehouseInLine = AllWarehouseInLines[0];
                        if (warehouseInLine.DeliveryLine.Delivery.DeliveryType == 1 ||
                            warehouseInLine.DeliveryLine.Delivery.DeliveryType == 2)
                        {
                            DeliveryTypeWarehouseIn = DeliveryTypeWarehouseIn.InternalWarehouseIn;
                        }
                        else
                        {
                            DeliveryTypeWarehouseIn = DeliveryTypeWarehouseIn.ExternalWarehouseIn;
                        }
                        using (
                            var warehouseService =
                                SvcClientManager.GetSvcClient<WarehouseServiceClient>(SvcType.WarehouseSvc))
                        {
                            Warehouse wh = warehouseService.GetById(WarehouseId);
                            if (wh != null)
                            {
                                WarehouseName = wh.Name;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// 重写新增
        /// </summary>
        protected override void Create()
        {
            var warehouseIn = new WarehouseIn
                                  {Comment = Comment, WarehouseInDate = WarehouseInDate, WarehouseId = WarehouseId, CommodityId = SelectedCommodityId};

            using (var warehouseInService = SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
            {
                warehouseInService.CreateDocument(CurrentUser.Id, warehouseIn, AddWarehouseInLines);
            }
        }

        /// <summary>
        /// 重写更新
        /// </summary>
        protected override void Update()
        {
            using (var warehouseInService = SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
            {
                WarehouseIn warehouseIn = warehouseInService.GetById(ObjectId);
                if (warehouseIn != null)
                {
                    warehouseIn.WarehouseInDate = WarehouseInDate;
                    warehouseIn.WarehouseId = WarehouseId;
                    warehouseIn.Comment = Comment;
                    warehouseIn.CommodityId = SelectedCommodityId;
                }
                warehouseInService.UpdateDocument(CurrentUser.Id, warehouseIn, AddWarehouseInLines,
                                                  UpdateWarehouseInLines, DeleteWarehouseInLines, AllWarehouseInLines);
            }
        }

        /// <summary>
        /// 在入库明细的入库行列表中点击删除按钮
        /// </summary>
        /// <param name="warehouseInLineID"></param>
        public void DelWarehouseInLine(int warehouseInLineID)
        {
            if (AllWarehouseInLines.Count > 0)
            {
                List<WarehouseInLine> lines = AllWarehouseInLines.Where(c => c.Id == warehouseInLineID).ToList();
                WarehouseInLine line = lines[0];
                AllWarehouseInLines.Remove(line);
                if (line.Id > 0)
                {
                    DeleteWarehouseInLines.Add(line);
                }
                else
                {
                    AddWarehouseInLines.Remove(line);
                }
            }
        }

        public void SetQty()
        {
            if (AllWarehouseInLines.Count > 0)
            {
                Lines = new List<WarehouseInLine>();
                TotalQty = 0;
                TotalVerQty = 0;
                TotalPackingQty = 0;
                foreach (WarehouseInLine line in AllWarehouseInLines)
                {
                    TotalQty += Convert.ToDecimal(line.Quantity);
                    TotalVerQty += Convert.ToDecimal(line.VerifiedQuantity);
                    TotalPackingQty += line.PackingQuantity;

                    Lines.Add(line);
                }
                Lines.Add(new WarehouseInLine
                              {Quantity = TotalQty, VerifiedQuantity = TotalVerQty, PackingQuantity = TotalPackingQty});
            }
            else
            {
                TotalQty = 0;
                TotalVerQty = 0;
                Lines = new List<WarehouseInLine>();
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(WarehouseName))
            {
                throw new Exception(Properties.Resources.WarehouseRequired);
            }
            if (SelectedCommodityId <= 0)
            {
                throw new Exception(Properties.Resources.CommodityNotNull);
            }
            if (AllWarehouseInLines.Count <= 0)
            {
                throw new Exception(ResWarehouseIn.WarehouseInLineRequired);
            }

            return true;
        }

        #region 入库上的控件的enable属性

        private bool _isWarehouseEnable;

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
                IsWarehouseEnable = true;
            }
            else
            {
                using (var warehouseInService =
                    SvcClientManager.GetSvcClient<WarehouseInServiceClient>(SvcType.WarehouseInSvc))
                {
                    WarehouseInEnableProperty wiep = warehouseInService.SetElementsEnableProperty(id);
                    IsWarehouseEnable = wiep.IsWarehouseEnable;
                }
            }
        }

        #endregion
    }
}