using System.Collections.Generic;
using System.ServiceModel;
using Utility.ErrorManagement;
using Utility.Misc;

namespace Services.Base
{
    [ServiceContract]
    public interface IService<TEntity>
    {
        [OperationContract]
        TEntity GetById(int id);

        [OperationContract]
        int GetAllCount();

        [OperationContract]
        int FetchCount(string predicate, ICollection<object> parameters, List<string> includes);

        [OperationContract]
        int GetCount(string predicate, ICollection<object> parameters);

        [OperationContract]
        ICollection<TEntity> GetAll();

        [OperationContract]
        ICollection<TEntity> GetAllWithOrder(SortCol sortCol);

        [OperationContract]
        ICollection<TEntity> GetByRange(int from, int to);

        [OperationContract]
        ICollection<TEntity> GetByRangeWithOrder(SortCol sortCol, int from, int to);

        [OperationContract]
        TEntity FetchById(int id, ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> FetchAll(ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> FetchAllWithOrder(SortCol sortCol, ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> FetchByRange(int from, int to, ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> FetchByRangeWithOrder(SortCol sortCol, int from, int to,
                                                   ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> Query(string predicate, ICollection<object> parameters);

        //[OperationContract]
        //ICollection<TEntity> QueryWithOrder(string predicate, ICollection<object> parameters, SortCol sortCol);

        [OperationContract]
        ICollection<TEntity> QueryByRange(string predicate, ICollection<object> parameters, int from, int to);

        [OperationContract]
        ICollection<TEntity> QueryByRangeWithOrder(string predicate, ICollection<object> parameters, SortCol sortCol,
                                                   int from, int to);

        [OperationContract]
        ICollection<TEntity> Select(string predicate, ICollection<object> parameters,
                                    ICollection<string> eagerLoadProperties);

        //[OperationContract]
        //ICollection<TEntity> SelectWithOrder(string predicate, ICollection<object> parameters, SortCol sortCol,
        //                                     ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> SelectByRange(string predicate, ICollection<object> parameters, int from, int to,
                                           ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> SelectByRangeWithOrder(string predicate, ICollection<object> parameters, SortCol sortCol,
                                                    int from, int to, ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> SelectByRangeWithMultiOrder(string predicate, ICollection<object> parameters,
                                                         List<SortCol> sortCols,
                                                         int from, int to, ICollection<string> eagerLoadProperties);

        [OperationContract]
        ICollection<TEntity> SelectByRangeWithMultiOrderLazyLoad(string predicate, ICollection<object> parameters,
                                                            List<SortCol> sortCols,
                                                            int from, int to, ICollection<string> propertiesForFilter, ICollection<string> extraProperties);
        
        [OperationContract]
        [FaultContract(typeof (ServerErr))]
        TEntity Create(TEntity obj);

        [OperationContract]
        [FaultContract(typeof(ServerErr))]
        TEntity CreateNew(TEntity obj, int userId);

        [OperationContract]
        [FaultContract(typeof (ServerErr))]
        void DeleteById(int id);

        [OperationContract]
        [FaultContract(typeof (ServerErr))]
        void Delete(TEntity obj);

        [OperationContract]
        [FaultContract(typeof (ServerErr))]
        void Update(TEntity obj);

        [OperationContract]
        [FaultContract(typeof(ServerErr))]
        void UpdateExisted(TEntity obj, int userId);

        [OperationContract]
        [FaultContract(typeof(ServerErr))]
        void Remove(TEntity obj, int userId);

        [OperationContract]
        [FaultContract(typeof(ServerErr))]
        void RemoveById(int id, int userId);

        [OperationContract]
        [FaultContract(typeof(ServerErr))]
        decimal SelectSum(string predicate, ICollection<object> parameters, List<string> eagerProperties,
                                 string projection);

        [OperationContract]
        [FaultContract(typeof(ServerErr))]
        TEntity SelectById(List<string> eagerProperties, int id);

        [OperationContract]
        [FaultContract(typeof (ServerErr))]
        ICollection<TEntity> SelectWithMultiOrder(string predicate, ICollection<object> parameters,
                                                  List<SortCol> sortCols,
                                                  ICollection<string> eagerLoadProperties);

        [OperationContract]
        [FaultContract(typeof(ServerErr))]
        ICollection<TEntity> SelectWithMultiOrderLazyLoad(string predicate, ICollection<object> parameters,
                                                  List<SortCol> sortCols,
                                                  ICollection<string> eagerLoadProperties, ICollection<string> extraProperties);
    }
}