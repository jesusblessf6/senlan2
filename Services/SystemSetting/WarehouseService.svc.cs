using DBEntity;
using Services.Base;
using System.Data;
using System.ServiceModel;
using Utility.ErrorManagement;
using System.Collections.Generic;
using System.Transactions;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WarehouseService" in code, svc and config file together.
    public class WarehouseService : BaseService<Warehouse>, IWarehouseService
    {
        public void AddNewWarehouse(Warehouse warehouse, List<StorageFeeRule> addStorageFeeRule, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    CreateHeader(userId, warehouse);
                    foreach (StorageFeeRule storageFeeRule in addStorageFeeRule)
                    {
                        CreateStorageFeeRule(userId, warehouse, storageFeeRule);
                    }
                    ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

        private void CreateHeader(int userId, Warehouse header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObjs(GetObjQuery<Warehouse>(ctx), o => o.Name == header.Name);
                    if (tmp.Count > 0)
                    {
                        throw new FaultException(ErrCode.WarehouseExisted.ToString());
                    }

                    Create(GetObjSet<Warehouse>(ctx), header);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public void CreateStorageFeeRule(int userId,Warehouse header,StorageFeeRule storageFeeRule)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var newStorageFeeRule = new StorageFeeRule
                    {
                         StartDate = storageFeeRule.StartDate,
                         EndDate = storageFeeRule.EndDate,
                         CommodityId = storageFeeRule.CommodityId,
                         PricePerUnit = storageFeeRule.PricePerUnit,
                         WarrantFee = storageFeeRule.WarrantFee,
                         TransferFee = storageFeeRule.TransferFee,
                         WarehouseId = header.Id
                    };
                    Create(GetObjSet<StorageFeeRule>(ctx), newStorageFeeRule);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public void UpdateExistedWarehouse(Warehouse warehouse, List<StorageFeeRule> addStorageFeeRules, List<StorageFeeRule> updateStorageFeeRules, List<StorageFeeRule> deleteStorageFeeRules, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    UpdateHeader(userId, warehouse);
                    foreach(StorageFeeRule addRule in addStorageFeeRules)
                    {
                        CreateStorageFeeRule(userId, warehouse, addRule);
                    }
                    foreach(StorageFeeRule updateRule in updateStorageFeeRules)
                    {
                        UpdateStorageFeeRule(userId, updateRule);
                    }
                    foreach(StorageFeeRule deleteRule in deleteStorageFeeRules)
                    {
                        DeleteStorageFeeRule(userId, deleteRule.Id);
                    }

                    ts.Complete();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

        public void DeleteStorageFeeRule(int userId, int id)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                StorageFeeRule rule = QueryForObj(GetObjQuery<StorageFeeRule>(ctx),
                                   c => c.Id == id);
                rule.IsDeleted = true;
                ctx.SaveChanges();

            }
        }
        private void UpdateStorageFeeRule(int userId, StorageFeeRule rule)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    StorageFeeRule oldRule =
                       QueryForObj(GetObjQuery<StorageFeeRule>(ctx),
                                   c => c.Id == rule.Id);
                    oldRule.StartDate = rule.StartDate;
                    oldRule.EndDate = rule.EndDate;
                    oldRule.CommodityId = rule.CommodityId;
                    oldRule.PricePerUnit = rule.PricePerUnit;
                    oldRule.WarrantFee = rule.WarrantFee;
                    oldRule.TransferFee = rule.TransferFee;
                    oldRule.WarehouseId = rule.WarehouseId;
                    Update(GetObjSet<StorageFeeRule>(ctx), oldRule);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        private void UpdateHeader(int userId, Warehouse header)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    var tmp = QueryForObjs(GetObjQuery<Warehouse>(ctx), o => o.Name == header.Name && o.Id != header.Id);
                    if (tmp.Count > 0)
                    {
                        throw new FaultException(ErrCode.WarehouseExisted.ToString());
                    }

                    Update(GetObjSet<Warehouse>(ctx), header);
                    ctx.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

         /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public override void RemoveById(int id, int userId)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var ctx = new SenLan2Entities(userId))
                    {
                        Warehouse warehouse =
                           QueryForObj(
                               GetObjQuery<Warehouse>(ctx, new List<string> { "StorageFeeRules" }),
                               c => c.Id == id);
                        foreach(StorageFeeRule rule in warehouse.StorageFeeRules)
                        {
                            if (!rule.IsDeleted)
                            {
                                DeleteStorageFeeRule(userId, rule.Id);
                            }
                        }
                        warehouse.IsDeleted = true;
                        ctx.SaveChanges();
                        ts.Complete();
                    }
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                finally
                {
                    ts.Dispose();
                }
            }
        }

    }
}