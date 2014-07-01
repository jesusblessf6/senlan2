using System;
using System.Collections.Generic;
using System.ServiceModel;
using Services.Base;
using DBEntity;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommissionService" in both code and config file together.
    [ServiceContract]
    public interface ICommissionService : IService<Commission>
    {
        [OperationContract]
        void CreateDocument(int userId, Commission header, List<CommissionLine> addedLines);
        [OperationContract]
        void UpdateDocument(int userId, Commission header, List<CommissionLine> addedLines, List<CommissionLine> updatedLines, List<CommissionLine> deletedLines);
        [OperationContract]
        decimal? GetCommissionValue(DateTime? startDate, int? internalCustomerID, int? commodityID, int? customerID, decimal? price, decimal? qty, int userId);
        [OperationContract]
        void GetCarryCommissionValue(LMEPosition position1, LMEPosition position2, int? customerID, decimal? price1, decimal? price2, ref decimal? commissionValue1, ref decimal? commissionValue2, int userId);

    }
}
