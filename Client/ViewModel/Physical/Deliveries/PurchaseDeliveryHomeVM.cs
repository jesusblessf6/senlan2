using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.CommodityServiceReference;
using DBEntity;

namespace Client.ViewModel.Physical.Deliveries
{
    public class PurchaseDeliveryHomeVM : BaseVM
    {
        #region Member
        private Dictionary<string, int> _TradeTypes;
        private int _SelectedTradeType;
        private List<Commodity> _Metals;
        private int _SelectedMetal;
        private int _SupplierId;
        private string _SupplierName;
        private DateTime? _StartDate;
        private DateTime? _EndDate;
        private PurchaseDeliverySearchVM _SearchVM;
        #endregion

        #region Property
        public Dictionary<string, int> TradeTypes
        {
            get { return _TradeTypes; }
            set
            {
                if (_TradeTypes != value)
                {
                    _TradeTypes = value;
                    Notify("TradeTypes");
                }
            }
        }

        public int SelectedTradeType
        {
            get { return _SelectedTradeType; }
            set
            {
                if (_SelectedTradeType != value)
                {
                    _SelectedTradeType = value;
                    Notify("SelectedTradeType");
                }
            }
        }

        public List<Commodity> Metals
        {
            get { return _Metals; }
            set
            {
                if (_Metals != value)
                {
                    _Metals = value;
                    Notify("Metals");
                }
            }
        }        

        public int SelectedMetal
        {
            get { return _SelectedMetal; }
            set
            {
                if (_SelectedMetal != value)
                {
                    _SelectedMetal = value;
                    Notify("SelectedMetal");
                }
            }
        }

        /// <summary>`
        /// 供应商ID
        /// </summary>
        public int SupplierId
        {
            get { return _SupplierId; }
            set
            {
                if (_SupplierId != value)
                {
                    _SupplierId = value;
                    Notify("SupplierId");
                }
            }
        }

        public string SupplierName
        {
            get { return _SupplierName; }
            set
            {
                if (_SupplierName != value)
                {
                    _SupplierName = value;
                    Notify("SupplierName");
                }
            }
        }


        public DateTime? StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                if (_StartDate != value)
                {
                    _StartDate = value;
                    Notify("StartDate");
                }
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                if (_EndDate != value)
                {
                    _EndDate = value;
                    Notify("EndDate");
                }
            }
        }

        public PurchaseDeliverySearchVM SearchVM
        {
            get { return _SearchVM; }
            set
            {
                if (_SearchVM != value)
                {
                    _SearchVM = value;
                    Notify("SearchVM");
                }
            }
        }
        #endregion

        #region Constructor
        public PurchaseDeliveryHomeVM()
        {
            StartDate = DateTime.Now.Date.AddMonths(-1);
            EndDate = DateTime.Now.Date;
            GetTradeTypes();
            GetMetals();
        }
        #endregion

        #region Method
        public void loadSearch()
        {
            SearchVM = new PurchaseDeliverySearchVM();
            SearchVM.Title = "采购提单查询";
            SearchVM.SelectedTradeType = SelectedTradeType;
            SearchVM.SelectedMetal = SelectedMetal;
            SearchVM.StartDate = StartDate;
            SearchVM.EndDate = EndDate;
            SearchVM.SupplierId = SupplierId;
            SearchVM.Init();
        }

        public void GetTradeTypes()
        {
            TradeTypes = new Dictionary<string, int> { { "", 0 } };
            TradeTypes = EnumHelper.GetEnumDic<TradeType>(TradeTypes);
        }

        public void GetMetals()
        {
            using (var metalService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Metals = metalService.GetAll();
                Metals.Insert(0, new Commodity() { Id = 0, Name = ""});
            }
        }
        #endregion
    }
}
