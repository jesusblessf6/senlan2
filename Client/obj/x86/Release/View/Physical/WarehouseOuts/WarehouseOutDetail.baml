   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity ;    5Client.View.Physical.WarehouseOuts.WarehouseOutDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *WarehouseOut+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker+   %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseOutLineEdit  WarehouseOutLineDelete  WarehouseOutLineActions �� DataType �� Orientation	   ResxName

   Key��%p  '��       '�� �     '  �     &	  �     &	 �     &	 �     &	     7  7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� �� �� $ DBEntity:WarehouseOutLine��.R��� $ 
Horizontal=�.+��� $��btWarehouseOutLineEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��btWarehouseOutLineDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $	��55* �.+��� -   $��button1��$	��...��$��23��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25��{��� *IsQuotaEnable+ � ToolTip �� *ContractInfo+�� -   $��button2��$	��...��$��23��$
��Left=�$��
246,72,0,0q�$	��Top=�$��25��{��� *IsWarehouseEnable+  -   $��datePicker1��$
��Left=�$��
394,40,0,0q�$	��Top=�   SelectedDate �� *WarehouseOutDate+�� -   $��button3��$��23��$
��Left=�$��	122,2,0,7q�$	��Top=�$��45��$��1����  $!	 Client.Properties.Resources��$
 AddWithSymbol���� -   $��textBox3��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$��3������ *	Comment+�� -	   $��button6��$��23��$
��Left=�$��210,130,0,0q�$	��Top=�$��60��$��3����  $!	 Client.Properties.Resources��$

 Save���� -
   $��button4��$��23��$
��Left=�$��278,130,0,0q�$y�Hidden=�$	��Top=�$��60��$��3����  $!	 Client.Properties.Resources��$
 SaveAsDraft���� -   $��button5��$��23��$
��Left=�$��305,130,0,0q�$	��Top=�$��60��$��3����  $!	 Client.Properties.Resources��$
 Cancel���� -   $��lbTitle��$��6,6,0,0q�$��16(�$
��Bold"�$��32��$	��Top=�$
��Left=�$
��Left=�$
��auto����  *WarehouseOut+�� -   $��label2��
���<��$
��Left=�$��6,38,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Quota���� -   $��textBox1��$
��Left=�$��
122,40,0,0q�$	��Top=�{�.  ���� *	QuotaNo+�� -   $��label3��$
��Left=�$��
278,38,0,0q�$	��Top=���  *WarehouseOutDate+�� -   $��label4��
���<��$
��Left=�$��6,70,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	Warehouse���� -   $��textBox2��$
��Left=�$��
122,72,0,0q�$	��Top=�{�.  ���� *WarehouseName+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .     
IsReadOnly . $
��Left=�$��	122,2,0,7q�$
��auto��$
��auto��$	��Top=�$   HorizontalScrollBarVisibility$
 Auto=�$��2������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	    CanUserSort .    Header   $!	 Client.Properties.Resources��$
 CardNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *WarehouseInLine.PBNo+  $
 Auto	  .    $!	 Client.Properties.Resources��$
 	Commodity�� �� *<:WarehouseInLine.DeliveryLine.Delivery.Quota.Commodity.Name+  $
 Auto	  .    $!	 Client.Properties.Resources��$
 CommodityType�� �� *CommodityType.Name+  $
 Auto	  .    $!	 Client.Properties.Resources��$
 Brand�� �� *
Brand.Name+  $
 Auto	  .    $!	 Client.Properties.Resources��$
 Quantity�� �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z   $
 Auto	  .    $!	 Client.Properties.Resources��$
 ActualQuantity�� �� *VerifiedQuantity+# Z   $
 Auto	  .    $!	 Client.Properties.Resources��$
 Bundle�� �� *PackingQuantity+# Z   $
 Auto	  .    $!	 Client.Properties.Resources��$
 QuantityConfirm�� �� *
IsVerified+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto	  .      CellTemplate#  [    $!	 Client.Properties.Resources��$
 	Operation���� -   $��label5��$
��Left=�$��6,0,0,0q�$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 Comments���� -   $��label6��$��1��$
��Left=�$��6,0,0,0q�$	��Top=���  *WarehouseOutLine+�� -   $��label7��$
��Left=�$��
278,70,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 WarehouseOutNo���� -   $��textBox4��$
��Left=�{�.  $��
394,72,0,0q�$	��Top=����� *WarehouseOutNo+�� -   $��label8��$��实际提货人��$��28��$
��Left=�$��	6,102,0,0q�$	��Top=�$	��110���� -   $��textBox5��$
��Left=�$��122,104,0,7q�$	��120��$	��Top=�{�.  ���� *BusinessPartnerName+�� -   $��button7��$	��...��$��23��$
��Left=�$��246,104,0,7q�$	��Top=�$��25��