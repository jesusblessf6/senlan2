using System.Collections.Generic;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using DBEntity.EnableProperty;

namespace Services.Physical.WarehouseOuts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWarehouseOutService" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseOutService : IService<WarehouseOut>
    {
        [OperationContract]
        void UpdateWarehosueOut(WarehouseOut warehouseOut, WarehouseOutLine outLine, int userId);

        [OperationContract]
        void AddNewWarehouseOutLine(WarehouseOut warehouseOut, WarehouseOutLine outLine, int userId);

        [OperationContract]
        void CreateDocument(int userId, WarehouseOut header, List<WarehouseOutLine> addedLines,
                            List<WarehouseInLine> inLines, int quotaID);

        [OperationContract]
        void UpdateDocument(int userId, WarehouseOut header, List<WarehouseOutLine> addedLines,
                            List<WarehouseOutLine> updatedLines, List<WarehouseOutLine> deletedLines,
                            List<WarehouseInLine> inLines, int quotaID);

        [OperationContract]
        WarehouseOutEnableProperty SetElementsEnableProperty(int id);
    }
}