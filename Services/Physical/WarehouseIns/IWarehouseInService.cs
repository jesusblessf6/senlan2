using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.Misc;
using DBEntity.EnableProperty;

namespace Services.Physical.WarehouseIns
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWarehouseInService" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseInService : IService<WarehouseIn>
    {
        [OperationContract]
        int GetWarehouseInLineAllCount();

        [OperationContract]
        int GetWarehouseInLineCount(string predicate, List<object> parameters);
        
        [OperationContract]
        List<WarehouseInLine> SelectByRangeWithOrderW(string predicate, List<object> parameters, SortCol sortcol, int from, int to, List<string> a);

        [OperationContract]
        void CreateDocument(int userId, WarehouseIn header, List<WarehouseInLine> addedLines);

        [OperationContract]
        void UpdateDocument(int userId, WarehouseIn header, List<WarehouseInLine> addedLines, List<WarehouseInLine> updatedLines, List<WarehouseInLine> deletedLines, List<WarehouseInLine> allLines);

        [OperationContract]
        WarehouseInEnableProperty SetElementsEnableProperty(int id);
    }
}
