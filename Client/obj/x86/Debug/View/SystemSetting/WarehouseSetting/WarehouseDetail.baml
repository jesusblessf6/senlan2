   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      @   :Client.View.SystemSetting.WarehouseSetting.WarehouseDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      L
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$D  >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��5      $
��auto��5   a   $	��600��5	       � WindowStartupLocation$ CenterScreen=�6$    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5           ResxName$! Client.Properties.Resources��
   Key$ 	Warehouse�� � 	Resources 5
       �� 
TargetType �� Property	 �� Value   StorageFeeRuleEdit  StorageFeeRuleDelete  StorageFeeRulesActions
 �� DataType �� Orientation��%  '��       '�� �     &	      &	 -    &	 @    7   7  �� 5   
   " ��6   .�5      ��  � ��$	 28��6'   64   �� 5       � ��$		 110��6&   64   �� 5       � ��$	 Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$	 23��6'   64   �� 5       � ��$		 120��6&   64   5      �� 5   
   65   �� 5   
   67   �� 5   
   $
 DBEntity:StorageFeeRule��66   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btStorageFeeRuleEdit��6   8��  ��65     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btStorageFeeRuleDelete��6   8�� ��67     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5       5!       J� CommandBindings 5#      )  #System.Windows.Input.CommandBinding  5$   
   -   5           Command# [  5$      5%   A     5&   
   -   5        # [ 5&      5'   C   .��5*      �� $
��Auto=�6   $
��Auto=�68   .��5+   
   � -   5        $��rootGrid��5+       � RowDefinitions 5,      �� 5-      $	��195 �6    �� 5.      $��34 �6    �� 5/      $
��auto �6    �� 50      $	��55* �6    .+�52      �� -   5        $��lbTitle��52   Y   $��32��6h   $
��Left=�6t   $��6,6,0,0q�6�   $
��auto��6�   $	��Top=�53      $
��Bold"�6,   $��16(�6>   ��52        $! Client.Properties.Resources��$ 	Warehouse��53   >   �� 54      -   5        $��label2��54   A   $��6,38,0,0q�6/   
���<��$
��Left=�6d   $	��Top=�55      ��54        *	ShortName+55      �� 56      -   5        $��textBox1��56   *   $��
122,40,0,0q�6    �� 	MaxLength$ 20��6P   $
��Left=�6_   $	��Top=�57      ��56   :   �� *Name+57      �� 58      -   5        $��label3��58   @   $��6,70,0,0q�6.   $
��Left=�6N   $	��Top=�6i   ��6     *
FullName+6i   �� 59      -   5        $��textBox2��59   Q   $��23��6   $
��Left=�6"   $��
122,72,0,0q�6=   $	��Top=�6a   $	��392��5:      $ 50��6<   ��6"   �� *
FullName+6<   �� 5;      -	   5        $��label4��5;   p   $��	6,102,0,0q�6]   $
��Left=�6~   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ ContactPerson��6�   �� 5<      -
   5        $��textBox3��5<   +   $��122,104,0,0q�6   $ 20��6Z   $
��Left=�5=      $	��Top=�61   ��5<   ;   �� *ContactPerson+5=   1   �� 5>      -   5        $��label8��5>   h   $��278,102,0,0q�6S   $
��Left=�6v   $	��Top=�6�   ��6     $! Client.Properties.Resources��$	 Tel��6�   �� 5?      -   5        $��textBox7��5?   +   $��394,104,0,0q�6   $ 20��6R   $
��Left=�5@      $	��Top=�61   ��5?   ;   �� *Phone+5@   1   �� 5A      -   5        $��label5��5A   f   $��	6,134,0,0q�6S   $
��Left=�6t   $	��Top=�6�   ��6     $! Client.Properties.Resources��$	 Fax��6�   �� 5B      -   5        $��textBox4��5B   F   $
��Left=�6   $��122,136,0,0q�61   $	��Top=�6V   $ 20��5C   +   ��6   �� *Fax+6+   �� 5D      -   5        $��label1��5D   m   $��278,134,0,0q�6X   $
��Left=�6{   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ PostCode��6�   �� 5E      -   5        $��textBox8��5E   F   $
��Left=�6   $��394,136,0,0q�61   $	��Top=�6V   $ 10��5F   0   ��6   �� *
PostCode+60   �� 5G      -   5        $��label6��5G   @   $��	6,166,0,0q�6-   $
��Left=�6N   $	��Top=�6i   ��6     *	Address+6i   �� 5H      -   5        $��textBox5��5H   R   $��23��6   $
��Left=�6"   $��122,168,0,0q�6=   $	��Top=�6b   $	��392��5I      $	 200��6;   ��6"   �� *	Address+6;   �� 5J      -   5        $��label7��5J   v   $��3��6X   $��6,6,0,0q�6e   $
��Left=�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Comments��6�   �� 5K      -   5        $��textBox6��5K   Q   $	��100��6   $
��Left=�6#   $��	122,8,0,0q�6>   $	��Top=�5L      $	��392��6.    �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6b   " �� VerticalScrollBarVisibility$
 Auto=�5M      $	 200��6V   $��3��6f   ��69   �� *Description+6f   �� 5O      -   5        $
��btOK��5O   �   $��25��6X   $
��Left=�6d   $��210,123,0,0q�6   $	��Top=�5P      $��60��6-   $��3��6E   ��5O        $! Client.Properties.Resources��$ Confirm��5P   E   �� 5Q      -   5        $��btCancel��5Q   �   $��25��6W   $
��Left=�6c   $��305,123,0,0q�6~   $	��Top=�5R      $��60��6-   $��3��6G   ��5Q        $! Client.Properties.Resources��$ Cancel��5R   G   �� 5S      -   5        $��label9��5S   q   $��币种��6   
���<��$��28��66   $
��Left=�6B   $��
320,35,0,0q�6]   $	��Top=�6   $��68��6�   �� 5T      -   5        $��	comboBox1��5T   R   $��23��6   $
��Left=�6#   $��
394,35,0,0q�6>   $	��Top=�6c   $	��120��6{    �� SelectedValuePath$ Id��6�    �� DisplayMemberPath$
 Name��6�   ��6�   �� *CurrencyList+ �� SelectedValue 5U      �� *
CurrencyId+�� 5V      -   5        $��label10��5V   Z   $��	仓储费��6   $��28��6"   $
��Left=�6.   $��6,0,0,2q�6I   $��Bottom=�6i   $	��110��6�   $��1��6�   �� 5W      -   5        $��button1��5W   i   $��新增��6   $��23��6"   $��1��6.   $
��Left=�6;   $��	122,0,0,6q�6V   $��Bottom=�6x   $��45��6�   6�   &   System.Windows.Controls.DataGrid  5X      -   5        $��	dataGrid1��5X   �      AutoGenerateColumns .  $
��auto��63   $��2��6A   $
��Left=�6f   $��	122,0,0,0q�6�   $��Bottom=�6�   $
��auto��6�      
IsReadOnly . ��6N   ��    Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$ 金属��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Commodity.Name+6Z     5[      $ 开始日期��6)    67   �� *	StartDate+ �� StringFormat$ 
yyyy/MM/dd��6q     5\      $ 结束日期��6)    67   �� *	EndDate+$ 
yyyy/MM/dd��6o     5]      $ 仓租单价��6)    67   �� *PricePerUnit+$   DBEntity.EnumEntity.RoundRules   	STR_PRICE# Z 6�     5^      $ 货权转移费��6)    68   �� *TransferFee+# Z 6�     5_      $ 	仓单费��6)    66   �� *
WarrantFee+# Z 6�   4	  .System.Windows.Controls.DataGridTemplateColumn	  5`         Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 6q      CanUserSort .    	  CellTemplate#  [ 5a   )    5`   -     $! Client.Properties.Resources��$ 	Operation��5a   b   5c      5d      5e      5f      