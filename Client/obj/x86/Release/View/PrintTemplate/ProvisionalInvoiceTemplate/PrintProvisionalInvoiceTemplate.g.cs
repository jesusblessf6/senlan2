﻿#pragma checksum "..\..\..\..\..\..\View\PrintTemplate\ProvisionalInvoiceTemplate\PrintProvisionalInvoiceTemplate.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A22AFA3D30CB51C85D833F394A0F99F"
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
using Infralution.Localization.Wpf;
using Microsoft.Reporting.WinForms;
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


namespace Client.View.PrintTemplate.ProvisionalInvoiceTemplate {
    
    
    /// <summary>
    /// PrintProvisionalInvoiceTemplate
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class PrintProvisionalInvoiceTemplate : Client.Base.BaseClient.BasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\..\View\PrintTemplate\ProvisionalInvoiceTemplate\PrintProvisionalInvoiceTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rootGrid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\..\View\PrintTemplate\ProvisionalInvoiceTemplate\PrintProvisionalInvoiceTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost windowsFormsHost1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\..\View\PrintTemplate\ProvisionalInvoiceTemplate\PrintProvisionalInvoiceTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Reporting.WinForms.ReportViewer invoiceReport;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/view/printtemplate/provisionalinvoicetemplate/printprovisionali" +
                    "nvoicetemplate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\PrintTemplate\ProvisionalInvoiceTemplate\PrintProvisionalInvoiceTemplate.xaml"
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
            this.rootGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.windowsFormsHost1 = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 3:
            this.invoiceReport = ((Microsoft.Reporting.WinForms.ReportViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

