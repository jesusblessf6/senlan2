   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 9    3Client.View.Physical.WarehouseIns.WarehouseInDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$6  0Client.View.Physical.WarehouseIns.ResWarehouseIn�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ WarehouseIn�� � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker+   %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseInLineEdit  WarehouseInLineDelete  WarehouseInLineActions	 �� DataType
 �� Orientation��%m  '��       '�� �     '  �     &	  �     &	 �     &	 �     &	     7  7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� �� �� $	 DBEntity:WarehouseInLine��.R��� $
 
Horizontal=�.+��� $��btWarehouseInLineEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btWarehouseInLineDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $��32 ��� $
��auto ��� $	��55* �.+��� -   $��button2��$	��...��$��23��$
��Left=�$��
518,40,0,0q�$	��Top=�$��25��{��� *IsWarehouseEnable+  -   $��datePicker1��$
��Left=�$��
122,72,0,7q�$	��Top=�   SelectedDate �� *WarehouseInDate+�� -   $��btWarehouseInLineAdd��$��23��$
��Left=�$��	122,2,0,7q�$	��Top=�$��45��$��1����  $! Client.Properties.Resources��$ AddWithSymbol���� -   $��textBox1��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$��3������ *	Comment+�� -   $��button1��$��23��$
��Left=�$��210,130,0,0q�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$
 Save���� -	   $��button4��$��23��$y�Hidden=�$
��Left=�$��419,130,0,0q�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$ SaveAsDraft���� -
   $��button3��$��23��$
��Left=�$��305,130,0,0q�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$ Cancel���� -   $��lbTitle��$��6,6,0,0q�$��16(�$
��Bold"�$��32��$	��Top=�$
��Left=�$
��Left=�$
��auto����  $! Client.Properties.Resources��$ WarehouseIn���� -   $��label3��$
��Left=�$��6,70,0,0q�$	��Top=���  *WarehouseInDate+�� -   $��label4��$
��Left=�$��
278,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ 	Warehouse��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .     
IsReadOnly . $
��Left=�$��	122,2,0,7q�$
��auto��$
��auto��$	��Top=�$   HorizontalScrollBarVisibility$
 Auto=�$��2������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	    CanUserSort .    Header   $! Client.Properties.Resources��$ CardNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *PBNo+  $
 Auto	  .    $! Client.Properties.Resources��$ 	Commodity�� �� *,*DeliveryLine.Delivery.Quota.Commodity.Name+  $
 Auto	  .    $! Client.Properties.Resources��$
 Type�� �� *CommodityType.Name+  $
 Auto	  .    $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+  $
 Auto	  .    $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z   $
 Auto	  .    $! Client.Properties.Resources��$ ActualQuantity�� �� *VerifiedQuantity+# Z   $
 Auto	  .    $! Client.Properties.Resources��$ Bundle�� �� *PackingQuantity+# Z   $
 Auto	  .    $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto	  .     CellTemplate# [    $! Client.Properties.Resources��$ 	Operation���� -   $��textBox3��$
��Left=�$��
394,40,0,0q�$	��Top=�{�.  ���� *WarehouseName+�� -   $��label2��$
��Left=�$��6,0,0,0q�$	��Top=�$��3����  $! Client.Properties.Resources��$ Comments���� -   $��label5��$��1��$
��Left=�$��6,0,0,0q�$	��Top=���  *WarehouseInLine+�� -   $��label1��$��金属��$��28��$
��Left=�$��6,38,0,0q�$	��Top=�$	��110��
���<���� -   $��	comboBox1��$��23��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120��  �� SelectedValuePath$  Id��! �� DisplayMemberPath$
! Name������ *CommodityList+" �� SelectedValue" �� *SelectedCommodityId+