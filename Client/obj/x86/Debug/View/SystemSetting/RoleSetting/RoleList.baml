   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5	      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      4   .Client.View.SystemSetting.RoleSetting.RoleList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.SystemSetting.RoleSetting.ResRoleSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *
RoleList+ � 	Resources 5         EditRole  
DeleteRole  EditPerm  ViewRole  ViewPerm  	tpButtons �� DataType �� Orientation   ResxName
   Key  
tpViewRole �� Command	 �� CommandParameter��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     7   7  7  7  &	 �    7  �� 5   
   6+   �� 5   
   6-   �� 5   
   6+   �� 5   
   6+   �� 5   
   6+   �� 5   
   $ DBEntity:Role��6)   .R�5      �� $��	spButtons��62   $ 
Horizontal=�6   .+�5      �� $��
btEditRole��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6�   �� 5      $��btDeleteRole��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6�   �� 5      $��
btEditPerm��6   8�� ��6+     *ModifyPermission+��6q   �� *Id+6�   �� 5      $��
btViewPerm��6   8�� ��6+     *ViewPermission+��6o   �� *Id+6�   5      5      �� 5   
   $ DBEntity:Role��6*   .R�5      �� �� 5       8   	 6@   �� *Id+.�6`   .�5!      �� �6   �� *Name+62   5"      5#      5$      5%      
 J� CommandBindings
 5'      )  #System.Windows.Input.CommandBinding  5(   
   -   5           Command# [ 5(      6{     5)   
   -   5        # [  5)      6{     5*   
   -   5        # [ 5*      6�     5+   
   -   5        # [ 5+      6{     5,   
   -   5        # [ 5,      6{   .��5/      �� $
��Auto=�6   $
��Auto=�68   .��50   
   � .+�51      �� -   5        $��label1��51   �   $��32��6.   $
��Left=�6:   $��6,6,0,0q�6U   $
��auto��6f   $	��Top=�6s   $
��Bold"�6�   $��16(�6�   ��6     *
RoleList+6�   �� 52      -   5        $��button1��52   �   $��23��6^   $
��Left=�6j   $��6,40,0,0q�6�   $	��Top=�6�   $��60��6�   ��6     $! Client.Properties.Resources��$ AddWithSymbol��6�   &   System.Windows.Controls.DataGrid  53      -   5        $��	dataGrid1��53   n      AutoGenerateColumns .  $
��Auto��63   $
��Left=�6A   $��6,70,0,0q�6\   $	��Top=�54      $
��Auto��6/      
IsReadOnly . ��6]   ��    Columns 55      4  .System.Windows.Controls.DataGridTemplateColumn  56         CellTemplate# [ 6l   ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    SortMemberPath$
 Name��6�      Header 6-     $! Client.Properties.Resources��$
 Name��6�   0  *System.Windows.Controls.DataGridTextColumn  57       6)     $! Client.Properties.Resources��$ Comments��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6l   �� *Description+6�     58      # [ 6q    6-     $! Client.Properties.Resources��$ 	Operation��6�   5:      5;      5<      5=      