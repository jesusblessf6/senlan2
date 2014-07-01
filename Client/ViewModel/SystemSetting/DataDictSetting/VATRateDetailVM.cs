using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.VATRateServiceReference;
using Client.View.SystemSetting.DataDictSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class VATRateDetailVM : BaseVM
    {
        #region Member

        private string _code;
        private string _description;
        private decimal? _rateValue;
        private int _type;
        private List<EnumItem> _vatTypes;

        #endregion

        #region Property

        public List<EnumItem> VATTypes
        {
            get { return _vatTypes; }
            set
            {
                _vatTypes = value;
                Notify("VATTypes");
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    Notify("Code");
                }
            }
        }

        public int Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    Notify("Type");
                }
            }
        }

        public decimal? RateValue
        {
            get { return _rateValue; }
            set
            {
                if (_rateValue != value)
                {
                    _rateValue = value;
                    Notify("RateValue");
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Notify("Description");
                }
            }
        }

        #endregion

        #region Constructor

        public VATRateDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public VATRateDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            _vatTypes = EnumHelper.GetEnumList<VATType>();
            _vatTypes.Insert(0, new EnumItem {Id = 0, Name = string.Empty});

            if (ObjectId > 0)
            {
                using (var vatrateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
                {
                    VATRate vatrate = vatrateService.GetById(ObjectId);

                    if (vatrate != null)
                    {
                        _code = vatrate.Code;
                        _type = vatrate.Type;
                        _rateValue = (vatrate.RateValue*100);
                        _description = vatrate.Description;
                    }
                }
            }
        }

        protected override void Create()
        {
            var vatrate = new VATRate
                              {
                                  Code = Code,
                                  Type = Type,
                                  RateValue = (RateValue/100),
                                  Description = Description,
                              };

            using (var vatrateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                vatrateService.AddNewVATRate(vatrate, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (var vatrateService = SvcClientManager.GetSvcClient<VATRateServiceClient>(SvcType.VATRateSvc))
            {
                VATRate vatrate = vatrateService.GetById(ObjectId);
                if (vatrate != null)
                {
                    vatrate.Code = Code;
                    vatrate.Type = Type;
                    vatrate.RateValue = (RateValue/100);
                    vatrate.Description = Description;

                    vatrateService.UpdateVATRate(vatrate, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResDataDictSetting.VATNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Code))
            {
                throw new Exception(ResDataDictSetting.TaxCodeRequired);
            }

            if (Equals(Type, 0))
            {
                throw new Exception(ResDataDictSetting.VATTypeRequired);
            }

            return true;
        }

        #endregion
    }
}