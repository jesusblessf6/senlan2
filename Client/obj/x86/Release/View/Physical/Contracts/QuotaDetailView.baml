   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 4    .Client.View.Physical.Contracts.QuotaDetailView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     -   'Client.Base.BaseClient.ObjectBaseWindow    Loaded$  ObjectBaseWindowLoaded��   Closed$ ObjectBaseWindowClosed�� � Title$  ��$	��660��$	��800�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Manual=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources -   'Client.Converters.FundFlowTypeConverter   FundFlowTypeConverter*   $Client.Converters.TradeTypeConverter  TradeTypeConverter-   'Client.Converters.DeliveryTypeConverter  DeliveryTypeConverter+   %Client.Converters.IsVerifiedConverter  IsVerifiedConverter,   &Client.Converters.PricingTypeConverter  PricingTypeConverter-   'Client.Converters.PricingBasisConverter  PricingBasisConverter.	   (Client.Converters.ApproveStatusConverter  ApproveStatusConverter,
   &Client.Converters.InvoiceTypeConverter  InvoiceTypeConverter'   !Client.Converters.LCPorSConverter  LCPorSConverter)   #Client.Converters.LCStatusConverter 	 LCStatusConverter*   $Client.Converters.VATStatusConverter 
 ConvertStatus/   )Client.Converters.VATInvoiceTypeConverter  ConvertVATInvoiceTypes  PricingView��%�   &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 2     &	 7     &	 <                 	  
          ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���� $
��Auto=�$
��Auto=�.��� -   	 �Name$	 rootGrid��
 � RowDefinitions
 �� $
��auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $	��62* �.+�&   System.Windows.Controls.DataGrid  -   $��dataGridQuotas��   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��6,36,6,0q�   AlternatingRowBackground
 �����$	��Top=�$
��Left=�$
��Auto��  DataGridStyle#��[   DataGridRowStyle   RowStyle# [ $
��Auto������    Columns 0  *System.Windows.Controls.DataGridTextColumn    DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [    Header 0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	QuotaNo+  # [    $0 *Client.View.Physical.Contracts.ResContract��$ OriginContractNo�� �� *Contract.ExContractNo+  # [    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    $! Client.Properties.Resources��$ BP�� �� *$"Contract.BusinessPartner.ShortName+  # [ $
 Auto  .    $! Client.Properties.Resources��$ SignSide�� �� *%#Contract.InternalCustomer.ShortName+  # [    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  # [    $! Client.Properties.Resources��$ Brand�� �� *TotalBrands+  # [    $! Client.Properties.Resources��$ 	Warehouse�� �� *Warehouse.Name+  # [    $! Client.Properties.Resources��$	 UDF�� �� *Contract.ContractUDF.Name+  # [    $! Client.Properties.Resources��$ ImplementedDate�� �� *ImplementedDate+ �� StringFormat$ 
yyyy-MM-dd��  # [    $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 4  .System.Windows.Controls.DataGridTemplateColumn  # [    $! Client.Properties.Resources��$ Price��   ClipboardContentBinding �� *
StrPrice+   CellTemplate ��  �� DataType$ DBEntity:Quota��.R��� ��  �� Command# [  �� CommandParameter �� *Id+.�.��� ��� *
StrPrice+  # [    $! Client.Properties.Resources��$ PricingCurrency�� �� *Currency.Name+  # [    $! Client.Properties.Resources��$ PricingType�� �� *PricingType+ �� 	Converter# [   # [    $! Client.Properties.Resources��$ PricingReference�� �� *PricingBasis+# [   # [    $! Client.Properties.Resources��$ PricingStartDate�� �� *PricingStartDate+$ 
yyyy-MM-dd��  # [    $! Client.Properties.Resources��$ PricingEndDate�� �� *PricingEndDate+$ 
yyyy-MM-dd��   . # [    $! Client.Properties.Resources��$ ApprovalStatus�� �� *ApproveStatus+# [    . # [    $! Client.Properties.Resources��$ Approval�� �� *Approval.Name+   .  # [    $! Client.Properties.Resources��$ ApprovalDetail�� �� $ DBEntity:Quota��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+   . $
 Auto # [    $! Client.Properties.Resources��$ RejectReason�� �� *RejectReason+  �� 
GroupStyle  (  "System.Windows.Controls.GroupStyle    GroupHerderStyle!   ContainerStyle#! [ "   Panel" �� .R�>  8System.Windows.Controls.Primitives.DataGridRowsPresenter  �� -   $��label1��$��32��$��16(�$
��Bold"�$
��Left=�$��6,9,0,0q�$	��Top=�$��1������ *DeliveryTypeValue+  -   #  Name$# deliveryGrid��$��6,40,0,0q� .   .  $   RowDetailsVisibilityMode$$ Visible=� . 
 �����$	��Top=�$
��Left=�#��[ # [ $
��Auto��$
��Auto��$��1������    # [    $! Client.Properties.Resources��$ QuotaNo�� �� *Quota.QuotaNo+  # [    $! Client.Properties.Resources��$ BP�� �� **(Quota.Contract.BusinessPartner.ShortName+  # [    $! Client.Properties.Resources��$
 BLNo�� �� *
DeliveryNo+  # [    $! Client.Properties.Resources��$ BLType�� �� *DeliveryType+# [   # [    $! Client.Properties.Resources��$
 Date�� �� *	IssueDate+$ 
yyyy-MM-dd��  # [    $! Client.Properties.Resources��$ 	Commodity�� �� *Quota.Commodity.Name+  # [    $1 +Client.View.Physical.Deliveries.ResDelivery��$ 
CargoOwner�� �� *+)Quota.Contract.InternalCustomer.ShortName+  # [    $! Client.Properties.Resources��$ 	Warehouse�� �� *Warehouse.Name+  # [    $! Client.Properties.Resources��$ 	TradeType�� �� *Quota.Contract.TradeType+# [   # [    $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+# [   # [    $! Client.Properties.Resources��$ WarehouseOutNo�� �� *WarehouseOutNo+%   RowDetailsTemplate% �� $ DBEntity:Delivery��.R�  $��dataGridDetail�� .   .   . $��6,2,0,15q����� *DeliveryLines+   # [    $! Client.Properties.Resources��$ CommodityType�� �� *CommodityType.Name+  # [    $! Client.Properties.Resources��$ Specification�� �� *Specification.Name+  # [    $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+  # [    $! Client.Properties.Resources��$ CardNo�� �� *PBNo+  # [    $! Client.Properties.Resources��$ 	NetWeight�� �� *	NetWeight+# Z   # [    $! Client.Properties.Resources��$ GrossWeight�� �� *GrossWeight+# Z   # [    $1 +Client.View.Physical.Deliveries.ResDelivery��$ ActualWeight�� �� *VerifiedWeight+# Z   # [    $! Client.Properties.Resources��$ Bundle�� �� *PackingQuantity+# Z   # [    $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+# [ �� -   $��label2��$��32��$��16(�$
��Bold"�$
��Left=�$��6,9,0,0q�$	��Top=�$��3������ *WarehouseTypeValue+  -   $# warehouseOutGrid��$��6,40,0,0q� .   .  $$ Visible=� . 
 �����$	��Top=�$
��Left=�#��[ # [ $
��Auto��$
��Auto��$��3������    # [    $! Client.Properties.Resources��$ Buyer�� �� **(Quota.Contract.BusinessPartner.ShortName+  # [    $! Client.Properties.Resources��$ InternalCustomer�� �� *+)Quota.Contract.InternalCustomer.ShortName+  # [    $! Client.Properties.Resources��$ WarehouseOutNo�� �� *WarehouseOutNo+  # [    $8 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ WarehouseOutDate�� �� *WarehouseOutDate+$ 
yyyy/MM/dd��  # [    $! Client.Properties.Resources��$ 	Warehouse�� �� *Warehouse.Name+  # [    $! Client.Properties.Resources��$ 	Commodity�� �� *Quota.Commodity.Name+  # [    $! Client.Properties.Resources��$ Comments�� �� *	Comment+% �� $ DBEntity:WarehouseOut��.R�  $��dataGridDetail�� .   .   . $��6,2,0,15q����� *WarehouseOutLines+   # [ $ 卡号�� �� *WarehouseInLine.PBNo+  # [    $! Client.Properties.Resources��$ CommodityType�� �� *CommodityType.Name+  # [    $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+  # [    $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+# Z   # [    $! Client.Properties.Resources��$ ActualQuantity�� �� *VerifiedQuantity+# Z   # [    $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+# [   # [    $! Client.Properties.Resources��$ Comments�� �� *	Comment+  -   $# warehouseInGrid��$��6,40,0,0q� .   .  $$ Visible=� . 
 �����$	��Top=�$
��Left=�#��[ # [ $
��Auto��$
��Auto��$��3������    # [    $6 0Client.View.Physical.WarehouseIns.ResWarehouseIn��$ WarehouseInDate�� �� *WarehouseInDate+$ 
yyyy/MM/dd��  # [    $! Client.Properties.Resources��$ 	Warehouse�� �� *Warehouse.Name+  # [    $! Client.Properties.Resources��$ Comments�� �� *	Comment+% �� $ DBEntity:WarehouseIn��.R�  $��dataGridDetail�� .   .   . $��6,2,0,15q����� *WarehouseInLines+   # [    $! Client.Properties.Resources��$ Supplier�� �� *@>DeliveryLine.Delivery.Quota.Contract.BusinessPartner.ShortName+  # [    $! Client.Properties.Resources��$ InternalCustomer�� �� *A?DeliveryLine.Delivery.Quota.Contract.InternalCustomer.ShortName+  # [ $ 卡号�� �� *PBNo+  # [    $! Client.Properties.Resources��$ 	Commodity�� �� *,*DeliveryLine.Delivery.Quota.Commodity.Name+  # [    $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+  # [    $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+  # [    $! Client.Properties.Resources��$ ActualQuantity�� �� *VerifiedQuantity+  # [    $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+# [   # [    $! Client.Properties.Resources��$ Comments�� �� *	Comment+�� -	   $��label3��$��批次��$��32��$��16(�$
��Bold"�$
��Left=�$��6,6,0,0q�$	��Top=��� -
   $��label4��$��商业发票��$��32��$��16(�$
��Bold"�$
��Left=�$��6,9,0,0q�$	��Top=�$��5��  -   $# 	dataGrid1��$��6,40,0,0q� .   .   . 
 �����$	��Top=�$
��Left=�#��[ # [ $
��auto��$
��Auto��$��5������    # [    $! Client.Properties.Resources��$ CommInvoiceNo�� �� *	InvoiceNo+  # [    $! Client.Properties.Resources��$ QuotaNo�� �� *Quota.QuotaNo+  # [    $! Client.Properties.Resources��$ Supplier�� �� **(Quota.Contract.BusinessPartner.ShortName+  # [    $! Client.Properties.Resources��$ InternalCustomer�� �� *+)Quota.Contract.InternalCustomer.ShortName+  # [    $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ InvoiceType�� �� *InvoiceType+# [   # [ $ 开票日期�� �� *InvoicedDate+$ 
yyyy/MM/dd��  # [    $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ RelatedInvoiceNo�� �� *FinalInvoice.InvoiceNo+  # [    $! Client.Properties.Resources��$ 	Commodity�� �� *Quota.Commodity.Name+  # [ $ 结算金额�� �� *Amount+&   
STR_AMOUNT# Z&   # [    $! Client.Properties.Resources��$ SettleCurrency�� �� *Currency.Name+  # [    $! Client.Properties.Resources��$ GrossWeight�� �� *GrossWeights+# Z   # [    $! Client.Properties.Resources��$ 	NetWeight�� �� *
NetWeights+# Z   # [    $! Client.Properties.Resources��$ Comments�� �� *	Comment+�� -   $��label5��$��	信用证��$��32��$��16(�$
��Bold"�$
��Left=�$��6,9,0,0q�$	��Top=�$��6��  -   $# listGrid��$��6,40,0,0q� .   .   . 
 �����$	��Top=�$
��Left=�$
��Auto��#��[ # [ $
��Auto��$��6������    # [    $! Client.Properties.Resources��$ LoCNo�� �� *LCNo+  # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	IssueBank�� �� *
Bank1.Name+  # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
InformBank�� �� *	Bank.Name+  # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ ApplyBP�� �� *BusinessPartner.ShortName+  # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	BenefitBP�� �� *BusinessPartner1.ShortName+  # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	LoCStatus�� �� *
LCStatus+# [	   # [    $! Client.Properties.Resources��$ 	LoCAmount�� �� *IssueAmount+# Z&   # [    $! Client.Properties.Resources��$ Currency�� �� *Currency.Name+  # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
IssuingQty�� �� *IssueQuantity+# Z   # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ AcceptanceDueDate�� �� *AcceptanceExpiryDate+$ 
yyyy-MM-dd��  # [    $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ LoCType�� �� *Id+# [ �� -   $��label6��$��现金收付��$��32��$��16(�$
��Bold"�$
��Left=�$��6,9,0,0q�$	��Top=�$��7��  -   $# foundFlowListGrid��$��6,40,0,0q� .   .   . 
 �����$	��Top=�$
��Left=�$
��Auto��#��[ # [ $
��Auto��$��7������ *	Binding+   # [    $! Client.Properties.Resources��$ BP�� �� *BusinessPartner.ShortName+  # [    $! Client.Properties.Resources��$ InternalCustomer�� �� *BusinessPartner1.ShortName+  # [    $! Client.Properties.Resources��$ Quota�� �� *Quota.QuotaNo+  # [    $! Client.Properties.Resources��$ Amount�� �� *Amount+# Z&   # [    $! Client.Properties.Resources��$ Currency�� �� *Currency.Name+  # [    $/ )Client.View.Finance.FundFlows.ResFundFlow��$ FundFlowType�� �� *RorP+# [    # [    $! Client.Properties.Resources��$
 Date�� �� *	TradeDate+$ 
yyyy-MM-dd��  # [    $! Client.Properties.Resources��$ FinancialAccount�� �� *FinancialAccount.Name+�� -   $��label7��$��增值税发票��$��32��$��16(�$
��Bold"�$
��Left=�$��6,9,0,0q�$	��Top=�$��8��  -   $# vatListGrid��$��6,40,0,0q� .   .   . 
 �����$	��Top=�$
��Left=�#��[ # [ $
��auto��$
��auto��$��8������    $
 Auto # [    $! Client.Properties.Resources��$ QuotaNo�� �� *Quota.QuotaNo+  $
 auto # [    $! Client.Properties.Resources��$ Supplier�� �� *&$VATInvoice.BusinessPartner.ShortName+  $
 auto # [    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 	InvoiceBP�� �� *'%VATInvoice.BusinessPartner1.ShortName+  $
 auto # [    $! Client.Properties.Resources��$ InvoiceDate�� �� *VATInvoice.InvoicedDate+$ 
yyyy-MM-dd��  $
 auto # [ $ 未开数量�� �� *UnOpenedQuantity+# Z   $
 auto # [    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 
InvoiceQty�� �� *VATInvoiceQuantity+# Z   $
 auto '   
Visibility$' Hidden=�   $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicedQty�� �� *OpenQuantity+# Z   $
 auto # [    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoiceAmount�� �� *	VATAmount+# Z&   $
 auto # [    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicePrice�� �� *
VATPrice+(   	STR_PRICE# Z(   $
 auto # [    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ OpenInvoiceStatus�� �� *Quota.VATStatus+# [
   $
 auto # [ $ 
开/收票�� �� *VATInvoice.VATInvoiceType+# [ �� -   $��label8��$��净重��$��28��$��60��$��Right=�$
��Left=�$��
130,13,0,0q�$	��Top=�$��1���� -   $��label9��$��28��$
��Left=�
����  �$��
191,13,0,0q�$	��Top=�$��1������ *TotalNetWeight+�� -   $��label10��$��毛重��$��28��$��60��$��Right=�$
��Left=�$��
260,13,0,0q�$	��Top=�$��1���� -   $��label11��
����  �$��28��$
��Left=�$��
321,13,0,0q�$	��Top=�$��1������ *TotalGrossWeight+�� -   $��label12��$��实际数量��$��28��$
��Left=�$��
410,13,0,0q�$	��Top=�$��1���� -   $��label13��
����  �$��28��$
��Left=�$��
471,13,0,0q�$	��Top=�$��1������ *TotalVerQty+�� -   $��label14��$��数量��$��28��$��60��$��Right=�$
��Left=�$��
130,13,0,0q�$	��Top=�$��3���� -   $��label15��
����  �$��28��$
��Left=�$��
191,13,0,0q�$	��Top=�$��3������ *TotalWarehouseQty+�� -   $��label16��$��开票数量��$��28��$��60��$��Right=�$
��Left=�$��
130,13,0,0q�$	��Top=�$��8���� -   $��label17��
����  �$��28��$
��Left=�$��
191,13,0,0q�$	��Top=�$��8������ *TotalOpenQty+