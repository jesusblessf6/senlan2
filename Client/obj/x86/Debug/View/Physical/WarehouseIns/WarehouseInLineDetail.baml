   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      =   7Client.View.Physical.WarehouseIns.WarehouseInLineDetail   5      6my/clr-namespace:Utility.Controls;assembly=Utility  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$6  0Client.View.Physical.WarehouseIns.ResWarehouseIn��5      $	��400��5	      $	��600��6%    � 
ResizeMode$ NoResize=�61    � Title 5   P     *WarehouseInLine+ � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value��%  &	        '�� �     '�� m    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5      .��5       �� $
��Auto=�6   $
��Auto=�68   .��5!   
   � -   5         �Name$ rootGrid��5!      .+�5#      �� -   5        $��button4��5#   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,40,0,0q�6J   $	��Top=�5$      $��25��6-   {�6M   �� *IsDeliveryLineEnable+�� 5%      -   5        $��textBox1��5%   E   $
��Left=�6   $��
394,40,0,0q�61   $	��Top=�6U   ��5&      �� *PBNo+{�6,   �� *IsPBNoEnable+�� 5'      -   5        $��	comboBox1��5(   +   	 �� DisplayMemberPath$
	 Name��5'      $
��Left=�60   $��
122,72,0,0q�5(      
 �� SelectedValuePath$
 Id��6n   $	��Top=�5)      ��5'   K   �� *CommodityTypes+ �� SelectedValue 5(   <   �� *SelectedCommodityTypeId+{�5)   /   �� *IsCommodityTypeEnable+�� 5*      -   5        $��	comboBox2��5*   _   $
	 Name��6   $
��Left=�60   $��
394,72,0,0q�6K   $	��Top=�5+   6   $	��120��6N   $
 Id��6Z   ��6   �� *Brands+ 5,      �� *	BrandId+{�69   �� *IsBrandEnable+�� 5-      -   5        $��	comboBox3��5-   `   $
	 Name��6   $
��Left=�60   $��122,104,0,0q�6K   $	��Top=�5.      $
 Id��6V   ��6/   �� *Specifications+ 5/      �� *SpecificationId+{�6A   �� *IsSpecificationEnable+&    Utility.Controls.CurrencyTextBox  50      -   5        $��currencyTextBox1��50   ]   $��23��6!   $
��Left=�6-   $��122,136,0,0q�6H   $	��Top=�51   !   $	��120��69      Text 6E   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {�6�   �� *IsQuantityEnable+  52      -   5        $��currencyTextBox2��52   ]   $��23��6!   $
��Left=�6-   $��394,136,0,0q�6H   $	��Top=�53   !   $	��120��69    6E   �� *VerifiedQuantity+# Z {�6�   �� *IsVerifiedQuantityEnable+�� 54      -	   5        $��	checkBox1��54   �   $��16��6b   $
��Left=�6n   $��394,172,0,0q�6�   $	��Top=�55      ��54           ResxName$! Client.Properties.Resources��
   Key$ QuantityConfirm�� d� 	IsChecked 55   /   �� *
IsVerified+  57      -
   5        $��currencyTextBox3��57   ]   $��23��6!   $
��Left=�6-   $��122,168,0,0q�6H   $	��Top=�58   !   $	��120��69    6E   �� *PackingQuantity+# Z �� 59      -   5        $��textBox3��59   S   $	��100��6   $
��Left=�6#   $��122,200,0,0q�6>   $	��Top=�6c   $	��392��5:       �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6J   " �� VerticalScrollBarVisibility$
 Auto=�6^   ��5;      �� *WarehouseInLineComment+�� 5<      -   5        $��button1��5<   �   $��23��6U   $
��Left=�6a   $��210,325,0,0q�6|   $	��Top=�5=      $��60��6-   ��5<        $! Client.Properties.Resources��$
 Save��5=   8   �� 5>      -   5        $��button2��5>   �   $��23��6\   $
��Left=�6h   $��289,325,0,0q�6�   $	��Top=�5?      $��60��6-   $y�Hidden=�68   ��5>        $! Client.Properties.Resources��$ SaveAsDraft��5?   8   �� 5@      -   5        $��button3��5@   �   $��23��6W   $
��Left=�6c   $��305,325,0,0q�6~   $	��Top=�5A      $��60��6-   ��5@        $! Client.Properties.Resources��$ Cancel��5A   8   �� 5C      -   5        $��lbTitle��5C   5   $��32��6D   $
��Left=�6P   $��6,6,0,0q�6k   $
��auto��6|   $	��Top=�5D      $
��Bold"�6,   $��16(�6>   ��5C        *WarehouseInLine+5D   >   �� 5E      -   5        $��label11��5F   &   $
��Left=�5E   *   #��[  6E   $��6,38,0,0q�5F      $	��Top=�65   
���<����5E        *BLWR+5F   M   �� 5G      -   5        $��textBox4��5G   W    �� 
IsReadOnly . $
��Left=�6(   $��
122,40,0,0q�6C   $	��Top=�5H      {�.  ��6.   �� *" DeliveryLine.Delivery.DeliveryNo+6`   �� 5I      -   5        $��label2��5J      #��[  5I   V   $
��Left=�6z   $��
278,38,0,0q�6�   $	��Top=�5J   "   
���<����5I        $! Client.Properties.Resources��$ CardNo��5J   :   �� 5K      -   5        $��label3��5L      #��[  5K   X   $
��Left=�6|   $��	6,134,0,0q�6�   $	��Top=�5L   "   ��5K        $! Client.Properties.Resources��$ Quantity��5L   "   �� 5M      -   5        $��label4��5N      #��[  5M   ^   $
��Left=�6�   $��278,134,0,0q�6�   $	��Top=�5N   "   ��5M        $! Client.Properties.Resources��$ ActualQuantity��5N   "   �� 5O      -   5        $��label6��5P   &   #��[  5O   ]   
���<��$
��Left=�6�   $��6,70,0,0q�5P      $	��Top=�64   ��5O        $! Client.Properties.Resources��$ CommodityType��5P   4   �� 5Q      -   5        $��label7��5R   (   #��[  5Q   U   
���<��$
��Left=�6�   $��
278,70,0,0q�5R      $	��Top=�66   ��5Q        $! Client.Properties.Resources��$ Brand��5R   6   �� 5S      -   5        $��label8��5T   '   #��[  5S   ]   
���<��$
��Left=�6�   $��	6,102,0,0q�5T      $	��Top=�65   ��5S        $! Client.Properties.Resources��$ Specification��5T   5   �� 5U      -   5        $��label9��5V      #��[  5U   V   $
��Left=�6z   $��	6,166,0,0q�6�   $	��Top=�5V   "   ��5U        $! Client.Properties.Resources��$ Bundle��5V   "   �� 5W      -   5        $��label10��5X      #��[  5W   X   $
��Left=�6|   $��	6,198,0,0q�6�   $	��Top=�5X   #   ��5W        $! Client.Properties.Resources��$ Comments��5X   #   5Y      5Z      5[      