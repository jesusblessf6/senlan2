using System;
using System.Windows;
using Client.ViewModel.SystemSetting.ModuleSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.ModuleSetting
{
    /// <summary>
    /// Interaction logic for ModulePermSetting.xaml
    /// </summary>
    public sealed partial class ModulePermSetting
    {
        #region Property

        public ModulePermSettingVM VM { get; set; }

        #endregion

        #region Constructor

        public ModulePermSetting()
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            VM = new ModulePermSettingVM();
            BindData();
        }

        public ModulePermSetting(int moduleId, PageMode pageMode)
            : base(pageMode)
        {
            InitializeComponent();
            ModuleName = "ModuleSetting";
            VM = new ModulePermSettingVM(moduleId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Event

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                MessageBox.Show("更新成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }

            Close();
        }

        #endregion
    }
}