using System;
using System.Collections.Generic;
using System.Windows;
using Client.ViewModel.SystemSetting.CommissionSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.CommissionSetting
{
    /// <summary>
    /// Interaction logic for CommissionLineDetail.xaml
    /// </summary>
    public sealed partial class CommissionLineDetail
    {
        public CommissionLineDetail(PageMode pageMode, List<CommissionLine> allLines, List<CommissionLine> addLines,
                                    bool isDefault, int internalCustomerId, int customerId)
            : base(pageMode, ResCommissionSetting.CommissionLineDetail)
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            VM = new CommissionLineDetailVM(addLines, allLines, isDefault, internalCustomerId, customerId);
            BindData();
        }

        public CommissionLineDetail(int id, PageMode pageMode, List<CommissionLine> allLines,
                                    List<CommissionLine> addLines, List<CommissionLine> updateLines, bool isDefault,
                                    int internalCustomerId, int customerId)
            : base(pageMode, ResCommissionSetting.CommissionLineDetail)
        {
            InitializeComponent();
            ModuleName = "CommissionSetting";
            VM = new CommissionLineDetailVM(id, addLines, allLines, updateLines, isDefault, internalCustomerId,
                                               customerId);
            BindData();
        }

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}