   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  6@   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      5    /Client.View.Console.MonitorCenter.MonitorCenter   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     6@   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Console.MonitorCenter.ResMonitorCenter��5       � Language 5	      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *MonitorCenter+ � 	Resources 5      ,   &Client.Converters.PricingTypeConverter   PricingTypeConverter��%   &	          5   
   6@   5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5      $��32��5   3   $
��Left=�6?   $��6,6,0,0q�6Z   $	��Top=�5   #   $
��Bold"�6;   $��16(�6M   $
��auto��6[   ��5        *MonitorCenter+5   [   �� 5      -   5        $��tabControl1��5   T   $
��Auto��6   $
��Left=�6'   $��6,40,0,0q�6B   $	��Top=�5      $
��Auto��61   .@�5      �� -   5        $��tabItem1��5   9   ��6     *PricingMonitor+.��5      � .+�5      &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5   #      AutoGenerateColumns .  $
��Auto��5   ?   $
��Left=�6M   $��6,6,0,0q�6h   $	��Top=�5   4   $
��Auto��6L     DataGridStyle#��[ 5   H     DataGridRowStyle   RowStyle# [ 5   #      
IsReadOnly . $	��500��5   D   ��5   #   �� *PricingLines+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5    "     DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [ 65   	   CanUserSort	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 5#   H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5!   5   �� *	QuotaNo+   Header 5"   5        ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��5$   #     5%   "   # [ 65   	 . $

 Auto 5(   H    5&   5   �� *BPName+ 5'   5     $! Client.Properties.Resources��$ BP��5)   #     5*   "   # [ 65   	 . $

 Auto 5-   H    5+   5   �� *QuotaQuantity+$	  DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY �� StringFormat# Z  5,   5     $! Client.Properties.Resources��$ Quantity��5.   #     5/   "   # [ 65   	 . $

 Auto 52   H    50   5   �� *UnpricedQuantity+# Z  51   5     $! Client.Properties.Resources��$ UnpricingQuantity��53   #     54   "   # [ 65   	 . $

 Auto 57   H    55   5   �� *PricingTypeId+ �� 	Converter# [   56   5     $! Client.Properties.Resources��$ PricingType��58   #     59   "   # [ 65   	 . $

 Auto 5<   H    5:   5   �� *	StartDate+$ 
yyyy-MM-dd�� 5;   5     $! Client.Properties.Resources��$ PricingStartDate��5=   #     5>   "   # [ 65   	 . $

 Auto 5A   H    5?   5   �� *	EndDate+$ 
yyyy-MM-dd�� 5@   5     $! Client.Properties.Resources��$ PricingEndDate��5B   #     5C   "   # [ 65   	 . $

 Auto 5F   H    5D   5   �� *InternalCustomerName+ 5E   5     $! Client.Properties.Resources��$ InternalCustomer��5G   #     5H   "   # [ 65   	 . $

 Auto 5K   H    5I   5   �� *
DaysRemain+ 5J   5     $8 2Client.View.Console.MonitorCenter.ResMonitorCenter��$ 
DaysRemain��5L   #   5N      5O      5P      5Q      5R      5S      5T      