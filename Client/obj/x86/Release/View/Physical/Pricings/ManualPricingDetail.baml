   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 7   1Client.View.Physical.Pricings.ManualPricingDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��$	��512��$	��600�� � 
ResizeMode$ NoResize=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title      ResxName$! Client.Properties.Resources��
   Key$ ManualPricing�� � 	Resources  �� 
TargetType �� Property	 �� Value(  "System.Windows.Controls.DatePicker��%)  '��       '�� S     '�� �     '  �     �� " ��.���  � ��$	 28����  � ��$		 110����  � ��$	 Right=��� " ��.���  � ��$	 23����  � ��$		 120���� " ��.���  � ��$	 23����  � ��$		 120���� "  .���  � ��$	 23����  � ��$		 120��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  $! Client.Properties.Resources��$ ManualPricing���� -   $��label2��$
��Left=�$��6,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ QuotaNo���� -   $��textBox1��$
��Left=�$��
122,40,0,0q�$	��Top=�{�.  ���� 
 �� Path$
 QuotaNo��� -   $��button1��$	��...��$��23��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25���� -   $��label3��$
��Left=�$��
278,38,0,0q�$	��Top=���  *PricingStatus+�� -   $��textBox2��$
��Left=�$��
394,40,0,0q�$	��Top=� �� 
IsReadOnly . ���� $
 PricingStatus��� -   $��label4��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ QuotaQuantity��&    Utility.Controls.CurrencyTextBox  -	   $��currencyTextBox1��$��23��$
��Left=�$��
122,72,0,0q�$	��Top=�$	��120��{�.     Text �� $
 QuotaQuantity�$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z �� -
   $��label5��$��28��$
��Left=�$��
278,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	PricedQty��  -   $��txPricedQuantity��$
��Left=�$��
394,72,0,0q�$	��Top=�$	��120��$��23��{�.   �� *PricedQuantity+# Z �� -   $��label6��$
��Left=�$��	6,102,0,0q�$	��Top=�
���<����  *
PricingQty+  -   $��txPricingQuantity��$��122,104,0,0q�$��23��$	��Top=�$
��Left=�$	��120�� �� *PricingQuantity+# Z �� -   $��label7��$
��Left=�$��278,102,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ PricingDate��  -   $��datePicker1��$��23��$
��Left=�$��394,104,0,0q�$	��Top=�   SelectedDate �� $
 PricingDate��� -   $��label8��$
��Left=�$��	6,134,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ PricingReference���� -   $��	comboBox1��$
��Left=�$��122,136,0,0q�$	��Top=� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *PricingBasises+ �� SelectedValue �� *PricingBasisId+�� -   $��label9��$
��Left=�$��278,134,0,0q�$	��Top=�
���<����  *ReferencePrice+  -   $��currencyTextBox2��$��23��$
��Left=�$��394,136,0,0q�$	��Top=�$	��120�� �� $
 
BasicPrice�   	STR_PRICE# Z �� -   $��label10��$
��Left=�$��	6,166,0,0q�$	��Top=���  *SwitchingFee+  -   $��currencyTextBox3��$��23��$
��Left=�$��122,168,0,0q�$	��Top=�$	��120�� �� $
 AdjustQpFee�# Z �� -   $��label11��$
��Left=�$��278,166,0,0q�$	��Top=���  *
DeferFee+  -   $��currencyTextBox4��$��23��$
��Left=�$��394,168,0,0q�$	��Top=�$	��120�� �� $
 DeferFee�# Z �� -   $��label12��$
��Left=�$��	6,198,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Premium��  -   $��currencyTextBox5��$��23��$
��Left=�$��122,200,0,0q�$	��Top=�$	��120�� �� $
 Premium�# Z �� -   $��label13��$
��Left=�$��278,198,0,0q�$	��Top=�
���<����  *
FinalPrice+  -   $��currencyTextBox6��$��23��$
��Left=�$��394,200,0,0q�$	��Top=�$	��120�� �� $
 
FinalPrice�# Z �� -   $��label14��$
��Left=�$��	6,230,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PricingCurrency���� -   $��cbPricingCurrency��$
��Left=�$��122,232,0,0q�$	��Top=�$
 Name��$ Id�� �� 
IsReadOnly . {�.  ���� *
Currencies+ �� *SelectedCurrencyId+�� -   $��label15��$��28��$
��Left=�$��278,230,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ExchangeRate��  -   $��currencyTextBox7��$��23��$
��Left=�$��394,232,0,0q�$	��Top=�$	��120�� �� $

 Rate�   STR_RATE# Z �� -    $��label16��$
��Left=�$��	6,294,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -!   $��	textBox12��$	��100��$
��Left=�$��122,296,0,0q�$	��Top=�$	��392�� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� $
 
Descripion��� -"   $��button2��$��23��$
��Left=�$��210,420,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Confirm���� -#   $��button3��$��23��$
��Left=�$��305,420,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Cancel���� -$   $��label1��$��价格日期��$
��Left=�$��	6,262,0,0q�$	��Top=�  -%   $��datePicker2��$��23��$
��Left=�$��122,264,0,0q�$	��Top=� �� $
 	PriceDate��� -&   $��	checkBox1��$��批次点价完成��$��16��$
��Left=�$��394,268,0,0q�$	��Top=� d� 	IsChecked �� *IsPricingComplete+