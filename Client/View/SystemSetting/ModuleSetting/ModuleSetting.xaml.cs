using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.ModuleSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.ModuleSetting
{
    /// <summary>
    /// Interaction logic for ModuleSetting.xaml
    /// </summary>
    public sealed partial class ModuleSetting
    {
        #region Members

        private readonly ModuleSettingVM _moduleSettingVM;

        #endregion

        #region Property

        public ModuleSettingVM ModuleSettingVM
        {
            get { return _moduleSettingVM; }
        }

        #endregion

        #region Constructor

        public ModuleSetting(PageMode pageMode)
            : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            _moduleSettingVM = new ModuleSettingVM();
            _moduleSettingVM.Load();

            BindData();
        }

        public ModuleSetting()
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            _moduleSettingVM = new ModuleSettingVM();
            _moduleSettingVM.Load();

            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            tvModule.ItemsSource = _moduleSettingVM.Modules;
            lbSelectedModuleName.DataContext = _moduleSettingVM;
            dgModuleDetails.ItemsSource = _moduleSettingVM.ModuleDetails;
        }

        public override void Refresh()
        {
            _moduleSettingVM.Load();
            BindData();

            tvModule.Items.Refresh();
            dgModuleDetails.Items.Refresh();

            base.Refresh();
        }

        #endregion

        #region Event

        private void TvModuleSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is ModuleTreeItem)
            {
                _moduleSettingVM.CurrentSelection = (ModuleTreeItem) e.NewValue;
            }
            else
            {
                _moduleSettingVM.CurrentSelection = null;
            }

            _moduleSettingVM.LoadModuleDetails();
            _moduleSettingVM.LoadSelectedModuleName();

            dgModuleDetails.ItemsSource = null;
            dgModuleDetails.ItemsSource = _moduleSettingVM.ModuleDetails;
            dgModuleDetails.Items.Refresh();

            Application.Current.Properties["SelectedTreeItem"] = _moduleSettingVM.CurrentSelection;
        }

        private void ChangePermCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ChangePermCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var moduleId = (int) e.Parameter;
            var mp = new ModulePermSetting(moduleId, PageMode.EditMode);
            mp.Show();
            e.Handled = true;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var cd = new CategoryDetail(PageMode.AddMode);
            cd.Show();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var md = new ModuleDetail(PageMode.AddMode);
            md.Show();
        }

        private void EditModuleCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void EditModuleCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var moduleId = (int) e.Parameter;
            var md = new ModuleDetail(moduleId, PageMode.EditMode);
            md.Show();
            e.Handled = true;
        }

        private void ViewModuleCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ViewModuleCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var moduleId = (int) e.Parameter;
            var md = new ModuleDetail(moduleId, PageMode.ViewMode);
            md.Show();
            e.Handled = true;
        }

        private void DeleteModuleCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = true;
            e.CanExecute = true;
        }

        private void DeleteModuleCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var moduleId = (int) e.Parameter;
            var md = new ModuleDetail(moduleId, PageMode.DeleteMode);
            md.Show();

            e.Handled = true;
        }

        private void DgModuleDetailsLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        #endregion
    }
}