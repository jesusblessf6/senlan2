   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6[   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5
      6   0Client.View.Physical.Deliveries.PurchaseWRDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      6
Convertersclr-namespace:Client.Converters     6[   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      %  Client.Base.BaseClient.BasePage    Loaded$  
PageLoaded��5   }   0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9        ResxName$! Client.Properties.Resources��
   Key$ 
DomesticWR�� � 	Resources 5       �� 
TargetType �� Property	 �� Value(  "System.Windows.Controls.DatePicker+  %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  AttachmentDownLoad  AttachmentDelete  AttachmentActions
 �� DataType �� Orientation  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  '��       '�� �     '��     '  �    &	      &	     &	 .    &	 A    7  7  &	 �    &	 �    &	 �    7  7  �� 5   
   " ��6   .�5      ��  � ��$	 28��6'   64   �� 5       � ��$		 110��6&   64   �� 5       � ��$	 Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$	 23��6'   64   �� 5       � ��$		 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$	 23��6'   64   �� 5       � ��$		 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$	 23��6'   64   �� 5        � ��$		 120��6&   64   5!        5"   
   6)   �� 5#   
   65   �� 5$   
   63   �� 5&   
   $
 DBEntity:Attachment��61   .R�5'      �� $ 
Horizontal=�6   .+�5(      �� $��btAttachmentDownLoad��6   8��  ��65     $! Client.Properties.Resources��$ Download����5)      �� *Id+6;   �� 5*      $��btAttachmentDelete��6   8�� ��63     $! Client.Properties.Resources��$ Delete����5+      �� *Id+6;   5,      5-      �� 5/   
   6/   �� 50   
   61   �� 52   
   $
 DBEntity:Delivery��6/   .R�53      �� $ 
Horizontal=�6   .+�54      �� $��btDeliveryEdit��6   8��  ��6/     $! Client.Properties.Resources��$
 Edit����55      �� *Id+6;   �� 56      $��btDeliveryDelete��6   8�� ��61     $! Client.Properties.Resources��$ Delete����57      �� *Id+6;   58      59      5:       J� CommandBindings 5<      )  #System.Windows.Input.CommandBinding  5=   
   -   5           Command# [ 5=      5>   ?     5?   
   -   5        # [ 5?      5@   A     5A   
   -   5        # [ 5A      5B   A     5C   
   -   5        # [ 5C      5D   ?   .��5G      �� $
��Auto=�6   $
��Auto=�68   .��5H   
   � -   5         �Name$ rootGrid��5H       � RowDefinitions 5I      �� 5J      $
��auto �6    �� 5K      $
��auto �6    �� 5L      $
��auto �6    �� 5M      $
��auto �6    .+�5O      �� -   5        $��tbDeliveryNo��5O      $
��Left=�6*   $	��Top=�5P      $��
122,40,0,0q�6J   ��6.   �� *
DeliveryNo+6J   �� 5Q      -   5        $��btnOrderLine��5Q   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��
518,40,0,0q�6�   $	��Top=�6�   {�6�   �� *IsQuotaEnable+ � ToolTip 6�   �� *ContractInfo+  5R      -   5        $��
dpSignDate��5R   4   $
��Left=�6   $	��Top=�5S      $��122,104,0,0q�6T      SelectedDate 61   �� *	IssueDate+6T   �� 5T      -	   5        $��btnWarehouse��5T   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��518,136,0,7q�6�   $	��Top=�6�   �� 5U      -
   5        $��btnWarehouseCompany��5U   /   $	��...��6   $��23��6#   $��25��6J   $
��Left=�6v   $��246,136,0,7q�6�   $	��Top=�6�   �� 5V      -   5         ��Name$ cboxFinancialStatus��5V   2   $
��Left=�6   $	��Top=�6O    �� DisplayMemberPath$	 Key��6�    �� SelectedValuePath$ Value��5W      $��394,104,0,0q�6Y   ��5V   g   �� *StatusTypes+ �� SelectedValue 5W   1   �� *FinanceStatus+6Y   �� 5X      -   5        $��btnAdd��5X   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5Y      $��45��6-   $��1��6L   ��5X        $! Client.Properties.Resources��$ AddWithSymbol��5Y   L   �� 5Z      -   5        $��button1��5Z   �   $��23��6^   $
��Left=�6j   $	��Top=�5[      $��45��6-   $��	122,2,0,0q�6M   $��2��6`   ��5Z        $! Client.Properties.Resources��$ AddWithSymbol��5[   `   �� 5\       �� TextWrapping$
 Wrap=�6   $	��392��5]      $	��100��6"   $��	122,2,0,0q�6/   $	��Top=�6B   $
��Left=�6Z   $��3��6u   ��5\   *   �� *	Comment+5]   u   �� 5^      -   5        $��210,120,0,0q�5^   U   $
��Left=�5_      $	��Top=�60   $��60��6H   $��25��6S   $��3��6l   ��5^        $! Client.Properties.Resources��$
 Save��5_   l   �� 5`      -   5        $��305,120,0,0q�5`   W   $	��Top=�5a      $
��Left=�6A   $��60��6\   $��25��6g   $��3��6s   ��5`        $! Client.Properties.Resources��$ Cancel��5a   s   �� 5b      -   5         ��Name$ lbTitle��5b   Z   $
��Left=�6k   $��6,6,0,0q�6�   $��16(�5c      $
��auto��6"   $
��Bold"�6/   $��32��6A   $	��Top=�6M   ��5b        $! Client.Properties.Resources��$ 
DomesticWR��5c   M   �� 5d      $
��Left=�6*   $��6,38,0,0q�6F   $��28��6X   $	��Top=�5e      ��5d        *WRNo+5e      �� 5f      -   5        $��label1��5f   U   $
��Left=�6c   
���<��$��
278,38,0,0q�5g      $��28��6(   $	��Top=�64   ��5f        $! Client.Properties.Resources��$ Quota��5g   4   �� 5h      -   5         ��Name$ 
tbCustomer��5h      $
��Left=�6*   $	��Top=�5i       �� 
IsReadOnly . $��
394,40,0,0q�6Y   ��6.   �� *	QuotaNo+6Y   �� 5j      $
��Left=�6^   $��6,70,0,0q�6y   $��28��6�   $	��Top=�5k      ��5j        $! Client.Properties.Resources��$ DocumentStatus��5k      �� 5l      -   5        $ tbStatus��5l      $��
122,72,0,0q�6(   $
��Left=�6<   $	��Top=�5m      {�.  $�� ��6@   �� 5n      -   5        $ label2��5n   `   $��28��6T   $��
278,70,0,0q�6p   $
��Left=�5o      $	��Top=�6/   ��5n        $! Client.Properties.Resources��$
 Type��5o   /   �� 5p      -   5        $ tbDeliveryType��5p      $��
394,72,0,0q�6.   $
��Left=�6B   $	��Top=�5q      {�.  ��6@     $! Client.Properties.Resources��$ 
DomesticWR���� 5r      -   5        $ label3��5r   g   $��28��6[   $��	6,102,0,0q�6w   $
��Left=�6�   
���<��$	��Top=�5s   )   ��5r        $! Client.Properties.Resources��$ IssuingDate��5s   )   �� 5t      -   5        $ label5��5t   >   $��28��62   $��	6,134,0,0q�6N   $
��Left=�6a   $	��Top=�5u      ��5t        *Warehouseman+5u      �� 5v      -   5        $ tbWarehouseCompany��5v      $	��Top=�62    . $��122,136,0,7q�5w   O   $
��Left=�6d   ��6   �� *WarehouseProviderName+6d   �� 5x      -   5        $ label6��5x   e   $��28��6Y   $��278,134,0,0q�6u   $
��Left=�5y      
���<��$	��Top=�6D   ��5x        $! Client.Properties.Resources��$ 	Warehouse��5y   D   �� 5z      -   5        $ tbWarehouse��5z      $
��Left=�6+   $	��Top=�5{       . $��394,136,0,7q�6_   ��6.   �� *WarehouseName+6_   �� 5|      -   5        $ label7��5|   k   $��28��6_   $
��Left=�6{   $	��Top=�5}      $��278,102,0,0q�6,   ��5|        $! Client.Properties.Resources��$ FinancialStatus��5}   ,   &   System.Windows.Controls.DataGrid  5~      -   5        $��dataGridDeliveryLines��5~   2      CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��auto��5   t   $
��Left=�5�      $
��auto��62   $��
122,34,0,7q�6?   $��1��6S   ��5   .   ��    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$ CardNo��1
  +System.Windows.Controls.DataGridBoundColumn  
  Binding  6j   �� *PBNo+  5�       6)     $! Client.Properties.Resources��$ 	Commodity��  6m   �� *CommodityType.Commodity.Name+  5�       6)     $! Client.Properties.Resources��$ CommodityType��  6q   �� *CommodityType.Name+  5�       6)     $! Client.Properties.Resources��$ Brand��  6i   �� *
Brand.Name+  5�       6)     $! Client.Properties.Resources��$ Quantity��  6l   �� *	NetWeight+$   DBEntity.EnumEntity.RoundRules!   STR_QUANTITY" �� StringFormat#" Z!   5�       6)     $! Client.Properties.Resources��$ ActualQuantity��  6r   �� *VerifiedWeight+#" Z!   5�       6)     $! Client.Properties.Resources��$ Bundle��  6j   �� *PackingQuantity+#" Z!   5�       6)     $! Client.Properties.Resources��$ QuantityConfirm��  6s   �� *DlvLineIsVerified+# �� 	Converter## [    5�      $ 	暂定价��6)     66   �� *TempUnitPrice+$   	STR_PRICE#" Z$   5�       6)     $! Client.Properties.Resources��$ Comments��  6l   �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  5�      % 	  CanUserSort% .  &   CellTemplate#& [ 5�   -    5�   -     $! Client.Properties.Resources��$ 	Operation��5�   -   5�      �� 5�      $��6,0,0,0q�6Z   $
��Left=�6k   $	��Top=�5�      $��2��6,   ��5�        $! Client.Properties.Resources��$ 
Attachment��5�   ,   �� 5�      $��6,0,0,0q�6X   $
��Left=�6i   $	��Top=�6�   $��3��6�   ��6     $! Client.Properties.Resources��$ Comments��6�     5�      -   5        $��dataGridAttachment��5�   �    .   .  $
��auto��6J   $
��Left=�6X    . $
��auto��6�   $��
122,34,0,7q�6�   $��2��6�   ��6�   ��  5�        5�        6)   �� *Name+ 6B     $! Client.Properties.Resources��$ AttachmentName��  5�      % .  #& [ 6A    5�   -     $! Client.Properties.Resources��$ 	Operation��5�      �� 5�      -   5        $��label4��5�   �   $
��Left=�6V   $��6,0,0,0q�6q   $	��Top=�6�   $��1��6�   ��6     $! Client.Properties.Resources��$ Detail��6�   5�      5�      5�      