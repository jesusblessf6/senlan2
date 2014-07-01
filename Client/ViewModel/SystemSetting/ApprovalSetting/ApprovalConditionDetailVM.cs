using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.CurrencyServiceReference;
using Client.View.SystemSetting.ApprovalSetting;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.ApprovalSetting
{
    public class ApprovalConditionDetailVM : BaseVM
    {
        #region Member

        private List<Currency> _currencies;
        private Currency _currency;
        private int _currencyId;
        private decimal? _lowerLimit;
        private decimal? _upperLimit;

        #endregion

        #region Property

        public List<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                Notify("Currencies");
            }
        }

        public int CurrencyId
        {
            get { return _currencyId; }
            set
            {
                if (_currencyId != value)
                {
                    _currencyId = value;
                    Notify("CurrencyId");
                }
            }
        }

        public decimal? UpperLimit
        {
            get { return _upperLimit; }
            set
            {
                if (_upperLimit != value)
                {
                    _upperLimit = value;
                    Notify("UpperLimit");
                }
            }
        }

        public decimal? LowerLimit
        {
            get { return _lowerLimit; }
            set
            {
                if (_lowerLimit != value)
                {
                    _lowerLimit = value;
                    Notify("LowerLimit");
                }
            }
        }

        public ApprovalCondition NewCondition { get; set; }

        public List<ApprovalCondition> Conditions { get; set; }

        public Currency Currency
        {
            get { return _currency; }
            set
            {
                if (_currency != value)
                {
                    _currency = value;
                    Notify("Currency");
                }
            }
        }

        #endregion

        #region Constructor

        public ApprovalConditionDetailVM(List<ApprovalCondition> conditions)
        {
            Initialize();
            Conditions = conditions;
        }

        #endregion

        #region Method

        public void Initialize()
        {
            Currencies = new List<Currency>();
            using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
            {
                Currencies = currencyService.GetAll();
            }
            Currencies.Insert(0, new Currency {Id = 0, Name = ""});
            CurrencyId = 0;

            UpperLimit = null;
            LowerLimit = null;
        }

        public override void Save()
        {
            if (Currency == null || Currency.Id == 0)
            {
                throw new Exception(Properties.Resources.CurrencyNotNull);
            }

            if (UpperLimit <= LowerLimit)
            {
                throw new Exception(ResApprovalSetting.RangeError);
            }

            if (UpperLimit == null)
            {
                UpperLimit = 999999999999;
            }

            if (LowerLimit == null)
            {
                LowerLimit = decimal.Zero;
            }

            if (Conditions == null)
            {
                Conditions = new List<ApprovalCondition>();
            }

            if (Conditions.Any(o => o.Currency.Id == Currency.Id))
            {
                throw new Exception(ResApprovalSetting.CurrencyError);
            }

            var condition = new ApprovalCondition
                                {Currency = Currency, UpperLimit = UpperLimit, LowerLimit = LowerLimit};
            if (Conditions == null || Conditions.Count == 0)
            {
                condition.Id = 0;
            }
            else
            {
                condition.Id = -(Conditions.Max(o => o.Id) + 1);
            }

            Conditions.Add(condition);
        }

        #endregion
    }
}