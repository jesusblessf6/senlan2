   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  6@   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      .    (Client.View.Reports.SHFEPositionPLReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     6@   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5	      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   ?     *	SHFEPnL+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%�  &	        '�� �     '  m    &	 �    &	 �    7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5    
   6@   �� 5"   
   " ��6"   .�5#      ��  � �� 6+   �� *
LineType+8   6v   5$      5%      .��5&      �� $
��Auto=�6   $
��Auto=�68   .��5'   
   � -   5        $��rootGrid��5'      .+�5(      �� -   5        $��lbTitle��5(   -   $
��Left=�6<   $��6,6,0,0q�6W   $��32��6h   $	��Top=�5)      $
��Bold"�6,   $��16(�6>   ��5(        *	SHFEPnL+5)   >   �� 5*      -   5        $��	groupBox1��5+   D   $	��100��5*   \   $
��Left=�5+      $��6,40,0,0q�62   $	��Top=�6U   $	��800��6m   ��5*           ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��5,      � .+�5-      �� -   5        $��label1��5/      #��[  5.      $
��Left=�6@   $��
260,42,0,0q�6[   $	��Top=�5/   *   ��5-        $! Client.Properties.Resources��$	 	Commodity��5/   *   �� 50      -   5        $��	comboBox1��50   N   $
��Left=�6   $��
366,44,0,0q�6:   $	��Top=�6_   
 �� DisplayMemberPath$

 Name��51   C    �� SelectedValuePath$ Id��6\   ��6   �� *Commodities+ �� SelectedValue 52      �� *SelectedCommodityId+�� 53      -   5        $��label3��55      #��[  54      $
��Left=�6@   $��
260,10,0,0q�6[   $	��Top=�55   *   ��53        $! Client.Properties.Resources��$	 	StartDate��55   *     56      -   5        $��datePicker1��56   P   $
��Left=�6!   $��
366,12,0,0q�6<   $	��Top=�57   !      SelectedDate 69   �� *	StartDate+�� 58      -   5        $��label4��5:      #��[  59      $
��Left=�6@   $��
519,10,0,0q�6[   $	��Top=�5:   *   
���<����58        $! Client.Properties.Resources��$	 EndDate��5:   B     5;      -	   5        $��datePicker2��5;   P   $
��Left=�6!   $��
625,12,0,0q�6<   $	��Top=�5<   !    69   �� *	EndDate+�� 5=      -
   5        $��label5��5?      #��[  5>      $
��Left=�6@   $��1,10,0,0q�6[   $	��Top=�5?   *   
���<����5=        $! Client.Properties.Resources��$	 InternalCustomer��5?   B   �� 5@      -   5        $��	comboBox3��5@   N   $
��Left=�6   $��
107,12,0,0q�6:   $	��Top=�6_   $
 	ShortName��5A   I   $ Id��5B      ��5A      �� *InternalCustomers+ 5B   6   �� *SelectedInternalCustomerId+�� 5C      -   5        $��button1��5D   L   $��23��5C   ^   $
��Left=�5D      $��
625,44,0,0q�68   $	��Top=�6[   $��75��5E      ��5C        $! Client.Properties.Resources��$	 Query��5E   (   �� 5F      -   5        $��label2��5H      #��[  5G      $
��Left=�6@   $��1,42,0,0q�6[   $	��Top=�5H   *   ��5F        $! Client.Properties.Resources��$	 Broker��5H   *   �� 5I      -   5        $��	comboBox2��5I   N   $
��Left=�6   $��
107,44,0,0q�6:   $	��Top=�6_   $
 	ShortName��5J   ?   $ Id��6]   ��6   �� *	Brokers+ 5K      �� *SelectedBrokerId+5L      5M      �� 5N      -   5        $��
separator1��5N   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   �� 5O      -   5        $��tabControl1��5O   b   $��1��6   $
��Auto��6&   $
��Left=�64   $��	6,166,0,0q�6O   $	��Top=�5P      $
��Auto��61   .@�5Q      �� ��6     *
PositionPL+.��5R      � .+�5S      &   System.Windows.Controls.DataGrid  -   5        $��grid1��5U   0      AutoGenerateColumns .  $
��Auto��5S   ?   $
��Left=�6M   $	��Top=�5T   #   $
��Auto��5U   #      
IsReadOnly . $��0,0,0,0q�6O   ��6`   ��    Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5X   5      CanUserSort .  1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [ 5Y   5      Header 5W   5     $! Client.Properties.Resources��$	 Broker��5Z   #     5[   "   $
 Auto 5\   5    .  # [ 5]   5    5[   5     $! Client.Properties.Resources��$	 	Commodity�� 	  Binding 5\   V   �� *CommodityName+5^   #     5_   "   $
 Auto 5`   5    .  # [ 5b   5    5_   5     $! Client.Properties.Resources��$	 ClosePL�� 5a   5   �� *
ClosePNL+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z 5c   #     5d   "   $
 Auto 5e   j    .  # [ 5h   %    5e   %     $# Client.View.Reports.ResReport��$	 FloatPnL�� 5g   %   �� *
FloatPNL+# Z 5i   #     5j   "   $
 Auto 5k   j    .  # [ 5n   %    5k   %     $! Client.Properties.Resources��$	 
Commission�� 5m   %   �� *
Commission+# Z 5o   #     5p   "   $
 Auto 5q   5    .  # [ 5s   5    5p   5     $! Client.Properties.Resources��$	 TotalPL�� 5r   5   �� *PNL+# Z 5t   #    �� 
GroupStyle 5v      (  "System.Windows.Controls.GroupStyle  5w   "     GroupHerderStyle   ContainerStyle# [ 6-      Panel 5x   &   �� 5y   *   .R�5z   .   >  8System.Windows.Controls.Primitives.DataGridRowsPresenter  5{   +   5}   #   5      5�      5�      �� 5�      -   5        $��tabItem2��5�   9   ��6     *PositionDetail+.��5�      � .+�5�        -   5        $��grid2��5�   0    .  $
��Auto��5�   ?   $
��Left=�6M   $	��Top=�5�   #   $
��Auto��5�   #    . $��0,0,0,0q�6O   ��6`   ��  5�        5�   "   $
 Auto 5�   5    .  # [ 5�   5    5�   5     $! Client.Properties.Resources��$	 Broker��5�   #     5�   "   $
 Auto 5�   l    .  # [ 5�   %    5�   %     $! Client.Properties.Resources��$	 SHFEContract�� 5�   9   �� *Alias+5�   #     5�   "   $
 Auto 5�   %    .  # [ 5�   %    5�   %     $# Client.View.Reports.ResReport��$	 PullPosition�� 5�   F   �� *BuyQty+$ N��5�   #     5�   "   $
 Auto 5�   %    .  # [ 5�   %    5�   %     $# Client.View.Reports.ResReport��$	 AveragePullPrice�� 5�   F   �� *
BuyPrice+$ N��5�   #     5�   "   $
 Auto 5�   %    .  # [ 5�   %    5�   %     $# Client.View.Reports.ResReport��$	 PushPosition�� 5�   F   �� *	SellQty+$ N��5�   #     5�   "   $
 Auto 5�   %    .  # [ 5�   %    5�   %     $# Client.View.Reports.ResReport��$	 AveragePushPrice�� 5�   F   �� *	SellPrice+$ N��5�   #     5�   "   $
 Auto 5�   %    .  # [ 5�   %    5�   %     $# Client.View.Reports.ResReport��$	 LatestSettlementPrice�� 5�   %   �� *SettlementPrice+$ N��5�   #     5�   "   $
 Auto 5�   j    .  # [ 5�   %    5�   %     $# Client.View.Reports.ResReport��$	 FloatPnL�� 5�   9   �� *PNL+$ N��5�   #    5�        5�   "   # [ 6-    5�   &   �� 5�   *   .R�5�   .     5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      