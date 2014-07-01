using System;
using System.Windows.Data;

namespace Client.View.PopUpDialog
{
    public class ColumnInfo
    {
        public String Header { get; set; }
        public String Path { get; set; }
        public String RenderType { get; set; }
        public bool? Visibility { get; set; }
        public IValueConverter Converter { get; set; }
        public string StringFormat { get; set; }
    }
}
