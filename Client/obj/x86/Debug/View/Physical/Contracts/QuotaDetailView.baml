   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      4    .Client.View.Physical.Contracts.QuotaDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6
Convertersclr-namespace:Client.Converters     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      -   'Client.Base.BaseClient.ObjectBaseWindow    Loaded$  ObjectBaseWindowLoaded��5   5      Closed$ ObjectBaseWindowClosed��6U    � Title$  ��5
      $	��660��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�6@    � SizeToContent$ Manual=�5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5      -   'Client.Converters.FundFlowTypeConverter   FundFlowTypeConverter*   $Client.Converters.TradeTypeConverter  TradeTypeConverter-   'Client.Converters.DeliveryTypeConverter  DeliveryTypeConverter+   %Client.Converters.IsVerifiedConverter  IsVerifiedConverter,   &Client.Converters.PricingTypeConverter  PricingTypeConverter-   'Client.Converters.PricingBasisConverter  PricingBasisConverter.	   (Client.Converters.ApproveStatusConverter  ApproveStatusConverter,
   &Client.Converters.InvoiceTypeConverter  InvoiceTypeConverter'   !Client.Converters.LCPorSConverter  LCPorSConverter)   #Client.Converters.LCStatusConverter 	 LCStatusConverter*   $Client.Converters.VATStatusConverter 
 ConvertStatus/   )Client.Converters.VATInvoiceTypeConverter  ConvertVATInvoiceTypes  PricingView��%y  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �       5   
   6+     5   
   6(     5   
   6+     5   
   6)     5   
   6*     5   
   6+   	  5   
   6,   
  5   
   6*     5   
   6%     5   
   6'     5   
   6(     5   
   6-   �� 5   
   6.   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      5      .��5       �� $
��Auto=�6   $
��Auto=�68   .��5!   
   � -   5        	 �Name$	 rootGrid��5!      
 � RowDefinitions
 5"      �� 5#      $
��auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $	��62* �6    .+�5.      &   System.Windows.Controls.DataGrid  -   5        $��dataGridQuotas��5.         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��6,36,6,0q�5/   )      AlternatingRowBackground
 �����$	��Top=�6a   $
��Left=�50      $
��Auto��51        DataGridStyle#��[ 6$     DataGridRowStyle   RowStyle# [ 6K   $
��Auto��52      ��5.   -   ��    Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54        DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [ 56   )      Header 54   )   0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 55   )   �� *	QuotaNo+56   )     57      # [ 5:       58        $0 *Client.View.Physical.Contracts.ResContract��$ OriginContractNo�� 59      �� *Contract.ExContractNo+5:        5;      # [ 5=   )      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6b      CanUserSort .  5;   )     $! Client.Properties.Resources��$ BP�� 5<   )   �� *$"Contract.BusinessPartner.ShortName+5?        5@      # [ 5B   )   $
 Auto 6b    .  5@   )     $! Client.Properties.Resources��$ SignSide�� 5A   )   �� *%#Contract.InternalCustomer.ShortName+5D        5E      # [ 5G   )    5E   )     $! Client.Properties.Resources��$ 	Commodity�� 5F   )   �� *Commodity.Name+5G   )     5H      # [ 5J   )    5H   )     $! Client.Properties.Resources��$ Brand�� 5I   )   �� *TotalBrands+5J   )     5K      # [ 5M   )    5K   )     $! Client.Properties.Resources��$ 	Warehouse�� 5L   )   �� *Warehouse.Name+5M   )     5N      # [ 5P   )    5N   )     $! Client.Properties.Resources��$	 UDF�� 5O   )   �� *Contract.ContractUDF.Name+5P   )     5Q      # [ 5S   )    5Q   )     $! Client.Properties.Resources��$ ImplementedDate�� 5R   )   �� *ImplementedDate+ �� StringFormat$ 
yyyy-MM-dd��5S   )     5T      # [ 5V   )    5T   )     $! Client.Properties.Resources��$ Quantity�� 5U   )   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 5V   )   4  .System.Windows.Controls.DataGridTemplateColumn  5W      # [ 5X   -    5W   -     $! Client.Properties.Resources��$ Price��   ClipboardContentBinding 5Y   -   �� *
StrPrice+   CellTemplate 5Z      �� 5[       �� DataType$ DBEntity:Quota��6+   .R�5\   "   �� �� 5]   &    �� Command# [ 60    �� CommandParameter 6W   �� *Id+.�6w   .�5^   *   �� �6.   �� *
StrPrice+6J   5_   '   5`   #   5a      5c        5d      # [ 5f   )    5d   )     $! Client.Properties.Resources��$ PricingCurrency�� 5e   )   �� *Currency.Name+5f   )     5g      # [ 5i   )    5g   )     $! Client.Properties.Resources��$ PricingType�� 5h   )   �� *PricingType+ �� 	Converter# [ 5i   )     5j      # [ 5l   )    5j   )     $! Client.Properties.Resources��$ PricingReference�� 5k   )   �� *PricingBasis+# [ 5l   )     5m      # [ 5n   )    5m   )     $! Client.Properties.Resources��$ PricingStartDate�� 5o   )   �� *PricingStartDate+$ 
yyyy-MM-dd��5p        5q      # [ 5r   )    5q   )     $! Client.Properties.Resources��$ PricingEndDate�� 5s   )   �� *PricingEndDate+$ 
yyyy-MM-dd��5t        5u       . # [ 5x   )    5u   )     $! Client.Properties.Resources��$ ApprovalStatus�� 5w   )   �� *ApproveStatus+# [ 5y        5z       . # [ 5|   )    5z   )     $! Client.Properties.Resources��$ Approval�� 5{   <   �� *Approval.Name+5}        5~       .  # [ 5�   -    5~   -     $! Client.Properties.Resources��$ ApprovalDetail�� 5�      �� 5�      $ DBEntity:Quota��6+   .R�5�   "   �� �� 5�   &   
��� � ��6=   �� *CustomerStrField1+6b    �� 5�   &   
���  ���6;   �� *CustomerStrField2+6`   5�   #   5�      5�        5�       . $
 Auto 5�   ]   # [ 5�   )    5�   )     $! Client.Properties.Resources��$ RejectReason�� 5�   )   �� *RejectReason+5�        �� 
GroupStyle  5�      (  "System.Windows.Controls.GroupStyle  5�        GroupHerderStyle!   ContainerStyle#! [ 6!   "   Panel" 5�      �� 5�      .R�5�   "   >  8System.Windows.Controls.Primitives.DataGridRowsPresenter  5�      5�      5�      �� 5�      -   5        $��label1��5�   @   $��32��5�   :   $��16(�6F   $
��Bold"�6T   $
��Left=�5�      $��6,9,0,0q�6/   $	��Top=�6N   $��1��6f   ��5�      �� *DeliveryTypeValue+5�   f     5�      -   5        #  Name$# deliveryGrid��5�   )   $��6,40,0,0q�6    .   .  $   RowDetailsVisibilityMode$$ Visible=�5�   .    . 
 �����$	��Top=�5�   O   $
��Left=�5�      #��[ 5�      # [ 6>   $
��Auto��6k   $
��Auto��5�      $��1��6$   ��5�   ?   ��  5�        5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ QuotaNo�� 5�   )   �� *Quota.QuotaNo+  5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ BP�� 5�   )   �� **(Quota.Contract.BusinessPartner.ShortName+  5�      # [ 6)    5�   )     $! Client.Properties.Resources��$
 BLNo�� 5�   )   �� *
DeliveryNo+  5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ BLType�� 5�   )   �� *DeliveryType+# [   5�      # [ 6)    5�   )     $! Client.Properties.Resources��$
 Date�� 5�   )   �� *	IssueDate+$ 
yyyy-MM-dd��  5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ 	Commodity�� 5�   )   �� *Quota.Commodity.Name+  5�      # [ 6)    5�   )     $1 +Client.View.Physical.Deliveries.ResDelivery��$ 
CargoOwner�� 5�   )   �� *+)Quota.Contract.InternalCustomer.ShortName+  5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ 	Warehouse�� 5�   )   �� *Warehouse.Name+  5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ 	TradeType�� 5�   )   �� *Quota.Contract.TradeType+# [   5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ QuantityConfirm�� 5�   )   �� *
IsVerified+# [   5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ WarehouseOutNo�� 5�   )   �� *WarehouseOutNo+%   RowDetailsTemplate% 5�      �� 5�      $ DBEntity:Delivery��6#   .R�5�        $��dataGridDetail��6#    .   .   . $��6,2,0,15q�5�   #   ��5�   9   �� *DeliveryLines+ 5�        5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ CommodityType�� 5�   5   �� *CommodityType.Name+  5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ Specification�� 5�   5   �� *Specification.Name+  5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ Brand�� 5�   5   �� *
Brand.Name+  5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ CardNo�� 5�   5   �� *PBNo+  5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ 	NetWeight�� 5�   5   �� *	NetWeight+# Z   5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ GrossWeight�� 5�   5   �� *GrossWeight+# Z   5�   "   # [ 65    5�   5     $1 +Client.View.Physical.Deliveries.ResDelivery��$ ActualWeight�� 5�   5   �� *VerifiedWeight+# Z   5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ Bundle�� 5�   5   �� *PackingQuantity+# Z   5�   "   # [ 65    5�   5     $! Client.Properties.Resources��$ QuantityConfirm�� 5�   5   �� *
IsVerified+# [ 5�      5�      5�      �� 5�      -   5        $��label2��5�   @   $��32��5�   ;   $��16(�6G   $
��Bold"�6U   $
��Left=�5�      $��6,9,0,0q�6/   $	��Top=�6N   $��3��6f   ��5�      �� *WarehouseTypeValue+5�   f     5�      -   5        $# warehouseOutGrid��5�   )   $��6,40,0,0q�6    .   .  $$ Visible=�5�       . 
 �����$	��Top=�5�   O   $
��Left=�5�      #��[ 5�      # [ 6>   $
��Auto��5�   /   $
��Auto��6=   $��3��6J   ��6   ��  5�        5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ Buyer�� 5�   )   �� **(Quota.Contract.BusinessPartner.ShortName+5�        5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ InternalCustomer�� 5�   )   �� *+)Quota.Contract.InternalCustomer.ShortName+5�        5�      # [ 6)    5�   )     $! Client.Properties.Resources��$ WarehouseOutNo�� 5�   )   �� *WarehouseOutNo+5�        5�      # [ 6)    5   )     $8 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ WarehouseOutDate�� 5  )   �� *WarehouseOutDate+$ 
yyyy/MM/dd��5       5     # [ 6)    5  )     $! Client.Properties.Resources��$ 	Warehouse�� 5  )   �� *Warehouse.Name+5       5     # [ 6)    5  )     $! Client.Properties.Resources��$ 	Commodity�� 5	  )   �� *Quota.Commodity.Name+5
       5     # [ 6)    5  )     $! Client.Properties.Resources��$ Comments�� 5  )   �� *	Comment+5     % 5     �� 5     $ DBEntity:WarehouseOut��6#   .R�5       $��dataGridDetail��6#    .   .   . $��6,2,0,15q�5  #   ��5  9   �� *WarehouseOutLines+ 5       5  "   # [ 65   $ 卡号��5  5    6A   �� *WarehouseInLine.PBNo+5  #     5  "   # [ 65    5  5     $! Client.Properties.Resources��$ CommodityType�� 5  5   �� *CommodityType.Name+5  #     5  "   # [ 65    5  5     $! Client.Properties.Resources��$ Brand�� 5  5   �� *
Brand.Name+5   #     5!  "   # [ 65    5"  5     $! Client.Properties.Resources��$ Quantity�� 5#  5   �� *
Quantity+# Z 5$  #     5%  "   # [ 65    5&  5     $! Client.Properties.Resources��$ ActualQuantity�� 5'  5   �� *VerifiedQuantity+# Z 5(  #     5)  "   # [ 65    5*  5     $! Client.Properties.Resources��$ QuantityConfirm�� 5+  5   �� *
IsVerified+# [ 5,  #     5-  "   # [ 65    5.  5     $! Client.Properties.Resources��$ Comments�� 5/  5   �� *	Comment+50  #   52     53     55       56     -   5        $# warehouseInGrid��56  )   $��6,40,0,0q�6    .   .  $$ Visible=�57  .    . 
 �����$	��Top=�58  O   $
��Left=�59     #��[ 5:     # [ 6>   $
��Auto��6k   $
��Auto��5;     $��3��6$   ��56  B   ��  5<       5=     # [ 6)    5>  )     $6 0Client.View.Physical.WarehouseIns.ResWarehouseIn��$ WarehouseInDate�� 5?  )   �� *WarehouseInDate+$ 
yyyy/MM/dd��  5@     # [ 6)    5A  )     $! Client.Properties.Resources��$ 	Warehouse�� 5B  )   �� *Warehouse.Name+  5C     # [ 6)    5D  )     $! Client.Properties.Resources��$ Comments�� 5E  )   �� *	Comment+% 5G     �� 5H     $ DBEntity:WarehouseIn��6#   .R�5I       $��dataGridDetail��6#    .   .   . $��6,2,0,15q�5K  #   ��5I  9   �� *WarehouseInLines+ 5L       5M  "   # [ 65    5N  5     $! Client.Properties.Resources��$ Supplier�� 5O  5   �� *@>DeliveryLine.Delivery.Quota.Contract.BusinessPartner.ShortName+5P  #     5Q  "   # [ 65    5R  5     $! Client.Properties.Resources��$ InternalCustomer�� 5S  5   �� *A?DeliveryLine.Delivery.Quota.Contract.InternalCustomer.ShortName+5T  #     5U  "   # [ 65   $ 卡号��5V  5    6A   �� *PBNo+5W  #     5X  "   # [ 65    5Y  5     $! Client.Properties.Resources��$ 	Commodity�� 5Z  5   �� *,*DeliveryLine.Delivery.Quota.Commodity.Name+5[  #     5\  "   # [ 65    5]  5     $! Client.Properties.Resources��$ Brand�� 5^  5   �� *
Brand.Name+5_  #     5`  "   # [ 65    5a  5     $! Client.Properties.Resources��$ Quantity�� 5b  5   �� *
Quantity+5c  #     5d  "   # [ 65    5e  5     $! Client.Properties.Resources��$ ActualQuantity�� 5f  5   �� *VerifiedQuantity+5g  #     5h  "   # [ 65    5i  5     $! Client.Properties.Resources��$ QuantityConfirm�� 5j  5   �� *
IsVerified+# [ 5k  #     5l  "   # [ 65    5m  5     $! Client.Properties.Resources��$ Comments�� 5n  5   �� *	Comment+5o  #   5q     5r     5t     �� 5u     -	   5        $��label3��5v     $��批次��5u     $��32��6!   $��16(�6-   $
��Bold"�6;   $
��Left=�6M   $��6,6,0,0q�6h   $	��Top=�5v  "   �� 5w     -
   5        $��label4��5x  %   $��商业发票��5w     $��32��6#   $��16(�6/   $
��Bold"�6=   $
��Left=�6O   $��6,9,0,0q�5x     $	��Top=�63   $��5��6K     5y     -   5        $# 	dataGrid1��5y  A   $��6,40,0,0q�6    .   .   . 
 �����$	��Top=�5{  O   $
��Left=�5|     #��[ 5}     # [ 6>   $
��auto��6k   $
��Auto��5~     $��5��6%   ��5y  )   ��  5       5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ CommInvoiceNo�� 5�  )   �� *	InvoiceNo+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ QuotaNo�� 5�  )   �� *Quota.QuotaNo+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ Supplier�� 5�  )   �� **(Quota.Contract.BusinessPartner.ShortName+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ InternalCustomer�� 5�  )   �� *+)Quota.Contract.InternalCustomer.ShortName+  5�     # [ 6)    5�  )     $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ InvoiceType�� 5�  )   �� *InvoiceType+# [   5�     # [ 6)   $ 开票日期��6b    5�  )   �� *InvoicedDate+$ 
yyyy/MM/dd��5�       5�     # [ 6)    5�  )     $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ RelatedInvoiceNo�� 5�  )   �� *FinalInvoice.InvoiceNo+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ 	Commodity�� 5�  )   �� *Quota.Commodity.Name+  5�     # [ 6)   $ 结算金额��6b    5�  )   �� *Amount+&   
STR_AMOUNT# Z&   5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ SettleCurrency�� 5�  )   �� *Currency.Name+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ GrossWeight�� 5�  )   �� *GrossWeights+# Z   5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ 	NetWeight�� 5�  )   �� *
NetWeights+# Z   5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ Comments�� 5�  )   �� *	Comment+5�     �� 5�     -   5        $��label5��5�  %   $��	信用证��5�     $��32��6"   $��16(�6.   $
��Bold"�6<   $
��Left=�6N   $��6,9,0,0q�5�     $	��Top=�63   $��6��6K     5�     -   5        $# listGrid��5�  )   $��6,40,0,0q�6    .   .   . 
 �����$	��Top=�5�  O   $
��Left=�5�     $
��Auto��5�     #��[ 6$   # [ 6K   $
��Auto��5�     $��6��6%   ��5�  ;   ��  5�       5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ LoCNo�� 5�  )   �� *LCNo+  5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	IssueBank�� 5�  )   �� *
Bank1.Name+  5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
InformBank�� 5�  )   �� *	Bank.Name+  5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ ApplyBP�� 5�  )   �� *BusinessPartner.ShortName+  5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	BenefitBP�� 5�  )   �� *BusinessPartner1.ShortName+  5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	LoCStatus�� 5�  )   �� *
LCStatus+# [	   5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ 	LoCAmount�� 5�  )   �� *IssueAmount+# Z&   5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ Currency�� 5�  )   �� *Currency.Name+  5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
IssuingQty�� 5�  )   �� *IssueQuantity+# Z   5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ AcceptanceDueDate�� 5�  )   �� *AcceptanceExpiryDate+$ 
yyyy-MM-dd��  5�     # [ 6)    5�  )     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ LoCType�� 5�  )   �� *Id+# [ 5�     �� 5�     -   5        $��label6��5�  %   $��现金收付��5�     $��32��6#   $��16(�6/   $
��Bold"�6=   $
��Left=�6O   $��6,9,0,0q�5�     $	��Top=�63   $��7��6K     5�     -   5        $# foundFlowListGrid��5�  )   $��6,40,0,0q�6    .   .   . 
 �����$	��Top=�5�  O   $
��Left=�5�     $
��Auto��5�     #��[ 6$   # [ 6K   $
��Auto��5�     $��7��6%   ��5�  D   ��  5�       5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ BP�� 5�  )   �� *BusinessPartner.ShortName+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ InternalCustomer�� 5�  )   �� *InternalCustomer.ShortName+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ Quota�� 5�  )   �� *Quota.QuotaNo+  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ Amount�� 5�  )   �� *Amount+# Z&   5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ Currency�� 5�  )   �� *Currency.Name+  5�     # [ 6)    5�  )     $/ )Client.View.Finance.FundFlows.ResFundFlow��$ FundFlowType�� 5�  )   �� *RorP+# [    5�     # [ 6)    5�  )     $! Client.Properties.Resources��$
 Date�� 5�  )   �� *	TradeDate+$ 
yyyy-MM-dd��  5�     # [ 6)    5�  )     $! Client.Properties.Resources��$ FinancialAccount�� 5�  )   �� *FinancialAccount.Name+5�     �� 5�     -   5        $��label7��5�  %   $��增值税发票��5�     $��32��6$   $��16(�60   $
��Bold"�6>   $
��Left=�6P   $��6,9,0,0q�5�     $	��Top=�63   $��8��6K     5�     -   5        $# vatListGrid��5�  )   $��6,40,0,0q�6    .   .   . 
 �����$	��Top=�5�  O   $
��Left=�5�     #��[ 5�     # [ 6>   $
��auto��6k   $
��auto��5�     $��8��6%   ��5�  >   ��  5�       5      $
 Auto 6)   # [ 66    5  )     $! Client.Properties.Resources��$ QuotaNo�� 5  )   �� *Quota.QuotaNo+5       5     $
 auto 6)   # [ 66    5  )     $! Client.Properties.Resources��$ Supplier�� 5  )   �� *&$VATInvoice.BusinessPartner.ShortName+  5     $
 auto 6)   # [ 66    5	  )     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 	InvoiceBP�� 5
  )   �� *'%VATInvoice.BusinessPartner1.ShortName+  5     $
 auto 6)   # [ 66    5  )     $! Client.Properties.Resources��$ InvoiceDate�� 5  )   �� *VATInvoice.InvoicedDate+$ 
yyyy-MM-dd��  5     $
 auto 6)   # [ 66   $ 未开数量��5  )    5  )   �� *UnOpenedQuantity+# Z   5     $
 auto 6)   # [ 66    5  )     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 
InvoiceQty�� 5  )   �� *VATInvoiceQuantity+# Z   5     $
 auto 6)   '   
Visibility$' Hidden=�5  )    5  )     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicedQty�� 5  )   �� *OpenQuantity+# Z 5  )     5     $
 auto 6)   # [ 66    5  )     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoiceAmount�� 5  )   �� *	VATAmount+# Z&   5     $
 auto 6)   # [ 66    5  )     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicePrice�� 5  )   �� *
VATPrice+(   	STR_PRICE# Z(   5     $
 auto 6)   # [ 66    5  )     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ OpenInvoiceStatus�� 5   )   �� *Quota.VATStatus+# [
   5!     $
 auto 6)   # [ 66   $ 
开/收票��5"  )    5#  )   �� *VATInvoice.VATInvoiceType+# [ 5%     �� 5&     -   5        $��label8��5'  (   $��净重��5&     $��28��6!   $��60��6-   $��Right=�68   $
��Left=�6[   $��
130,13,0,0q�5'     $	��Top=�66   $��1��6N   �� 5(     -   5        $��label9��5)  (   $��28��5(  7   $
��Left=�6C   
����  �$��
191,13,0,0q�5)     $	��Top=�66   $��1��6N   ��5(     �� *TotalNetWeight+5)  N   �� 5*     -   5        $��label10��5+  (   $��毛重��5*     $��28��6!   $��60��6-   $��Right=�68   $
��Left=�6[   $��
260,13,0,0q�5+     $	��Top=�67   $��1��6O   �� 5,     -   5        $��label11��5-  (   
����  �$��28��5,  K   $
��Left=�6W   $��
321,13,0,0q�5-     $	��Top=�67   $��1��6O   ��5,     �� *TotalGrossWeight+5-  O   �� 5.     -   5        $��label12��5.  ^   $��实际数量��6   $��28��6#   $
��Left=�6/   $��
410,13,0,0q�6J   $	��Top=�5/     $��1��6,   �� 50     -   5        $��label13��51  (   
����  �$��28��50  F   $
��Left=�6R   $��
471,13,0,0q�51     $	��Top=�67   $��1��6O   ��50     �� *TotalVerQty+51  O   �� 52     -   5        $��label14��53  (   $��数量��52     $��28��6!   $��60��6-   $��Right=�68   $
��Left=�6[   $��
130,13,0,0q�53     $	��Top=�67   $��3��6O   �� 54     -   5        $��label15��55  (   
����  �$��28��54  L   $
��Left=�6X   $��
191,13,0,0q�55     $	��Top=�67   $��3��6O   ��54     �� *TotalWarehouseQty+55  O   �� 56     -   5        $��label16��57  (   $��开票数量��56     $��28��6#   $��60��6/   $��Right=�6:   $
��Left=�6]   $��
130,13,0,0q�57     $	��Top=�67   $��8��6O   �� 58     -   5        $��label17��59  (   
����  �$��28��58  G   $
��Left=�6S   $��
191,13,0,0q�59     $	��Top=�67   $��8��6O   ��58     �� *TotalOpenQty+59  O   5:     5;     5<     