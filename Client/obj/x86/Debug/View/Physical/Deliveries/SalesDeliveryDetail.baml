   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6[   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5
      9   3Client.View.Physical.Deliveries.SalesDeliveryDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      6
Convertersclr-namespace:Client.Converters     6[   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9        ResxName$! Client.Properties.Resources��
   Key$ DeliveryForm�� � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker+  %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  AttachmentDownLoad  AttachmentDelete  AttachmentActions	 �� DataType
 �� Orientation  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  '��       '�� �     '��     '  �    &	      &	     &	 .    &	 A    7  7  &	 �    &	 �    &	 �    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5        � ��$	 120��6&   64   5!        5"   
   6)   �� 5#   
   65   �� 5$   
   63   �� 5&   
   $	 DBEntity:Attachment��61   .R�5'      �� $
 
Horizontal=�6   .+�5(      �� $��btAttachmentDownLoad��6   8��  ��65     $! Client.Properties.Resources��$ Download����5)      �� *Id+6;   �� 5*      $��btAttachmentDelete��6   8�� ��63     $! Client.Properties.Resources��$ Delete����5+      �� *Id+6;   5,      5-      �� 5/   
   6/   �� 50   
   61   �� 52   
   $	 DBEntity:Delivery��6/   .R�53      �� $
 
Horizontal=�6   .+�54      �� $��btDeliveryEdit��6   8��  ��6/     $! Client.Properties.Resources��$
 Edit����55      �� *Id+6;   �� 56      $��btDeliveryDelete��6   8�� ��61     $! Client.Properties.Resources��$ Delete����57      �� *Id+6;   58      59      5:       J� CommandBindings 5<      )  #System.Windows.Input.CommandBinding  5=   
   -   5           Command# [ 5=      5>   ?     5?   
   -   5        # [ 5?      5@   A     5A   
   -   5        # [ 5A      5B   A     5C   
   -   5        # [ 5C      5D   ?   .��5G      �� $
��Auto=�6   $
��Auto=�68   .��5H   
   � -   5         �Name$ rootGrid��5H       � RowDefinitions 5I      �� 5J      $
��auto �6    �� 5K      $
��auto �6    �� 5L      $
��auto �6    �� 5M      $
��auto �6    .+�5O      �� -   5        $��btnOrderLine��5O   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��
246,40,0,0q�6�   $	��Top=�6�   {�6�   �� *IsQuotaEnable+ � ToolTip 6�   �� *ContractInfo+�� 5P      -   5        $
��btTD��5P   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
518,40,0,0q�6J   $��25��6j   $	��Top=�6�   {�6�   �� *
IsTDEnable+  5Q      -   5        $��
dpSignDate��5Q   4   $
��Left=�6   $	��Top=�5R      $��122,104,0,0q�6T      SelectedDate 61   �� *	IssueDate+6T   �� 5S      -	   5        $��btnWarehouse��5S   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $	��Top=�6�   $��518,103,0,0q�6�   �� 5T      -
   5         ��Name$ cboxFinancialStatus��5T   2   $
��Left=�6   $��122,136,0,0q�6O   $	��Top=�6d    �� DisplayMemberPath$	 Key��6�    �� SelectedValuePath$ Value��5U      ��5T   |   �� *StatusTypes+ �� SelectedValue 5U   1   �� *FinanceStatus+�� 5V      -   5        $��btnAdd��5V   �   $��23��6^   $
��Left=�6j   $	��Top=�6�   $��45��6�   $y�	Collapsed=�6�   $��	122,6,0,0q�6�   $��1��6�   ��6     $! Client.Properties.Resources��$ AddWithSymbol��6�   �� 5W      -   5        $��button1��5W   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5X      $��45��6-   $��2��6M   ��5W        $! Client.Properties.Resources��$ AddWithSymbol��5X   M   �� 5Y       �� TextWrapping$
 Wrap=�6   $��	122,2,0,0q�6C   $
��Left=�5Z      $	��392��61   $	��100��6=   $	��Top=�6J   $��3��6b   ��5Y   *   �� *	Comment+5Z   b   �� 5[      -   5        $��222,125,0,0q�5[   U   $
��Left=�5\      $	��Top=�60   $��60��6H   $��25��6S   $��3��6l   ��5[        $! Client.Properties.Resources��$
 Save��5\   l   �� 5]      -   5        $��316,125,0,0q�5]   W   $��60��5^      $��25��6    $
��Left=�6,   $	��Top=�6G   $��3��6s   ��5]        $! Client.Properties.Resources��$ Cancel��5^   s   �� 5_      -   5         ��Name$ lbTitle��5_   :   $
��Left=�6K   $��	6,7,0,154q�6f   $��16(�5`      $
��auto��6"   $
��Bold"�6/   $��32��6A   ��5_        *DomesticDeliveryForm+5`   A   �� 5a      -   5        $��label1��5a   U   $
��Left=�6c   
���<��$��6,39,0,0q�6�   $	��Top=�5b      ��5a        $! Client.Properties.Resources��$ Quota��5b      �� 5c      -   5         ��Name$ 
tbCustomer��5c      $
��Left=�6*   $	��Top=�5d      {�.  $��
122,40,0,0q�6Y   ��6.   �� *	QuotaNo+6Y   �� 5e      $
��Left=�6^   $��6,71,0,0q�6y   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ DocumentStatus��6�   �� 5f      -   5        $ tbStatus��5f      $��
122,72,0,0q�6(   $
��Left=�6<   $	��Top=�5g      {�.  ��6@   �� *ApproveStatus+�� 5h      -   5        $ label2��5h   T   $��
278,71,0,0q�6d   $
��Left=�5i      $	��Top=�6/   ��5h        $! Client.Properties.Resources��$
 Type��5i   /   �� 5j      -   5        $ tbDeliveryType��5j      $��
394,72,0,0q�6.   $
��Left=�6B   $	��Top=�5k      {�.  ��6@     *DomesticDeliveryForm+�� 5l      -   5        $ label3��5l   [   $��	6,102,0,0q�6k   $
��Left=�6~   
���<��$	��Top=�5m   )   ��5l        $! Client.Properties.Resources��$ IssuingDate��5m   )   �� 5n      -   5        $ label6��5n   Y   $��278,102,0,0q�6i   $
��Left=�5o      
���<��$	��Top=�6D   ��5n        $! Client.Properties.Resources��$ 	Warehouse��5o   D   �� 5p      -   5        $ tbWarehouse��5p      $
��Left=�6+   $	��Top=�5q      {�.  $��394,104,0,0q�6_   ��6.   �� *WarehouseName+6_   �� 5r      -   5        $ label7��5r   _   $��	6,134,0,0q�6o   $
��Left=�6�   $	��Top=�5s      ��5r        $! Client.Properties.Resources��$ FinancialStatus��5s      &   System.Windows.Controls.DataGrid  5t      -   5        $��dataGridDeliveryLines��5t   2      CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $	��Top=�5u   t   $
��auto��6�   $
��Left=�5v      $
��auto��62   $��	122,2,0,7q�6?   $��1��6R   ��5u   .   ��    Columns 5w      0  *System.Windows.Controls.DataGridTextColumn  5x      ,  &System.Windows.Controls.DataGridColumn   Header 6)     $! Client.Properties.Resources��$ CardNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6j   �� *PBNo+  5y       6)     $! Client.Properties.Resources��$ 	Commodity�� 6m   �� *CommodityType.Commodity.Name+  5z       6)     $! Client.Properties.Resources��$ CommodityType�� 6q   �� *CommodityType.Name+  5{       6)     $! Client.Properties.Resources��$ Brand�� 6i   �� *
Brand.Name+  5|       6)     $! Client.Properties.Resources��$ Specification�� 6q   �� *Specification.Name+  5}       6)     $! Client.Properties.Resources��$ Quantity�� 6l   �� *	NetWeight+$
   DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY  �� StringFormat#  Z   5~       6)     $! Client.Properties.Resources��$ ActualQuantity�� 6r   �� *VerifiedWeight+#  Z   5       6)     $! Client.Properties.Resources��$ Bundle�� 6j   �� *PackingQuantity+#  Z   5�       6)     $! Client.Properties.Resources��$ QuantityConfirm�� 6s   �� *DlvLineIsVerified+! �� 	Converter#! [    5�      $ 	暂定价��6)    66   �� *TempUnitPrice+" 
  	STR_PRICE#  Z"   5�       6)     $! Client.Properties.Resources��$ Comments�� 6l   �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  5�      #   CanUserSort# .  $   CellTemplate#$ [ 5�   -    5�   -     $! Client.Properties.Resources��$ 	Operation��5�   -   5�      �� 5�      $��6,0,0,0q�6X   $
��Left=�6i   $	��Top=�6�   $��3��6�   ��6     $! Client.Properties.Resources��$ Comments��6�   �� 5�      -   5        $��label9��5�   C   
���<��$��Right=�5�   G   $
��Left=�5�      $��
278,40,0,0q�6/   $	��Top=�6Q   ��5�        *DomesticBLWR+5�   Q   �� 5�      -   5        $��textBox1��5�   W   $
��Left=�6   {�.  $��
394,40,0,0q�6C   $	��Top=�5�   3   ��6   �� *TDeliveryNo+63   �� 5�      -   5        $��label4��5�   �   $��28��6Z   $
��Left=�6f   $��6,0,0,0q�6�   $	��Top=�5�      $��2��6,   ��5�        $! Client.Properties.Resources��$ 
Attachment��5�   ,     5�      -   5        $��dataGridAttachment��5�   A    .   .  $
��auto��5�   J   $
��Left=�6X    . $	��Top=�5�   [   $
��auto��6s   $��
122,34,0,7q�6�   $��2��6�   ��6)   ��  5�        5�       6)   �� *Name+ 6B     $! Client.Properties.Resources��$ AttachmentName��  5�      # .  #$ [ 6A    5�   -     $! Client.Properties.Resources��$ 	Operation��5�      �� 5�      -   5        $��label5��5�   �   $
��Left=�6V   $��6,0,0,0q�6q   $	��Top=�6�   $��1��6�   $��2��6�   ��6     $! Client.Properties.Resources��$ Detail��6�   �� 5�      -   5        $��label8��5�   �   $��28��6^   $
��Left=�6j   $��278,135,0,0q�6�   $	��Top=�6�   $	��110��6�   ��6     $! Client.Properties.Resources��$ WarehouseOutNo��6�   �� 5�      -    5        $��textBox2��5�   R   $��23��6   $
��Left=�6"   $��394,136,0,0q�6=   $	��Top=�6b   $	��120��6z   {�.  ��6�   �� *
DeliveryNo+�� 5�      -!   5        $��label10��5�   ^   $��实际提货人��6   $��28��6$   $
��Left=�60   $��	6,167,0,0q�6K   $	��Top=�6m   $	��110��6�   $��2��6�   �� 5�      -"   5        $��textBox3��5�   =   $��23��6   $
��Left=�6"   $	��Top=�6M   $	��120��6e   {�.  $��122,168,0,7q�6�   ��6�   �� *ActualDeliveryBPName+6�   �� 5�      -#   5        $��button2��5�   _   $	��...��6   $��23��6#   $
��Left=�6/   $��246,168,0,7q�6J   $	��Top=�6n   $��25��6�   6�   5�      5�      5�      