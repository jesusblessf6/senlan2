   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5
      :   4Client.View.Physical.Deliveries.ImportDeliveryDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      <baseClient2$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      +  %Client.Base.BaseClient.ObjectBasePage    Loaded$  ObjectBasePageLoaded��5   4   0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *ImportDelivery+ � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   AttachmentDownLoad  AttachmentDelete  AttachmentActions �� DataType	 �� Orientation
   ResxName
   Key  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  '��       '�� �     '��     '  �    &	      &	     &	 .    7   7  &	 �    &	 �    &	 �    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5        � ��$	 120��6&   64   5!      �� 5#   
   65   �� 5$   
   63   �� 5&   
   $ DBEntity:Attachment��61   .R�5'      �� $	 
Horizontal=�6   .+�5(      �� $��btAttachmentDownLoad��6   8��  ��65     $!
 Client.Properties.Resources��$ Download����5)      �� *Id+6;   �� 5*      $��btAttachmentDelete��6   8�� ��63     $!
 Client.Properties.Resources��$ Delete����5+      �� *Id+6;   5,      5-      �� 5/   
   6/   �� 50   
   61   �� 52   
   $ DBEntity:DeliveryLine��6/   .R�53      �� $	 
Horizontal=�6   .+�54      �� $��btDeliveryEdit��6   8��  ��6/     $!
 Client.Properties.Resources��$
 Edit����55      �� *Id+6;   �� 56      $��btDeliveryDelete��6   8�� ��61     $!
 Client.Properties.Resources��$ Delete����57      �� *Id+6;   58      59      5:       J� CommandBindings 5<      )  #System.Windows.Input.CommandBinding  5=   
   -   5           Command# [ 5=      5>   ?     5?   
   -   5        # [ 5?      5@   A     5B   
   -   5        # [  5B      5C   A     5D   
   -   5        # [ 5D      5E   ?   .��5H      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5I      .��5J   
   � -   5         �Name$ rootGrid��5J       � RowDefinitions 5K      �� 5L      $
��Auto �6    �� 5M      $��0 �6    �� 5N      $
��auto �6    �� 5O      $��0 �6    �� 5P      $
��auto �6    �� 5Q      $��0 �6    �� 5R      $
��auto �6    �� 5S      $��0 �6    �� 5T      $
��auto �6    �� 5U      $��0 �6    �� 5V      $	��55* �6    .+�5Y      �� -   5        $��tbDeliveryNo��5Y      $
��Left=�6*   $	��Top=�6E   $��
394,72,0,0q�5Z      {�.  ��5Y   ]   �� *
DeliveryNo+5Z   *   �� 5[      -   5        $��btnOrderLine��5[   :   $	��...��6   $��23��6#   $��25��6/   $
��Left=�5\      $��
246,72,0,0q�60   $	��Top=�6D   {�6\   �� *IsQuotaEnable+ � ToolTip 6�   �� *ContractInfo+�� 5]      -   5        $��
btnShipper��5]   :   $	��...��6   $��23��6#   $��25��6/   $
��Left=�5^      $��246,136,0,0q�60   $	��Top=�6E   $y�	Collapsed=�6]     5_      -	   5        $��
dpSignDate��5_   4   $
��Left=�6   $	��Top=�6F   $��122,200,0,0q�5`   <      SelectedDate 6   �� *	IssueDate+6<   	� 5a      -
   5        $��radioButton1��5a   k   $��20��60   $
��Left=�6<   $��
190,40,0,0q�6W    	� 	GroupName$ rbIsCopy��5b      $	��Top=�6Q   ��5a        *Copy+ d� 	IsChecked 5b   /   �� *IsCopyFirst+6Q   	� 5c      -   5        $��radioButton2��5c   o   $��20��64   $
��Left=�6@   $��
394,40,0,0q�6[   $ rbIsCopy��5d      $	��Top=�6R   ��5c        *
Original+ 5d   /   �� *IsCopySecond+6R   �� 5e      -   5        $��btnShippingParty��5e   /   $	��...��6   $��23��6#   $��25��6G   $
��Left=�5f      $��246,168,0,0q�60   $	��Top=�6E   $y�	Collapsed=�6]   �� 5g      -   5        $��
btnLinkman��5g   /   $	��...��6   $��23��6#   $��25��6A   $
��Left=�5h      $��518,168,0,0q�60   $	��Top=�6E   $y�	Collapsed=�6]     5i      -   5        $��dpDeliveryDate��5i   4   $
��Left=�6   $	��Top=�6J   $��394,200,0,0q�5j   >   {�.   6   �� *OnBoardDate+6S     5k      -   5        $��dpArrivalDate��5k   4   $
��Left=�6   $	��Top=�6I   $��122,232,0,0q�5l   >   {�.  6   �� *ArrivedDate+6S   �� 5m      -   5         ��Name$ cboxCustomStatus��5m   2   $
��Left=�6   $��394,232,0,0q�6L   $	��Top=�6a    �� DisplayMemberPath$	 Key��5n   ;    �� SelectedValuePath$ Value��6S    �� 
IsReadOnly . {�.  ��6   �� *IsCustomeds+ �� SelectedValue 5o      �� *
IsCustomed+6N   �� 5p      -   5        $ cboxFinancialStatus��5p   2   $
��Left=�6   $��122,264,0,0q�6O   $	��Top=�5q      $	 Key��6S   $ Value��6k    . {�.  ��6/   �� *StatusTypes+ 5r      �� *FinanceStatus+6Q   �� 5s      -   5        $��tbShipNo��5s      $
��Left=�6&   $	��Top=�6A   $��394,136,0,0q�5t      {�.  ��5s   Y   �� *
VesselNo+5t   +   �� 5u      -   5        $��tbPack��5u      $
��Left=�6$   $	��Top=�6?   $��394,264,0,0q�5v      {�.  ��5u   W   �� *PackingStandard+5v   +   �� 5w      -   5        $ cboxDeliveryPort��5w   2   $
��Left=�6   $��122,328,0,0q�6L   $	��Top=�6a   $
 Name��5x   <   $ Id��6U    . {�.  ��6   �� *LoadingPorts+ 5y      �� *LoadingPortId+6Q   �� 5z      -   5        $ cboxDeliveryPlace��5z   2   $
��Left=�6   $��122,296,0,0q�6M   $	��Top=�6b   $ ChineseName��5{   =   $ Id��6]    . {�.  ��6   �� *LoadingPlaces+ 5|      �� *LoadingPlaceId+6R   �� 5}      -   5        $ cboxArrivalPort��5}   2   $
��Left=�6   $��394,328,0,0q�6K   $	��Top=�6`   $
 Name��5~   >   $ Id��6W    . {�.  ��6   �� *DischargePorts+ 5      �� *DischargePortId+6S   �� 5�      -   5        $ cboxArrivalPlace��5�   2   $
��Left=�6   $��394,296,0,0q�6L   $	��Top=�6a   $ ChineseName��5�   ?   $ Id��6_    . {�.  ��6   �� *DischargePlaces+ 5�      �� *DischargePlaceId+6T   �� 5�      -   5        $��btnAdd��5�   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5�      $��45��6-   $��4��6L   $y�	Collapsed=�6Y   ��5�        $!
 Client.Properties.Resources��$ AddWithSymbol��5�   Y   �� 5�      -   5        $��button1��5�   �   $��23��6^   $
��Left=�6j   $��	122,9,0,0q�6�   $	��Top=�5�      $��45��6-   $��8��68   $y�	Collapsed=�6Z   ��5�        $!
 Client.Properties.Resources��$ AddWithSymbol��5�   Z   �� 5�      $��10��6    �� TextWrapping$
 Wrap=�6$   $��	122,2,0,0q�6Q   $
��Left=�5�      $	��392��61   $	��100��6=   $	��Top=�6J   ��5�   8   �� *	Comment+5�   J   �� 5�      -   5        $��210,130,0,0q�5�   U   $��10��6j   $
��Left=�5�      $	��Top=�60   $��60��6H   $��25��6`   ��5�        $!
 Client.Properties.Resources��$
 Save��5�   `   �� 5�      -   5        $��305,130,0,0q�5�   W   $��10��6l   $��60��6�   $
��Left=�5�      $	��Top=�60   $��25��6W   ��5�        $!
 Client.Properties.Resources��$ Cancel��5�   W   �� 5�      -   5         ��Name$ lbTitle��5�   4   $
��Left=�6E   $��6,6,0,0q�6`   $��16(�6q   $
��auto��5�      $
��Bold"�6!   $��32��63   $	��Top=�6?   ��5�        *ImportDelivery+5�   ?   �� 5�      $
��Left=�6   $��
278,70,0,0q�6/   $	��Top=�6C   
���<����5�        $!
 Client.Properties.Resources��$
 BLNo��6V   �� 5�      -   5        $��label1��5�      $
��Left=�6"   $��6,70,0,0q�6=   $	��Top=�6O   
���<����5�   )     $!
 Client.Properties.Resources��$ Quota��6l   �� 5�      -   5         ��Name$ 
tbCustomer��5�      $
��Left=�6*   $	��Top=�6E   {�.  $��
122,72,0,0q�5�   (   ��5�   ]   �� *	QuotaNo+5�   (   �� 5�      $
��Left=�6^   $��	6,102,0,0q�6y   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ DocumentStatus��6�   �� 5�      -   5        $ tbStatus��5�      $��122,104,0,0q�6(   $
��Left=�6=   $	��Top=�6X   {�.  ��5�   (   �� *ApproveStatus+�� 5�      -    5        $ label2��5�   T   $��278,102,0,0q�6d   $
��Left=�6y   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$
 Type��6�   �� 5�      -!   5        $ tbDeliveryType��5�      $��394,104,0,0q�6.   $
��Left=�6C   $	��Top=�6^   {�.  ��5�   (     *ImportDelivery+�� 5�      -"   5        $ label5��5�      $��	6,134,0,0q�6$   $
��Left=�67   $	��Top=�6R   
���<����5�   )     *	Consignor+6F   �� 5�      -#   5        $ tbConsignor��5�      $	��Top=�6+   {�.  $��122,136,0,0q�5�      $
��Left=�6+   $	��120��6F   ��5�   C   �� *ShipperName+5�   F   �� 5�      -$   5        $ label15��5�   -   $��	6,166,0,0q�6>   $
��Left=�6Q   $	��Top=�5�      ��5�        *	Carrier+5�      �� 5�      -%   5        $ 	tbShipper��5�   "   $��23��6   $
��Left=�65   $	��Top=�6P   {�.  $��122,168,0,0q�5�   K   ��6   �� *ShippingPartyName+6K   �� 5�      -&   5        $ label6��5�   3   $��278,166,0,0q�6C   $
��Left=�6X   $	��Top=�5�      ��5�        *ContactPerson+5�      �� 5�      -'   5        $ 	tbLinkman��5�      $
��Left=�6)   $	��Top=�6D   {�.  $��394,168,0,0q�5�   I   ��6   �� *NotifyPartyName+6I   �� 5�      -(   5        $ label3��5�      $��	6,198,0,0q�6$   $
��Left=�67   $	��Top=�6R   
���<����5�        $!
 Client.Properties.Resources��$ IssuingDate��6r   �� 5�      -)   5        $ label13��5�   X   $��278,198,0,0q�6i   $
��Left=�6~   $	��Top=�5�      ��5�        $!
 Client.Properties.Resources��$ ShipDate��5�      �� 5�      -*   5        $ label14��5�   1   $��	6,230,0,0q�6B   $
��Left=�6U   $	��Top=�5�      ��5�        *ArrivalDate+5�      �� 5�      -+   5        $ label17��5�   2   $��278,230,0,0q�6C   $
��Left=�6X   $	��Top=�5�      ��5�        *CustomStatus+5�      �� 5�      -,   5        $ label7��5�   _   $��	6,262,0,0q�6o   $
��Left=�6�   $	��Top=�5�      ��5�        $!
 Client.Properties.Resources��$ FinancialStatus��5�      �� 5�      --   5        $ label12��5�   ,   $��278,134,0,0q�6=   $
��Left=�6R   $	��Top=�5�      ��5�        *HullNo+5�      �� 5�      -.   5        $ label16��5�   1   $��278,262,0,0q�6B   $
��Left=�6W   $	��Top=�5�      ��5�        *PackingSpec+5�      �� 5�      -/   5        $ label18��5�   1   $��	6,326,0,0q�6B   $
��Left=�6U   $	��Top=�5�      ��5�        *LoadingPort+5�      �� 5�      -0   5        $ label19��5�   2   $��	6,294,0,0q�6C   $
��Left=�6V   $	��Top=�5�      ��5�        *LoadingPlace+5�      �� 5�      -1   5        $ label20��5�   3   $��278,326,0,0q�6D   $
��Left=�6Y   $	��Top=�5�      ��5�        *UnloadingPort+5�      �� 5�      -2   5        $ label21��5�   4   $��278,294,0,0q�6E   $
��Left=�6Z   $	��Top=�5�      ��5�        *UnloadingPlace+5�      &   System.Windows.Controls.DataGrid  5�      -3   5        $��dataGridDeliveryLines��5�   R      CanUserSortColumns .  $��	122,2,0,7q�62   $��4��6E      CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�5�   t   $
��auto��6�   $
��auto��5�      $	��Top=�6$   ��5�   .   ��     Columns  5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn!   Header! 6)     $!
 Client.Properties.Resources��$
 Type��1	  +System.Windows.Controls.DataGridBoundColumn" 	  Binding" 6h   �� *CommodityType.Name+  5�      ! 6)     $!
 Client.Properties.Resources��$ Brand��" 6i   �� *
Brand.Name+  5�      ! 6)     $!
 Client.Properties.Resources��$ OriginCountry��" 6q   �� *Country.ChineseName+  5�      ! 6)     $!
 Client.Properties.Resources��$ 	NetWeight��" 6m   �� *	NetWeight+$
   DBEntity.EnumEntity.RoundRules# 
  STR_QUANTITY$ �� StringFormat#$ Z#   5�      ! 6)     $!
 Client.Properties.Resources��$ GrossWeight��" 6o   �� *GrossWeight+#$ Z#   5�      ! 6)     $!
 Client.Properties.Resources��$ Bundle��" 6j   �� *PackingQuantity+#$ Z#   5�      ! 6)     $!
 Client.Properties.Resources��$ Comments��" 6l   �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  5�      %   CanUserSort% .  &   CellTemplate#& [ 5�   -   '   
Visibility$' 	Collapsed=�6]   ! 5�   -     $!
 Client.Properties.Resources��$ 	Operation��5�   ]   5�      �� 5�      $��6,0,0,0q�6Z   $��8��6k   $
��Left=�6x   $	��Top=�5�      ��5�        $!
 Client.Properties.Resources��$ 
Attachment��5�      �� 5�      $��6,0,0,0q�6X   $��10��6i   $
��Left=�6w   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ Comments��6�     5�      -4   5        $��dataGridAttachment��5�   A    .   .  $
��auto��5�   J   $
��Left=�6X    . $
��auto��5�   [   $��8��6h   $��	122,2,0,7q�6u   $	��Top=�6�   ��6)   ��   5�        5�      (   Width5  /System.Windows.Controls.DataGridLengthConverter$
( Auto 6�   " 6)   �� *Name+! 6B     $!
 Client.Properties.Resources��$ AttachmentName��6�     5�      % .  #& [ 6A   $' 	Collapsed=�5�   q   ! 6-     $!
 Client.Properties.Resources��$ 	Operation��6q   5�      �� 5�      -5   5        $��label8��5�   �   $
��Left=�6V   $��6,0,0,0q�6q   $	��Top=�5�      $��4��6,   ��5�        $!
 Client.Properties.Resources��$ Detail��5�   ,   �� 5�      -6   5        $��txtCirculNo��5�   F   $
��Left=�6   $��122,360,0,7q�61   ) �� 
IsReadOnly) .  ��6Y   �� *
CirculNo+6s   �� 5�      -7   5        $��label4��5�   �   $
��Left=�6V   $��Right=�6r   $��	6,358,0,0q�6�   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ FlowId��6�   �� 5�      -8   5        $��button2��5�   �   $	��...��6   $��23��6#   $
��Left=�6/   $��
518,71,0,0q�6q   $	��Top=�6�   $��25��6�   {�6J   �� *IsPoolNoBtnEnale+6�   �� 5�      -9   5        $��label9��5�   ]   $��金属��6   $��28��6!   $
��Left=�6-   $��278,358,0,0q�6H   $	��Top=�6k   $	��110��6�   �� 5�      -:   5        $��textBox1��5�   R   $��23��6   $
��Left=�6"   $��394,360,0,0q�6=   $	��Top=�6b   $	��120��6z   ) . {�.  ��5�      �� *Commodity.Name+5�      5�      5�      