   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity ,    &Client.View.Reports.SHFEFundFlowReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     >my/clr-namespace:Utility.Controls;assembly=Utility     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity       N� Title$  SHFE出入金明细�� � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%  &	        '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$��SHFE出入金明细��$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(�$
��Left=��� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��600����0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ 
Conditions��.��� .+��� -   $��button2��$��23��$
��Left=�$��
505,44,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��label5��$
��Left=�$��1,42,0,0q�#��[  $	��Top=���  $! Client.Properties.Resources��$ 	StartDate��  -   $��datePicker1��$
��Left=�$��
107,44,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -   $��label6��$
��Left=�$��
260,42,0,0q�#��[  $	��Top=���  $! Client.Properties.Resources��$ EndDate��  -   $��datePicker2��$
��Left=�$��
366,44,0,0q�$	��Top=� �� *	EndDate+�� -	   $��label2��$
��Left=�$��1,10,0,0q�#��[  $	��Top=���  $! Client.Properties.Resources��$ Broker���� -
   $��	comboBox2��	 �� DisplayMemberPath$	 	ShortName��$
��Left=�$��
107,12,0,0q�
 �� SelectedValuePath$
 Id��$	��Top=����� *	Brokers+ �� SelectedValue �� *SelectedBrokerId+�� -   $��label3��$
��Left=�$��
260,10,0,0q�#��[  $	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox1��$	 	ShortName��$
��Left=�$��
366,12,0,0q�$
 Id��$	��Top=�$	��120������ *InnerCustomer+ �� *SelectedInnerCustomer+�� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=�$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��	6,163,0,0q�$��31��$	��Top=�&   System.Windows.Controls.DataGrid  -   $��dataGridSHFEFundFlow��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,200,0,0q�$	��Top=�$
��Auto��   CanUserAddRows .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 发生日期��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	TradeDate+ �� StringFormat$ 
yyyy-MM-dd��  $ 入金�� �� *
AmountIn+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT# Z   $ 出金�� �� *	AmountOut+# Z   $ 方式�� �� *Type+  $ 摘要�� �� *
Abstract+     $! Client.Properties.Resources��$ Broker�� �� *-+SHFECapitalDetail.BusinessPartner.ShortName+     $! Client.Properties.Resources��$ InternalCustomer�� �� *.,SHFECapitalDetail.BusinessPartner1.ShortName+