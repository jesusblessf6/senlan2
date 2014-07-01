using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel.Physical.Pricings;
using Client.ViewModel.PrintTemplate.PricingConfirmationTemplate;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Microsoft.Reporting.WinForms;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Physical.Pricings
{
    /// <summary>
    /// Interaction logic for ManualPricingList.xaml
    /// </summary>
    public sealed partial class ManualPricingList
    {
        #region Member

        private const int RecPerPage = 10;
        private readonly bool _canEdit;
        private readonly bool _canDelete;

        #endregion

        #region Property

        public ManualPricingListVM VM { get; set; }

        #endregion

        #region Constructor

        public ManualPricingList(ManualPricingSearchConditions cons)
        {
            InitializeComponent();
            ModuleName = "Pricing";
            VM = new ManualPricingListVM(cons);

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);

            pagingControl1.OnNewPage += PagingControl1OnOnNewPage;
            pagingControl1.Init(VM.QuotaCount, RecPerPage);
        }

        #endregion

        #region Event

        private void PagingControl1OnOnNewPage(object sender, PagingEventArgs e)
        {
            VM.QuotaFrom = e.From;
            VM.QuotaTo = e.To;
            VM.Load();
            rootGrid.DataContext = VM;
            dataGrid1.ItemsSource = VM.Quotas;
            dataGrid1.Items.Refresh();
        }

        private void PricingEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void PricingDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void PricingPrintCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void PricingEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var mpd = new ManualPricingDetail(PageMode.EditMode, id);
            mpd.Show();
            e.Handled = true;
        }

        private void PricingDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var id = (int)e.Parameter;
                try
                {
                    VM.DeletePricing(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                }
            }
            e.Handled = true;
        }

        private void PricingPrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var rptVM = new PricingConfirmationVM(id);
            var localReport = new LocalReport { ReportPath = rptVM.PathName };
            localReport.DataSources.Add(new ReportDataSource("Head", rptVM.HeaderList));
            var output = localReport.Render("EXCEL");
            string fileName = "ManualPricing" + id + "-" + DateTime.Now.ToString("yyyyMMddhhmmss")+ ".xls";
            string dirPath = "ReportOutput";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var fs = new FileStream(dirPath + "\\" + fileName, FileMode.Create);
            fs.Write(output, 0, output.Length);
            fs.Flush();
            fs.Close();
            Process.Start(dirPath + "\\" + fileName);
        }
        private void PricingsLoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            var p = (Pricing)e.Row.Item;
            if (p != null)
            {
                e.Row.Visibility = (p.IsDeleted || p.IsDraft) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void UnpricingsLoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            var p = (Unpricing)e.Row.Item;
            if (p != null)
            {
                e.Row.Visibility = (p.IsDeleted || p.UnpricingQuantity <= 0) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void UnpricingEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void UnpricingEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            if (!VM.IsUnpricingEditable(id))
            {
                MessageBox.Show(ResPricing.OriginalUnpricingLimit);
                return;
            }

            var pd = new PricingDefer(PageMode.EditMode, id);
            pd.Show();
            e.Handled = true;
        }

        private void UnpricingDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void UnpricingDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            if (!VM.IsUnpricingEditable(id))
            {
                MessageBox.Show(ResPricing.OriginalUnpricingLimit2);
                return;
            }

            if (MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteUnpricing(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                }
            }
            e.Handled = true;
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.ItemsSource = VM.Quotas;
        }

        public override void Refresh()
        {
            VM.LoadCount();
            pagingControl1.Init(VM.QuotaCount, RecPerPage);
        }

        #endregion
    }
}
