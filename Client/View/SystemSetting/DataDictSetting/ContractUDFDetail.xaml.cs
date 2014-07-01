using Client.ViewModel.SystemSetting.DataDictSetting;
using DBEntity.EnumEntity;
using System.Windows;
using System;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// 交互逻辑
    /// </summary>
    public sealed partial class ContractUDFDetail
    {
        #region Constructor

        public ContractUDFDetail()
            : base(PageMode.ViewMode, Properties.Resources.UDF)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new ContractUDFDetailVM();
            BindData();
        }

        public ContractUDFDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.UDF)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new ContractUDFDetailVM();
            BindData();
        }

        public ContractUDFDetail(PageMode pageMode, int portId)
            : base(pageMode, Properties.Resources.UDF)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";

            VM = new ContractUDFDetailVM(portId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        private void BtnSave(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (((ContractUDFDetailVM)VM).Validate())
                {
                    VM.Save();
                    MessageBox.Show(Properties.Resources.SaveSuccessfully);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
    }
}