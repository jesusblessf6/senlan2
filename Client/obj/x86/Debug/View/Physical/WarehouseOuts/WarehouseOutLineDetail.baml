   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      ?   9Client.View.Physical.WarehouseOuts.WarehouseOutLineDetail   5      6my/clr-namespace:Utility.Controls;assembly=Utility  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut��5      $
��auto��5      $	��600��6&    � 
ResizeMode$ NoResize=�62    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5
        *WarehouseOutLine+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value  DeliveryPersonEdit  DeliveryPersonDelete  DeliveryPersonActions �� DataType	 �� Orientation
   ResxName
   Key��%�  &	        '�� �     '�� m    &	 �    &	 �    &	 
    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5    
   65   �� 5!   
   67   �� 5#   
   $) #DBEntity:WarehouseOutDeliveryPerson��65   .R�5$      �� $	 
Horizontal=�6   .+�5%      �� $��btDeliveryPersonEdit��6   8��  ��65     $!
 Client.Properties.Resources��$
 Edit����5&      �� *Id+6;   �� 5'      $��btDeliveryPersonDelete��6   8�� ��67     $!
 Client.Properties.Resources��$ Delete����5(      �� *Id+6;   5)      5*      5+       J� CommandBindings 5-      )  #System.Windows.Input.CommandBinding  5.   
   -   5           Command# [ 5.      5/   A     50   
   -   5        # [ 50      51   C   .��54      �� $
��Auto=�6   $
��Auto=�68   .��55   
   � -   5         �Name$ rootGrid��55       � RowDefinitions 56      �� 57      $
��auto �6    �� 58      $
��auto �6    .+�5:      �� -   5        $��	comboBox1��5:   F   $
��Left=�6   $��
394,40,0,0q�62   $	��Top=�6W    �� DisplayMemberPath$
 Name��5;   h    �� SelectedValuePath$ Id��5<      ��5;      �� *CommodityTypes+ �� SelectedValue 6>   �� *CommodityTypeId+5<      �� 5=      -   5        $��	comboBox2��5=   F   $
��Left=�6   $��
122,72,0,0q�62   $	��Top=�6W   $
 Name��5>   X   $ Id��6q   ��6   �� *Brands+ 66   �� *	BrandId+6q   �� 5?      -   5        $��	comboBox3��5?   F   $
��Left=�6   $��
394,72,0,0q�62   $	��Top=�6W   $
 Name��5@   h   $ Id��5A      ��5@      �� *Specifications+ 6>   �� *SpecificationId+5A      �� 5B      -   5        $��button1��5B   _   $	��...��6   $��23��6#   $
��Left=�6/   $��246,104,0,0q�6J   $	��Top=�5C      $��25��6-   68   &    Utility.Controls.CurrencyTextBox  5D      -   5        $��currencyTextBox1��5D   ]   $��23��6!   $
��Left=�6-   $��122,136,0,0q�6H   $	��Top=�5E   !   $	��120��69      Text 6E   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {�5F   !   �� *IsQuantityEnable+�� 5G      -	   5        $��	checkBox1��5G   �   $��16��6b   $
��Left=�6n   $��394,172,0,0q�6�   $	��Top=�5H      ��5G        $!
 Client.Properties.Resources��$ QuantityConfirm�� d� 	IsChecked 5H   /   �� *
IsVerified+  5I      -
   5        $��currencyTextBox2��5I   ]   $��23��6!   $
��Left=�6-   $��394,136,0,0q�6H   $	��Top=�5J   !   $	��120��69    6E   �� *VerifiedQuantity+# Z {�6�   �� *IsVerifiedQuantityEnable+  5K      -   5        $��currencyTextBox3��5K   ]   $��23��6!   $
��Left=�6-   $��122,168,0,0q�6H   $	��Top=�5L   !   $	��120��69    6E   �� *PackingQuantity+# Z �� 5M      -   5        $��	checkBox2��5M   l   $��16��60   $
��Left=�6<   $��394,108,0,0q�6W   $	��Top=�5N       J� RenderTransformOrigin$ 3.268,-1.375&�6w   ��5M        *	PBClear+ 5N   /   �� *	IsPBClear+{�6O   �� *IsClearPBNoEnable+6w   �� 5O      -   5        $��textBox3��5O   Q   $	��100��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   $	��392��5P       �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6J   " �� VerticalScrollBarVisibility$
 Auto=�6^   $��1��5Q   /   ��6   �� *	Comment+6/   �� 5R      -   5        $��button3��5R   �   $��23��6U   $
��Left=�6a   $��210,130,0,0q�6|   $	��Top=�5S      $��60��6-   $��1��6G   ��5R        $!
 Client.Properties.Resources��$
 Save��5S   G   �� 5T      -   5        $��button4��5T   �   $��23��6\   $
��Left=�6h   $��289,130,0,0q�6�   $	��Top=�5U      $��60��6-   $y�Hidden=�68   $��1��6L   ��5T        $!
 Client.Properties.Resources��$ SaveAsDraft��5U   L   �� 5V      -   5        $��button5��5V   �   $��23��6W   $
��Left=�6c   $��305,130,0,0q�6~   $	��Top=�5W      $��60��6-   $��1��6M   ��5V        $!
 Client.Properties.Resources��$ Cancel��5W   M   �� 5Y      -   5        $��label1��5Z      #��[  5Y   Y   $
��Left=�6}   $��6,38,0,0q�6�   $	��Top=�5Z   "   ��5Y        $!
 Client.Properties.Resources��$ 	Commodity��5Z   "   �� 5[      -   5        $��textBox1��5[   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   $	��120��6m    �� 
IsReadOnly . ��5\      �� *CommodityName+65   �� 5]      -   5        $��label2��5^   (   
���<��#��[  5]   r   $
��Left=�6�   $��
278,38,0,0q�5^      $	��Top=�66   ��5]        $!
 Client.Properties.Resources��$ CommodityType��5^   6   �� 5_      -   5        $��label3��5`   &   
���<��#��[  5_   j   $
��Left=�6�   $��6,70,0,0q�5`      $	��Top=�64   ��5_        $!
 Client.Properties.Resources��$ Brand��5`   4   �� 5a      -   5        $��label4��5b   (   
���<��#��[  5a   r   $
��Left=�6�   $��
278,70,0,0q�5b      $	��Top=�66   ��5a        $!
 Client.Properties.Resources��$ Specification��5b   6   �� 5c      -   5        $��label5��5d   '   
���<��#��[  5c   k   $
��Left=�6�   $��	6,102,0,0q�5d      $	��Top=�65   ��5c        $!
 Client.Properties.Resources��$ CardNo��5d   5   �� 5e      -   5        $��textBox2��5e   X   {�.  $
��Left=�6(   $��122,104,0,0q�6C   $	��Top=�5f      $	��120��6.   ��6:   �� *WarehouseInLine.PBNo+�� 5g      -   5        $��label6��5h      #��[  5g   X   $
��Left=�6|   $��	6,134,0,0q�6�   $	��Top=�5h   "   ��5g        $!
 Client.Properties.Resources��$ Quantity��5h   "   �� 5i      -   5        $��label7��5j      #��[  5i   ^   $
��Left=�6�   $��278,134,0,0q�6�   $	��Top=�5j   "   ��5i        $!
 Client.Properties.Resources��$ ActualQuantity��5j   "   �� 5k      -   5        $��label8��5l      #��[  5k   V   $
��Left=�6z   $��	6,166,0,0q�6�   $	��Top=�5l   "   ��5k        $!
 Client.Properties.Resources��$ Bundle��5l   "   �� 5m      -   5        $��label9��5n      #��[  5m   X   $
��Left=�6|   $��6,0,0,0q�6�   $	��Top=�5n   "   $��1��6:   ��5m        $!
 Client.Properties.Resources��$ Comments��5n   :   �� 5o      -   5        $��lbTitle��5o   6   $��32��6E   $
��Left=�6Q   $
��Left=�6t   $��6,6,0,0q�6�   $
��auto��6�   $	��Top=�5p      $
��Bold"�6,   $��16(�6>   ��5o        *WarehouseOutLine+5p   >   �� 5q      -   5        $��button2��5q   �   $��23��6^   $
��Left=�6j   $��122,200,0,0q�6�   $	��Top=�5r      $��45��6-   ��5q        $!
 Client.Properties.Resources��$ AddWithSymbol��5r   8   �� 5s      -   5        $��label11��5s   �   #��[  68   $
��Left=�6\   $��	6,198,0,0q�6w   $	��Top=�5t      ��5s        *DeliveryPersonInfo+5t      &   System.Windows.Controls.DataGrid  5u      -   5        $��	dataGrid1��5v   ,      AutoGenerateColumns .     
IsReadOnly . $
��Left=�5u   E   $��122,232,0,7q�5v      $
��auto��6=   $   HorizontalScrollBarVisibility$
 Auto=�5w      $
��auto��6<   $��80��6J   $	��Top=�6Z   ��5v   J   ��     Columns  5x      0  *System.Windows.Controls.DataGridTextColumn  5y      ,  &System.Windows.Controls.DataGridColumn!   Width5	  /System.Windows.Controls.DataGridLengthConverter$
! Auto	 6�   "   CanUserSort" . #   Header# 6)     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryPerson��1
  +System.Windows.Controls.DataGridBoundColumn$ 
  Binding$ 6�   �� *Name+6�     5z      $
! Auto	 6   " . # 6)     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$
 IdNo��$ 6�   �� *IdentityCard+6�     5{      $
! Auto	 6�   " . # 6)     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ 	VehicleNo��$ 6�   �� *	VehicleNo+6�     5|      $
! Auto	 6�   " . # 6)     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryQty��$ 6�   �� *DeliveryQuantity+# Z 6	  4  .System.Windows.Controls.DataGridTemplateColumn  5}      $
! Auto	 6q   " .  %   CellTemplate#% [ 5~   -   # 5}   -     $!
 Client.Properties.Resources��$ 	Operation��5~   e   5�      5�      5�      5�      