   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 0   *Client.View.Physical.Contracts.QuotaDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�$	��610�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title   *
AddQuota+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker.  (Client.Converters.ApproveStatusConverter   ApproveStatusConverter��%8  '��       '�� S     '�� �     '  �     &	      �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  .���� $
��Auto=�$
��Auto=�.��� -   	 �Name$	 rootGrid��
 � RowDefinitions
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��auto �.+��� -   $��lbTitle��$�� ��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(��� $��
278,38,0,0q�$
��Left=�$	��Top=�
���<����     ResxName$! Client.Properties.Resources��
   Key$ ImplementedDate��  $
��Left=�$��
394,40,0,0q�$	��Top=�   SelectedDate �� *ImplementedDate+{��� *IsImplDateEnable+�� $��6,70,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ Quantity��&    Utility.Controls.CurrencyTextBox  $��
122,72,0,0q�$	��120��$��23��$
��Left=�$	��Top=�   Text �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {��� *IsQuantityEnable+�� -    ��Name$ lbPrice��$��
278,70,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ Price��  -     Name$ txtPrice��$��
394,72,0,0q�$	��120��$��23��$
��Left=�$	��Top=� �� *Price+   	STR_PRICE# Z {��� *IsPriceEnable+�� $��	6,166,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ 	Commodity���� -    ��Name$ cbCommodity��$��122,168,0,0q�$
��Left=�$	��Top=� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *
Commoditys+ �� SelectedValue �� *CommodityId+{��� *IsCommodityEnable+�� $��278,166,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ CommodityType���� -   $ cbCmmodityType��$��394,168,0,0q�$
��Left=�$	��Top=�$ Id��$
 Name������ *CommodityTypes+ �� *CommodityTypeId+�� $��	6,198,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ Brand���� -   $ cbBrand��$��122,200,0,0q�$
��Left=�$	��Top=�$ Id��$
 Name������ *Brands+ �� *	BrandId+�� $��278,198,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ Specification���� -   $ cbSpecification��$��394,200,0,0q�$
��Left=�$	��Top=�$ Id��$
 Name������ *Specifications+ �� *SpecificationId+�� $��	6,230,0,0q�$
��Left=�
���<��$��28��$	��Top=���  $! Client.Properties.Resources��$ PricingType���� -	   $ cbPricingType��$��122,232,0,4q�$
��Left=�$	 Key��$ Value��$��23������ *PricingTypes+ �� *SelectPricingType+{��� *IsPricingTypeEnable+�� -
   $ lbPricingCurrency��$��6,3,0,0q�$
��Left=�$	��Top=�
���<��$��3����  $! Client.Properties.Resources��$ PricingCurrency���� -   $ cbxPricingCurrency��$��	122,5,0,4q�$
��Left=�$
 Name��$ Id��$��3��$��23������ *
Currencies+ �� *SelectPricingCurrencyId+�� -   $ lbSettlementRate��$��	278,3,0,0q�$
��Left=�$	��Top=�$��3��
���<����  $! Client.Properties.Resources��$ ExchangeRate��  -   $ txtSettlementRate��$��	394,5,0,4q�$	��120��$��23��$
��Left=�$��3�� �� *SettlementRate+   STR_RATE# Z �� $��6,38,0,0q�$	��Top=�$
��Left=���  $! Client.Properties.Resources��$ QuotaNo���� $��
122,40,0,0q�$	��Top=�$
��Left=����� *	QuotaNo+�� $��	6,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ FinancialStatus���� $��122,136,0,0q�$
��Left=�$	��Top=�$ Value��$	 Key��{�.  ���� *StatusTypes+ �� *FinanceStatus+�� $��278,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ 
ShipStatus���� $��394,136,0,0q�$
��Left=�$	��Top=�$ Value��$	 Key��{�.  ���� *StatusTypes+ �� *DeliveryStatus+�� -   $ lbPricingBasis��$��278,230,0,0q�$
��Left=�
���<��$	��Top=���  $! Client.Properties.Resources��$ PricingReference���� -   $ cbxPricingBasis��$��394,232,0,4q�$
��Left=�$	 Key��$ Value��$��23������ *PricingBasises+ �� *SelectPricingBasis+{��� *IsPricingBasisEnable+�� -   $ lbPricingStartDate��$��6,3,0,0q�$
��Left=�$	��Top=�$��1����  $! Client.Properties.Resources��$ PricingStartDate��  -     Name$ dpPricingStartDate��$��	122,5,0,4q�$
��Left=�$��1��$��23�� �� *PricingStartDate+{��� *IsPricingStartDateEnable+�� -   $ lbPricingEndDate��$��	278,3,0,0q�$��Right=�$
��Left=�$	��Top=�$��1����  $! Client.Properties.Resources��$ PricingEndDate��  -   $ dpPricingEndDate��$��	394,5,0,4q�$
��Left=�$��1��$��23�� �� *PricingEndDate+{��� *IsPricingEndDateEnable+�� -   $ 	lbPremium��$��6,3,0,0q�$
��Left=�$��2��$	��Top=���  $! Client.Properties.Resources��$ Premium��  -   $ 
txtPremium��$��	122,5,0,4q�$	��120��$
��Left=�$��23��$��2�� �� *	Premium+{��� *IsPremiumEnable+�� -   $ lbPricingSide��$��	278,3,0,0q�$	��Top=�$��2��$
��Left=���  $! Client.Properties.Resources��$ PricingSide��	� -    	�Name$ rbtPricingSideTheir��$��20��$��	394,9,0,0q�$	��Top=�$��2��$
��Left=���  $! Client.Properties.Resources��$ OppoSide�� d� 	IsChecked �� *PricingSideTheir+	� -   $ rbtPricingSideOwn��$��	474,9,0,0q�$��20��$	��Top=�$��2��$
��Left=���  $! Client.Properties.Resources��$ OurSide�� �� *PricingSideOwn+�� -   $ lbWarehouse��$��6,3,0,0q�$
��Left=�$��4��$	��Top=���  $! Client.Properties.Resources��$ 	Warehouse���� -    ��Name$ btnWarehouse��$	��...��$
��Left=�$��25��$��	246,5,0,4q�$��4��$��23���� -   $ lbDeliveryDate��$��	278,3,0,0q�$
��Left=�$��Right=�$��4��$	��Top=���  *DeliveryDate+  -   $ dpDeliveryDate��$��	394,5,0,4q�$
��Left=�$��4��$��23�� �� *DeliveryDate+�� -   $��lbShipCondition��$��6��$
��Left=�$��6,3,0,0q�$	��Top=�$��2����  $! Client.Properties.Resources��$ ShipTerm���� -   $��tbShipCondition��$��6��$��23��$
��Left=�$��	122,5,0,4q�$	��Top=�$	��120������ *
ShipTerm+�� -   $��
210,28,0,0q�$
��Left=�$	��Top=�$��23��$��60��$��8����  $! Client.Properties.Resources��$
 Save���� -    $��
408,14,0,0q�$
��Left=�$	��Top=�$��23��$��60��$��8��$y�Hidden=���  $! Client.Properties.Resources��$ SaveAsDraft��{��� *IsSaveAsDraftEnable+�� $��	6,102,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ DocumentStatus���� $��122,104,0,0q�$
��Left=�$	��Top=�{�.  �� $��278,102,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ ApprovalStatus���� $��394,104,0,0q�$
��Left=�$	��Top=�{�.  ���� *ApproveStatus+ �� 	Converter# [  �� -!    ��Name$ txtWarehouse��$��	122,5,0,4q�$
��Left=�{�.  $��4��$��23������ *WarehouseName+�� -"   $��btCancel��$��23��$
��Left=�$��
305,28,0,0q�$	��Top=�$��60��$��8����  $! Client.Properties.Resources��$ Cancel���� $��原始批次号��$
��Left=�$��	278,3,0,0q�$	��Top=�$��5��$��2���� $
��Left=�$��	394,5,0,4q�$	��Top=�$��5������ *	ExQuotaNo+�� -#   $��paymentMean��$	 Key��$
��Left=�$��	122,5,0,4q�$ Value��$	��Top=�$��5������ *PaymentMean+ �� *SelectPaymentMeanId+�� -$   $��label6��$
��Left=�$��6,3,0,0q�$	��Top=�$��5����  $! Client.Properties.Resources��$ PaymentMean���� -%   $��lbVATInvoiceDate��$��28��$
��Left=�$��5,2,0,0q�$	��Top=�$	��110��$��7������ *VATInvoiceStr+  -&   $��datePicker2��$
��Left=�$��	122,5,0,0q�$	��Top=�$��7�� �� *VATInvoiceDate+�� -'   $��label1��$��对手批次号��$��6��$
��Left=�$��	278,3,0,0q�$	��Top=�$��2��y��� *IsAutoNoVisible+�� -(   $��textBox1��$��6��$��23��$
��Left=�$��	394,5,0,4q�$	��Top=�$	��120��$��2��y��� *IsAutoNoVisible+���� *AutoQuotaNo+