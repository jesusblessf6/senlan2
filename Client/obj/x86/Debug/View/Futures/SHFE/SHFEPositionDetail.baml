   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5	      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      1   +Client.View.Futures.SHFE.SHFEPositionDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$&   Client.View.Futures.SHFE.ResSHFE��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9        ResxName$! Client.Properties.Resources��
   Key$ SHFEPosition�� � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker��%�  '��       '�� �     '�� l    '  �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$ 60��6)   66   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5    
   "  6   .�5!      ��  � ��$ 23��6'   64   �� 5"       � ��$	 120��6&   64   5#      5%      .��5(      � -   5        	 �Name$	 rootGrid��5(      
 � RowDefinitions
 5)   
   �� 5*      $��38 �6   �� 5+      $��32 �6   �� 5,      $��32 �6   �� 5-      $��32 �6   �� 5.      $��32 �6   �� 5/      $��32 �6   �� 50      $��32 �6   �� 51      $	��120 �6   �� 52      $	��28* �6    � ColumnDefinitions 54   
   �� 55      $	��116 �6   �� 56      $	��130 �6   �� 57      $	��140 �6   �� 58      $	��160 �6   �� 59      $	��39* �6   .+�5;   
   �� -   5        $��label1��5;   �   $��32��6X   $
��Left=�6d   $��6,6,0,0q�6   $	��Top=�5<      $��16(�6(   $
��Bold"�66   $��3��6H   $
��auto��6\   ��5;        $! Client.Properties.Resources��$ SHFEPosition��5<   \   �� 5=   
   -   5        $��label2��5=   �   $��1��6O   $
��Left=�6\   $��6,0,0,0q�6w   $	��Top=�5>      ��5=        $! Client.Properties.Resources��$	 Lot��5>      �� 5?   
   -   5        $��label3��5?   �   $��2��6U   $
��Left=�6c   $��6,0,0,0q�6~   $	��Top=�5@      ��5?        $! Client.Properties.Resources��$ 	Commodity��5@      �� 5A   
   -   5        $��label4��5A   �   $��3��6U   $
��Left=�6b   $��6,0,0,0q�6}   $	��Top=�5B      ��5A        $! Client.Properties.Resources��$ 	TradeDate��5B      �� 5C   
   -   5        $��label5��5C   �   $��4��6U   $
��Left=�6c   $��6,0,0,0q�6~   $	��Top=�5D      ��5C        $! Client.Properties.Resources��$ 	OpenClose��5D      �� 5E   
   -   5        $��label6��5E   �   $��5��6R   $
��Left=�6_   $��6,0,0,0q�6z   $	��Top=�5F      ��5E        $! Client.Properties.Resources��$ Broker��5F      �� 5G   
   -   5        $��label7��5G   �   $��6��6V   $
��Left=�6c   $��6,0,0,0q�6~   $	��Top=�5H      ��5G        $! Client.Properties.Resources��$ 
Commission��5H      �� 5I   
   -	   5        $��label8��5I   �   $��7��6T   $
��Left=�6a   $��6,0,0,0q�6|   $	��Top=�5J      ��5I        $! Client.Properties.Resources��$ Comments��5J      �� 5K   
   -
   5        $��label9��5L      $��2��5K   Q   $��1��6a   $
��Left=�6n   $��30,0,0,0q�6�   $	��Top=�5L      ��5K        $! Client.Properties.Resources��$ Price��5L      �� 5M   
   -   5        $��label10��5N      $��2��5M   U   $��2��6e   $
��Left=�6r   $��30,0,0,0q�6�   $	��Top=�5N      ��5M        $! Client.Properties.Resources��$ 	Direction��5N      �� 5O   
   -   5        $��label11��5P      $��2��5O   X   $��3��6h   $
��Left=�6u   $��30,0,0,0q�6�   $	��Top=�5P      ��5O        $! Client.Properties.Resources��$ SHFEContract��5P      �� 5Q   
   -   5        $��label12��5R      $��2��5Q   X   $��4��6h   $
��Left=�6u   $��30,0,0,0q�6�   $	��Top=�5R      ��5Q        $! Client.Properties.Resources��$ PositionType��5R      �� 5S   
   -   5        $��label13��5T      $��2��5S   \   $��5��6l   $
��Left=�6y   $��30,0,0,0q�6�   $	��Top=�5T      ��5S        $! Client.Properties.Resources��$ InternalCustomer��5T      &    Utility.Controls.CurrencyTextBox  5U   
   -   5        $��currencyTextBox1��5V      $��1��5U      $��1��6-   $��23��6:   $
��Left=�6F   $��6,2,0,0q�6a   $	��Top=�5V   5   $	��120��6M      Text 6Y   �� *LotQuantity+�� 5W   
   -   5        $��	comboBox1��5W   \   $��1��6   $��2��6#   $
��Left=�60   $��6,2,0,0q�6K   $	��Top=�5X       �� DisplayMemberPath$
 Name��6O    �� SelectedValuePath$ Id��5Y   A   ��5X   +   �� *Commodities+ �� SelectedValue 5Y      �� *SelectedCommodityId+6A     5Z   
   -   5        $��datePicker1��5[      $��1��5Z      $��3��6%   $
��Left=�62   $��6,2,0,0q�6M   $	��Top=�5[   (      SelectedDate 6@   �� *	TradeDate+�� 5\   
   -   5        $��	comboBox2��5\   \   $��1��6   $��4��6#   $
��Left=�60   $��6,2,0,0q�6K   $	��Top=�5]      $
 Name��6U   $ Id��5^      ��5]   +   �� *PositionOpenClose+ 5^   *   �� *	OpenClose+�� 5_   
   -   5        $��	comboBox3��5_   \   $��1��6   $��5��6#   $
��Left=�60   $��6,2,0,0q�6K   $	��Top=�5`      $ 	ShortName��6K   $ Id��5a   >   ��5`   +   �� *	Brokers+ 5a      �� *SelectedBrokerId+6>     5b   
   -   5        $��currencyTextBox2��5c      $��1��5b      $��6��6-   $��23��6:   $
��Left=�6F   $��6,2,0,0q�6a   $	��Top=�5c   5   $	��120��6M    6Y   �� *
Commission+�� 5d   
   -   5        $��textBox1��5d   h   $��1��6   $��7��6"   $	��100��6/   $
��Left=�6<   $��6,2,0,0q�6W   $	��Top=�5e      $	��392��6*   $��3��66    �� TextWrapping$
 Wrap=�6J   ��6^   �� *	Comment+  5f   
   -   5        $��currencyTextBox3��5g      $��3��5f      $��1��6-   $��23��6:   $
��Left=�6F   $��6,2,0,0q�6a   $	��Top=�5g   5   $	��120��6M    6Y   �� *Price+�� 5h   
   -   5        $��	comboBox4��5h   \   $��3��6   $��2��6#   $
��Left=�60   $��6,2,0,0q�6K   $	��Top=�5i      $
 Name��6V   $ Id��5j      ��5i   +   �� *PositionDirections+ 5j   *   �� *	Direction+�� 5k   
   -   5        $��	comboBox6��5k   \   $��3��6   $��4��6#   $
��Left=�60   $��6,2,0,0q�6K   $	��Top=�5l      $
 Name��6Q   $ Id��5m      ��5l   +   �� *PositionTypes+ 5m   *   �� *Type+�� 5n   
   -   5        $��	comboBox7��5n   \   $��3��6   $��5��6#   $
��Left=�60   $��6,2,0,0q�6K   $	��Top=�5o      $ 	ShortName��6Q   $ Id��5p   C   ��5o   +   �� *InnerCustomer+ 5p      �� *SelectedInnerCustomer+6C   �� 5q   
   -   5        $��label14��5q   �   $
��Left=�6S   $��30,0,0,0q�6n   $	��Top=�5r      $��2��6(   $��6��68   ��5q        $! Client.Properties.Resources��$ ClosePL��5r   8     5s   
   -   5        $��currencyTextBox4��5s   U   $��23��6   $
��Left=�6)   $��6,2,0,0q�6D   $	��Top=�5t   2   $	��120��6J   $��3��6V   $��6��6f    6   �� *PNL+6f   �� 5u   
   -   5        $��textBox2��5u   [   $��3��6   $��3��6"   $
��Left=�6/   $��6,2,0,0q�6J   $	��Top=�5v      ��6*   �� *Alias+5w      5x      