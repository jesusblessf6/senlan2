using System;
using Client.Base.BaseClientVM;
using System.Collections.Generic;
using Utility.Misc;
using DBEntity.EnumEntity;

namespace Client.ViewModel.Finance.LetterOfCredits
{
    public class LetterOfCreditHomeVM : BaseVM
    {
        #region Member

        private int _applicantId;
        private string _applicantName;
        private int _beneficiaryId;
        private string _beneficiaryName;
        private DateTime? _end2Date;
        private DateTime? _endDate;
        private LetterOfCreditListVM _listVM;
        private DateTime? _start2Date;
        private DateTime? _startDate;
        private LetterOfCreditHomeVM _vm;
        //private Dictionary<string, int> _lcPorS;
        private List<EnumItem> _lcPorS;
        private int _selectedLCPorS;
        private bool _containCurrentUser = true;
        private string _QuotaNo;

        #endregion

        #region Property
        public string QuotaNo
        {
            get { return _QuotaNo; }
            set { 
                if(_QuotaNo != value)
                {
                    _QuotaNo = value;
                    Notify("QuotaNo");
                }
            }
        }

        public int SelectedLCPorS
        {
            get { return _selectedLCPorS; }
            set { 
                if(_selectedLCPorS != value)
                {
                    _selectedLCPorS = value;
                    Notify("SelectedLCPorS");
                }
            }
        }

        public List<EnumItem> LCPorS
        {
            get { return _lcPorS; }
            set {
                if (_lcPorS != value)
                {
                    _lcPorS = value;
                    Notify("LCPorS");
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

        public DateTime? End2Date
        {
            get { return _end2Date; }
            set
            {
                if (_end2Date != value)
                {
                    _end2Date = value;
                    Notify("End2Date");
                }
            }
        }

        public DateTime? Start2Date
        {
            get { return _start2Date; }
            set
            {
                if (_start2Date != value)
                {
                    _start2Date = value;
                    Notify("Start2Date");
                }
            }
        }

        public int ApplicantId
        {
            get { return _applicantId; }
            set
            {
                if (_applicantId != value)
                {
                    _applicantId = value;
                    Notify("ApplicantId");
                }
            }
        }

        public string ApplicantName
        {
            get { return _applicantName; }
            set
            {
                if (_applicantName != value)
                {
                    _applicantName = value;
                    Notify("ApplicantName");
                }
            }
        }

        public int BeneficiaryId
        {
            get { return _beneficiaryId; }
            set
            {
                if (_beneficiaryId != value)
                {
                    _beneficiaryId = value;
                    Notify("BeneficiaryId");
                }
            }
        }

        public string BeneficiaryName
        {
            get { return _beneficiaryName; }
            set
            {
                if (_beneficiaryName != value)
                {
                    _beneficiaryName = value;
                    Notify("BeneficiaryName");
                }
            }
        }

        public LetterOfCreditHomeVM VM
        {
            get { return _vm; }
            set
            {
                if (_vm != value)
                {
                    _vm = value;
                    Notify("VM");
                }
            }
        }

        public LetterOfCreditListVM ListVM
        {
            get { return _listVM; }
            set
            {
                if (_listVM != value)
                {
                    _listVM = value;
                    Notify("ListVM");
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

        public LetterOfCreditHomeVM()
        {
            ObjectId = 0;
            Initialize();
            LoadLCPorS();
        }

        #endregion

        public void Initialize()
        {
        }

        public void LoadLCPorS()
        {
            LCPorS = EnumHelper.GetEnumList<LCPorS>();
            LCPorS.Insert(0, new EnumItem {Id = 0, Name = string.Empty});
        }

        public void Load()
        {
            ListVM = new LetterOfCreditListVM
                         {
                             ApplicantId = ApplicantId,
                             BeneficiaryId = BeneficiaryId,
                             StartDate = StartDate,
                             EndDate = EndDate,
                             LCPorS = SelectedLCPorS,
                             QuotaNo = QuotaNo,
                             ContainCurrentUser = ContainCurrentUser
                             //Start2Date = Start2Date,
                             //End2Date = End2Date
                         };
            ListVM.Init();
        }

        public void LoadByDate()
        {
            DateTime dt = DateTime.Now;
            DateTime startDate = dt.AddDays(- dt.Day);
            DateTime endDate = startDate.AddMonths(1);
            ListVM = new LetterOfCreditListVM { StartDate = startDate, EndDate = endDate, Start2Date = startDate, End2Date = endDate, ContainCurrentUser = ContainCurrentUser };
            ListVM.Init();
        }

        /// <summary>
        /// Clear the search conditions
        /// </summary>
        public void Reset()
        {
            StartDate = null;
            Start2Date=null;
            EndDate = null;
            End2Date=null;
            ApplicantId=0;
            ApplicantName="";
            BeneficiaryId=0;
            BeneficiaryName="";
            SelectedLCPorS = 0;
            QuotaNo = null;
            ContainCurrentUser = true;
        }
    }
}