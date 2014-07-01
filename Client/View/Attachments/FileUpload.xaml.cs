using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Client.UploadServiceReference;
using Utility.ServiceManagement;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace Client.View.Attachments
{
    /// <summary>
    /// Interaction logic for FileUpload.xaml
    /// </summary>
    public partial class FileUpload
    {
        private BackgroundWorker _bgWorker;
        private OpenFileDialog _dialog;
        private string _fileName;
        private string _filePath;
        private string _newName;
        private bool _workState;

        public FileUpload()
        {
            InitializeComponent();
            SaveFile = false;
        }

        public string Header { get; set; }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public string SavePath { get; set; }
        public bool SaveFile { get; set; }

        /// <summary>
        /// 选择附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectClick(object sender, RoutedEventArgs e)
        {
            _dialog = new OpenFileDialog {Filter = "All Files|*.*", Multiselect = false};
            _dialog.ShowDialog();
            if (_dialog.FileName != string.Empty)
            {
                _filePath = _dialog.FileName;
                _fileName = GetFileName(_filePath);
                _newName = GetNewFileName(_fileName);
                txtFile.Text = _fileName;
                txtFile.ToolTip = _filePath;
            }
        }

        public static string GetNewFileName(string fileName)
        {
            string fex = GetFex(fileName);
            string name = fileName.Substring(0, fileName.LastIndexOf(".", StringComparison.Ordinal));
            name += "_" + Guid.NewGuid().ToString();
            string newName = name + "." + fex;
            return newName;
        }

        /// <summary>  
        /// 获取文件名称  
        /// </summary>  
        /// <param name="path">路径</param>  
        /// <returns></returns>  
        public static string GetFileName(String path)
        {
            if (path.Contains("\\"))
            {
                string[] arr = path.Split('\\');
                return arr[arr.Length - 1];
            }
            else
            {
                string[] arr = path.Split('/');
                return arr[arr.Length - 1];
            }
        }

        /// <summary>  
        /// 获取文件后缀名  
        /// </summary>  
        /// <param name="filename">文件名</param>  
        /// <returns></returns>  
        public static String GetFex(string filename)
        {
            return filename.Substring(filename.LastIndexOf(".", StringComparison.Ordinal) + 1);
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _bgWorker = new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
            _bgWorker.DoWork += BgWorkerDoWork;
            _bgWorker.RunWorkerCompleted += BgWorkerRunWorkerCompleted;
            _bgWorker.ProgressChanged += BgWorkerProgressChanged;
        }

        private void BgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (_dialog == null || _dialog.FileName == string.Empty)
            {
                MessageBox.Show(ResAttachment.SelectFirst);
                _workState = false;
                return;
            }
            using (
                var client =
                    SvcClientManager.GetSvcClient<UploadServiceClient>(SvcType.UploadSvc))
            {
                const int maxSiz = 1024*10; //设置每次传10k
                Stream stream = _dialog.OpenFile();
                var file = new FileUploadMessage
                               {Name = _dialog.SafeFileName, SaveName = _newName, Length = stream.Length};
                try
                {
                    //循环的读取文件,上传，直到文件的长度等于文件的偏移量
                    if (file.Length <= 0) 
                    {
                        _workState = false;
                        SaveFile = false;
                        MessageBox.Show(ResAttachment.EmptyFile);
                        return;
                    }
                    while (file.Length != file.Offset)
                    {
                        //设置传递的数据的大小
                        file.Data = new byte[file.Length - file.Offset <= maxSiz ? file.Length - file.Offset : maxSiz];
                        stream.Position = file.Offset; //设置本地文件数据的读取位置
                        stream.Read(file.Data, 0, file.Data.Length); //把数据写入到file.Data中
                        file = client.UploadFile(file); //上传
                        e.Result = file.Offset;
                        SavePath = file.SavePath;
                        _bgWorker.ReportProgress((int) ((file.Offset/(double) (file.Length))*100), file.Offset);
                        if (_bgWorker.CancellationPending)
                            return;
                    }
                    SaveFile = true;
                }
                catch (Exception)
                {
                    throw;
                    //MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        private void BgWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void BgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             if (_workState == false)
                {
                    return;
                }
                if (e.Error == null)
                {
                    MessageBox.Show(ResAttachment.UploadComplete + e.Result + ResAttachment.Byte, Properties.Resources.Reminder);
                    _workState = false;
                    Close();
                }
                else
                {
                    MessageBox.Show(e.Error.Message);
                }
            _workState = false;
        }

        /// <summary>
        /// 取消上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            if (_workState)
            {
                DialogResult result = MessageBox.Show(ResAttachment.CancelConfirm, ResAttachment.UploadFile, MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    _bgWorker.CancelAsync();
                    _workState = false;
                    FileName = string.Empty;
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// 开始上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClick(object sender, RoutedEventArgs e)
        {
            if (!_bgWorker.IsBusy)
            {
                _workState = true;
                _bgWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show(ResAttachment.Uploading);
            }
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            if (_workState)
            {
                DialogResult dialogResult = MessageBox.Show(ResAttachment.CloseConfirm, ResAttachment.Warning, MessageBoxButtons.OKCancel);
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    _bgWorker.CancelAsync();
                    FileName = string.Empty;
                    Close();
                }
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