﻿#pragma checksum "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EFA78B71CE794F5BF0815BF7047C4162"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
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


namespace Client.View.Physical.Deliveries {
    
    
    /// <summary>
    /// DeliveryList
    /// </summary>
    public partial class DeliveryList : Client.Base.BaseClient.BasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rootGrid;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Utility.Controls.PagingControl pagerDelivery;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid deliveryGrid;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbSelectAll;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;component/view/physical/deliveries/deliverylist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 50 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.DeliveryEditCanExecute);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeliveryEditExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 53 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeliveryPrintExecuted);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 54 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.DeliveryLineDeleteCanExecute);
            
            #line default
            #line hidden
            
            #line 55 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeliveryLineDeleteExecuted);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 56 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ShowCirculDetailCanExecute);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ShowCirculDetailExecuted);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 58 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.MDViewCanExecute);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MDViewExecuted);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 61 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ConvertWRCanExecute);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ConvertWRExecuted);
            
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
            this.pagerDelivery = ((Utility.Controls.PagingControl)(target));
            return;
            case 10:
            
            #line 75 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.deliveryGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 79 "..\..\..\..\..\..\View\Physical\Deliveries\DeliveryList.xaml"
            this.deliveryGrid.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DeliveryGridLoadingRow);
            
            #line default
            #line hidden
            return;
            case 12:
            this.cbSelectAll = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

