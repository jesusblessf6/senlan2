   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity -    'Client.View.Reports.LMEPositionPLReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *LMEPositionPL+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker2   ,Client.Converters.PositionDirectionConverter  DirectionConverter/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%s  &	        '�� �     '  �     &	 �     &	 �     &	 �     7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��    �� " ��.���  � �� �� *
LineType+8   .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $
��auto ��� $��* �.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *LMEPositionPL+�� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=��� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��650����  	   ResxName$!	 Client.Properties.Resources��

   Key$
 
Conditions��.��� .+��� -   $��label1��#��[  $
��Left=�$��1,10,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 	Commodity���� -   $��	comboBox1��$
��Left=�$��
107,12,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Commodities+ �� SelectedValue �� *SelectedCommodityId+�� -   $��label3��$
��Left=�#��[  $��
260,10,0,0q�$	��Top=�
���<����  *SettlementDate+  -   $��datePicker1��$
��Left=�$��
366,12,0,0q�$	��Top=�   SelectedDate �� *
SettleDate+�� -	   $��label5��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 InternalCustomer���� -
   $��	comboBox3��$
��Left=�$��
366,44,0,0q�$	��Top=�$ 	ShortName��$ Id������ *InternalCustomers+ �� *SelectedInternalCustomerId+�� -   $��button1��$��23��$
��Left=�$��
505,44,0,0q�$	��Top=�$��75����  $!	 Client.Properties.Resources��$
 Query���� -   $��label2��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Broker���� -   $��	comboBox2��$
��Left=�$��
107,44,0,0q�$	��Top=�$ 	ShortName��$ Id������ *	Brokers+ �� *SelectedBrokerId+�� -   $��label6��$��28��$��85��$
��Left=�$
��Left=�$��	6,163,0,0q�$
��Bold"�$	��Top=���  *SumByBroker+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,191,0,0q�$	��Top=�$
��Auto��   
IsReadOnly . ���� *	Summaries+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 1
  +System.Windows.Controls.DataGridBoundColumn 
  ElementStyle# [    Header   $#	 Client.View.Reports.ResReport��$
 
BrokerName�� 
  Binding �� *
BrokerName+   . $
 Auto	 # [    $#	 Client.View.Reports.ResReport��$
 DuedLockedPnL�� �� *DuedLockedPL+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z    . $
 Auto	 # [    $#	 Client.View.Reports.ResReport��$
 UnduedLockedPnL�� �� *UnduedLockedPL+# Z    . $
 Auto	 # [    $#	 Client.View.Reports.ResReport��$
 UnduedFloatPnL�� �� *UnduedFloatPL+# Z    . $
 Auto	 # [    $!	 Client.Properties.Resources��$
 Summary�� �� *SumPL+# Z �� -   $��label7��$��1��$��28��$��85��$
��Left=�$
��Left=�$��6,17,0,0q�$
��Bold"�$	��Top=���  $!	 Client.Properties.Resources��$
 Detail���� -   $��
separator2��$��17��$��6,0,6,0q�$	��Top=�$��1���� -   $��tabControl1��$��1��$
��Auto��$
��Left=�$��6,45,0,0q�$	��Top=�$
��Auto��.@��� ��  *DuedLockedPnL+.��� .+�  -   $��duedLockedGrid�� .  $
��Auto��$
��Left=�$	��Top=�$
��Auto�� . $��6,6,0,0q�����    $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 Broker�� �� *
BrokerName+  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 
PromptDate�� �� *
PromptDate+  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$	
 Lot�� �� *	LotNumber+   STR_INTEGER# Z   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 
Commission�� �� *
Commission+# Z   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 PL�� �� *	FloatPL+# Z   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 Comments�� �� *
Comments+�� -   $��tabItem2����  *UnduedLockedPnL+.��� .+�  -   $��unduedLockedGrid�� .  $
��Auto��$
��Left=�$	��Top=�$
��Auto�� . $��6,6,0,0q����� *UnduedLockedDetails+   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 Broker�� �� *
BrokerName+  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 
PromptDate�� �� *
PromptDate+  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 	TradeDate�� �� *	TradeDate+$ {0:yyyy-MM-dd}��  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$	
 Lot�� �� *	LotNumber+# Z   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 	Direction�� �� *	Direction+# [   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 Price�� �� *Price+   	STR_PRICE# Z   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 
Commission�� �� *
Commission+# Z �� -   $��tabItem3����  *UnduedFloatPnL+.��� .+�  -   $��unduedFloatGrid�� .  $
��Auto��$
��Left=�$	��Top=�$
��Auto�� . $��6,6,0,0q����� *UnduedFloatDetails+   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 Broker�� �� *
BrokerName+  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 
PromptDate�� �� *
PromptDate+  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 	TradeDate�� �� *	TradeDate+$ {0:yyyy-MM-dd}��  $
 Auto	  .  # [    $!	 Client.Properties.Resources��$	
 Lot�� �� *	LotNumber+# Z   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 	Direction�� �� *	Direction+# [   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 Price�� �� *Price+# Z   $
 Auto	  .  # [    $!	 Client.Properties.Resources��$
 
Commission�� �� *
Commission+# Z   $
 Auto	  .  # [    $#	 Client.View.Reports.ResReport��$
 LMELatestPrice�� �� *LMELastestPrice+# Z   $
 Auto	  .  # [    $#	 Client.View.Reports.ResReport��$
 FloatPnL�� �� *	FloatPL+# Z �� -   $��tabItem1����  *ClosingPnLOfSettleDate+.��� .+��� -   $��label4��$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  *ClosingPnLOfSettleDate+�� -   $��label8��$��28��$
��Left=�$��97,6,0,0q�$	��Top=�$	��160�� �� ContentStringFormat# Z 
���<������ *	ClosingPL+