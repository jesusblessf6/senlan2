   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5    /Client.View.Console.MonitorCenter.MonitorCenter   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Console.MonitorCenter.ResMonitorCenter�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *MonitorCenter+ � 	Resources ,   &Client.Converters.PricingTypeConverter   PricingTypeConverter��%   &	          .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(�$
��auto����  *MonitorCenter+�� -   $��tabControl1��$
��Auto��$
��Left=�$��6,40,0,0q�$	��Top=�$
��Auto��.@��� -   $��tabItem1����  *PricingMonitor+.��� .+�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Auto��  DataGridStyle#��[   DataGridRowStyle   RowStyle# [    
IsReadOnly . $	��500������ *PricingLines+   Columns 0  *System.Windows.Controls.DataGridTextColumn    DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [ 	   CanUserSort	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	QuotaNo+   Header      ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��  # [ 	 . $

 Auto  �� *BPName+   $! Client.Properties.Resources��$ BP��  # [ 	 . $

 Auto  �� *QuotaQuantity+$	  DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY �� StringFormat# Z    $! Client.Properties.Resources��$ Quantity��  # [ 	 . $

 Auto  �� *UnpricedQuantity+# Z    $! Client.Properties.Resources��$ UnpricingQuantity��  # [ 	 . $

 Auto  �� *PricingTypeId+ �� 	Converter# [     $! Client.Properties.Resources��$ PricingType��  # [ 	 . $

 Auto  �� *	StartDate+$ 
yyyy-MM-dd��   $! Client.Properties.Resources��$ PricingStartDate��  # [ 	 . $

 Auto  �� *	EndDate+$ 
yyyy-MM-dd��   $! Client.Properties.Resources��$ PricingEndDate��  # [ 	 . $

 Auto  �� *InternalCustomerName+   $! Client.Properties.Resources��$ InternalCustomer��  # [ 	 . $

 Auto  �� *
DaysRemain+   $8 2Client.View.Console.MonitorCenter.ResMonitorCenter��$ 
DaysRemain��