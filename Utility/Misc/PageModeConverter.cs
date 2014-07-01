using DBEntity.EnumEntity;

namespace Utility.Misc
{
    public class PageModeConverter
    {
        public static string PageMode2Name(PageMode pageMode)
        {
            if (pageMode == PageMode.AddMode)
            {
                return "新增";
            }
            if (pageMode == PageMode.DeleteMode)
            {
                return "删除";
            }
            if (pageMode == PageMode.EditMode)
            {
                return "编辑";
            }
            if (pageMode == PageMode.ViewMode)
            {
                return "查看";
            }
            return "";
        }

        public static string PageMode2Name(string pageMode)
        {
            if (pageMode == PageMode.AddMode.ToString())
            {
                return "新增";
            }
            if (pageMode == PageMode.DeleteMode.ToString())
            {
                return "删除";
            }
            if (pageMode == PageMode.EditMode.ToString())
            {
                return "编辑";
            }
            if (pageMode == PageMode.ViewMode.ToString())
            {
                return "查看";
            }
            return "";
        }
    }
}