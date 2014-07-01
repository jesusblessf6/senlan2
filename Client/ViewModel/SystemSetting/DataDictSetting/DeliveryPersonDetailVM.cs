using System;
using Client.Base.BaseClientVM;
using Client.DeliveryPersonServiceReference;
using Client.View.Physical.WarehouseOuts;
using DBEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class DeliveryPersonDetailVM : ObjectBaseVM
    {
        #region Members & Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }

        private string _vehicleNo;
        public string VehicleNo
        {
            get { return _vehicleNo; }
            set
            {
                if (_vehicleNo != value)
                {
                    _vehicleNo = value;
                    Notify("VehicleNo");
                }
            }
        }

        private string _idNo;
        public string IdNo
        {
            get { return _idNo; }
            set
            {
                if (_idNo != value)
                {
                    _idNo = value;
                    Notify("IdNo");
                }
            }
        }

        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    Notify("Comments");
                }
            }
        }

        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set
            {
                if (_tel != value)
                {
                    _tel = value;
                    Notify("Tel");
                }
            }
        }

        #endregion

        #region Constructor

        public DeliveryPersonDetailVM()
        {
            Initialize();
        }

        public DeliveryPersonDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (var dpService = SvcClientManager.GetSvcClient<DeliveryPersonServiceClient>(SvcType.DeliveryPersonSvc))
                {
                    var dp = dpService.GetById(ObjectId);
                    _name = dp.Name;
                    _vehicleNo = dp.VehicleNo;
                    _idNo = dp.IdNo;
                    _comments = dp.Comments;
                    _tel = dp.Tel;
                }
            }
        }

        protected override void Create()
        {
            var dp = new DeliveryPerson
                         {
                             Name = Name.Trim(),
                             VehicleNo = VehicleNo,
                             IdNo = IdNo.Trim(),
                             Comments = Comments,
                             Tel = Tel
                         };
            using (var dpService = SvcClientManager.GetSvcClient<DeliveryPersonServiceClient>(SvcType.DeliveryPersonSvc))
            {
                dpService.CreateNew(dp, CurrentUser.Id);
            }
        }

        protected override void Update()
        {

            using (var dpService = SvcClientManager.GetSvcClient<DeliveryPersonServiceClient>(SvcType.DeliveryPersonSvc))
            {
                var dp = dpService.GetById(ObjectId);
                dp.Name = Name.Trim();
                dp.VehicleNo = VehicleNo;
                dp.IdNo = IdNo.Trim();
                dp.Comments = Comments;
                dp.Tel = Tel;

                dpService.UpdateExisted(dp, CurrentUser.Id);
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception("请输入名称！");
            }

            if(string.IsNullOrWhiteSpace(IdNo))
            {
                throw new Exception("请输入身份证号！");
            }

            if (!IdCardNoValidation.Validate(IdNo))
            {
                throw new Exception(ResWarehouseOut.IdNoWrong);
            }

            return true;
        }

        #endregion
    }
}
