using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using Client.ForeignDeliveryPoolServiceReference;
using Utility.ServiceManagement;
using DBEntity;

namespace Client.ViewModel.Reports
{
     public class FDPStorageFeeDetailVM : BaseVM
     {
         #region Member
         private List<FDPStorageFeeDetailReport> _StorageFeeList;
         private string _DeliveryNo;
         private int _WarehouseId;
         private string _WarehouseName;
         private DateTime? _StartDate;
         private DateTime? _EndDate;
         #endregion

         #region Property
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

         public string WarehouseName
         {
             get { return _WarehouseName; }
             set { 
                if(_WarehouseName != value)
                {
                    _WarehouseName = value;
                    Notify("WarehouseName");
                }
             }
         }

         public int WarehouseId
         {
             get { return _WarehouseId; }
             set { 
                if(_WarehouseId != value)
                {
                    _WarehouseId = value;
                    Notify("WarehouseId");
                }
             }
         }

         public string DeliveryNo
         {
             get { return _DeliveryNo; }
             set { 
                if(_DeliveryNo != value)
                {
                    _DeliveryNo = value;
                    Notify("DeliveryNo");
                }
             }
         }

         public List<FDPStorageFeeDetailReport> StorageFeeList
         {
             get { return _StorageFeeList; }
             set { 
                if(_StorageFeeList != value)
                {
                    _StorageFeeList = value;
                    Notify("StorageFeeList");
                }
             }
         }
         #endregion

         #region Constructor
         public FDPStorageFeeDetailVM()
         {             
             //GetData();
         }
        #endregion

         #region Method
         public void GetData()
         {
             StorageFeeList = new List<FDPStorageFeeDetailReport>();
             using (var foreignDeliveryPoolService = SvcClientManager.GetSvcClient<ForeignDeliveryPoolServiceClient>(SvcType.ForeignDeliveryPoolSvc))
            {
                StorageFeeList = foreignDeliveryPoolService.GetDataList(DeliveryNo, WarehouseId, StartDate, EndDate, CurrentUser.Id);
                StorageFeeList = StorageFeeList.OrderByDescending(c => c.StartDate).ToList();
            }
         }
         #endregion
     }
}
