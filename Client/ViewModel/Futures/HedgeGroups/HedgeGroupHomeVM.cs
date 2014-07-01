using System;
using Client.Base.BaseClientVM;

namespace Client.ViewModel.Futures.HedgeGroups
{
    public class HedgeGroupHomeVM : BaseVM
    {
        #region Member

        private DateTime? _startDate;
        private DateTime? _endDate;
        private string _hedgeName;

        #endregion

        #region Property

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if(_startDate != value)
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
                if(_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        public string HedgeName
        {
            get { return _hedgeName; }
            set
            {
                if (_hedgeName != value)
                {
                    _hedgeName = value;
                    Notify("HedgeName");
                }
            }
        }

        #endregion

        #region Constructor

        public HedgeGroupHomeVM()
        {
            _startDate = null;
            _endDate = null;
            _hedgeName = null;
        }

        #endregion

        #region Method

        public void Reset()
        {
            EndDate = null;
            StartDate = null;
            HedgeName = null;
        }

        public HedgeGroupConditions GetConditions(HedgeGroupSearchType type)
        {
            var c = new HedgeGroupConditions();

            if(type == HedgeGroupSearchType.Free)
            {
                c.StartDate = StartDate;
                c.EndDate = EndDate;
                c.HedgeNme = HedgeName;
            }
            
            if(type == HedgeGroupSearchType.CurrentMonth)
            {
                var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                c.StartDate = startDate;
                c.EndDate = endDate;
            }

            if(type == HedgeGroupSearchType.LastMonth)
            {
                var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                c.StartDate = startDate;
                c.EndDate = endDate;
            }

            if(type == HedgeGroupSearchType.CurrentYear)
            {
                var startDate = new DateTime(DateTime.Today.Year, 1, 1);
                var endDate = startDate.AddYears(1).AddDays(-1);
                c.StartDate = startDate;
                c.EndDate = endDate;
            }

            if(type == HedgeGroupSearchType.LastYear)
            {
                var startDate = new DateTime(DateTime.Today.Year - 1, 1, 1);
                var endDate = startDate.AddYears(1).AddDays(-1);
                c.StartDate = startDate;
                c.EndDate = endDate;
            }

            return c;
        }

        #endregion
    }
}
