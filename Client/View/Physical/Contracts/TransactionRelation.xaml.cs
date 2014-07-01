using System;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel.Physical.Contracts;
using Client.ContractServiceReference;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for TransactionRelation.xaml
    /// </summary>
    public partial class TransactionRelation
    {
        #region Member

        #endregion

        #region Property
        public TransactionRelationVM VM { get; set; }
        #endregion

        #region Constructor

        public TransactionRelation()
        {
            InitializeComponent();
            VM = new TransactionRelationVM();
            BindData();
        }

        public TransactionRelation(RelQuota rel)
        {
            InitializeComponent();
            VM = new TransactionRelationVM(rel);
            BindData();
        }

        #endregion

        #region Event
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// esc退出弹出框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            VM.Cancel();
            Close();
        }
        #endregion

        #region Method
        private void BindData()
        {
            rootGrid.DataContext = VM;
        }


        #endregion
    }
}
