   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient ;   5Client.View.SystemSetting.ModuleSetting.ModuleSetting   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$>  8Client.View.SystemSetting.ModuleSetting.ResModuleSetting�� N� Title$ 模块设置�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources    ChangePermCommand  EditModuleCommand  ViewModuleCommand  DeleteModuleCommand  
ChangePerm �� DataType �� Orientation   ResxName
   Key��%(  &	        &	      &	 
     &	      &	      7   7  7  7  �� �� �� �� �� $ DBEntity:Module��.R��� $ 
Horizontal=�.+��� $��更改权限��8��  $��70��$��20��$��11(����� *Id+�� $��20��$��11(�$��30��8�� ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��20��$��11(�$��30��8�� ��  $! Client.Properties.Resources��$
 View������ *Id+�� $��20��$��11(�$��30��8�� $y�	Collapsed=���  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [    -   #	 [   -   #	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��
 � DataContext
 �� *ModuleSettingVM+ � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -   $��label1��$��模块管理��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(��� -   $��button1��$��+ 添加模块分类��$��1��$��23��$
��Left=�$��6,7,0,0q�$	��Top=�$	��108��R� -   $��tvModule��$
��Left=�$��6,40,0,6q�$
��Auto��$	��150��$��50��$��0�� R� SelectedValuePath$ Id������ ����  �� 
TargetType" Q�.���  �� Property �@Q�
IsExpanded �� Value �� *
IsExpanded+ �� Mode$ TwoWay=���  �@Q�
IsSelected �� *
IsSelected+$ TwoWay=���  � ��$ Normal"� �� Triggers P�  P� Property �@Q�
IsSelected P� Value . . ���  � ��$
 Bold"�����  �� ItemsSource �� *
Children+.R��� ���� *Name+� -	   $��grid1��$��6,40,6,6q�$��1�� �� $
��Auto ��� $��* �.+��� -
   $��
rectangle1��
���   �$��2���� -   $��lbSelectedModuleName��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$��0������ *SelectedModuleName+�� -   $��button2��$��+ 新增模块��$��23��$
��Left=�$��1,7,0,0q�$	��Top=�$��75��$��1��&   System.Windows.Controls.DataGrid  -   $��dgModuleDetails��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��1,39,0,0q�$	��Top=�$
��Auto��   
IsReadOnly .    SelectionUnit$
 Cell=�   SelectionMode$ Extended=�$��1������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 模块名称��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ModuleName+  $ 	控件名��$
 Auto  .  �� *ControlName+  $ 可选权限��$
 Auto  .  �� *
PermOption+4	  .System.Windows.Controls.DataGridTemplateColumn	  $
 Auto  .   	  CellTemplate# [    $! Client.Properties.Resources��$ 	Operation��