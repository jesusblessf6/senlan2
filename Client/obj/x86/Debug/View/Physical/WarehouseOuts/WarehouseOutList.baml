   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   0   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      9   3Client.View.Physical.WarehouseOuts.WarehouseOutList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   0   6
Convertersclr-namespace:Client.Converters     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *WarehouseOutList+ � 	Resources 5      +  %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseOutEdit  WarehouseOutDelete  PrintWarehouseOut  WarehouseOutPrint  WarehouseOutActions �� DataType �� Orientation   ResxName
   Key  WarehouseOutAction��%  &	        &	      &	 &     &	 9     &	 L     &	 _     7  7  &	 �    7    5   
   6)   �� 5   
   63   �� 5   
   65   �� 5   
   64   �� 5   
   64   �� 5   
   $ DBEntity:WarehouseOutLine��63   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btWarehouseOutEdit��6   8��  ��63     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btWarehouseOutDelete��6   8�� ��65     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5      �� 5   
   $ DBEntity:WarehouseOutLine��62   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btWarehouseOutPrint��6C   $��	出库单��6   $��Right=�6'   8��  ��5       �� *Id+6h   5!      5"      5#       J� CommandBindings 5%      )  #System.Windows.Input.CommandBinding  5&   
   -   5        	   Command#	 [ 5&      5'   ?     5(   
   -   5        #	 [ 5(      5)   A     5*   
   -   5        #	 [ 5*      5+   @     5,   
   -   5        #	 [ 5,      5-   @   .��50      �� $
��Auto=�6   $
��Auto=�68   .��51   
   � -   5        $��rootGrid��51      .+�52      �� -   5        $��lbTitle��52   6   $��32��6E   $
��Left=�6Q   $��6,6,0,0q�6l   $
��auto��6}   $	��Top=�53      $
��Bold"�6,   $��16(�6>   ��52        *WarehouseOutList+53   >   �� 55      $ 
Horizontal=�6   $��6,40,0,0q�62   $
��Auto��6D   $	��Top=�6R   $
��Left=�6j   $
��Auto��6�   .+�56      $   Utility.Controls.PagingControl  -   5        
  Name$
 pager��56   #   $
��Left=�63   $	��Top=�57   !   �� 58      -   5        $��打印提单��58      $��10,0,0,0q�6(   $��23��6N   6\   �� 59      -	   5        $��打印出库单��59      $��10,0,0,0q�6)   $y�	Collapsed=�6`   6y   5:      &   System.Windows.Controls.DataGrid  5<      -
   5          Name$ 
entityList��5<   )   $��6,77,0,0q�6      AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[ 6p     DataGridRowStyle   RowStyle# [ 6�   $
��auto��6�   $	��750��6�   $	��Top=�5=      $
��Left=�6+      RowDetailsVisibilityMode$ Visible=�6F      Columns 5>      4  .System.Windows.Controls.DataGridTemplateColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6-      
IsReadOnly .    Header 5@      �� 5A      -   5        $��cbSelectAll��5A   I   $��全选��6\   $��Center=�6i   $��Center=�6�    d� 	IsChecked 6'   �� *IsSelectAll+6�      CellTemplate 5C      �� 5D      $ DBEntity:WarehouseOut��6+   .R�5E   "   �� $��Center=�6�   $��Center=�6�    6+   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{�6q   �� *	Printable+6�   5F      5H      0
  *System.Windows.Controls.DataGridTextColumn
  5I       .  6;     $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6}   �� *Quota.QuotaNo+
  5J       .  6;     $! Client.Properties.Resources��$ Buyer�� 6{   �� **(Quota.Contract.BusinessPartner.ShortName+6�   
  5K       .  6;     $! Client.Properties.Resources��$ InternalCustomer�� 6�   �� *+)Quota.Contract.InternalCustomer.ShortName+6�   
  5L       .  6;     $! Client.Properties.Resources��$ WarehouseOutNo�� 6�   �� *WarehouseOutNo+6�   
  5M       .  6;     $8 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ WarehouseOutDate�� 6�   �� *WarehouseOutDate+ �� StringFormat$ 
yyyy/MM/dd��6�   
  5N       .  6;     $! Client.Properties.Resources��$ 	Warehouse�� 6   �� *Warehouse.Name+6�   
  5O       .  6;     $! Client.Properties.Resources��$ 	Commodity�� 6   �� *Quota.Commodity.Name+6�   
  5P       .  6;     $! Client.Properties.Resources��$ QuantityConfirm�� 6�   �� *
IsVerified+ �� 	Converter# [  6�   
  5Q       .  6;     $! Client.Properties.Resources��$ Comments�� 6~   �� *	Comment+6�     5R         
Visibility$ 	Collapsed=�6-    . $
 Auto	 6�      CanUserSort .  # [ 5S   5    5R   V     $! Client.Properties.Resources��$ 	Operation��5S   j      RowDetailsTemplate 5U      �� 5V      $ DBEntity:WarehouseOut��6#   .R�5W      �� $
��Auto=�6'   $
��Auto=�6L   $	��0,0q�6o   $
��Left=�5X      .��5Y        $��dataGridDetail��6'   $	��680��6g    .   .     
IsReadOnly . $��6,2,0,15q�5Z   f   ��5Y   =   �� *WarehouseOutLines+ 5[   "   
  5\   &   $ 卡号��69    6E   �� *WarehouseInLine.PBNo+6p   
  5]   &    69     $! Client.Properties.Resources��$ CommodityType�� 6�   �� *CommodityType.Name+6�   
  5^   &    69     $! Client.Properties.Resources��$ Brand�� 6y   �� *
Brand.Name+6�   
  5_   &    69     $! Client.Properties.Resources��$ Quantity�� 6|   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 6�   
  5`   &    69     $! Client.Properties.Resources��$ ActualQuantity�� 6�   �� *VerifiedQuantity+# Z 6�   
  5a   &    69     $! Client.Properties.Resources��$ QuantityConfirm�� 5b   5   �� *
IsVerified+# [  6�   
  5c   &    69     $! Client.Properties.Resources��$ Comments�� 6|   �� *	Comment+6�     5d   &   $
 Auto	 6�    .  # [ 5e   9    5d   =     $! Client.Properties.Resources��$ 	Operation��5e   o   5g      5h      5i      5k      5l      5m      5n      