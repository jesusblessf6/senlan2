   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 4   .Client.View.SystemSetting.RoleSetting.RoleList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.SystemSetting.RoleSetting.ResRoleSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *
RoleList+ � 	Resources    EditRole  
DeleteRole  EditPerm  ViewRole  ViewPerm  	tpButtons �� DataType �� Orientation   ResxName
   Key  
tpViewRole �� Command	 �� CommandParameter��%f  &	        &	      &	 
     &	      &	      &	      7   7  7  7  &	 �    7  �� �� �� �� �� �� $ DBEntity:Role��.R��� $��	spButtons��$ 
Horizontal=�.+��� $��
btEditRole��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btDeleteRole��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $��
btEditPerm��8�� ��  *ModifyPermission+���� *Id+�� $��
btViewPerm��8�� ��  *ViewPermission+���� *Id+�� $ DBEntity:Role��.R��� �� 8   	 �� *Id+.�.��� ��� *Name+
 J� CommandBindings
 )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [    -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� .+��� -   $��label1��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *
RoleList+�� -   $��button1��$��23��$
��Left=�$��6,40,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ AddWithSymbol��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,70,0,0q�$	��Top=�$
��Auto��   
IsReadOnly . ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [ ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    SortMemberPath$
 Name��   Header   $! Client.Properties.Resources��$
 Name��0  *System.Windows.Controls.DataGridTextColumn     $! Client.Properties.Resources��$ Comments��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Description+  # [    $! Client.Properties.Resources��$ 	Operation��