   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5   	   S OZedGraph, Version=5.1.5.28844, Culture=neutral, PublicKeyToken=02a83cbd123fcd605(clr-namespace:ZedGraph;assembly=ZedGraphZedGraph 5   	   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
   	   5clr-namespace:Client.ConvertersClient.Converters 5   	   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5   	   /   )Client.View.Reports.ForwardPositionReport   5      WwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  5   	   5zedgraph(clr-namespace:ZedGraph;assembly=ZedGraph  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5	   	   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
   	   6
Convertersclr-namespace:Client.Converters     5   	   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5   	   0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5   	    � Language 5   	   5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *ExposureTrend+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value2  ,Client.Converters.PositionDirectionConverter  PositionDirectionConverter��%�  &	        '�� �     &	 m    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5   
   60   5      .��5!      �� $
��Auto=�6   $
��Auto=�68   .��5"   
   � -   5         �Name$ rootGrid��5"      .+�5#      �� -   5        $��lbTitle��5#   �   $��远期头寸分布��6   $
��Left=�6%   $��6,6,0,0q�6@   $��32��6Q   $	��Top=�6]   $
��Bold"�6u   $��16(�6�   6�   �� 5$      -   5        $��tabControl1��5$   S   $	��667��6   $
��Left=�6&   $��6,40,0,0q�6A   $	��Top=�6f   $	��764��6~   .@�5%      �� -   5        $��tabItem1��5%   )   $��	LME头寸��6   .��5&      � .+�5(      �� -   5        $��	groupBox1��5(   �   $	��100��6h   $
��Left=�6u   $��6,12,0,0q�6�   $	��Top=�6�   $	��700��6�   ��6#        ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��5)      � .+�5*   "   �� -   5        $
��lbl1��5*   7   $��内部客户��6(   $
��Left=�6C   $��1,10,0,0q�6^   $	��Top=�6p   #��[  6�   6�   �� 5+   "   -   5        $��	comboBox1��5+   Z   $
��Left=�6+   $��
107,12,0,0q�6F   $	��Top=�6k   
 �� SelectedValuePath$
 Id��6�    �� DisplayMemberPath$ 	ShortName��6�   ��6�   �� *InternalCustomerList+ �� SelectedValue 6�   �� *SelectedInternalID+6�   �� 5,   "   -   5        $
��lbl2��5,   6   $��	经纪行��6(   $
��Left=�6B   $��
260,10,0,0q�6]   $	��Top=�6q   #��[  6�   6�   �� 5-   "   -	   5        $��	comboBox2��5-   Z   $
��Left=�6+   $��
366,12,0,0q�6F   $	��Top=�6k   $
 Id��6�   $ 	ShortName��6�   ��6�   �� *
BrokerList+ 6�   �� *SelectedBrokerID+6�   �� 5.   "   -
   5        $��button1��5.   q   $��查询��6)   $��23��66   $
��Left=�6B   $��
366,44,0,0q�6]   $	��Top=�6�   $��75��6�   6�   �� 5/   "   -   5        $��label2��5/   �   $��金属��6(   
���<��$��28��6J   $
��Left=�6V   $��1,42,0,0q�6q   $	��Top=�6�   #��[  6�   �� 50   "   -   5        $��	comboBox3��50   Z   $
��Left=�6+   $��
107,44,0,0q�6F   $	��Top=�6k   $
 Id��6�   $
 Name��6�   ��6�   �� *CommodityList+ 6�   �� *SelectedCommodityID+6�   51      52      �� 54      -   5        $��
separator1��54   C   $��17��6$   $��	6,115,6,0q�60   $	��Top=�6U   7   1System.Windows.Forms.Integration.WindowsFormsHost  56      $��	6,135,0,0q�6/   $	��742��6B   $
��Left=�6N   $	��280��6i   $	��Top=�57   #      Child. 58        ZedGraph.ZedGraphControl  -   5        zedGraphControlLine��58   7   59      �� 5;      -   5        $��
separator2��5;   C   $��17��6$   $��	6,418,6,0q�60   $	��Top=�6U   6o   &   System.Windows.Controls.DataGrid  5=      -   5        $��	dataGrid1��5=   �      AutoGenerateColumns .  $
��auto��6W   $
��Left=�6e   $��	6,438,0,0q�6�   $	��Top=�6�   $
��auto��6�     DataGridStyle#��[ 6�     DataGridRowStyle   RowStyle# [ 6     
IsReadOnly . ��6?   ��    Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 	到期日��65   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6B   �� *
PromptDate+ �� StringFormat$ 
yyyy/MM/dd��6     5@   "   $ 	交易日��65    6B   �� *	TradeDate+$ 
yyyy/MM/dd��6~     5A   "   $ 手数��65    6A   �� *	LotNumber+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY# Z 6�     5B   "   $ 价格��65    6A   �� *Price+ 
  	STR_PRICE# Z 6�     5C   "   $ 交易方向��65    6C   �� *	Direction+ �� 	Converter# [ 6�     5D   "   $ 	经纪行��65    6B   �� *
BrokerName+6c     5E   "   $ 内部客户��65    6C   �� *InternalCustomerName+6n   5G      5H      5I      �� 5J      -   5        $��tabItem2��5J   +   $��
SHFE头寸��6   .��5K      � .+�5M      �� -   5        $��	groupBox2��5M   �   $	��100��6h   $
��Left=�6u   $��6,12,0,0q�6�   $	��Top=�6�   $	��700��6�   ��6#     $! Client.Properties.Resources��$	 
Conditions��.��5N      � .+�5O   "   �� -   5        $
��lbl3��5O   7   $��内部客户��6(   $
��Left=�6C   $��1,10,0,0q�6^   $	��Top=�6p   #��[  6�   6�   �� 5P   "   -   5        $��	comboBox4��5P   Z   $
��Left=�6+   $��
107,12,0,0q�6F   $	��Top=�6k   $
 Id��6�   $ 	ShortName��6�   ��6�   �� *InternalCustomerList+ 6�   �� *SelectedInternalID1+6�   �� 5Q   "   -   5        $
��lbl4��5Q   6   $��	经纪行��6(   $
��Left=�6B   $��
260,10,0,0q�6]   $	��Top=�6q   #��[  6�   6�   �� 5R   "   -   5        $��	comboBox5��5R   Z   $
��Left=�6+   $��
366,12,0,0q�6F   $	��Top=�6k   $
 Id��6�   $ 	ShortName��6�   ��6�   �� *
BrokerList+ 6�   �� *SelectedBrokerID1+6�   �� 5S   "   -   5        $��button2��5S   q   $��查询��6)   $��23��66   $
��Left=�6B   $��
366,44,0,0q�6]   $	��Top=�6�   $��75��6�   6�   �� 5T   "   -   5        $��label3��5T   �   $��金属��6(   
���<��$��28��6J   $
��Left=�6V   $��1,42,0,0q�6q   $	��Top=�6�   #��[  6�   �� 5U   "   -   5        $��	comboBox6��5U   Z   $
��Left=�6+   $��
107,44,0,0q�6F   $	��Top=�6k   $
 Id��6�   $
 Name��6�   ��6�   �� *CommodityList+ 6�   �� *SelectedCommodityID1+6�   5V      5W      �� 5Y      -   5        $��
separator3��5Y   C   $��17��6$   $��	6,115,6,0q�60   $	��Top=�6U   6o     5[      $��	6,135,0,0q�6/   $	��742��6B   $
��Left=�6N   $	��280��6i   $	��Top=�5\   #   . 5]        -   5        zedGraphControlLine1��5]   7   5^      �� 5`      -   5        $��
separator4��5`   C   $��17��6$   $��	6,418,6,0q�60   $	��Top=�6U   6o     5b      -   5        $��	dataGrid2��5b   �    .  $
��auto��6W   $
��Left=�6e   $��	6,438,0,0q�6�   $	��Top=�6�   $
��auto��6�   #��[ 6�   # [ 6�    . ��6?   ��  5c        5d   "   $ 合约��65    6A   �� *Alias+6]     5e   "   $ 	交易日��65      
Visibility$ Hidden=�6z    6B   �� *	TradeDate+$ 
yyyy/MM/dd��6�     5f   "   $ 手数��65    6A   �� *Qty+# Z 6�     5g   "   $ 价格��65    6A   �� *Price+# Z 6�     5h   "   $ 交易方向��65    6C   �� *PositionDerection+# [ 6�     5i   "   $ 	经纪行��65    6B   �� *
BrokerName+6c     5j   "   $ 内部客户��65    6C   �� *InternalName+6f   5l      5m      5n      5o      5p      5q      5r      