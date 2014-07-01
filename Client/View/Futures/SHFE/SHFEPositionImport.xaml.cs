using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Client.ViewModel.Futures.SHFE;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Input;

namespace Client.View.Futures.SHFE
{
    /// <summary>
    /// Interaction logic for SHFEPositionImport.xaml
    /// </summary>
    public partial class SHFEPositionImport
    {
        #region Property

        public SHFEPositionImportVM VM { get; set; }

        #endregion
        public SHFEPositionImport()
        {
            InitializeComponent();
            VM = new SHFEPositionImportVM();
            Bind();
        }

        public void Bind()
        {
            rootGrid.DataContext = VM;
        }

        private OpenFileDialog _dialog;
        /// <summary>
        /// 选择对账单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            _dialog = new OpenFileDialog {Filter = "Excel Files|*.xls;*.xlsx", Multiselect = false};
            _dialog.ShowDialog();
            if (_dialog.FileName != string.Empty)
            {
                VM.FileName = _dialog.FileName;
            }
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_dialog == null || _dialog.FileName == string.Empty)
                {
                    MessageBox.Show(ResSHFE.StatementRequired);
                }
                else
                {
                    Stream stream = _dialog.OpenFile();
                    VM.ImportPosition((FileStream)stream);
                    MessageBox.Show(ResSHFE.ImportComplete);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
