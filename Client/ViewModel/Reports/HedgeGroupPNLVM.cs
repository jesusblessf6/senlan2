using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.HedgeGroupServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.QueryManagement;
using Utility.ServiceManagement;

namespace Client.ViewModel.Reports
{
    public class HedgeGroupPNLVM : BaseVM
    {
        #region Member

        private DateTime? _startDate;
        private DateTime? _endDate;
        private int _selectedHedgeTypeId;
        private List<HedgeGroupFloatPNLLine> _lines;
        private List<EnumItem> _hedgeTypes;
        private string _con;
        private List<object> _params;
        private int _selectedHedgeStatusId;
        private List<EnumItem> _hedgeStatuses; 
        
        #endregion

        #region Properties

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

        public int SelectedHedgeTypeId
        {
            get { return _selectedHedgeTypeId; }
            set
            {
                if (_selectedHedgeTypeId != value)
                {
                    _selectedHedgeTypeId = value;
                    Notify("SelectedHedgeTypeId");
                }
            }
        } 

        public List<HedgeGroupFloatPNLLine> Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;
                Notify("Lines");
            }
        }

        public List<EnumItem> HedgeTypes
        {
            get { return _hedgeTypes; }
            set
            {
                _hedgeTypes = value;
                Notify("HedgeTypes");
            }
        }

        public int SelectedHedgeStatusId
        {
            get { return _selectedHedgeStatusId; }
            set
            {
                if (_selectedHedgeStatusId != value)
                {
                    _selectedHedgeStatusId = value;
                    Notify("SelectedHedgeStatusId");
                }
            }
        }

        public List<EnumItem> HedgeStatuses
        {
            get { return _hedgeStatuses; }
            set
            {
                _hedgeStatuses = value;
                Notify("HedgeStatuses");
            }
        }

        public int From { get; set; }
        public int To { get; set; }
        public int RecCount { get; set; }

        #endregion

        #region Constructor

        public HedgeGroupPNLVM()
        {
            _hedgeTypes = EnumHelper.GetEnumList<ArbitrageType>();
            _hedgeTypes.Insert(0, new EnumItem());

            _hedgeStatuses = EnumHelper.GetEnumList<HedgeGroupStatus>();
            _hedgeStatuses.Insert(0, new EnumItem());

            Lines = new List<HedgeGroupFloatPNLLine>();
        }

        #endregion

        #region Method

        public void LoadCount()
        {
            using (var hgSvc = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                if (string.IsNullOrWhiteSpace(_con)) _con = "1=1";
                RecCount = hgSvc.GetCount(_con, _params);
            }
        }

        public void BuildQuery()
        {
            var elements = new List<QueryElement>();

            if (SelectedHedgeStatusId != 0)
            {
                elements.Add(new QueryElement
                {
                    FieldName = "Status",
                    Operator = Operator.Equal,
                    Value = SelectedHedgeStatusId
                });
            }

            if (StartDate != null)
            {
                elements.Add(new QueryElement
                                 {
                                     FieldName = "HedgeDate",
                                     Operator = Operator.GreaterEqualThan,
                                     Value = StartDate
                                 });
            }
            
            if (EndDate != null)
            {
                elements.Add(new QueryElement
                                 {
                                     FieldName = "HedgeDate",
                                     Operator = Operator.LessEqualThan,
                                     Value = EndDate
                                 });
            }

            if (SelectedHedgeTypeId > 0)
            {
                elements.Add(new QueryElement
                                 {
                                     FieldName = "ArbitrageType",
                                     Operator = Operator.Equal,
                                     Value = SelectedHedgeTypeId
                                 });
            }

            QueryManager.BuildQueryStrAndParams(elements, out _con, out _params);
        }

        public void Load()
        {
            using (var hgSvc = SvcClientManager.GetSvcClient<HedgeGroupServiceClient>(SvcType.HedgeGroupSvc))
            {
                if (string.IsNullOrWhiteSpace(_con)) _con = "1=1";
                Lines = hgSvc.SelectHedgeGroupPNLLine(_con, _params, From, To, null,CurrentUser.Id);
            }
        }

        #endregion
    }
}
