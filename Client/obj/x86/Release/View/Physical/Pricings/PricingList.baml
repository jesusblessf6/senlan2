   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity /    )Client.View.Physical.Pricings.PricingList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��$	��301��$	��289�� � 
ResizeMode$ NoResize=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title   *PricingList+.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $
��auto ��� $	��20* �.+��� -   $��lbTitle��$��6,6,0,0q�$��16(�$
��Bold"�$��32��$	��Top=�$
��Left=�$
��auto����  *PricingList+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .     
IsReadOnly . $
��Auto��$
��Left=�$��6,40,0,0q�$	��Top=�$
��Auto������ *
Pricings+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 	   CanUserSort	 . 
   Header
      ResxName$! Client.Properties.Resources��
   Key$ PricingDate��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *PricingDate+ �� StringFormat$ {0:yyyy-MM-dd}��  $
 Auto 	 . 
   $! Client.Properties.Resources��$ Price�� �� *
FinalPrice+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE# Z   $
 Auto 	 . 
   $. (Client.View.Physical.Pricings.ResPricing��$ 
PricingQty�� �� *PricingQuantity+   STR_QUANTITY# Z �� -   $��lblAVGPricing��$��28��$
��Left=�$��66,8,0,0q�$	��Top=�$��92��$��1������ *
AVGPricing+�� -   $��label1��$��28��$
��Left=�$��6,8,0,0q�$	��Top=�$��1����  *AveragePrice+