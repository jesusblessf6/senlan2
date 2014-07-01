using System;
using Client.Base.BaseClientVM;

namespace Client.ViewModel.Console.MonitorCenter
{
    public class PricingMonitorLineVM : BaseVM
    {
        #region Member

        private string _quotaNo;
        private string _bpName;
        private decimal _quotaQuantity;
        private decimal _unpricedQuantity;
        private int _pricingTypeId;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private string _internalCustomerName;
        private int _daysRemain;

        #endregion

        #region Property

        public string QuotaNo
        {
            get { return _quotaNo; }
            set
            {
                if(_quotaNo != value)
                {
                    _quotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        public string BPName
        {
            get { return _bpName; }
            set
            {
                if(_bpName != value)
                {
                    _bpName = value;
                    Notify("BPName");
                }
            }
        }

        public decimal QuotaQuantity
        {
            get { return _quotaQuantity; }
            set
            {
                if (_quotaQuantity != value)
                {
                    _quotaQuantity = value;
                    Notify("QuotaQuantity");
                }
            }
        }

        public decimal UnpricedQuantity
        {
            get { return _unpricedQuantity; }
            set
            {
                if(_unpricedQuantity != value)
                {
                    _unpricedQuantity = value;
                    Notify("UnpricedQuantity");
                }
            }
        }

        public int PricingTypeId
        {
            get { return _pricingTypeId; }
            set
            {
                if (_pricingTypeId != value)
                {
                    _pricingTypeId = value;
                    Notify("PricingTypeId");
                }
            }
        }

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

        public string InternalCustomerName
        {
            get { return _internalCustomerName; }
            set
            {
                if(_internalCustomerName != value)
                {
                    _internalCustomerName = value;
                    Notify("InternalCustomerName");
                }
            }
        }

        public int DaysRemain
        {
            get { return _daysRemain; }
            set
            {
                if(_daysRemain != value)
                {
                    _daysRemain = value;
                    Notify("DaysRemain");
                }
            }
        }

        #endregion

        #region Constructor

        public PricingMonitorLineVM()
        {
            _quotaNo = string.Empty;
            _bpName = string.Empty;
            _quotaQuantity = 0;
            _unpricedQuantity = 0;
            _pricingTypeId = 0;
            _startDate = null;
            _endDate = null;
            _internalCustomerName = string.Empty;
            _daysRemain = 0;
        }

        #endregion
    }
}
