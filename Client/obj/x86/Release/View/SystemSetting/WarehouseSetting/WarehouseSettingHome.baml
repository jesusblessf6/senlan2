   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient E   ?Client.View.SystemSetting.WarehouseSetting.WarehouseSettingHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$D  >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *WarehouseSettingHome+ � 	Resources    WarehouseEdit  WarehouseDelete  WarehouseView  WarehouseActions �� DataType �� Orientation   ResxName
   Key  WarehouseNameLink �� Command	 �� CommandParameter��%�  &	        &	      &	 
     &	      7   7  &	     7  �� �� �� �� $ DBEntity:Warehouse��.R��� $ 
Horizontal=�.+��� $��btWarehouseEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btWarehouseDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:Warehouse��.R��� �� 8   	 �� *Id+.�.��� ��� *Name+
 J� CommandBindings
 )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� .+��� -   $��label1��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *WarehouseSettingHome+�� -   $��button1��$��23��$
��Left=�$��6,40,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ AddWithSymbol��$   Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��6,70,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,107,0,0q�$	��Top=�$
��Auto��   
IsReadOnly . ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    SortMemberPath$
 Name��   CellTemplate# [    Header   $D >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��$ 	ShortName��0	  *System.Windows.Controls.DataGridTextColumn	  $
 Auto  .    $D >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��$ FullName��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *
FullName+	  $
 Auto  .    $D >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��$ Address�� �� *	Address+	  $
 Auto  .    $! Client.Properties.Resources��$ ContactPerson�� �� *ContactPerson+	  $
 Auto  .    $! Client.Properties.Resources��$	 Tel�� �� *Phone+	  $
 Auto  .    $! Client.Properties.Resources��$	 Fax�� �� *Fax+	  $
 Auto  .    $! Client.Properties.Resources��$ PostCode�� �� *
PostCode+	  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation��