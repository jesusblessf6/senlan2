   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity =   7Client.View.Physical.WarehouseIns.WarehouseInLineDetail   6my/clr-namespace:Utility.Controls;assembly=Utility  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$6  0Client.View.Physical.WarehouseIns.ResWarehouseIn��$	��400��$	��600�� � 
ResizeMode$ NoResize=� � Title   *WarehouseInLine+ � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value��%  &	        '�� �     '�� �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��button4��$	��...��$��23��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25��{��� *IsDeliveryLineEnable+�� -   $��textBox1��$
��Left=�$��
394,40,0,0q�$	��Top=����� *PBNo+{��� *IsPBNoEnable+�� -   $��	comboBox1��	 �� DisplayMemberPath$
	 Name��$
��Left=�$��
122,72,0,0q�
 �� SelectedValuePath$
 Id��$	��Top=����� *CommodityTypes+ �� SelectedValue �� *SelectedCommodityTypeId+{��� *IsCommodityTypeEnable+�� -   $��	comboBox2��$
	 Name��$
��Left=�$��
394,72,0,0q�$	��Top=�$	��120��$
 Id������ *Brands+ �� *	BrandId+{��� *IsBrandEnable+�� -   $��	comboBox3��$
	 Name��$
��Left=�$��122,104,0,0q�$	��Top=�$
 Id������ *Specifications+ �� *SpecificationId+{��� *IsSpecificationEnable+&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��122,136,0,0q�$	��Top=�$	��120��   Text �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {��� *IsQuantityEnable+  -   $��currencyTextBox2��$��23��$
��Left=�$��394,136,0,0q�$	��Top=�$	��120�� �� *VerifiedQuantity+# Z {��� *IsVerifiedQuantityEnable+�� -	   $��	checkBox1��$��16��$
��Left=�$��394,172,0,0q�$	��Top=���     ResxName$! Client.Properties.Resources��
   Key$ QuantityConfirm�� d� 	IsChecked �� *
IsVerified+  -
   $��currencyTextBox3��$��23��$
��Left=�$��122,168,0,0q�$	��Top=�$	��120�� �� *PackingQuantity+# Z �� -   $��textBox3��$	��100��$
��Left=�$��122,200,0,0q�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *WarehouseInLineComment+�� -   $��button1��$��23��$
��Left=�$��210,325,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$
 Save���� -   $��button2��$��23��$
��Left=�$��289,325,0,0q�$	��Top=�$��60��$y�Hidden=���  $! Client.Properties.Resources��$ SaveAsDraft���� -   $��button3��$��23��$
��Left=�$��305,325,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Cancel���� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *WarehouseInLine+�� -   $��label11��$
��Left=�#��[  $��6,38,0,0q�$	��Top=�
���<����  *BLWR+�� -   $��textBox4�� �� 
IsReadOnly . $
��Left=�$��
122,40,0,0q�$	��Top=�{�.  ���� *" DeliveryLine.Delivery.DeliveryNo+�� -   $��label2��#��[  $
��Left=�$��
278,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ CardNo���� -   $��label3��#��[  $
��Left=�$��	6,134,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Quantity���� -   $��label4��#��[  $
��Left=�$��278,134,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ActualQuantity���� -   $��label6��#��[  
���<��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ CommodityType���� -   $��label7��#��[  
���<��$
��Left=�$��
278,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Brand���� -   $��label8��#��[  
���<��$
��Left=�$��	6,102,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Specification���� -   $��label9��#��[  $
��Left=�$��	6,166,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Bundle���� -   $��label10��#��[  $
��Left=�$��	6,198,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments��