using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using DBEntity;
using Utility.ErrorManagement;
using Utility.Misc;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Services.Base
{
    public class BaseService<TEntity> : IService<TEntity>
        where TEntity : class, IObjectWithChangeTracker, IEntity, new()
    {
        #region generic methods

        public ObjectQuery<T> GetObjQuery<T>(IContext ctx, ICollection<string> eagerLoadProperties = null)
            where T : class, IEntity, new()
        {
            var oq = ctx.GetObjSet<T>().Where("it.IsDeleted = false");
            
            if (eagerLoadProperties == null)
            {
                eagerLoadProperties = (new T()).EagerLoadProperties;
            }

            return eagerLoadProperties.Aggregate(oq, (current, prop) => current.Include(prop));
        }

        public ObjectQuery<T> GetObjQueryWithDeleted<T>(IContext ctx, ICollection<string> eagerLoadProperties = null)
            where T : class, IEntity, new()
        {
            ObjectQuery<T> oq = ctx.GetObjSet<T>();
            if (eagerLoadProperties == null)
            {
                eagerLoadProperties = (new T()).EagerLoadProperties;
            }

            return eagerLoadProperties.Aggregate(oq, (current, prop) => current.Include(prop));
        }

        public ObjectSet<T> GetObjSet<T>(IContext ctx) where T : class, new()
        {
            return ctx.GetObjSet<T>();
        }

        public T GetById<T>(ObjectQuery<T> os, int id) where T : class, IEntity, new()
        {
            T x = QueryForObj(os, (o => o.Id == id));
            return x;
        }

        public T QueryForObj<T>(ObjectQuery<T> os, Expression<Func<T, bool> > func) where T : class, IEntity, new()
        {
            return os.SingleOrDefault(func);
        }

        public ICollection<T> QueryForObjs<T>(ObjectQuery<T> os, Expression<Func<T, bool> > func) where T : class, IEntity, new()
        {
            return os.Where(func).ToList();
        }

        public ICollection<T> QueryForObjs<T>(IOrderedQueryable<T> query, Expression<Func<T, bool> > func, int from, int to)
            where T : class, IEntity, new()
        {
            if (from < 0 || to < 0 || from > to)
            {
                return query.Where(func).ToList();
            }

            return query.Where(func).Skip(@from - 1).Take(to - @from + 1).ToList();
        }

        public IOrderedQueryable<T> GetAll<T>(ObjectQuery<T> os) where T : class, IEntity
        {
            // order by Id desc by default
            return os.OrderByDescending(t => t.Id);
        }

        //index start with 1
        public IQueryable<T> GetByRange<T>(IOrderedQueryable<T> query, int from, int to) where T : class
        {
            if (from < 0 || to < 0 || from > to)
            {
                return query;
            }
            
            return query.Skip(@from - 1).Take(to - @from + 1);
        }

        public void Create<T>(ObjectSet<T> os, T obj) where T : class, IObjectWithChangeTracker
        {
            os.AddObject(obj);
        }

        public void Delete<T>(ObjectSet<T> os, T obj) where T : class, IObjectWithChangeTracker
        {
            os.DeleteObject(obj);
        }

        public void Delete<T>(ObjectSet<T> os, int id) where T : class, IEntity, IObjectWithChangeTracker, new()
        {
            T obj = GetById(os, id);
            if (obj != null)
            {
                Delete(os, obj);
            }
        }

        public void Update<T>(ObjectSet<T> os, T obj) where T : class, IObjectWithChangeTracker
        {
            os.ApplyChanges(obj);
        }

        #endregion

        #region implementation of interface IService<TEntity>

        public TEntity GetById(int id)
        {
            return FetchById(id, null);
        }

        public TEntity FetchById(int id, ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx);
                var x = QueryForObj(os, (o => o.Id == id));
                if (eagerLoadProperties != null) 
                {
                    foreach (var s in eagerLoadProperties)
                    {
                        ctx.LoadProperty(x, s);
                    }
                }
                return x;
            }
        }

        public int GetAllCount()
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx);
                return os.Count();
            }
        }

        public int GetCount(string predicate, ICollection<object> parameters)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectParameter[] p;
                BuildObjParams(parameters, out p);
                var objQuery = GetObjQuery<TEntity>(ctx).Where(predicate, p);
                return objQuery.Count();
            }
        }

        public int GetCount<T>(string predicate, ICollection<object> parameters) where T : class, IEntity, IObjectWithChangeTracker, new()
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectParameter[] p;
                BuildObjParams(parameters, out p);
                var objQuery = GetObjQuery<T>(ctx).Where(predicate, p);
                return objQuery.Count();
            }
        }

        public decimal GetSum<T>(string predicate, ICollection<object> parameters, Expression<Func<T, decimal?>> func) 
            where T : class, IEntity, IObjectWithChangeTracker, new()
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectParameter[] p;
                BuildObjParams(parameters, out p);
                var objQuery = GetObjQuery<T>(ctx).Where(predicate, p);
                if (!objQuery.Any()) return 0;
                return objQuery.Sum(func) ?? 0;
            }
        }

        public decimal SelectSum<T>(string predicate, ICollection<object> parameters, List<string> eagerProperties, Expression<Func<T, decimal?>> func)
            where T : class, IEntity, IObjectWithChangeTracker, new()
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectParameter[] p;
                BuildObjParams(parameters, out p);
                var objQuery = GetObjQuery<T>(ctx, eagerProperties).Where(predicate, p);
                if (!objQuery.Any()) return 0;
                return objQuery.Sum(func) ?? 0;
            }
        }

        public decimal SelectSum(string predicate, ICollection<object> parameters, List<string> eagerProperties,
                                 string projection)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectParameter[] p;
                BuildObjParams(parameters, out p);
                var objQuery = GetObjQuery<TEntity>(ctx, eagerProperties).Where(predicate, p);
                if (!objQuery.Any()) return 0;
                var x = objQuery.Select(projection).ToList();
                return x.Sum(o => o.GetDecimal(0));
            }
        }

        public int FetchCount(string predicate, ICollection<object> parameters, List<string> includes )
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectParameter[] p;
                BuildObjParams(parameters, out p);
                var objQuery = GetObjQuery<TEntity>(ctx, includes).Where(predicate, p);
                return objQuery.Count();
            }
        }

        public ICollection<TEntity> GetAll()
        {
            return FetchAll(null);
        }

        public ICollection<TEntity> FetchAll(ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx);
                var x =  GetAll(os);

                if(eagerLoadProperties != null)
                {
                    foreach (var entity in x)
                    {
                        foreach (var s in eagerLoadProperties)
                        {
                            ctx.LoadProperty(entity, s);
                        }
                    }
                }

                return x.ToList();
            }
        }

        public ICollection<TEntity> GetAllWithOrder(SortCol sortCol)
        {
            return FetchAllWithOrder(sortCol, null);
        }

        public ICollection<TEntity> FetchAllWithOrder(SortCol sortCol, ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                IQueryable<TEntity> q = GetObjQuery<TEntity>(ctx);
                IOrderedQueryable<TEntity> oq = sortCol.ByDescending ? q.OrderByDescending(sortCol.ColName) : q.OrderBy(sortCol.ColName);

                if (eagerLoadProperties != null)
                {
                    foreach (var entity in oq)
                    {
                        foreach (var s in eagerLoadProperties)
                        {
                            ctx.LoadProperty(entity, s);
                        }
                    }
                }

                return oq.ToList();
            }
        }

        public ICollection<TEntity> GetByRange(int from, int to)
        {
            return FetchByRange(from, to, null);
        }

        public ICollection<TEntity> FetchByRange(int from, int to, ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx);
                var x =  GetByRange(GetAll(os), from, to);

                if(eagerLoadProperties != null)
                {
                    foreach (var entity in x)
                    {
                        foreach (var s in eagerLoadProperties)
                        {
                            ctx.LoadProperty(entity, s);
                        }
                    }
                }

                return x.ToList();
            }
        }

        public ICollection<TEntity> GetByRangeWithOrder(SortCol sortCol, int from, int to)
        {
            return FetchByRangeWithOrder(sortCol, from, to, null);
        }

        public ICollection<TEntity> FetchByRangeWithOrder(SortCol sortCol, int from, int to,
                                                          ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                IQueryable<TEntity> q = GetObjQuery<TEntity>(ctx);
                IOrderedQueryable<TEntity> oq = sortCol.ByDescending ? q.OrderByDescending(sortCol.ColName) : q.OrderBy(sortCol.ColName);
                var x =  GetByRange(oq, from, to);
                if (eagerLoadProperties != null)
                {
                    foreach (var entity in x)
                    {
                        foreach (var s in eagerLoadProperties)
                        {
                            ctx.LoadProperty(entity, s);
                        }
                    }
                }
                return x.ToList();
            }
        }

        public ICollection<TEntity> Query(string predicate, ICollection<object> parameters)
        {
            return Select(predicate, parameters, null);
        }

        public ICollection<TEntity> Select(string predicate, ICollection<object> parameters,
                                           ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, eagerLoadProperties);
                ObjectParameter[] objParams;
                BuildObjParams(parameters, out objParams);
                var x = os.Where(predicate, objParams);
                return x.ToList();
            }
        }

        public ICollection<TEntity> SelectCount(string predicate, ICollection<object> parameters,
                                           ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, eagerLoadProperties);
                ObjectParameter[] objParams;
                BuildObjParams(parameters, out objParams);
                var x = os.Where(predicate, objParams);
                return x.ToList();
            }
        }

        //public ICollection<TEntity> QueryWithOrder(string predicate, ICollection<object> parameters, SortCol sortCol)
        //{
        //    return SelectWithOrder(predicate, parameters, sortCol, null);
        //}

        //public ICollection<TEntity> SelectWithOrder(string predicate, ICollection<object> parameters, SortCol sortCol,
        //                                            ICollection<string> eagerLoadProperties)
        //{
        //    using (var ctx = new SenLan2Entities())
        //    {
        //        ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, eagerLoadProperties);
        //        ObjectParameter[] objParams;
        //        BuildObjParams(parameters, out objParams);
        //        IQueryable<TEntity> q = os.Where(predicate, objParams);
        //        IOrderedQueryable<TEntity> oq = sortCol.ByDescending ? q.OrderByDescending(sortCol.ColName) : q.OrderBy(sortCol.ColName);
        //        return oq.ToList();
        //    }
        //}

        public ICollection<TEntity> QueryByRange(string predicate, ICollection<object> parameters, int from, int to)
        {
            return SelectByRange(predicate, parameters, from, to, null);
        }

        public ICollection<TEntity> SelectByRange(string predicate, ICollection<object> parameters, int from, int to,
                                                  ICollection<string> eagerLoadProperties)
        {
            return SelectByRangeWithOrder(predicate, parameters,
                                          new SortCol
                                              {
                                                  ColName = "Id",
                                                  ByDescending = true
                                              },
                                          from, to, eagerLoadProperties);
        }

        public ICollection<TEntity> QueryByRangeWithOrder(string predicate, ICollection<object> parameters,
                                                          SortCol sortCol, int from, int to)
        {
            return SelectByRangeWithOrder(predicate, parameters, sortCol, from, to, null);
        }

        public ICollection<TEntity> SelectByRangeWithOrder(string predicate, ICollection<object> parameters,
                                                           SortCol sortCol, int from, int to,
                                                           ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, eagerLoadProperties);
                ObjectParameter[] objParams;
                BuildObjParams(parameters, out objParams);
                IQueryable<TEntity> q = os.Where(predicate, objParams);
                IOrderedQueryable<TEntity> oq = sortCol.ByDescending ? q.OrderByDescending(sortCol.ColName) : q.OrderBy(sortCol.ColName);
                return GetByRange(oq, from, to).ToList();
            }
        }

        public virtual TEntity Create(TEntity obj)
        {
            return CreateNew(obj, 0);
        }

        public virtual TEntity CreateNew(TEntity obj, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                try
                {
                    ObjectSet<TEntity> os = GetObjSet<TEntity>(ctx);
                    Create(os, obj);
                    ctx.SaveChanges();
                    return obj;
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 8152)
                    {
                        throw new FaultException(ErrCode.StringOverflow.ToString());
                    }

                    throw;
                }
            }
        }

        public void DeleteById(int id)
        {
            using (var ctx = new SenLan2Entities())
            {
                try
                {
                    ObjectSet<TEntity> os = GetObjSet<TEntity>(ctx);
                    Delete(os, id);
                    ctx.SaveChanges();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 547)
                    {
                        throw new FaultException(ErrCode.DeleteFKErr.ToString());
                    }

                    throw;
                }
            }
        }

        public void Delete(TEntity obj)
        {
            using (var ctx = new SenLan2Entities())
            {
                try
                {
                    ObjectSet<TEntity> os = GetObjSet<TEntity>(ctx);
                    Delete(os, obj);
                    ctx.SaveChanges();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 547)
                    {
                        throw new FaultException(ErrCode.DeleteFKErr.ToString());
                    }

                    throw;
                }
            }
        }

        public virtual void Update(TEntity obj)
        {
            UpdateExisted(obj, 0);
        }

        public virtual void UpdateExisted(TEntity obj, int userId)
        {
            using (var ctx = new SenLan2Entities(userId))
            {
                ObjectSet<TEntity> os = GetObjSet<TEntity>(ctx);
                Update(os, obj);
                try
                {
                    ctx.SaveChanges();
                }
                catch (OptimisticConcurrencyException)
                {
                    throw new FaultException(ErrCode.OptimisticConcurrencyErr.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 8152)
                    {
                        throw new FaultException(ErrCode.StringOverflow.ToString());
                    }

                    throw;
                }
            }
        }

        private static void BuildObjParams(ICollection<object> parameters, out ObjectParameter[] objParams)
        {
            if (parameters == null)
            {
                objParams = new ObjectParameter[0];
                return;
            }
            objParams = new ObjectParameter[(parameters.Count)];
            int i = 0;
            foreach (object obj in parameters)
            {
                objParams[i] = new ObjectParameter("p" + (i + 1).ToString(CultureInfo.InvariantCulture), obj);
                ++i;
            }
        }

        public virtual void Remove(TEntity obj, int userId)
        {
            Delete(obj);
        }

        public virtual void RemoveById(int id, int userId)
        {
            DeleteById(id);
        }

        public TEntity SelectById(List<string> eagerProperties, int id)
        {
            using (var ctx = new SenLan2Entities())
            {
                return QueryForObj(GetObjQuery<TEntity>(ctx, eagerProperties), o => o.Id == id);
            }
        }

        public ICollection<TEntity> SelectWithMultiOrder(string predicate, ICollection<object> parameters, List<SortCol> sortCols,
                                                ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, eagerLoadProperties);
                ObjectParameter[] objParams;
                BuildObjParams(parameters, out objParams);
                IQueryable<TEntity> q = os.Where(predicate, objParams);
                var firstCol = sortCols[0];
                IOrderedQueryable<TEntity> oq = firstCol.ByDescending ? q.OrderByDescending(firstCol.ColName) : q.OrderBy(firstCol.ColName);
                if (sortCols.Count > 1)
                {
                    for (int i = 1; i < sortCols.Count; i++)
                    {
                        var iCol = sortCols[i];
                        oq = iCol.ByDescending ? oq.ThenByDescending(iCol.ColName) : oq.ThenBy(iCol.ColName);
                    }
                }
                return oq.ToList();
            }
        }

        public ICollection<TEntity> SelectWithMultiOrderLazyLoad(string predicate, ICollection<object> parameters,
                                                          List<SortCol> sortCols,
                                                          ICollection<string> eagerLoadProperties,
                                                          ICollection<string> extraProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, eagerLoadProperties);
                ObjectParameter[] objParams;
                BuildObjParams(parameters, out objParams);
                IQueryable<TEntity> q = os.Where(predicate, objParams);
                var firstCol = sortCols[0];
                IOrderedQueryable<TEntity> oq = firstCol.ByDescending ? q.OrderByDescending(firstCol.ColName) : q.OrderBy(firstCol.ColName);
                if (sortCols.Count > 1)
                {
                    for (int i = 1; i < sortCols.Count; i++)
                    {
                        var iCol = sortCols[i];
                        oq = iCol.ByDescending ? oq.ThenByDescending(iCol.ColName) : oq.ThenBy(iCol.ColName);
                    }
                }
                var interimResult = oq.ToList();
                if (extraProperties == null || extraProperties.Count <= 0)
                {
                    return interimResult;
                }
                //var ids = interimResult.Select(o => o.Id);
                //var allProperties = new List<string>();
                //allProperties.AddRange(eagerLoadProperties);
                //allProperties.AddRange(extraProperties);
                //return QueryForObjs(GetObjQuery<TEntity>(ctx, allProperties), o => ids.Contains(o.Id)).ToList();

                List<string> cons = interimResult.Select(o => "it.id=" + o.Id).ToList();
                if (cons == null || cons.Count <= 0)
                {
                    return interimResult;
                }
                var strCon = string.Join(" or ", cons);

                var allProperties = new List<string>();
                allProperties.AddRange(eagerLoadProperties);
                allProperties.AddRange(extraProperties);

                os = GetObjQuery<TEntity>(ctx, allProperties);
                var parameters2 = new List<object>();
                BuildObjParams(parameters2, out objParams);
                q = os.Where(strCon, objParams);

                oq = firstCol.ByDescending ? q.OrderByDescending(firstCol.ColName) : q.OrderBy(firstCol.ColName);

                if (sortCols.Count > 1)
                {
                    for (int i = 1; i < sortCols.Count; i++)
                    {
                        var iCol = sortCols[i];
                        oq = iCol.ByDescending ? oq.ThenByDescending(iCol.ColName) : oq.ThenBy(iCol.ColName);
                    }
                }
                return oq.ToList();
            }
        }

        /// <summary>
        /// The sortCols should not be null or empty
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="parameters"></param>
        /// <param name="sortCols"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="eagerLoadProperties"></param>
        /// <returns></returns>
        public ICollection<TEntity> SelectByRangeWithMultiOrder(string predicate, ICollection<object> parameters,
                                                                List<SortCol> sortCols,
                                                                int from, int to,
                                                                ICollection<string> eagerLoadProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, eagerLoadProperties);
                ObjectParameter[] objParams;
                BuildObjParams(parameters, out objParams);
                IQueryable<TEntity> q = os.Where(predicate, objParams);
                var firstCol = sortCols[0];
                IOrderedQueryable<TEntity> oq = firstCol.ByDescending ? q.OrderByDescending(firstCol.ColName) : q.OrderBy(firstCol.ColName);

                if (sortCols.Count > 1)
                {
                    for (int i = 1; i < sortCols.Count; i++)
                    {
                        var iCol = sortCols[i];
                        oq = iCol.ByDescending ? oq.ThenByDescending(iCol.ColName) : oq.ThenBy(iCol.ColName);
                    }
                }

                return GetByRange(oq, from, to).ToList();
            }
        }

        public ICollection<TEntity> SelectByRangeWithMultiOrderLazyLoad(string predicate, ICollection<object> parameters,
                                                            List<SortCol> sortCols,
                                                            int from, int to, ICollection<string> propertiesForFilter, ICollection<string> extraProperties)
        {
            using (var ctx = new SenLan2Entities())
            {
                ObjectQuery<TEntity> os = GetObjQuery<TEntity>(ctx, propertiesForFilter);
                ObjectParameter[] objParams;
                BuildObjParams(parameters, out objParams);
                IQueryable<TEntity> q = os.Where(predicate, objParams);
                var firstCol = sortCols[0];
                IOrderedQueryable<TEntity> oq = firstCol.ByDescending ? q.OrderByDescending(firstCol.ColName) : q.OrderBy(firstCol.ColName);

                if (sortCols.Count > 1)
                {
                    for (int i = 1; i < sortCols.Count; i++)
                    {
                        var iCol = sortCols[i];
                        oq = iCol.ByDescending ? oq.ThenByDescending(iCol.ColName) : oq.ThenBy(iCol.ColName);
                    }
                }

                var interimResult = GetByRange(oq, from, to).ToList();

                if (extraProperties == null || extraProperties.Count <= 0)
                {
                    return interimResult;
                }

                List<string> cons = interimResult.Select(o => "it.id=" + o.Id).ToList();
                if (cons == null || cons.Count <= 0)
                {
                    return interimResult;
                }
                var strCon = string.Join(" or ", cons);

                var allProperties = new List<string>();
                allProperties.AddRange(propertiesForFilter);
                allProperties.AddRange(extraProperties);

                os = GetObjQuery<TEntity>(ctx, allProperties);
                var parameters2 = new List<object>();
                BuildObjParams(parameters2, out objParams);
                q = os.Where(strCon, objParams);
                
                oq = firstCol.ByDescending ? q.OrderByDescending(firstCol.ColName) : q.OrderBy(firstCol.ColName);

                if (sortCols.Count > 1)
                {
                    for (int i = 1; i < sortCols.Count; i++)
                    {
                        var iCol = sortCols[i];
                        oq = iCol.ByDescending ? oq.ThenByDescending(iCol.ColName) : oq.ThenBy(iCol.ColName);
                    }
                }
                return oq.ToList();
            }
        }

        #endregion
    }
}