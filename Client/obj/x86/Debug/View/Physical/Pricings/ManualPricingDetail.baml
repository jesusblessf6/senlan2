   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5
      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      7   1Client.View.Physical.Pricings.ManualPricingDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��5      $	��512��5   0   $	��600��6=    � 
ResizeMode$ NoResize=�5   ?    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5	           ResxName$! Client.Properties.Resources��
   Key$ ManualPricing�� � 	Resources 5       �� 
TargetType �� Property	 �� Value(  "System.Windows.Controls.DatePicker��%0  '��       '�� �     '��     '  �    �� 5   
   " ��6   .�5      ��  � ��$	 28��6'   64   �� 5       � ��$		 110��6&   64   �� 5       � ��$	 Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$	 23��6'   64   �� 5       � ��$		 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$	 23��6'   64   �� 5       � ��$		 120��6&   64   5      �� 5   
   "  6   .�5       ��  � ��$	 23��6'   64   �� 5!       � ��$		 120��6&   64   5"      5#      .��5%      �� $
��Auto=�6   $
��Auto=�68   .��5&   
   � -   5        $��rootGrid��5&      .+�5'      �� -   5        $��lbTitle��5'   ]   $��32��6l   $
��Left=�6x   $��6,6,0,0q�6�   $
��auto��6�   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     $! Client.Properties.Resources��$ ManualPricing��6�   �� 5(      -   5        $��label2��5(   �   $
��Left=�6W   $��6,38,0,0q�6r   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ QuotaNo��6�   �� 5)      -   5        $��textBox1��5)   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   {�.  ��5*      �� 
 �� Path$
 QuotaNo��� 5+      -   5        $��button1��5+   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,40,0,0q�6J   $	��Top=�6m   $��25��6�   6�   �� 5,      -   5        $��label3��5,   b   $
��Left=�63   $��
278,38,0,0q�6N   $	��Top=�6p   ��6     *PricingStatus+6p   �� 5-      -   5        $��textBox2��5-   E   $
��Left=�6   $��
394,40,0,0q�61   $	��Top=�6U    �� 
IsReadOnly . ��5.      �� $
 PricingStatus��� 5/      -   5        $��label4��5/   �   $
��Left=�6]   $��6,70,0,0q�6x   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ QuotaQuantity��6�   &    Utility.Controls.CurrencyTextBox  50      -	   5        $��currencyTextBox1��50   \   $��23��6!   $
��Left=�6-   $��
122,72,0,0q�6H   $	��Top=�6t   $	��120��6�   {�.     Text 6�   �� $
 QuotaQuantity�$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�   �� 51      -
   5        $��label5��51   �   $��28��6Y   $
��Left=�6e   $��
278,70,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ 	PricedQty��6�     52      -   5        $��txPricedQuantity��52   !   $
��Left=�69   $��
394,72,0,0q�6T   $	��Top=�6�   $	��120��6�   $��23��6�   {�.   6h   �� *PricedQuantity+# Z 6�   �� 53      -   5        $��label6��53   ^   $
��Left=�60   $��	6,102,0,0q�6K   $	��Top=�6l   
���<����6     *
PricingQty+6�     54      -   5        $��txPricingQuantity��54   C   $��122,104,0,0q�6!   $��23��66   $	��Top=�6�   $
��Left=�6�   $	��120��6�    6\   �� *PricingQuantity+# Z 6�   �� 55      -   5        $��label7��55   �   $
��Left=�6[   $��278,102,0,0q�6v   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ PricingDate��6�     56      -   5        $��datePicker1��56   U   $��23��6   $
��Left=�6%   $��394,104,0,0q�6@   $	��Top=�6h      SelectedDate 6�   �� $
 PricingDate��� 57      -   5        $��label8��57   �   $
��Left=�6`   $��	6,134,0,0q�6{   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ PricingReference��6�   �� 58      -   5        $��	comboBox1��58   G   $
��Left=�6   $��122,136,0,0q�62   $	��Top=�6X    �� SelectedValuePath$ Id��6�    �� DisplayMemberPath$
 Name��6�   ��6p   �� *PricingBasises+ �� SelectedValue 6�   �� *PricingBasisId+�� 59      -   5        $��label9��59   e   $
��Left=�64   $��278,134,0,0q�6O   $	��Top=�6s   
���<����6     *ReferencePrice+6�     5:      -   5        $��currencyTextBox2��5:   ]   $��23��6!   $
��Left=�6-   $��394,136,0,0q�6H   $	��Top=�6u   $	��120��6�    6�   �� $
 
BasicPrice�   	STR_PRICE# Z �� 5;      -   5        $��label10��5;   `   $
��Left=�62   $��	6,166,0,0q�6M   $	��Top=�6o   ��6     *SwitchingFee+6o     5<      -   5        $��currencyTextBox3��5<   ]   $��23��6!   $
��Left=�6-   $��122,168,0,0q�6H   $	��Top=�6u   $	��120��6�    6�   �� $
 AdjustQpFee�# Z �� 5=      -   5        $��label11��5=   ^   $
��Left=�6.   $��278,166,0,0q�6I   $	��Top=�6m   ��6     *
DeferFee+6m     5>      -   5        $��currencyTextBox4��5>   ]   $��23��6!   $
��Left=�6-   $��394,168,0,0q�6H   $	��Top=�6u   $	��120��6�    6�   �� $
 DeferFee�# Z �� 5?      -   5        $��label12��5?   �   $
��Left=�6W   $��	6,198,0,0q�6r   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Premium��6�     5@      -   5        $��currencyTextBox5��5@   ]   $��23��6!   $
��Left=�6-   $��122,200,0,0q�6H   $	��Top=�6u   $	��120��6�    6�   �� $
 Premium�# Z �� 5A      -   5        $��label13��5A   `   $
��Left=�60   $��278,198,0,0q�6K   $	��Top=�6o   
���<����6     *
FinalPrice+6�     5B      -   5        $��currencyTextBox6��5B   ]   $��23��6!   $
��Left=�6-   $��394,200,0,0q�6H   $	��Top=�6u   $	��120��6�    6�   �� $
 
FinalPrice�# Z �� 5C      -   5        $��label14��5C   �   $
��Left=�6_   $��	6,230,0,0q�6z   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ PricingCurrency��6�   �� 5D      -   5        $��cbPricingCurrency��5D   G   $
��Left=�6   $��122,232,0,0q�62   $	��Top=�6`   $
 Name��6�   $ Id��6�    �� 
IsReadOnly . {�.  ��6x   �� *
Currencies+ 6�   �� *SelectedCurrencyId+6
  �� 5E      -   5        $��label15��5E   �   $��28��6\   $
��Left=�6h   $��278,230,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ ExchangeRate��6�     5F      -   5        $��currencyTextBox7��5F   ]   $��23��6!   $
��Left=�6-   $��394,232,0,0q�6H   $	��Top=�6u   $	��120��6�    6�   �� $

 Rate�   STR_RATE# Z �� 5G      -    5        $��label16��5G   �   $
��Left=�6X   $��	6,294,0,0q�6s   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Comments��6�   �� 5H      -!   5        $��	textBox12��5H   S   $	��100��6   $
��Left=�6#   $��122,296,0,0q�6>   $	��Top=�6d   $	��392��6|    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6�   �� $
 
Descripion��� 5I      -"   5        $��button2��5I   �   $��23��6X   $
��Left=�6d   $��210,420,0,0q�6   $	��Top=�6�   $��60��6�   ��6     $! Client.Properties.Resources��$ Confirm��6�   �� 5J      -#   5        $��button3��5J   �   $��23��6W   $
��Left=�6c   $��305,420,0,0q�6~   $	��Top=�6�   $��60��6�   ��6     $! Client.Properties.Resources��$ Cancel��6�   �� 5K      -$   5        $��label1��5K   Q   $��价格日期��6   $
��Left=�6#   $��	6,262,0,0q�6>   $	��Top=�6_     5L      -%   5        $��datePicker2��5L   U   $��23��6   $
��Left=�6%   $��122,264,0,0q�6@   $	��Top=�6h    6�   �� $
 	PriceDate��� 5M      -&   5        $��	checkBox1��5M   d   $��批次点价完成��6   $��16��6(   $
��Left=�64   $��394,268,0,0q�6O   $	��Top=�6u    d� 	IsChecked 6�   �� *IsPricingComplete+5N      5O      5P      