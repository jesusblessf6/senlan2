   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  4   .Client.View.Physical.Deliveries.ImportWRDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     %  Client.Base.BaseClient.BasePage    Loaded$  ImportWRLoaded��0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$1 +Client.View.Physical.Deliveries.ResDelivery�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *
ImportWR+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   AttachmentDownLoad  AttachmentDelete  AttachmentActions �� DataType	 �� Orientation
   ResxName
   Key  DeliveryEdit  DeliveryDelete  DeliveryActions��%�  '��       '�� S     '�� �     '  �     &	      &	     &	     7   7  &	      &	 %    &	 *    7  7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� $ DBEntity:Attachment��.R��� $	 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $!
 Client.Properties.Resources��$ Download������ *Id+�� $��btAttachmentDelete��8�� ��  $!
 Client.Properties.Resources��$ Delete������ *Id+�� �� �� $ DBEntity:Delivery��.R��� $	 
Horizontal=�.+��� $��btDeliveryEdit��8��  ��  $!
 Client.Properties.Resources��$
 Edit������ *Id+�� $��btDeliveryDelete��8�� ��  $!
 Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [    -   # [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��tbDeliveryNo��$
��Left=�$	��Top=�$��
394,71,0,0q� �� 
IsReadOnly . {�.  ���� *
DeliveryNo+�� -   $��btnOrderLine��$	��...��$��23��$��25��$
��Left=�$��
246,70,0,0q�$	��Top=�{��� *IsQuotaEnable+ � ToolTip �� *ContractInfo+  -   $��
dpSignDate��$
��Left=�$	��Top=�$��122,134,0,0q�   SelectedDate �� *	IssueDate+�� -	   $��btnWarehouse��$	��...��$��23��$��25��$
��Left=�$��518,166,0,0q�$	��Top=�$y�	Collapsed=�	� -
   $��radioButton1��$��20��$
��Left=�$��
189,41,0,0q� 	� 	GroupName$ rbIsCopy��$	��Top=���  *Copy+ d� 	IsChecked �� *IsCopyFirst+	� -   $��radioButton2��$��20��$
��Left=�$��
394,41,0,0q�$ rbIsCopy��$	��Top=���  *
Original+ �� *IsCopySecond+�� -   $��btnWarehouseCompany��$	��...��$��23��$��25��$
��Left=�$��246,166,0,0q�$	��Top=�$y�	Collapsed=��� -   $��tbPack��$
��Left=�$	��Top=�$��122,198,0,0q�{�.  ���� *PackingStandard+�� -    ��Name$ cboxDeclarationStatus��$
��Left=�$��394,198,0,0q�$	��Top=� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value�� �� 
IsReadOnly . {�.  ���� *IsCustomeds+ �� SelectedValue �� *
IsCustomed+�� -   $ cboxFinancialStatus��$
��Left=�$��394,134,0,0q�$	��Top=�$	 Key��$ Value�� . {�.  ���� *StatusTypes+ �� *FinanceStatus+�� -   $��btnAdd��$��23��$
��Left=�$��Bottom=�$��45��$��	122,0,0,0q�$y�	Collapsed=�$��1����  $!
 Client.Properties.Resources��$ AddWithSymbol���� -   $��button1��$��23��$
��Left=�$��122,11,0,29q�$��45��$y�	Collapsed=�$��2����  $!
 Client.Properties.Resources��$ AddWithSymbol����  �� TextWrapping$
 Wrap=�$��	122,2,0,0q�$	��100��$	��Top=�$
��Left=�$	��392��$��3������ *	Comment+�� -   $��210,130,0,0q�$
��Left=�$	��Top=�$��60��$��25��$��3����  $!
 Client.Properties.Resources��$
 Save���� -   $��305,130,0,0q�$��60��$��25��$
��Left=�$	��Top=�$��3����  $!
 Client.Properties.Resources��$ Cancel���� -    ��Name$ lbTitle��$
��Left=�$��	6,7,0,217q�$��16(�$
��auto��$
��Bold"�$��32����  *
ImportWR+�� $��
273,68,0,0q�$	��Top=�
���<��$
��Left=���  *WRNo+�� -   $��label1��$
��Left=�$��6,68,0,0q�$	��Top=�.���� 
���<����  $!
 Client.Properties.Resources��$ Quota���� -    ��Name$ 
tbCustomer��$
��Left=�$	��Top=� . $��
122,70,0,0q�{�.  ���� *	QuotaNo+�� $
��Left=�$��	6,100,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ DocumentStatus���� -   $ tbStatus��$��122,102,0,0q�$
��Left=�$	��Top=�{�.  ���� *ApproveStatus+�� -   $ label2��$��278,100,0,0q�$
��Left=�$	��Top=���  $!
 Client.Properties.Resources��$
 Type���� -   $ tbDeliveryType��$��394,102,0,0q�$
��Left=�$	��Top=�{�.  ��  *
ImportWR+�� -   $ label3��$��	6,132,0,0q�$
��Left=�
���<��$��28��$	��Top=���  $!
 Client.Properties.Resources��$ IssuingDate���� -   $ label5��$��	6,164,0,0q�$
��Left=�$��28��$	��Top=���  *Warehouseman+�� -   $ tbWarehouseCompany��$
��Left=�$	��Top=�{�.  $��122,166,0,0q����� *WarehouseProviderName+�� -   $ label6��$��278,163,0,0q�$
��Left=�$	��Top=�.���� 
���<����  $!
 Client.Properties.Resources��$ 	Warehouse���� -   $ tbWarehouse��$
��Left=�$	��Top=�{�.  $��394,166,0,0q����� *WarehouseName+�� -   $ label17��$��278,196,0,0q�$
��Left=�$	��Top=���  *CustomStatus+�� -    $ label7��$��278,132,0,0q�$
��Left=�$��28��$	��Top=���  $!
 Client.Properties.Resources��$ FinancialStatus���� -!   $ label16��$��	6,196,0,0q�$
��Left=�$��28��$	��Top=���  *PackingSpec+&   System.Windows.Controls.DataGrid  -"   $��dataGridDeliveryLines��   CanUserSortColumns .     CanUserAddRows .     
IsReadOnly .     AutoGenerateColumns  .  $
��auto��$
��Left=�$
��auto��$��Bottom=�$��	122,2,0,7q�$��1������ !   Columns! 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn"   Header"   $!
 Client.Properties.Resources��$ CommodityType��1	  +System.Windows.Controls.DataGridBoundColumn# 	  Binding# �� *CommodityType.Name+  "   $!
 Client.Properties.Resources��$ Brand��# �� *
Brand.Name+  "   $!
 Client.Properties.Resources��$ OriginCountry��# �� *Country.ChineseName+  "   $!
 Client.Properties.Resources��$ CardNo��# �� *PBNo+  "   $!
 Client.Properties.Resources��$ 	NetWeight��# �� *	NetWeight+$
   DBEntity.EnumEntity.RoundRules$ 
  STR_QUANTITY% �� StringFormat#% Z$   "   $!
 Client.Properties.Resources��$ GrossWeight��# �� *GrossWeight+#% Z$   "   $!
 Client.Properties.Resources��$ Bundle��# �� *PackingQuantity+#% Z$   "   $!
 Client.Properties.Resources��$ Comments��# �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  &   CanUserSort& .  '   CellTemplate#' [ (   
Visibility$( 	Collapsed=�"   $!
 Client.Properties.Resources��$ 	Operation���� $��6,0,0,0q�$
��Left=�$	��Top=�$��2��$��28����  $!
 Client.Properties.Resources��$ 
Attachment���� $��6,0,0,0q�$	��Top=�$
��Left=�$��3����  $!
 Client.Properties.Resources��$ Comments��  -#   $��dataGridAttachment��  .   .  $
��Left=� . $
��auto��$
��auto��$��	122,2,0,7q�$��2������ !   # �� *Name+"   $!
 Client.Properties.Resources��$ AttachmentName��  & .  #' [ $( 	Collapsed=�"   $!
 Client.Properties.Resources��$ 	Operation���� -$   $��label8��$
��Left=�$	��Top=�$��6,0,0,0q�$��1����  $!
 Client.Properties.Resources��$ Detail���� -%   $��txtCirculNo��$
��Left=�$��122,230,0,7q�$	��Top=����� *
CirculNo+�� -&   $��label4��$
��Left=�$��Right=�$��	6,228,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ FlowId���� -'   $��button2��$	��...��$��23��$
��Left=�$��
518,71,0,0q�$	��Top=�$��25��{��� *IsPoolNoBtnEnale+�� -(   $��label9��$��金属��$��28��$
��Left=�$��277,228,0,0q�$	��Top=�$	��110���� -)   $��textBox1��$��23��$
��Left=�$��394,230,0,7q�$	��Top=�$	��120�� . {�.  ���� *Commodity.Name+