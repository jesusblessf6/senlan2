   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  :   4Client.View.Physical.Deliveries.ImportDeliveryDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     <baseClient2$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     +  %Client.Base.BaseClient.ObjectBasePage    Loaded$  ObjectBasePageLoaded��0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ImportDelivery+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   AttachmentDownLoad  AttachmentDelete  AttachmentActions �� DataType	 �� Orientation
   ResxName
   Key  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  '��       '�� S     '�� �     '  �     &	      &	     &	     7   7  &	      &	 %    &	 *    7  7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� $ DBEntity:Attachment��.R��� $	 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $!
 Client.Properties.Resources��$ Download������ *Id+�� $��btAttachmentDelete��8�� ��  $!
 Client.Properties.Resources��$ Delete������ *Id+�� �� �� $ DBEntity:DeliveryLine��.R��� $	 
Horizontal=�.+��� $��btDeliveryEdit��8��  ��  $!
 Client.Properties.Resources��$
 Edit������ *Id+�� $��btDeliveryDelete��8�� ��  $!
 Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [    -   # [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $��0 ��� $
��auto ��� $��0 ��� $
��auto ��� $��0 ��� $
��auto ��� $��0 ��� $
��auto ��� $��0 ��� $	��55* �.+��� -   $��tbDeliveryNo��$
��Left=�$	��Top=�$��
394,72,0,0q�{�.  ���� *
DeliveryNo+�� -   $��btnOrderLine��$	��...��$��23��$��25��$
��Left=�$��
246,72,0,0q�$	��Top=�{��� *IsQuotaEnable+ � ToolTip �� *ContractInfo+�� -   $��
btnShipper��$	��...��$��23��$��25��$
��Left=�$��246,136,0,0q�$	��Top=�$y�	Collapsed=�  -	   $��
dpSignDate��$
��Left=�$	��Top=�$��122,200,0,0q�   SelectedDate �� *	IssueDate+	� -
   $��radioButton1��$��20��$
��Left=�$��
190,40,0,0q� 	� 	GroupName$ rbIsCopy��$	��Top=���  *Copy+ d� 	IsChecked �� *IsCopyFirst+	� -   $��radioButton2��$��20��$
��Left=�$��
394,40,0,0q�$ rbIsCopy��$	��Top=���  *
Original+ �� *IsCopySecond+�� -   $��btnShippingParty��$	��...��$��23��$��25��$
��Left=�$��246,168,0,0q�$	��Top=�$y�	Collapsed=��� -   $��
btnLinkman��$	��...��$��23��$��25��$
��Left=�$��518,168,0,0q�$	��Top=�$y�	Collapsed=�  -   $��dpDeliveryDate��$
��Left=�$	��Top=�$��394,200,0,0q�{�.   �� *OnBoardDate+  -   $��dpArrivalDate��$
��Left=�$	��Top=�$��122,232,0,0q�{�.  �� *ArrivedDate+�� -    ��Name$ cboxCustomStatus��$
��Left=�$��394,232,0,0q�$	��Top=� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value�� �� 
IsReadOnly . {�.  ���� *IsCustomeds+ �� SelectedValue �� *
IsCustomed+�� -   $ cboxFinancialStatus��$
��Left=�$��122,264,0,0q�$	��Top=�$	 Key��$ Value�� . {�.  ���� *StatusTypes+ �� *FinanceStatus+�� -   $��tbShipNo��$
��Left=�$	��Top=�$��394,136,0,0q�{�.  ���� *
VesselNo+�� -   $��tbPack��$
��Left=�$	��Top=�$��394,264,0,0q�{�.  ���� *PackingStandard+�� -   $ cboxDeliveryPort��$
��Left=�$��122,328,0,0q�$	��Top=�$
 Name��$ Id�� . {�.  ���� *LoadingPorts+ �� *LoadingPortId+�� -   $ cboxDeliveryPlace��$
��Left=�$��122,296,0,0q�$	��Top=�$ ChineseName��$ Id�� . {�.  ���� *LoadingPlaces+ �� *LoadingPlaceId+�� -   $ cboxArrivalPort��$
��Left=�$��394,328,0,0q�$	��Top=�$
 Name��$ Id�� . {�.  ���� *DischargePorts+ �� *DischargePortId+�� -   $ cboxArrivalPlace��$
��Left=�$��394,296,0,0q�$	��Top=�$ ChineseName��$ Id�� . {�.  ���� *DischargePlaces+ �� *DischargePlaceId+�� -   $��btnAdd��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��4��$y�	Collapsed=���  $!
 Client.Properties.Resources��$ AddWithSymbol���� -   $��button1��$��23��$
��Left=�$��	122,9,0,0q�$	��Top=�$��45��$��8��$y�	Collapsed=���  $!
 Client.Properties.Resources��$ AddWithSymbol���� $��10�� �� TextWrapping$
 Wrap=�$��	122,2,0,0q�$
��Left=�$	��392��$	��100��$	��Top=����� *	Comment+�� -   $��210,130,0,0q�$��10��$
��Left=�$	��Top=�$��60��$��25����  $!
 Client.Properties.Resources��$
 Save���� -   $��305,130,0,0q�$��10��$��60��$
��Left=�$	��Top=�$��25����  $!
 Client.Properties.Resources��$ Cancel���� -    ��Name$ lbTitle��$
��Left=�$��6,6,0,0q�$��16(�$
��auto��$
��Bold"�$��32��$	��Top=���  *ImportDelivery+�� $
��Left=�$��
278,70,0,0q�$	��Top=�
���<����  $!
 Client.Properties.Resources��$
 BLNo���� -   $��label1��$
��Left=�$��6,70,0,0q�$	��Top=�
���<����  $!
 Client.Properties.Resources��$ Quota���� -    ��Name$ 
tbCustomer��$
��Left=�$	��Top=�{�.  $��
122,72,0,0q����� *	QuotaNo+�� $
��Left=�$��	6,102,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ DocumentStatus���� -   $ tbStatus��$��122,104,0,0q�$
��Left=�$	��Top=�{�.  ���� *ApproveStatus+�� -    $ label2��$��278,102,0,0q�$
��Left=�$	��Top=���  $!
 Client.Properties.Resources��$
 Type���� -!   $ tbDeliveryType��$��394,104,0,0q�$
��Left=�$	��Top=�{�.  ��  *ImportDelivery+�� -"   $ label5��$��	6,134,0,0q�$
��Left=�$	��Top=�
���<����  *	Consignor+�� -#   $ tbConsignor��$	��Top=�{�.  $��122,136,0,0q�$
��Left=�$	��120������ *ShipperName+�� -$   $ label15��$��	6,166,0,0q�$
��Left=�$	��Top=���  *	Carrier+�� -%   $ 	tbShipper��$��23��$
��Left=�$	��Top=�{�.  $��122,168,0,0q����� *ShippingPartyName+�� -&   $ label6��$��278,166,0,0q�$
��Left=�$	��Top=���  *ContactPerson+�� -'   $ 	tbLinkman��$
��Left=�$	��Top=�{�.  $��394,168,0,0q����� *NotifyPartyName+�� -(   $ label3��$��	6,198,0,0q�$
��Left=�$	��Top=�
���<����  $!
 Client.Properties.Resources��$ IssuingDate���� -)   $ label13��$��278,198,0,0q�$
��Left=�$	��Top=���  $!
 Client.Properties.Resources��$ ShipDate���� -*   $ label14��$��	6,230,0,0q�$
��Left=�$	��Top=���  *ArrivalDate+�� -+   $ label17��$��278,230,0,0q�$
��Left=�$	��Top=���  *CustomStatus+�� -,   $ label7��$��	6,262,0,0q�$
��Left=�$	��Top=���  $!
 Client.Properties.Resources��$ FinancialStatus���� --   $ label12��$��278,134,0,0q�$
��Left=�$	��Top=���  *HullNo+�� -.   $ label16��$��278,262,0,0q�$
��Left=�$	��Top=���  *PackingSpec+�� -/   $ label18��$��	6,326,0,0q�$
��Left=�$	��Top=���  *LoadingPort+�� -0   $ label19��$��	6,294,0,0q�$
��Left=�$	��Top=���  *LoadingPlace+�� -1   $ label20��$��278,326,0,0q�$
��Left=�$	��Top=���  *UnloadingPort+�� -2   $ label21��$��278,294,0,0q�$
��Left=�$	��Top=���  *UnloadingPlace+&   System.Windows.Controls.DataGrid  -3   $��dataGridDeliveryLines��   CanUserSortColumns .  $��	122,2,0,7q�$��4��   CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$
��auto��$
��auto��$	��Top=�����     Columns  0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn!   Header!   $!
 Client.Properties.Resources��$
 Type��1	  +System.Windows.Controls.DataGridBoundColumn" 	  Binding" �� *CommodityType.Name+  !   $!
 Client.Properties.Resources��$ Brand��" �� *
Brand.Name+  !   $!
 Client.Properties.Resources��$ OriginCountry��" �� *Country.ChineseName+  !   $!
 Client.Properties.Resources��$ 	NetWeight��" �� *	NetWeight+$
   DBEntity.EnumEntity.RoundRules# 
  STR_QUANTITY$ �� StringFormat#$ Z#   !   $!
 Client.Properties.Resources��$ GrossWeight��" �� *GrossWeight+#$ Z#   !   $!
 Client.Properties.Resources��$ Bundle��" �� *PackingQuantity+#$ Z#   !   $!
 Client.Properties.Resources��$ Comments��" �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  %   CanUserSort% .  &   CellTemplate#& [ '   
Visibility$' 	Collapsed=�!   $!
 Client.Properties.Resources��$ 	Operation���� $��6,0,0,0q�$��8��$
��Left=�$	��Top=���  $!
 Client.Properties.Resources��$ 
Attachment���� $��6,0,0,0q�$��10��$
��Left=�$	��Top=���  $!
 Client.Properties.Resources��$ Comments��  -4   $��dataGridAttachment�� .   .  $
��auto��$
��Left=� . $
��auto��$��8��$��	122,2,0,7q�$	��Top=�����     (   Width5  /System.Windows.Controls.DataGridLengthConverter$
( Auto " �� *Name+!   $!
 Client.Properties.Resources��$ AttachmentName��  % .  #& [ $' 	Collapsed=�!   $!
 Client.Properties.Resources��$ 	Operation���� -5   $��label8��$
��Left=�$��6,0,0,0q�$	��Top=�$��4����  $!
 Client.Properties.Resources��$ Detail���� -6   $��txtCirculNo��$
��Left=�$��122,360,0,7q�) �� 
IsReadOnly) .  ���� *
CirculNo+�� -7   $��label4��$
��Left=�$��Right=�$��	6,358,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ FlowId���� -8   $��button2��$	��...��$��23��$
��Left=�$��
518,71,0,0q�$	��Top=�$��25��{��� *IsPoolNoBtnEnale+�� -9   $��label9��$��金属��$��28��$
��Left=�$��278,358,0,0q�$	��Top=�$	��110���� -:   $��textBox1��$��23��$
��Left=�$��394,360,0,0q�$	��Top=�$	��120��) . {�.  ���� *Commodity.Name+