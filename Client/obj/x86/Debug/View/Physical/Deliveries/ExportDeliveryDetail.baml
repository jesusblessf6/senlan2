   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5
      4   .Client.View.Physical.Deliveries.ExportDelivery   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *ExportDelivery+ � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   DeliveryEdit  DeliveryDelete  AttachmentDownLoad  AttachmentDelete  AttachmentActions �� DataType �� Orientation	   ResxName

   Key  DeliveryActions��%�  '��       '�� �     '��     '  �    &	      &	     &	 .    &	 A    &	 T    7  7  &	 �    7   7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5       ��  � ��$ 23��6'   64   �� 5!       � ��$	 120��6&   64   5"      �� 5$   
   6/   �� 5%   
   61   �� 5&   
   65   �� 5'   
   63   �� 5)   
   $ DBEntity:Attachment��61   .R�5*      �� $ 
Horizontal=�6   .+�5+      �� $��btAttachmentDownLoad��6   8��  ��65     $!	 Client.Properties.Resources��$
 Download����5,      �� *Id+6;   �� 5-      $��btAttachmentDelete��6   8�� ��63     $!	 Client.Properties.Resources��$
 Delete����5.      �� *Id+6;   5/      50      �� 52   
   $ DBEntity:Delivery��6/   .R�53      �� $ 
Horizontal=�6   .+�54      �� $��btDeliveryEdit��6   8��  ��6/     $!	 Client.Properties.Resources��$

 Edit����55      �� *Id+6;   �� 56      $��btDeliveryDelete��6   8�� ��61     $!	 Client.Properties.Resources��$
 Delete����57      �� *Id+6;   58      59      5:       J� CommandBindings 5<      )  #System.Windows.Input.CommandBinding  5=   
   -   5           Command# [  5=      5>   ?     5?   
   -   5        # [ 5?      5@   A     5A   
   -   5        # [ 5A      5B   A     5C   
   -   5        # [ 5C      5D   ?   .��5G      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5H      .��5I   
   � -   5         �Name$ rootGrid��5I       � RowDefinitions 5J      �� 5K      $
��auto �6    �� 5L      $
��auto �6    �� 5M      $
��auto �6    �� 5N      $
��462* �6    .+�5P      �� -   5        $��btnOrderLine��5P   /   $	��...��6   $��23��6#   $��25��6C   $
��Left=�6h   $��
246,40,0,0q�6�   $	��Top=�6�   {�6�   �� *IsQuotaEnable+ � ToolTip 6�   �� *ContractInfo+�� 5Q      -   5        $��btnTD��5Q   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
516,40,0,0q�6J   $��25��6k   $	��Top=�6�   {�6�   �� *
IsTDEnable+  5R      -   5        $��
dpSignDate��5R   4   $
��Left=�6   $	��Top=�5S      $��122,136,0,0q�6T      SelectedDate 61   �� *	IssueDate+6T   �� 5T      -	   5        $��btnShippingParty��5T   /   $	��...��6   $��23��6#   $��25��6G   $
��Left=�6p   $��246,104,0,0q�6�   $	��Top=�6�   �� 5U      -
   5        $��
btnLinkman��5U   /   $	��...��6   $��23��6#   $��25��6A   $
��Left=�6d   $��516,104,0,0q�6   $	��Top=�6�     5V      -   5        $��dpDeliveryDate��5V   4   $
��Left=�6   $	��Top=�5W      $��392,136,0,0q�6V    61   �� *OnBoardDate+6V     5X      -   5        $��dpArrivalDate��5X   4   $
��Left=�6   $	��Top=�5Y      $��122,168,0,0q�6V    61   �� *ArrivedDate+6V   �� 5Z      -   5         ��Name$ cboxCustomStatus��5Z   2   $
��Left=�6   $��392,168,0,0q�6L   $	��Top=�6a    �� DisplayMemberPath$	 Key��6�    �� SelectedValuePath$ Value��5[      ��5Z   y   �� *IsCustomeds+ �� SelectedValue 5[   1   �� *
IsCustomed+�� 5\      -   5        $ cboxFinancialStatus��5\   2   $
��Left=�6   $��122,200,0,0q�6O   $	��Top=�6d   $	 Key��6�   $ Value��5]      ��5\   |   �� *StatusTypes+ 5]   1   �� *FinanceStatus+�� 5^      -   5        $��tbShipNo��5^      $
��Left=�6&   $	��Top=�6A   $��122,232,0,0q�5_   0   ��6   �� *
VesselNo+60   �� 5`      -   5        $��tbPack��5`      $
��Left=�6$   $	��Top=�6?   $��392,232,0,0q�5a   7   ��6   �� *PackingStandard+67   �� 5b      -   5        $ cboxDeliveryPort��5b   2   $
��Left=�6   $��122,264,0,0q�6L   $	��Top=�6a   $
 Name��6�   $ Id��5c      ��5b   y   �� *LoadingPorts+ 5c   .   �� *LoadingPortId+�� 5d      -   5        $ cboxDeliveryPlace��5d   2   $
��Left=�6   $��392,264,0,0q�6M   $	��Top=�6b   $ ChineseName��6�   $ Id��5e      ��5d   z   �� *LoadingPlaces+ 5e   .   �� *LoadingPlaceId+�� 5f      -   5        $ cboxArrivalPort��5f   2   $
��Left=�6   $��122,296,0,7q�6K   $	��Top=�6`   $
 Name��6�   $ Id��5g      ��5f   x   �� *DischargePorts+ 5g   .   �� *DischargePortId+�� 5h      -   5        $ cboxArrivalPlace��5h   2   $
��Left=�6   $��392,296,0,7q�6L   $	��Top=�6a   $ ChineseName��6�   $ Id��5i      ��5h   y   �� *DischargePlaces+ 5i   .   �� *DischargePlaceId+�� 5j      -   5        $��btnAdd��5j   �   $��23��6^   $
��Left=�6j   $	��Top=�6�   $��45��6�   $y�	Collapsed=�6�   $��	122,1,0,0q�6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 AddWithSymbol��6�   �� 5k      -   5        $��button1��5k   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5l      $��45��6-   $��2��6M   ��5k        $!	 Client.Properties.Resources��$
 AddWithSymbol��5l   M   �� 5m       �� TextWrapping$
 Wrap=�6   $
��Left=�5n      $��	122,2,0,0q�61   $	��392��6D   $	��100��6P   $	��Top=�6]   $��3��6u   ��5m   *   �� *	Comment+5n   u   �� 5p      -   5        $��210,130,0,0q�5p   U   $
��Left=�5q      $	��Top=�60   $��60��6H   $��25��6`   $��3��6l   ��5p        $!	 Client.Properties.Resources��$

 Save��5q   l   �� 5r      -   5        $��305,130,0,0q�5r   W   $��60��5s      $
��Left=�6    $	��Top=�6;   $��25��6g   $��3��6s   ��5r        $!	 Client.Properties.Resources��$
 Cancel��5s   s   �� 5v      -   5         ��Name$ lbTitle��5v   4   $
��Left=�6E   $��6,6,0,0q�6`   $��16(�6q   $��74��5w      $
��Bold"�6   $��32��61   $	��Top=�6=   ��5v        *ExportDelivery+5w   =   �� 5x      -   5         ��Name$ 
tbCustomer��5x      $
��Left=�6*   $	��Top=�6E   {�.  $��
122,40,0,0q�5y   A   ��6   �� *	QuotaNo+6A   �� 5z      $
��Left=�6^   $��6,70,0,0q�6y   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 DocumentStatus��6�   �� 5{      -   5        $ tbStatus��5{      $��
122,72,0,0q�6(   $
��Left=�6<   $	��Top=�5|      {�.  ��6@   �� *ApproveStatus+�� 5}      -   5        $ label2��5}   T   $��
277,70,0,0q�6d   $
��Left=�5~      $��28��6/   $	��Top=�6;   ��5}        $!	 Client.Properties.Resources��$

 Type��5~   ;   �� 5      -   5        $ tbDeliveryType��5      $��
392,72,0,0q�6.   $
��Left=�6B   $	��Top=�5�      {�.  ��6@     *ExportDelivery+�� 5�      -   5        $ label15��5�   -   $��	6,102,0,0q�6>   $
��Left=�6Q   $	��Top=�5�      ��5�        *	Carrier+5�      �� 5�      -   5        $ 	tbShipper��5�      $
��Left=�6)   $	��Top=�6D   {�.  $��122,104,0,0q�5�   K   ��6   �� *ShippingPartyName+6K   �� 5�      -    5        $ label6��5�   3   $��277,102,0,0q�6C   $
��Left=�5�      $	��Top=�6/   ��5�        *ContactPerson+5�   /   �� 5�      -!   5        $ 	tbLinkman��5�      $
��Left=�6)   $	��Top=�6D   {�.  $��392,104,0,0q�5�   I   ��6   �� *NotifyPartyName+6I   �� 5�      -"   5        $ label3��5�      $��	6,134,0,0q�6$   $
��Left=�67   
���<��$	��Top=�5�   [   ��6     $!	 Client.Properties.Resources��$
 IssuingDate��5�      �� 5�      -#   5        $ label13��5�   X   $��277,134,0,0q�6i   $
��Left=�5�      $	��Top=�6/   ��5�        $!	 Client.Properties.Resources��$
 ShipDate��5�   /   �� 5�      -$   5        $ label14��5�   1   $��	6,166,0,0q�6B   $
��Left=�6U   $	��Top=�5�      ��5�        *ArrivalDate+5�      �� 5�      -%   5        $ label17��5�   2   $��277,166,0,0q�6C   $
��Left=�5�      $	��Top=�6/   ��5�        *CustomStatus+5�   /   �� 5�      -&   5        $ label7��5�   _   $��	6,198,0,0q�6o   $
��Left=�6�   $	��Top=�5�      ��5�        $!	 Client.Properties.Resources��$
 FinancialStatus��5�      �� 5�      -'   5        $ label12��5�   ,   $��	6,230,0,0q�6=   $
��Left=�6P   $��28��6k   $	��Top=�5�      ��5�        *HullNo+5�      �� 5�      -(   5        $ label16��5�   1   $��277,230,0,0q�6B   $
��Left=�5�      $	��Top=�6/   ��5�        *PackingSpec+5�   /   �� 5�      -)   5        $ label18��5�   1   $��	6,262,0,0q�6B   $
��Left=�6U   $	��Top=�5�      ��5�        *LoadingPort+5�      �� 5�      -*   5        $ label19��5�   2   $��277,262,0,0q�6C   $
��Left=�5�      $	��Top=�6/   ��5�        *LoadingPlace+5�   /   �� 5�      -+   5        $ label20��5�   3   $��	6,294,0,0q�6D   $
��Left=�6W   $	��Top=�5�      ��5�        *UnloadingPort+5�      �� 5�      -,   5        $ label21��5�   4   $��277,294,0,0q�6E   $
��Left=�5�      $	��Top=�6/   ��5�        *UnloadingPlace+5�   /   &   System.Windows.Controls.DataGrid  5�      --   5        $��dataGridDeliveryLines��5�   2      CanUserSortColumns .  $��	122,2,0,7q�5�         CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�5�      $
��auto��62   $
��auto��6?   $	��Top=�6M   $��1��6e   ��5�   A   ��    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header 6)     $!	 Client.Properties.Resources��$
 	Commodity��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6m   �� *CommodityType.Commodity.Name+  5�       6)     $!	 Client.Properties.Resources��$
 CommodityType�� 6q   �� *CommodityType.Name+  5�       6)     $!	 Client.Properties.Resources��$
 Brand�� 6i   �� *
Brand.Name+  5�       6)     $!	 Client.Properties.Resources��$
 OriginCountry�� 6q   �� *Country.ChineseName+  5�       6)     $!	 Client.Properties.Resources��$
 	NetWeight�� 6m   �� *	NetWeight+$	   DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY  �� StringFormat#  Z   5�       6)     $!	 Client.Properties.Resources��$
 GrossWeight�� 6o   �� *GrossWeight+#  Z   5�       6)     $!	 Client.Properties.Resources��$
 Bundle�� 6j   �� *PackingQuantity+#  Z   5�       6)     $!	 Client.Properties.Resources��$
 Comments�� 6l   �� *	Comment+4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      !   CanUserSort! .  " 
  CellTemplate#" [ 5�   -    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�   -   5�      �� 5�      $��6,0,0,0q�6X   $
��Left=�6i   $	��Top=�6�   $��3��6�   ��6     $!	 Client.Properties.Resources��$
 Comments��6�   �� 5�      -.   5        $��label9��5�   O   $��28��6   $
��Left=�6    $��
277,38,0,0q�6;   
���<��$	��Top=�6�   ��6r     *ImportDelivery+5�      �� 5�      -/   5        $��textBox1��5�   W   $
��Left=�6   {�.  $��
392,40,0,0q�6C   $	��Top=�5�   3   ��6   �� *TDeliveryNo+63   �� 5�      -0   5        $��label1��5�   k   $��6,0,0,0q�6Z   $	��Top=�6y   $
��Left=�6�   $��2��6�   ��6     $!	 Client.Properties.Resources��$
 
Attachment��6�     5�      -1   5        $��dataGridAttachment��5�   K    .   .  .  $��26��5�   .   $
��Left=�6:   $��
122,34,0,7q�5�      $	��Top=�6+   $��82��6C   $��2��6N   ��5�   3   ��  5�        5�       6)     $!	 Client.Properties.Resources��$
 AttachmentName�� 6r   �� *Name+
  5�      #" [ 6q   ! .   6-     $!	 Client.Properties.Resources��$
 	Operation��5�   -   5�      �� 5�      -2   5        $��label4��5�   �   $
��Left=�6V   $��6,0,0,0q�6q   $	��Top=�5�      $��1��6,   ��5�        $!	 Client.Properties.Resources��$
 Detail��5�   ,   �� 5�      -3   5        $��label5��5�   p   $
��Left=�6U   $	��Top=�6~   
���<��$��6,38,0,0q�6�   ��6     $!	 Client.Properties.Resources��$
 Quota��6�   �� 5�      -4   5        $��label8��5�   _   $��发货单号��6   $��28��6#   $
��Left=�6/   $��277,198,0,0q�6J   $	��Top=�6m   $	��110��6�   �� 5�      -5   5        $��textBox2��5�   R   $��23��6   $
��Left=�6"   $��393,200,0,0q�6=   $	��Top=�6b   $	��120��6z   ��6�   �� *
DeliveryNo+5�      5�      5�      