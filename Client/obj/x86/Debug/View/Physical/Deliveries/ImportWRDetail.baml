   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      5clr-namespace:Client.ConvertersClient.Converters 5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5      4   .Client.View.Physical.Deliveries.ImportWRDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      6
Convertersclr-namespace:Client.Converters     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      %  Client.Base.BaseClient.BasePage    Loaded$  ImportWRLoaded��5   Q   0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *
ImportWR+ � 	Resources 5      +  %Client.Converters.VisibilityConverter   VisibilityConverter �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker  AttachmentDownLoad  AttachmentDelete  AttachmentActions �� DataType	 �� Orientation
   ResxName
   Key  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  &	        '��      '�� �     '�� -    '  �    &	     &	 .    &	 A    7  7  &	 �    &	 �    &	 �    7  7    5   
   6)   �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5!   
   "  6   .�5"      ��  � ��$ 23��6'   64   �� 5#       � ��$	 120��6&   64   5$      �� 5&   
   65   �� 5'   
   63   �� 5)   
   $ DBEntity:Attachment��61   .R�5*      �� $	 
Horizontal=�6   .+�5+      �� $��btAttachmentDownLoad��6   8��  ��65     $!
 Client.Properties.Resources��$ Download����5,      �� *Id+6;   �� 5-      $��btAttachmentDelete��6   8�� ��63     $!
 Client.Properties.Resources��$ Delete����5.      �� *Id+6;   5/      50      �� 52   
   6/   �� 53   
   61   �� 55   
   $ DBEntity:Delivery��6/   .R�56      �� $	 
Horizontal=�6   .+�57      �� $��btDeliveryEdit��6   8��  ��6/     $!
 Client.Properties.Resources��$
 Edit����58      �� *Id+6;   �� 59      $��btDeliveryDelete��6   8�� $y�	Collapsed=�5:   9   ��59   1     $!
 Client.Properties.Resources��$ Delete����5:      �� *Id+6R   5;      5<      5=       J� CommandBindings 5?      )  #System.Windows.Input.CommandBinding  5@   
   -   5           Command# [ 5@      5A   ?     5B   
   -   5        # [ 5B      5C   A     5D   
   -   5        # [ 5D      5E   A     5F   
   -   5        # [ 5F      5G   ?   .��5J      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5K      .��5L   
   � -   5         �Name$ rootGrid��5L       � RowDefinitions 5M      �� 5N      $
��auto �6    �� 5O      $
��auto �6    �� 5P      $
��auto �6    �� 5Q      $
��auto �6    .+�5S      �� -   5        $��tbDeliveryNo��5S      $
��Left=�6*   $	��Top=�5T      $��
394,71,0,0q�6J    �� 
IsReadOnly . {�.  ��6.   �� *
DeliveryNo+6p   �� 5U      -   5        $��btnOrderLine��5U   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��
246,70,0,0q�6�   $	��Top=�6�   {�6�   �� *IsQuotaEnable+ � ToolTip 6�   �� *ContractInfo+  5V      -   5        $��
dpSignDate��5V   4   $
��Left=�6   $	��Top=�5W      $��122,134,0,0q�6T      SelectedDate 61   �� *	IssueDate+6T   �� 5X      -	   5        $��btnWarehouse��5X   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��518,166,0,0q�6�   $	��Top=�6�   $y�	Collapsed=�6�   	� 5Y      -
   5        $��radioButton1��5Z   .   $��20��5Y   0   $
��Left=�6<   $��
189,41,0,0q�5Z       	� 	GroupName$ rbIsCopy��6B   $	��Top=�6y   ��5Y        *Copy+ d� 	IsChecked 5Z   W   �� *IsCopyFirst+6y   	� 5[      -   5        $��radioButton2��5\   .   $��20��5[   4   $
��Left=�6@   $��
394,41,0,0q�5\      $ rbIsCopy��6B   $	��Top=�6z   ��5[        *
Original+ 5\   W   �� *IsCopySecond+6z   �� 5]      -   5        $��btnWarehouseCompany��5]   /   $	��...��6   $��23��6#   $��25��6J   $
��Left=�6v   $��246,166,0,0q�6�   $	��Top=�6�   $y�	Collapsed=�6�   �� 5^      -   5        $��tbPack��5^      $
��Left=�6$   $	��Top=�6?   $��122,198,0,0q�5_   7   {�.  ��6   �� *PackingStandard+6L   �� 5`      -   5         ��Name$ cboxDeclarationStatus��5`   2   $
��Left=�6   $��394,198,0,0q�6Q   $	��Top=�6f    �� DisplayMemberPath$	 Key��6�    �� SelectedValuePath$ Value��5a       �� 
IsReadOnly . {�.  ��5`   ~   �� *IsCustomeds+ �� SelectedValue 5a   1   �� *
IsCustomed+6h   �� 5b      -   5        $ cboxFinancialStatus��5b   2   $
��Left=�6   $��394,134,0,0q�6O   $	��Top=�6d   $	 Key��6�   $ Value��5c       . {�.  ��5b   |   �� *StatusTypes+ 5c   1   �� *FinanceStatus+6k   �� 5d      -   5        $��btnAdd��5d   �   $��23��6^   $
��Left=�6j   $��Bottom=�6�   $��45��6�   $��	122,0,0,0q�6�   $y�	Collapsed=�6�   $��1��6�   ��6     $!
 Client.Properties.Resources��$ AddWithSymbol��6�   �� 5e      -   5        $��button1��5e   �   $��23��6^   $
��Left=�6j   $��122,11,0,29q�6�   $��45��6�   $y�	Collapsed=�6�   $��2��6�   ��6     $!
 Client.Properties.Resources��$ AddWithSymbol��6�   �� 5f       �� TextWrapping$
 Wrap=�6   $��	122,2,0,0q�5g      $	��100��6)   $	��Top=�66   $
��Left=�6N   $	��392��6i   $��3��6u   ��5f   *   �� *	Comment+5g   u   �� 5h      -   5        $��210,130,0,0q�5h   U   $
��Left=�5i      $	��Top=�60   $��60��6H   $��25��6`   $��3��6l   ��5h        $!
 Client.Properties.Resources��$
 Save��5i   l   �� 5j      -   5        $��305,130,0,0q�5j   W   $��60��5k      $��25��6    $
��Left=�6,   $	��Top=�6G   $��3��6s   ��5j        $!
 Client.Properties.Resources��$ Cancel��5k   s   �� 5l      -   5         ��Name$ lbTitle��5l   .   $
��Left=�6?   $��	6,7,0,217q�6Z   $��16(�5m      $
��auto��6"   $
��Bold"�6/   $��32��6A   ��5l        *
ImportWR+5m   A   �� 5n      $��
273,68,0,0q�6*   $	��Top=�6>   
���<��$
��Left=�5o      ��5n        *WRNo+5p      �� 5q      -   5        $��label1��5q      $
��Left=�6"   $��6,68,0,0q�6=   $	��Top=�5r      .��5s      �� 
���<����61     $!
 Client.Properties.Resources��$ Quota��6q   5t      �� 5u      -   5         ��Name$ 
tbCustomer��5u      $
��Left=�6*   $	��Top=�5v       . $��
122,70,0,0q�6Y   {�.  ��6.   �� *	QuotaNo+6m   �� 5x      $
��Left=�6^   $��	6,100,0,0q�6y   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ DocumentStatus��6�   �� 5y      -   5        $ tbStatus��5y      $��122,102,0,0q�6(   $
��Left=�6=   $	��Top=�5z      {�.  ��6@   �� *ApproveStatus+�� 5{      -   5        $ label2��5{   T   $��278,100,0,0q�6d   $
��Left=�5|      $	��Top=�6/   ��5{        $!
 Client.Properties.Resources��$
 Type��5|   /   �� 5}      -   5        $ tbDeliveryType��5}      $��394,102,0,0q�6.   $
��Left=�6C   $	��Top=�5~      {�.  ��6@     *
ImportWR+�� 5�      -   5        $ label3��5�   [   $��	6,132,0,0q�6k   $
��Left=�6~   
���<��$��28��5�   )   $	��Top=�65   ��5�        $!
 Client.Properties.Resources��$ IssuingDate��5�      �� 5�      -   5        $ label5��5�   2   $��	6,164,0,0q�6B   $
��Left=�6U   $��28��6p   $	��Top=�5�      ��5�        *Warehouseman+5�      �� 5�      -   5        $ tbWarehouseCompany��5�      $
��Left=�62   $	��Top=�5�      {�.  $��122,166,0,0q�6g   ��6.   �� *WarehouseProviderName+6g   �� 5�      -   5        $ label6��5�      $��278,163,0,0q�6$   $
��Left=�69   $	��Top=�5�      .��5�      �� 
���<����61     $!
 Client.Properties.Resources��$ 	Warehouse��6u   5�      �� 5�      -   5        $ tbWarehouse��5�      $
��Left=�6+   $	��Top=�5�      {�.  $��394,166,0,0q�6_   ��6.   �� *WarehouseName+6_   �� 5�      -   5        $ label17��5�   2   $��278,196,0,0q�6C   $
��Left=�5�      $	��Top=�6/   ��5�        *CustomStatus+5�   /   �� 5�      -    5        $ label7��5�   _   $��278,132,0,0q�6o   $
��Left=�6�   $��28��6�   $	��Top=�5�      ��5�        $!
 Client.Properties.Resources��$ FinancialStatus��5�      �� 5�      -!   5        $ label16��5�   1   $��	6,196,0,0q�6B   $
��Left=�6U   $��28��5�      $	��Top=�6    ��5�        *PackingSpec+5�       &   System.Windows.Controls.DataGrid  5�      -"   5        $��dataGridDeliveryLines��5�   2      CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .     AutoGenerateColumns  .  $
��auto��5�   t   $
��Left=�5�      $
��auto��62   $��Bottom=�6?   $��	122,2,0,7q�6Z   $��1��6m   ��5�   .   �� !   Columns! 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn" 	  Header" 6)     $!
 Client.Properties.Resources��$ CommodityType��1
  +System.Windows.Controls.DataGridBoundColumn# 
  Binding# 6q   �� *CommodityType.Name+  5�      " 6)     $!
 Client.Properties.Resources��$ Brand��# 6i   �� *
Brand.Name+  5�      " 6)     $!
 Client.Properties.Resources��$ OriginCountry��# 6q   �� *Country.ChineseName+  5�      " 6)     $!
 Client.Properties.Resources��$ CardNo��# 6j   �� *PBNo+  5�      " 6)     $!
 Client.Properties.Resources��$ 	NetWeight��# 6m   �� *	NetWeight+$   DBEntity.EnumEntity.RoundRules$   STR_QUANTITY% �� StringFormat#% Z$   5�      " 6)     $!
 Client.Properties.Resources��$ GrossWeight��# 6o   �� *GrossWeight+#% Z$   5�      " 6)     $!
 Client.Properties.Resources��$ Bundle��# 6j   �� *PackingQuantity+#% Z$   5�      " 6)     $!
 Client.Properties.Resources��$ Comments��# 6l   �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  5�      & 	  CanUserSort& .  '   CellTemplate#' [ 5�   -   " 5�   -     $!
 Client.Properties.Resources��$ 	Operation��( 	  
Visibility( 5�   ]   �� *IsConvertWR+) �� 	Converter#) [  5�      �� 5�      $��6,0,0,0q�6Z   $
��Left=�6k   $	��Top=�6�   $��2��6�   $��28��6�   ��6     $!
 Client.Properties.Resources��$ 
Attachment��6�   �� 5�      $��6,0,0,0q�6X   $	��Top=�6i   $
��Left=�6�   $��3��6�   ��6     $!
 Client.Properties.Resources��$ Comments��6�     5�      -#   5        $��dataGridAttachment��5�   �     .   .  $
��Left=�6J    . $
��auto��6�   $
��auto��6�   $��	122,2,0,7q�6�   $��2��6�   ��6w   �� ! 5�        5�      # 6)   �� *Name+" 6B     $!
 Client.Properties.Resources��$ AttachmentName��  5�      & .  #' [ 6A   $( 	Collapsed=�5�   q   " 6-     $!
 Client.Properties.Resources��$ 	Operation��6q   5�      �� 5�      -$   5        $��label8��5�   �   $
��Left=�6V   $	��Top=�6q   $��6,0,0,0q�6�   $��1��6�   ��6     $!
 Client.Properties.Resources��$ Detail��6�   �� 5�      -%   5        $��txtCirculNo��5�   F   $
��Left=�6   $��122,230,0,7q�61   $	��Top=�6s   ��6Y   �� *
CirculNo+6s   �� 5�      -&   5        $��label4��5�   �   $
��Left=�6V   $��Right=�6r   $��	6,228,0,0q�6�   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ FlowId��6�   �� 5�      -'   5        $��button2��5�   �   $	��...��6   $��23��6#   $
��Left=�6/   $��
518,71,0,0q�6q   $	��Top=�6�   $��25��6�   {�6J   �� *IsPoolNoBtnEnale+6�   �� 5�      -(   5        $��label9��5�   ]   $��金属��6   $��28��6!   $
��Left=�6-   $��277,228,0,0q�6H   $	��Top=�6k   $	��110��6�   �� 5�      -)   5        $��textBox1��5�   R   $��23��6   $
��Left=�6"   $��394,230,0,7q�6=   $	��Top=�6b   $	��120��6z    . {�.  ��5�      �� *Commodity.Name+5�      5�      5�      