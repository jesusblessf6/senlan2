   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  S OZedGraph, Version=5.1.5.28844, Culture=neutral, PublicKeyToken=02a83cbd123fcd605(clr-namespace:ZedGraph;assembly=ZedGraphZedGraph A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity /   )Client.View.Reports.ForwardPositionReport   WwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  5zedgraph(clr-namespace:ZedGraph;assembly=ZedGraph  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     6
Convertersclr-namespace:Client.Converters     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ExposureTrend+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value2  ,Client.Converters.PositionDirectionConverter  PositionDirectionConverter��%�   &	        '�� �     &	 �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120��  .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$��远期头寸分布��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(��� -   $��tabControl1��$	��667��$
��Left=�$��6,40,0,0q�$	��Top=�$	��764��.@��� -   $��tabItem1��$��	LME头寸��.��� .+��� -   $��	groupBox1��$	��100��$
��Left=�$��6,12,0,0q�$	��Top=�$	��700����     ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��� .+��� -   $
��lbl1��$��内部客户��$
��Left=�$��1,10,0,0q�$	��Top=�#��[  �� -   $��	comboBox1��$
��Left=�$��
107,12,0,0q�$	��Top=�
 �� SelectedValuePath$
 Id�� �� DisplayMemberPath$ 	ShortName������ *InternalCustomerList+ �� SelectedValue �� *SelectedInternalID+�� -   $
��lbl2��$��	经纪行��$
��Left=�$��
260,10,0,0q�$	��Top=�#��[  �� -	   $��	comboBox2��$
��Left=�$��
366,12,0,0q�$	��Top=�$
 Id��$ 	ShortName������ *
BrokerList+ �� *SelectedBrokerID+�� -
   $��button1��$��查询��$��23��$
��Left=�$��
366,44,0,0q�$	��Top=�$��75���� -   $��label2��$��金属��
���<��$��28��$
��Left=�$��1,42,0,0q�$	��Top=�#��[  �� -   $��	comboBox3��$
��Left=�$��
107,44,0,0q�$	��Top=�$
 Id��$
 Name������ *CommodityList+ �� *SelectedCommodityID+�� -   $��
separator1��$��17��$��	6,115,6,0q�$	��Top=�7   1System.Windows.Forms.Integration.WindowsFormsHost  $��	6,135,0,0q�$	��742��$
��Left=�$	��280��$	��Top=�   Child.   ZedGraph.ZedGraphControl  -   zedGraphControlLine���� -   $��
separator2��$��17��$��	6,418,6,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��auto��$
��Left=�$��	6,438,0,0q�$	��Top=�$
��auto��  DataGridStyle#��[   DataGridRowStyle   RowStyle# [    
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	到期日��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *
PromptDate+ �� StringFormat$ 
yyyy/MM/dd��  $ 	交易日�� �� *	TradeDate+$ 
yyyy/MM/dd��  $ 手数�� �� *	LotNumber+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY# Z   $ 价格�� �� *Price+ 
  	STR_PRICE# Z   $ 交易方向�� �� *	Direction+ �� 	Converter# [   $ 	经纪行�� �� *
BrokerName+  $ 内部客户�� �� *InternalCustomerName+�� -   $��tabItem2��$��
SHFE头寸��.��� .+��� -   $��	groupBox2��$	��100��$
��Left=�$��6,12,0,0q�$	��Top=�$	��700����  $! Client.Properties.Resources��$	 
Conditions��.��� .+��� -   $
��lbl3��$��内部客户��$
��Left=�$��1,10,0,0q�$	��Top=�#��[  �� -   $��	comboBox4��$
��Left=�$��
107,12,0,0q�$	��Top=�$
 Id��$ 	ShortName������ *InternalCustomerList+ �� *SelectedInternalID1+�� -   $
��lbl4��$��	经纪行��$
��Left=�$��
260,10,0,0q�$	��Top=�#��[  �� -   $��	comboBox5��$
��Left=�$��
366,12,0,0q�$	��Top=�$
 Id��$ 	ShortName������ *
BrokerList+ �� *SelectedBrokerID1+�� -   $��button2��$��查询��$��23��$
��Left=�$��
366,44,0,0q�$	��Top=�$��75���� -   $��label3��$��金属��
���<��$��28��$
��Left=�$��1,42,0,0q�$	��Top=�#��[  �� -   $��	comboBox6��$
��Left=�$��
107,44,0,0q�$	��Top=�$
 Id��$
 Name������ *CommodityList+ �� *SelectedCommodityID1+�� -   $��
separator3��$��17��$��	6,115,6,0q�$	��Top=�  $��	6,135,0,0q�$	��742��$
��Left=�$	��280��$	��Top=�.   -   zedGraphControlLine1���� -   $��
separator4��$��17��$��	6,418,6,0q�$	��Top=�  -   $��	dataGrid2�� .  $
��auto��$
��Left=�$��	6,438,0,0q�$	��Top=�$
��auto��#��[ # [  . ����    $ 合约�� �� *Alias+  $ 	交易日��   
Visibility$ Hidden=� �� *	TradeDate+$ 
yyyy/MM/dd��  $ 手数�� �� *Qty+# Z   $ 价格�� �� *Price+# Z   $ 交易方向�� �� *PositionDerection+# [   $ 	经纪行�� �� *
BrokerName+  $ 内部客户�� �� *InternalName+