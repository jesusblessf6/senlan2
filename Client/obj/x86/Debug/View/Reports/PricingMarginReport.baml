   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5	   2   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      )   #Client.View.Reports.LMEMarginReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	   2   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       N� Title$ LMEPositionPLReport��5	       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%  &	        '�� �     '  m    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5!      .��5#      �� $
��Auto=�6   $
��Auto=�68   .��5$   
   � -   5        $��rootGrid��5$       � RowDefinitions 5%      �� 5&      $	��166 �6    �� 5'      $
��331* �6    .+�5)      �� -   5        $��lbTitle��5)   7   $
��Left=�6F   $��6,6,0,0q�6a   $��32��5*      $	��Top=�5+      $
��Bold"�6,   $��16(�6>   ��5)        *PricingMarginRisk+5+   >   �� 5,      -   5        $��
separator1��5,   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   �� 5-      -   5        $��tabControl1��5-   `   $��1��6   $
��Auto��6&   $
��Left=�64   $��6,0,0,0q�6O   $	��Top=�5.      $
��Auto��61   .@�5/      �� ��6     *PurchaseOurSidePricing+.��50      � .+�51      &   System.Windows.Controls.DataGrid  -   5        $��pOurGrid��52   H      AutoGenerateColumns .  $
��Auto��51   ?   $
��Left=�6M   $	��Top=�52   #   $
��Auto��6;   	   
IsReadOnly	 . $��6,6,0,0q�53   #   $��2��54   A   ��6#   �� *POurs+
   Columns
 55      0  *System.Windows.Controls.DataGridTextColumn  56   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 57   5      CanUserSort .     Header 56   5        ResxName$! Client.Properties.Resources��
   Key$ BP��1  +System.Windows.Controls.DataGridBoundColumn   Binding 58   5   �� *BPName+59   #     5:   "   $
 Auto 5;   5    .   5:   5     $! Client.Properties.Resources��$ QuotaNo�� 5<   5   �� *	QuotaNo+5=   #     5>   "   $
 Auto 5@   %    .   5?   %     $! Client.Properties.Resources��$ QuotaQuantity�� 5A   %   �� *QuotaQuantity+$	  DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY �� StringFormat# Z 5B   #     5C   "   $
 Auto 5D   5    .   5C   5     $! Client.Properties.Resources��$ 	PricedQty�� 5E   5   �� *PricingQuantity+# Z 5F   #     5G   "   $
 Auto 5H   j    .   6%     $! Client.Properties.Resources��$ 
PaidAmount�� 5J   %   �� *
PaymentStr+5K   #     5L   "   $
 Auto 5N   %    .   5M   %     $# Client.View.Reports.ResReport��$ InitPricingMargin�� 5O   %   �� *
InitMargin+ 	  
STR_AMOUNT# Z 5P   #     5Q   "   $
 Auto 5S   %    .   5R   %     $# Client.View.Reports.ResReport��$ OurAdditionalMargin�� 5T   %   �� *OurAppendMargin+# Z 5U   #     5V   "   $
 Auto 5X   %    .   5W   %     $# Client.View.Reports.ResReport��$ OppositeReturnedMargin�� 5Y   %   �� *TheirReturnMargin+# Z 5Z   #     5[   "   $
 Auto 5]   %    .   5\   %     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� 5^   %   �� *	LastPrice+ 	  	STR_PRICE# Z 5_   #     5`   "   $
 Auto 5b   %    .   5a   %     $# Client.View.Reports.ResReport��$ StopLossPrice�� 5c   %   �� *	ExitPrice+# Z 5d   #     5e   "   $
 Auto 5g   %    .   5f   %     $# Client.View.Reports.ResReport��$ OurMarginToAdd�� 5h   %   �� *OurNeedToAppendMargin+# Z 5i   #     5j   "   $
 Auto 5l   %    .   5k   %     $# Client.View.Reports.ResReport��$ OppositeMarginToReturn�� 5m   %   �� *TheirNeedToReturnMargin+# Z 5n   #   5y      5z      5{      �� 5|      -   5        $��tabItem2��5|   >   ��6     *PurchaseOppoPricing+.��5}      � .+�5~        -   5        $��
pTheirGrid��5   H    .  $
��Auto��5~   ?   $
��Left=�6M   $	��Top=�5   #   $
��Auto��6;   	 . $��6,6,0,0q�5�   #   ��5�   #   �� *	PTheirs+
 5�        5�   "   $
 Auto 5�   5    .   5�   5     $! Client.Properties.Resources��$ BP�� 5�   5   �� *BPName+5�   #     5�   "   $
 Auto 5�   5    .   5�   5     $! Client.Properties.Resources��$ QuotaNo�� 5�   5   �� *	QuotaNo+5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $! Client.Properties.Resources��$ QuotaQuantity�� 5�   %   �� *QuotaQuantity+# Z 5�   #     5�   "   $
 Auto 5�   5    .   5�   5     $! Client.Properties.Resources��$ 	PricedQty�� 5�   5   �� *PricingQuantity+# Z 5�   #     5�   "   $
 Auto 5�   j    .   6%     $! Client.Properties.Resources��$ 
PaidAmount�� 5�   %   �� *
PaymentStr+5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ InitPricingMargin�� 5�   %   �� *
InitMargin+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ OppoCalledMargin�� 5�   %   �� *TheirAppendMargin+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ OurReturnedMargin�� 5�   %   �� *OurReturnMargin+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� 5�   %   �� *	LastPrice+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ StopLossPrice�� 5�   %   �� *	ExitPrice+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ OppoMarginToAdd�� 5�   %   �� *TheirNeedToAppendMargin+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ OurMarginToReturn�� 5�   %   �� *OurNeedToReturnMargin+# Z 5�   #   5�      5�      5�      �� 5�      -   5        $��tabItem3��5�   :   ��6     *SalesOurPricing+.��5�      � .+�5�        -	   5        $��sOurGrid��5�   H    .  $
��Auto��5�   ?   $
��Left=�6M   $	��Top=�5�   #   $
��Auto��6;   	 . $��6,6,0,0q�5�   #   ��5�   #   �� *SOurs+
 5�        5�   "   $
 Auto 5�   5    .   5�   5     $! Client.Properties.Resources��$ BP�� 5�   5   �� *BPName+5�   #     5�   "   $
 Auto 5�   5    .   5�   5     $! Client.Properties.Resources��$ QuotaNo�� 5�   5   �� *	QuotaNo+5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $! Client.Properties.Resources��$ QuotaQuantity�� 5�   %   �� *QuotaQuantity+# Z 5�   #     5�   "   $
 Auto 5�   5    .   5�   5     $! Client.Properties.Resources��$ 	PricedQty�� 5�   5   �� *PricingQuantity+# Z 5�   #     5�   "   $
 Auto 5�   j    .   6%     $# Client.View.Reports.ResReport��$ Received�� 5�   %   �� *
PaymentStr+5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ InitPricingMargin�� 5�   %   �� *
InitMargin+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ OurAdditionalMargin�� 5�   %   �� *OurAppendMargin+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ OppositeReturnedMargin�� 5�   %   �� *TheirReturnMargin+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� 5�   %   �� *	LastPrice+# Z 5�   #     5�   "   $
 Auto 5�   %    .   5�   %     $# Client.View.Reports.ResReport��$ StopLossPrice�� 5�   %   �� *	ExitPrice+# Z 5�   #     5�   "   $
 Auto 5  %    .   5   %     $# Client.View.Reports.ResReport��$ OurMarginToAdd�� 5  %   �� *OurNeedToAppendMargin+# Z 5  #     5  "   $
 Auto 5  %    .   5  %     $# Client.View.Reports.ResReport��$ OppositeMarginToReturn�� 5  %   �� *TheirNeedToReturnMargin+# Z 5  #   5     5     5     �� 5     -
   5        $��tabItem4��5  ;   ��6     *SalesOppoPricing+.��5     � .+�5       -   5        $��
sTheirGrid��5  H    .  $
��Auto��5  ?   $
��Left=�6M   $	��Top=�5  #   $
��Auto��6;   	 . $��6,6,0,0q�5  #   $��2��5  C   ��6#   �� *	STheirs+
 5       5  "   $
 Auto 5  5    .   5  5     $! Client.Properties.Resources��$ BP�� 5  5   �� *BPName+5   #     5!  "   $
 Auto 5"  5    .   5!  5     $! Client.Properties.Resources��$ QuotaNo�� 5#  5   �� *	QuotaNo+5$  #     5%  "   $
 Auto 5'  %    .   5&  %     $! Client.Properties.Resources��$ QuotaQuantity�� 5(  %   �� *QuotaQuantity+# Z 5)  #     5*  "   $
 Auto 5+  5    .   5*  5     $! Client.Properties.Resources��$ 	PricedQty�� 5,  5   �� *PricingQuantity+# Z 5-  #     5.  "   $
 Auto 5/  j    .   6%     $# Client.View.Reports.ResReport��$ Received�� 51  %   �� *
PaymentStr+52  #     53  "   $
 Auto 55  %    .   54  %     $# Client.View.Reports.ResReport��$ InitPricingMargin�� 56  %   �� *
InitMargin+# Z 57  #     58  "   $
 Auto 5:  %    .   59  %     $# Client.View.Reports.ResReport��$ OppoCalledMargin�� 5;  %   �� *TheirAppendMargin+# Z 5<  #     5=  "   $
 Auto 5?  %    .   5>  %     $# Client.View.Reports.ResReport��$ OurReturnedMargin�� 5@  %   �� *OurReturnMargin+# Z 5A  #     5B  "   $
 Auto 5D  %    .   5C  %     $# Client.View.Reports.ResReport��$ LatestPriceWithPremium�� 5E  %   �� *	LastPrice+# Z 5F  #     5G  "   $
 Auto 5I  %    .   5H  %     $# Client.View.Reports.ResReport��$ StopLossPrice�� 5J  %   �� *	ExitPrice+# Z 5K  #     5L  "   $
 Auto 5N  %    .   5M  %     $# Client.View.Reports.ResReport��$ OppoMarginToAdd�� 5O  %   �� *TheirNeedToAppendMargin+# Z 5P  #     5Q  "   $
 Auto 5S  %    .   5R  %     $# Client.View.Reports.ResReport��$ OurMarginToReturn�� 5T  %   �� *OurNeedToReturnMargin+# Z 5U  #   5`     5a     5b     5c     �� 5d     -   5        $��	groupBox1��5e  D   $	��100��5d  \   $
��Left=�5e     $��6,40,0,0q�62   $	��Top=�5f     $	��800��6/   ��5d       $! Client.Properties.Resources��$ 
Conditions��.��5g     � .+�5h     �� -   5        $��label1��5j  .   #��[  5i     $
��Left=�6@   $��1,10,0,0q�5j     $	��Top=�6<   
���<����5h       $! Client.Properties.Resources��$ 	Commodity��5j  T   �� 5k     -   5        $��	comboBox1��5k  N   $
��Left=�6   $��
107,12,0,0q�6:   $	��Top=�6_    �� DisplayMemberPath$
 Name��5l  C    �� SelectedValuePath$ Id��6\   ��6   �� *Commodities+ �� SelectedValue 5m     �� *SelectedCommodityId+�� 5n     -   5        $��label3��5p  .   #��[  5o     $
��Left=�6@   $��1,42,0,0q�5p     $	��Top=�6<   ��5n       $! Client.Properties.Resources��$ 	StartDate��5p  <     5q     -   5        $��datePicker1��5q  P   $
��Left=�6!   $��
107,44,0,0q�6<   $	��Top=�5r  !      SelectedDate 69   �� *	StartDate+�� 5s     -   5        $��label4��5u  0   #��[  5t     $
��Left=�6@   $��
260,42,0,0q�5u     $	��Top=�6>   ��5s       $! Client.Properties.Resources��$ EndDate��5u  >     5v     -   5        $��datePicker2��5v  P   $
��Left=�6!   $��
366,44,0,0q�6<   $	��Top=�5w  !    69   �� *	EndDate+�� 5x     -   5        $��label5��5z  0   #��[  5y     $
��Left=�6@   $��
260,10,0,0q�5z     $	��Top=�6>   
���<����5x       $! Client.Properties.Resources��$ InternalCustomer��5z  V   �� 5{     -   5        $��	comboBox3��5{  Z   $��23��6   $
��Left=�6+   $��
366,12,0,0q�6F   $	��Top=�5|     $	��120��67   $ 	ShortName��5}     $ Id��5~     ��5|  C   �� *InternalCustomers+ 5~  6   �� *SelectedInternalCustomerId+&
    Utility.Controls.CurrencyTextBox
  5     -   5        $��currencyTextBox2��5�  )   $��23��5  )   $
��Left=�65   $��
625,12,0,0q�6P   $	��Top=�5�  ^   $	��120��5�  )    
  Text 5�  A   �� *MarginRatio+5�  )   �� 5�     -   5        $��label2��5�  0   $
��Left=�5�  9   #��[  6T   $��
519,10,0,0q�5�     $	��Top=�6>   
���<����5�       *MarginRatio+5�  V   �� 5�     -   5        $��label6��5�  c   $��%��6   $��28��6(   $
��Left=�64   $��
749,12,0,0q�6O   $	��Top=�5�     $��20��64   �� 5�     -   5        $��button1��5�  L   $��23��5�  ^   $
��Left=�5�     $��
625,44,0,0q�68   $	��Top=�5�     $��75��65   ��5�       $! Client.Properties.Resources��$ Query��5�  @   5�     5�     5�     5�     5�     