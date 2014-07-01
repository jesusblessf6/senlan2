﻿#pragma checksum "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "78757E5D1316E499190323C892392C4D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client.Base.BaseClient;
using Client.Converters;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Client.View.Console.ApprovalCenter {
    
    
    /// <summary>
    /// ApprovalCenterHome
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ApprovalCenterHome : Client.Base.BaseClient.BasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rootGrid;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid quotaGrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid1;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid2;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgPaymentRequest;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dbVATInvoiceRequestLine;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;component/view/console/approvalcenter/approvalcenterhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 41 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.QuotaApproveCanExecute);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.QuotaApproveExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 42 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.QuotaRejectCanExecute);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.QuotaRejectExecuted);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 44 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.PaymentRequestApproveCanExecute);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PaymentRequestApproveExecuted);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 45 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.PaymentRequestRejectCanExecute);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PaymentRequestRejectExecuted);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 47 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.VATInvoiceRequestLineApproveCanExecute);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.VATInvoiceRequestLineApproveExecuted);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 48 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.VATInvoiceRequestLineRejectCanExecute);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.VATInvoiceRequestLineRejectExecuted);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rootGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.lbTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.quotaGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.dataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 63 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            this.dataGrid1.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.PurchaseQuotasLoadingRow);
            
            #line default
            #line hidden
            return;
            case 12:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.dataGrid2 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 120 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            this.dataGrid2.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.SalesQuotasLoadingRow);
            
            #line default
            #line hidden
            return;
            case 14:
            this.dgPaymentRequest = ((System.Windows.Controls.DataGrid)(target));
            
            #line 173 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            this.dgPaymentRequest.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.PaymentRequestsLoadingRow);
            
            #line default
            #line hidden
            return;
            case 15:
            this.dbVATInvoiceRequestLine = ((System.Windows.Controls.DataGrid)(target));
            
            #line 253 "..\..\..\..\..\..\View\Console\ApprovalCenter\ApprovalCenterHome.xaml"
            this.dbVATInvoiceRequestLine.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.VATInvoiceRequestLinesLoadingRow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

