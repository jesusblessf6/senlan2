   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5    /Client.View.Physical.Pricings.ManualPricingList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ManualPricingList+ � 	Resources -   'Client.Converters.PricingBasisConverter   pbconverter.   (Client.Converters.PricingStatusConverter  psconverter,   &Client.Converters.BoolReverseConverter  boolReverse  PricingEdit  PricingDelete  UnpricingEdit  UnpricingDelete  PricingPrint��%x   &	        &	      &	 
     &	      &	      &	      &	      &	 #           �� �� �� �� ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��6,6,0,0q�$��16(�$
��Bold"�$��32��$	��Top=�$
��Left=�$
��auto����  *ManualPricingList+$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��6,40,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -	   $��	dataGrid1��   AutoGenerateColumns .     
IsReadOnly . $
��Auto��$
��Left=�$��6,77,0,0q�$	��Top=�$
��Auto��   AlternatingRowBackground
 ��������� *Quotas+	   Columns	 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn
 
  CanUserSort
 .  
  Header      ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	QuotaNo+	  
 .    $! Client.Properties.Resources��$ QuotaQuantity�� �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 	  
 .    $! Client.Properties.Resources��$ 	PricedQty�� �� *PricedQuantity+# Z 	  
 .    $. (Client.View.Physical.Pricings.ResPricing��$ PricingStatus�� �� *PricingStatus+ �� 	Converter# [    RowDetailsTemplate ��  �� DataType$ DBEntity:Quota��.R��� .+�� 
������� � RowDefinitions �� $
��Auto ��� .+��� $
��Left=�$��26��$��8,8,0,0q�$	��Top=�$��61����  $. (Client.View.Physical.Pricings.ResPricing��$ PricedDetail��  -
    .   . $
��Auto��$
��Auto��$
��Left=�$	��Top=�$��9,38,0,0q����� *
Pricings+	 	  
 .  
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    $! Client.Properties.Resources��$ PricingDate�� �� *PricingDate+$ {0:yyyy-MM-dd}��	  
 . $
 Auto    $. (Client.View.Physical.Pricings.ResPricing��$ 
PricingQty�� �� *PricingQuantity+$ N��	  
 . $
 Auto    $! Client.Properties.Resources��$ Price�� �� *
FinalPrice+$ N��	  
 . $
 Auto    $! Client.Properties.Resources��$ Currency�� �� *Currency.Name+	  
 . $
 Auto    $! Client.Properties.Resources��$ PricingReference�� �� *PricingBasis+# [  4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto    $! Client.Properties.Resources��$ 	Operation��   CellTemplate �� $ DBEntity:Pricing��.R���  �� Orientation$ 
Horizontal=�.+��� #��[ {���  �� Path$ IsAutoGenerated�# [ ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� #��[ {��� $ IsAutoGenerated�# [ ��  $! Client.Properties.Resources��$ Delete������ *Id+�� #��[ {��� $ IsAutoGenerated�# [ ��  $! Client.Properties.Resources��$ Print������ *Id+�� $
��Left=�$��8,8,0,0q�$��1��$	��Top=���  $. (Client.View.Physical.Pricings.ResPricing��$ UnpricedDetail��  -    .   . $
��Auto��$
��Auto��$
��Left=�$��9,37.836,0,6q�$��1��$	��Top=����� *
Unpricings+	 	  $
 Auto 
 .    $! Client.Properties.Resources��$ UnpricingQuantity�� �� *UnpricingQuantity+$ N��	  $
 Auto 
 .    $. (Client.View.Physical.Pricings.ResPricing��$ DeferFee�� �� *
DeferFee+$ N��	  $
 Auto 
 .    $! Client.Properties.Resources��$ PricingStartDate�� �� *StartPricingDate+$ {0:yyyy-MM-dd}��	  $
 Auto 
 .    $! Client.Properties.Resources��$ PricingEndDate�� �� *EndPricingDate+$ {0:yyyy-MM-dd}��  $
 Auto    $! Client.Properties.Resources��$ 	Operation�� �� $ DBEntity:Unpricing��.R��� $ 
Horizontal=�.+��� #��[ {��� $ IsAutoGenerated�# [ ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� #��[ {��� $ IsAutoGenerated�# [ ��  $! Client.Properties.Resources��$ Delete������ *Id+