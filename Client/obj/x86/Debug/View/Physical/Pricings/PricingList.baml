   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5   	   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5   	   /    )Client.View.Physical.Pricings.PricingList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;
baseClient$clr-namespace:Client.Base.BaseClient     5   	   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5   	   0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��5   	   $	��301��5   $   $	��289��61    � 
ResizeMode$ NoResize=�6=    � Language 5   	   5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5   	     *PricingList+.��5	      �� $
��Auto=�6   $
��Auto=�68   .��5
   
   � -   5        $��rootGrid��5
       � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $	��20* �6    .+�5      �� -   5        $��lbTitle��5   1   $��6,6,0,0q�6@   $��16(�6Q   $
��Bold"�6_   $��32��6q   $	��Top=�6}   $
��Left=�6�   $
��auto��6�   ��6     *PricingList+6�   &   System.Windows.Controls.DataGrid  5      -   5        $��	dataGrid1��5   �      AutoGenerateColumns .     
IsReadOnly . $
��Auto��6E   $
��Left=�6S   $��6,40,0,0q�6�   $	��Top=�6�   $
��Auto��6�   ��6n   �� *
Pricings+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6o   	   CanUserSort	 . 
   Header
 6)        ResxName$! Client.Properties.Resources��
   Key$ PricingDate��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *PricingDate+ �� StringFormat$ {0:yyyy-MM-dd}��6�     5      $
 Auto 6i   	 . 
 6)     $! Client.Properties.Resources��$ Price�� 6�   �� *
FinalPrice+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE# Z 6�     5      $
 Auto 6{   	 . 
 6)     $. (Client.View.Physical.Pricings.ResPricing��$ 
PricingQty�� 6�   �� *PricingQuantity+   STR_QUANTITY# Z 6�   5      �� 5      -   5        $��lblAVGPricing��5   l   $��28��63   $
��Left=�6?   $��66,8,0,0q�6Z   $	��Top=�6�   $��92��6�   $��1��6�   ��6   �� *
AVGPricing+6�   �� 5      -   5        $��label1��5   j   $��28��62   $
��Left=�6>   $��6,8,0,0q�6Y   $	��Top=�6x   $��1��6�   ��6     *AveragePrice+6�   5      5      5      