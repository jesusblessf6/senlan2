   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 9   3Client.View.Physical.WarehouseOuts.WarehouseOutList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *WarehouseOutList+ � 	Resources +  %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseOutEdit  WarehouseOutDelete  PrintWarehouseOut  WarehouseOutPrint  WarehouseOutActions �� DataType �� Orientation   ResxName
   Key  WarehouseOutAction��%  &	        &	      &	 
     &	      &	      &	      7  7  &	 0    7    �� �� �� �� �� $ DBEntity:WarehouseOutLine��.R��� $ 
Horizontal=�.+��� $��btWarehouseOutEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btWarehouseOutDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:WarehouseOutLine��.R��� $ 
Horizontal=�.+��� $��btWarehouseOutPrint��$��	出库单��$��Right=�8��  ���� *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [   -   #	 [   -   #	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *WarehouseOutList+�� $ 
Horizontal=�$��6,40,0,0q�$
��Auto��$	��Top=�$
��Left=�$
��Auto��.+�$   Utility.Controls.PagingControl  -   
  Name$
 pager��$
��Left=�$	��Top=��� -   $��打印提单��$��10,0,0,0q�$��23���� -	   $��打印出库单��$��10,0,0,0q�$y�	Collapsed=�&   System.Windows.Controls.DataGrid  -
     Name$ 
entityList��$��6,77,0,0q�   AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[   DataGridRowStyle   RowStyle# [ $
��auto��$	��750��$	��Top=�$
��Left=�   RowDetailsVisibilityMode$ Visible=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	    
IsReadOnly .    Header �� -   $��cbSelectAll��$��全选��$��Center=�$��Center=� d� 	IsChecked �� *IsSelectAll+   CellTemplate �� $ DBEntity:WarehouseOut��.R��� $��Center=�$��Center=� �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *	Printable+0
  *System.Windows.Controls.DataGridTextColumn
   .    $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Quota.QuotaNo+
   .    $! Client.Properties.Resources��$ Buyer�� �� **(Quota.Contract.BusinessPartner.ShortName+
   .    $! Client.Properties.Resources��$ InternalCustomer�� �� *+)Quota.Contract.InternalCustomer.ShortName+
   .    $! Client.Properties.Resources��$ WarehouseOutNo�� �� *WarehouseOutNo+
   .    $8 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ WarehouseOutDate�� �� *WarehouseOutDate+ �� StringFormat$ 
yyyy/MM/dd��
   .    $! Client.Properties.Resources��$ 	Warehouse�� �� *Warehouse.Name+
   .    $! Client.Properties.Resources��$ 	Commodity�� �� *Quota.Commodity.Name+
   .    $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+ �� 	Converter# [  
   .    $! Client.Properties.Resources��$ Comments�� �� *	Comment+     
Visibility$ 	Collapsed=� . $
 Auto	    CanUserSort .  # [    $! Client.Properties.Resources��$ 	Operation��   RowDetailsTemplate �� $ DBEntity:WarehouseOut��.R��� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��  $��dataGridDetail��$	��680�� .   .     
IsReadOnly . $��6,2,0,15q����� *WarehouseOutLines+ 
  $ 卡号�� �� *WarehouseInLine.PBNo+
     $! Client.Properties.Resources��$ CommodityType�� �� *CommodityType.Name+
     $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+
     $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 
     $! Client.Properties.Resources��$ ActualQuantity�� �� *VerifiedQuantity+# Z 
     $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+# [  
     $! Client.Properties.Resources��$ Comments�� �� *	Comment+  $
 Auto	  .  # [    $! Client.Properties.Resources��$ 	Operation��