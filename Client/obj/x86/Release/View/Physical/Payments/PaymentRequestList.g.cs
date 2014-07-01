﻿#pragma checksum "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5A75F53D5EB211F1C2C92AA000D5EC83"
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
using Utility.Controls;


namespace Client.View.Physical.Payments {
    
    
    /// <summary>
    /// PaymentRequestList
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class PaymentRequestList : Client.Base.BaseClient.BasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rootGrid;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Utility.Controls.PagingControl pagingControl1;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid contractGrid;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbSelectAll;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/view/physical/payments/paymentrequestlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
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
            
            #line 35 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.PaymentRequestEditCanExecute);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PaymentRequestEditExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 37 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.PaymentRequestDeleteCanExecute);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PaymentRequestDeleteExecuted);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 39 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.PaymentRequestPrintCanExecute);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PaymentRequestPrintExecuted);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rootGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.pagingControl1 = ((Utility.Controls.PagingControl)(target));
            return;
            case 6:
            
            #line 49 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.contractGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 55 "..\..\..\..\..\..\View\Physical\Payments\PaymentRequestList.xaml"
            this.contractGrid.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DataGrid1LoadingRow);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cbSelectAll = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

