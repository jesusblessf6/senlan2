   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity .    (Client.View.Reports.SHFEPositionPLReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *	SHFEPnL+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%d  &	        '�� �     '  �     &	 �     &	 �     7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� " ��.���  � �� �� *
LineType+8   .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *	SHFEPnL+�� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��800����     ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��� .+��� -   $��label1��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 	Commodity���� -   $��	comboBox1��$
��Left=�$��
366,44,0,0q�$	��Top=�
 �� DisplayMemberPath$

 Name�� �� SelectedValuePath$ Id������ *Commodities+ �� SelectedValue �� *SelectedCommodityId+�� -   $��label3��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 	StartDate��  -   $��datePicker1��$
��Left=�$��
366,12,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -   $��label4��#��[  $
��Left=�$��
519,10,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$	 EndDate��  -	   $��datePicker2��$
��Left=�$��
625,12,0,0q�$	��Top=� �� *	EndDate+�� -
   $��label5��#��[  $
��Left=�$��1,10,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$	 InternalCustomer���� -   $��	comboBox3��$
��Left=�$��
107,12,0,0q�$	��Top=�$
 	ShortName��$ Id������ *InternalCustomers+ �� *SelectedInternalCustomerId+�� -   $��button1��$��23��$
��Left=�$��
625,44,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$	 Query���� -   $��label2��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 Broker���� -   $��	comboBox2��$
��Left=�$��
107,44,0,0q�$	��Top=�$
 	ShortName��$ Id������ *	Brokers+ �� *SelectedBrokerId+�� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=��� -   $��tabControl1��$��1��$
��Auto��$
��Left=�$��	6,166,0,0q�$	��Top=�$
��Auto��.@��� ��  *
PositionPL+.��� .+�&   System.Windows.Controls.DataGrid  -   $��grid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$	��Top=�$
��Auto��   
IsReadOnly . $��0,0,0,0q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .  1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [    Header   $! Client.Properties.Resources��$	 Broker��  $
 Auto  .  # [    $! Client.Properties.Resources��$	 	Commodity�� 	  Binding �� *CommodityName+  $
 Auto  .  # [    $! Client.Properties.Resources��$	 ClosePL�� �� *
ClosePNL+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z   $
 Auto  .  # [    $# Client.View.Reports.ResReport��$	 FloatPnL�� �� *
FloatPNL+# Z   $
 Auto  .  # [    $! Client.Properties.Resources��$	 
Commission�� �� *
Commission+# Z   $
 Auto  .  # [    $! Client.Properties.Resources��$	 TotalPL�� �� *PNL+# Z  �� 
GroupStyle (  "System.Windows.Controls.GroupStyle    GroupHerderStyle   ContainerStyle# [    Panel �� .R�>  8System.Windows.Controls.Primitives.DataGridRowsPresenter  �� -   $��tabItem2����  *PositionDetail+.��� .+�  -   $��grid2�� .  $
��Auto��$
��Left=�$	��Top=�$
��Auto�� . $��0,0,0,0q�����    $
 Auto  .  # [    $! Client.Properties.Resources��$	 Broker��  $
 Auto  .  # [    $! Client.Properties.Resources��$	 SHFEContract�� �� *Alias+  $
 Auto  .  # [    $# Client.View.Reports.ResReport��$	 PullPosition�� �� *BuyQty+$ N��  $
 Auto  .  # [    $# Client.View.Reports.ResReport��$	 AveragePullPrice�� �� *
BuyPrice+$ N��  $
 Auto  .  # [    $# Client.View.Reports.ResReport��$	 PushPosition�� �� *	SellQty+$ N��  $
 Auto  .  # [    $# Client.View.Reports.ResReport��$	 AveragePushPrice�� �� *	SellPrice+$ N��  $
 Auto  .  # [    $# Client.View.Reports.ResReport��$	 LatestSettlementPrice�� �� *SettlementPrice+$ N��  $
 Auto  .  # [    $# Client.View.Reports.ResReport��$	 FloatPnL�� �� *PNL+$ N��   # [  �� .R�  