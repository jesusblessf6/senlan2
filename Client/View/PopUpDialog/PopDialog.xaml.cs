using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Utility.Controls;
using Utility.Misc;
using Utility.ServiceManagement;

//todo 重写，将数据用VM封装，而不是直接写在View中

namespace Client.View.PopUpDialog
{
    /// <summary>
    /// Interaction logic for PopDialog.xaml
    /// </summary>
    public partial class PopDialog
    {
        #region Member

        private const int PerRecord = 20;
        private const BindingFlags Flag = BindingFlags.Public | BindingFlags.Instance;
        private List<object> _fullParameters;
        private string _fullQueryStr = string.Empty;
        private int _rowCount;

        #endregion

        #region Property

        // 表格的列名和绑定的Path
        public List<ColumnInfo> Columns { get; set; }
        // 查询的条件
        public Dictionary<string, string> Conditions { get; set; }
        // 弹出窗体的标题
        public String QueryStr { get; set; }
        // 查询参数
        public List<object> Parameters { get; set; }
        public object SelectedItem { get; set; }
        public List<object> SelectedItemList { get; set; }
        public Type MySvcClientType { get; set; }
        public SvcType ServiceType { get; set; }
        public object MySvcClient { get; set; }
        public List<SearchConditionItem> SearchConditionItems { get; set; }
        public List<string> EagerLoadPropertiesForFilter { get; set; }
        public List<string> EagerLoadPropertiesForAppend { get; set; }
        public int FilterId { get; set; }
        public int ContentId { get; set; }
        public List<SortCol> SortCols { get; set; }
        //public string OrderBy { get; set; }
        //public string OrderType { get; set; }
        public bool SelectedMode { get; set; }
        #endregion

        #region Constructor

        public PopDialog(string title, List<ColumnInfo> columns, Dictionary<string, string> conditions,
                         Type mySvcClient, SvcType serviceType, string queryStr = null,
                         List<Object> parameters = null, List<string> eagerLoadPropertiesForFilter = null, int filterId = 0, int contentId = 0, bool selectedMode = false, List<string> eagerLoadPropertiesForAppend = null, List<SortCol> sortCols = null)
        {
            InitializeComponent();

            Title = title;
            Conditions = conditions;
            Columns = columns;
            MySvcClientType = mySvcClient;
            ServiceType = serviceType;
            QueryStr = queryStr;
            Parameters = parameters;
            if (eagerLoadPropertiesForFilter != null)
                EagerLoadPropertiesForFilter = eagerLoadPropertiesForFilter;
            else
                EagerLoadPropertiesForFilter = new List<string>();
            if (eagerLoadPropertiesForAppend != null)
                EagerLoadPropertiesForAppend = eagerLoadPropertiesForAppend;
            else
                EagerLoadPropertiesForAppend = new List<string>();
            FilterId = filterId;
            ContentId = contentId;
            //OrderBy = orderBy;
            //OrderType = orderType;
            SortCols = sortCols;
            SelectedMode = selectedMode;
            if (selectedMode)
            {
                popDataGrid.SelectionMode = DataGridSelectionMode.Extended;
            }
            else
            {
                popDataGrid.SelectionMode = DataGridSelectionMode.Single;
            }
            LoadControl();
        }

        #endregion

        #region Method

        private void LoadControl()
        {
            label1.Visibility = Visibility.Collapsed;
            textBox1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            textBox2.Visibility = Visibility.Collapsed;

            MySvcClient = SvcClientManager.GetSvcClient(MySvcClientType, ServiceType);
            SearchConditionItems = new List<SearchConditionItem>
                {
                    new SearchConditionItem {ConditionLabel = label1, ConditionContent = textBox1},
                    new SearchConditionItem {ConditionLabel = label2, ConditionContent = textBox2},
                };

            SetConditions();
            InitGridColumns();

            try
            {
                GetRowCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

            pagingControl.OnNewPage += MoveToNewPage;
            pagingControl.Init(_rowCount, PerRecord);
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        private void SetConditions()
        {
            if (Conditions == null || Conditions.Count == 0)
                return;

            Dictionary<string, string>.Enumerator e = Conditions.GetEnumerator();
            int i = 0;
            while (e.MoveNext())
            {
                SearchConditionItems[i].ConditionContent.Visibility = Visibility.Visible;
                SearchConditionItems[i].ConditionLabel.Visibility = Visibility.Visible;
                SearchConditionItems[i].ConditionLabel.Content = e.Current.Key;
                SearchConditionItems[i].ConditionContent.Tag = e.Current.Value;
                i++;
            }

            btnSearch.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 初始化表格列
        /// </summary>
        private void InitGridColumns()
        {
            if (Columns != null && Columns.Count > 0)
            {
                foreach (ColumnInfo columnInfo in Columns)
                {
                    Visibility visibility;
                    if (columnInfo.Visibility != null && columnInfo.Visibility == false)
                    {
                        visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        visibility = Visibility.Visible;
                    }

                    var colBinding = new Binding(columnInfo.Path);
                    if (columnInfo.Converter != null)
                    {
                        colBinding.Converter = columnInfo.Converter;
                    }

                    if (!string.IsNullOrWhiteSpace(columnInfo.StringFormat))
                    {
                        colBinding.StringFormat = columnInfo.StringFormat;
                    }

                    popDataGrid.Columns.Add(new DataGridTextColumn { Header = columnInfo.Header, Binding = colBinding, Visibility = visibility });
                }
            }
        }

        private void MoveToNewPage(Object sender, PagingEventArgs e)
        {
            try
            {
                popDataGrid.ItemsSource = GetData(e.From, e.To);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

            popDataGrid.Items.Refresh();
        }

        private void GetSelectedItem()
        {
            var lists = popDataGrid.SelectedItems as IList<Object>;
            if (lists != null && lists.Count != 0)
            {
                if (SelectedMode)
                {
                    SelectedItemList = new List<object>();
                    foreach (var item in lists)
                    {
                        SelectedItemList.Add(item);
                    }
                }
                else
                {
                    SelectedItem = lists[0];

                }
                Close();
            }
        }

        /// <summary>   
        /// 获取弹出框上输入的查询条件
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetSearchDatas()
        {
            var searchDatas = new Dictionary<string, string>();

            foreach (SearchConditionItem s in SearchConditionItems)
            {
                if (s.ConditionLabel.Visibility == Visibility.Visible)
                {
                    string value = s.ConditionContent.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        searchDatas.Add(s.ConditionContent.Tag.ToString(), value);
                    }
                }
            }

            return searchDatas;
        }

        /// <summary>
        /// 计算数据条数
        /// </summary>
        public void GetRowCount()
        {
            BuildQueryStrAndParams();

            if (!string.IsNullOrEmpty(_fullQueryStr))
            {
                MethodInfo method = MySvcClientType.GetMethod("FetchCount");
                var os = new object[3];
                os[0] = _fullQueryStr;
                os[1] = _fullParameters;
                os[2] = EagerLoadPropertiesForFilter;
                _rowCount = (int)method.Invoke(MySvcClient, Flag, Type.DefaultBinder, os, null);
            }
            else
            {
                MethodInfo method = MySvcClientType.GetMethod("GetAllCount");
                _rowCount = (int)method.Invoke(MySvcClient, Flag, Type.DefaultBinder, null, null);
            }
            if (ContentId != 0)
            {
                _rowCount++;
            }
        }

        /// <summary>
        /// 获取表格要显示的数据
        /// </summary>
        /// <param name="form"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IEnumerable GetData(int form, int to)
        {
            IEnumerable searchList;
            if (SortCols == null || SortCols.Count == 0)
            {
                var sortCol = new SortCol { ByDescending = true, ColName = "Id" };
                SortCols = new List<SortCol>();
                SortCols.Add(sortCol);
            }

            MethodInfo mQuery = MySvcClientType.GetMethod("SelectByRangeWithMultiOrderLazyLoad");
            var os = new object[7];
            os[0] = _fullQueryStr;
            os[1] = _fullParameters;
            os[2] = SortCols;
            os[3] = form;
            os[4] = to;
            os[5] = EagerLoadPropertiesForFilter;
            os[6] = EagerLoadPropertiesForAppend;
            searchList = mQuery.Invoke(MySvcClient, Flag, Type.DefaultBinder, os, null) as IEnumerable;

            return searchList;
        }

        /// <summary>
        /// 构造查询的Entity SQL和参数(目前只支持模糊查询)
        /// </summary>
        private void BuildQueryStrAndParams()
        {
            var sb = new StringBuilder();
            var parameters = new List<object>();
            int num = 1;
            if (!string.IsNullOrEmpty(QueryStr))
            {
                sb.Append("(" + QueryStr + ")");
                if (Parameters != null)
                {
                    parameters.AddRange(Parameters);
                    num = Parameters.Count + 1;
                }
            }
            Dictionary<string, string> conditions = GetSearchDatas();

            foreach (var kvp in conditions)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("it." + key + " Like @p" + num + " ");
                parameters.Add("%" + value + "%");
                num++;
            }
            if (ContentId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" or ");
                }
                sb.Insert(0, " (");
                sb.Append("it.Id=" + ContentId + ") ");
            }
            if (FilterId != 0)
            {
                if (sb.Length != 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("it.Id !=" + FilterId + " ");
            }
            _fullQueryStr = sb.ToString();
            _fullParameters = parameters;
        }

        #endregion

        #region Events

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            GetRowCount();
            pagingControl.Init(_rowCount, PerRecord);
        }

        private void OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl.CurPageNo - 1) * PerRecord + e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// esc退出弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// 鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                GetSelectedItem();
            }
        }

        #endregion

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            GetSelectedItem();
        }
    }

    public class SearchConditionItem
    {
        public Label ConditionLabel { get; set; }
        public TextBox ConditionContent { get; set; }
    }
}