using System;
using System.Collections;
using System.Collections.Generic;
using Utility.Misc;
using Utility.QueryManagement;

namespace Client.Base.BaseClientVM
{
    public abstract class ListBaseVM : BaseVM
    {
        #region Properties & Members

        public bool IsPaging { get; set; }
        public int TotalCount { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public List<QueryElement> QueryElements { get; set; }

        public IEnumerable Entities
        {
            get { return _entities; }
            set
            {
                _entities = value;
                Notify("Entities");
            }
        }
        private IEnumerable _entities;

        private string _queryStr;
        public string QueryStr
        {
            get { return _queryStr; }
            set { _queryStr = value; }
        }

        public List<object> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        private List<object> _parameters;

        public object SvcClient { get; set; }

        // Normal Load or Filters in Lazy Load
        public List<string> Includes { get; set; }

        // Extra includes in Lazy Load
        public List<string> ExtraIncludes { get; set; } 

        // For Normal Load
        public SortCol SortingCol 
        {
            get { return _sortingCol ?? (_sortingCol = new SortCol {ByDescending = true, ColName = "Id"}); }
            set { _sortingCol = value; }
        }
        private SortCol _sortingCol;

        //For Lazy Load
        public List<SortCol> SortCols
        {
            get
            {
                if (_sortCols == null)
                {
                    _sortCols = new List<SortCol>();
                }

                if (_sortCols.Count == 0)
                {
                    _sortCols.Add(new SortCol { ByDescending = true, ColName = "Id" });
                }

                return _sortCols;
            }
            set { _sortCols = value; }
        }
        private List<SortCol> _sortCols; 

        #endregion

        #region Contractor

        protected ListBaseVM(List<QueryElement> elements)
        {
            IsPaging = true;
            QueryElements = elements;
            QueryManager.BuildQueryStrAndParams(QueryElements, out _queryStr, out _parameters);
        }

        protected ListBaseVM()
        {
            IsPaging = true;
            QueryElements = new List<QueryElement>();
            QueryManager.BuildQueryStrAndParams(QueryElements, out _queryStr, out _parameters);
        }

        #endregion

        #region Method

        public virtual void LoadList()
        {
            if (SvcClient == null)
            {
                throw new Exception("Service Client is not initialized! ");
            }

            Entities = (IList)SvcClient.GetType().GetMethod("SelectByRangeWithOrder").Invoke(SvcClient, new object[] { QueryStr, Parameters, SortingCol, From, To, Includes });
            FilterEntities();
            Resort();
        }

        public virtual void LoadListLazy()
        {
            if (SvcClient == null)
            {
                throw new Exception("Service Client is not initialized! ");
            }
            Entities = (IList)SvcClient.GetType().GetMethod("SelectByRangeWithMultiOrderLazyLoad").Invoke(SvcClient, new object[] { QueryStr, Parameters, SortCols, From, To, Includes, ExtraIncludes });
            FilterEntities();
            Resort();
        }

        public virtual void GetRecCount()
        {
            if (SvcClient == null)
            {
                throw new Exception("Service Client is not initialized! ");
            }

            TotalCount = (int)SvcClient.GetType().GetMethod("GetCount").Invoke(SvcClient, new object[] { QueryStr, Parameters });
        }

        public virtual void Remove(int id)
        {
            if (SvcClient == null)
            {
                throw new Exception("Service Client is not initialized! ");
            }

            SvcClient.GetType().GetMethod("RemoveById").Invoke(SvcClient, new object[] { id, CurrentUser.Id });
        }

        public abstract void InitService();

        public abstract void RegisterIncludes();

        public virtual void RegisterExtraIncludes()
        {
            ExtraIncludes = new List<string>();
        }

        public virtual void FilterEntities()
        {
            
        }

        public virtual void Resort()
        {
            
        }

        #endregion
    }
}
