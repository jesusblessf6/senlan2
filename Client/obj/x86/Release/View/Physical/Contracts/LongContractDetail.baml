   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 7    1Client.View.Physical.Contracts.LongContractDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *LongContract+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker,   &Client.Converters.PricingTypeConverter   PricingTypeConverter  AttachmentDownLoad  AttachmentDelete  	QuotaEdit  QuotaDelete  PricingView  AttachmentActions �� DataType �� Orientation	   ResxName

   Key  QuotaActions��%�  '��       '�� S     '�� �     '  �     &	      &	     &	     &	     &	     &	     &	     7  7  &	 4    7  7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� �� �� �� �� �� $ DBEntity:Attachment��.R��� $ 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $!	 Client.Properties.Resources��$
 Download������ *Id+�� $��btAttachmentDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+�� $ DBEntity:Quota��.R��� $ 
Horizontal=�.+��� $��btQuotaEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��btQuotaDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��183* �.+��� -   $��lbTitle��$�� ��$��6,6,0,0q�$
��Left=�$
��Auto��$	��Top=�$
��Bold"�$��32��$��16(��� $��6,38,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 
ContractNo���� $��
122,40,0,0q�$	��Top=�$
��Left=����� *
ContractNo+�� -    ��Name$ 
lbSupplier��$��
278,38,0,0q�$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 Supplier���� $��
394,40,0,0q�$	��Top=�$
��Left=� �� 
IsReadOnly . |�.  {�.  ���� *SupplierName+�� -	    ��Name$ btnSupplier��$	��...��$��
518,40,0,0q�$	��Top=�$
��Left=�$��25��$��23��{��� *
IsBPEnable+�� $��6,70,0,0q�$
��Left=�
���<��$	��Top=���  *
SignDate+  $��
122,72,0,0q�$
��Left=�$	��Top=�   SelectedDate �� *
SignDate+�� $��
278,70,0,0q�$
��Left=�
���<��$	��Top=���  $!	 Client.Properties.Resources��$
 SignSide���� -
   $��	comboBox2�� �� DisplayMemberPath$ 	ShortName��$
��Left=�$��
394,72,0,0q� �� SelectedValuePath$ Id��$	��Top=����� *InternalCustomers+ �� SelectedValue �� *SelectedInternalCustomerId+{��� *IsSignBPEnable+�� $��6,0,0,0q�$
��Left=�$	��Top=�$��2����  $!	 Client.Properties.Resources��$
 Quota���� -   $��btnAdd��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��2����  $!	 Client.Properties.Resources��$
 AddWithSymbol��&   System.Windows.Controls.DataGrid  -   $��dataGridQuotas��$��
122,34,0,7q�   AlternatingRowBackground
 �����   CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�$
��Auto��$
��Auto��$	��Top=�$��2������ *Quotas+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header   $!	 Client.Properties.Resources��$
 	Commodity��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Commodity.Name+     $!	 Client.Properties.Resources��$
 CommodityType�� �� *CommodityType.Name+     $!	 Client.Properties.Resources��$
 Brand�� �� *
Brand.Name+     $!	 Client.Properties.Resources��$
 Specification�� �� *Specification.Name+     $!	 Client.Properties.Resources��$
 Quantity�� �� *
Quantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY �� StringFormat# Z      $!	 Client.Properties.Resources��$
 PricingType�� �� *PricingType+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn     $!	 Client.Properties.Resources��$
 Price��    CellTemplate  �� $ DBEntity:Quota��.R��� �� ! �� Command#! [ " �� CommandParameter" �� *Id+.�.��� ��� *
StrPrice+     $!	 Client.Properties.Resources��$
 PricingStartDate�� �� *PricingStartDate+$ 
yyyy-MM-dd��     $!	 Client.Properties.Resources��$
 PricingEndDate�� �� *PricingEndDate+$ 
yyyy-MM-dd��  #   CanUserSort# .  #  [    $!	 Client.Properties.Resources��$
 	Operation���� $��6,0,0,0q�$
��Left=�$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 
Attachment���� -   $��button1��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��3����  $!	 Client.Properties.Resources��$
 AddWithSymbol��  -   $��dataGridAttachment�� .   .  $
��Left=� . $��
122,34,0,7q�$
��Auto��$��3��$
��auto��$	��Top=����� *Attachments+    �� *Name+   $!	 Client.Properties.Resources��$
 AttachmentName��  # .  #  [    $!	 Client.Properties.Resources��$
 	Operation���� $��6,0,0,0q�$
��Left=�$	��Top=�$��4����  $!	 Client.Properties.Resources��$
 Comments���� $��	122,2,0,0q�$ �� TextWrapping$
$ Wrap=�$
��Left=�$	��392��$	��100��$	��Top=�$��4������ *Description+�� -   $��210,130,0,0q�$��23��$
��Left=�$	��Top=�$��60��$��4����  $!	 Client.Properties.Resources��$

 Save���� -   $��336,130,0,0q�$��23��$��60��$
��Left=�$	��Top=�$��4��$y�Hidden=���  $!	 Client.Properties.Resources��$
 SaveAsDraft��{��� *IsSaveAsDraftEnable+�� -   $��btCancel��$��23��$
��Left=�$��305,130,0,0q�$	��Top=�$��60��$��4����  $!	 Client.Properties.Resources��$
 Cancel���� $
��Left=�$��	6,102,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$	
 UDF���� -   $��	comboBox1��$
 Name��$
��Left=�$��122,104,0,7q�$ Id��$	��Top=����� *Udfs+ �� *SelectedUsdId+�� $
��Left=�$��269,102,0,0q�$	��Top=�$	��119����  *OriginContractNo+�� $
��Left=�$��394,104,0,7q�$	��Top=����� *ExContractNo+�� -   $��label1��$��对手合同号��$��28��$
��Left=�$��6,0,0,0q�$	��Top=�$	��110��$��1��$��2��y��� *IsAutoNoVisible+�� -   $��textBox1��$��23��$
��Left=�$��	122,2,0,7q�$	��Top=�$	��120��$��1��y��� *IsAutoNoVisible+���� *AutoContractNo+