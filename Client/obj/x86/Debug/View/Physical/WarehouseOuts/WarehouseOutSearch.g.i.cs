﻿#pragma checksum "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3DEE89C3AD30050A7EB2EFD1B21138D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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


namespace Client.View.Physical.WarehouseOuts {
    
    
    /// <summary>
    /// WarehouseOutSearch
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class WarehouseOutSearch : Client.Base.BaseClient.BasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rootGrid;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Utility.Controls.PagingControl pagerContract;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid warehouseOutGrid;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Client;component/view/physical/warehouseouts/warehouseoutsearch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
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
            
            #line 40 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.WarehouseOutCanExecute);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.WarehouseOutEditExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 42 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.WarehouseOutCanExecute);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.WarehouseOutDeleteExecuted);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 44 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.WarehouseOutCanExecute);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PrintWarehouseOutExecuted);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 46 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.WarehouseOutCanExecute);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.WarehouseOutPrintExecuted);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rootGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.lbTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.pagerContract = ((Utility.Controls.PagingControl)(target));
            return;
            case 8:
            
            #line 58 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 59 "..\..\..\..\..\..\View\Physical\WarehouseOuts\WarehouseOutSearch.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonPrintWarehouseOutClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.warehouseOutGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.cbSelectAll = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
