   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5   $   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      >    8Client.View.Physical.InventoryReport.InventoryReportHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5   $   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$=  7Client.View.Physical.InventoryReport.ResInventoryReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   ^     *InventoryReport+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value&   System.Windows.Controls.DataGrid  DataGridStyle/   )Client.Converters.WarehouseInQtyConverter  WarehouseInQtyConverter-   'Client.Converters.DeliveryTypeConverter  DeliveryTypeConverter*   $Client.Converters.TDOnlyQtyConverter  TDOnlyQtyConverter  ShowCirculDetail��%O  &	        '�� �     &	     &	 �    &	 �    &	 �    &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 100��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$	 210��6'   65   �� 5       � ��$	 446��6)   67   �� 5       � ��$
 auto��6&   65   5        5   
   6-     5   
   6+     5    
   6(   �� 5"   
   63   5#       J� CommandBindings 5%      )  #System.Windows.Input.CommandBinding  5&   
   -   5           Command# [ 5&      6�   .��5)      �� $
��Auto=�6   $
��Auto=�68   .��5*   
   � -   5        	 �Name$	 rootGrid��5*      .+�5,      �� -   5        $��lbTitle��5,   5   $
��Bold"�6D   $��16(�6V   $��32��6d   $
��Left=�6p   $��6,6,0,0q�5-      $	��Top=�6%   $
��auto��6=   ��5,        *InventoryReport+5-   =   �� 5.      -   5        $��label2��5.   �   $��75��6Y   $��28��6d   $��Right=�6p   
���<��$
��Left=�6�   $��	12,38,0,0q�6�   $	��Top=�6�   ��6     
   ResxName$!
 Client.Properties.Resources��
   Key$ 	Commodity��6�   �� 5/      -   5        $��	comboBox1��5/   E   $
��Left=�6   $��	93,40,0,0q�62   $	��Top=�6V    �� DisplayMemberPath$
 Name��50       �� SelectedValuePath$ Id��51      ��50   0   �� *CommodityList+ �� SelectedValue 6V   �� *SelectedCommodityID+51      �� 52      -   5        $��label3��52   �   #��[  6`   
���<��$
��Left=�6�   $��
210,38,0,0q�6�   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ InternalCustomer��6�   �� 53      -   5        $��	comboBox2��53   R   $��23��6   $
��Left=�6#   $��
314,40,0,0q�6>   $	��Top=�54      $	��120��6/   $ 	ShortName��6;   $ Id��55   D   ��54   Y   �� *InternalCustomerList+ 55      �� *SelectedCustomerID+6D   �� 56      -   5        $��button1��56   �   $��23��6V   $
��Left=�6b   $��
450,40,0,0q�6}   $	��Top=�57      $��60��6-   ��56        $!
 Client.Properties.Resources��$ Query��57   8   �� 58      -	   5        $��label4��59      $��28��58   8   $
��Left=�6D   $��Black"�6_   $��	52,69,0,0q�6r   $	��Top=�59   "   ��58        *WarehouseInventory+59   "     5:      -
   5          Name$ warehouseInventory��5:      $��
52,104,0,0q�63      CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns . $   HorizontalScrollBarVisibility$
 Auto=�5;   J      	RowHeight$ 18Q�6o      ColumnHeaderHeight$ 23Q�5<      $	��Top=�6/   $
��Left=�6G   #��[ 6b   ��5;   2   �� 5<   �   �� 5=      -   5        $��label5��5>      $��28��5=   Z   $
��Left=�6f   $��Black"�6�   $��
52,320,0,0q�6�   $	��Top=�5>   "   ��5=        $!
 Client.Properties.Resources��$ 
DomesticBL��5>   "     5?      -   5        $ internalTDList��5?      $��
52,354,0,0q�6/    .  #��[ 6x     DataGridRowStyle   RowStyle# [ 6�    .   . $
 Auto=�5@   @   $	��210��6e   $ 18Q�6r   $ 23Q�5A      $	��Top=�6/   $
��Left=�6G   ��5?   _   ��    Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $!
 Client.Properties.Resources��$
 BLNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6h   �� *Delivery.DeliveryNo+6�     5D       6)     $!
 Client.Properties.Resources��$ IssuingDate�� 6o   �� *Delivery.IssueDate+ �� StringFormat$ 
yyyy-MM-dd��6�     5E       6)     $!
 Client.Properties.Resources��$ 	Warehouse�� 6m   �� *Delivery.Warehouse.Name+6�     5F       6)     $!
 Client.Properties.Resources��$ 	Commodity�� 6m   �� *Delivery.Quota.Commodity.Name+6�     5G       6)     $!
 Client.Properties.Resources��$ Brand�� 6i   �� *
Brand.Name+6�     5H       6)     $!
 Client.Properties.Resources��$ Quantity�� 6l   �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 6�     5I      $ 实际数量��6)    67   �� *VerifiedWeight+# Z 6�     5J       6)     $=
 7Client.View.Physical.InventoryReport.ResInventoryReport��$ 
InQuantity�� 5K   )   �� *Id+ �� 	Converter# [ # Z 6�     5L       6)     $!
 Client.Properties.Resources��$ QuantityRemain�� 5M   )   �� *	OnlyQty+# Z 6�     5N      $ 剩余实际数量��6)    69   �� *OnlyVerfiedQty+# Z 6�     5O       6)     $!
 Client.Properties.Resources��$ BLType�� 5P   )   �� *Delivery.DeliveryType+# [ 6�   5R      �� 5S      -   5        $��label6��5T      $��28��5S   _   $
��Left=�6k   $��Black"�6�   $��
52,570,0,0q�6�   $	��Top=�5T   "   ��5S        $!
 Client.Properties.Resources��$ ForeignDelivery��5T   "     5U      -   5        $ externalTDList��5U      $��
52,602,0,0q�6/    .  #��[ 6w   # [ 6�    .   . $
 Auto=�5V   @   $	��210��6e   $ 18Q�6r   $ 23Q�5W      $	��Top=�6/   $
��Left=�6G   ��5U   _   ��  5X        5Y       6)     $!
 Client.Properties.Resources��$
 BLNo�� 6h   �� *Delivery.DeliveryNo+6�     5Z       6)     $!
 Client.Properties.Resources��$ 	Commodity�� 6m   �� *Delivery.Quota.Commodity.Name+6�     5[       6)     $!
 Client.Properties.Resources��$ Brand�� 6i   �� *
Brand.Name+6�     5\       6)     $!
 Client.Properties.Resources��$ 	NetWeight�� 6m   �� *	NetWeight+# Z 6�     5]       6)     $!
 Client.Properties.Resources��$ GrossWeight�� 6o   �� *GrossWeight+# Z 6�     5^       6)     $=
 7Client.View.Physical.InventoryReport.ResInventoryReport��$ 
InQuantity�� 5_   )   �� *Id+# [ # Z 6�     5`      $ 剩余净重��6)    5a   )   �� *	OnlyQty+# Z 6�     5b      $ 剩余毛重��6)    67   �� *OnlyGrossWeight+# Z 6�     5c       6)     $!
 Client.Properties.Resources��$ BLType�� 5d   )   �� *Delivery.DeliveryType+# [ 6�   4  .System.Windows.Controls.DataGridTemplateColumn  5e      $ 流转标识号��6-      CellTemplate 5f      �� 5g       �� DataType$ DBEntity:DeliveryLine��6+   .R�5h   "   �� �� 5i   &    �� Command# [ 60     �� CommandParameter  5j   0   �� *Delivery.CirculNo+.�6_   .�5k   *   �� �6.   �� *Delivery.CirculNo+6S   5l   '   5m   #   5n      5p      5r      5s      5t      5u      