   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   %   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      5    /Client.View.Physical.Pricings.ManualPricingList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      >my/clr-namespace:Utility.Controls;assembly=Utility     5   %   ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *ManualPricingList+ � 	Resources 5      -   'Client.Converters.PricingBasisConverter   pbconverter.   (Client.Converters.PricingStatusConverter  psconverter,   &Client.Converters.BoolReverseConverter  boolReverse  PricingEdit  PricingDelete  UnpricingEdit  UnpricingDelete  PricingPrint��%�   &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �       5   
   68     5   
   69     5   
   67   �� 5   
   6.   �� 5   
   60   �� 5   
   60   �� 5   
   62   �� 5   
   6/   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6�     5   
   -   5        # [ 5      6�     5   
   -   5        # [ 5      6�     5   
   -   5        # [ 5      6�     5    
   -   5        # [ 5       6�   .��5#      �� $
��Auto=�6   $
��Auto=�68   .��5$   
   � -   5        $��rootGrid��5$      .+�5%      �� -   5        $��lbTitle��5%   7   $��6,6,0,0q�6F   $��16(�6W   $
��Bold"�6e   $��32��6w   $	��Top=�6�   $
��Left=�6�   $
��auto��6�   ��6     *ManualPricingList+6�   $  Utility.Controls.PagingControl  5&      -   5        $��pagingControl1��5&   L   $
��Left=�6   $��6,40,0,0q�6:   $	��Top=�6b   &   System.Windows.Controls.DataGrid  5'      -	   5        $��	dataGrid1��5'   �      AutoGenerateColumns .     
IsReadOnly . $
��Auto��6E   $
��Left=�6S   $��6,77,0,0q�6n   $	��Top=�6�   $
��Auto��6�      AlternatingRowBackground
 �������6�   �� *Quotas+	   Columns	 5(      0	  *System.Windows.Controls.DataGridTextColumn	  5)      ,
  &System.Windows.Controls.DataGridColumn
 
  CanUserSort
 .  
  Header 6)        ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6k   �� *	QuotaNo+6�   	  5*      
 .  6)     $! Client.Properties.Resources��$ QuotaQuantity�� 6q   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�   	  5+      
 .  6)     $! Client.Properties.Resources��$ 	PricedQty�� 6m   �� *PricedQuantity+# Z 6�   	  5,      
 .  6)     $. (Client.View.Physical.Pricings.ResPricing��$ PricingStatus�� 6~   �� *PricingStatus+ �� 	Converter# [ 6�      RowDetailsTemplate 5.      �� 5/       �� DataType$ DBEntity:Quota��6#   .R�50      �� .+�51      � 
������� � RowDefinitions 52   "   �� 53   &   $
��Auto �64   6D   �� 54   &   .+�56   "   �� $
��Left=�6|   $��26��6�   $��8,8,0,0q�6�   $	��Top=�6�   $��61��6�   ��6(     $. (Client.View.Physical.Pricings.ResPricing��$ PricedDetail��6�     57   "   -
   5         .   . $
��Auto��57   z   $
��Auto��6�   $
��Left=�58   %   $	��Top=�6@   $��9,38,0,0q�6X   ��57   G   �� *
Pricings+	 59   &   	  5:   *   
 .  
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�    6=     $! Client.Properties.Resources��$ PricingDate�� 6�   �� *PricingDate+$ {0:yyyy-MM-dd}��6�   	  5;   *   
 . $
 Auto 6�    6=     $. (Client.View.Physical.Pricings.ResPricing��$ 
PricingQty�� 6�   �� *PricingQuantity+$ N��6�   	  5<   *   
 . $
 Auto 6�    6=     $! Client.Properties.Resources��$ Price�� 6}   �� *
FinalPrice+$ N��6�   	  5=   *   
 . $
 Auto 6�    6=     $! Client.Properties.Resources��$ Currency�� 6�   �� *Currency.Name+6�   	  5>   *   
 . $
 Auto 6�    6=     $! Client.Properties.Resources��$ PricingReference�� 6�   �� *PricingBasis+# [  6�   4  .System.Windows.Controls.DataGridTemplateColumn  5?   *   $
 Auto 6�    6A     $! Client.Properties.Resources��$ 	Operation��   CellTemplate 5@   .   �� 5A   2   $ DBEntity:Pricing��6?   .R�5B   6   ��  �� Orientation$ 
Horizontal=�6A   .+�5C   :   �� #��[ 6�   {�6A   ��  �� Path$ IsAutoGenerated�# [ ��6�     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6  �� 5D   :   #��[ 6�   {�6A   �� $ IsAutoGenerated�# [ ��6�     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6!  �� 5E   :   #��[ 6�   {�6A   �� $ IsAutoGenerated�# [ ��6�     $! Client.Properties.Resources��$ Print����6�   �� *Id+6  5F   7   5G   3   5I   +   5K   #   �� 5L   "   $
��Left=�6   $��8,8,0,0q�6�   $��1��6�   $	��Top=�6�   ��6(     $. (Client.View.Physical.Pricings.ResPricing��$ UnpricedDetail��6�     5M   "   -   5         .   . $
��Auto��5M   |   $
��Auto��5N      $
��Left=�6,   $��9,37.836,0,6q�6G   $��1��6]   $	��Top=�6j   ��5M   G   �� *
Unpricings+	 5O   &   	  5P   *   $
 Auto 6�   
 .  6=     $! Client.Properties.Resources��$ UnpricingQuantity�� 6�   �� *UnpricingQuantity+$ N��6�   	  5Q   *   $
 Auto 6�   
 .  6=     $. (Client.View.Physical.Pricings.ResPricing��$ DeferFee�� 6�   �� *
DeferFee+$ N��6�   	  5R   *   $
 Auto 6�   
 .  6=     $! Client.Properties.Resources��$ PricingStartDate�� 6�   �� *StartPricingDate+$ {0:yyyy-MM-dd}��6�   	  5S   *   $
 Auto 6�   
 .  6=     $! Client.Properties.Resources��$ PricingEndDate�� 6�   �� *EndPricingDate+$ {0:yyyy-MM-dd}��6�     5T   *   $
 Auto 6�    6A     $! Client.Properties.Resources��$ 	Operation�� 5U   .   �� 5V   2   $ DBEntity:Unpricing��6?   .R�5W   6   �� $ 
Horizontal=�6A   .+�5X   :   �� #��[ 6�   {�6A   �� $ IsAutoGenerated�# [ ��6�     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6  �� 5Y   :   #��[ 6�   {�6A   �� $ IsAutoGenerated�# [ ��6�     $! Client.Properties.Resources��$ Delete����6  �� *Id+6#  5Z   7   5[   3   5]   +   5_   #   5`      5a      5b      5d      5e      5f      5h      