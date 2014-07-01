using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;
using System.Data;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContractUDFService" in code, svc and config file together.
    public class ContractUDFService : BaseService<ContractUDF>, IContractUDFService 
    {
        #region ICountryService Members

        public ContractUDF AddNewContractUDF(ContractUDF udf, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    ContractUDF tmp = QueryForObj(GetObjQuery<ContractUDF>(ctx),
                                              o => o.Name == udf.Name);
                    if (tmp != null)
                    {
                        throw new FaultException(ErrCode.UdfExisted.ToString());
                    }

                    Create(GetObjSet<ContractUDF>(ctx), udf);
                    ctx.SaveChanges();
                    return udf;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        public ContractUDF UpdateContractUDF(ContractUDF udf, int userId)
        {
            try
            {
                using (var ctx = new SenLan2Entities(userId))
                {
                    List<ContractUDF> udfLinks =
                        QueryForObjs(GetObjQuery<ContractUDF>(ctx),
                                     o =>
                                     o.Name == udf.Name &&
                                     o.Id != udf.Id).ToList();

                    if (udfLinks.Count > 0)
                    {
                        throw new FaultException(ErrCode.UdfExisted.ToString());
                    }

                    ContractUDF oldudf = GetById(GetObjQuery<ContractUDF>(ctx), udf.Id);
                    oldudf.Name = udf.Name;
                    oldudf.Comment = udf.Comment;
                    oldudf.IsDefault = udf.IsDefault;

                    ctx.SaveChanges();
                    return oldudf;
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        #endregion
    }
}
