   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5(clr-namespace:DBEntity;assembly=DBEntityDBEntity >    8Client.View.Physical.InventoryReport.InventoryReportHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$=  7Client.View.Physical.InventoryReport.ResInventoryReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *InventoryReport+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value&   System.Windows.Controls.DataGrid  DataGridStyle/   )Client.Converters.WarehouseInQtyConverter  WarehouseInQtyConverter-   'Client.Converters.DeliveryTypeConverter  DeliveryTypeConverter*   $Client.Converters.TDOnlyQtyConverter  TDOnlyQtyConverter  ShowCirculDetail��%:  &	        '�� S     &	 �     &	 �     &	 �     &	 �     &	 �     �� " ��.���  � ��$ 28����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$	 210����  � ��$	 446����  � ��$
 auto��      ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���� $
��Auto=�$
��Auto=�.��� -   	 �Name$	 rootGrid��.+��� -   $��lbTitle��$
��Bold"�$��16(�$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��auto����  *InventoryReport+�� -   $��label2��$��75��$��28��$��Right=�
���<��$
��Left=�$��	12,38,0,0q�$	��Top=���  
   ResxName$!
 Client.Properties.Resources��
   Key$ 	Commodity���� -   $��	comboBox1��$
��Left=�$��	93,40,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *CommodityList+ �� SelectedValue �� *SelectedCommodityID+�� -   $��label3��#��[  
���<��$
��Left=�$��
210,38,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox2��$��23��$
��Left=�$��
314,40,0,0q�$	��Top=�$	��120��$ 	ShortName��$ Id������ *InternalCustomerList+ �� *SelectedCustomerID+�� -   $��button1��$��23��$
��Left=�$��
450,40,0,0q�$	��Top=�$��60����  $!
 Client.Properties.Resources��$ Query���� -	   $��label4��$��28��$
��Left=�$��Black"�$��	52,69,0,0q�$	��Top=���  *WarehouseInventory+  -
     Name$ warehouseInventory��$��
52,104,0,0q�   CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns . $   HorizontalScrollBarVisibility$
 Auto=�   	RowHeight$ 18Q�   ColumnHeaderHeight$ 23Q�$	��Top=�$
��Left=�#��[ ���� �� -   $��label5��$��28��$
��Left=�$��Black"�$��
52,320,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ 
DomesticBL��  -   $ internalTDList��$��
52,354,0,0q� .  #��[   DataGridRowStyle   RowStyle# [  .   . $
 Auto=�$	��210��$ 18Q�$ 23Q�$	��Top=�$
��Left=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $!
 Client.Properties.Resources��$
 BLNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Delivery.DeliveryNo+     $!
 Client.Properties.Resources��$ IssuingDate�� �� *Delivery.IssueDate+ �� StringFormat$ 
yyyy-MM-dd��     $!
 Client.Properties.Resources��$ 	Warehouse�� �� *Delivery.Warehouse.Name+     $!
 Client.Properties.Resources��$ 	Commodity�� �� *Delivery.Quota.Commodity.Name+     $!
 Client.Properties.Resources��$ Brand�� �� *
Brand.Name+     $!
 Client.Properties.Resources��$ Quantity�� �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z   $ 实际数量�� �� *VerifiedWeight+# Z      $=
 7Client.View.Physical.InventoryReport.ResInventoryReport��$ 
InQuantity�� �� *Id+ �� 	Converter# [ # Z      $!
 Client.Properties.Resources��$ QuantityRemain�� �� *	OnlyQty+# Z   $ 剩余实际数量�� �� *OnlyVerfiedQty+# Z      $!
 Client.Properties.Resources��$ BLType�� �� *Delivery.DeliveryType+# [ �� -   $��label6��$��28��$
��Left=�$��Black"�$��
52,570,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ ForeignDelivery��  -   $ externalTDList��$��
52,602,0,0q� .  #��[ # [  .   . $
 Auto=�$	��210��$ 18Q�$ 23Q�$	��Top=�$
��Left=�����       $!
 Client.Properties.Resources��$
 BLNo�� �� *Delivery.DeliveryNo+     $!
 Client.Properties.Resources��$ 	Commodity�� �� *Delivery.Quota.Commodity.Name+     $!
 Client.Properties.Resources��$ Brand�� �� *
Brand.Name+     $!
 Client.Properties.Resources��$ 	NetWeight�� �� *	NetWeight+# Z      $!
 Client.Properties.Resources��$ GrossWeight�� �� *GrossWeight+# Z      $=
 7Client.View.Physical.InventoryReport.ResInventoryReport��$ 
InQuantity�� �� *Id+# [ # Z   $ 剩余净重�� �� *	OnlyQty+# Z   $ 剩余毛重�� �� *OnlyGrossWeight+# Z      $!
 Client.Properties.Resources��$ BLType�� �� *Delivery.DeliveryType+# [ 4  .System.Windows.Controls.DataGridTemplateColumn  $ 流转标识号��   CellTemplate ��  �� DataType$ DBEntity:DeliveryLine��.R��� ��  �� Command# [   �� CommandParameter  �� *Delivery.CirculNo+.�.��� ��� *Delivery.CirculNo+