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
    /// Interaction logic for LinkCommodity.xaml
    /// </summary>
    public sealed partial class LinkCommodity
    {
        #region Constructor

        public LinkCommodity(PageMode pageMode, int userId) : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "UserSetting";

            VM = new LinkCommodityVM(userId);
            BindData();
        }

        #endregion

        #region Property

        public LinkCommodityVM VM { get; set; }

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
                DisableItemByName("button1");
                DisableItemByName("button2");
                DisableItemByName("button3");
                DisableItemByName("button4");
            }

            base.BasePageLoaded(sender, e);
        }

        private void BtnAddAllocatedClick(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = listBox1.SelectedItem;
                var commodity = item as Commodity;
                if (commodity != null)
                {
                    VM.Link(commodity);
                    Refresh();
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
                object item = listBox2.SelectedItem;
                var commodity = item as Commodity;
                if (commodity != null)
                {
                    VM.UnLink(commodity);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                RedirectTo(new UserList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
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