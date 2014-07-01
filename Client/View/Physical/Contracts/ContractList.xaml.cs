using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.View.Physical.Pricings;
using Client.View.PrintTemplate.DomesticContractTemplate;
using Client.ViewModel.Physical.Contracts;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;
using Utility.Misc;
using Client.Converters;
using System.Data;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for PurchaseContractSearch.xaml
    /// </summary>
    public sealed partial class ContractList
    {
        #region Member

        private const int RecPerPage = 10;
        private readonly bool _canEdit;
        private readonly bool _canDelete;
        private readonly bool _canView;

        #endregion

        #region Property

        public ContractListVM VM { get; set; }
        public ContractType ContractType { get; set; }

        #endregion

        #region Constructor

        public ContractList(ContractSearchConditions conditions, ContractType contractType)
        {
            InitializeComponent();
            ContractType = contractType;

            VM = new ContractListVM(conditions);
            ModuleName = ContractHomeVM.GetModuleNameByContractType(contractType);

            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            pagerContract.OnNewPage += pagerContract_OnNewPage;
            pagerContract.Init(VM.QuotaTotalCount, RecPerPage);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;

            cbSelectAll.DataContext = VM;
        }

        /// <summary>
        /// Refresh the page
        /// </summary>
        public override void Refresh()
        {
            VM.LoadQuotaCount();
            pagerContract.Init(VM.QuotaTotalCount, RecPerPage);
        }

        #endregion

        #region Event

        private void QuotaDetailViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void QuotaDetailViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var bd = new QuotaDetailView(id,ContractType, PageMode.EditMode);
            bd.ShowDialog();
            //e.Handled = true;
        }

        /// <summary>
        /// Event handler of going to new page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerContract_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.QuotaFrom = e.From;
            VM.QuotaTo = e.To;
            VM.LoadQuotas();
            dataGridQuotas.ItemsSource = VM.QuotasView;
            dataGridQuotas.Items.Refresh();
        }

        /// <summary>
        /// Set the row header with the row index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuotaGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagerContract.CurPageNo - 1) * 10 + e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// Can edit quota?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuotaEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        /// <summary>
        /// Can delete quota?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuotaDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        /// <summary>
        /// Can print contract?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintContractCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// Print contract
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintContractExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            var pct = new PrintContractTemplate(id, ModuleName);
            RedirectTo(pct);
        }

        /// <summary>
        /// Edit Quota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuotaEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;

            if (!VM.QuotaCanEditWithRel(id))
            {
                MessageBox.Show("是自动生成的单据，不能编辑!");
                return;
            }

            if (!VM.QuotaCanEditWithApproveStatus(id))
            {
                MessageBox.Show(ResContract.DuringApprovalError);
                return;
            }

            var page = VM.CreatePageByQuota(id);
            if (page != null)
            {
                RedirectTo(page);
            }
        }

        /// <summary>
        /// Delete Quota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuotaDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;

            if (!VM.QuotaCanEditWithRel(id))
            {
                MessageBox.Show("是自动生成的单据，不能作废!");
                return;
            }

            if (MessageBox.Show(Properties.Resources.NullifyConfirm, Properties.Resources.Nullify, MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                return;
            if (!VM.QuotaCanEditWithApproveStatus(id))
            {
                MessageBox.Show(ResContract.DuringApprovalError2);
                return;
            }

            try
            {
                VM.Remove(id);
                MessageBox.Show(Properties.Resources.NullifySuccessfully);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        /// <summary>
        /// Can view pricings?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PricingViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        /// <summary>
        /// View Pricings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PricingViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var pl = new PricingList(id);
            pl.ShowDialog();
            e.Handled = true;
        }

        /// <summary>
        /// Can view attachment?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// View attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (!VM.HasAttachment(id))
            {
                MessageBox.Show(Properties.Resources.NoAttachment);
                return;
            }

            var frm = new AttachmentList(id);
            frm.ShowDialog();
        }

        protected override void BasePageIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.PrintSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContractSplitCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// 拆分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractSplitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int contractId = e.Parameter is int ? (int)e.Parameter : 0;
            //判断是否能拆分

            //跳到拆分页面
            string pageName = EnumHelper.GetDescriptionByCulture(ContractType.Purchase) +
                                  EnumHelper.GetDescriptionByCulture(TradeType.ShortDomesticTrade);
            ShortContractDetail frm = new ShortContractDetail(TradeType.ShortDomesticTrade, ContractType.Purchase,contractId, DBEntity.EnumEntity.PageMode.AddMode, pageName,true);
            RedirectTo(frm);
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            VM.GetAllQuotas();
            if (VM.Quotas != null && VM.Quotas.Count > 0)
            {
                System.Windows.Forms.SaveFileDialog _sfd = new System.Windows.Forms.SaveFileDialog
                {
                    Filter = "Excel 2003 Files|xls.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = "合同.xls"
                };
                if (_sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string _localFilePath = _sfd.FileName; //获得文件路径 

                    DataTable dt = new DataTable();

                    dt.Columns.Add("QuotaNo");
                    dt.Columns.Add("ExContractNo");
                    dt.Columns.Add("BusinessPartner");
                    dt.Columns.Add("BusinessPartnerFullName");
                    dt.Columns.Add("InternalCustomer");
                    dt.Columns.Add("InternalCustomerFullName");
                    dt.Columns.Add("Commodity");
                    dt.Columns.Add("TotalBrands");
                    dt.Columns.Add("Warehouse");
                    dt.Columns.Add("ContractUDF");
                    dt.Columns.Add("ImplementedDate");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("VerQuantity");
                    dt.Columns.Add("StrPrice");
                    dt.Columns.Add("Currency");
                    dt.Columns.Add("PricingType");
                    dt.Columns.Add("PricingBasis");
                    dt.Columns.Add("PricingStartDate");
                    dt.Columns.Add("PricingEndDate");
                    dt.Columns.Add("ApproveStatus");
                    dt.Columns.Add("Approval");
                    dt.Columns.Add("ApprovalDetail");
                    dt.Columns.Add("RejectReason");
                    dt.Columns.Add("Description");

                    string QuotaNo = Properties.Resources.QuotaNo;
                    string ExContractNo = ResContract.OriginContractNo;
                    string BusinessPartner = Properties.Resources.BP;
                    string BusinessPartnerFullName = "业务伙伴全称";
                    string InternalCustomer = Properties.Resources.SignSide;
                    string InternalCustomerFullName = "内部客户全称";
                    string Commodity = Properties.Resources.Commodity;
                    string TotalBrands = Properties.Resources.Brand;
                    string Warehouse = Properties.Resources.Warehouse;
                    string ContractUDF = Properties.Resources.UDF;
                    string ImplementedDate = Properties.Resources.ImplementedDate;
                    string Quantity = Properties.Resources.Quantity;
                    string VerQuantity = "实际数量";
                    string StrPrice = Properties.Resources.Price;
                    string Currency = Properties.Resources.PricingCurrency;
                    string PricingType = Properties.Resources.PricingType;
                    string PricingBasis = Properties.Resources.PricingReference;
                    string PricingStartDate = Properties.Resources.PricingStartDate;
                    string PricingEndDate = Properties.Resources.PricingEndDate;
                    string ApproveStatus = Properties.Resources.ApprovalStatus;
                    string Approval = Properties.Resources.Approval;
                    string ApprovalDetail = Properties.Resources.ApprovalDetail;
                    string RejectReason = Properties.Resources.RejectReason;
                    string Description = "备注";

                    DataRow dr = dt.NewRow();

                    dr["QuotaNo"] = QuotaNo;
                    dr["ExContractNo"] = ExContractNo;
                    dr["BusinessPartner"] = BusinessPartner;
                    dr["BusinessPartnerFullName"] = BusinessPartnerFullName;
                    dr["InternalCustomer"] = InternalCustomer;
                    dr["InternalCustomerFullName"] = InternalCustomerFullName;
                    dr["Commodity"] = Commodity;
                    dr["TotalBrands"] = TotalBrands;
                    dr["Warehouse"] = Warehouse;
                    dr["ContractUDF"] = ContractUDF;
                    dr["ImplementedDate"] = ImplementedDate;
                    dr["Quantity"] = Quantity;
                    dr["VerQuantity"] = VerQuantity;
                    dr["StrPrice"] = StrPrice;
                    dr["Currency"] = Currency;
                    dr["PricingType"] = PricingType;
                    dr["PricingBasis"] = PricingBasis;
                    dr["PricingStartDate"] = PricingStartDate;
                    dr["PricingEndDate"] = PricingEndDate;
                    dr["ApproveStatus"] = ApproveStatus;
                    dr["Approval"] = Approval;
                    dr["ApprovalDetail"] = ApprovalDetail;
                    dr["RejectReason"] = RejectReason;
                    dr["Description"] = Description;

                    dt.Rows.Add(dr);

                    foreach (var item in VM.Quotas)
                    {
                        dr = dt.NewRow();

                        dr["QuotaNo"] = item.QuotaNo;
                        dr["ExContractNo"] = item.Contract.ExContractNo;
                        dr["BusinessPartner"] = item.Contract.BusinessPartner.ShortName;
                        dr["BusinessPartnerFullName"] = item.Contract.BusinessPartner.Name;
                        dr["InternalCustomer"] = item.Contract.InternalCustomer.ShortName;
                        dr["InternalCustomerFullName"] = item.Contract.InternalCustomer.Name;
                        dr["Commodity"] = item.Commodity.Name;
                        dr["TotalBrands"] = item.TotalBrands;
                        dr["Warehouse"] = item.Warehouse != null ? item.Warehouse.Name : "";
                        dr["ContractUDF"] = item.Contract.ContractUDF != null ? item.Contract.ContractUDF.Name : "";
                        dr["ImplementedDate"] = item.ImplementedDate.HasValue ? item.ImplementedDate.Value.ToString("yyyy-MM-dd") : "";
                        dr["Quantity"] = item.MoreBrandDetail;
                        dr["VerQuantity"] = item.VerifiedQuantity;
                        dr["StrPrice"] = item.FinalPrice;
                        dr["Currency"] = item.Currency.Name;
                        dr["PricingType"] = new PricingTypeConverter().Convert(item.PricingType, null, null, null);
                        dr["PricingBasis"] = item.PricingBasis.HasValue ? new PricingBasisConverter().Convert(item.PricingBasis, null, null, null) : "";
                        dr["PricingStartDate"] = item.PricingStartDate.HasValue ? item.PricingStartDate.Value.ToString("yyyy-MM-dd") : "";
                        dr["PricingEndDate"] = item.PricingEndDate.HasValue ? item.PricingEndDate.Value.ToString("yyyy-MM-dd") : "";
                        dr["ApproveStatus"] = new ApproveStatusConverter().Convert(item.ApproveStatus, null, null, null);
                        dr["ApprovalDetail"] = item.CustomerStrField1 + " " + item.CustomerStrField2;
                        dr["Approval"] = item.Approval != null ? item.Approval.Name : "";
                        dr["RejectReason"] = item.RejectReason;
                        dr["Description"] = item.Contract.Description;

                        dt.Rows.Add(dr);
                    }

                    RenderToExcel excelHelper = new RenderToExcel();
                    excelHelper.DataTableToExcel(dt, _localFilePath);
                }
            }
        }

        private void MoreBrandsViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        //多品牌弹出框
        private void MoreBrandsViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var pl = new MoreBrandsList(id, this.ModuleName);
            pl.ShowDialog();
            e.Handled = true;
        }
    }
}
