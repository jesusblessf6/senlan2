using System.Windows.Input;
using Client.View.Attachments;
using Client.ViewModel.Physical.Contracts;
using DBEntity;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for AttachmentList.xaml
    /// </summary>
    public sealed partial class AttachmentList
    {
        public AttachmentListVM VM { get; set; }
        #region Constructor
        public AttachmentList()
        {
            InitializeComponent();
        }

        public AttachmentList(int contractId)
        {
            InitializeComponent();
            VM=new AttachmentListVM(contractId);
            BindData();
        }

        public AttachmentList(int id,string code)
        {
            InitializeComponent();
            VM = new AttachmentListVM(id,code);
            BindData();
        }
        #endregion

        public void BindData()
        {
            rootGrid.DataContext = VM;
            dataGridAttachment.Items.Refresh();
        }

        private void AttachmentDownLoadCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// 下载附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentDownLoadExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            Attachment attachment = VM.GetAttachmentById(id);
            if(attachment!=null)
            {
                var frm = new FileDownload(attachment.FileName);
                frm.ShowDialog();
            }
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
