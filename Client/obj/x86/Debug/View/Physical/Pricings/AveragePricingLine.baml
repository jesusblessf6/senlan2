   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   =   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      6    0Client.View.Physical.Pricings.AveragePricingLine   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   =   ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��5      $	��500��5   o   $	��600��6|    � WindowStartupLocation$ CenterScreen=�5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5   K     *AveragePricingDetail+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker-   'Client.Converters.PricingBasisConverter  PricingBasisConverter��%�  &	        '  �     &	 m    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5   
   6+   5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   :   $��32��6I   $
��Left=�6U   $��6,6,0,0q�6p   $
��auto��5      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5        *AveragePricingDetail+5   K   �� 5      -   5        $��labRateName��5       #��[  5   \   $
��Left=�6�   $��6,70,0,0q�6�   $	��Top=�5    '   
���<����5           ResxName$! Client.Properties.Resources��
	   Key$	 ExchangeRate��5    ?   &   Utility.Controls.CurrencyTextBox  5!      -   5        $��txtRate��5!   !   $��23��60   $
��Left=�6<   $��
122,72,0,0q�6W   $	��Top=�5"   !   $	��120��69   
   Text
 6E   �� *ERate+  5#      -   5        $��datePicker1��5#   H   $
��Left=�6   $��
394,72,0,0q�64   $	��Top=�6[      SelectedDate 5$      �� *PricingDate+  5%      -   5        $��currencyTextBox2��5%   \   $��23��6!   $
��Left=�6-   $��
394,40,0,0q�6H   $	��Top=�5&   !   $	��120��69   
 6E   �� *
FinalPrice+�� 5'      -   5        $
��btOK��5'   p   $��23��64   $
��Left=�6@   $��245,102,0,0q�6[   $	��Top=�5(      $��80��6-   $��Center=�68   ��5'        *ConfirmPriced+5(   \   $  Utility.Controls.PagingControl  5)      -   5        $��pagingControl1��5)   O   $
��Left=�6   $��122,128,0,0q�6:   $	��Top=�5*      $	��340��67   �� 5+      -	   5        $��label1��5,      #��[  5+   W   $
��Left=�6{   $��6,38,0,0q�6�   $	��Top=�5,   "   ��5+        $! Client.Properties.Resources��$	 Premium��5,   "   �� 5-      -
   5        $��label2��5.      #��[  5-   0   $
��Left=�6T   $��
278,38,0,0q�6o   $	��Top=�5.   "   ��5-        *
FinalPrice+5.   "   &   System.Windows.Controls.DataGrid  5/      -   5        $��	dataGrid1��50         AutoGenerateColumns .  $
��Auto��5/   3   $
��Left=�6A   $��122,162,0,0q�6\   $	��Top=�50   (   $
��Auto��6@      
IsReadOnly .    Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$
	 Date��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6h   �� *	StartDate+  53       6)     $! Client.Properties.Resources��$	 Price�� 6i   �� *	Pricing+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z   54       6)     $! Client.Properties.Resources��$	 Currency�� 6l   �� *
Currency+  55       6)     $! Client.Properties.Resources��$	 PricingReference�� 56   )   �� *PricingBasisId+ �� 	Converter# [ 58        59      -   5        $��currencyTextBox1��59   \   $��23��6!   $
��Left=�6-   $��
122,40,0,0q�6H   $	��Top=�5:   !   $	��120��69    �� 
IsReadOnly . 
 6E   �� *	Premium+6^   �� 5;      -   5        $��label5��5<      #��[  5;   [   $
��Left=�6   $��
278,70,0,0q�6�   $	��Top=�5<   "   
���<����5;        $! Client.Properties.Resources��$	 PricingDate��5<   :   5=      5>      5?      