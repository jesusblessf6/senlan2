   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Client.ViewModel.SystemSetting.RoleSetting*Client.ViewModel.SystemSetting.RoleSetting  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5    /Client.View.SystemSetting.RoleSetting.RolePerms   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     PRoleSetting8clr-namespace:Client.ViewModel.SystemSetting.RoleSetting     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.SystemSetting.RoleSetting.ResRoleSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *RolePermission+ � 	Resources    AddCheckBox �� DataType d� 	IsChecked �� Mode �� UpdateSourceTrigger  EditCheckBox  DeleteCheckBox  ViewCheckBox��%b  &	        &	 �     &	     &	 �    �� $  RoleSetting:RolePermLineVM��.R��� $�� �� �� *IsAddChecked+$ TwoWay=�$ PropertyChanged=�{��� *IsAddExisted+�� $  RoleSetting:RolePermLineVM��.R��� $�� �� �� *IsEditChecked+$ TwoWay=�$ PropertyChanged=�{��� *IsEditExisted+�� $  RoleSetting:RolePermLineVM��.R��� $�� �� �� *IsDeleteChecked+$ TwoWay=�$ PropertyChanged=�{��� *IsDeleteExisted+�� $  RoleSetting:RolePermLineVM��.R��� $�� �� �� *IsViewChecked+$ TwoWay=�$ PropertyChanged=�{��� *IsViewExisted+.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $
��Auto ��� $��* �.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *RolePermission+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��	   AutoGenerateColumns	 .  $
��Auto��$
��Left=�$��6,40,0,0q�$	��Top=�$
��Auto��
   SelectionUnit$

 Cell=�   CanUserAddRows .     AreRowDetailsFrozen . $��Center=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .     
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    Header      ResxName$: 4Client.View.SystemSetting.RoleSetting.ResRoleSetting��
   Key$ 
ModuleName��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ModuleName+4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [  $
 Auto    $! Client.Properties.Resources��$	 Add��  # [ $
 Auto    $! Client.Properties.Resources��$
 Edit��  # [ $
 Auto    $! Client.Properties.Resources��$ Delete��  # [ $
 Auto    $! Client.Properties.Resources��$
 View�� �� 
GroupStyle (	  "System.Windows.Controls.GroupStyle	    GroupHerderStyle 	  ContainerStyle# [  	  Panel �� .R�>
  8System.Windows.Controls.Primitives.DataGridRowsPresenter
  �� -   $��button1��$��1��$��25��$
��Left=�$��	32,25,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$
 Save���� -   $��button2��$��25��$
��Left=�$��
127,25,0,0q�$	��Top=�$��60��$��1����  $! Client.Properties.Resources��$ Cancel��