﻿#pragma checksum "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "06CDA9FA07DFD096A66898EDFDAEBE30"
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


namespace Client.View.Physical.ForeignDeliveryPools {
    
    
    /// <summary>
    /// ForeignDeliveryPoolList
    /// </summary>
    public partial class ForeignDeliveryPoolList : Client.Base.BaseClient.ListBasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rootGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Utility.Controls.PagingControl pager;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid entityList;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/view/physical/foreigndeliverypools/foreigndeliverypoollist.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
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
            
            #line 22 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ListEditCanExecute);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ListEditExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ListDeleteCanExecute);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
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
            
            #line 33 "..\..\..\..\..\..\View\Physical\ForeignDeliveryPools\ForeignDeliveryPoolList.xaml"
            this.entityList.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.OnLoadRowIndex);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

