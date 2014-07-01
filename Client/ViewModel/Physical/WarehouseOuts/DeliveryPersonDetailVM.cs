using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.View.Physical.WarehouseOuts;
using DBEntity;
using Utility.Misc;

namespace Client.ViewModel.Physical.WarehouseOuts
{
    public class DeliveryPersonDetailVM : BaseVM
    {
        #region Member

        private List<WarehouseOutDeliveryPerson> _addDeliveryPersonList;
        private List<WarehouseOutDeliveryPerson> _allDeliveryPersonList;
        private decimal _deliveryQuantity;
        private string _identityCard;
        private string _name;
        private List<WarehouseOutDeliveryPerson> _updateDeliveryPersonList;
        private string _vehicleNo;
        private string _tel;

        #endregion

        #region Property

        public List<WarehouseOutDeliveryPerson> AllDeliveryPersonList
        {
            get { return _allDeliveryPersonList; }
            set
            {
                if (_allDeliveryPersonList != value)
                {
                    _allDeliveryPersonList = value;
                    Notify("AllDeliveryPersonList");
                }
            }
        }

        public List<WarehouseOutDeliveryPerson> UpdateDeliveryPersonList
        {
            get { return _updateDeliveryPersonList; }
            set
            {
                if (_updateDeliveryPersonList != value)
                {
                    _updateDeliveryPersonList = value;
                    Notify("UpdateDeliveryPersonList");
                }
            }
        }

        public List<WarehouseOutDeliveryPerson> AddDeliveryPersonList
        {
            get { return _addDeliveryPersonList; }
            set
            {
                if (_addDeliveryPersonList != value)
                {
                    _addDeliveryPersonList = value;
                    Notify("AddDeliveryPersonList");
                }
            }
        }

        public decimal DeliveryQuantity
        {
            get { return _deliveryQuantity; }
            set
            {
                if (_deliveryQuantity != value)
                {
                    _deliveryQuantity = value;
                    Notify("DeliveryQuantity");
                }
            }
        }

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

        public string IdentityCard
        {
            get { return _identityCard; }
            set
            {
                if (_identityCard != value)
                {
                    _identityCard = value;
                    Notify("IdentityCard");
                }
            }
        }

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

        public DeliveryPersonDetailVM(List<WarehouseOutDeliveryPerson> list, List<WarehouseOutDeliveryPerson> addList)
        {
            ObjectId = 0;
            AddDeliveryPersonList = addList;
            AllDeliveryPersonList = list;
        }

        public DeliveryPersonDetailVM(int deliverypersonID, List<WarehouseOutDeliveryPerson> list,
                                      List<WarehouseOutDeliveryPerson> addList,
                                      List<WarehouseOutDeliveryPerson> updateList)
        {
            ObjectId = deliverypersonID;
            AllDeliveryPersonList = list;
            AddDeliveryPersonList = addList;
            UpdateDeliveryPersonList = updateList;
            LoadDeliveryPersonDetail();
        }

        #endregion

        #region Method

        public void LoadDeliveryPersonDetail()
        {
            if (ObjectId != 0)
            {
                List<WarehouseOutDeliveryPerson> list = AllDeliveryPersonList.Where(c => c.Id == ObjectId).ToList();
                if (list.Count > 0)
                {
                    WarehouseOutDeliveryPerson deliveryPerson = list[0];
                    Name = deliveryPerson.Name;
                    IdentityCard = deliveryPerson.IdentityCard;
                    VehicleNo = deliveryPerson.VehicleNo;
                    DeliveryQuantity = deliveryPerson.DeliveryQuantity == null
                                           ? 0
                                           : Convert.ToDecimal(deliveryPerson.DeliveryQuantity);
                    Tel = deliveryPerson.Tel;
                }
            }
        }

        protected override void Create()
        {
            var deliveryPerson = new WarehouseOutDeliveryPerson();

            if (AllDeliveryPersonList.Count <= 0)
            {
                deliveryPerson.Id = -1;
            }
            else
            {
                var lineIdList = AllDeliveryPersonList.Select(lineId => Math.Abs(lineId.Id)).ToList();
                int maxID = lineIdList.Max();
                deliveryPerson.Id = -(maxID + 1);
            }

            deliveryPerson.Name = Name;
            deliveryPerson.IdentityCard = IdentityCard;
            deliveryPerson.VehicleNo = VehicleNo;
            deliveryPerson.DeliveryQuantity = DeliveryQuantity;
            deliveryPerson.Tel = Tel;

            AddDeliveryPersonList.Add(deliveryPerson);
            AllDeliveryPersonList.Add(deliveryPerson);
        }

        protected override void Update()
        {
            var deliveryPerson = new WarehouseOutDeliveryPerson();
            List<WarehouseOutDeliveryPerson> deliveryPersonList =
                AllDeliveryPersonList.Where(c => c.Id == ObjectId).ToList();
            if (deliveryPersonList.Count > 0)
            {
                WarehouseOutDeliveryPerson deliveryPersonOld = deliveryPersonList[0];
                deliveryPerson.Id = deliveryPersonOld.Id;
                deliveryPerson.WarehouseOutLineId = deliveryPersonOld.WarehouseOutLineId;
                deliveryPerson.Name = Name;
                deliveryPerson.IdentityCard = IdentityCard;
                deliveryPerson.VehicleNo = VehicleNo;
                deliveryPerson.DeliveryQuantity = DeliveryQuantity;
                deliveryPerson.Tel = Tel;

                AllDeliveryPersonList.Remove(deliveryPersonOld);
                AllDeliveryPersonList.Add(deliveryPerson);

                if (deliveryPersonOld.Id < 0)
                {
                    if (AddDeliveryPersonList.Count > 0)
                    {
                        List<WarehouseOutDeliveryPerson> deliveryPersons =
                            AddDeliveryPersonList.Where(c => c.Id == deliveryPersonOld.Id).ToList();

                        if (deliveryPersons.Count > 0)
                        {
                            WarehouseOutDeliveryPerson addDeliveryPerson = deliveryPersons[0];
                            AddDeliveryPersonList.Remove(addDeliveryPerson);
                            AddDeliveryPersonList.Add(deliveryPerson);
                        }
                    }
                }
                else
                {
                    if (UpdateDeliveryPersonList.Count > 0)
                    {
                        List<WarehouseOutDeliveryPerson> updateDeliveryPersons =
                            UpdateDeliveryPersonList.Where(c => c.Id == deliveryPersonOld.Id).ToList();
                        if (updateDeliveryPersons.Count > 0)
                        {
                            WarehouseOutDeliveryPerson updateDeliveryPerson = updateDeliveryPersons[0];

                            UpdateDeliveryPersonList.Remove(updateDeliveryPerson);
                            UpdateDeliveryPersonList.Add(deliveryPerson);
                        }
                    }
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception("提货人不能为空");
            }

            if(!string.IsNullOrEmpty(IdentityCard))
            {
                if (!IdCardNoValidation.Validate(IdentityCard))
                {
                    throw new Exception(ResWarehouseOut.IdNoWrong);
                }
            }

            return true;
        }

        #endregion
    }
}