   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5   U   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      9    3Client.View.Physical.WarehouseIns.WarehouseInDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5   U   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$6  0Client.View.Physical.WarehouseIns.ResWarehouseIn��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5           ResxName$! Client.Properties.Resources��
   Key$ WarehouseIn�� � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker+   %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseInLineEdit  WarehouseInLineDelete  WarehouseInLineActions	 �� DataType
 �� Orientation��%�  '��       '�� �     '  m    &	  �    &	 �    &	 
    &	     7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5    
   6)   �� 5"   
   66   �� 5#   
   68   �� 5%   
   $	 DBEntity:WarehouseInLine��66   .R�5&      �� $
 
Horizontal=�6   .+�5'      �� $��btWarehouseInLineEdit��6   8��  ��66     $! Client.Properties.Resources��$
 Edit����5(      �� *Id+6;   �� 5)      $��btWarehouseInLineDelete��6   8�� ��68     $! Client.Properties.Resources��$ Delete����5*      �� *Id+6;   5+      5,      5-       J� CommandBindings 5/      )  #System.Windows.Input.CommandBinding  50   
   -   5           Command# [ 50      51   B     52   
   -   5        # [ 52      53   D   .��56      �� $
��Auto=�6   $
��Auto=�68   .��57   
   � -   5         �Name$ rootGrid��57       � RowDefinitions 58      �� 59      $
��Auto �6    �� 5:      $��32 �6    �� 5;      $
��auto �6    �� 5<      $	��55* �6    .+�5?      �� -   5        $��button2��5?   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,72,0,0q�6J   $	��Top=�5@      $��25��6-   {�6M   �� *IsWarehouseEnable+  5A      -   5        $��datePicker1��5A   H   $
��Left=�6   $��
394,40,0,0q�64   $	��Top=�6[      SelectedDate 5B      �� *WarehouseInDate+�� 5C      -   5        $��btWarehouseInLineAdd��5C   �   $��23��6^   $
��Left=�6j   $��	122,2,0,7q�6�   $	��Top=�5D      $��45��6-   $��1��6Z   ��5C        $! Client.Properties.Resources��$ AddWithSymbol��5D   Z   �� 5E      -   5        $��textBox1��5E   Q   $	��100��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   $	��392��5F       �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6J   " �� VerticalScrollBarVisibility$
 Auto=�6^   $��3��5G   /   ��6   �� *	Comment+6/   �� 5H      -   5        $��button1��5H   �   $��23��6U   $
��Left=�6a   $��210,130,0,0q�6|   $	��Top=�5I      $��60��6-   $��3��6M   ��5H        $! Client.Properties.Resources��$
 Save��5I   M   �� 5J      -	   5        $��button4��5K      $��23��5J   \   $y�Hidden=�6h   $
��Left=�6|   $��419,130,0,0q�6�   $	��Top=�5K   $   $��60��6<   $��3��6G   ��5J        $! Client.Properties.Resources��$ SaveAsDraft��5K   G   �� 5L      -
   5        $��button3��5L   �   $��23��6W   $
��Left=�6c   $��305,130,0,0q�6~   $	��Top=�5M      $��60��6-   $��3��6M   ��5L        $! Client.Properties.Resources��$ Cancel��5M   M   �� 5O      -   5        $��lbTitle��5O   �   $��6,6,0,0q�6[   $��16(�6l   $
��Bold"�6z   $��32��6�   $	��Top=�6�   $
��Left=�6�   $
��Left=�6�   $
��auto��6�   ��6     $! Client.Properties.Resources��$ WarehouseIn��6�   �� 5P      -   5        $��label3��5P   d   $
��Left=�65   $��
278,38,0,0q�6P   $	��Top=�6r   $��2��6�   ��6     *WarehouseInDate+6�   �� 5Q      -   5        $��label4��5Q   �   $
��Left=�6Y   $��6,70,0,0q�6t   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ 	Warehouse��5R      &   System.Windows.Controls.DataGrid  5S      -   5        $��	dataGrid1��5T         AutoGenerateColumns .     
IsReadOnly . $
��Left=�5S   E   $��	122,2,0,7q�6`   $
��auto��6s   $
��auto��6�   $	��Top=�5T   @   $   HorizontalScrollBarVisibility$
 Auto=�6X   $��2��6}   ��6(   ��    Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6j      CanUserSort .    Header 6)     $! Client.Properties.Resources��$ CardNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6�   �� *PBNo+6�     5W      $
 Auto	 6m    .  6)     $! Client.Properties.Resources��$ 	Commodity�� 5X   )   �� *,*DeliveryLine.Delivery.Quota.Commodity.Name+6j     5Y      $
 Auto	 6h    .  6)     $! Client.Properties.Resources��$
 Type�� 6�   �� *CommodityType.Name+6�     5Z      $
 Auto	 6i    .  6)     $! Client.Properties.Resources��$ Brand�� 6�   �� *
Brand.Name+6�     5[      $
 Auto	 6l    .  6)     $! Client.Properties.Resources��$ Quantity�� 5\   )   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�     5]      $
 Auto	 6r    .  6)     $! Client.Properties.Resources��$ ActualQuantity�� 5^   )   �� *VerifiedQuantity+# Z 6�     5_      $
 Auto	 6j    .  6)     $! Client.Properties.Resources��$ Bundle�� 5`   )   �� *PackingQuantity+# Z 6�     5a      $
 Auto	 6s    .  6)     $! Client.Properties.Resources��$ QuantityConfirm�� 5b   )   �� *
IsVerified+ �� 	Converter# [  6z   4  .System.Windows.Controls.DataGridTemplateColumn  5c      $
 Auto	 6q    .     CellTemplate# [ 5d   -    5c   -     $! Client.Properties.Resources��$ 	Operation��5d   f   5f      �� 5g      -   5        $��textBox3��5g   E   $
��Left=�6   $��
122,72,0,7q�61   $	��Top=�6U   {�.  ��5h      �� *WarehouseName+65   �� 5j      -   5        $��label2��5j   �   $
��Left=�6X   $��6,0,0,0q�6s   $	��Top=�6�   $��3��5k      ��5j        $! Client.Properties.Resources��$ Comments��5k      �� 5l      -   5        $��label5��5l   n   $��1��65   $
��Left=�6B   $��6,0,0,0q�6]   $	��Top=�5m      ��5l        *WarehouseInLine+5m      �� 5n      -   5        $��label1��5n   Z   $��金属��6   $��28��6!   $
��Left=�6-   $��6,38,0,0q�6H   $	��Top=�6h   $	��110��6�   
���<��6�   �� 5o      -   5        $��	comboBox1��5o   R   $��23��6   $
��Left=�6#   $��
122,40,0,0q�6>   $	��Top=�6c   $	��120��6{     �� SelectedValuePath$  Id��6�   ! �� DisplayMemberPath$
! Name��6�   ��6�   �� *CommodityList+" �� SelectedValue" 6�   �� *SelectedCommodityId+5p      5q      5r      