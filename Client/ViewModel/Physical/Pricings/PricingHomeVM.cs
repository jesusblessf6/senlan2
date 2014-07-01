using System.Collections.Generic;
using Client.Base.BaseClientVM;
using DBEntity.EnumEntity;
using Utility.Misc;

namespace Client.ViewModel.Physical.Pricings
{
    public class PricingHomeVM : BaseVM
    {
        #region Member

        private int _quotaId;
        private string _quotaNo;
        private int _bpId;
        private string _bpName;
        private List<EnumItem> _pricingSides;
        private int _selectedPricingSideId;
        private bool _containCurrentUser = true;

        #endregion

        #region Property

        public int QuotaId
        {
            get { return _quotaId; }
            set
            {
                if(_quotaId != value)
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
                if(_quotaNo != value)
                {
                    _quotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        public int BPId
        {
            get { return _bpId; }
            set
            {
                if(_bpId != value)
                {
                    _bpId = value;
                    Notify("BPId");
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

        public List<EnumItem> PricingSides
        {
            get { return _pricingSides; }
            set
            {
                _pricingSides = value;
                Notify("PricingSides");
            }
        }

        public int SelectedPricingSideId
        {
            get { return _selectedPricingSideId; }
            set
            {
                if(_selectedPricingSideId != value)
                {
                    _selectedPricingSideId = value;
                    Notify("SelectedPricingSideId");
                }
            }
        }

        public bool ContainCurrentUser
        {
            get { return _containCurrentUser; }
            set
            {
                if (_containCurrentUser != value)
                {
                    _containCurrentUser = value;
                    Notify("ContainCurrentUser");
                }
            }
        }
        #endregion

        #region Constructor

        public PricingHomeVM()
        {
            _quotaId = 0;
            _quotaNo = string.Empty;
            _bpId = 0;
            _bpName = string.Empty;

            _pricingSides = EnumHelper.GetEnumList<PricingSide>();
            _pricingSides.Insert(0, new EnumItem{Id = 0, Name = string.Empty});
            _selectedPricingSideId = 0;
        }

        #endregion

        #region Method

        public ManualPricingSearchConditions BuildConditions()
        {
            var c = new ManualPricingSearchConditions
                {
                    QuotaId = QuotaId,
                    QuotaNo = QuotaNo,
                    BusinessPartnerId = BPId,
                    PricingSideId = SelectedPricingSideId,
                    ContainCurrentUser = ContainCurrentUser
                };
            return c;
        }

        public void Clear()
        {
            QuotaId = 0;
            QuotaNo = string.Empty;
            BPId = 0;
            BPName = string.Empty;
            SelectedPricingSideId = 0;
        }

        #endregion
    }

    public class ManualPricingSearchConditions
    {
        public int PricingStatusId { get; set; }
        public int QuotaId { get; set; }
        public int BusinessPartnerId { get; set; }
        public int PricingSideId { get; set; }
        public bool ContainCurrentUser { get; set; }
        public string QuotaNo { get; set; }
    }
}
