   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  <   6Client.View.Physical.Deliveries.PurchaseDeliveryDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6
Convertersclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     %  Client.Base.BaseClient.BasePage    Loaded$  
PageLoaded��0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ 
DomesticBL�� � 	Resources  �� 
TargetType �� Property	 �� Value(  "System.Windows.Controls.DatePicker+  %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  AttachmentDownLoad  AttachmentDelete  AttachmentActions
 �� DataType �� Orientation  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  '��       '�� S     '�� �     '  �     &	      &	     &	     &	     7  7  &	 %    &	 *    &	 /    7  7  �� " ��.���  � ��$	 28����  � ��$		 110����  � ��$	 Right=��� " ��.���  � ��$	 23����  � ��$		 120���� " ��.���  � ��$	 23����  � ��$		 120���� "  .���  � ��$	 23����  � ��$		 120��  �� �� �� $
 DBEntity:Attachment��.R��� $ 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $! Client.Properties.Resources��$ Download������ *Id+�� $��btAttachmentDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� �� �� $
 DBEntity:Delivery��.R��� $ 
Horizontal=�.+��� $��btDeliveryEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btDeliveryDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��tbDeliveryNo��$
��Left=�$��
122,40,0,0q�$��23��$	��Top=����� *
DeliveryNo+�� -   $��btnOrderLine��$	��...��$��23��$��25��$
��Left=�$	��Top=�$��
518,40,0,0q�{��� *IsQuotaEnable+ � ToolTip �� *ContractInfo+  -   $��
dpSignDate��$
��Left=�$��23��$	��Top=�$��122,104,0,0q�   SelectedDate �� *	IssueDate+�� -	   $��btnWarehouse��$	��...��$��23��$��25��$
��Left=�$��518,136,0,7q�$	��Top=�{��� *IsWarehouseEnable+�� -
   $��btnWarehouseCompany��$	��...��$��23��$��25��$
��Left=�$	��Top=�$��246,136,0,0q��� -    ��Name$ cboxFinancialStatus��$
��Left=�$	��Top=� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value��$��394,104,0,0q����� *StatusTypes+ �� SelectedValue �� *FinanceStatus+�� -   $��btnAdd��$��23��$
��Left=�$	��Top=�$��45��$��	122,2,0,7q�$��1����  $! Client.Properties.Resources��$ AddWithSymbol���� -   $��button1��$��23��$
��Left=�$	��Top=�$��45��$��	122,2,0,0q�$��2����  $! Client.Properties.Resources��$ AddWithSymbol����  �� TextWrapping$
 Wrap=�$	��392��$	��100��$	��Top=�$
��Left=�$��	122,2,0,0q�$��3������ *	Comment+�� -   $��210,130,0,0q�$��25��$
��Left=�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$
 Save���� -   $��305,130,0,0q�$��25��$��60��$
��Left=�$	��Top=�$��3����  $! Client.Properties.Resources��$ Cancel���� -    ��Name$ lbTitle��$��32��$
��Left=�$��6,6,0,0q�$��16(�$
��auto��$
��Bold"�$	��Top=���  $! Client.Properties.Resources��$ 
DomesticBL���� $
��Left=�$��6,38,0,0q�$��28��$	��Top=���  $! Client.Properties.Resources��$
 BLNo���� -   $��label1��$
��Left=�
���<��$��28��$	��Top=�$��
278,38,0,0q���  $! Client.Properties.Resources��$ Quota���� -    ��Name$ 
tbCustomer��$
��Left=�{�.  $��
394,40,0,0q�$	��Top=����� *	QuotaNo+�� $
��Left=�$��6,70,0,0q�$��28��$	��Top=���  $! Client.Properties.Resources��$ DocumentStatus���� -   $ tbStatus��$��
122,72,0,0q�$
��Left=�{�.  $	��Top=����� *ApproveStatus+�� -   $ label2��$��
277,71,0,0q�$
��Left=�$��28��$	��Top=���  $! Client.Properties.Resources��$
 Type���� -   $ tbDeliveryType��$��
394,72,0,0q�$
��Left=�{�.  $	��Top=���  $! Client.Properties.Resources��$ 
DomesticBL���� -   $ label3��$��	6,102,0,0q�$
��Left=�
���<��$��28��$	��Top=���  $! Client.Properties.Resources��$ IssuingDate���� -   $ label5��$��	6,134,0,0q�$
��Left=�$	��Top=�$��2����  *Warehouseman+�� -   $ tbWarehouseCompany��$
��Left=�$	��Top=�{�.  $��122,136,0,7q����� *WarehouseProviderName+�� -   $ label6��$��278,134,0,0q�$
��Left=�
���<��$	��Top=�$��2����  $! Client.Properties.Resources��$ 	Warehouse���� -   $ tbWarehouse��$��23��$
��Left=�$	��Top=�{�.  $��394,136,0,7q����� *WarehouseName+�� -   $ label7��$��278,102,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ FinancialStatus��&   System.Windows.Controls.DataGrid  -   $��dataGridDeliveryLines��   CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$
��auto��$��
122,34,0,7q�$��1������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $! Client.Properties.Resources��$ CardNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *PBNo+     $! Client.Properties.Resources��$ 	Commodity�� �� *CommodityType.Commodity.Name+     $! Client.Properties.Resources��$ CommodityType�� �� *CommodityType.Name+     $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+     $! Client.Properties.Resources��$ Specification�� �� *Specification.Name+     $! Client.Properties.Resources��$ Quantity�� �� *	NetWeight+$   DBEntity.EnumEntity.RoundRules    STR_QUANTITY! �� StringFormat#! Z       $! Client.Properties.Resources��$ ActualQuantity�� �� *VerifiedWeight+#! Z       $! Client.Properties.Resources��$ Bundle�� �� *PackingQuantity+#! Z       $! Client.Properties.Resources��$ QuantityConfirm�� �� *DlvLineIsVerified+" �� 	Converter#" [    $ 	暂定价�� �� *TempUnitPrice+#   	STR_PRICE#! Z#      $! Client.Properties.Resources��$ Comments�� �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  $ 	  CanUserSort$ .  %   CellTemplate#% [    $! Client.Properties.Resources��$ 	Operation���� $��6,0,0,0q�$
��Left=�$	��Top=�$��2����  $! Client.Properties.Resources��$ 
Attachment���� $
��Left=�$	��Top=�$��6,0,0,0q�$��3����  $! Client.Properties.Resources��$ Comments��  -   $��dataGridAttachment�� .   .  $
��auto��$
��Left=� . $	��Top=�$
��auto��$��
122,34,0,7q�$��2������     �� *Name+   $! Client.Properties.Resources��$ AttachmentName��  $ .  #% [    $! Client.Properties.Resources��$ 	Operation���� -   $��label8��$
��Left=�$��6,0,0,0q�$	��Top=�$��1����  $! Client.Properties.Resources��$ Detail��