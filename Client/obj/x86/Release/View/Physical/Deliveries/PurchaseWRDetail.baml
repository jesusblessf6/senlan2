   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  6   0Client.View.Physical.Deliveries.PurchaseWRDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6
Convertersclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     %  Client.Base.BaseClient.BasePage    Loaded$  
PageLoaded��0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ 
DomesticWR�� � 	Resources  �� 
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
��Left=�$	��Top=�$��
122,40,0,0q����� *
DeliveryNo+�� -   $��btnOrderLine��$	��...��$��23��$��25��$
��Left=�$��
518,40,0,0q�$	��Top=�{��� *IsQuotaEnable+ � ToolTip �� *ContractInfo+  -   $��
dpSignDate��$
��Left=�$	��Top=�$��122,104,0,0q�   SelectedDate �� *	IssueDate+�� -	   $��btnWarehouse��$	��...��$��23��$��25��$
��Left=�$��518,136,0,7q�$	��Top=��� -
   $��btnWarehouseCompany��$	��...��$��23��$��25��$
��Left=�$��246,136,0,7q�$	��Top=��� -    ��Name$ cboxFinancialStatus��$
��Left=�$	��Top=� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value��$��394,104,0,0q����� *StatusTypes+ �� SelectedValue �� *FinanceStatus+�� -   $��btnAdd��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��1����  $! Client.Properties.Resources��$ AddWithSymbol���� -   $��button1��$��23��$
��Left=�$	��Top=�$��45��$��	122,2,0,0q�$��2����  $! Client.Properties.Resources��$ AddWithSymbol����  �� TextWrapping$
 Wrap=�$	��392��$	��100��$��	122,2,0,0q�$	��Top=�$
��Left=�$��3������ *	Comment+�� -   $��210,120,0,0q�$
��Left=�$	��Top=�$��60��$��25��$��3����  $! Client.Properties.Resources��$
 Save���� -   $��305,120,0,0q�$	��Top=�$
��Left=�$��60��$��25��$��3����  $! Client.Properties.Resources��$ Cancel���� -    ��Name$ lbTitle��$
��Left=�$��6,6,0,0q�$��16(�$
��auto��$
��Bold"�$��32��$	��Top=���  $! Client.Properties.Resources��$ 
DomesticWR���� $
��Left=�$��6,38,0,0q�$��28��$	��Top=���  *WRNo+�� -   $��label1��$
��Left=�
���<��$��
278,38,0,0q�$��28��$	��Top=���  $! Client.Properties.Resources��$ Quota���� -    ��Name$ 
tbCustomer��$
��Left=�$	��Top=� �� 
IsReadOnly . $��
394,40,0,0q����� *	QuotaNo+�� $
��Left=�$��6,70,0,0q�$��28��$	��Top=���  $! Client.Properties.Resources��$ DocumentStatus���� -   $ tbStatus��$��
122,72,0,0q�$
��Left=�$	��Top=�{�.  $�� ���� -   $ label2��$��28��$��
278,70,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$
 Type���� -   $ tbDeliveryType��$��
394,72,0,0q�$
��Left=�$	��Top=�{�.  ��  $! Client.Properties.Resources��$ 
DomesticWR���� -   $ label3��$��28��$��	6,102,0,0q�$
��Left=�
���<��$	��Top=���  $! Client.Properties.Resources��$ IssuingDate���� -   $ label5��$��28��$��	6,134,0,0q�$
��Left=�$	��Top=���  *Warehouseman+�� -   $ tbWarehouseCompany��$	��Top=� . $��122,136,0,7q�$
��Left=����� *WarehouseProviderName+�� -   $ label6��$��28��$��278,134,0,0q�$
��Left=�
���<��$	��Top=���  $! Client.Properties.Resources��$ 	Warehouse���� -   $ tbWarehouse��$
��Left=�$	��Top=� . $��394,136,0,7q����� *WarehouseName+�� -   $ label7��$��28��$
��Left=�$	��Top=�$��278,102,0,0q���  $! Client.Properties.Resources��$ FinancialStatus��&   System.Windows.Controls.DataGrid  -   $��dataGridDeliveryLines��   CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��auto��$
��Left=�$
��auto��$��
122,34,0,7q�$��1������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $! Client.Properties.Resources��$ CardNo��1
  +System.Windows.Controls.DataGridBoundColumn  
  Binding  �� *PBNo+     $! Client.Properties.Resources��$ 	Commodity��  �� *CommodityType.Commodity.Name+     $! Client.Properties.Resources��$ CommodityType��  �� *CommodityType.Name+     $! Client.Properties.Resources��$ Brand��  �� *
Brand.Name+     $! Client.Properties.Resources��$ Quantity��  �� *	NetWeight+$   DBEntity.EnumEntity.RoundRules!   STR_QUANTITY" �� StringFormat#" Z!      $! Client.Properties.Resources��$ ActualQuantity��  �� *VerifiedWeight+#" Z!      $! Client.Properties.Resources��$ Bundle��  �� *PackingQuantity+#" Z!      $! Client.Properties.Resources��$ QuantityConfirm��  �� *DlvLineIsVerified+# �� 	Converter## [    $ 	暂定价��  �� *TempUnitPrice+$   	STR_PRICE#" Z$      $! Client.Properties.Resources��$ Comments��  �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  % 	  CanUserSort% .  &   CellTemplate#& [    $! Client.Properties.Resources��$ 	Operation���� $��6,0,0,0q�$
��Left=�$	��Top=�$��2����  $! Client.Properties.Resources��$ 
Attachment���� $��6,0,0,0q�$
��Left=�$	��Top=�$��3����  $! Client.Properties.Resources��$ Comments��  -   $��dataGridAttachment�� .   .  $
��auto��$
��Left=� . $
��auto��$��
122,34,0,7q�$��2������      �� *Name+   $! Client.Properties.Resources��$ AttachmentName��  % .  #& [    $! Client.Properties.Resources��$ 	Operation���� -   $��label4��$
��Left=�$��6,0,0,0q�$	��Top=�$��1����  $! Client.Properties.Resources��$ Detail��