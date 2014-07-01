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
    public class SalesDeliveryHomeVM : BaseVM
    {
        #region Member
        private List<Commodity> _Metals;
        private int _SelectedMetal;
        private int _BuyerId;
        private string _BuyerName;
        private DateTime? _StartDate;
        private DateTime? _EndDate;
        private PurchaseDeliverySearchVM _SearchVM;
        #endregion

        #region Property
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
        public int BuyerId
        {
            get { return _BuyerId; }
            set
            {
                if (_BuyerId != value)
                {
                    _BuyerId = value;
                    Notify("BuyerId");
                }
            }
        }

        public string BuyerName
        {
            get { return _BuyerName; }
            set
            {
                if (_BuyerName != value)
                {
                    _BuyerName = value;
                    Notify("BuyerName");
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

        //public PurchaseDeliverySearchVM SearchVM
        //{
        //    get { return _SearchVM; }
        //    set
        //    {
        //        if (_SearchVM != value)
        //        {
        //            _SearchVM = value;
        //            Notify("SearchVM");
        //        }
        //    }
        //}
        #endregion

        #region Constructor
        public SalesDeliveryHomeVM()
        {
            GetMetals();
        }
        #endregion

        #region Method
        public void loadSearch()
        {
            //SearchVM = new PurchaseDeliverySearchVM();
            //SearchVM.Title = "销售提单查询";
            //SearchVM.SelectedTradeType = SelectedTradeType;
            //SearchVM.SelectedMetal = SelectedMetal;
            //SearchVM.StartDate = StartDate;
            //SearchVM.EndDate = EndDate;
            //SearchVM.SupplierId = SupplierId;
            //SearchVM.Init();
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
