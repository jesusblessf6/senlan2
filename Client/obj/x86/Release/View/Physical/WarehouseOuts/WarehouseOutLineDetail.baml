   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity ?   9Client.View.Physical.WarehouseOuts.WarehouseOutLineDetail   6my/clr-namespace:Utility.Controls;assembly=Utility  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$
��auto��$	��600�� � 
ResizeMode$ NoResize=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title   *WarehouseOutLine+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value  DeliveryPersonEdit  DeliveryPersonDelete  DeliveryPersonActions �� DataType	 �� Orientation
   ResxName
   Key��%g  &	        '�� �     '�� �     &	 �     &	 �     &	 �     7  7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� �� �� $) #DBEntity:WarehouseOutDeliveryPerson��.R��� $	 
Horizontal=�.+��� $��btDeliveryPersonEdit��8��  ��  $!
 Client.Properties.Resources��$
 Edit������ *Id+�� $��btDeliveryPersonDelete��8�� ��  $!
 Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��auto ��� $
��auto �.+��� -   $��	comboBox1��$
��Left=�$��
394,40,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *CommodityTypes+ �� SelectedValue �� *CommodityTypeId+�� -   $��	comboBox2��$
��Left=�$��
122,72,0,0q�$	��Top=�$
 Name��$ Id������ *Brands+ �� *	BrandId+�� -   $��	comboBox3��$
��Left=�$��
394,72,0,0q�$	��Top=�$
 Name��$ Id������ *Specifications+ �� *SpecificationId+�� -   $��button1��$	��...��$��23��$
��Left=�$��246,104,0,0q�$	��Top=�$��25��&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��122,136,0,0q�$	��Top=�$	��120��   Text �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {��� *IsQuantityEnable+�� -	   $��	checkBox1��$��16��$
��Left=�$��394,172,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ QuantityConfirm�� d� 	IsChecked �� *
IsVerified+  -
   $��currencyTextBox2��$��23��$
��Left=�$��394,136,0,0q�$	��Top=�$	��120�� �� *VerifiedQuantity+# Z {��� *IsVerifiedQuantityEnable+  -   $��currencyTextBox3��$��23��$
��Left=�$��122,168,0,0q�$	��Top=�$	��120�� �� *PackingQuantity+# Z �� -   $��	checkBox2��$��16��$
��Left=�$��394,108,0,0q�$	��Top=� J� RenderTransformOrigin$ 3.268,-1.375&���  *	PBClear+ �� *	IsPBClear+{��� *IsClearPBNoEnable+�� -   $��textBox3��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$��1������ *	Comment+�� -   $��button3��$��23��$
��Left=�$��210,130,0,0q�$	��Top=�$��60��$��1����  $!
 Client.Properties.Resources��$
 Save���� -   $��button4��$��23��$
��Left=�$��289,130,0,0q�$	��Top=�$��60��$y�Hidden=�$��1����  $!
 Client.Properties.Resources��$ SaveAsDraft���� -   $��button5��$��23��$
��Left=�$��305,130,0,0q�$	��Top=�$��60��$��1����  $!
 Client.Properties.Resources��$ Cancel���� -   $��label1��#��[  $
��Left=�$��6,38,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ 	Commodity���� -   $��textBox1��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120�� �� 
IsReadOnly . ���� *CommodityName+�� -   $��label2��
���<��#��[  $
��Left=�$��
278,38,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ CommodityType���� -   $��label3��
���<��#��[  $
��Left=�$��6,70,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ Brand���� -   $��label4��
���<��#��[  $
��Left=�$��
278,70,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ Specification���� -   $��label5��
���<��#��[  $
��Left=�$��	6,102,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ CardNo���� -   $��textBox2��{�.  $
��Left=�$��122,104,0,0q�$	��Top=�$	��120������ *WarehouseInLine.PBNo+�� -   $��label6��#��[  $
��Left=�$��	6,134,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ Quantity���� -   $��label7��#��[  $
��Left=�$��278,134,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ ActualQuantity���� -   $��label8��#��[  $
��Left=�$��	6,166,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ Bundle���� -   $��label9��#��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1����  $!
 Client.Properties.Resources��$ Comments���� -   $��lbTitle��$��32��$
��Left=�$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *WarehouseOutLine+�� -   $��button2��$��23��$
��Left=�$��122,200,0,0q�$	��Top=�$��45����  $!
 Client.Properties.Resources��$ AddWithSymbol���� -   $��label11��#��[  $
��Left=�$��	6,198,0,0q�$	��Top=���  *DeliveryPersonInfo+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .     
IsReadOnly . $
��Left=�$��122,232,0,7q�$
��auto��$   HorizontalScrollBarVisibility$
 Auto=�$
��auto��$��80��$	��Top=�����     Columns  0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn!   Width5	  /System.Windows.Controls.DataGridLengthConverter$
! Auto	 "   CanUserSort" . #   Header#   $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryPerson��1
  +System.Windows.Controls.DataGridBoundColumn$ 
  Binding$ �� *Name+  $
! Auto	 " . #   $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$
 IdNo��$ �� *IdentityCard+  $
! Auto	 " . #   $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ 	VehicleNo��$ �� *	VehicleNo+  $
! Auto	 " . #   $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryQty��$ �� *DeliveryQuantity+# Z 4  .System.Windows.Controls.DataGridTemplateColumn  $
! Auto	 " .  %   CellTemplate#% [ #   $!
 Client.Properties.Resources��$ 	Operation��