   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  4   .Client.View.Physical.Deliveries.ExportDelivery   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ExportDelivery+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   DeliveryEdit  DeliveryDelete  AttachmentDownLoad  AttachmentDelete  AttachmentActions �� DataType �� Orientation	   ResxName

   Key  DeliveryActions��%�  '��       '�� S     '�� �     '  �     &	      &	     &	     &	     &	     7  7  &	 *    7   7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� �� �� $ DBEntity:Attachment��.R��� $ 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $!	 Client.Properties.Resources��$
 Download������ *Id+�� $��btAttachmentDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+�� $ DBEntity:Delivery��.R��� $ 
Horizontal=�.+��� $��btDeliveryEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��btDeliveryDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��462* �.+��� -   $��btnOrderLine��$	��...��$��23��$��25��$
��Left=�$��
246,40,0,0q�$	��Top=�{��� *IsQuotaEnable+ � ToolTip �� *ContractInfo+�� -   $��btnTD��$	��...��$��23��$
��Left=�$��
516,40,0,0q�$��25��$	��Top=�{��� *
IsTDEnable+  -   $��
dpSignDate��$
��Left=�$	��Top=�$��122,136,0,0q�   SelectedDate �� *	IssueDate+�� -	   $��btnShippingParty��$	��...��$��23��$��25��$
��Left=�$��246,104,0,0q�$	��Top=��� -
   $��
btnLinkman��$	��...��$��23��$��25��$
��Left=�$��516,104,0,0q�$	��Top=�  -   $��dpDeliveryDate��$
��Left=�$	��Top=�$��392,136,0,0q� �� *OnBoardDate+  -   $��dpArrivalDate��$
��Left=�$	��Top=�$��122,168,0,0q� �� *ArrivedDate+�� -    ��Name$ cboxCustomStatus��$
��Left=�$��392,168,0,0q�$	��Top=� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value������ *IsCustomeds+ �� SelectedValue �� *
IsCustomed+�� -   $ cboxFinancialStatus��$
��Left=�$��122,200,0,0q�$	��Top=�$	 Key��$ Value������ *StatusTypes+ �� *FinanceStatus+�� -   $��tbShipNo��$
��Left=�$	��Top=�$��122,232,0,0q����� *
VesselNo+�� -   $��tbPack��$
��Left=�$	��Top=�$��392,232,0,0q����� *PackingStandard+�� -   $ cboxDeliveryPort��$
��Left=�$��122,264,0,0q�$	��Top=�$
 Name��$ Id������ *LoadingPorts+ �� *LoadingPortId+�� -   $ cboxDeliveryPlace��$
��Left=�$��392,264,0,0q�$	��Top=�$ ChineseName��$ Id������ *LoadingPlaces+ �� *LoadingPlaceId+�� -   $ cboxArrivalPort��$
��Left=�$��122,296,0,7q�$	��Top=�$
 Name��$ Id������ *DischargePorts+ �� *DischargePortId+�� -   $ cboxArrivalPlace��$
��Left=�$��392,296,0,7q�$	��Top=�$ ChineseName��$ Id������ *DischargePlaces+ �� *DischargePlaceId+�� -   $��btnAdd��$��23��$
��Left=�$	��Top=�$��45��$y�	Collapsed=�$��	122,1,0,0q�$��1����  $!	 Client.Properties.Resources��$
 AddWithSymbol���� -   $��button1��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��2����  $!	 Client.Properties.Resources��$
 AddWithSymbol����  �� TextWrapping$
 Wrap=�$
��Left=�$��	122,2,0,0q�$	��392��$	��100��$	��Top=�$��3������ *	Comment+�� -   $��210,130,0,0q�$
��Left=�$	��Top=�$��60��$��25��$��3����  $!	 Client.Properties.Resources��$

 Save���� -   $��305,130,0,0q�$��60��$
��Left=�$	��Top=�$��25��$��3����  $!	 Client.Properties.Resources��$
 Cancel���� -    ��Name$ lbTitle��$
��Left=�$��6,6,0,0q�$��16(�$��74��$
��Bold"�$��32��$	��Top=���  *ExportDelivery+�� -    ��Name$ 
tbCustomer��$
��Left=�$	��Top=�{�.  $��
122,40,0,0q����� *	QuotaNo+�� $
��Left=�$��6,70,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 DocumentStatus���� -   $ tbStatus��$��
122,72,0,0q�$
��Left=�$	��Top=�{�.  ���� *ApproveStatus+�� -   $ label2��$��
277,70,0,0q�$
��Left=�$��28��$	��Top=���  $!	 Client.Properties.Resources��$

 Type���� -   $ tbDeliveryType��$��
392,72,0,0q�$
��Left=�$	��Top=�{�.  ��  *ExportDelivery+�� -   $ label15��$��	6,102,0,0q�$
��Left=�$	��Top=���  *	Carrier+�� -   $ 	tbShipper��$
��Left=�$	��Top=�{�.  $��122,104,0,0q����� *ShippingPartyName+�� -    $ label6��$��277,102,0,0q�$
��Left=�$	��Top=���  *ContactPerson+�� -!   $ 	tbLinkman��$
��Left=�$	��Top=�{�.  $��392,104,0,0q����� *NotifyPartyName+�� -"   $ label3��$��	6,134,0,0q�$
��Left=�
���<��$	��Top=���  $!	 Client.Properties.Resources��$
 IssuingDate���� -#   $ label13��$��277,134,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 ShipDate���� -$   $ label14��$��	6,166,0,0q�$
��Left=�$	��Top=���  *ArrivalDate+�� -%   $ label17��$��277,166,0,0q�$
��Left=�$	��Top=���  *CustomStatus+�� -&   $ label7��$��	6,198,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 FinancialStatus���� -'   $ label12��$��	6,230,0,0q�$
��Left=�$��28��$	��Top=���  *HullNo+�� -(   $ label16��$��277,230,0,0q�$
��Left=�$	��Top=���  *PackingSpec+�� -)   $ label18��$��	6,262,0,0q�$
��Left=�$	��Top=���  *LoadingPort+�� -*   $ label19��$��277,262,0,0q�$
��Left=�$	��Top=���  *LoadingPlace+�� -+   $ label20��$��	6,294,0,0q�$
��Left=�$	��Top=���  *UnloadingPort+�� -,   $ label21��$��277,294,0,0q�$
��Left=�$	��Top=���  *UnloadingPlace+&   System.Windows.Controls.DataGrid  --   $��dataGridDeliveryLines��   CanUserSortColumns .  $��	122,2,0,7q�   CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$
��auto��$
��auto��$	��Top=�$��1������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header   $!	 Client.Properties.Resources��$
 	Commodity��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *CommodityType.Commodity.Name+     $!	 Client.Properties.Resources��$
 CommodityType�� �� *CommodityType.Name+     $!	 Client.Properties.Resources��$
 Brand�� �� *
Brand.Name+     $!	 Client.Properties.Resources��$
 OriginCountry�� �� *Country.ChineseName+     $!	 Client.Properties.Resources��$
 	NetWeight�� �� *	NetWeight+$	   DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY  �� StringFormat#  Z      $!	 Client.Properties.Resources��$
 GrossWeight�� �� *GrossWeight+#  Z      $!	 Client.Properties.Resources��$
 Bundle�� �� *PackingQuantity+#  Z      $!	 Client.Properties.Resources��$
 Comments�� �� *	Comment+4
  .System.Windows.Controls.DataGridTemplateColumn
  !   CanUserSort! .  " 
  CellTemplate#" [    $!	 Client.Properties.Resources��$
 	Operation���� $��6,0,0,0q�$
��Left=�$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 Comments���� -.   $��label9��$��28��$
��Left=�$��
277,38,0,0q�
���<��$	��Top=���  *ImportDelivery+�� -/   $��textBox1��$
��Left=�{�.  $��
392,40,0,0q�$	��Top=����� *TDeliveryNo+�� -0   $��label1��$��6,0,0,0q�$	��Top=�$
��Left=�$��2����  $!	 Client.Properties.Resources��$
 
Attachment��  -1   $��dataGridAttachment�� .   .  .  $��26��$
��Left=�$��
122,34,0,7q�$	��Top=�$��82��$��2������       $!	 Client.Properties.Resources��$
 AttachmentName�� �� *Name+
  #" [ ! .     $!	 Client.Properties.Resources��$
 	Operation���� -2   $��label4��$
��Left=�$��6,0,0,0q�$	��Top=�$��1����  $!	 Client.Properties.Resources��$
 Detail���� -3   $��label5��$
��Left=�$	��Top=�
���<��$��6,38,0,0q���  $!	 Client.Properties.Resources��$
 Quota���� -4   $��label8��$��发货单号��$��28��$
��Left=�$��277,198,0,0q�$	��Top=�$	��110���� -5   $��textBox2��$��23��$
��Left=�$��393,200,0,0q�$	��Top=�$	��120������ *
DeliveryNo+