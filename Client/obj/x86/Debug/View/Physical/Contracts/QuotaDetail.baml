   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      0   *Client.View.Physical.Contracts.QuotaDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      6
Convertersclr-namespace:Client.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract��5       � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�6B   $	��610��6X    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5        *
AddQuota+ � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker.  (Client.Converters.ApproveStatusConverter   ApproveStatusConverter��%M  '��       '�� �     '��     '  �    &	      �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5    
   "  6   .�5!      ��  � ��$ 23��6'   64   �� 5"       � ��$	 120��6&   64   5#        5&   
   6,   5'      .��5)      �� $
��Auto=�6   $
��Auto=�68   .��5*   
   � -   5        	 �Name$	 rootGrid��5*      
 � RowDefinitions
 5+      �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6    �� 50      $
��Auto �6    �� 51      $
��Auto �6    �� 52      $
��Auto �6    �� 53      $
��Auto �6    �� 54      $
��auto �6    .+�57      �� -   5        $��lbTitle��58   Y   $�� ��57      $��32��6   $
��Left=�6+   $��6,6,0,0q�6F   $
��auto��58      $	��Top=�6!   $
��Bold"�69   $��16(�6K   6Y   �� 5:      $��
278,38,0,0q�6_   $
��Left=�6s   $	��Top=�6�   
���<����6        ResxName$! Client.Properties.Resources��
   Key$ ImplementedDate��6�     5;      $
��Left=�6   $��
394,40,0,0q�64   $	��Top=�6H      SelectedDate 5<      �� *ImplementedDate+{�6B   �� *IsImplDateEnable+�� 5=      $��6,70,0,0q�6X   $
��Left=�6j   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ Quantity��5>      &    Utility.Controls.CurrencyTextBox  5?      $��
122,72,0,0q�6!   $	��120��65   $��23��6A   $
��Left=�6M   $	��Top=�6h      Text 5@   !   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {�6w   �� *IsQuantityEnable+�� 5A      -   5         ��Name$ lbPrice��5B      $��
278,70,0,0q�5A   U   $
��Left=�6i   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Price��5B        5C      -   5          Name$ txtPrice��5D   !   $��
394,72,0,0q�5C   !   $	��120��65   $��23��6A   $
��Left=�6N   $	��Top=�6i    5D   3   �� *Price+   	STR_PRICE# Z {�6�   �� *IsPriceEnable+�� 5E      $��	6,166,0,0q�6Y   $
��Left=�6l   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ 	Commodity��5F      �� 5G      -   5         ��Name$ cbCommodity��5I   =   $��122,168,0,0q�5G      $
��Left=�6,   $	��Top=�6G    �� SelectedValuePath$ Id��5H   :    �� DisplayMemberPath$
 Name��6Q   ��6   �� *
Commoditys+ �� SelectedValue 5I      �� *CommodityId+{�5J      �� *IsCommodityEnable+�� 5K      $��278,166,0,0q�6]   $
��Left=�6r   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ CommodityType��5L      �� 5M      -   5        $ cbCmmodityType��5O   A   $��394,168,0,0q�5M      $
��Left=�6,   $	��Top=�6G   $ Id��5N   >   $
 Name��6U   ��6   �� *CommodityTypes+ 5O      �� *CommodityTypeId+6Y   �� 5P      $��	6,198,0,0q�6U   $
��Left=�6h   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Brand��6�   �� 5Q      -   5        $ cbBrand��5S      $��122,200,0,0q�5Q      $
��Left=�6,   $	��Top=�6G   $ Id��5R   6   $
 Name��6M   ��6   �� *Brands+ 6f   �� *	BrandId+5S      �� 5T      $��278,198,0,0q�6]   $
��Left=�6r   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Specification��6�   �� 5U      -   5        $ cbSpecification��5W   A   $��394,200,0,0q�5U      $
��Left=�6,   $	��Top=�6G   $ Id��5V   >   $
 Name��6U   ��6   �� *Specifications+ 5W      �� *SpecificationId+6A   �� 5X      $��	6,230,0,0q�6[   $
��Left=�6n   
���<��$��28��6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ PricingType��6�   �� 5Y      -	   5        $ cbPricingType��5Z   C   $��122,232,0,4q�5Y      $
��Left=�6,   $	 Key��6l   $ Value��6�   $��23��5[   A   ��5Y   G   �� *PricingTypes+ 5Z      �� *SelectPricingType+{�5[      �� *IsPricingTypeEnable+6A   �� 5\      -
   5        $ lbPricingCurrency��5]      $��6,3,0,0q�5\   _   $
��Left=�6p   $	��Top=�6�   
���<��$��3��5]   D   ��5\        $! Client.Properties.Resources��$ PricingCurrency��5]   D   �� 5^      -   5        $ cbxPricingCurrency��5^   E   $��	122,5,0,4q�6   $
��Left=�6*   $
 Name��6�   $ Id��6�   $��3��5_   I   $��23��6V   ��5^   a   �� *
Currencies+ 5_      �� *SelectPricingCurrencyId+6V   �� 5`      -   5        $ lbSettlementRate��5a      $��	278,3,0,0q�5`   \   $
��Left=�6o   $	��Top=�6�   $��3��5a   .   
���<����5`        $! Client.Properties.Resources��$ ExchangeRate��5a   ;     5b      -   5        $ txtSettlementRate��5b   i   $��	394,5,0,4q�6!   $	��120��64   $��23��6A   $
��Left=�6N   $��3��6�    6�   �� *SettlementRate+   STR_RATE# Z 6�   �� 5d      $��6,38,0,0q�6W   $	��Top=�6i   $
��Left=�6�   ��6     $! Client.Properties.Resources��$ QuotaNo��6�   �� 5e      $��
122,40,0,0q�6   $	��Top=�6*   $
��Left=�6B   ��5f      �� *	QuotaNo+�� 5h      $��	6,134,0,0q�6_   $
��Left=�6r   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ FinancialStatus��6�   �� 5i      $��122,136,0,0q�6   $
��Left=�6,   $	��Top=�6G   $ Value��5j   ;   $	 Key��6U   {�.  ��6   �� *StatusTypes+ 5k      �� *FinanceStatus+6?   �� 5l      $��278,134,0,0q�6Z   $
��Left=�6p   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ 
ShipStatus��6�   �� 5m      $��394,136,0,0q�6   $
��Left=�6,   $	��Top=�6G   $ Value��5n   ;   $	 Key��6U   {�.  ��6   �� *StatusTypes+ 5o      �� *DeliveryStatus+6@   �� 5p      -   5        $ lbPricingBasis��5p   �   $��278,230,0,0q�6`   $
��Left=�6u   
���<��$	��Top=�6�   ��6     $! Client.Properties.Resources��$ PricingReference��6�   �� 5q      -   5        $ cbxPricingBasis��5q      $��394,232,0,4q�60   $
��Left=�6E   $	 Key��6�   $ Value��6�   $��23��6D  ��6`   �� *PricingBasises+ 6�   �� *SelectPricingBasis+{�6�   �� *IsPricingBasisEnable+6D  �� 5r      -   5        $ lbPricingStartDate��5r   �   $��6,3,0,0q�6`   $
��Left=�6q   $	��Top=�6�   $��1��6�   ��6     $! Client.Properties.Resources��$ PricingStartDate��6�     5s      -   5          Name$ dpPricingStartDate��5s   q   $��	122,5,0,4q�6   $
��Left=�6,   $��1��6�   $��23��6�    6G   �� *PricingStartDate+{�6�   �� *IsPricingStartDateEnable+6�   �� 5t      -   5        $ lbPricingEndDate��5u      $��	278,3,0,0q�5t   ^   $��Right=�6q   $
��Left=�6�   $	��Top=�6�   $��1��5u   .   ��5t        $! Client.Properties.Resources��$ PricingEndDate��5u   .     5v      -   5        $ dpPricingEndDate��5v   o   $��	394,5,0,4q�6   $
��Left=�6,   $��1��6�   $��23��6�    6G   �� *PricingEndDate+{�6�   �� *IsPricingEndDateEnable+6�   �� 5w      -   5        $ 	lbPremium��5w      $��6,3,0,0q�6j   $
��Left=�6{   $��2��6�   $	��Top=�6�   ��6'     $! Client.Properties.Resources��$ Premium��6�     5x      -   5        $ 
txtPremium��5x   !   $��	122,5,0,4q�65   $	��120��6H   $
��Left=�6T   $��23��6o   $��2��6�    6{   �� *	Premium+{�6�   �� *IsPremiumEnable+6�   �� 5y      -   5        $ lbPricingSide��5z      $��	278,3,0,0q�5y   [   $	��Top=�6n   $��2��5z   +   $
��Left=�68   ��5y        $! Client.Properties.Resources��$ PricingSide��5z   8   	� 5{      -   5         	�Name$ rbtPricingSideTheir��5|   -   $��20��5{   ^   $��	394,9,0,0q�5|      $	��Top=�6J   $��2��6b   $
��Left=�6o   ��5{        $! Client.Properties.Resources��$ OppoSide�� d� 	IsChecked 6j   �� *PricingSideTheir+5|   o   	� 5}      -   5        $ rbtPricingSideOwn��5~   -   $��	474,9,0,0q�6   $��20��6H   $	��Top=�6T   $��2��6l   $
��Left=�6y   ��5}        $! Client.Properties.Resources��$ OurSide�� 6]   �� *PricingSideOwn+5~   y   �� 5      -   5        $ lbWarehouse��5   �   $��6,3,0,0q�6Y   $
��Left=�6j   $��4��6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ 	Warehouse��6�   �� 5�      -   5         ��Name$ btnWarehouse��5�   I   $	��...��6   $
��Left=�6#   $��25��6>   $��	246,5,0,4q�5�   .   $��4��6A   $��23��6N   �� 5�      -   5        $ lbDeliveryDate��5�      $��	278,3,0,0q�5�   2   $
��Left=�6E   $��Right=�6`   $��4��5�   ,   $	��Top=�69   ��5�        *DeliveryDate+5�   9     5�      -   5        $ dpDeliveryDate��5�   G   $��	394,5,0,4q�6   $
��Left=�6,   $��4��6�   $��23��6�    6_   �� *DeliveryDate+6�   �� 5�      -   5        $��lbShipCondition��5�   �   $��6��6X   $
��Left=�6e   $��6,3,0,0q�6�   $	��Top=�6�   $��2��6�   ��6     $! Client.Properties.Resources��$ ShipTerm��6�   �� 5�      -   5        $��tbShipCondition��5�   ]   $��6��6   $��23��6#   $
��Left=�6/   $��	122,5,0,4q�6J   $	��Top=�6t   $	��120��6�   ��6�   �� *
ShipTerm+�� 5�      -   5        $��
210,14,0,0q�5�   U   $
��Left=�6i   $	��Top=�6�   $��23��6�   $��60��5�      $��8��6-   ��5�        $! Client.Properties.Resources��$
 Save��5�   -   �� 5�      -    5        $��
408,14,0,0q�5�   \   $
��Left=�6p   $	��Top=�6�   $��23��6�   $��60��5�      $��8��6    $y�Hidden=�6k   ��5�        $! Client.Properties.Resources��$ SaveAsDraft��{�5�   A   �� *IsSaveAsDraftEnable+6k   �� 5�      $��	6,102,0,0q�6^   $
��Left=�6q   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ DocumentStatus��6�   �� 5�      $��122,104,0,0q�6   $
��Left=�6+   $	��Top=�6F   {�.  5�      �� 5�      $��278,102,0,0q�6^   $
��Left=�6s   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ ApprovalStatus��6�   �� 5�      $��394,104,0,0q�6   $
��Left=�6+   $	��Top=�6F   {�.  ��5�      �� *ApproveStatus+ �� 	Converter# [  6h   �� 5�      -!   5         ��Name$ txtWarehouse��5�   D   $��	122,5,0,4q�6   $
��Left=�6)   {�.  $��4��6�   $��23��6�   ��6Z   �� *WarehouseName+6�   �� 5�      -"   5        $��btCancel��5�   �   $��23��6W   $
��Left=�6c   $��
305,14,0,0q�6~   $	��Top=�6�   $��60��6�   $��8��6�   ��6     $! Client.Properties.Resources��$ Cancel��6�   �� 5�      $��原始批次号��6   $
��Left=�6$   $��	278,3,0,0q�6?   $	��Top=�6R   $��5��6j   $��2��6w   �� 5�      $
��Left=�6   $��	394,5,0,4q�61   $	��Top=�6_   $��5��6w   ��6D   �� *	ExQuotaNo+6w   �� 5�      -#   5        $��paymentMean��5�   �   $	 Key��6   $
��Left=�6/   $��	122,5,0,4q�6n   $ Value��6�   $	��Top=�6�   $��5��6�   ��6J   �� *PaymentMean+ 6�   �� *SelectPaymentMeanId+6�   �� 5�      -$   5        $��label6��5�   �   $
��Left=�6[   $��6,3,0,0q�6v   $	��Top=�6�   $��5��6�   ��6     $! Client.Properties.Resources��$ PaymentMean��6�   �� 5�      -%   5        $��lbVATInvoiceDate��5�   n   $��28��66   $
��Left=�6B   $��5,2,0,0q�6]   $	��Top=�6�   $	��110��6�   $��7��6�   ��6   �� *VATInvoiceStr+6�     5�      -&   5        $��datePicker2��5�   G   $
��Left=�6   $��	122,5,0,0q�64   $	��Top=�6�   $��7��6�    6Z   �� *VATInvoiceDate+6�   �� 5�      -'   5        $��label1��5�   _   $��对手批次号��6   $��6��6$   $
��Left=�61   $��	278,3,0,0q�6L   $	��Top=�6m   $��2��6�   y�6�   �� *IsAutoNoVisible+�� 5�      -(   5        $��textBox1��5�   ]   $��6��6   $��23��6#   $
��Left=�6/   $��	394,5,0,4q�6J   $	��Top=�6m   $	��120��6�   $��2��6�   y�6�   �� *IsAutoNoVisible+��6�   �� *AutoQuotaNo+5�      5�      5�      