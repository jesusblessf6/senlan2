   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   /   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      7   1Client.View.Physical.WarehouseIns.WarehouseInList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   /   6
Convertersclr-namespace:Client.Converters     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$6  0Client.View.Physical.WarehouseIns.ResWarehouseIn��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *WarehouseInList+ � 	Resources 5      +  %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseInEdit  WarehouseInDelete  WarehouseInPrint  WarehouseInActions �� DataType �� Orientation   ResxName
   Key  WarehouseInAction��%�  &	        &	      &	 &     &	 9     &	 L     7  7  &	 �    7    5   
   6)   �� 5   
   62   �� 5   
   64   �� 5   
   63   �� 5   
   $ DBEntity:WarehouseIn��62   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btWarehouseInEdit��6   8��  ��62     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btWarehouseInDelete��6   8�� ��64     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5      �� 5   
   $ DBEntity:WarehouseIn��61   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btPrint��6   8��  ��6(     $! Client.Properties.Resources��$ Print����5       �� *Id+6;   5!      5"      5#       J� CommandBindings 5%      )  #System.Windows.Input.CommandBinding  5&   
   -   5        	   Command#	 [ 5&      5'   >     5(   
   -   5        #	 [ 5(      5)   @     5*   
   -   5        #	 [ 5*      5+   ?   .��5.      �� $
��Auto=�6   $
��Auto=�68   .��5/   
   � -   5        $��rootGrid��5/      .+�50      �� -   5        $��lbTitle��50   5   $��32��6D   $
��Left=�6P   $��6,6,0,0q�6k   $
��auto��6|   $	��Top=�51      $
��Bold"�6,   $��16(�6>   ��50        *WarehouseInList+51   >   �� 52      $ 
Horizontal=�6   $��6,40,0,0q�62   $
��Left=�6D   $
��Auto��6_   $
��Auto��6l   $	��Top=�6z   .+�53      $   Utility.Controls.PagingControl  -   5        
  Name$
 pagerContract��53   #   $
��Left=�6:   $	��Top=�6U   �� 54      -   5        $��10,0,0,0q�54      $��打印入库单��6+   $��23��6O   $y�	Collapsed=�6[   6t   55      &   System.Windows.Controls.DataGrid  57      -   5          Name$ warehouseInGrid��57   )   $��6,77,0,0q�6      AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[ 6u     DataGridRowStyle   RowStyle# [ 6�      
IsReadOnly . $
��Left=�58   )   $	��Top=�6D      RowDetailsVisibilityMode$ Visible=�6\      Columns 59      4  .System.Windows.Controls.DataGridTemplateColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6-      
IsReadOnly .    Header 5;      �� 5<      -	   5        $��cbSelectAll��5<   I   $��全选��6\   $��Center=�6i   $��Center=�6�   $y�Hidden=�6�    d� 	IsChecked 6'   �� *IsSelectAll+6�      CellTemplate 5>      �� 5?      $ DBEntity:WarehouseIn��6+   .R�5@   "   �� $��Center=�6�   $��Center=�6�   $y�Hidden=�6�    6+   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{�6q   �� *	Printable+6�   5A      5C      0
  *System.Windows.Controls.DataGridTextColumn
  5D       6)     $6 0Client.View.Physical.WarehouseIns.ResWarehouseIn��$ WarehouseInDate��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *WarehouseInDate+ �� StringFormat$ 
yyyy/MM/dd��
  5E       6)     $! Client.Properties.Resources��$ 	Warehouse�� 6m   �� *Warehouse.Name+
  5F       6)     $! Client.Properties.Resources��$ QuantityConfirm�� 6s   �� *
IsVerified+ �� 	Converter# [  
  5G       6)     $! Client.Properties.Resources��$ Comments�� 6l   �� *	Comment+  5H      $
 Auto	 6q      CanUserSort .  # [ 5I   9      
Visibility$ 	Collapsed=�6k    5H   -     $! Client.Properties.Resources��$ 	Operation��5I   �      RowDetailsTemplate 5K      �� 5L      $ DBEntity:WarehouseIn��6#   .R�5M        $��dataGridDetail��6#    .   .   . $��6,2,0,15q�5N   h   ��5M   9   �� *WarehouseInLines+ 5O      
  5P   "    65     $! Client.Properties.Resources��$ Supplier�� 5Q   5   �� *@>DeliveryLine.Delivery.Quota.Contract.BusinessPartner.ShortName+6�   
  5R   "    65     $! Client.Properties.Resources��$ InternalCustomer�� 5S   5   �� *A?DeliveryLine.Delivery.Quota.Contract.InternalCustomer.ShortName+6�   
  5T   "   $ 卡号��65    6A   �� *PBNo+6\   
  5U   "    65     $! Client.Properties.Resources��$ 	Commodity�� 5V   5   �� *,*DeliveryLine.Delivery.Quota.Commodity.Name+6v   
  5W   "    65     $! Client.Properties.Resources��$ Brand�� 6u   �� *
Brand.Name+6�   
  5X   "    65     $! Client.Properties.Resources��$ Quantity�� 6x   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 6�   
  5Y   "    65     $! Client.Properties.Resources��$ ActualQuantity�� 6~   �� *VerifiedQuantity+# Z 6�   
  5Z   "    65     $! Client.Properties.Resources��$ QuantityConfirm�� 5[   5   �� *
IsVerified+# [  6�   
  5\   "    65     $! Client.Properties.Resources��$ Comments�� 6x   �� *	Comment+6�     5]   "   $
 Auto	 6}    .  # [ 5^   9    5]   9     $! Client.Properties.Resources��$ 	Operation��5^   n   5`      5a      5c      5d      5e      5f      