using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using DBEntity;

namespace Client.ViewModel.Physical.CommercialInvoices
{
    public class LCDistributionVM : BaseVM
    {
        #region Member
        private decimal? amount;
        private decimal? allowAmount;
        private bool saveStatus = false;
        decimal distributionAmount = 0;
        #endregion

        #region Property
        public List<LCCIRel> AddRels { get; set; }
        public List<LCCIRel> DeleteRels { get; set; }

        public LetterOfCredit SelectLc { get; set; }

        public List<LetterOfCredit> DisplayLc { get; set; }

        public decimal? Amount
        {
            get { return amount; }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    Notify("Amount");
                }
            }
        }

        public decimal? AllowAmount
        {
            get { return allowAmount; }
            set
            {
                if (allowAmount != value)
                {
                    allowAmount = value;
                    Notify("AllowAmount");
                }
            }
        }

        public bool SaveStatus
        {
            get { return saveStatus; }
            set
            {
                if (saveStatus != value)
                {
                    saveStatus = value;
                    Notify("SaveStatus");
                }
            }
        }

        #endregion

        #region Construct
        public LCDistributionVM(LetterOfCredit selectLc, List<LCCIRel> addRels, List<LCCIRel> deleteRels)
        {
            SelectLc = selectLc;
            AddRels = addRels;
            DeleteRels = deleteRels;
            CalcAmount();
            DisplayLc = new List<LetterOfCredit>();
            LetterOfCredit displayLc = new LetterOfCredit() { Id = selectLc.Id, LCNo = selectLc.LCNo, PresentAmount = selectLc.PresentAmount, DistriButionAmount = distributionAmount, Currency = selectLc.Currency };
            DisplayLc.Add(displayLc);
        }
        #endregion

        #region Method
        private void CalcAmount()
        {
            distributionAmount = SelectLc.DistriButionAmount ?? 0;
            if (AddRels != null && AddRels.Count > 0)
            {
                List<LCCIRel> temp = AddRels.Where(o => o.LCId == SelectLc.Id).ToList();
                if (temp != null && temp.Count > 0)
                {
                    distributionAmount += temp.Sum(o => o.AllocationAmount ?? 0);
                }
            }

            if (DeleteRels != null && DeleteRels.Count > 0)
            {
                List<LCCIRel> temp = DeleteRels.Where(o => o.LCId == SelectLc.Id).ToList();
                if (temp != null && temp.Count > 0)
                {
                    distributionAmount -= temp.Sum(o => o.AllocationAmount ?? 0);
                    SelectLc.DistriButionAmount = distributionAmount;
                }
            }

            AllowAmount = SelectLc.PresentAmount - distributionAmount;
            Amount = AllowAmount;
        }
        #endregion
    }
}
