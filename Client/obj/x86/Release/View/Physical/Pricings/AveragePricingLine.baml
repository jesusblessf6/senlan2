   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 6    0Client.View.Physical.Pricings.AveragePricingLine   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��$	��500��$	��600�� � WindowStartupLocation$ CenterScreen=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title   *AveragePricingDetail+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker-   'Client.Converters.PricingBasisConverter  PricingBasisConverter��%�   &	        '  �     &	 �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� "  .���  � ��$ 23����  � ��$	 120��  .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *AveragePricingDetail+�� -   $��labRateName��#��[  $
��Left=�$��6,70,0,0q�$	��Top=�
���<����     ResxName$! Client.Properties.Resources��
	   Key$	 ExchangeRate��&   Utility.Controls.CurrencyTextBox  -   $��txtRate��$��23��$
��Left=�$��
122,72,0,0q�$	��Top=�$	��120��
   Text
 �� *ERate+  -   $��datePicker1��$
��Left=�$��
394,72,0,0q�$	��Top=�   SelectedDate �� *PricingDate+  -   $��currencyTextBox2��$��23��$
��Left=�$��
394,40,0,0q�$	��Top=�$	��120��
 �� *
FinalPrice+�� -   $
��btOK��$��23��$
��Left=�$��245,102,0,0q�$	��Top=�$��80��$��Center=���  *ConfirmPriced+$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��122,128,0,0q�$	��Top=�$	��340���� -	   $��label1��#��[  $
��Left=�$��6,38,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 Premium���� -
   $��label2��#��[  $
��Left=�$��
278,38,0,0q�$	��Top=���  *
FinalPrice+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��122,162,0,0q�$	��Top=�$
��Auto��   
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $! Client.Properties.Resources��$
	 Date��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *	StartDate+     $! Client.Properties.Resources��$	 Price�� �� *	Pricing+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z      $! Client.Properties.Resources��$	 Currency�� �� *
Currency+     $! Client.Properties.Resources��$	 PricingReference�� �� *PricingBasisId+ �� 	Converter# [   -   $��currencyTextBox1��$��23��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120�� �� 
IsReadOnly . 
 �� *	Premium+�� -   $��label5��#��[  $
��Left=�$��
278,70,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$	 PricingDate��