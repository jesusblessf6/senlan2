   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Client.ViewModel.SystemSetting.RoleSetting*Client.ViewModel.SystemSetting.RoleSetting  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      5    /Client.View.SystemSetting.RoleSetting.RolePerms   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PRoleSetting8clr-namespace:Client.ViewModel.SystemSetting.RoleSetting     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.SystemSetting.RoleSetting.ResRoleSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *RolePermission+ � 	Resources 5         AddCheckBox �� DataType d� 	IsChecked �� Mode �� UpdateSourceTrigger  EditCheckBox  DeleteCheckBox  ViewCheckBox��%2  &	        &	 �     &	 �    &	 H    �� 5   
   $  RoleSetting:RolePermLineVM��6+   .R�5      �� $�� ��6    6"   �� *IsAddChecked+$ TwoWay=�$ PropertyChanged=�{�6w   �� *IsAddExisted+6�   5      �� 5   
   $  RoleSetting:RolePermLineVM��6,   .R�5      �� $�� ��6    6"   �� *IsEditChecked+$ TwoWay=�$ PropertyChanged=�{�6x   �� *IsEditExisted+6�   5      �� 5   
   $  RoleSetting:RolePermLineVM��6.   .R�5      �� $�� ��6    6"   �� *IsDeleteChecked+$ TwoWay=�$ PropertyChanged=�{�6z   �� *IsDeleteExisted+6�   5      �� 5   
   $  RoleSetting:RolePermLineVM��6,   .R�5      �� $�� ��6    6"   �� *IsViewChecked+$ TwoWay=�$ PropertyChanged=�{�6x   �� *IsViewExisted+6�   5      5      .��5!      �� $
��Auto=�6   $
��Auto=�68   .��5"   
   � -   5        $��rootGrid��5"       � RowDefinitions 5#      �� 5$      $
��Auto �6    �� 5%      $��* �6    .+�5'      �� -   5        $��lbTitle��5'   4   $��32��6C   $
��Left=�6O   $��6,6,0,0q�6j   $
��auto��6{   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     *RolePermission+6�   &   System.Windows.Controls.DataGrid  5(      -   5        $��	dataGrid1��5(   n   	   AutoGenerateColumns	 .  $
��Auto��63   $
��Left=�6A   $��6,40,0,0q�6\   $	��Top=�5)      $
��Auto��6/   
   SelectionUnit$

 Cell=�6<      CanUserAddRows .     AreRowDetailsFrozen . $��Center=�5*   2   ��5)   Q   ��    Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .     
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�      Header 6)        ResxName$: 4Client.View.SystemSetting.RoleSetting.ResRoleSetting��
   Key$ 
ModuleName��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *
ModuleName+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5-         CellTemplate# [  6-   $
 Auto 6�    6Y     $! Client.Properties.Resources��$	 Add��6�     5.      # [ 6-   $
 Auto 6�    6Z     $! Client.Properties.Resources��$
 Edit��6�     5/      # [ 6-   $
 Auto 6�    6\     $! Client.Properties.Resources��$ Delete��6�     50      # [ 6-   $
 Auto 6�    6Z     $! Client.Properties.Resources��$
 View��6�    �� 
GroupStyle 52      (	  "System.Windows.Controls.GroupStyle	  53        GroupHerderStyle 	  ContainerStyle# [ 6!    	  Panel 54      �� 55      .R�56   "   >
  8System.Windows.Controls.Primitives.DataGridRowsPresenter
  57      59      5;      �� 5<      -   5        $��button1��5<   �   $��1��6U   $��25��6b   $
��Left=�6n   $��	32,25,0,0q�6�   $	��Top=�6�   $��60��6�   ��6     $! Client.Properties.Resources��$
 Save��6�   �� 5=      -   5        $��button2��5=   �   $��25��6W   $
��Left=�6c   $��
127,25,0,0q�6~   $	��Top=�6�   $��60��6�   $��1��6�   ��6     $! Client.Properties.Resources��$ Cancel��6�   5>      5?      5@      