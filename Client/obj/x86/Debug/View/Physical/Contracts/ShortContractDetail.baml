   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5
      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5      8   2Client.View.Physical.Contracts.ShortContractDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5
      6
Convertersclr-namespace:Client.Converters     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract��5      $
��Auto��5   ?   $
��auto��6M    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5	   '     *ShortContract+ � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker.  (Client.Converters.ApproveStatusConverter   ApproveStatusConverter  AttachmentDownLoad  AttachmentDelete  QuotaBrandRelEdit  QuotaBrandRelDelete  RelQuotaEdit  RelQuotaDelete  QuotaBrandRelActions �� DataType �� Orientation	   ResxName

   Key  RelQuotaActions 	 AttachmentActions��%�  '��       '�� �     '��     '  �    &	      &	     &	 .    &	 A    &	 T    &	 g    &	 z    &	 �    7  7  &	     7  7  &		 }    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5       �� 5"   
   "  6   .�5#      ��  � ��$ 23��6'   64   �� 5$       � ��$	 120��6&   64   5%        5'   
   6,   �� 5(   
   65   �� 5)   
   63   �� 5*   
   64   �� 5+   
   66   �� 5,   
   6/   �� 5-   
   61   �� 5/   
   $ DBEntity:QuotaBrandRel��64   .R�50      �� $ 
Horizontal=�6   .+�51      �� $��btQuotaBrandRelEdit��6   8��  ��64     $!	 Client.Properties.Resources��$

 Edit����52      �� *Id+6;   �� 53      $��btQuotaBrandRelDelete��6   8�� ��66     $!	 Client.Properties.Resources��$
 Delete����54      �� *Id+6;   55      56      �� 58   
   .R�59      �� $ 
Horizontal=�6   .+�5:      �� $��btRelQuotaEdit��6   8��  ��6/     $!	 Client.Properties.Resources��$

 Edit����5;      �� *
QuotaStage+6C   �� 5<      $��btRelQuotaDelete��6   8�� ��61     $!	 Client.Properties.Resources��$
 Delete����5=      �� *
QuotaStage+6C   5>      5?      �� 5A   
   $ DBEntity:Attachment��61   .R�5B      �� $ 
Horizontal=�6   .+�5C      �� $��btAttachmentDownLoad��6   8��  ��65     $!	 Client.Properties.Resources��$
 Download����5D      �� *Id+6;   �� 5E      $��btAttachmentDelete��6   8�� ��63     $!	 Client.Properties.Resources��$
 Delete����5F      �� *Id+6;   5G      5H      5I       J� CommandBindings 5K      )  #System.Windows.Input.CommandBinding  5L   
   -   5           Command# [ 5L      5M   A     5N   
   -   5        # [ 5N      5O   ?     5P   
   -   5        # [ 5P      5Q   @     5R   
   -   5        # [ 5R      5S   B     5T   
   -   5        # [ 5T      5U   ;     5V   
   -   5        # [ 5V      5W   =   .��5Z      �� $
��Auto=�6   $
��Auto=�68   .��5[   
   � -   5        $��rootGrid��5[       � RowDefinitions 5\      �� 5]      $
��Auto �6    �� 5^      $	��196 �6    �� 5_      $
��Auto �6    �� 5`      $
��Auto �6    �� 5a      $
��Auto �6    �� 5b      $
��Auto �6    �� 5c      $
��Auto �6    �� 5d      $
��Auto �6    �� 5e      $
��Auto �6    �� 5f      $
��Auto �6    �� 5g      $
��auto �6    �� 5h      $
��135* �6    .+�5k      �� -   5         ��Name$ 
lbSupplier��5l   (   $
��Left=�5k   X   
���<��$��
278,38,0,0q�5l      $	��Top=�6<   ��5k        $!	 Client.Properties.Resources��$
 Supplier��5l   <   �� 5n      -	   5        $��btnSupplier��5n   /   $	��...��6   $��23��6#   $��
518,40,0,0q�5o      $	��Top=�6)   $
��Left=�6A   $��25��6\   {�6g   �� *
IsBPEnable+�� 5p      -
   5        $ 
label3Copy��5p   X   $��6,70,0,0q�6l   $
��Left=�5q      
���<��$	��Top=�6D   ��5p        $!	 Client.Properties.Resources��$
 Quantity��5q   D   &   Utility.Controls.CurrencyTextBox  5r      -   5          Name$ textBox1Copy2��5r   -   $��23��6!   $	��120��6D   $��
122,72,0,0q�6P   $
��Left=�5s   !   $	��Top=�6<      Text 6T   �� *
Quantity+$   DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {�6�   �� *IsQuantityEnable+�� 5t      -   5        $ lbPrice��5u      $
��Left=�5t   U   $��	6,102,0,0q�6p   
���<��$��28��5u   :   $	��Top=�6F   ��5t        $!	 Client.Properties.Resources��$
 Price��5u   F     5v      -   5        $ txtPrice��5v   -   $��23��6!   $	��120��6?   $��122,104,0,0q�6K   $
��Left=�5w   !   $	��Top=�6<    6T   �� *Price+   	STR_PRICE# Z {�6�   �� *IsPriceEnable+�� 5x      $
��Left=�6.   $��6,70,0,0q�6I   
���<��$	��Top=�5y   )   $��1��6A   ��5x        *
SignDate+5y   A     5z      -   5        $��datePicker1��5z   4   $
��Left=�6   $	��Top=�6G   $��
122,70,0,0q�5{   ;   $��1��6v      SelectedDate 6   �� *
SignDate+{�6O   �� *IsSignDateEnable+6v   �� 5|      $
��Left=�6X   $��
278,68,0,0q�6s   
���<��$	��Top=�5}   )   $��1��6A   ��5|        $!	 Client.Properties.Resources��$
 SignSide��5}   A   �� 5~      -   5        $��	comboBox2��5   R    �� DisplayMemberPath$ 	ShortName��5~      $
��Left=�65   $��
394,70,0,0q�5   >    �� SelectedValuePath$ Id��5�   L   $	��Top=�6c   $��1��5�   <   ��5      �� *InnerCustomers+ �� SelectedValue 5�      �� *SelectedInternalCustomerId+{�5�      �� *IsSignBPEnable+6I   �� 5�      -   5        $��lbShipCondition��5�   �   $��7��6X   $
��Left=�6e   $��6,0,0,0q�6�   $��28��6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 ShipTerm��6�   �� 5�      -   5        $��tbShipCondition��5�   ]   $��7��6   $��23��6#   $
��Left=�6/   $��	122,2,0,0q�6J   $	��392��6t   $	��Top=�6�   ��6�   �� *
ShipTerm+6�   �� 5�      $
��Left=�6Y   $��	6,100,0,0q�6t   
���<��$	��Top=�5�   )   $��1��6A   ��5�        $!	 Client.Properties.Resources��$
 	Commodity��5�   A   �� 5�      -   5         ��Name$ cboxCommodity��5�   2   $
��Left=�6   $��122,102,0,0q�6I   $	��Top=�5�      $
 Name��6R   $ Id��6k   $��1��5�   ?   ��5�   /   �� *
Commoditys+ 5�      �� *CommodityId+{�5�      �� *IsCommodityEnable+6?   �� 5�      $
��Left=�6]   $��278,100,0,0q�6x   
���<��$	��Top=�5�   )   $��1��6A   ��5�        $!	 Client.Properties.Resources��$
 CommodityType��5�   A   �� 5�      -   5        $ cboxCommodityType��5�   2   $
��Left=�6   $��394,102,0,0q�6M   $	��Top=�6b   $
 Name��6�   $ Id��5�      $��1��6�   ��5�   z   �� *CommodityTypes+ 5�   .   �� *CommodityTypeId+6�   �� 5�      $
��Left=�6U   $��	6,132,0,0q�6p   $	��Top=�6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 Brand��6�   �� 5�      -   5        $ comboBox1Copy3��5�   2   $
��Left=�6   $��122,134,0,0q�6J   $	��Top=�5�      $
 Name��6N   $ Id��6g   $��1��5�   9   ��5�   /   �� *Brands+ 5�      �� *	BrandId+69   �� 5�      $
��Left=�6]   $��278,132,0,0q�6x   $	��Top=�6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 Specification��6�   �� 5�      -   5        $ comboBox1Copy4��5�      $��394,134,0,0q�6/   $	��Top=�6D   $
 Name��6�   $ Id��5�      $
��Left=�6X   $��1��6s   ��5�   \   �� *Specifications+ 5�   .   �� *SpecificationId+6s   �� 5�      -   5        $��lbPricingType��5�   )   $
��Left=�5�   [   $��6,0,0,0q�6v   
���<��$	��Top=�5�   >   $��3��6V   $��2��6c   ��5�        $!	 Client.Properties.Resources��$
 PricingType��5�   c   �� 5�      -   5        $ cbxPricingType��5�   2   $
��Left=�6   $��	122,2,0,0q�6J   $	 Key��6�   $ Value��6�   $��23��5�   �   $	��Top=�6�   $��3��6�   ��5�   ]   �� *PricingTypes+ 5�      �� *SelectPricingType+{�6u   �� *IsPricingTypeEnable+6�   �� 5�      -   5        $ lbPricingStartDate��5�      $
��Left=�5�   `   $��6,4,0,0q�6{   $��4��5�   0   $	��Top=�6=   
���<����5�        $!	 Client.Properties.Resources��$
 PricingStartDate��5�   U     5�      -   5          Name$ dpPricingStartDate��5�   4   $
��Left=�6   $��	122,2,0,0q�5�      $	��Top=�6,   $��4��6n    6D   �� *PricingStartDate+{�5�      �� *IsPricingStartDateEnable+�� 5�      -   5        $ lbPricingEndDate��5�      $
��Left=�5�   ^   $��	278,3,0,0q�6y   $��Right=�6�   $��4��5�   .   $��28��6;   $	��Top=�6G   
���<����5�        $!	 Client.Properties.Resources��$
 PricingEndDate��5�   _     5�      -   5        $ dpPricingEndDate��5�   4   $
��Left=�6   $��	394,2,0,0q�5�      $	��Top=�6,   $��4��6l    6D   �� *PricingEndDate+{�5�      �� *IsPricingEndDateEnable+�� 5�      -   5        $ lbSettlementCurrency��5�   ^   $
��Left=�6|   
���<��$��6,35,0,0q�5�   )   $	��Top=�6;   $��7��6S   $y�	Collapsed=�6`   ��5�        $!	 Client.Properties.Resources��$
 SettleCurrency��5�   `   �� 5�      -   5        $ cbSettlementCurrency��5�      $��
122,35,0,0q�65   $��7��6I   $y�	Collapsed=�6W   $
��Left=�6n   $��23��6�   $	��Top=�6�   �� 5�      -   5        $ lbSettlementRate��5�      $
��Left=�5�   \   $��	278,0,0,0q�6w   
���<��$	��Top=�5�   ^   $��6��6v   $��2��6�   ��5�        $!	 Client.Properties.Resources��$
 ExchangeRate��5�   �     5�      -   5        $ txtSettlementRate��5�   !   $
��Left=�6<   $	��120��6W   $��	394,2,0,7q�5�      $��23��6�   $��6��6�    6)   �� *SettlementRate+   STR_RATE# Z 6�   �� 5�      -    5        $��lbPricingCurrency��5�      $��6��5�   _   $
��Left=�6l   $��6,0,0,0q�6�   $	��Top=�5�   -   
���<��$��2��6Z   ��5�        $!	 Client.Properties.Resources��$
 PricingCurrency��5�   Z   �� 5�      -!   5        $��cbPricingCurrency��5�   R   $��6��6   $
��Left=�6$   $��	122,2,0,7q�6?   $
 Name��5�      $ Id��60   $��23��6y   ��5�   �   �� *
Currencies+ 5�   G   �� *SelectPricingCurrencyId+6y   �� 5�      $��	合同号��6   $
��Left=�6"   
���   �$��6,38,0,0q�6P   $	��Top=�6b   �� 5�      -"   5        $��textBox1��5�      $
��Left=�6&   $	��Top=�6A   $��
122,40,0,0q�6u   ��6Y   �� *
ContractNo+6u   �� 5�      $
��Left=�6_   $��6,36,0,0q�6z   $	��Top=�5�      $��1��6,   ��5�        $!	 Client.Properties.Resources��$
 FinancialStatus��5�   ,   �� 5�      -#   5        $��	comboBox1��5�   2   $
��Left=�6   $	 Key��5�   ;   $ Value��6S   $��
122,38,0,0q�5�   ?   $	��Top=�6T   {�.  $��1��6~   ��5�      �� *StatusTypes+ 5�      �� *FinanceStatus+6~   �� 5�      -$   5        $ label3Copy2��5�   Z   $��
278,36,0,0q�6o   $
��Left=�6�   $	��Top=�5�      $��1��6,   ��5�        $!	 Client.Properties.Resources��$
 
ShipStatus��5�   ,   �� 5�      -%   5        $ comboBox1Copy��5�   2   $
��Left=�6   $��
394,38,0,0q�6I   $	 Key��5�   ;   $ Value��6S   $	��Top=�5�   @   {�.  $��1��6j   ��5�      �� *StatusTypes+ 5�      �� *DeliveryStatus+6j   �� 5�      -&   5        $ lbPricingBasis��5�      $
��Left=�5�   `   $��	278,2,0,0q�6{   $	��Top=�5�   ,   
���<��$��3��6Y   ��5�        $!	 Client.Properties.Resources��$
 PricingReference��5�   Y   �� 5�      -'   5        $ cbxPricingBasis��5�   2   $
��Left=�6   $��	394,2,0,0q�5�      $	��Top=�6*   $	 Key��6i   $ Value��5�      $��3��6�   ��5�   B   �� *PricingBasises+ 5�   1   �� *SelectPricingBasis+{�6�   �� *IsPricingBasisEnable+�� 5�      -(   5        $ 	lbPremium��5�      $
��Left=�5�   W   $��6,32,0,0q�6r   
���   �$	��Top=�5�   :   $��4��6R   ��5�        $!	 Client.Properties.Resources��$
 Premium��5�   R     5�      -)   5        $ 
txtPremium��5�   -   $��23��6!   $	��120��6A   $��
122,34,0,7q�6M   $
��Left=�6a   $��4��6�    6|   �� *	Premium+{�5�   !   �� *IsPremiumEnable+�� 5�      -*   5        $ lbPricingSide��5�      $
��Left=�5�   [   $��
278,32,0,0q�6v   $	��Top=�5�   +   $��4��6C   ��5�        $!	 Client.Properties.Resources��$
 PricingSide��5�   C   	� 5�      -+   5        $��rbtPricingSideTheir��5�   j   $��20��6^   $	��Top=�6�   $��Center=�6�   $
��left=�5�      $��
394,38,0,0q�6\   $��4��6p   ��5�        $!	 Client.Properties.Resources��$
 OppoSide�� d� 	IsChecked 5�   5   �� *PricingSideTheir+6p   	� 5�      -,   5        $��rbtPricingSideOwn��5�   ]   $
��Left=�6v   $��
474,38,0,0q�5�      $��20��6S   $	��Top=�6_   $��4��6w   ��5�        $!	 Client.Properties.Resources��$
 OurSide�� 5�   .   �� *PricingSideOwn+6w   �� 5�      --   5        $ lbWarehouse��5�   Y   $
��Left=�6n   $��6,1,0,0q�6�   $��5��5�      $	��Top=�6<   ��5�        $!	 Client.Properties.Resources��$
 	Warehouse��5�   <   �� 5�      -.   5         ��Name$ btnWarhouse��5�   #   $	��...��6   $��25��6R   $��23��6]   $��	246,2,0,7q�5�      $
��Left=�6(   $��5��6C   �� 5�      -/   5        $ lbDeliveryDate��5�   E   $��	278,4,0,0q�62   $��Right=�6^   $
��Left=�5�      $��5��6/   $	��Top=�6<   ��5�        *DeliveryDate+5�   <     5�      -0   5        $ dpDeliveryDate��5�   4   $
��Left=�6   $��	394,2,0,7q�5�      $��5��6R   $��23��6z    6,   �� *DeliveryDate+6z   �� 5�      -1   5        $��button1��5�   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5�      $��45��6-   $��8��5�      ��5�        $!	 Client.Properties.Resources��$
 AddWithSymbol��5�      �� 5�      $��6,0,0,0q�6X   $
��Left=�6i   $	��Top=�5�      $��9��6,   $��2��69   ��5�        $!	 Client.Properties.Resources��$
 Comments��5�   9   �� 5�      -2   5        $��textBox6��5�      " �� VerticalScrollBarVisibility$
 Auto=�6&   $��	122,2,0,0q�6I    �� TextWrapping$
 Wrap=�5�   3   $	��100��6G   $	��Top=�6T   $
��Left=�6l   $	��392��5�      $��9��6"   ��5�      �� *Description+5�   "   �� 5�      -3   5        $��210,130,0,0q�5�   U   $	��Top=�6j   $
��Left=�6�   $��60��5�      $��9��6-   $��23��6:   ��5�        $!	 Client.Properties.Resources��$

 Save��5�   :   �� 5�      -4   5        $	��Top=�5�   \   $
��Left=�6t   $��60��6�   $��271,134,0,0q�5�      $��9��6*   $��23��67   $y�Hidden=�6�   ��5�        $!	 Client.Properties.Resources��$
 SaveAsDraft��{�5�   W   �� *IsSaveAsDraftEnable+6�   �� 5�      -5   5        $	��Top=�5�   W   $��305,130,0,0q�6~   $
��Left=�5�      $��60��60   $��23��6;   $��9��6G   ��5�        $!	 Client.Properties.Resources��$
 Cancel��5�   G   �� 5�      -6   5        $ lbTitle��5�   C   $��32��6T   $
��Left=�6`   $��6,6,0,0q�6{   $
��auto��5�      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5�        *DomesticPurchaseContractShort+5�   K   �� 5�      -7   5         ��Name$ textBox1Copy��5�      $
��Left=�6,   $	��Top=�6G     �� 
IsReadOnly  . $��
394,40,0,0q�6�   {�.  ��6_   �� *SupplierName+6�   �� 5�      $
��Left=�6_   $��6,4,0,0q�6z   $	��Top=�5�      $��1��6,   ��5�        $!	 Client.Properties.Resources��$
 DocumentStatus��5�   ,   �� 5�      -8   5        $ textBox1Copy3��5�      $��	122,6,0,0q�6-   $	��Top=�6@   {�.  $
��Left=�5�   2   $��1��6M   ��6   �� *
BillStatus+6M   �� 5�      -9   5        $ label3Copy1��5�   ^   $��	278,4,0,0q�6s   $
��Left=�5�      $	��Top=�6/   $��1��6G   ��5�        $!	 Client.Properties.Resources��$
 ApprovalStatus��5�   G   �� 5�      -:   5        $ textBox1Copy4��5�      $��	394,6,0,0q�6-   $
��Left=�6@   $	��Top=�5�      {�.  $��1��5�   h   ��6   �� *ApproveStatus+! �� 	Converter#! [  6h   �� 5�      -;   5        $ txtWarehouse��5�      $��	122,2,0,7q�6,   $
��Left=�6?   {�.  $��5��5�   G   $��23��6T   ��6   �� *WarehouseName+6T   �� 5�      $��6,0,0,0q�6Z   $	��Top=�6k   $
��Left=�5�      $��8��6/   $��2��6<   ��5�        $!	 Client.Properties.Resources��$
 
Attachment��5�   <   &   System.Windows.Controls.DataGrid  5�      -<   5        $��dataGridAttachment��5�   W   "   AutoGenerateColumns" .  $
��auto��6q   $
��Left=�5�      #   
IsReadOnly# . $   CanUserAddRows$ .  $��
122,34,0,7q�6[   $��8��6o   $
��Auto��6|   $	��Top=�6�   ��5�   3   �� *Attachments+%   Columns% 5�      0	  *System.Windows.Controls.DataGridTextColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn& 
  Header& 6)     $!	 Client.Properties.Resources��$
 AttachmentName��1  +System.Windows.Controls.DataGridBoundColumn'   Binding' 6r   �� *Name+4  .System.Windows.Controls.DataGridTemplateColumn  5�      (   CellTemplate#( [	 6q   ) 
  CanUserSort) .  & 6-     $!	 Client.Properties.Resources��$
 	Operation��5�   -   5�      �� 5�      $
��Left=�6S   $��6,32,0,0q�6n   $	��Top=�6�   $��3��6�   ��6     $!	 Client.Properties.Resources��$	
 UDF��6�   �� 5�      -=   5        $��	comboBox3��5�   |   $
 Name��6   $
��Left=�60   $��
122,34,0,7q�6h   $ Id��6�   $��3��6�   $��23��6�   $	��Top=�6�   ��6K   �� *Udfs+ 6�   �� *SelectedUsdId+6�   �� 5�      ->   5        $��label1��5�   V   $
��Left=�6*   $��6,0,0,0q�6E   $	��Top=�6d   $��2��6�   ��6     *More+y�6|   �� *IsUseMultipleBrands+6�   �� 5      -?   5        $��button2��5   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�6�   $��45��6�   $��2��6
  ��6     $!	 Client.Properties.Resources��$
 AddWithSymbol��y�6�   �� *IsUseMultipleBrands+6
    5     -@   5        $��	dataGrid1��5  b   " .  $
��Left=�63   $��
122,34,0,7q�6N   $*   HorizontalScrollBarVisibility$
* Auto=�6�   $
��Auto��6�   # . $
��Auto��6�   $	��Top=�6�   $��2��6!  ��6s   �� y�6�   �� *IsUseMultipleBrands+% 5     	  5     + 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
+ Auto 6i   & 6)     $!	 Client.Properties.Resources��$
 Brand��' 6v   �� *
Brand.Name+6�   	  5     $
+ Auto 6q   & 6)     $!	 Client.Properties.Resources��$
 Specification��' 6~   �� *Specification.Name+6�   	  5     $
+ Auto 6i   & 6)     $!	 Client.Properties.Resources��$
 Price��' 6v   �� *Price+# Z 6�   	  5     $
+ Auto 6l   & 6)     $!	 Client.Properties.Resources��$
 Quantity��' 6y   �� *
Quantity+# Z 6�   	  5     $
+ Auto 6m   & 6)     $!	 Client.Properties.Resources��$
 	Warehouse��' 6z   �� *Warehouse.Name+6�     5     #( [ 6q   $
+ auto 6�   ) .  & 6-     $!	 Client.Properties.Resources��$
 	Operation��6�   5
     �� 5     
���   �$
��Left=�6I   $��
271,32,0,0q�6d   $	��Top=�6x   $��3��6�   $	��117��6�   ��6     *OriginContractNo+6�   �� 5     -A   5        $��textBox2��5  E   $
��Left=�6   $��
394,34,0,7q�61   $	��Top=�6s   $��3��6�   ��6U   �� *ExContractNo+6�   �� 5     -B   5        $��lbRel��5  �   $y�	Collapsed=�6   $��关联交易��6+   $��2��6:   $��28��6G   $
��Left=�6S   $��6,0,0,24q�6n   $	��110��6�   $��Bottom=�6�   �� 5     -C   5        $��btnRel��5  �   $y�	Collapsed=�6   $��23��6u   $
��Left=�6�   $��
122,0,0,27q�6�   $��45��6�   $��2��6�   $��Bottom=�6  ��6,     $!	 Client.Properties.Resources��$
 AddWithSymbol��{�6�   �� *IsRelTransactionNewBtnEnable+6    5     -D   5        $��	dataGrid2��5  �   $y�	Collapsed=�6   " .  $
��Auto��6K   $
��Left=�6Y   $
* Auto=�6t   # . $��	122,0,0,0q�6�   $��Bottom=�6�   $
��Auto��6  $��2��6  ��6�   �� % 5     	  5     $
+ Auto 6�   ' 6)   �� *BusinessParnterName+& 6Q     $!	 Client.Properties.Resources��$
 InternalCustomer��6�   	  5     $
+ Auto 6�   ' 6)   �� *Price+# Z & 6|     $!	 Client.Properties.Resources��$
 Price��6�   	  5     $& 签署日期��6_   $
+ Auto 6m   ' 6)   �� *
SignDate+$ 
yyyy-MM-dd��6m   	  5     $& 收票日期��6e   $
+ Auto 6s   ' 6)   �� *VATInvoiceDate+$ 
yyyy-MM-dd��6s     5     ) .  #( [ 6A   $
+ auto 6�   & 6q     $!	 Client.Properties.Resources��$
 	Operation��6�   5     �� 5     -E   5        $��lbVATInvoiceDate��5  b   $
��Left=�66   $��6,0,0,0q�6Q   $��Bottom=�6z   $	��110��6�   $��7��6�   ��6   �� *VATInvoiceStr+6�     5     -F   5        $��datePicker2��5  H   $
��Left=�6   $��
122,34,0,7q�64   $	��Top=�6�   $��7��6�   $��23��6�    6[   �� *VATInvoiceDate+6�   �� 5     -G   5        $��paymentMean��5  �   $	 Key��6   $
��Left=�6/   $��122,166,0,0q�6n   $ Value��6�   $	��Top=�6�   $��1��6�   ��6J   �� *PaymentMean+ 6�   �� *SelectPaymentMeanId+6�   �� 5     -H   5        $��label6��5  �   $
��Left=�6[   $��	6,164,0,0q�6v   $	��Top=�6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 PaymentMean��6�   �� 5     -I   5        $��label2��5  _   $��对手合同号��6   $��28��6$   $
��Left=�60   $��
278,32,0,0q�6K   $	��Top=�6m   $	��110��6�   $��7��6�   y�6�   �� *IsAutoNoVisible+6�   �� 5     -J   5        $��textBox3��5  Q   $��23��6   $
��Left=�6"   $��
394,34,0,0q�6=   $	��Top=�6a   $	��120��6y   $��7��6�   y�6�   �� *IsAutoNoVisible+��6�   �� *AutoContractNo+6�   �� 5     -K   5        $��label3��5  _   $��数量上下浮��6   $��28��6$   $
��Left=�60   $��
278,70,0,0q�6K   $	��Top=�6m   $	��110��6�   �� 5     -L   5        $��label4��5  [   $��±��6   $��28��6    $
��Left=�6,   $��
387,70,0,0q�6G   $	��Top=�6i   $��23��6�   �� 5      -M   5        $��label5��5   [   $��%��6   $��28��6    $
��Left=�6,   $��
508,72,0,0q�6G   $	��Top=�6i   $��23��6�     5!     -N   5        $��currencyTextBox1��5!  \   $��23��6!   $
��Left=�6-   $��
410,72,0,0q�6H   $	��Top=�6t   $	��104��6�    6�   �� *
QtyLimit+�� 5"     -O   5        $��label7��5"  c   $��是否需要自动生成��6   $��28��6'   $
��Left=�63   $��278,102,0,0q�6N   $	��Top=�6q   $	��110��6�   y�6�   �� *IsNeedAutoVisible+�� 5#     -P   5        $��	checkBox1��5#  S   $��16��6   $
��Left=�6#   $��394,108,0,0q�6>   $	��Top=�6d    6|   �� *IsNeedAutoGenerated+y�6�   �� *IsNeedAutoVisible+�� 5$     -Q   5        $��label8��5$  _   $��银行账号��6   $��28��6#   $
��Left=�6/   $��278,164,0,0q�6J   $	��Top=�6m   $	��110��6�   $��1��6�   �� 5%     -R   5        $��	comboBox4��5%  p   $
��Left=�6@   $��394,166,0,0q�6[   $	��Top=�6�   $ Id��5&  ?   $ Description��6V   $��1��5'  B   {�5%     �� *IsAccountPayEnable+��5&     �� *PayBankAccounts+ 5'     �� *PayBankAccountId+6B   �� 5(     -S   5        $��label9��5(  \   $��	业务员��6   $��28��6"   $
��Left=�6.   $��	6,134,0,0q�6I   $	��Top=�6j   $	��110��6�   �� 5)     -T   5        $��	comboBox5��5)  T   $��23��6   $
��Left=�6#   $��122,136,0,0q�6?   $	��Top=�6e   $	��120��6}   $
 Name��6�   $ Id��6�   ��6�   �� *Users+ 6�   �� *SelectedUserId+6�   5*     5+     5,     