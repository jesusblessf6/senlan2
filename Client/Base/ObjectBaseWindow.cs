using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Client.Converters;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ClientException;
using Utility.ErrorManagement;

namespace Client.Base
{
    public abstract class ObjectBaseWindow : BaseWindow
    {
        #region Property

        public string PageName { get; set; }

        public string ActionName { get; set; }

        public virtual BaseVM VM { get; set; }

        #endregion

        #region Constructor

        protected ObjectBaseWindow()
        {
            var pmc = new PageModeConverter();
            ActionName = (string) pmc.Convert(PageMode, typeof (string), null, null);
            PageName = (PageName ?? string.Empty) + "-" + ActionName;
        }

        protected ObjectBaseWindow(PageMode pageMode, string objectName)
            : base(pageMode)
        {
            PageName = objectName;
            var pmc = new PageModeConverter();
            ActionName = (string) pmc.Convert(PageMode, typeof (string), null, null);
            PageName += "-" + ActionName;
        }

        #endregion

        #region Event

        protected override void BaseWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (PageMode == PageMode.ViewMode || PageMode == PageMode.DeleteMode)
            {
                Visual visualChild = GetVisualChild(0);
                if (visualChild != null) visualChild.SetValue(IsEnabledProperty, false);
            }

            var title = (Label) FindName("lbTitle");
            if (title != null) title.Content = PageName;

            try
            {
                base.BaseWindowLoaded(sender, e);
            }
            catch (NoPermException ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                Close();
                return;
            }
            Title = PageName;
        }

        protected virtual void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PageValidate())
                {
                    VM.Save();
                    MessageBox.Show(GetSuccessMessage());
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        protected virtual void SaveAsDraft(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PageValidate())
                {
                    VM.SaveAsDraft();
                    MessageBox.Show(GetSuccessMessage());
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        protected void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        #region Method

        public string GetSuccessMessage()
        {
            return ActionName + Properties.Resources.Success;
        }

        #endregion
    }
}
