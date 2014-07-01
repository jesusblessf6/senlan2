using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Client.Base.BaseClientVM;
using Client.Converters;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ClientException;
using Utility.ErrorManagement;

namespace Client.Base.BaseClient
{
    public abstract class ObjectBasePage : BasePage
    {
        #region Property

        public string PageName { get; set; }
        public string ActionName { get; set; }
        public virtual BaseVM VM { get; set; }

        #endregion

        #region Constructor

        protected ObjectBasePage()
        {
            var pmc = new PageModeConverter();
            ActionName = (string) pmc.Convert(PageMode, typeof (string), null, null);
            PageName = (PageName ?? string.Empty) + "-" + ActionName;
        }

        protected ObjectBasePage(PageMode pageMode, string objectName)
            : base(pageMode)
        {
            PageName = objectName;
            var pmc = new PageModeConverter();
            ActionName = (string) pmc.Convert(PageMode, typeof (string), null, null);
            PageName +=  "-" + ActionName;
        }

        #endregion

        #region Event

        protected override void BasePageLoaded(object sender, RoutedEventArgs e)
        {
            SetItemStatusByPageMode();

            var findName = (Label) FindName("lbTitle");
            if (findName != null)
            {
                findName.Content = PageName;
            }

            try
            {
                base.BasePageLoaded(sender, e);
            }
            catch (NoPermException ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                GoBackOrHome();
                return;
            }
            Title = PageName;
        }

        protected virtual void SetItemStatusByPageMode()
        {
            if (PageMode == PageMode.ViewMode || PageMode == PageMode.DeleteMode)
            {
                Visual visualChild = GetVisualChild(0);
                if (visualChild != null)
                    visualChild.SetValue(IsEnabledProperty, false);
            }
        }

        protected virtual void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PageValidate())
                {
                    VM.Save();
                    AfterSave();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        protected virtual void AfterSave()
        {
            MessageBox.Show(GetSuccessMessage());
            GoBackOrHome();
        }

        protected virtual void SaveAsDraft(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PageValidate())
                {
                    VM.SaveAsDraft();
                    MessageBox.Show(GetSuccessMessage());
                    GoBackOrHome();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        protected virtual void Cancel(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }

        #endregion

        #region Method

        public string GetSuccessMessage()
        {
            return ActionName + Properties.Resources.Success;
        }

        public override void BindData()
        {
            var root = FindName("rootGrid") as Grid;
            if (root != null)
            {
                root.DataContext = VM;
            }
        }

        #endregion
    }
}

