   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity C   =Client.View.Physical.CommercialInvoices.CommercialInvoiceList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.Physical.CommercialInvoices.ResCommercialInvoice�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *CommercialInvoiceList+ � 	Resources ,  &Client.Converters.InvoiceTypeConverter   InvoiceTypeConverter4  .Client.Converters.InvoicePrintVisibleConverter   InvoicePrintVisibleConverter0 *Client.Converters.NullEmptyInt2BoolReverse  	Null2Bool  InvoiceEdit  InvoiceDelete  InvoicePrint  PrintDocument  AttachmentView  InvoiceActions �� DataType �� Orientation   ResxName
   Key �� 	Converter��%�  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     7  7  7  7  7  7  7  7  7        �� �� �� �� �� �� $  DBEntity:CommercialInvoice��.R��� $ 
Horizontal=�.+��� $��btInvoiceEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+{��� *BaseCommercialInvoiceId+8  �� $��btInvoiceDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+{��� *BaseCommercialInvoiceId+8  �� $��btAttachmentView��$��Right=�8�� ��  $! Client.Properties.Resources��$ 
Attachment������ *Id+�� $��btInvoicePrint��8�� ��  $! Client.Properties.Resources��$ Print��y��� *Quota.Contract.ContractType+8  ���� *Id+�� $��btDocumentPrint��$��打印单据��8�� y��� *Quota.Contract.ContractType+8  ���� *Id+	 J� CommandBindings	 )  #System.Windows.Input.CommandBinding  -   
   Command#
 [   -   #
 [   -   #
 [   -   #
 [   -   #
 [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(�&   System.Windows.Controls.DataGrid  -     Name$ 	dataGrid1��$��6,72,0,0q�   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $
��auto��$	��Top=�$
��Left=�$
��auto������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $! Client.Properties.Resources��$ CommInvoiceNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *	InvoiceNo+     $! Client.Properties.Resources��$ QuotaNo�� �� *Quota.QuotaNo+     $! Client.Properties.Resources��$ Supplier�� �� **(Quota.Contract.BusinessPartner.ShortName+     $! Client.Properties.Resources��$ InternalCustomer�� �� *+)Quota.Contract.InternalCustomer.ShortName+     $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ InvoiceType�� �� *InvoiceType+# [    $ 开票日期�� �� *InvoicedDate+ �� StringFormat$ 
yyyy/MM/dd��     $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ RelatedInvoiceNo�� �� *FinalInvoice.InvoiceNo+     $! Client.Properties.Resources��$ 	Commodity�� �� *Quota.Commodity.Name+  $ 结算金额�� �� *Amount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT# Z      $! Client.Properties.Resources��$ SettleCurrency�� �� *Currency.Name+     $! Client.Properties.Resources��$ GrossWeight�� �� *GrossWeights+   STR_QUANTITY# Z      $! Client.Properties.Resources��$ 	NetWeight�� �� *
NetWeights+# Z      $! Client.Properties.Resources��$ Comments�� �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn   	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  	  CanUserSort .     CellTemplate# [    $! Client.Properties.Resources��$ 	Operation��$   Utility.Controls.PagingControl  -	   $��pagingControl1��$
��Left=�$��6,40,0,0q�$	��Top=�