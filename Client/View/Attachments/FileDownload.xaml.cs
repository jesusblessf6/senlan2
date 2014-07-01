using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Client.UploadServiceReference;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;
using Utility.ServiceManagement;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Client.View.Attachments
{
    /// <summary>
    /// Interaction logic for FileDownload.xaml
    /// </summary>
    public partial class FileDownload
    {
        private BackgroundWorker _bgWorker;
        private string _fileNameExt;
        private string _localFilePath;
        private SaveFileDialog _sfd;
        private bool _workState;

        public FileDownload(string fileName)
        {
            InitializeComponent();
            FileName = fileName;
        }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        private void ShowDownloadDialog()
        {
            _sfd = new SaveFileDialog
                       {
                           Filter = "All Files|*.*",
                           FilterIndex = 1,
                           RestoreDirectory = true,
                           FileName = GetRealFileName(FileName)
                       };
            if (_sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _localFilePath = _sfd.FileName; //获得文件路径 
                _fileNameExt = _localFilePath.Substring(_localFilePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                //获取文件名，不带路径
                _bgWorker.RunWorkerAsync();
            }
            else
            {
                Close();
            }
        }

        private string GetRealFileName(string name)
        {
            string realName = string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
            {
                string fileName = GetFileName(name);
                string fex = GetFex(fileName);
                int index = fileName.LastIndexOf("_", StringComparison.Ordinal);
                string realFileName = fileName.Substring(0, index);
                realName = realFileName + "." + fex;
            }
            return realName;
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

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            if (FileName == null)
            {
                MessageBox.Show(ResAttachment.FileNotFound);
                Close();
            }
            else
            {
                _bgWorker = new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
                _bgWorker.DoWork += BgWorkerDoWork;
                _bgWorker.RunWorkerCompleted += BgWorkerRunWorkerCompleted;
                _bgWorker.ProgressChanged += BgWorkerProgressChanged;
                ShowDownloadDialog();
            }
        }

        private void BgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _workState = false;
            using (
                var client =
                    SvcClientManager.GetSvcClient<UploadServiceClient>(SvcType.UploadSvc))
            {
                Stream stream = _sfd.OpenFile();
                var file = new FileUploadMessage {Name = _fileNameExt, SaveName = FileName};
                file = client.DownloadFile(file);

                try
                {
                    if (!file.FindFile)
                    {
                        _bgWorker.CancelAsync();
                        MessageBox.Show(ResAttachment.FileNotFound);
                        return;
                    }
                    if (file.Data != null)
                    {
                        stream.Position = 0;
                        stream.Write(file.Data, 0, file.Data.Length);
                        e.Result = file.Data.Length;
                        _bgWorker.ReportProgress((int) ((file.Offset/(double) (file.Length))*100),
                                                 file.Offset + file.Data.Length);
                        if (_bgWorker.CancellationPending)
                            return;

                        while (file.Length > file.Offset)
                        {
                            file.Data = null;
                            stream.Position = file.Offset;
                            file = client.DownloadFile(file);
                            stream.Write(file.Data, 0, file.Data.Length);
                            e.Result = file.Offset;
                            _bgWorker.ReportProgress((int) ((file.Offset/(double) (file.Length))*100),
                                                     file.Offset + file.Data.Length);
                            if (_bgWorker.CancellationPending)
                                return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        private void BgWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            percent.Content = e.ProgressPercentage.ToString(CultureInfo.InvariantCulture) + "%";
        }

        private void BgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _workState = false;
            if (e.Error == null)
            {
                MessageBox.Show(ResAttachment.DownloadComplete, Properties.Resources.Reminder);
            }
            else
            {
                MessageBox.Show(e.Error.ToString());
            }
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (_workState)
            {
                _bgWorker.CancelAsync();
                Thread.Sleep(1000);
                File.Delete(_localFilePath);
                MessageBox.Show(ResAttachment.DownloadCancelled);
            }
            _workState = false;
            Close();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            Process.Start(_localFilePath);
        }
    }
}