using System;
using System.Windows;
using System.Windows.Controls;
using Client.ViewModel.SystemSetting.UserSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.UserSetting
{
    /// <summary>
    /// LinkIC.xaml 的交互逻辑
    /// </summary>
    public sealed partial class LinkIC
    {
        #region Constructor

        public LinkIC(PageMode pageMode, int userId)
            : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "UserSetting";

            VM = new LinkICVM(userId);
            BindData();
        }

        #endregion

        #region Property

        public LinkICVM VM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Event

        protected override void BasePageLoaded(object sender, RoutedEventArgs e)
        {
            if (!CheckPerm(PageMode.EditMode))
            {
                var bt = FindName("button1") as Button;
                if (bt != null) bt.IsEnabled = false;

                bt = FindName("button2") as Button;
                if (bt != null) bt.IsEnabled = false;

                bt = FindName("button3") as Button;
                if (bt != null) bt.IsEnabled = false;

                bt = FindName("button4") as Button;
                if (bt != null) bt.IsEnabled = false;
            }

            base.BasePageLoaded(sender, e);
        }

        private void BtnAddAllocatedClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var items = listBox1.SelectedItems;
                while (items.Count > 0)
                {
                    var bp = items[0] as BusinessPartner;
                    if (bp != null)
                    {
                        VM.Link(bp);
                        Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void BtnAddNotAllocatedClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var items = listBox2.SelectedItems;
                while (items.Count > 0)
                {
                    var bp = items[0] as BusinessPartner;
                    if (bp != null)
                    {
                        VM.UnLink(bp);
                        Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            VM.Save();
            RedirectTo(new UserList());
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }

        public override void Refresh()
        {
            listBox1.Items.Refresh();
            listBox2.Items.Refresh();
        }

        #endregion
    }
}