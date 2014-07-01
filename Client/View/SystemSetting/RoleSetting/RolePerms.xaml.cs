using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Client.ViewModel.SystemSetting.RoleSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.RoleSetting
{
    /// <summary>
    /// Interaction logic for RolePerms.xaml
    /// </summary>
    public sealed partial class RolePerms
    {
        #region Property

        public RolePermsVM VM { get; set; }

        #endregion

        #region Constructor

        public RolePerms() : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";

            VM = new RolePermsVM(0);
            VM.Load();
            BindData();
        }

        public RolePerms(int roleId)
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";

            VM = new RolePermsVM(roleId);
            VM.Load();
            BindData();
        }

        public RolePerms(int roleId, PageMode pageMode)
            : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "RoleSetting";

            VM = new RolePermsVM(roleId);
            VM.Load();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            var c = new ListCollectionView(VM.PermLines);
            if (c.GroupDescriptions != null) c.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));

            dataGrid1.ItemsSource = c;
            dataGrid1.Items.Refresh();
        }

        #endregion

        #region Event

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            GoBackOrHome();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show(Properties.Resources.SaveSuccessfully);
                GoBackOrHome();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        protected override void BasePageLoaded(object sender, RoutedEventArgs e)
        {
            if (PageMode == PageMode.ViewMode)
            {
                var grid = FindName("rootGrid") as Grid;
                if (grid != null) grid.IsEnabled = false;
            }
            base.BasePageLoaded(sender, e);
        }

        #endregion
    }
}