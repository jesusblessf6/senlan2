   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      8   2Client.View.Physical.Deliveries.DeliveryLineDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      $	��500��5   k   $	��600��6x   0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery��5       � 
ResizeMode$ NoResize=�5
       � Title 5   O     *DeliveryLine+ � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5       �� 
TargetType �� Property �� Value   DeliveryPersonEdit  DeliveryPersonDelete  DeliveryPersonActions �� DataType	 �� Orientation
   ResxName
   Key��%�  '��       '�� �     '��     &	  �    &	 �    &	 �    7   7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   65   �� 5   
   67   �� 5!   
   $) #DBEntity:WarehouseOutDeliveryPerson��65   .R�5"      �� $	 
Horizontal=�6   .+�5#      �� $��btDeliveryPersonEdit��6   8��  ��65     $!
 Client.Properties.Resources��$
 Edit����5$      �� *Id+6;   �� 5%      $��btDeliveryPersonDelete��6   8�� ��67     $!
 Client.Properties.Resources��$ Delete����5&      �� *Id+6;   5'      5(      5)       J� CommandBindings 5+      )  #System.Windows.Input.CommandBinding  5,   
   -   5           Command# [  5,      5-   A     5.   
   -   5        # [ 5.      5/   C   .��52      �� $
��Auto=�6   $
��Auto=�68   .��54   
   � -   5         �Name$ rootGrid��54       � RowDefinitions 55      �� 56      $
��Auto �6    �� 57      $
��auto �6    �� 58      $
��auto �6    �� 59      $	��36* �6    .+�5<      �� -   5        $��textBox1��5<   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   ��5=      �� *PBNo+�� 5>      -   5        $��	comboBox1��5>   j   $
��Left=�6   $��
394,40,0,0q�6V    �� DisplayMemberPath$	 Key��5?       �� SelectedValuePath$ Value��6/   $	��Top=�6r   ��5>   2   �� *StatusTypes+ �� SelectedValue 5?   I   �� *DeliveryStatus+6r   �� 5@      -   5        $��cbCmmodityType��5B   A   $
��Left=�5@      $��
394,72,0,0q�62   $	��Top=�6F   $ Id��5A   >   $
 Name��6U   ��6   �� *CommodityTypes+ 5B      �� *CommodityTypeId+{�5C      �� *IsCommodityTypeEnable+�� 5D      -   5        $��cbBrand��5E   i   $
��Left=�5D      $��122,104,0,0q�62   $	��Top=�6G   $ Id��5E      $
 Name��6.   ��5D   _   �� *Brands+ 5E   G   �� *	BrandId+{�6x   �� *IsBrandEnable+�� 5F      -   5        $��cbSpecification��5H   A   $
��Left=�5F      $��394,104,64,0q�62   $	��Top=�6H   $ Id��5G   >   $
 Name��6U   ��6   �� *Specifications+ 5H      �� *SpecificationId+{�6X   �� *IsSpecificationEnable+&    Utility.Controls.CurrencyTextBox  5I      -	   5        $��textBox2��5I   ]   $��23��6!   $
��Left=�6-   $��122,136,0,0q�6H   $	��Top=�5J   !   $	��120��69      Text 6E   �� *	NetWeight+{�5K   !   �� *IsNetWeightEnable+  5L      -
   5        $��textBox3��5L   ]   $��23��6!   $
��Left=�6-   $��394,136,0,0q�6H   $	��Top=�5M   !   $	��120��69    6E   �� *VerifiedWeight+{�6e   �� *IsVerifiedQuantityEnable+  5N      -   5        $��textBox7��5N   ]   $��23��6!   $
��Left=�6-   $��394,136,0,0q�6H   $	��Top=�5O   !   $	��120��69    6E   �� *GrossWeight+�� 5P      -   5        $��	checkBox1��5P   �   $��16��6b   $
��Left=�6n   $��	122,6,0,7q�6�   $��1��6�   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ QuantityConfirm�� d� 	IsChecked 6�   �� *
IsVerified+6�   �� 5Q      -   5        $��	cbCountry��5Q   G   $
��Left=�6   $��122,168,0,7q�62   $	��Top=�6X   $ Id��5R   9   $ ChineseName��6P   ��6   �� *	Countries+ 5S      �� *	CountryId+ �� Mode$ TwoWay=�  5T      -   5        $��textBox5��5T   ]   $��23��6!   $
��Left=�6-   $��394,168,0,7q�6H   $	��120��6m   $	��Top=�6�    6y   �� *PackingQuantity+6�   �� 5U      -   5        $��textBox6��5U   Q   $	��100��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�5V      $	��392��6.   $��3��6S   ��6:   �� *	Comment+6S   �� 5W      -   5        $
��Left=�5W   U   $��209,134,0,0q�6p   $	��Top=�6�   $��60��6�   $��25��5X      $��3��6.   ��5W        $!
 Client.Properties.Resources��$
 Save��5X   .   �� 5Y      -   5        $
��Left=�5Y   W   $��304,134,0,0q�6r   $	��Top=�6�   $��60��6�   $��25��5Z      $��3��60   ��5Y        $!
 Client.Properties.Resources��$ Cancel��5Z   0   �� 5[      -   5        $��lbTitle��5\       $
��Left=�5[   V   $��6,6,0,0q�6q   $��16(�6�   $
��auto��6�   $
��Bold"�6�   $��32��5\      $	��Top=�6/   ��5[        $!
 Client.Properties.Resources��$ Detail��5\   /   �� 5]      -   5        $��label2��5]   �   $
��Left=�6V   $��6,38,0,0q�6q   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ CardNo��6�   �� 5^      -   5        $��label3��5^   �   $
��Left=�6X   $��	6,134,0,0q�6s   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ Quantity��6�   �� 5_      -   5        $��label12��5_   �   $
��Left=�6Y   $��	6,134,0,0q�6t   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ 	NetWeight��6�   �� 5`      -   5        $��label4��5`   �   $
��Left=�6^   $��278,134,0,0q�6y   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ ActualQuantity��6�   �� 5a      -   5        $��label13��5a   �   $
��Left=�6[   $��278,134,0,0q�6v   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ GrossWeight��6�   �� 5b      -   5        $��label5��5b   �   $
��Left=�6Y   $��6,70,0,0q�6t   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ 	Commodity��6�   �� 5c      -   5        $��textBox4��5c   E   $
��Left=�6   $��
122,72,0,0q�61   $	��Top=�6U   {�.  ��5d   (   �� *Commodity.Name+�� 5e      -   5        $��label6��5e   �   $
��Left=�6]   $��
278,70,0,0q�6x   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ CommodityType��6�   �� 5f      -   5        $��label7��5f   �   $
��Left=�6U   $��	6,102,0,0q�6p   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ Brand��6�   �� 5g      -   5        $��label8��5g   �   $
��Left=�6]   $��278,102,0,0q�6x   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ Specification��6�   �� 5h      -   5        $��label9��5h   �   $
��Left=�6V   $��278,166,0,0q�6q   $	��Top=�6�   $��2��6�   ��6     $!
 Client.Properties.Resources��$ Bundle��6�   �� 5i      -   5        $��label10��5i   �   $
��Left=�6X   $��6,0,0,0q�6s   $	��Top=�6�   $��3��6�   ��6     $!
 Client.Properties.Resources��$ Comments��6�   �� 5j      -   5        $��label11��5j   �   $
��Left=�6]   $��	6,166,0,0q�6x   $	��Top=�6�   $��2��6�   ��6     $!
 Client.Properties.Resources��$ OriginCountry��6�   �� 5k      -    5        $��label14��5k   �   $
��Left=�6Z   $��
278,38,0,0q�6u   $	��Top=�6�   ��6     $!
 Client.Properties.Resources��$ 
ShipStatus��6�   �� 5l      -!   5        $��label15��5l   \   $��提货人信息��6   $��28��6$   $
��Left=�60   $��6,0,0,0q�6K   $	��Top=�6k   $	��110��6�   $��2��6�   �� 5m      -"   5        $��button1��5m   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�6�   $��50��6�   $��2��6�   ��6     $!
 Client.Properties.Resources��$ AddWithSymbol��6�   &   System.Windows.Controls.DataGrid  5n      -#   5        $��	dataGrid1��5o   '      AutoGenerateColumns .     
IsReadOnly . $
��Left=�5n   E   $��
122,34,0,7q�5o      $
��auto��68   $   HorizontalScrollBarVisibility$
 Auto=�5p      $
��auto��68   $	��Top=�6F   $��2��6^   ��5o   E   ��    Columns 5q      0  *System.Windows.Controls.DataGridTextColumn  5r      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�      CanUserSort .    Header 6%     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryPerson��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6�   �� *Name+6�     5s      $
 Auto 6{    .  6%     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$
 IdNo�� 6�   �� *IdentityCard+6�     5t      $
 Auto 6�    .  6%     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ 	VehicleNo�� 6�   �� *	VehicleNo+6�     5u      $
 Auto 6�    .  6)     $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryQty�� 6�   �� *DeliveryQuantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY �� StringFormat# Z 6	  4  .System.Windows.Controls.DataGridTemplateColumn  5v      $
 Auto 6m    .      CellTemplate#  [ 5w   )    5v   )     $!
 Client.Properties.Resources��$ 	Operation��5w   a   5y      �� 5z      -$   5        $��labelTempUnitPrice��5z   z   $��	暂定价��6   $��1��6"   $��2��6/   $��28��6@   $
��Left=�6L   $��	278,0,0,0q�6g   $	��Top=�6�   $	��110��6�     5{      -%   5        $"��currencyTextBoxTempUnitPrice��5{   [   $��23��6!   $
��Left=�6-   $��	394,2,0,7q�6H   $	��Top=�6�   $	��120��6�   $��1��6�    6   �� *TempUnitPrice+6�   5|      5}      5~      