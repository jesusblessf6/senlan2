using System;
using System.Windows;
using Client.ViewModel.Console.ApprovalCenter;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Console.ApprovalCenter
{
    /// <summary>
    /// Interaction logic for RejectReason.xaml
    /// </summary>
    public sealed partial class RejectReason
    {
        #region Property

        public RejectReasonVM VM { get; set; }

        #endregion

        #region Constructor

        public RejectReason(int id, string tableCode)
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = "ApprovalCenter";
            VM = new RejectReasonVM(id, tableCode);
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
                VM.Reject();
                MessageBox.Show(Properties.Resources.OperationSucceed);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
            
        }

        #endregion
    }
}
