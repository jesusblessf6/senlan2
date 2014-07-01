using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using DBEntity;
using Utility.ServiceManagement;
using Client.CommodityServiceReference;

namespace Client.ViewModel.SystemSetting.WarehouseSetting
{
    public class StorageFeeDetailVM : BaseVM
    {
        #region Member
        private int _CommodityID;
        private DateTime? _StartDate;
        private DateTime? _EndDate;
        private decimal? _PricePerUnit;//仓租单价
        private decimal? _TransferFee;//货权转移费
        private decimal? _WarrantFee;//仓单费
        private List<StorageFeeRule> _AddStorageFeeRules;
        private List<StorageFeeRule> _UpdateStorageFeeRules;
        private List<StorageFeeRule> _AllStorageFeeRules;
        private List<Commodity> _CommodityList;
        #endregion

        #region Property
        public List<StorageFeeRule> UpdateStorageFeeRules
        {
            get { return _UpdateStorageFeeRules; }
            set { 
                if(_UpdateStorageFeeRules != value)
                {
                    _UpdateStorageFeeRules = value;
                    Notify("UpdateStorageFeeRules");
                }
            }
        }

        public List<StorageFeeRule> AllStorageFeeRules
        {
            get { return _AllStorageFeeRules; }
            set { 
                if(_AllStorageFeeRules != value)
                {
                    _AllStorageFeeRules = value;
                    Notify("AllStorageFeeRules");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _CommodityList; }
            set { 
                if(_CommodityList != value)
                {
                    _CommodityList = value;
                    Notify("CommodityList");
                }
            }
        }

        public List<StorageFeeRule> AddStorageFeeRules
        {
            get { return _AddStorageFeeRules; }
            set { 
                if(_AddStorageFeeRules != value)
                {
                    _AddStorageFeeRules = value;
                    Notify("AddStorageFeeRules");
                }
            }
        }

        public decimal? TransFerFee
        {
            get { return _TransferFee; }
            set { 
                if(_TransferFee != value)
                {
                    _TransferFee = value;
                    Notify("TransFerFee");
                }            }
        }

        public decimal? WarrantFee
        {
            get { return _WarrantFee; }
            set{
                if(_WarrantFee != value)
                {
                    _WarrantFee = value;
                    Notify("WarrantFee");
                }
            }
        }

        public decimal? PricePerUnit
        {
            get { return _PricePerUnit; }
            set { 
                if(_PricePerUnit != value)
                {
                    _PricePerUnit = value;
                    Notify("PricePerUnit");
                }
            }
        }

        public DateTime? EndDate
        {
            get { return _EndDate; }
            set { 
                if(_EndDate != value)
                {
                    _EndDate = value;
                    Notify("EndDate");
                }
            }
        }

        public DateTime? StartDate
        {
            get { return _StartDate; }
            set { 
                if(_StartDate != value)
                {
                    _StartDate = value;
                    Notify("StartDate");
                }
            }
        }

        public int CommodityID
        {
            get { return _CommodityID; }
            set { 
                if(_CommodityID != value)
                {
                    _CommodityID = value;
                    Notify("CommodityID");
                }
            }
        }
        #endregion

        #region Contructor
        public StorageFeeDetailVM(List<StorageFeeRule> allStorageFeeRules, List<StorageFeeRule> addStorageFeeRules)
        {
            ObjectId = 0;
            AllStorageFeeRules = allStorageFeeRules;
            AddStorageFeeRules = addStorageFeeRules;
            Load();
        }

        public StorageFeeDetailVM(int id, List<StorageFeeRule> allStorageFeeRules, List<StorageFeeRule> addStorageFeeRules, List<StorageFeeRule> updateStorageFeeRules)
        {
            ObjectId = id;
            AllStorageFeeRules = allStorageFeeRules;
            AddStorageFeeRules = addStorageFeeRules;
            UpdateStorageFeeRules = updateStorageFeeRules;
            Load();
        }
        #endregion

        #region Method
        public void Load()
        {
            LoadCommodity();
            LoadStorageFeeRule();
        }

        public void LoadCommodity()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commodityService.GetCommoditiesByUser(CurrentUser.Id);
            }
            CommodityList.Insert(0, new Commodity { Id = 0, Name = "" });
        }
        #endregion

        public void LoadStorageFeeRule()
        { 
            if(ObjectId != 0)
            {
                List<StorageFeeRule> storageFeeRules = AllStorageFeeRules.Where(c => c.Id == ObjectId).ToList();
                if(storageFeeRules != null && storageFeeRules.Count > 0)
                {
                    StorageFeeRule storageFeeRule = storageFeeRules[0];
                    CommodityID = storageFeeRule.CommodityId;
                    StartDate = storageFeeRule.StartDate;
                    EndDate = storageFeeRule.EndDate;
                    PricePerUnit = storageFeeRule.PricePerUnit;
                    WarrantFee = storageFeeRule.WarrantFee;
                    TransFerFee = storageFeeRule.TransferFee;
                }
            }
        }

        protected override void Create()
        {
            var storageFeeRule = new StorageFeeRule();
            if (AllStorageFeeRules.Count <= 0)
            {
                storageFeeRule.Id = -1;
            }
            else
            {
                var idList = AllStorageFeeRules.Select(o => Math.Abs(o.Id)).ToList();
                int maxID = idList.Max();
                storageFeeRule.Id = -(maxID + 1);
            }

            storageFeeRule.StartDate = StartDate.Value;
            storageFeeRule.EndDate = EndDate.Value;
            storageFeeRule.CommodityId = CommodityID;
            storageFeeRule.PricePerUnit = (PricePerUnit == null ? PricePerUnit : Math.Round(PricePerUnit.Value, DBEntity.EnumEntity.RoundRules.PRICE, MidpointRounding.AwayFromZero));
            storageFeeRule.WarrantFee = (WarrantFee == null ? WarrantFee : Math.Round(WarrantFee.Value, DBEntity.EnumEntity.RoundRules.AMOUNT, MidpointRounding.AwayFromZero));
            storageFeeRule.TransferFee = (TransFerFee == null ? TransFerFee : Math.Round(TransFerFee.Value, DBEntity.EnumEntity.RoundRules.AMOUNT, MidpointRounding.AwayFromZero));
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Commodity commodity = commodityService.GetById(CommodityID);
                storageFeeRule.Commodity = commodity;
            }

            AddStorageFeeRules.Add(storageFeeRule);
            AllStorageFeeRules.Add(storageFeeRule);
        }

        protected override void Update()
        {
            var newStorageFeeRule = new StorageFeeRule();
            List<StorageFeeRule> storageFeeRules = AllStorageFeeRules.Where(c => c.Id == ObjectId).ToList();
            if (storageFeeRules != null && storageFeeRules.Count > 0)
            {
                StorageFeeRule storageFeeRule = storageFeeRules[0];
                newStorageFeeRule.Id = storageFeeRule.Id;
                newStorageFeeRule.WarehouseId = storageFeeRule.WarehouseId;
                newStorageFeeRule.StartDate = StartDate.Value;
                newStorageFeeRule.EndDate = EndDate.Value;
                newStorageFeeRule.PricePerUnit = (PricePerUnit == null ? PricePerUnit : Math.Round(PricePerUnit.Value, DBEntity.EnumEntity.RoundRules.PRICE, MidpointRounding.AwayFromZero));
                newStorageFeeRule.WarrantFee = (WarrantFee == null ? WarrantFee : Math.Round(WarrantFee.Value, DBEntity.EnumEntity.RoundRules.AMOUNT, MidpointRounding.AwayFromZero));
                newStorageFeeRule.TransferFee = (TransFerFee == null ? TransFerFee : Math.Round(TransFerFee.Value, DBEntity.EnumEntity.RoundRules.AMOUNT, MidpointRounding.AwayFromZero));
                newStorageFeeRule.CommodityId = CommodityID;
                using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
                {
                    Commodity commodity = commodityService.GetById(CommodityID);
                    newStorageFeeRule.Commodity = commodity;
                }

                AllStorageFeeRules.Remove(storageFeeRule);
                AllStorageFeeRules.Add(newStorageFeeRule);

                if (storageFeeRule.Id < 0)
                {
                    if (AddStorageFeeRules.Count > 0)
                    {
                        List<StorageFeeRule> addStorageFeeRules = AddStorageFeeRules.Where(c => c.Id == storageFeeRule.Id).ToList();
                        if (addStorageFeeRules != null && addStorageFeeRules.Count > 0)
                        {
                            AddStorageFeeRules.Remove(storageFeeRule);
                            AddStorageFeeRules.Add(newStorageFeeRule);
                        }
                    }
                }
                else
                { 
                    if(UpdateStorageFeeRules.Count > 0)
                    {
                        List<StorageFeeRule> updateStorageFeeRules = UpdateStorageFeeRules.Where(c => c.Id == storageFeeRule.Id).ToList();
                        if(updateStorageFeeRules.Count > 0)
                        {
                            StorageFeeRule updateStorageFeeRule = updateStorageFeeRules[0];
                            UpdateStorageFeeRules.Remove(updateStorageFeeRule);
                        }
                    }
                    UpdateStorageFeeRules.Add(newStorageFeeRule);
                }
            }
        }

        public override bool Validate()
        {
            if(!StartDate.HasValue)
            {
                throw new Exception("起始日期不能为空");
            }

            if(!EndDate.HasValue)
            {
                throw new Exception("结束日期不能为空");
            }

            if(StartDate > EndDate)
            {
                throw new Exception("开始日期不能大于结束日期");
            }

            if(CommodityID == 0)
            {
                throw new Exception("金属不能为空");
            }

            List<StorageFeeRule> list =
                AllStorageFeeRules.Where(
                    c =>
                    ((c.StartDate >= StartDate && c.EndDate <= EndDate) ||
                    (c.StartDate <= StartDate && c.EndDate >= EndDate) ||
                    (c.StartDate <= StartDate && c.EndDate >= StartDate) || (c.StartDate <= EndDate && c.EndDate >= EndDate)) && c.CommodityId == CommodityID)
                    .ToList();

            if (list.Count > 0)
            {                

                if (list.Select(c => c.Id).Contains(ObjectId))
                {
                    if (list.Count > 1)
                    {
                        throw new Exception("仓储费规则日期不能重复");
                    }
                }
                else
                {
                    throw new Exception("仓储费规则日期不能重复");
                }

                //if (ObjectId == 0)
                //{
                //    throw new Exception("仓储费规则日期不能重复");
                //}
            }

            return true;
        }
    }
}
