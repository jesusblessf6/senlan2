   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 8   2Client.View.Physical.Deliveries.DeliveryLineDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     $	��500��$	��600��0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery�� � 
ResizeMode$ NoResize=� � Title   *DeliveryLine+ � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources  �� 
TargetType �� Property �� Value   DeliveryPersonEdit  DeliveryPersonDelete  DeliveryPersonActions �� DataType	 �� Orientation
   ResxName
   Key��%:  '��       '�� S     '�� �     &	  �     &	 �     &	 �     7   7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� �� �� $) #DBEntity:WarehouseOutDeliveryPerson��.R��� $	 
Horizontal=�.+��� $��btDeliveryPersonEdit��8��  ��  $!
 Client.Properties.Resources��$
 Edit������ *Id+�� $��btDeliveryPersonDelete��8�� ��  $!
 Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $	��36* �.+��� -   $��textBox1��$
��Left=�$��
122,40,0,0q�$	��Top=����� *PBNo+�� -   $��	comboBox1��$
��Left=�$��
394,40,0,0q� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value��$	��Top=����� *StatusTypes+ �� SelectedValue �� *DeliveryStatus+�� -   $��cbCmmodityType��$
��Left=�$��
394,72,0,0q�$	��Top=�$ Id��$
 Name������ *CommodityTypes+ �� *CommodityTypeId+{��� *IsCommodityTypeEnable+�� -   $��cbBrand��$
��Left=�$��122,104,0,0q�$	��Top=�$ Id��$
 Name������ *Brands+ �� *	BrandId+{��� *IsBrandEnable+�� -   $��cbSpecification��$
��Left=�$��394,104,0,0q�$	��Top=�$ Id��$
 Name������ *Specifications+ �� *SpecificationId+{��� *IsSpecificationEnable+&    Utility.Controls.CurrencyTextBox  -	   $��textBox2��$��23��$
��Left=�$��122,136,0,0q�$	��Top=�$	��120��   Text �� *	NetWeight+{��� *IsNetWeightEnable+  -
   $��textBox3��$��23��$
��Left=�$��394,136,0,0q�$	��Top=�$	��120�� �� *VerifiedWeight+{��� *IsVerifiedQuantityEnable+  -   $��textBox7��$��23��$
��Left=�$��394,136,0,0q�$	��Top=�$	��120�� �� *GrossWeight+�� -   $��	checkBox1��$��16��$
��Left=�$��	122,6,0,7q�$��1��$	��Top=���  $!
 Client.Properties.Resources��$ QuantityConfirm�� d� 	IsChecked �� *
IsVerified+�� -   $��	cbCountry��$
��Left=�$��122,168,0,7q�$	��Top=�$ Id��$ ChineseName������ *	Countries+ �� *	CountryId+ �� Mode$ TwoWay=�  -   $��textBox5��$��23��$
��Left=�$��394,168,0,7q�$	��120��$	��Top=� �� *PackingQuantity+�� -   $��textBox6��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392��$��3������ *	Comment+�� -   $
��Left=�$��209,134,0,0q�$	��Top=�$��60��$��25��$��3����  $!
 Client.Properties.Resources��$
 Save���� -   $
��Left=�$��304,134,0,0q�$	��Top=�$��60��$��25��$��3����  $!
 Client.Properties.Resources��$ Cancel���� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��16(�$
��auto��$
��Bold"�$��32��$	��Top=���  $!
 Client.Properties.Resources��$ Detail���� -   $��label2��$
��Left=�$��6,38,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ CardNo���� -   $��label3��$
��Left=�$��	6,134,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ Quantity���� -   $��label12��$
��Left=�$��	6,134,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ 	NetWeight���� -   $��label4��$
��Left=�$��278,134,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ ActualQuantity���� -   $��label13��$
��Left=�$��278,134,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ GrossWeight���� -   $��label5��$
��Left=�$��6,70,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ 	Commodity���� -   $��textBox4��$
��Left=�$��
122,72,0,0q�$	��Top=�{�.  ���� *Commodity.Name+�� -   $��label6��$
��Left=�$��
278,70,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ CommodityType���� -   $��label7��$
��Left=�$��	6,102,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ Brand���� -   $��label8��$
��Left=�$��278,102,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ Specification���� -   $��label9��$
��Left=�$��278,166,0,0q�$	��Top=�$��2����  $!
 Client.Properties.Resources��$ Bundle���� -   $��label10��$
��Left=�$��6,0,0,0q�$	��Top=�$��3����  $!
 Client.Properties.Resources��$ Comments���� -   $��label11��$
��Left=�$��	6,166,0,0q�$	��Top=�$��2����  $!
 Client.Properties.Resources��$ OriginCountry���� -    $��label14��$
��Left=�$��
278,38,0,0q�$	��Top=���  $!
 Client.Properties.Resources��$ 
ShipStatus���� -!   $��label15��$��提货人信息��$��28��$
��Left=�$��6,0,0,0q�$	��Top=�$	��110��$��2���� -"   $��button1��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��50��$��2����  $!
 Client.Properties.Resources��$ AddWithSymbol��&   System.Windows.Controls.DataGrid  -#   $��	dataGrid1��   AutoGenerateColumns .     
IsReadOnly . $
��Left=�$��
122,34,0,7q�$
��auto��$   HorizontalScrollBarVisibility$
 Auto=�$
��auto��$	��Top=�$��2������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    Header   $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryPerson��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Name+  $
 Auto  .    $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$
 IdNo�� �� *IdentityCard+  $
 Auto  .    $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ 	VehicleNo�� �� *	VehicleNo+  $
 Auto  .    $8
 2Client.View.Physical.WarehouseOuts.ResWarehouseOut��$ DeliveryQty�� �� *DeliveryQuantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY �� StringFormat# Z 4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto  .      CellTemplate#  [    $!
 Client.Properties.Resources��$ 	Operation���� -$   $��labelTempUnitPrice��$��	暂定价��$��1��$��2��$��28��$
��Left=�$��	278,0,0,0q�$	��Top=�$	��110��  -%   $"��currencyTextBoxTempUnitPrice��$��23��$
��Left=�$��	394,2,0,7q�$	��Top=�$	��120��$��1�� �� *TempUnitPrice+