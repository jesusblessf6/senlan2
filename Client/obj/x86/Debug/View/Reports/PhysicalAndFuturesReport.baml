   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  6@   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      2    ,Client.View.Reports.PhysicalAndFuturesReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     6@   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *PhysicalFuturesPnL+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%�  &	        '�� �     '  m    &	 �    &	 �    7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5    
   6@   �� 5"   
   " ��6"   .�5#      ��  � �� 6+   �� *
LineType+8   6v   5$      5%      .��5'      �� $
��Auto=�6   $
��Auto=�68   .��5(   
   � -   5        $��rootGrid��5(       � RowDefinitions 5)      �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $	��68* �6    .+�51      �� -   5        $��lbTitle��51   8   $
��Left=�6G   $��6,6,0,0q�6b   $��32��52      $	��Top=�6    $
��Bold"�68   $��16(�6J   ��51        *PhysicalFuturesPnL+52   J   �� 53      -   5        $��	groupBox1��54   D   $	��100��53   \   $
��Left=�54      $��6,40,0,0q�62   $	��Top=�6U   $	��620��6m   ��53        	   ResxName$!	 Client.Properties.Resources��

   Key$
 
Conditions��.��55      � .+�56      �� -   5        $��label1��58      #��[  57      $
��Left=�6@   $��
260,10,0,0q�6[   $	��Top=�58   *   ��56        $!	 Client.Properties.Resources��$
 	Commodity��58   *   �� 59      -   5        $��	comboBox1��59   N   $
��Left=�6   $��
366,12,0,0q�6:   $	��Top=�6_    �� DisplayMemberPath$
 Name��5:   C    �� SelectedValuePath$ Id��6\   ��6   �� *Commodities+ �� SelectedValue 5;      �� *SelectedCommodityId+�� 5<      -   5        $��label3��5>      #��[  5=      $
��Left=�6@   $��1,42,0,0q�6[   $	��Top=�5>   *   ��5<        $!	 Client.Properties.Resources��$
 	StartDate��5>   *     5?      -   5        $��datePicker1��5?   P   $
��Left=�6!   $��
107,44,0,0q�6<   $	��Top=�5@   !      SelectedDate 69   �� *	StartDate+�� 5A      -   5        $��label4��5C      #��[  5B      $
��Left=�6@   $��
260,42,0,0q�6[   $	��Top=�5C   *   
���<����5A        $!	 Client.Properties.Resources��$
 EndDate��5C   B     5D      -	   5        $��datePicker2��5D   P   $
��Left=�6!   $��
366,44,0,0q�6<   $	��Top=�5E   !    69   �� *	EndDate+�� 5F      -
   5        $��label5��5H      #��[  5G      $
��Left=�6@   $��1,10,0,0q�6[   $	��Top=�5H   *   
���<����5F        $!	 Client.Properties.Resources��$
 InternalCustomer��5H   B   �� 5I      -   5        $��	comboBox3��5I   N   $
��Left=�6   $��
107,12,0,0q�6:   $	��Top=�6_   $ 	ShortName��5J   I   $ Id��5K      ��5J      �� *InternalCustomers+ 5K   6   �� *SelectedInternalCustomerId+�� 5L      -   5        $��button1��5M   L   $��23��5L   ^   $
��Left=�5M      $��
505,44,0,0q�68   $	��Top=�6[   $��75��5N      ��5L        $!	 Client.Properties.Resources��$
 Query��5N   (   5O      5P      &   System.Windows.Controls.DataGrid  5Q      -   5        $��dataGridSHFE��5R         AutoGenerateColumns .  $
��Auto��5Q   3   $
��Left=�6A   $��	12,40,0,0q�6\   $	��Top=�5R   +   $
��Auto��6C   $��3��6P      
IsReadOnly . ��6]   ��    Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6j      CanUserSort .  1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [ 5V   =      Header 5U   )     $!	 Client.Properties.Resources��$
 Broker��5W        5X      $
 Auto 5Y   )    .  # [ 5Z   )    5X   )     $!	 Client.Properties.Resources��$
 	Commodity�� 	  Binding 5Y   J   �� *CommodityName+5[        5\      $
 Auto 6k    .  # [ 5_   )    5\   )     $!	 Client.Properties.Resources��$
 ClosePL�� 5^   )   �� *
ClosePNL+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z 5`        5a      $
 Auto 5b   )    .  # [ 5d   )    5a   )     $#	 Client.View.Reports.ResReport��$
 FloatPnL�� 5c   )   �� *
FloatPNL+# Z 5e        5f      $
 Auto 5g   )    .  # [ 5i   )    5f   )     $!	 Client.Properties.Resources��$
 
Commission�� 5h   )   �� *
Commission+# Z 5j        5k      $
 Auto 6k    .  # [ 5n   )    5k   )     $!	 Client.Properties.Resources��$
 TotalPL�� 5m   )   �� *PNL+# Z 5o       �� 
GroupStyle 5q      (  "System.Windows.Controls.GroupStyle  5r        GroupHerderStyle   ContainerStyle# [ 6!      Panel 5s      �� 5t      .R�5u   "   >  8System.Windows.Controls.Primitives.DataGridRowsPresenter  5v      5x      5z        5{      -   5        $��dataGridLME��5|   L    .  $
��Auto��5{   3   $
��Left=�6A    . $��	12,40,0,0q�5|   9   $	��Top=�6_   $
��Auto��5}      $��4��6$   ��5|      �� *	Summaries+ 5~        5       . $
 Auto 5�   <   # [ 5�   )    5   )     $#	 Client.View.Reports.ResReport��$
 
BrokerName�� 5�   I   �� *
BrokerName+5�        5�       . $
 Auto 5�   <   # [ 5�   )    5�   )     $#	 Client.View.Reports.ResReport��$
 DuedLockedPnL�� 5�   )   �� *DuedLockedPL+# Z 5�        5�       . $
 Auto 5�   <   # [ 5�   )    5�   )     $#	 Client.View.Reports.ResReport��$
 UnduedLockedPnL�� 5�   )   �� *UnduedLockedPL+# Z 5�        5�       . $
 Auto 5�   <   # [ 5�   )    5�   )     $#	 Client.View.Reports.ResReport��$
 UnduedFloatPnL�� 5�   )   �� *UnduedFloatPL+# Z 5�        5�       . $
 Auto 5�   <   # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 Summary�� 5�   )   �� *SumPL+# Z 5�       5�        5�      # [ 6!    5�      �� 5�      .R�5�   "     5�      5�      5�      �� 5�      -   5        $��label2��5�      $��3��5�   -   $��28��6:   $
��Left=�6F   $��6,15,0,0q�6a   $	��Top=�5�   "   ��5�        *	SHFEPnL+5�   "   �� 5�      -   5        $��label6��5�      $��4��5�   3   $��28��6@   $
��Left=�6L   $��6,15,0,0q�6g   $	��Top=�5�   "   ��5�        *LMEPositionPL+5�   "   �� 5�      -   5        $��label7��5�      $��28��5�   =   $
��Left=�6I   $��6,15,0,0q�6d   $	��Top=�5�   "   $��2��6:   ��5�        *PhysicalForeignTradePnL+5�   :     5�      -   5        $��dataGridPhysicalExternal��5�   B    .  $
��Auto��5�   3   $
��Left=�6A    . $��	12,40,0,0q�5�   /   $	��Top=�5�      $
��Auto��6/   $��2��6<   ��5�      ��  5�        5�       .  # [ 5�   )   $
 Auto 5�   )    5�   )   �� *CommodityName+ 5�   )     $!	 Client.Properties.Resources��$
 	Commodity��5�   )     5�       .  # [ 5�   -   $
 Auto 5�   _    5�      �� *	BuySumQty+ 
  STR_QUANTITY# Z  5�        $!	 Client.Properties.Resources��$
 PurchaseQty��6_     5�       .  # [ 5�   -   $
 Auto 5�   j    5�      �� *BuyAvgPrice+ 
  	STR_PRICE# Z  5�        $#	 Client.View.Reports.ResReport��$
 PruchaseAveragePrice��6j     5�       .  # [ 5�   -   $
 Auto 5�   \    5�      �� *
SellSumQty+# Z  5�        $!	 Client.Properties.Resources��$
 SalesQty��6\     5�       .  # [ 5�   -   $
 Auto 5�   g    5�      �� *SellAvgPrice+# Z  5�        $#	 Client.View.Reports.ResReport��$
 SalesAveragePrice��6g     5�       .  # [ 5�   -   $
 Auto 5�   ^    5�      �� *	SellPNL+# Z  5�        $#	 Client.View.Reports.ResReport��$
 SalesPnL��6^     5�       .  # [ 5�   -   $
 Auto 5�   _    5�      �� *InventorySumQty+# Z  5�        $#	 Client.View.Reports.ResReport��$
 	Inventory��6_     5�       .  # [ 5�   -   $
 Auto 5�   a    5�      �� *LatestPrice+# Z  5�        $#	 Client.View.Reports.ResReport��$
 LatestPrice��6a     5�       .  # [ 5�   -   $
 Auto 5�   ^    5�      �� *
FloatPNL+# Z  5�        $#	 Client.View.Reports.ResReport��$
 FloatPnL��6^     5�       .  # [ 5�   -   $
 Auto 5�   [    5�      �� *
TotalPNL+# Z  5�        $!	 Client.Properties.Resources��$
 TotalPL��6[    5�        5�      # [ 6!    5�      �� 5�      .R�5�   "     5�      5�      5�        5�      -   5        $��dataGridPhysicalDomestic��5�   B    .  $
��Auto��5�   3   $
��Left=�6A    . $��	12,40,0,0q�5�   /   $	��Top=�5�      $
��Auto��6/   $��1��6<   ��5�      ��  5�        5�       .  # [ 5�   )   $
 Auto 5�   )    5�   )   �� *CommodityName+ 5�   )     $!	 Client.Properties.Resources��$
 	Commodity��5�   )     5�       .  # [ 5�   -   $
 Auto 5�   _    5�      �� *	BuySumQty+# Z  5�        $!	 Client.Properties.Resources��$
 PurchaseQty��6_     5�       .  # [ 5�   -   $
 Auto 5�   j    5�      �� *BuyAvgPrice+# Z  5�        $#	 Client.View.Reports.ResReport��$
 PruchaseAveragePrice��6j     5�       .  # [ 5�   -   $
 Auto 5�   \    5�      �� *
SellSumQty+# Z  5�        $!	 Client.Properties.Resources��$
 SalesQty��6\     5�       .  # [ 5�   -   $
 Auto 5�   g    5�      �� *SellAvgPrice+# Z  5�        $#	 Client.View.Reports.ResReport��$
 SalesAveragePrice��6g     5�       .  # [ 5�   -   $
 Auto 5�   ^    5�      �� *	SellPNL+# Z  5�        $#	 Client.View.Reports.ResReport��$
 SalesPnL��6^     5�       .  # [ 5�   -   $
 Auto 5�   _    5�      �� *InventorySumQty+# Z  5�        $#	 Client.View.Reports.ResReport��$
 	Inventory��6_     5�       .  # [ 5  -   $
 Auto 5  a    5      �� *LatestPrice+# Z  5       $#	 Client.View.Reports.ResReport��$
 LatestPrice��6a     5      .  # [ 5  -   $
 Auto 5  ^    5     �� *
FloatPNL+# Z  5       $#	 Client.View.Reports.ResReport��$
 FloatPnL��6^     5      .  # [ 5	  -   $
 Auto 5
  [    5     �� *
TotalPNL+# Z  5
       $!	 Client.Properties.Resources��$
 TotalPL��6[    5       5     # [ 6!    5     �� 5     .R�5  "     5     5     5     �� 5     -   5        $��label8��5     $��28��5  >   $
��Left=�6J   $��	6,15,0,22q�6e   $	��top=�5  "   $��1��6:   ��5       *PhysicalDomesticTradePnL+5  :   �� 5     -   5        $��
separator1��5  5   $��17��6   $��6,0,6,0q�6$   $	��Top=�6G   $��1��6_   5     5     5     