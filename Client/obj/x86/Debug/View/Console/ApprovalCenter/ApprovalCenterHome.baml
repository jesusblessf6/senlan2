   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6.   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      ;    5Client.View.Console.ApprovalCenter.ApprovalCenterHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6.   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.Console.ApprovalCenter.ResApprovalCenter��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *ApprovalCenter+ � 	Resources 5      ,   &Client.Converters.PricingTypeConverter   PTC4   .Client.Converters.BusinessPartnerTypeConverter  BPTypeConverter  QuotaApprove  QuotaReject  PaymentRequestApprove  PaymentRequestReject   VATInvoiceRequestLineApprove  VATInvoiceRequestLineReject  	BPApprove 	 BPReject 
 PaymentRequestActions �� DataType �� Orientation   VATInvoiceRequestLineActions  BPApproveActions��%!  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     7  7  &	 �    7  7  &	 �    7  7 	   5      6)     5      6=   �� 5      6)   �� 5      6(   �� 5      62   �� 5      61   �� 5      69   �� 5      68   �� 5   
   6,   �� 5   
   6+   �� 5      $ DBEntity:PaymentRequest��6/   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��同意��6   8��  ��6K   �� *Id+6m   �� 5      $��拒绝��6   8�� ��6J   �� *Id+6l   5       5!      �� 5#      $$ DBEntity:VATInvoiceRequestLine��66   .R�5$      �� $ 
Horizontal=�6   .+�5%      �� $��同意��6   8��  ��6R   �� *Id+6t   �� 5&      $��拒绝��6   8�� ��6Q   �� *Id+6s   5'      5(      �� 5*   
   $ DBEntity:BusinessPartner��60   .R�5+      �� $ 
Horizontal=�6   .+�5,      �� $��同意��6   8��  ��6K   �� *Id+6m   �� 5-      $��拒绝��6   8�� ��6J   �� *Id+6l   5.      5/      50       J� CommandBindings 52      )  #System.Windows.Input.CommandBinding  53      -   5           Command# [ 53      6�     54      -   5        # [ 54      6~     56      -   5        # [ 56      6q     57      -   5        # [ 57      6o     59      -   5        # [ 59      6     5:      -   5        # [ 5:      6}     5<   
   -   5        # [ 5<      6_     5=   
   -   5        # [	 5=      6]   .��5@      �� $
��Auto=�6   $
��Auto=�65   .��5A      � -	   5        $��rootGrid��5A   	   .+�5B      �� -
   5        $��lbTitle��5B   +   $
��Left=�6:   $��6,6,0,0q�6U   $��32��6f   $	��Top=�6r   $
��Bold"�6�   $��16(�6�   ��6     *ApprovalCenter+6�   �� 5C      $
��Auto��6   $	��Top=�6   $
��Left=�66   $
��Auto��6Q   $��6,40,0,0q�6^   .@�5D      �� ��6     *QuotaApproval+.��5E      � -   5        $��	quotaGrid��5E       � RowDefinitions 5F      �� 5G   	   $
��Auto �6   �� 5H   	   $��* �6   .+�5J      �� -   5        $��label1��5J   d   $��28��6,   $
��Left=�68   $��6,6,0,0q�6S   $	��Top=�6r   ��6     *PurchaseList+6r   &   System.Windows.Controls.DataGrid  5K      -   5        $��	dataGrid1��5K   h   	   AutoGenerateColumns	 .  $
��Auto��6-   $
��Left=�6;   $��6,40,0,0q�6V   $	��Top=�6y   $
��Auto��6�   
   
IsReadOnly
 .   DataGridStyle#��[ 5M        DataGridRowStyle   RowStyle# [ 62   ��5L      �� *PurchaseQuotas+   Columns 5N   	   0  *System.Windows.Controls.DataGridTextColumn  5O   
   ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6_      CanUserSort .    Header 6        ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6   �� *	QuotaNo+6�     5P   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Supplier�� 6�   �� *$"Contract.BusinessPartner.ShortName+6�     5Q   
   $
 Auto	 6a    .  6     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *Commodity.Name+6�     5R   
   $
 Auto	 6]    .  6     $! Client.Properties.Resources��$ Brand�� 6}   �� *
Brand.Name+6�     5S   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Quantity�� 6�   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�     5T   
   $
 Auto	 6]    .  6     $! Client.Properties.Resources��$ Price�� 6}   �� *
StrPrice+6�     5U   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Currency�� 6�   �� *Currency.Name+6�     5W   
   $
 Auto	 6    .  6=   �� *PricingType+ �� 	Converter# [   5X      �� 5Y      ��6     $! Client.Properties.Resources��$ PricingTypeShort�� � ToolTip 6_     $! Client.Properties.Resources��$ PricingType��6�   5[        5\   
   $
 Auto	 6    .  6=   �� *%#Contract.InternalCustomer.ShortName+ 5]      �� 5^       6     $! Client.Properties.Resources��$ InternalCustomer����6b     $! Client.Properties.Resources��$ InternalCustomerShort��6�   5`        5a   
   $ 	申请人��6   $
 Auto	 6*    .  6J   �� *	User.Name+6j     5b   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Comments�� 6�   �� *Contract.Description+6�     5c   
   $
 Auto	 6    .    
Visibility$ Hidden=�6_    6=   �� *Approval.Name+ 5d      �� 5e      ��6     $! Client.Properties.Resources��$ ApprovalShort�� 6\     $! Client.Properties.Resources��$ Approval��6�   5g      4  .System.Windows.Controls.DataGridTemplateColumn  5h   
   $
 Auto	 6!    .   5i      �� 5j      ��6     $! Client.Properties.Resources��$ ApprovalDetailShort�� 6b     $! Client.Properties.Resources��$ ApprovalDetail��6�      CellTemplate 5l      �� 5m      $ DBEntity:Quota��6   .R�5n      �� �� 5o      
��� � ��6%   �� *CustomerStrField1+6J    �� 5p      
���  ���6#   �� *CustomerStrField2+6H   5q      5r      5t        5u   
   $ 流转��6   $
 Auto	 6)    .  6I   �� *RelQuotaStr+6k     5v   
    .  $
 Auto	 6y    6!     $! Client.Properties.Resources��$ 	Operation�� 5w      �� 5x      $ DBEntity:Quota��6   .R�5y      �� $ 
Horizontal=�6   .+�5z      �� $��同意��6   #��[ 6"   ��6J   �� *Id+{�6j   �� *ApprovalCanEdit+6�   �� 5{      $��拒绝��6   #��[ 6"   ��6I   �� *Id+{�6i   �� *ApprovalCanEdit+6�   5|      5}      5      5�   	   �� 5�      -   5        $��label2��5�   a   $��28��6)   $
��Left=�65   $��6,6,0,0q�6P   $	��Top=�6o   $��1��6�   ��6     *	SalesList+6�     5�      -   5        $��	dataGrid2��5�   u   	 .  $��1��6-   $
��Auto��6:   $
��Left=�6H   $��6,40,0,0q�6c   $	��Top=�6�   $
��Auto��6�   
 . #��[ 5�   b   # [ 6�   ��6   �� *SalesQuotas+ 5�   	     5�   
   $
 Auto	 6_    .  6     $! Client.Properties.Resources��$ QuotaNo�� 6   �� *	QuotaNo+6�     5�   
   $
 Auto	 6]    .  6     $! Client.Properties.Resources��$ Buyer�� 6}   �� *$"Contract.BusinessPartner.ShortName+6�     5�   
   $
 Auto	 6a    .  6     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *Commodity.Name+6�     5�   
   $
 Auto	 6]    .  6     $! Client.Properties.Resources��$ Brand�� 6}   �� *
Brand.Name+6�     5�   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Quantity�� 6�   �� *
Quantity+# Z 6�     5�   
   $
 Auto	 6]    .  6     $! Client.Properties.Resources��$ Price�� 6}   �� *
StrPrice+6�     5�   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Currency�� 6�   �� *Currency.Name+6�     5�   
   $
 Auto	 6    .  6=   �� *PricingType+# [   5�      �� 5�      ��6     $! Client.Properties.Resources��$ PricingTypeShort�� 6_     $! Client.Properties.Resources��$ PricingType��6�   5�        5�   
   $
 Auto	 6m    .  6     $! Client.Properties.Resources��$ InternalCustomerShort�� 6�   �� *%#Contract.InternalCustomer.ShortName+6�     5�   
   $ 	申请人��6   $
 Auto	 6*    .  6J   �� *	User.Name+6j     5�   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Comments�� 6�   �� *Contract.Description+6�     5�   
   $
 Auto	 6    .  6=   �� *Approval.Name+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ ApprovalShort�� 6\     $! Client.Properties.Resources��$ Approval��6�   5�        5�   
   $
 Auto	 6"    .   5�      �� 5�      ��6     $! Client.Properties.Resources��$ ApprovalDetailShort�� 6b     $! Client.Properties.Resources��$ ApprovalDetail��6�    5�      �� 5�      $ DBEntity:Quota��6   .R�5�      �� �� 5�      
��� � ��6#   �� *CustomerStrField1+6H    �� 5�      
���  ���6!   �� *CustomerStrField2+6F   5�      5�      5�        5�   
   $ 流转��6   $
 Auto	 6)    .  6I   �� *RelQuotaStr+6k     5�   
    .   6!     $! Client.Properties.Resources��$ 	Operation�� 5�      �� 5�      $ DBEntity:Quota��6   .R�5�      �� $ 
Horizontal=�6   .+�5�      �� $��同意��6   #��[ 6"   ��6J   �� *Id+6l   �� 5�      $��拒绝��6   #��[ 6"   ��6I   �� *Id+6k   5�      5�      5�      5�   	   5�      5�      �� 5�      ��6     *PaymentApproval+.��5�      � .+�5�        -   5        $��dgPaymentRequest��5�      	 .  $
��Auto��6E   $
��Left=�6S   $��6,6,0,0q�6n   $	��Top=�6   $
��Auto��5�      
 . #��[ 5�      # [ 62   ��5�   *   �� *PaymentRequests+ 5�   	     5�   
   $
 Auto	 6_    .  6     $! Client.Properties.Resources��$ QuotaNo�� 6   �� *Quota.QuotaNo+6�     5�   
   $
 Auto	 6    .  6=   �� *RequestDate+$ {0:yyyy-MM-dd}�� 5�      �� 5�      ��6     $! Client.Properties.Resources��$ ApplyDateShort�� 6]     $! Client.Properties.Resources��$ 	ApplyDate��6�   5�        5�   
   $
 Auto	 6    .  6=   �� *RequestAmount+   
STR_AMOUNT# Z  5�      �� 5�      ��6     $! Client.Properties.Resources��$ AppliedAmountShort�� 6a     $! Client.Properties.Resources��$ AppliedAmount��6�   5�        5�   
   $
 Auto	 6    .  6=   �� *Currency.Name+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ PaymentCurrencyShort�� 6c     $! Client.Properties.Resources��$ PaymentCurrency��6�   5�        5�   
   $
 Auto	 6    . $ Hidden=�6n    6=   �� *PayBusinessPartner.ShortName+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ PaymentBPShort�� 6]     $! Client.Properties.Resources��$ 	PaymentBP��6�   5�        5�   
   $
 Auto	 6    . $ Hidden=�6j    6=   �� *PayBankAccount.Bank.Name+ 5�      �� 5�      ��6     $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ PaymentBankShort�� 6x     $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ PaymentBank��6�   5�        5�   
   $
 Auto	 6    . $ Hidden=�6l    6=   �� *PayBankAccount.AccountCode+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ PaymentAccountShort�� 6b     $! Client.Properties.Resources��$ PaymentAccount��6�   5�        5�   
   $
 Auto	 6a    .  6     $! Client.Properties.Resources��$ 	ReceiptBP�� 6�   �� *" ReceiveBusinessPartner.ShortName+6�     5�   
   $
 Auto	 6|    . $ Hidden=�6�    6     $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ ReceiptBank�� 6�   �� *ReceiveBankAccount.Bank.Name+6�     5�   
   $
 Auto	 6    . $ Hidden=�6p    6=   �� * ReceiveBankAccount.AccountCode+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ ReceiptAccountShort�� 6b     $! Client.Properties.Resources��$ ReceiptAccount��6�   5�        5�   
   $
 Auto	 6    .  6=   �� *PaymentUsage.Name+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ PaymentUsageShort�� 6`     $! Client.Properties.Resources��$ PaymentUsage��6�   5�        5�   
   $
 Auto	 6    . $ Hidden=�6b    6=   �� *PaymentMean.Name+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ PaymentMeanShort�� 6_     $! Client.Properties.Resources��$ PaymentMean��6�   5�        5�   
   $ 流转��6   $
 Auto	 6)    .  6I   �� *Quota.RelQuotaStr+6q     5�   
   $ 	申请人��6   $
 Auto	 6*    .  6J   �� *	User.Name+6j     5�   
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Comments�� 6�   �� *	Comment+6�     5�   
   $
 Auto	 6    .  6=   �� *Approval.Name+ 5�      �� 5�      ��6     $! Client.Properties.Resources��$ ApprovalShort�� 6\     $! Client.Properties.Resources��$ Approval��6�   5�        5�   
    .   5�      �� 5�      ��6     $! Client.Properties.Resources��$ ApprovalDetailShort�� 6b     $! Client.Properties.Resources��$ ApprovalDetail��6�    5�      �� 5�      $ DBEntity:PaymentRequest��6   .R�5�      �� �� 5�      
��� � ��6#   �� *CustomerStrField1+6H    �� 5�      
���  ���6!   �� *CustomerStrField2+6F   5�      5�      5       5  
   $
 Auto	 6e   # [
 6r    6!     $! Client.Properties.Resources��$ 	Operation��6�   5  	   5     5     �� 5     ��6     *VATInvoiceApproval+.��5     � .+�5	       -   5        $��dbVATInvoiceRequestLine��5	     	 .  $
��Auto��6L   $
��Left=�6Z   $��6,6,0,0q�6u   $	��Top=�6�   $
��Auto��5
     
 . #��[ 5     # [ 62   ��5
  *   �� *VATInvoiceRequestLines+ 5  	     5  
   $
 Auto	 6_    .  6     $! Client.Properties.Resources��$ QuotaNo�� 6   �� *Quota.QuotaNo+6�     5  
   $
 Auto	 6]    .  6     $! Client.Properties.Resources��$ Buyer�� 6}   �� *-+VATInvoiceRequest.BusinessPartner.ShortName+6�     5  
   $
 Auto	 6{    .  6     $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ 
InvoicedBP�� 6�   �� *.,VATInvoiceRequest.InternalCustomer.ShortName+6�     5  
   $
 Auto	 6a    .  6     $! Client.Properties.Resources��$ 	ApplyDate�� 6�   �� *VATInvoiceRequest.RequestDate+$ {0:yyyy-MM-dd}��6�     5  
   $
 Auto	 6^    .  6     $! Client.Properties.Resources��$ Amount�� 6~   �� *RequestAmount+# Z 6�     5  
   $
 Auto	 6e    .  6     $! Client.Properties.Resources��$ ApplyQuantity�� 6�   �� *RequestQuantity+# Z 6�     5  
   $ 	申请人��6   $
 Auto	 6*    .  6J   �� *	User.Name+6j     5  
   $
 Auto	 6`    .  6     $! Client.Properties.Resources��$ Comments�� 6�   �� *	Comment+6�     5  
   $
 Auto	 6    .  6=   �� *Approval.Name+ 5     �� 5     ��6     $! Client.Properties.Resources��$ ApprovalShort�� 6\     $! Client.Properties.Resources��$ Approval��6�   5       5  
    .   5     �� 5     ��6     $! Client.Properties.Resources��$ ApprovalDetailShort�� 6b     $! Client.Properties.Resources��$ ApprovalDetail��6�    5     �� 5     $$ DBEntity:VATInvoiceRequestLine��6   .R�5      �� �� 5!     
��� � ��6#   �� *CustomerStrField1+6H    �� 5"     
���  ���6!   �� *CustomerStrField2+6F   5#     5$     5&       5'  
   $
 Auto	 6e   # [ 6r    6!     $! Client.Properties.Resources��$ 	Operation��6�   5)  	   5*     5+     �� 5,     $��客户/经纪行审批��6   .��5-     � .+�5.       -   5        $��bpApproveLines��5.     	 .  $
��Auto��6C   $
��Left=�6Q   $��6,6,0,0q�6l   $	��Top=�6}   $
��Auto��5/     
 . #��[ 50     # [ 62   ��5/  *   �� *BPApproveLines+ 51  	     52  "   $ 客户类型��65   $
 Auto	 6C    .  6c   �� *CustomerType+# [ 6�     53  
   $ 客户简称��6   $
 Auto	 6+    .  6K   �� *	ShortName+6k     54  
   $ 客户全称��6   $
 Auto	 6+    .  6K   �� *Name+6f     55  
   $ 客户代码��6   $
 Auto	 6+    .  6K   �� *Code+6f     56  
   $ 	联系人��6   $
 Auto	 6*    .  6J   �� *ContactPerson+6n     57  
   $ 联系电话��6   $
 Auto	 6+    .  6K   �� *ContactPhone+6n     58  
   $ 	申请人��6   $
 Auto	 6*    .  6J   �� *	User.Name+6j     59  
   $
 Auto	 6    .  6=   �� *Approval.Name+ 5:     �� 5;     ��6     $! Client.Properties.Resources��$ ApprovalShort�� 6\     $! Client.Properties.Resources��$ Approval��6�   5=       5>  
    .   5?     �� 5@     ��6     $! Client.Properties.Resources��$ ApprovalDetailShort�� 6b     $! Client.Properties.Resources��$ ApprovalDetail��6�    5B     �� 5C     $ DBEntity:BusinessPartner��6   .R�5D     �� �� 5E     
��� � ��6#   �� *CustomerStrField1+6H    �� 5F     
���  ���6!   �� *CustomerStrField2+6F   5G     5H     5J       5K  "   $
 Auto	 6}   # [ 6�    69     $! Client.Properties.Resources��$ 	Operation��6�   5M  	   5N     5O     5P     5Q     5R     5S     