using System;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Console.ApprovalCenter;
using System.Windows;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Console.ApprovalCenter
{
	/// <summary>
	/// Interaction logic for ApprovalCenterHome.xaml
	/// </summary>
	public sealed partial class ApprovalCenterHome
	{
		#region Property

		public ApprovalCenterHomeVM VM { get; set; }

		#endregion

		#region Constructor

		public ApprovalCenterHome() : base(PageMode.ViewMode)
		{
			InitializeComponent();

			VM = new ApprovalCenterHomeVM();
			ModuleName = "ApprovalCenter";
			BindData();
		}

		#endregion

		#region Method

		public override void BindData()
		{
			rootGrid.DataContext = VM;
		}

		public override void Refresh()
		{
			VM.LoadPurchaseQuotas();
			dataGrid1.Items.Refresh();

			VM.LoadSalesQuotas();
			dataGrid2.Items.Refresh();

			VM.LoadPaymentRequests();
			dgPaymentRequest.Items.Refresh();

			VM.LoadVATInvoiceRequestLines();
			dbVATInvoiceRequestLine.Items.Refresh();

			VM.LoadBPApproveLines();
			bpApproveLines.Items.Refresh();
		}

		#endregion

		#region Event

		private void QuotaApproveCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void QuotaApproveExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			try
			{
				var id = (int)e.Parameter;
				VM.ApproveQuota(id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
				return;
			}
			
			Refresh();
			e.Handled = true;
		}

		private void QuotaRejectCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void QuotaRejectExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var id = (int) e.Parameter;
			var rr = new RejectReason(id, "Quota");
			rr.Show();
			e.Handled = true;
		}

		private void PurchaseQuotasLoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
		{
			e.Row.Header = e.Row.GetIndex() + 1;
		}

		private void SalesQuotasLoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
		{
			e.Row.Header = e.Row.GetIndex() + 1;
		}

		private void PaymentRequestsLoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
		{
			e.Row.Header = e.Row.GetIndex() + 1;
		}

		private void PaymentRequestApproveCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void PaymentRequestApproveExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var id = (int) e.Parameter;
			try
			{
				VM.ApprovePaymentRequest(id);
				MessageBox.Show(ResApprovalCenter.ApprovalPass);
				Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
				return;
			}
			
			e.Handled = true;
		}

		private void PaymentRequestRejectCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void PaymentRequestRejectExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var id = (int)e.Parameter;
			var rr = new RejectReason(id, "PaymentRequest");
			rr.Show();
			e.Handled = true;
		}

		private void VATInvoiceRequestLinesLoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
		{
			e.Row.Header = e.Row.GetIndex() + 1;
		}

		private void VATInvoiceRequestLineApproveCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void VATInvoiceRequestLineRejectCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void VATInvoiceRequestLineApproveExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var id = (int) e.Parameter;
			try
			{
				VM.ApproveVATInvoiceRequestLine(id);
				MessageBox.Show(ResApprovalCenter.ApprovalPass);
				Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
				return;
			}
			
			e.Handled = true;
		}

		private void VATInvoiceRequestLineRejectExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var id = (int)e.Parameter;
			var rr = new RejectReason(id, "VATInvoiceRequestLine");
			rr.Show();
			e.Handled = true;
		}

		#endregion

		private void BPApproveLinesLoadingRow(object sender, DataGridRowEventArgs e)
		{
			e.Row.Header = e.Row.GetIndex() + 1;
		}

		private void BPApproveCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.Handled = true;
			e.CanExecute = true;
		}

		private void BPRejectCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.Handled = true;
			e.CanExecute = true;
		}

		private void BPApproveExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var id = (int)e.Parameter;
			try
			{
				VM.ApproveBP(id);
				MessageBox.Show(ResApprovalCenter.ApprovalPass);
				Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
				return;
			}
			e.Handled = true;
		}

		private void BPRejectExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var id = (int)e.Parameter;
			var rr = new RejectReason(id, "BusinessPartner");
			rr.Show();
			e.Handled = true;
		}
	}
}
