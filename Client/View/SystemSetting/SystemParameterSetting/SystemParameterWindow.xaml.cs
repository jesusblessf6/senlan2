using System;
using System.Windows;
using System.Windows.Controls;
using Client.ViewModel.SystemSetting.SystemParameterSetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.SystemParameterSetting
{
    /// <summary>
    /// Interaction logic for SystemParameterWindow.xaml
    /// </summary>
    public sealed partial class SystemParameterWindow
    {
        #region Constrcutor

        public SystemParameterWindow()
            : base(PageMode.EditMode)
        {
            InitializeComponent();
            ModuleName = "SystemParameterSetting";
            VM = new SystemParameterVM();
            BindData();
        }

        #endregion

        #region Property

        public SystemParameterVM VM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validation.GetErrors(textBox1).Count > 0)
                {
                    throw new Exception("批次货运状态参数配置输入有误！");
                }

                if (Validation.GetErrors(textBox2).Count > 0)
                {
                    throw new Exception("报关提单/内贸提单货运状态参数配置输入有误！");
                }

                if (Validation.GetErrors(textBox3).Count > 0)
                {
                    throw new Exception("点价数量误差参数输入有误！");
                }
                
                VM.Save();
                MessageBox.Show("保存信息成功!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
        #endregion

        #region Method

        public override void Refresh()
        {
            VM.LoadSystemParameters();
        }

        #endregion
    }
}