using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using DBEntity.EnumEntity;
using Utility.Misc;
using DBEntity;
using Utility.QueryManagement;
using Utility.ServiceManagement;
using Client.CommodityServiceReference;

namespace Client.ViewModel.Physical.WarehouseOuts
{
    public class WarehouseOutHomeVM : HomeBaseVM
    {
        #region Search type

        public enum SearchType
        {
            CurrentMonth,
            LastMonth,
            LastYear,
            CurrentYear,
            Free
        }

        #endregion

        #region Member

        private DateTime? _endDate;
        private DateTime? _startDate;
        private int _supplierId;
        private string _supplierName;
        private List<EnumItem> _verifiedStatus;
        private int _warehouseId;
        private string _warehouseName;
        private List<Commodity> _commodityList;
        private int _commodityId;
        private bool _onlyCurrentUser;
        private int _selectedVerifiedStatus;

        #endregion

        #region Property
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

        public List<Commodity> CommodityList
        {
            get { return _commodityList; }
            set
            {
                _commodityList = value;
                Notify("CommodityList");
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

        public int SupplierId
        {
            get { return _supplierId; }
            set
            {
                if (_supplierId != value)
                {
                    _supplierId = value;
                    Notify("SupplierId");
                }
            }
        }

        public string SupplierName
        {
            get { return _supplierName; }
            set
            {
                if (_supplierName != value)
                {
                    _supplierName = value;
                    Notify("SupplierName");
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

        public List<EnumItem> VerifiedStatus
        {
            get { return _verifiedStatus; }
            set
            {
                _verifiedStatus = value;
                Notify("StatusTypes");
            }
        }

        public int SelectedVerifiedStatus
        {
            get { return _selectedVerifiedStatus; }
            set
            {
                if (_selectedVerifiedStatus != value)
                {
                    _selectedVerifiedStatus = value;
                    Notify("SelectedVerifiedStatus");
                }
            }
        }

        public bool OnlyCurrentUser
        {
            get { return _onlyCurrentUser; }
            set
            {
                if (_onlyCurrentUser != value)
                {
                    _onlyCurrentUser = value;
                    Notify("OnlyCurrentUser");
                }
            }
        }

        #endregion

        #region Constructor

        public WarehouseOutHomeVM()
        {
            Initialize();
        }

        #endregion

        #region Method

        private void Initialize()
        {
            //Commodities
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodityList = commodityService.GetCommoditiesByUser(CurrentUser.Id);
            }
            _commodityList.Insert(0, new Commodity());

            //Verified Status
            _verifiedStatus = EnumHelper.GetEnumList<IsVerified>();
            _verifiedStatus.Insert(0, new EnumItem());

            _onlyCurrentUser = true;

            _endDate = DateTime.Today;
            _startDate = DateTime.Today.AddMonths(-1);
        }

        public override List<QueryElement> GetQueryElements(object queryType = null)
        {
            var type = queryType == null ? SearchType.Free : (SearchType) queryType;
            var elements = new List<QueryElement>();
            var day1OfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var day1OfCurrentYear = new DateTime(DateTime.Today.Year, 1, 1);

            var icIds = GetInternalCustomerIdsOfCurrentUser();
            for (int i = 0; i < icIds.Count; i ++)
            {
                var e = new QueryElement { FieldName = "Quota.Contract.InternalCustomerId", Operator = Operator.Equal, Value = icIds[i]};
                if (i == 0)
                {
                    e.WithLeftBracket = true;
                }
                else
                {
                    e.RelationToLeft = Relation.Or;
                }

                if (i == icIds.Count - 1)
                {
                    e.WithRightBracket = true;
                }
                elements.Add(e);
            }

            switch (type)
            {
                case SearchType.CurrentMonth:
                    {
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.GreaterEqualThan, Value = day1OfCurrentMonth});
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.LessEqualThan, Value = day1OfCurrentMonth.AddMonths(1).AddDays(-1)});
                    }
                    break;

                case SearchType.CurrentYear:
                    {
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.GreaterEqualThan, Value = day1OfCurrentYear });
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.LessEqualThan, Value = day1OfCurrentMonth.AddYears(1).AddDays(-1) });
                    }
                    break;

                case SearchType.LastMonth:
                    {
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.GreaterEqualThan, Value = day1OfCurrentMonth.AddMonths(-1) });
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.LessEqualThan, Value = day1OfCurrentMonth.AddDays(-1) });
                    }
                    break;

                case SearchType.LastYear:
                    {
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.GreaterEqualThan, Value = day1OfCurrentYear.AddYears(-1) });
                        elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.LessEqualThan, Value = day1OfCurrentMonth.AddDays(-1) });
                    }
                    break;

                case SearchType.Free:
                    {
                        if (SupplierId > 0)
                        {
                            elements.Add(new QueryElement { FieldName = "Quota.Contract.BPId", Operator = Operator.Equal, Value = SupplierId});
                        }

                        if (WarehouseId > 0)
                        {
                            elements.Add(new QueryElement{FieldName = "WarehouseId", Operator = Operator.Equal, Value = WarehouseId});
                        }

                        if (StartDate != null)
                        {
                            elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.GreaterEqualThan, Value = StartDate});
                        }

                        if (EndDate != null)
                        {
                            elements.Add(new QueryElement { FieldName = "WarehouseOutDate", Operator = Operator.LessEqualThan, Value = EndDate});
                        }

                        if (SelectedVerifiedStatus > 0)
                        {
                            elements.Add(new QueryElement{FieldName = "IsVerified", Operator = Operator.Equal, Value = (SelectedVerifiedStatus == (int)IsVerified.True)});
                        }

                        if (CommodityId > 0)
                        {
                            elements.Add(new QueryElement{FieldName = "Quota.CommodityId", Operator = Operator.Equal, Value = CommodityId});
                        }

                        if (OnlyCurrentUser)
                        {
                            elements.Add(new QueryElement{FieldName = "CreatedBy", Operator = Operator.Equal, Value = CurrentUser.Id});
                        }
                    }
                    break;
            }

            return elements;
        }

        public override void Reset()
        {
            SupplierId = 0;
            SupplierName = string.Empty;
            WarehouseId = 0;
            WarehouseName = string.Empty;
            StartDate = null;
            EndDate = null;
            SelectedVerifiedStatus = 0;
            CommodityId = 0;
            OnlyCurrentUser = true;
        }

        #endregion
    }
}