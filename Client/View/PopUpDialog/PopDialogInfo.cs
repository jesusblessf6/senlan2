using System;
using System.Collections.Generic;
using Utility.ServiceManagement;
using Utility.Misc;

namespace Client.View.PopUpDialog
{
    public class PopDialogInfo
    {
        public List<ColumnInfo> Columns { get; set; }
        public string Title { get; set; }
        public Dictionary<string, string> Conditions { get; set; }
        public Type SvcClientType { get; set; }
        public SvcType ServiceType { get; set; }
        public List<string> EagerLoadListForFilter { get; set; }
        public string InnerQueryStr { get; set; }
        public List<SortCol> SortCols { get; set; }
        //public string OrderBy { get; set; }
        //public string OrderType { get; set; }
        public bool SelectedMode { get; set; }
        public List<string> EagerLoadListForAppend { get; set; }
    }
}
