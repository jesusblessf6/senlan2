   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 1   +Client.View.Futures.SHFE.SHFEPositionDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$&   Client.View.Futures.SHFE.ResSHFE�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ SHFEPosition�� � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker��%U  '��       '��      '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$ 60����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.��� -   	 �Name$	 rootGrid��
 � RowDefinitions
 �� $��38 ��� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $	��120 ��� $	��28* � � ColumnDefinitions �� $	��116 ��� $	��130 ��� $	��140 ��� $	��160 ��� $	��39* �.+��� -   $��label1��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$��16(�$
��Bold"�$��3��$
��auto����  $! Client.Properties.Resources��$ SHFEPosition���� -   $��label2��$��1��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 Lot���� -   $��label3��$��2��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -   $��label4��$��3��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	TradeDate���� -   $��label5��$��4��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	OpenClose���� -   $��label6��$��5��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Broker���� -   $��label7��$��6��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 
Commission���� -	   $��label8��$��7��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -
   $��label9��$��2��$��1��$
��Left=�$��30,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Price���� -   $��label10��$��2��$��2��$
��Left=�$��30,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Direction���� -   $��label11��$��2��$��3��$
��Left=�$��30,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ SHFEContract���� -   $��label12��$��2��$��4��$
��Left=�$��30,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PositionType���� -   $��label13��$��2��$��5��$
��Left=�$��30,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer��&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��1��$��1��$��23��$
��Left=�$��6,2,0,0q�$	��Top=�$	��120��   Text �� *LotQuantity+�� -   $��	comboBox1��$��1��$��2��$
��Left=�$��6,2,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Commodities+ �� SelectedValue �� *SelectedCommodityId+  -   $��datePicker1��$��1��$��3��$
��Left=�$��6,2,0,0q�$	��Top=�   SelectedDate �� *	TradeDate+�� -   $��	comboBox2��$��1��$��4��$
��Left=�$��6,2,0,0q�$	��Top=�$
 Name��$ Id������ *PositionOpenClose+ �� *	OpenClose+�� -   $��	comboBox3��$��1��$��5��$
��Left=�$��6,2,0,0q�$	��Top=�$ 	ShortName��$ Id������ *	Brokers+ �� *SelectedBrokerId+  -   $��currencyTextBox2��$��1��$��6��$��23��$
��Left=�$��6,2,0,0q�$	��Top=�$	��120�� �� *
Commission+�� -   $��textBox1��$��1��$��7��$	��100��$
��Left=�$��6,2,0,0q�$	��Top=�$	��392��$��3�� �� TextWrapping$
 Wrap=����� *	Comment+  -   $��currencyTextBox3��$��3��$��1��$��23��$
��Left=�$��6,2,0,0q�$	��Top=�$	��120�� �� *Price+�� -   $��	comboBox4��$��3��$��2��$
��Left=�$��6,2,0,0q�$	��Top=�$
 Name��$ Id������ *PositionDirections+ �� *	Direction+�� -   $��	comboBox6��$��3��$��4��$
��Left=�$��6,2,0,0q�$	��Top=�$
 Name��$ Id������ *PositionTypes+ �� *Type+�� -   $��	comboBox7��$��3��$��5��$
��Left=�$��6,2,0,0q�$	��Top=�$ 	ShortName��$ Id������ *InnerCustomer+ �� *SelectedInnerCustomer+�� -   $��label14��$
��Left=�$��30,0,0,0q�$	��Top=�$��2��$��6����  $! Client.Properties.Resources��$ ClosePL��  -   $��currencyTextBox4��$��23��$
��Left=�$��6,2,0,0q�$	��Top=�$	��120��$��3��$��6�� �� *PNL+�� -   $��textBox2��$��3��$��3��$
��Left=�$��6,2,0,0q�$	��Top=����� *Alias+