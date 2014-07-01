using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using DBEntity.EnumEntity;
using System.IO;
using Utility.Misc;
using Microsoft.Reporting.WinForms;
using Client.ViewModel.PrintTemplate.FinalInvoiceTemplate;
using System.Diagnostics;
using Client.ViewModel.PrintTemplate.ProvisionalInvoiceTemplate;

namespace Client.ViewModel.Physical.CommercialInvoices
{
    public class PrintCommercialInvoiceVM : BaseVM
    {
        #region Member
        private List<string> _PathList;
        private int _Id;
        private int _Type;
        private string _SelectedValue;
        #endregion

        #region Property
        public string SelectedValue
        {
            get { return _SelectedValue; }
            set { 
                if(_SelectedValue !=  value)
                {
                    _SelectedValue = value;
                    Notify("SelectedValue");
                }
            }
        }

        public int Type
        {
            get { return _Type; }
            set { 
                if(_Type != value)
                {
                    _Type = value;
                    Notify("Type");
                }
            }
        }

        public int Id
        {
            get { return _Id; }
            set { 
                if(_Id != value)
                {
                    _Id = value;
                    Notify("Id");
                }
            }
        }

        public List<string> PathList
        {
            get { return _PathList; }
            set { 
                if(_PathList != value)
                {
                    _PathList = value;
                    Notify("PathList");
                }
            }
        }
        #endregion

        #region Contructor
        public PrintCommercialInvoiceVM(int commercialInvoiceId, int commercialInvoiceType)
        {
            Id = commercialInvoiceId;
            Type = commercialInvoiceType;
            GetPathList(Type);
        }
        #endregion

        #region Method
        public void PrintCommercialInvoice(string documentName)
        {

            string dirPath = "ReportOutput";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            if (Type == (int)CommercialInvoiceType.Final|| Type == (int)CommercialInvoiceType.FinalCommercial)
            {
                string name = EnumHelper.GetDescriptionByCulture(PrintTemplateType.FinalInvoiceTemplate);
                var rptVM = new FinalInvoiceTemplateVM(Id);
                string pathName = @"PrintTemplate\" + name + "\\" + documentName;
                var localReport = new LocalReport { ReportPath = pathName };
                localReport.DataSources.Add(new ReportDataSource("Head", rptVM.HeaderList));
                localReport.DataSources.Add(new ReportDataSource("Lines", rptVM.LCPropertyList));
                var output = localReport.Render("EXCEL");
                string fileName = "FinalInvoice" + Id + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                var fs = new FileStream(dirPath + "\\" + fileName, FileMode.Create);
                fs.Write(output, 0, output.Length);
                fs.Flush();
                fs.Close();

                Process.Start(dirPath + "\\" + fileName);
            }
            else if (Type == (int)CommercialInvoiceType.Provisional)
            {
                string name = EnumHelper.GetDescriptionByCulture(PrintTemplateType.ProvisionalInvoiceTemplate);

                var rptVM = new ProvisionalInvoiceTemplateVM(Id);
                string pathName = @"PrintTemplate\" + name + "\\" + documentName;
                var localReport = new LocalReport { ReportPath = pathName };
                localReport.DataSources.Add(new ReportDataSource("Head", rptVM.HeaderList));
                var output = localReport.Render("EXCEL");
                string fileName = "ProvisionalInvoice" + Id + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                var fs = new FileStream(dirPath + "\\" + fileName, FileMode.Create);
                fs.Write(output, 0, output.Length);
                fs.Flush();
                fs.Close();

                Process.Start(dirPath + "\\" + fileName);
            }

        }

        public void GetPathList(int commercialInvoiceType)
        {
            if (commercialInvoiceType == (int)CommercialInvoiceType.Final || commercialInvoiceType == (int)CommercialInvoiceType.FinalCommercial)
            {
                PathList = GetTemplateNamesByType(PrintTemplateType.FinalInvoiceTemplate);
            }
            else if (commercialInvoiceType == (int)CommercialInvoiceType.Provisional)
            {
                PathList = GetTemplateNamesByType(PrintTemplateType.ProvisionalInvoiceTemplate);
            }

            if(PathList != null && PathList.Count > 1)
            {
                SelectedValue = PathList[0];
            }
        }

        public List<string> GetTemplateNamesByType(PrintTemplateType ptt)
        {
            var templates = new List<string>();
            string templatePath = GetTemplateDirectory(ptt);
            if (templatePath == string.Empty)
                return templates;
            string[] fileNames = Directory.GetFiles(templatePath);
            if (!fileNames.Any())
                return templates;
            templates.AddRange(fileNames.Select(Path.GetFileName));
            return templates;
        }

        private String GetTemplateDirectory(PrintTemplateType ptt)
        {
            string[] di = Directory.GetDirectories(Directory.GetCurrentDirectory(), "PrintTemplate");
            if (!di.Any())
                return string.Empty;
            string[] dii = Directory.GetDirectories(di[0], EnumHelper.GetDescription(ptt));
            if (!dii.Any())
                return string.Empty;
            return dii[0];
        }
        #endregion
    }
}
