   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5   ,   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      ;    5Client.View.Physical.WarehouseOuts.WarehouseOutDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5   ,   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *WarehouseOut+ � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker+   %Client.Converters.IsVerifiedConverter   IsVerifiedConverter  WarehouseOutLineEdit  WarehouseOutLineDelete  WarehouseOutLineActions �� DataType �� Orientation	   ResxName

   Key��%�  '��       '�� �     '  m    &	  �    &	 �    &	 
    &	     7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5!   
   6)   �� 5#   
   67   �� 5$   
   69   �� 5&   
   $ DBEntity:WarehouseOutLine��67   .R�5'      �� $ 
Horizontal=�6   .+�5(      �� $��btWarehouseOutLineEdit��6   8��  ��67     $!	 Client.Properties.Resources��$

 Edit����5)      �� *Id+6;   �� 5*      $��btWarehouseOutLineDelete��6   8�� ��69     $!	 Client.Properties.Resources��$
 Delete����5+      �� *Id+6;   5,      5-      5.       J� CommandBindings 50      )  #System.Windows.Input.CommandBinding  51   
   -   5           Command# [ 51      52   C     53   
   -   5        # [ 53      54   E   .��57      �� $
��Auto=�6   $
��Auto=�68   .��58   
   � -   5         �Name$ rootGrid��58       � RowDefinitions 59      �� 5:      $
��auto �6    �� 5;      $
��auto �6    �� 5<      $
��auto �6    �� 5=      $	��55* �6    .+�5@      �� -   5        $��button1��5@   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,40,0,0q�6J   $	��Top=�5A      $��25��6-   {�6M   �� *IsQuotaEnable+ � ToolTip 6r   �� *ContractInfo+�� 5B      -   5        $��button2��5B   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,72,0,0q�6J   $	��Top=�5C      $��25��6-   {�6M   �� *IsWarehouseEnable+  5D      -   5        $��datePicker1��5D   H   $
��Left=�6   $��
394,40,0,0q�64   $	��Top=�6[      SelectedDate 5E      �� *WarehouseOutDate+�� 5F      -   5        $��button3��5F   �   $��23��6^   $
��Left=�6j   $��	122,2,0,7q�6�   $	��Top=�5G      $��45��6-   $��1��6M   ��5F        $!	 Client.Properties.Resources��$
 AddWithSymbol��5G   M   �� 5H      -   5        $��textBox3��5H   Q   $	��100��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   $	��392��5I       �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6J   " �� VerticalScrollBarVisibility$
 Auto=�6^   $��3��5J   /   ��6   �� *	Comment+6/   �� 5K      -	   5        $��button6��5K   �   $��23��6U   $
��Left=�6a   $��210,130,0,0q�6|   $	��Top=�5L      $��60��6-   $��3��6M   ��5K        $!	 Client.Properties.Resources��$

 Save��5L   M   �� 5M      -
   5        $��button4��5N      $��23��5M   \   $
��Left=�6h   $��278,130,0,0q�6�   $y�Hidden=�6�   $	��Top=�5N   $   $��60��6<   $��3��6G   ��5M        $!	 Client.Properties.Resources��$
 SaveAsDraft��5N   G   �� 5O      -   5        $��button5��5O   �   $��23��6W   $
��Left=�6c   $��305,130,0,0q�6~   $	��Top=�5P      $��60��6-   $��3��6M   ��5O        $!	 Client.Properties.Resources��$
 Cancel��5P   M   �� 5R      -   5        $��lbTitle��5R   o   $��6,6,0,0q�62   $��16(�6C   $
��Bold"�6Q   $��32��6c   $	��Top=�5S      $
��Left=�6,   $
��Left=�6G   $
��auto��6j   ��5R        *WarehouseOut+5S   j   �� 5T      -   5        $��label2��5T   �   
���<��$
��Left=�6j   $��6,38,0,0q�6�   $	��Top=�5U      ��5T        $!	 Client.Properties.Resources��$
 Quota��5U      �� 5V      -   5        $��textBox1��5V   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   {�.  ��5W      �� *	QuotaNo+6/   �� 5Y      -   5        $��label3��5Y   e   $
��Left=�66   $��
278,38,0,0q�6Q   $	��Top=�6s   ��6     *WarehouseOutDate+6s   �� 5[      -   5        $��label4��5[   �   
���<��$
��Left=�6n   $��6,70,0,0q�6�   $	��Top=�5\      ��5[        $!	 Client.Properties.Resources��$
 	Warehouse��5\      �� 5]      -   5        $��textBox2��5]   E   $
��Left=�6   $��
122,72,0,0q�61   $	��Top=�6U   {�.  ��5^      �� *WarehouseName+65   &   System.Windows.Controls.DataGrid  5a      -   5        $��	dataGrid1��5b         AutoGenerateColumns .     
IsReadOnly . $
��Left=�5a   E   $��	122,2,0,7q�6`   $
��auto��6s   $
��auto��6�   $	��Top=�5b   @   $   HorizontalScrollBarVisibility$
 Auto=�6X   $��2��6}   ��6(   ��    Columns 5c      0  *System.Windows.Controls.DataGridTextColumn  5d      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6j      CanUserSort .    Header 6)     $!	 Client.Properties.Resources��$
 CardNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5e   )   �� *WarehouseInLine.PBNo+6T     5f      $
 Auto	 6m    .  6)     $!	 Client.Properties.Resources��$
 	Commodity�� 5g   )   �� *<:WarehouseInLine.DeliveryLine.Delivery.Quota.Commodity.Name+6z     5h      $
 Auto	 6q    .  6)     $!	 Client.Properties.Resources��$
 CommodityType�� 6�   �� *CommodityType.Name+6�     5i      $
 Auto	 6i    .  6)     $!	 Client.Properties.Resources��$
 Brand�� 6�   �� *
Brand.Name+6�     5j      $
 Auto	 6l    .  6)     $!	 Client.Properties.Resources��$
 Quantity�� 5k   )   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�     5l      $
 Auto	 6r    .  6)     $!	 Client.Properties.Resources��$
 ActualQuantity�� 5m   )   �� *VerifiedQuantity+# Z 6�     5n      $
 Auto	 6j    .  6)     $!	 Client.Properties.Resources��$
 Bundle�� 5o   )   �� *PackingQuantity+# Z 6�     5p      $
 Auto	 6s    .  6)     $!	 Client.Properties.Resources��$
 QuantityConfirm�� 5q   )   �� *
IsVerified+ �� 	Converter# [  6{   4  .System.Windows.Controls.DataGridTemplateColumn  5r      $
 Auto	 6q    .      CellTemplate#  [ 5s   -    5r   -     $!	 Client.Properties.Resources��$
 	Operation��5s   g   5u      �� 5v      -   5        $��label5��5v   �   $
��Left=�6X   $��6,0,0,0q�6s   $	��Top=�6�   $��3��5w      ��5v        $!	 Client.Properties.Resources��$
 Comments��5w      �� 5x      -   5        $��label6��5x   o   $��1��66   $
��Left=�6C   $��6,0,0,0q�6^   $	��Top=�5y      ��5x        *WarehouseOutLine+5y      �� 5z      -   5        $��label7��5z   �   $
��Left=�6^   $��
278,70,0,0q�6y   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 WarehouseOutNo��6�   �� 5{      -   5        $��textBox4��5{   W   $
��Left=�6   {�.  $��
394,72,0,0q�6C   $	��Top=�6g   ��6   �� *WarehouseOutNo+�� 5|      -   5        $��label8��5|   ^   $��实际提货人��6   $��28��6$   $
��Left=�60   $��	6,102,0,0q�6K   $	��Top=�6l   $	��110��6�   �� 5}      -   5        $��textBox5��5}   F   $
��Left=�6   $��122,104,0,7q�61   $	��120��6V   $	��Top=�6�   {�.  ��6b   �� *BusinessPartnerName+6�   �� 5~      -   5        $��button7��5~   _   $	��...��6   $��23��6#   $
��Left=�6/   $��246,104,0,7q�6J   $	��Top=�6n   $��25��6�   6�   5      5�      5�      