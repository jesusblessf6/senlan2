﻿#pragma checksum "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DBE9C5AC142B549806238454DDB03690"
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


namespace Client.View.Finance.FundFlows {
    
    
    /// <summary>
    /// FundFlowList
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class FundFlowList : Client.Base.BaseClient.ListBasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rootGrid;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Utility.Controls.PagingControl pager;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid entityList;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/view/finance/fundflows/fundflowlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
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
            
            #line 32 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ListEditCanExecute);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ListEditExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 33 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ListDeleteCanExecute);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ListDeleteExecuted);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rootGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.lbTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.pager = ((Utility.Controls.PagingControl)(target));
            return;
            case 6:
            this.entityList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 44 "..\..\..\..\..\..\View\Finance\FundFlows\FundFlowList.xaml"
            this.entityList.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.OnLoadRowIndex);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

