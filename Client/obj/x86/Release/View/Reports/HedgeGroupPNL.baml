   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity '    !Client.View.Reports.HedgeGroupPNL   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     5base$clr-namespace:Client.Base.BaseClient     >my/clr-namespace:Utility.Controls;assembly=Utility     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity       N� Title$  HedgeGroupPNL�� � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker.   (Client.Converters.ArbitrageTypeConverter  ArbitrageConverter1   +Client.Converters.HedgeGroupStatusConverter  HGStatusConverter��%0  &	        '�� �     '  �     &	 �     &	 �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��    .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��分组保值盈亏明细��$��32��$
��Bold"�$��16(�$
��Left=�$��6,6,0,0q�$	��Top=��� -   $��	groupBox1��$��查询条件��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��691��.��� .+��� -   $��label2��$��起始日期��#��[  $
��Left=�$��1,10,0,0q�$	��Top=�  -   $��datePicker1��$
��Left=�$��
107,12,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -   $��label3��$��结束日期��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=�  -   $��datePicker2��$
��Left=�$��
366,12,0,0q�$	��Top=� �� *	EndDate+�� -   $��label4��$��保值类型��#��[  $
��Left=�$��1,42,0,0q�$	��Top=��� -	   $��	comboBox1��$
��Left=�$��
107,44,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *
HedgeTypes+ �� SelectedValue �� *SelectedHedgeTypeId+�� -
   $��label5��$��结算状态��$��28��$
��Left=�$��
302,42,0,0q�$	��Top=��� -   $��	comboBox2��$��23��$
��Left=�$��
366,44,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *HedgeStatuses+ �� *SelectedHedgeStatusId+�� -   $��button1��$��查询��$��23��$
��Left=�$��
504,44,0,0q�$	��Top=�$��75���� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=�$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��	6,163,0,0q�$	��Top=�$��31��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��	   AutoGenerateColumns	 .  
   
IsReadOnly
 . $
��Auto��$
��Left=�$��	6,200,0,0q�$	��Top=�$
��Auto������ *Lines+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 分组名称��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort . 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Name+  $ 保值日期��$
 Auto  .  �� *	HedgeDate+ �� StringFormat$ {0:yyyy-MM-dd}��  $ 保值类型��$
 Auto  .  �� *HedgeTypeId+ �� 	Converter# [   $ 结算状态��$
 Auto  .  �� *HedgeStatusId+# [   $ 保本基差��$
 Auto  .  �� *BreakEvenSpread+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT# Z   $ 现货锁定盈亏(CNY)��$
 Auto  .  �� *PhysicalFixedPNL+# Z   $ 现货浮动盈亏(CNY)��$
 Auto  .  �� *PhysicalFloatPNL+# Z   $ SHFE锁定盈亏(CNY)��$
 Auto  .  �� *SHFEFixedPNL+# Z   $ SHFE浮动盈亏(CNY)��$
 Auto  .  �� *SHFEFloatPNL+# Z   $ LME锁定盈亏(USD)��$
 Auto  .  �� *LMEFixedPNL+# Z   $ LME浮动盈亏(USD)��$
 Auto  .  �� *LMEFloatPNL+# Z   $ 总盈亏(CNY)��$
 Auto  .  �� *
TotalPNL+# Z 