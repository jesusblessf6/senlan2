   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity )   #Client.View.Reports.LMEMarginReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� N� Title$ LMEPositionPLReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%  &	        '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $	��166 ��� $
��331* �.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *PricingMarginRisk+�� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=��� -   $��tabControl1��$��1��$
��Auto��$
��Left=�$��6,0,0,0q�$	��Top=�$
��Auto��.@��� ��  *PurchaseOurSidePricing+.��� .+�&   System.Windows.Controls.DataGrid  -   $��pOurGrid��   AutoGenerateColumns .  $
��Auto��$
��Left=�$	��Top=�$
��Auto��	   
IsReadOnly	 . $��6,6,0,0q�$��2������ *POurs+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .     Header      ResxName$! Client.Properties.Resources��
   Key$ BP��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *BPName+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaNo�� �� *	QuotaNo+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaQuantity�� �� *QuotaQuantity+$	  DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY �� StringFormat# Z   $
 Auto  .     $! Client.Properties.Resources��$ 	PricedQty�� �� *PricingQuantity+# Z   $
 Auto  .     $! Client.Properties.Resources��$ 
PaidAmount�� �� *
PaymentStr+  $
 Auto  .     $# Client.View.Reports.ResReport��$ InitPricingMargin�� �� *
InitMargin+ 	  
STR_AMOUNT# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurAdditionalMargin�� �� *OurAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppositeReturnedMargin�� �� *TheirReturnMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� �� *	LastPrice+ 	  	STR_PRICE# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ StopLossPrice�� �� *	ExitPrice+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurMarginToAdd�� �� *OurNeedToAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppositeMarginToReturn�� �� *TheirNeedToReturnMargin+# Z �� -   $��tabItem2����  *PurchaseOppoPricing+.��� .+�  -   $��
pTheirGrid�� .  $
��Auto��$
��Left=�$	��Top=�$
��Auto��	 . $��6,6,0,0q����� *	PTheirs+
   $
 Auto  .     $! Client.Properties.Resources��$ BP�� �� *BPName+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaNo�� �� *	QuotaNo+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaQuantity�� �� *QuotaQuantity+# Z   $
 Auto  .     $! Client.Properties.Resources��$ 	PricedQty�� �� *PricingQuantity+# Z   $
 Auto  .     $! Client.Properties.Resources��$ 
PaidAmount�� �� *
PaymentStr+  $
 Auto  .     $# Client.View.Reports.ResReport��$ InitPricingMargin�� �� *
InitMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppoCalledMargin�� �� *TheirAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurReturnedMargin�� �� *OurReturnMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� �� *	LastPrice+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ StopLossPrice�� �� *	ExitPrice+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppoMarginToAdd�� �� *TheirNeedToAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurMarginToReturn�� �� *OurNeedToReturnMargin+# Z �� -   $��tabItem3����  *SalesOurPricing+.��� .+�  -	   $��sOurGrid�� .  $
��Auto��$
��Left=�$	��Top=�$
��Auto��	 . $��6,6,0,0q����� *SOurs+
   $
 Auto  .     $! Client.Properties.Resources��$ BP�� �� *BPName+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaNo�� �� *	QuotaNo+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaQuantity�� �� *QuotaQuantity+# Z   $
 Auto  .     $! Client.Properties.Resources��$ 	PricedQty�� �� *PricingQuantity+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ Received�� �� *
PaymentStr+  $
 Auto  .     $# Client.View.Reports.ResReport��$ InitPricingMargin�� �� *
InitMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurAdditionalMargin�� �� *OurAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppositeReturnedMargin�� �� *TheirReturnMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� �� *	LastPrice+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ StopLossPrice�� �� *	ExitPrice+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurMarginToAdd�� �� *OurNeedToAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppositeMarginToReturn�� �� *TheirNeedToReturnMargin+# Z �� -
   $��tabItem4����  *SalesOppoPricing+.��� .+�  -   $��
sTheirGrid�� .  $
��Auto��$
��Left=�$	��Top=�$
��Auto��	 . $��6,6,0,0q�$��2������ *	STheirs+
   $
 Auto  .     $! Client.Properties.Resources��$ BP�� �� *BPName+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaNo�� �� *	QuotaNo+  $
 Auto  .     $! Client.Properties.Resources��$ QuotaQuantity�� �� *QuotaQuantity+# Z   $
 Auto  .     $! Client.Properties.Resources��$ 	PricedQty�� �� *PricingQuantity+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ Received�� �� *
PaymentStr+  $
 Auto  .     $# Client.View.Reports.ResReport��$ InitPricingMargin�� �� *
InitMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppoCalledMargin�� �� *TheirAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurReturnedMargin�� �� *OurReturnMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� �� *	LastPrice+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ StopLossPrice�� �� *	ExitPrice+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OppoMarginToAdd�� �� *TheirNeedToAppendMargin+# Z   $
 Auto  .     $# Client.View.Reports.ResReport��$ OurMarginToReturn�� �� *OurNeedToReturnMargin+# Z �� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��800����  $! Client.Properties.Resources��$ 
Conditions��.��� .+��� -   $��label1��#��[  $
��Left=�$��1,10,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ 	Commodity���� -   $��	comboBox1��$
��Left=�$��
107,12,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Commodities+ �� SelectedValue �� *SelectedCommodityId+�� -   $��label3��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	StartDate��  -   $��datePicker1��$
��Left=�$��
107,44,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -   $��label4��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ EndDate��  -   $��datePicker2��$
��Left=�$��
366,44,0,0q�$	��Top=� �� *	EndDate+�� -   $��label5��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox3��$��23��$
��Left=�$��
366,12,0,0q�$	��Top=�$	��120��$ 	ShortName��$ Id������ *InternalCustomers+ �� *SelectedInternalCustomerId+&
    Utility.Controls.CurrencyTextBox
  -   $��currencyTextBox2��$��23��$
��Left=�$��
625,12,0,0q�$	��Top=�$	��120�� 
  Text �� *MarginRatio+�� -   $��label2��$
��Left=�#��[  $��
519,10,0,0q�$	��Top=�
���<����  *MarginRatio+�� -   $��label6��$��%��$��28��$
��Left=�$��
749,12,0,0q�$	��Top=�$��20���� -   $��button1��$��23��$
��Left=�$��
625,44,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query��