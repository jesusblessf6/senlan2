   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      ;   5Client.View.SystemSetting.ModuleSetting.ModuleSetting   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$>  8Client.View.SystemSetting.ModuleSetting.ResModuleSetting��5       N� Title$ 模块设置��5
   ?    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5         ChangePermCommand  EditModuleCommand  ViewModuleCommand  DeleteModuleCommand  
ChangePerm �� DataType �� Orientation   ResxName
   Key��%O  &	        &	      &	 &     &	 9     &	 L     7   7  7  7  �� 5   
   64   �� 5   
   64   �� 5   
   64   �� 5   
   66   �� 5   
   $ DBEntity:Module��6*   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��更改权限��6   8��  $��70��5      $��20��6$   $��11(�60   ��5   U   �� *Id+5   0   �� 5      $��20��6Y   $��11(�6e   $��30��6s   8�� ��6     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��20��6Y   $��11(�6e   $��30��6s   8�� ��6     $! Client.Properties.Resources��$
 View����5      �� *Id+6;   �� 5      $��20��6[   $��11(�6g   $��30��6u   8�� $y�	Collapsed=�5   h   ��5        $! Client.Properties.Resources��$ Delete����5   H   �� *Id+6�   5      5      5       J� CommandBindings 5       )  #System.Windows.Input.CommandBinding  5!   
   -   5        	   Command#	 [  5!      5"   @     5#   
   -   5        #	 [ 5#      5$   @     5%   
   -   5        #	 [ 5%      5&   @     5'   
   -   5        #	 [ 5'      5(   B   .��5+      �� $
��Auto=�6   $
��Auto=�68   .��5,   
   � -   5        $��rootGrid��5,      
 � DataContext
 6   �� *ModuleSettingVM+ � ColumnDefinitions 5-      �� 5.      $
��Auto �6#   �� 5/      $��* �6#   .+�51      �� -   5        $��label1��51   [   $��模块管理��6   $��32��6#   $
��Left=�6/   $��6,6,0,0q�6J   $	��Top=�52      $
��Bold"�6,   $��16(�6>   �� 53      -   5        $��button1��54      $��+ 添加模块分类��53      $��1��6(   $��23��68   $
��Left=�6D   $��6,7,0,0q�6_   $	��Top=�54   $   $	��108��6<   6H   R� 55      -   5        $��tvModule��55   D   $
��Left=�6   $��6,40,0,6q�62   $
��Auto��6T   $	��150��6a   $��50��56      $��0��6&    R� SelectedValuePath$ Id��6N   ��66   �� ��58      �� 59       �� 
TargetType" Q�6   .�5:      ��  �� Property �@Q�
IsExpanded �� Value 67   �� *
IsExpanded+ �� Mode$ TwoWay=��� 5;       �@Q�
IsSelected 67   �� *
IsSelected+$ TwoWay=��� 5<       � ��$ Normal"�67    �� Triggers 5=      P� 5>       P� Property �@Q�
IsSelected P� Value . . �5?   "   ��  � ��$
 Bold"�6?   5@      5B      ��5D      �� 5E       �� ItemsSource 6/   �� *
Children+.R�5F      �� ��6$   �� *Name+5G      5I      � 5J      -	   5        $��grid1��5J   %   $��6,40,6,6q�6   $��1��62    5K      �� 5L      $
��Auto �6'   �� 5M      $��* �6'   .+�5O      �� -
   5        $��
rectangle1��5O      
���   �$��2��6=   �� 5P      -   5        $��lbSelectedModuleName��5Q      $��28��5P   ?   $
��Left=�6K   $��6,6,0,0q�6f   $	��Top=�5Q   4   $��0��6L   ��5P      �� *SelectedModuleName+5Q   L   �� 5R      -   5        $��button2��5R   b   $��+ 新增模块��6   $��23��6*   $
��Left=�66   $��1,7,0,0q�6Q   $	��Top=�5S      $��75��61   $��1��6Q   &   System.Windows.Controls.DataGrid  5T      -   5        $��dgModuleDetails��5U         AutoGenerateColumns .  $
��Auto��5T   7   $
��Left=�6E   $��1,39,0,0q�6`   $	��Top=�5U   2   $
��Auto��6J      
IsReadOnly .    SelectionUnit$
 Cell=�5V   -      SelectionMode$ Extended=�6B   $��1��6�   ��5U   W   ��    Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X      ,  &System.Windows.Controls.DataGridColumn   Header$ 模块名称��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6;      CanUserSort . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5Y   -   �� *
ModuleName+6N     5Z      $ 	控件名��6-   $
 Auto 6:    .  5[   -   �� *ControlName+6O     5\      $ 可选权限��6-   $
 Auto 6;    .  5]   -   �� *
PermOption+6N   4	  .System.Windows.Controls.DataGridTemplateColumn	  5^      $
 Auto 6u    .   	  CellTemplate# [ 5_   1    5^   1     $! Client.Properties.Resources��$ 	Operation��5_   ^   5a      5b      5d      5e      5f      