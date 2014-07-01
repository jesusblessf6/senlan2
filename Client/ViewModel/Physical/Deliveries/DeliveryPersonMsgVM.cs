using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using DBEntity;
using Client.View.Physical.WarehouseOuts;
using System.Globalization;

namespace Client.ViewModel.Physical.Deliveries
{
    public class DeliveryPersonMsgVM : BaseVM
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

        #region Contructor
        public DeliveryPersonMsgVM(List<WarehouseOutDeliveryPerson> list, List<WarehouseOutDeliveryPerson> addList)
        {
            ObjectId = 0;
            AddDeliveryPersonList = addList;
            AllDeliveryPersonList = list;
        }

        public DeliveryPersonMsgVM(int deliverypersonID, List<WarehouseOutDeliveryPerson> list,
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

        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <returns></returns>
        public bool CheckIDCard(string id)
        {
            if (id.Length == 18)
            {
                bool check = CheckIDCard18(id);
                return check;
            }

            if (id.Length == 15)
            {
                bool check = CheckIDCard15(id);
                return check;
            }

            return false;
        }

        /// <summary>
        /// 18位身份证验证
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <returns></returns>
        private bool CheckIDCard18(string id)
        {
            long n;
            if (long.TryParse(id.Remove(17), out n) == false || n < Math.Pow(10, 16) ||
                long.TryParse(id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false; //数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false; //省份验证
            }
            string birth = id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] ai = id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString(CultureInfo.InvariantCulture));
            }
            int y;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != id.Substring(17, 1).ToLower())
            {
                return false; //校验码验证
            }
            return true; //符合GB11643-1999标准
        }

        /// <summary>
        /// 15位身份证验证
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <returns></returns>
        private bool CheckIDCard15(string id)
        {
            long n;
            if (long.TryParse(id, out n) == false || n < Math.Pow(10, 14))
            {
                return false; //数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false; //省份验证
            }
            string birth = id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            return true; //符合15位身份证标准
        }

        public override bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception("提货人不能为空");
            }

            if (!string.IsNullOrEmpty(IdentityCard))
            {
                if (!CheckIDCard(IdentityCard))
                {
                    throw new Exception(ResWarehouseOut.IdNoWrong);
                }
            }

            return true;
        }
        #endregion
    }
}
