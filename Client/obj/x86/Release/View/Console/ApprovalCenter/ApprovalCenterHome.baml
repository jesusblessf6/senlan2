   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity ;    5Client.View.Console.ApprovalCenter.ApprovalCenterHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.Console.ApprovalCenter.ResApprovalCenter�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ApprovalCenter+ � 	Resources ,   &Client.Converters.PricingTypeConverter   PTC  QuotaApprove  QuotaReject  PaymentRequestApprove  PaymentRequestReject   VATInvoiceRequestLineApprove  VATInvoiceRequestLineReject  PaymentRequestActions �� DataType �� Orientation   VATInvoiceRequestLineActions��%�  &	        &	      &	 
     &	      &	      &	      &	      &	 #     7  7  &	 �     7  7    �� �� �� �� �� �� �� $ DBEntity:PaymentRequest��.R��� $ 
Horizontal=�.+��� $��同意��8��  ���� *Id+�� $��拒绝��8�� ���� *Id+�� $$ DBEntity:VATInvoiceRequestLine��.R��� $ 
Horizontal=�.+��� $��同意��8��  ���� *Id+�� $��拒绝��8�� ���� *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *ApprovalCenter+�� $
��Auto��$	��Top=�$
��Left=�$
��Auto��$��6,40,0,0q�.@��� ��  *QuotaApproval+.��� -	   $��	quotaGrid�� � RowDefinitions �� $
��Auto ��� $��* �.+��� -
   $��label1��$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  *PurchaseList+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��	   AutoGenerateColumns	 .  $
��Auto��$
��Left=�$��6,40,0,0q�$	��Top=�$
��Auto��
   
IsReadOnly
 .  	 DataGridStyle#��[	  
 DataGridRowStyle   RowStyle# [
 ���� *PurchaseQuotas+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    Header      ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *	QuotaNo+  $
 Auto  .    $! Client.Properties.Resources��$ Supplier�� �� *$"Contract.BusinessPartner.ShortName+  $
 Auto  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY �� StringFormat# Z   $
 Auto  .    $! Client.Properties.Resources��$ Price�� �� *
StrPrice+  $
 Auto  .    $! Client.Properties.Resources��$ Currency�� �� *Currency.Name+  $
 Auto  .  �� *PricingType+ �� 	Converter# [   �� ��  $! Client.Properties.Resources��$ PricingTypeShort�� � ToolTip   $! Client.Properties.Resources��$ PricingType��  $
 Auto  .  �� *%#Contract.InternalCustomer.ShortName+ ��    $! Client.Properties.Resources��$ InternalCustomer����  $! Client.Properties.Resources��$ InternalCustomerShort��  $ 	申请人��$
 Auto  .  �� *	User.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Contract.Description+  $
 Auto  .    
Visibility$ Hidden=� �� *Approval.Name+ �� ��  $! Client.Properties.Resources��$ ApprovalShort��   $! Client.Properties.Resources��$ Approval��4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto  .   �� ��  $! Client.Properties.Resources��$ ApprovalDetailShort��   $! Client.Properties.Resources��$ ApprovalDetail��   CellTemplate �� $ DBEntity:Quota��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+  $ 流转��$
 Auto  .  �� *RelQuotaStr+   .  $
 Auto    $! Client.Properties.Resources��$ 	Operation�� �� $ DBEntity:Quota��.R��� $ 
Horizontal=�.+��� $��同意��#��[ ���� *Id+{��� *ApprovalCanEdit+�� $��拒绝��#��[ ���� *Id+{��� *ApprovalCanEdit+�� -   $��label2��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$��1����  *	SalesList+  -   $��	dataGrid2��	 .  $��1��$
��Auto��$
��Left=�$��6,40,0,0q�$	��Top=�$
��Auto��
 . #��[	 # [
 ���� *SalesQuotas+   $
 Auto  .    $! Client.Properties.Resources��$ QuotaNo�� �� *	QuotaNo+  $
 Auto  .    $! Client.Properties.Resources��$ Buyer�� �� *$"Contract.BusinessPartner.ShortName+  $
 Auto  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+# Z   $
 Auto  .    $! Client.Properties.Resources��$ Price�� �� *
StrPrice+  $
 Auto  .    $! Client.Properties.Resources��$ Currency�� �� *Currency.Name+  $
 Auto  .  �� *PricingType+# [   �� ��  $! Client.Properties.Resources��$ PricingTypeShort��   $! Client.Properties.Resources��$ PricingType��  $
 Auto  .    $! Client.Properties.Resources��$ InternalCustomerShort�� �� *%#Contract.InternalCustomer.ShortName+  $ 	申请人��$
 Auto  .  �� *	User.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Contract.Description+  $
 Auto  .  �� *Approval.Name+ �� ��  $! Client.Properties.Resources��$ ApprovalShort��   $! Client.Properties.Resources��$ Approval��  $
 Auto  .   �� ��  $! Client.Properties.Resources��$ ApprovalDetailShort��   $! Client.Properties.Resources��$ ApprovalDetail�� �� $ DBEntity:Quota��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+  $ 流转��$
 Auto  .  �� *RelQuotaStr+   .     $! Client.Properties.Resources��$ 	Operation�� �� $ DBEntity:Quota��.R��� $ 
Horizontal=�.+��� $��同意��#��[ ���� *Id+�� $��拒绝��#��[ ���� *Id+�� ��  *PaymentApproval+.��� .+�  -   $��dgPaymentRequest��	 .  $
��Auto��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Auto��
 . #��[	 # [
 ���� *PaymentRequests+   $
 Auto  .    $! Client.Properties.Resources��$ QuotaNo�� �� *Quota.QuotaNo+  $
 Auto  .  �� *RequestDate+$ {0:yyyy-MM-dd}�� �� ��  $! Client.Properties.Resources��$ ApplyDateShort��   $! Client.Properties.Resources��$ 	ApplyDate��  $
 Auto  .  �� *RequestAmount+ 
  
STR_AMOUNT# Z  �� ��  $! Client.Properties.Resources��$ AppliedAmountShort��   $! Client.Properties.Resources��$ AppliedAmount��  $
 Auto  .  �� *Currency.Name+ �� ��  $! Client.Properties.Resources��$ PaymentCurrencyShort��   $! Client.Properties.Resources��$ PaymentCurrency��  $
 Auto  . $ Hidden=� �� *PayBusinessPartner.ShortName+ �� ��  $! Client.Properties.Resources��$ PaymentBPShort��   $! Client.Properties.Resources��$ 	PaymentBP��  $
 Auto  . $ Hidden=� �� *PayBankAccount.Bank.Name+ �� ��  $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ PaymentBankShort��   $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ PaymentBank��  $
 Auto  . $ Hidden=� �� *PayBankAccount.AccountCode+ �� ��  $! Client.Properties.Resources��$ PaymentAccountShort��   $! Client.Properties.Resources��$ PaymentAccount��  $
 Auto  .    $! Client.Properties.Resources��$ 	ReceiptBP�� �� *" ReceiveBusinessPartner.ShortName+  $
 Auto  . $ Hidden=�   $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ ReceiptBank�� �� *ReceiveBankAccount.Bank.Name+  $
 Auto  . $ Hidden=� �� * ReceiveBankAccount.AccountCode+ �� ��  $! Client.Properties.Resources��$ ReceiptAccountShort��   $! Client.Properties.Resources��$ ReceiptAccount��  $
 Auto  .  �� *PaymentUsage.Name+ �� ��  $! Client.Properties.Resources��$ PaymentUsageShort��   $! Client.Properties.Resources��$ PaymentUsage��  $
 Auto  . $ Hidden=� �� *PaymentMean.Name+ �� ��  $! Client.Properties.Resources��$ PaymentMeanShort��   $! Client.Properties.Resources��$ PaymentMean��  $ 流转��$
 Auto  .  �� *Quota.RelQuotaStr+  $ 	申请人��$
 Auto  .  �� *	User.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *	Comment+  $
 Auto  .  �� *Approval.Name+ �� ��  $! Client.Properties.Resources��$ ApprovalShort��   $! Client.Properties.Resources��$ Approval��   .   �� ��  $! Client.Properties.Resources��$ ApprovalDetailShort��   $! Client.Properties.Resources��$ ApprovalDetail�� �� $ DBEntity:PaymentRequest��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+  $
 Auto # [    $! Client.Properties.Resources��$ 	Operation���� ��  *VATInvoiceApproval+.��� .+�  -   $��dbVATInvoiceRequestLine��	 .  $
��Auto��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Auto��
 . #��[	 # [
 ���� *VATInvoiceRequestLines+   $
 Auto  .    $! Client.Properties.Resources��$ QuotaNo�� �� *Quota.QuotaNo+  $
 Auto  .    $! Client.Properties.Resources��$ Buyer�� �� *-+VATInvoiceRequest.BusinessPartner.ShortName+  $
 Auto  .    $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ 
InvoicedBP�� �� *.,VATInvoiceRequest.InternalCustomer.ShortName+  $
 Auto  .    $! Client.Properties.Resources��$ 	ApplyDate�� �� *VATInvoiceRequest.RequestDate+$ {0:yyyy-MM-dd}��  $
 Auto  .    $! Client.Properties.Resources��$ Amount�� �� *RequestAmount+# Z   $
 Auto  .    $! Client.Properties.Resources��$ ApplyQuantity�� �� *RequestQuantity+# Z   $ 	申请人��$
 Auto  .  �� *	User.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *	Comment+  $
 Auto  .  �� *Approval.Name+ �� ��  $! Client.Properties.Resources��$ ApprovalShort��   $! Client.Properties.Resources��$ Approval��   .   �� ��  $! Client.Properties.Resources��$ ApprovalDetailShort��   $! Client.Properties.Resources��$ ApprovalDetail�� �� $$ DBEntity:VATInvoiceRequestLine��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+  $
 Auto # [    $! Client.Properties.Resources��$ 	Operation��