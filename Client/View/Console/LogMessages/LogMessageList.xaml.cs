using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel.Console.LogMessages;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using Utility.QueryManagement;

namespace Client.View.Console.LogMessages
{
    /// <summary>
    /// Interaction logic for LogMessageList.xaml
    /// </summary>
    public sealed partial class LogMessageList
    {
        #region Property

        public override int RecPerPage
        {
            get
            {
                return 20;
            }
        }

        #endregion

        #region Constructor

        public LogMessageList()
            : base("LogMessage")
        {
            InitializeComponent();
            VM = new LogMessageListVM(new List<QueryElement>());
        }

        #endregion

        #region Event

        private void MarkAsReadCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void MarkAsReadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int) e.Parameter;
            try
            {
                ((LogMessageListVM)VM).MarkAsRead(id);
                MessageBox.Show(Properties.Resources.OperationSucceed);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }
        #endregion
    }
}
