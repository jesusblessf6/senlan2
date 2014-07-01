using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Reporting.WinForms;

namespace Client.Helper
{
    public class PrintHelper : IDisposable
    {
        private readonly LocalReport _localReport;
        private int _mCurrentPageIndex;
        private IList<Stream> _mStreams;
        private readonly bool _isLandscape;
        private string _fileName;

        public PrintHelper(Dictionary<string, object> dataSourceMap, string rdlcPath, string fileName = "", bool isLandscape = false)
        {
            _localReport = new LocalReport {ReportPath = rdlcPath};
            _isLandscape = isLandscape;
            _fileName = fileName;

            foreach (var o in dataSourceMap)
            {
                _localReport.DataSources.Add(new ReportDataSource(o.Key, o.Value));
            }
        }

        public void Dispose()
        {
            if (_mStreams != null)
            {
                foreach (Stream stream in _mStreams)
                    stream.Close();
                _mStreams = null;
            }
        }

        public void Run()
        {
            Export();
            _mCurrentPageIndex = 0;
            Print();
        }

        private void Export()
        {
            const string deviceInfo = "<DeviceInfo>" +
                                      "  <OutputFormat>EMF</OutputFormat>" +
                                      "</DeviceInfo>";
            Warning[] warnings;
            _mStreams = new List<Stream>();
            _localReport.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in _mStreams)
                stream.Position = 0;
        }

        private Stream CreateStream(string name, string extension, Encoding encoding, string mimetype, bool willseek)
        {
            Stream stream = new MemoryStream();
            _mStreams.Add(stream);
            return stream;
        }

        private void Print()
        {
            var printDoc = new PrintDocument();
            //printDoc.PrinterSettings.PrinterName = "Microsoft Office Document Image Writer";
            if (_mStreams == null || _mStreams.Count == 0)
                return;

            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer.");
                MessageBox.Show(msg, "Print Error");
                return;
            }
            printDoc.PrintPage += PrintPage;
            printDoc.DefaultPageSettings.Landscape = _isLandscape;
            if (!string.IsNullOrWhiteSpace(_fileName))
            {
                printDoc.DocumentName = _fileName;
            }
            
            printDoc.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            var pageImage = new Metafile(_mStreams[_mCurrentPageIndex]);
            e.Graphics.DrawImage(pageImage, e.PageBounds);

            _mCurrentPageIndex++;
            e.HasMorePages = (_mCurrentPageIndex < _mStreams.Count);
        }
    }
}