   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5
      4   .Client.View.Physical.Deliveries.ExportWRDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   :     *
ExportWR+ � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   AttachmentDownLoad  AttachmentDelete  AttachmentActions �� DataType �� Orientation	   ResxName

   Key  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  '��       '�� �     '��     '  �    &	      &	     &	 .    7   7  &	 �    &	 �    &	 �    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5       ��  � ��$ 23��6'   64   �� 5!       � ��$	 120��6&   64   5"      �� 5$   
   65   �� 5%   
   63   �� 5'   
   $ DBEntity:Attachment��61   .R�5(      �� $ 
Horizontal=�6   .+�5)      �� $��btAttachmentDownLoad��6   8��  ��65     $!	 Client.Properties.Resources��$
 Download����5*      �� *Id+6;   �� 5+      $��btAttachmentDelete��6   8�� ��63     $!	 Client.Properties.Resources��$
 Delete����5,      �� *Id+6;   5-      5.      �� 50   
   6/   �� 51   
   61   �� 53   
   $ DBEntity:Delivery��6/   .R�54      �� $ 
Horizontal=�6   .+�55      �� $��btDeliveryEdit��6   8��  ��6/     $!	 Client.Properties.Resources��$

 Edit����56      �� *Id+6;   �� 57      $��btDeliveryDelete��6   8�� ��61     $!	 Client.Properties.Resources��$
 Delete����58      �� *Id+6;   59      5:      5;       J� CommandBindings 5=      )  #System.Windows.Input.CommandBinding  5>   
   -   5           Command# [ 5>      5?   ?     5@   
   -   5        # [ 5@      5A   A     5B   
   -   5        # [  5B      5C   A     5D   
   -   5        # [ 5D      5E   ?   .��5H      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5I      .��5J   
   � -   5         �Name$ rootGrid��5J       � RowDefinitions 5K      �� 5L      $
��auto �6    �� 5M      $
��auto �6    �� 5N      $
��auto �6    �� 5O      $
��auto �6    .+�5Q      �� -   5        $��btnOrderLine��5Q   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��
246,40,0,0q�6�   $	��Top=�6�   {�6�   �� *IsQuotaEnable+ � ToolTip 6�   �� *ContractInfo+�� 5R      -   5        $
��btTD��5R   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
518,40,0,0q�6J   $��25��6j   $	��Top=�6�   {�6�   �� *
IsTDEnable+  5S      -   5        $��
dpSignDate��5S   4   $
��Left=�6   $	��Top=�5T      $��122,104,0,0q�6T      SelectedDate 61   �� *	IssueDate+6T   �� 5U      -	   5        $��btnWarehouse��5U   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $	��Top=�6�   $��518,104,0,0q�6�   �� 5V      -
   5         ��Name$ cboxFinancialStatus��5V   2   $
��Left=�6   $	��Top=�6O    �� DisplayMemberPath$	 Key��6�    �� SelectedValuePath$ Value��5W      $��122,136,0,0q�6Y   ��5V   g   �� *StatusTypes+ �� SelectedValue 5W   1   �� *FinanceStatus+6Y   �� 5X      -   5        $��cboxCustomStatus��5Y   ,   $	 Key��5X      $
��Left=�6/   $��122,168,0,7q�5Y      $ Value��6i   $	��Top=�5Z      ��5X   J   �� *IsCustomeds+ 5Y   D   �� *
IsCustomed+5Z      �� 5[      -   5        $��tbPack��5[   R   $��23��6   $
��Left=�6"   $��394,168,0,7q�6=   $	��Top=�5\   7   ��6   �� *PackingStandard+67   �� 5]      -   5        $��btnAdd��5]   �   $��23��6^   $
��Left=�6j   $	��Top=�6�   $��45��6�   $y�	Collapsed=�6�   $��	122,2,0,0q�6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 AddWithSymbol��6�   �� 5^      -   5        $��button2��5^   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5_      $��45��6-   $��2��6M   ��5^        $!	 Client.Properties.Resources��$
 AddWithSymbol��5_   M   �� 5`       �� TextWrapping$
 Wrap=�6   $��	122,2,0,0q�5a      $	��Top=�6)   $
��Left=�6A   $	��397��6\   $	��100��6h   $��3��6u   ��5`   *   �� *	Comment+5a   u   �� 5b      -   5        $��210,130,0,0q�5b   U   $
��Left=�5c      $	��Top=�60   $��60��6H   $��25��6S   $��3��6l   ��5b        $!	 Client.Properties.Resources��$

 Save��5c   l   �� 5d      -   5        $��305,130,0,0q�5d   W   $��60��5e      $��25��6    $
��Left=�6,   $	��Top=�6G   $��3��6s   ��5d        $!	 Client.Properties.Resources��$
 Cancel��5e   s   �� 5h      -   5         ��Name$ lbTitle��5h   .   $
��Left=�6?   $��6,6,0,0q�6Z   $��16(�6k   $
��auto��5i      $
��Bold"�6!   $��32��63   $	��Top=�6?   ��5h        *
ExportWR+5i   ?   �� 5j      -   5        $��label1��5j   U   
���<��$��6,38,0,0q�6x   $
��Left=�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 Quota��6�   �� 5k      -   5         ��Name$ 
tbCustomer��5k      $
��Left=�6*   $	��Top=�6E    �� 
IsReadOnly . $��
122,40,0,0q�5l   A   ��6   �� *	QuotaNo+6A   �� 5m      $
��Left=�6^   $��6,70,0,0q�6y   $��28��6�   $	��Top=�5n      ��5m        $!	 Client.Properties.Resources��$
 DocumentStatus��5n      �� 5o      -   5        $ tbStatus��5o      $��
122,72,0,0q�6(   $
��Left=�6<   $	��Top=�5p      {�.  ��6@   �� *ApproveStatus+�� 5q      -   5        $ label2��5q   T   $
��Left=�6d   $	��Top=�6   $��
278,70,0,0q�6�   ��6     $!	 Client.Properties.Resources��$

 Type��6�   �� 5r      -   5        $ tbDeliveryType��5r      $��
394,72,0,0q�6.   $
��Left=�6B   $	��Top=�5s      {�.  ��6@     *
ExportWR+�� 5t      -   5        $ label3��5t   [   $��	6,102,0,0q�6k   $
��Left=�6~   
���<��$	��Top=�5u   )   ��5t        $!	 Client.Properties.Resources��$
 IssuingDate��5u   )   �� 5v      -   5        $ label6��5v   e   $��28��6Y   $��278,102,0,0q�6u   $
��Left=�5w      
���<��$	��Top=�6D   ��5v        $!	 Client.Properties.Resources��$
 	Warehouse��5w   D   �� 5x      -   5        $ tbWarehouse��5x      $
��Left=�6+   $	��Top=�5y       . $��394,104,0,0q�6_   ��6.   �� *WarehouseName+6_   �� 5z      -   5        $ label7��5z   _   $��	6,134,0,0q�6o   $
��Left=�6�   $	��Top=�5{      ��5z        $!	 Client.Properties.Resources��$
 FinancialStatus��5{      &   System.Windows.Controls.DataGrid  5|      -   5        $��dataGridDeliveryLines��5|   2      CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�5}   3   $
��auto��6N   $
��auto��6[   $��	122,2,0,7q�6i   $��1��6|   ��5|   f   ��    Columns 5~      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header 6)     $!	 Client.Properties.Resources��$
 CardNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6j   �� *PBNo+  5�       6)     $!	 Client.Properties.Resources��$
 	Commodity�� 6m   �� *CommodityType.Commodity.Name+  5�       6)     $!	 Client.Properties.Resources��$
 CommodityType�� 6q   �� *CommodityType.Name+  5�       6)     $!	 Client.Properties.Resources��$
 Brand�� 6i   �� *
Brand.Name+  5�       6)     $!	 Client.Properties.Resources��$
 Specification�� 6q   �� *Specification.Name+  5�       6)     $!	 Client.Properties.Resources��$
 	NetWeight�� 6m   �� *	NetWeight+$	   DBEntity.EnumEntity.RoundRules  	  STR_QUANTITY! �� StringFormat#! Z    5�       6)     $!	 Client.Properties.Resources��$
 GrossWeight�� 6o   �� *GrossWeight+#! Z    5�       6)     $!	 Client.Properties.Resources��$
 Bundle�� 6j   �� *PackingQuantity+#! Z    5�       6)     $!	 Client.Properties.Resources��$
 Comments�� 6l   �� *	Comment+4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      "   CanUserSort" .  # 
  CellTemplate## [ 5�   -   $   Width5  /System.Windows.Controls.DataGridLengthConverter$
$ auto 6]    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�   ]   5�      �� 5�      $��6,0,0,0q�6X   $	��Top=�6i   $
��Left=�6�   $��3��6�   ��6     $!	 Client.Properties.Resources��$
 Comments��6�   �� 5�      -   5        $��label9��5�   r   
���<��$
��Left=�6C   $��
278,38,0,0q�6^   $��28��6�   $	��Top=�6�   ��6     *
ImportWR+6�   �� 5�      -   5        $��textBox1��5�   c   $��23��6   $
��Left=�6"    . $��
394,40,0,0q�6O   $	��Top=�5�   3   ��6   �� *TDeliveryNo+63   �� 5�      -   5        $��label4��5�   �   $
��Left=�6Z   $��6,0,0,0q�6u   $	��Top=�5�      $��2��6,   ��5�        $!	 Client.Properties.Resources��$
 
Attachment��5�   ,     5�      -   5        $��dataGridAttachment��5�   �    .   .  $
��Left=�6J    . $
��auto��6�   $
��auto��6�   $	��Top=�6�   $��
122,32,0,7q�6�   $��2��6�   ��6w   ��  5�        5�       6)   �� *Name+ 6B     $!	 Client.Properties.Resources��$
 AttachmentName��
  5�      " .  ## [ 6A    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�      �� 5�      -    5        $��label17��5�   2   $	��Top=�6A   $��	6,166,0,0q�6Y   $
��Left=�5�      ��5�        *CustomStatus+5�      �� 5�      -!   5        $��label16��5�   a   $
��Left=�61   $��278,166,0,0q�6L   $��28��6p   $	��Top=�6|   ��6     *PackingSpec+6|   �� 5�      -"   5        $��label5��5�   �   $
��Left=�6V   $��6,0,0,0q�6q   $	��Top=�6�   $��2��6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 Detail��6�   �� 5�      -#   5        $��label8��5�   _   $��发货单号��6   $��28��6#   $
��Left=�6/   $��278,132,0,0q�6J   $	��Top=�6m   $	��110��6�   �� 5�      -$   5        $��textBox2��5�   R   $��23��6   $
��Left=�6"   $��396,136,0,0q�6=   $	��Top=�6b   $	��120��6z   ��6�   �� *
DeliveryNo+5�      5�      5�      