   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   4   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      E   ?Client.View.SystemSetting.WarehouseSetting.WarehouseSettingHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   4   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$D  >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *WarehouseSettingHome+ � 	Resources 5         WarehouseEdit  WarehouseDelete  WarehouseView  WarehouseActions �� DataType �� Orientation   ResxName
   Key  WarehouseNameLink �� Command	 �� CommandParameter��%�  &	        &	      &	 &     &	 9     7   7  &	 �    7  �� 5   
   60   �� 5   
   62   �� 5   
   60   �� 5   
   $ DBEntity:Warehouse��60   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btWarehouseEdit��6   8��  ��60     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btWarehouseDelete��6   8�� ��62     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5      �� 5   
   $ DBEntity:Warehouse��61   .R�5      �� �� 5      8   	 6E   �� *Id+.�6e   .�5      �� �6   �� *Name+62   5      5       5!      5#      
 J� CommandBindings
 5%      )  #System.Windows.Input.CommandBinding  5&   
   -   5           Command# [  5&      5'   <     5(   
   -   5        # [ 5(      5)   >     5*   
   -   5        # [ 5*      5+   <   .��5.      �� $
��Auto=�6   $
��Auto=�68   .��5/   
   � -   5         �Name$ rootGrid��5/      .+�50      �� -   5        $��label1��51   L   $��32��50   :   $
��Left=�6F   $��6,6,0,0q�6a   $
��auto��6r   $	��Top=�51      $
��Bold"�6,   $��16(�6>   ��50        *WarehouseSettingHome+51   L   �� 52      -   5        $��button1��52   �   $��23��6^   $
��Left=�6j   $��6,40,0,0q�6�   $	��Top=�53      $��60��6-   ��52        $! Client.Properties.Resources��$ AddWithSymbol��53   8   $   Utility.Controls.PagingControl  55      -   5        $��pagingControl1��55   M   $
��Left=�6   $��	6,100,0,0q�6:   $	��Top=�56      &   System.Windows.Controls.DataGrid  57      -   5        $��	dataGrid1��58         AutoGenerateColumns .  $
��Auto��57   3   $
��Left=�6A   $��	6,137,0,0q�6\   $	��Top=�58   (   $
��Auto��6@      
IsReadOnly . ��6M   ��    Columns 5:      4  .System.Windows.Controls.DataGridTemplateColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�      CanUserSort .    SortMemberPath$
 Name��6�      CellTemplate# [ 5<   -      Header 5;   -     $D >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��$ 	ShortName��5<   a   0	  *System.Windows.Controls.DataGridTextColumn	  5=      $
 Auto 6�    .  6)     $D >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��$ FullName��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6�   �� *
FullName+6�   	  5>      $
 Auto 6�    .  6)     $D >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��$ Address�� 6�   �� *	Address+6�   	  5?      $
 Auto 6q    .  6)     $! Client.Properties.Resources��$ ContactPerson�� 6�   �� *ContactPerson+6�   	  5@      $
 Auto 6g    .  6)     $! Client.Properties.Resources��$	 Tel�� 6�   �� *Phone+6�   	  5A      $
 Auto 6g    .  6)     $! Client.Properties.Resources��$	 Fax�� 6�   �� *Fax+6�   	  5B      $
 Auto 6l    .  6)     $! Client.Properties.Resources��$ PostCode�� 6�   �� *
PostCode+6�   	  5C      $
 Auto 6l    .  6)     $! Client.Properties.Resources��$ Comments�� 6�   �� *Description+6�     5D      $
 Auto 6q    .  # [ 5E   -    5D   -     $! Client.Properties.Resources��$ 	Operation��5E   `   5G      �� 5H      -	   5        $��label2��5H   ]   $��仓库简称��6   $��28��6#   $
��Left=�6/   $��	10,70,0,0q�6J   $	��Top=�6k   �� 5I      -
   5        $��textBox1��5I   P   $��23��6   $
��Left=�6"   $��	80,72,0,0q�6=   $	��Top=�6`   $	��120��6x   ��6�   �� *	ShortName+�� 5J      -   5        $��button2��5J   ]   $��查询��6   $��23��6"   $
��Left=�6.   $��
210,72,0,0q�6I   $	��Top=�6l   $��65��6�   6�   5K      5L      5M      