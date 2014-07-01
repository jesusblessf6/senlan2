using System.Data;
using System.ServiceModel;
using DBEntity;
using Services.Base;
using Utility.ErrorManagement;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DocumentService" in code, svc and config file together.
    public class DocumentService : BaseService<Document>,  IDocumentService
    {
        /// <summary>
        /// Get Document type object by document name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Document GetByName(string name)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObj(GetObjQuery<Document>(ctx), o => o.Name == name);
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }

        /// <summary>
        /// Get Document by Table Code
        /// </summary>
        /// <param name="tableCode"></param>
        /// <returns></returns>
        public Document GetByTableCode(string tableCode)
        {
            try
            {
                using (var ctx = new SenLan2Entities())
                {
                    return QueryForObj(GetObjQuery<Document>(ctx), o => o.TableCode == tableCode);
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
            }
        }
    }
}
