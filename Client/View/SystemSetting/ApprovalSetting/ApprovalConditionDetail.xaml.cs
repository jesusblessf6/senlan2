using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Client.ViewModel.SystemSetting.ApprovalSetting;
using DBEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.ApprovalSetting
{
    /// <summary>
    /// Interaction logic for ApprovalConditionDetailVM.xaml
    /// </summary>
    public partial class ApprovalConditionDetail
    {
        #region Property

        public ApprovalConditionDetailVM VM { get; set; }

        #endregion

        #region Constructor

        public ApprovalConditionDetail(List<ApprovalCondition> conditions)
        {
            InitializeComponent();
            VM = new ApprovalConditionDetailVM(conditions);
            BindData();
        }

        #endregion

        #region Event

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Save Condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(textBox1).Count > 0)
            {
                MessageBox.Show(ResApprovalSetting.CeilingInputWrong);
                return;
            }

            if (Validation.GetErrors(textBox2).Count > 0)
            {
                MessageBox.Show(ResApprovalSetting.FloorInputWrong);
                return;
            }

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

        /// <summary>
        /// When window closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowClosing(object sender, CancelEventArgs e)
        {
            Owner.Activate();
            Owner.IsEnabled = true;
        }

        #endregion

        #region Method

        /// <summary>
        /// Bind Data
        /// </summary>
        public void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion
    }
}