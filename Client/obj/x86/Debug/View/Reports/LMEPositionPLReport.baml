   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  6@   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      -    'Client.View.Reports.LMEPositionPLReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     6@   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5
   P     *LMEPositionPL+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker2   ,Client.Converters.PositionDirectionConverter  DirectionConverter/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%�  &	        '�� �     '  m    &	 �    &	 �    &	 
    7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5   
   6D     5    
   6@   �� 5"   
   " ��6"   .�5#      ��  � �� 6+   �� *
LineType+8   6v   5$      5%      .��5'      �� $
��Auto=�6   $
��Auto=�68   .��5(   
   � -   5        $��rootGrid��5(       � RowDefinitions 5)      �� 5*      $
��auto �6    �� 5+      $��* �6    .+�5-      �� -   5        $��lbTitle��5-   3   $
��Left=�6B   $��6,6,0,0q�6]   $��32��5.      $	��Top=�5/      $
��Bold"�6,   $��16(�6>   ��5-        *LMEPositionPL+5/   >   �� 50      -   5        $��
separator1��50   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   �� 51      -   5        $��	groupBox1��52   D   $	��100��51   \   $
��Left=�52      $��6,40,0,0q�62   $	��Top=�53      $	��650��6/   ��51        	   ResxName$!	 Client.Properties.Resources��

   Key$
 
Conditions��.��54      � .+�55      �� -   5        $��label1��57   .   #��[  56      $
��Left=�6@   $��1,10,0,0q�57      $	��Top=�6<   
���<����55        $!	 Client.Properties.Resources��$
 	Commodity��57   T   �� 58      -   5        $��	comboBox1��58   N   $
��Left=�6   $��
107,12,0,0q�6:   $	��Top=�6_    �� DisplayMemberPath$
 Name��59   C    �� SelectedValuePath$ Id��6\   ��6   �� *Commodities+ �� SelectedValue 5:      �� *SelectedCommodityId+�� 5;      -   5        $��label3��5<   T   $
��Left=�5;   <   #��[  5<      $��
260,10,0,0q�6@   $	��Top=�5=      
���<����5;        *SettlementDate+5=   4     5>      -   5        $��datePicker1��5>   P   $
��Left=�6!   $��
366,12,0,0q�6<   $	��Top=�5?   !      SelectedDate 69   �� *
SettleDate+�� 5@      -	   5        $��label5��5B   0   #��[  5A      $
��Left=�6@   $��
260,42,0,0q�5B      $	��Top=�6>   
���<����5@        $!	 Client.Properties.Resources��$
 InternalCustomer��5B   V   �� 5C      -
   5        $��	comboBox3��5C   N   $
��Left=�6   $��
366,44,0,0q�6:   $	��Top=�6_   $ 	ShortName��5D   I   $ Id��5E      ��5D      �� *InternalCustomers+ 5F      �� *SelectedInternalCustomerId+�� 5G      -   5        $��button1��5H   L   $��23��5G   ^   $
��Left=�5H      $��
505,44,0,0q�68   $	��Top=�5I      $��75��65   ��5G        $!	 Client.Properties.Resources��$
 Query��5I   @   �� 5J      -   5        $��label2��5L   .   #��[  5K      $
��Left=�6@   $��1,42,0,0q�5L      $	��Top=�6<   ��5J        $!	 Client.Properties.Resources��$
 Broker��5L   <   �� 5M      -   5        $��	comboBox2��5M   N   $
��Left=�6   $��
107,44,0,0q�6:   $	��Top=�6_   $ 	ShortName��5N   ?   $ Id��6]   ��6   �� *	Brokers+ 5O      �� *SelectedBrokerId+5P      5Q      �� 5R      -   5        $��label6��5T   '   $��28��5R   1   $��85��6=   $
��Left=�6H   $
��Left=�5S      $��	6,163,0,0q�5T      $
��Bold"�65   $	��Top=�6G   ��5R        *SumByBroker+5T   G   &   System.Windows.Controls.DataGrid  5U      -   5        $��	dataGrid1��5V         AutoGenerateColumns .  $
��Auto��5U   3   $
��Left=�6A   $��	6,191,0,0q�6\   $	��Top=�5V   (   $
��Auto��6@      
IsReadOnly . ��5W      �� *	Summaries+   Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 5Z   <   1
  +System.Windows.Controls.DataGridBoundColumn 
  ElementStyle# [ 5[   )      Header 5Y   )     $#	 Client.View.Reports.ResReport��$
 
BrokerName�� 
  Binding 5Z   I   �� *
BrokerName+5\        5]       . $
 Auto	 5^   <   # [ 5`   )    5]   )     $#	 Client.View.Reports.ResReport��$
 DuedLockedPnL�� 5_   )   �� *DuedLockedPL+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z 5a        5b       . $
 Auto	 5c   <   # [ 5e   )    5b   )     $#	 Client.View.Reports.ResReport��$
 UnduedLockedPnL�� 5d   )   �� *UnduedLockedPL+# Z 5f        5g       . $
 Auto	 5h   <   # [ 5j   )    5g   )     $#	 Client.View.Reports.ResReport��$
 UnduedFloatPnL�� 5i   )   �� *UnduedFloatPL+# Z 5k        5l       . $
 Auto	 5m   <   # [ 5o   )    5l   )     $!	 Client.Properties.Resources��$
 Summary�� 5n   )   �� *SumPL+# Z 5p      5r      �� 5t      -   5        $��label7��5v   A   $��1��5t   V   $��28��6c   $��85��5u      $
��Left=�6   $
��Left=�5v      $��6,17,0,0q�6/   $
��Bold"�6O   $	��Top=�6a   ��5t        $!	 Client.Properties.Resources��$
 Detail��5v   a   �� 5w      -   5        $��
separator2��5w   5   $��17��6   $��6,0,6,0q�6$   $	��Top=�6G   $��1��6_   �� 5x      -   5        $��tabControl1��5x   a   $��1��6   $
��Auto��6&   $
��Left=�64   $��6,45,0,0q�6O   $	��Top=�5y      $
��Auto��61   .@�5z      �� ��6     *DuedLockedPnL+.��5{      � .+�5|        -   5        $��duedLockedGrid��5}   H    .  $
��Auto��5|   ?   $
��Left=�6M   $	��Top=�5}   #   $
��Auto��6;    . $��6,6,0,0q�5~   #   ��64   ��  5        5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 Broker�� 5�   5   �� *
BrokerName+5�   #     5�   "   $
 Auto	 5�   j    .  # [ 5�   D    5�   %     $!	 Client.Properties.Resources��$
 
PromptDate�� 5�   %   �� *
PromptDate+5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$	
 Lot�� 5�   5   �� *	LotNumber+   STR_INTEGER# Z 5�   #     5�   "   $
 Auto	 5�   j    .  # [ 5�   ~    5�   %     $!	 Client.Properties.Resources��$
 
Commission�� 5�   %   �� *
Commission+# Z 5�   #     5�   "   $
 Auto	 6r    .  # [ 5�   {    5�   5     $!	 Client.Properties.Resources��$
 PL�� 5�   %   �� *	FloatPL+# Z 5�   #     5�   "   $
 Auto	 6x    .  # [ 5�   B    5�   5     $!	 Client.Properties.Resources��$
 Comments�� 5�   %   �� *
Comments+6n   5�      5�      5�      �� 5�      -   5        $��tabItem2��5�   :   ��6     *UnduedLockedPnL+.��5�      � .+�5�        -   5        $��unduedLockedGrid��5�   H    .  $
��Auto��5�   ?   $
��Left=�6M   $	��Top=�5�   #   $
��Auto��6;    . $��6,6,0,0q�5�   #   ��5�   #   �� *UnduedLockedDetails+ 5�        5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 Broker�� 5�   5   �� *
BrokerName+5�   #     5�   "   $
 Auto	 5�   j    .  # [ 5�   D    5�   %     $!	 Client.Properties.Resources��$
 
PromptDate�� 5�   %   �� *
PromptDate+5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 	TradeDate�� 5�   5   �� *	TradeDate+$ {0:yyyy-MM-dd}��5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$	
 Lot�� 5�   5   �� *	LotNumber+# Z 5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 	Direction�� 5�   5   �� *	Direction+# [ 5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 Price�� 5�   5   �� *Price+   	STR_PRICE# Z 5�   #     5�   "   $
 Auto	 5�   j    .  # [ 5�   %    5�   %     $!	 Client.Properties.Resources��$
 
Commission�� 5�   %   �� *
Commission+# Z 5�   #   5�      5�      5�      �� 5�      -   5        $��tabItem3��5�   9   ��6     *UnduedFloatPnL+.��5�      � .+�5�        -   5        $��unduedFloatGrid��5�   H    .  $
��Auto��5�   ?   $
��Left=�6M   $	��Top=�5�   #   $
��Auto��6;    . $��6,6,0,0q�5�   #   ��5�   #   �� *UnduedFloatDetails+ 5�        5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 Broker�� 5�   5   �� *
BrokerName+5�   #     5�   "   $
 Auto	 5�   j    .  # [ 5�   D    5�   %     $!	 Client.Properties.Resources��$
 
PromptDate�� 5�   %   �� *
PromptDate+5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 	TradeDate�� 5�   5   �� *	TradeDate+$ {0:yyyy-MM-dd}��5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$	
 Lot�� 5�   5   �� *	LotNumber+# Z 5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 	Direction�� 5�   5   �� *	Direction+# [ 5�   #     5�   "   $
 Auto	 5�   5    .  # [ 5�   5    5�   5     $!	 Client.Properties.Resources��$
 Price�� 5�   5   �� *Price+# Z 5�   #     5�   "   $
 Auto	 5�   j    .  # [ 5�   %    5�   %     $!	 Client.Properties.Resources��$
 
Commission�� 5�   %   �� *
Commission+# Z 5�   #     5�   "   $
 Auto	 5�   %    .  # [ 5�   %    5�   %     $#	 Client.View.Reports.ResReport��$
 LMELatestPrice�� 5�   %   �� *LMELastestPrice+# Z 5�   #     5   "   $
 Auto	 5  j    .  # [ 5  %    5  %     $#	 Client.View.Reports.ResReport��$
 FloatPnL�� 5  %   �� *	FloatPL+# Z 5  #   5     5     5	     �� 5
     -   5        $��tabItem1��5
  A   ��6     *ClosingPnLOfSettleDate+.��5     � .+�5     �� -   5        $��label4��5  1   $��28��5  H   $
��Left=�6T   $��6,6,0,0q�5      $	��Top=�6?   ��5        *ClosingPnLOfSettleDate+5  ?   �� 5     -   5        $��label8��5  Y   $��28��6    $
��Left=�6,   $��97,6,0,0q�6G   $	��Top=�5      $	��160��68    �� ContentStringFormat# Z 5      
���<����5  D   �� *	ClosingPL+5  b   5     5     5     5     5     5     