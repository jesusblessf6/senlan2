   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6\   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5
      <   6Client.View.Physical.Deliveries.PurchaseDeliveryDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      6
Convertersclr-namespace:Client.Converters     6\   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      %  Client.Base.BaseClient.BasePage    Loaded$  
PageLoaded��5   }   0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9        ResxName$! Client.Properties.Resources��
   Key$ 
DomesticBL�� � 	Resources 5       �� 
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
��Left=�6*   $��
122,40,0,0q�5P   2   $��23��6F   $	��Top=�6R   ��6   �� *
DeliveryNo+6R   �� 5Q      -   5        $��btnOrderLine��5Q   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $	��Top=�6�   $��
518,40,0,0q�5R      {�5Q   �   �� *IsQuotaEnable+ � ToolTip 5R   )   �� *ContractInfo+  5S      -   5        $��
dpSignDate��5S   4   $
��Left=�6   $��23��5T   <   $	��Top=�6H   $��122,104,0,0q�6`      SelectedDate 6   �� *	IssueDate+6`   �� 5U      -	   5        $��btnWarehouse��5U   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��518,136,0,7q�6�   $	��Top=�6�   {�5V      �� *IsWarehouseEnable+�� 5W      -
   5        $��btnWarehouseCompany��5W   /   $	��...��6   $��23��6#   $��25��6J   $
��Left=�6v   $	��Top=�6�   $��246,136,0,0q�6�   �� 5X      -   5         ��Name$ cboxFinancialStatus��5X   2   $
��Left=�6   $	��Top=�6O    �� DisplayMemberPath$	 Key��6�    �� SelectedValuePath$ Value��5Y      $��394,104,0,0q�6Y   ��5X   g   �� *StatusTypes+ �� SelectedValue 5Y   1   �� *FinanceStatus+6Y   �� 5Z      -   5        $��btnAdd��5Z   �   $��23��6^   $
��Left=�6j   $	��Top=�5[      $��45��6-   $��	122,2,0,7q�6L   $��1��6_   ��5Z        $! Client.Properties.Resources��$ AddWithSymbol��5[   _   �� 5\      -   5        $��button1��5\   �   $��23��6^   $
��Left=�6j   $	��Top=�5]      $��45��6-   $��	122,2,0,0q�6M   $��2��6`   ��5\        $! Client.Properties.Resources��$ AddWithSymbol��5]   `   �� 5^       �� TextWrapping$
 Wrap=�6   $	��392��5_      $	��100��6"   $	��Top=�6/   $
��Left=�6G   $��	122,2,0,0q�6b   $��3��6u   ��5^   *   �� *	Comment+5_   u   �� 5`      -   5        $��210,130,0,0q�5`   U   $��25��6j   $
��Left=�5a   0   $	��Top=�6K   $��60��6c   $��3��6{   ��5`        $! Client.Properties.Resources��$
 Save��5a   {   �� 5b      -   5        $��305,130,0,0q�5b   W   $��25��6l   $��60��5c   0   $
��Left=�6;   $	��Top=�6V   $��3��6�   ��5b        $! Client.Properties.Resources��$ Cancel��5c   �   �� 5d      -   5         ��Name$ lbTitle��5d   Z   $��32��6k   $
��Left=�6w   $��6,6,0,0q�6�   $��16(�5e      $
��auto��6"   $
��Bold"�6/   $	��Top=�6A   ��5d        $! Client.Properties.Resources��$ 
DomesticBL��5e   A   �� 5f      $
��Left=�6T   $��6,38,0,0q�6o   $��28��5g      $	��Top=�6    ��5f        $! Client.Properties.Resources��$
 BLNo��5g       �� 5h      -   5        $��label1��5h   U   $
��Left=�6c   
���<��$��28��5i   )   $	��Top=�65   $��
278,38,0,0q�6M   ��5h        $! Client.Properties.Resources��$ Quota��5i   M   �� 5j      -   5         ��Name$ 
tbCustomer��5j      $
��Left=�6*   {�.  $��
394,40,0,0q�5k   (   $	��Top=�6<   ��5j   E   �� *	QuotaNo+5k   <   �� 5l      $
��Left=�6^   $��6,70,0,0q�6y   $��28��6�   $	��Top=�5m      ��5l        $! Client.Properties.Resources��$ DocumentStatus��5m      �� 5n      -   5        $ tbStatus��5n      $��
122,72,0,0q�6(   $
��Left=�6<   {�.  $	��Top=�5o   G   ��6(   �� *ApproveStatus+6G   �� 5p      -   5        $ label2��5p   T   $��
277,71,0,0q�6d   $
��Left=�5q      $��28��6/   $	��Top=�6;   ��5p        $! Client.Properties.Resources��$
 Type��5q   ;   �� 5r      -   5        $ tbDeliveryType��5r      $��
394,72,0,0q�6.   $
��Left=�6B   {�.  $	��Top=�5s   k   ��6(     $! Client.Properties.Resources��$ 
DomesticBL��6k   �� 5t      -   5        $ label3��5t   [   $��	6,102,0,0q�6k   $
��Left=�6~   
���<��$��28��5u   )   $	��Top=�65   ��5t        $! Client.Properties.Resources��$ IssuingDate��5u   5   �� 5v      -   5        $ label5��5v   2   $��	6,134,0,0q�6B   $
��Left=�6U   $	��Top=�5w      $��2��6,   ��5v        *Warehouseman+5w   ,   �� 5x      -   5        $ tbWarehouseCompany��5x      $
��Left=�62   $	��Top=�5y      {�.  $��122,136,0,7q�6g   ��6.   �� *WarehouseProviderName+6g   �� 5z      -   5        $ label6��5z   Y   $��278,134,0,0q�6i   $
��Left=�5{      
���<��$	��Top=�6D   $��2��6\   ��5z        $! Client.Properties.Resources��$ 	Warehouse��5{   \   �� 5|      -   5        $ tbWarehouse��5|   "   $��23��6   $
��Left=�67   $	��Top=�5}      {�.  $��394,136,0,7q�6_   ��6.   �� *WarehouseName+6_   �� 5~      -   5        $ label7��5~   _   $��278,102,0,0q�6o   $
��Left=�6�   $	��Top=�5      ��5~        $! Client.Properties.Resources��$ FinancialStatus��5      &   System.Windows.Controls.DataGrid  5�      -   5        $��dataGridDeliveryLines��5�   2      CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�5�   3   $
��auto��6N   $��
122,34,0,7q�6[   $��1��6o   ��5�   f   ��    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$ CardNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6j   �� *PBNo+  5�       6)     $! Client.Properties.Resources��$ 	Commodity�� 6m   �� *CommodityType.Commodity.Name+  5�       6)     $! Client.Properties.Resources��$ CommodityType�� 6q   �� *CommodityType.Name+  5�       6)     $! Client.Properties.Resources��$ Brand�� 6i   �� *
Brand.Name+  5�       6)     $! Client.Properties.Resources��$ Specification�� 6q   �� *Specification.Name+  5�       6)     $! Client.Properties.Resources��$ Quantity�� 6l   �� *	NetWeight+$   DBEntity.EnumEntity.RoundRules    STR_QUANTITY! �� StringFormat#! Z    5�       6)     $! Client.Properties.Resources��$ ActualQuantity�� 6r   �� *VerifiedWeight+#! Z    5�       6)     $! Client.Properties.Resources��$ Bundle�� 6j   �� *PackingQuantity+#! Z    5�       6)     $! Client.Properties.Resources��$ QuantityConfirm�� 6s   �� *DlvLineIsVerified+" �� 	Converter#" [    5�      $ 	暂定价��6)    66   �� *TempUnitPrice+#   	STR_PRICE#! Z#   5�       6)     $! Client.Properties.Resources��$ Comments�� 6l   �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ 	  CanUserSort$ .  %   CellTemplate#% [ 5�   -    5�   -     $! Client.Properties.Resources��$ 	Operation��5�   -   5�      �� 5�      $��6,0,0,0q�6Z   $
��Left=�6k   $	��Top=�5�      $��2��6,   ��5�        $! Client.Properties.Resources��$ 
Attachment��5�   ,   �� 5�      $
��Left=�6X   $	��Top=�6s   $��6,0,0,0q�6�   $��3��6�   ��6     $! Client.Properties.Resources��$ Comments��6�     5�      -   5        $��dataGridAttachment��5�   \    .   .  $
��auto��5�   J   $
��Left=�5�       . $	��Top=�6v   $
��auto��5�      $��
122,34,0,7q�6$   $��2��68   ��5�   D   ��  5�        5�       6)   �� *Name+ 6B     $! Client.Properties.Resources��$ AttachmentName��  5�      $ .  #% [ 6A    5�   -     $! Client.Properties.Resources��$ 	Operation��5�      �� 5�      -   5        $��label8��5�   �   $
��Left=�6V   $��6,0,0,0q�6q   $	��Top=�5�      $��1��6,   ��5�        $! Client.Properties.Resources��$ Detail��5�   ,   5�      5�      5�      