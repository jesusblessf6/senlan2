   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 7   1Client.View.Physical.WarehouseIns.WarehouseInList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$6  0Client.View.Physical.WarehouseIns.ResWarehouseIn�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *WarehouseInList+ � 	Resources +  %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseInEdit  WarehouseInDelete  WarehouseInPrint  WarehouseInActions �� DataType �� Orientation   ResxName
   Key  WarehouseInAction��%  &	        &	      &	 
     &	      &	      7  7  &	 $    7    �� �� �� �� $ DBEntity:WarehouseIn��.R��� $ 
Horizontal=�.+��� $��btWarehouseInEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btWarehouseInDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:WarehouseIn��.R��� $ 
Horizontal=�.+��� $��btPrint��8��  ��  $! Client.Properties.Resources��$ Print������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [   -   #	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *WarehouseInList+�� $ 
Horizontal=�$��6,40,0,0q�$
��Left=�$
��Auto��$
��Auto��$	��Top=�.+�$   Utility.Controls.PagingControl  -   
  Name$
 pagerContract��$
��Left=�$	��Top=��� -   $��10,0,0,0q�$��打印入库单��$��23��$y�	Collapsed=�&   System.Windows.Controls.DataGrid  -     Name$ warehouseInGrid��$��6,77,0,0q�   AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[   DataGridRowStyle   RowStyle# [    
IsReadOnly . $
��Left=�$	��Top=�   RowDetailsVisibilityMode$ Visible=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	    
IsReadOnly .    Header �� -	   $��cbSelectAll��$��全选��$��Center=�$��Center=�$y�Hidden=� d� 	IsChecked �� *IsSelectAll+   CellTemplate �� $ DBEntity:WarehouseIn��.R��� $��Center=�$��Center=�$y�Hidden=� �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *	Printable+0
  *System.Windows.Controls.DataGridTextColumn
     $6 0Client.View.Physical.WarehouseIns.ResWarehouseIn��$ WarehouseInDate��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *WarehouseInDate+ �� StringFormat$ 
yyyy/MM/dd��
     $! Client.Properties.Resources��$ 	Warehouse�� �� *Warehouse.Name+
     $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+ �� 	Converter# [  
     $! Client.Properties.Resources��$ Comments�� �� *	Comment+  $
 Auto	    CanUserSort .  # [    
Visibility$ 	Collapsed=�   $! Client.Properties.Resources��$ 	Operation��   RowDetailsTemplate �� $ DBEntity:WarehouseIn��.R�  $��dataGridDetail�� .   .   . $��6,2,0,15q����� *WarehouseInLines+ 
     $! Client.Properties.Resources��$ Supplier�� �� *@>DeliveryLine.Delivery.Quota.Contract.BusinessPartner.ShortName+
     $! Client.Properties.Resources��$ InternalCustomer�� �� *A?DeliveryLine.Delivery.Quota.Contract.InternalCustomer.ShortName+
  $ 卡号�� �� *PBNo+
     $! Client.Properties.Resources��$ 	Commodity�� �� *,*DeliveryLine.Delivery.Quota.Commodity.Name+
     $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+
     $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 
     $! Client.Properties.Resources��$ ActualQuantity�� �� *VerifiedQuantity+# Z 
     $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+# [  
     $! Client.Properties.Resources��$ Comments�� �� *	Comment+  $
 Auto	  .  # [    $! Client.Properties.Resources��$ 	Operation��