   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5
      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      '    !Client.View.Reports.HedgeGroupPNL   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      5base$clr-namespace:Client.Base.BaseClient     5	      >my/clr-namespace:Utility.Controls;assembly=Utility     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5        N� Title$  HedgeGroupPNL��5
       � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker.   (Client.Converters.ArbitrageTypeConverter  ArbitrageConverter1   +Client.Converters.HedgeGroupStatusConverter  HGStatusConverter��%<  &	        '�� �     '  m    &	 �    &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5!   
   6@     5"   
   6B   5#      .��5&      �� $
��Auto=�6   $
��Auto=�66   .��5'   
   � -   5        $��rootGrid��5'      .+�5(      �� -   5        $��lbTitle��5(      $��分组保值盈亏明细��6   $��32��6'   $
��Bold"�63   $��16(�6E   $
��Left=�6S   $��6,6,0,0q�6n   $	��Top=�6�   �� 5)      -   5        $��	groupBox1��5)   _   $��查询条件��6   $	��100��6%   $
��Left=�62   $��6,40,0,0q�6M   $	��Top=�6p   $	��691��6�   .��5*      � .+�5+      �� -   5        $��label2��5+   |   $��起始日期��6   #��[  6+   $
��Left=�6O   $��1,10,0,0q�6j   $	��Top=�6�     5,      -   5        $��datePicker1��5,   P   $
��Left=�6!   $��
107,12,0,0q�6<   $	��Top=�6c      SelectedDate 6{   �� *	StartDate+�� 5-      -   5        $��label3��5-   ~   $��结束日期��6   #��[  6+   $
��Left=�6O   $��
260,10,0,0q�6j   $	��Top=�6�     5.      -   5        $��datePicker2��5.   P   $
��Left=�6!   $��
366,12,0,0q�6<   $	��Top=�6c    6|   �� *	EndDate+�� 5/      -   5        $��label4��5/   |   $��保值类型��6   #��[  6+   $
��Left=�6O   $��1,42,0,0q�6j   $	��Top=�6�   �� 50      -	   5        $��	comboBox1��50   N   $
��Left=�6   $��
107,44,0,0q�6:   $	��Top=�6_    �� DisplayMemberPath$
 Name��51   B    �� SelectedValuePath$ Id��6[   ��6   �� *
HedgeTypes+ �� SelectedValue 6r   �� *SelectedHedgeTypeId+�� 52      -
   5        $��label5��52   f   $��结算状态��6   $��28��6+   $
��Left=�67   $��
302,42,0,0q�6R   $	��Top=�6t   �� 53      -   5        $��	comboBox2��53   Z   $��23��6   $
��Left=�6+   $��
366,44,0,0q�6F   $	��Top=�6k   $	��120��6�   $
 Name��54   E   $ Id��6^   ��6   �� *HedgeStatuses+ 6u   �� *SelectedHedgeStatusId+�� 55      -   5        $��button1��55   e   $��查询��6   $��23��6*   $
��Left=�66   $��
504,44,0,0q�6Q   $	��Top=�6t   $��75��6�   6�   56      57      �� 58      -   5        $��
separator1��58   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   $  Utility.Controls.PagingControl  59      -   5        $��pagingControl1��59   M   $
��Left=�6   $��	6,163,0,0q�6:   $	��Top=�6c   $��31��6{   &   System.Windows.Controls.DataGrid  5:      -   5        $��	dataGrid1��5:   �   	   AutoGenerateColumns	 .  
   
IsReadOnly
 . $
��Auto��6_   $
��Left=�6m   $��	6,200,0,0q�6�   $	��Top=�6�   $
��Auto��6�   ��6�   �� *Lines+   Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ 分组名称��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 67      CanUserSort . 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6W   �� *Name+6r     5=      $ 保值日期��6)   $
 Auto 67    .  6W   �� *	HedgeDate+ �� StringFormat$ {0:yyyy-MM-dd}��6�     5>      $ 保值类型��6)   $
 Auto 67    .  6W   �� *HedgeTypeId+ �� 	Converter# [ 6�     5?      $ 结算状态��6)   $
 Auto 67    .  6W   �� *HedgeStatusId+# [ 6�     5@      $ 保本基差��6)   $
 Auto 67    .  6W   �� *BreakEvenSpread+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT# Z 6�     5A      $ 现货锁定盈亏(CNY)��6)   $
 Auto 6>    .  6^   �� *PhysicalFixedPNL+# Z 6�     5B      $ 现货浮动盈亏(CNY)��6)   $
 Auto 6>    .  6^   �� *PhysicalFloatPNL+# Z 6�     5C      $ SHFE锁定盈亏(CNY)��6)   $
 Auto 6@    .  6`   �� *SHFEFixedPNL+# Z 6�     5D      $ SHFE浮动盈亏(CNY)��6)   $
 Auto 6@    .  6`   �� *SHFEFloatPNL+# Z 6�     5E      $ LME锁定盈亏(USD)��6)   $
 Auto 6?    .  6_   �� *LMEFixedPNL+# Z 6�     5F      $ LME浮动盈亏(USD)��6)   $
 Auto 6?    .  6_   �� *LMEFloatPNL+# Z 6�     5G      $ 总盈亏(CNY)��6)   $
 Auto 6;    .  6[   �� *
TotalPNL+# Z 6�   5I      5K      5L      5M      