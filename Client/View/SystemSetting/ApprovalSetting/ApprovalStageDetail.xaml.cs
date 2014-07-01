using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Client.View.PopUpDialog;
using Client.ViewModel.SystemSetting.ApprovalSetting;
using DBEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.ApprovalSetting
{
    /// <summary>
    /// Interaction logic for ApprovalStageDetail.xaml
    /// </summary>
    public partial class ApprovalStageDetail
    {
        #region Property

        public ApprovalStageDetailVM VM { get; set; }

        #endregion

        #region Constructor

        public ApprovalStageDetail(List<ApprovalStage> stages)
        {
            InitializeComponent();
            VM = new ApprovalStageDetailVM(stages);
            BindData();
        }

        #endregion

        #region Event

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// when the window closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovalStageDetailClosing(object sender, CancelEventArgs e)
        {
            Owner.Activate();
            Owner.IsEnabled = true;
        }

        /// <summary>
        /// Save approval stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(textBox1).Count > 0)
            {
                MessageBox.Show(ResApprovalSetting.NoInputWrong);
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
        /// Pop-up window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var dialog = PopDialogCreater.CreateDialog("User");
            dialog.ShowDialog();
            var user = dialog.SelectedItem as User;
            if (user == null) return;
            VM.UserId = user.Id;
            VM.UserName = user.Name;
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