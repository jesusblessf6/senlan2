   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  /    )Client.View.Futures.SHFE.SHFEPositionHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$&   Client.View.Futures.SHFE.ResSHFE�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *SHFEPositionHome+.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label2��$��28��$	��100��$��Right=�$
��Left=�$��6,63,0,0q�$	��Top=���  *ImpotPosition+�� -   $��button1��$��23��$
��Left=�$��
120,64,0,0q�$	��Top=�$��75����  *ImportWithSymbol+�� -   $��lbTitle��$
��Bold"�$��16(�$��32��$
��Left=�$��6,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ SHFEPosition���� -   $��	groupBox2��$	��270��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.���  � ColumnDefinitions �� $	��107 ��� $	��120 ��� $	��146 ��� $	��125 ��� $��8* � � RowDefinitions �� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $��7* �.+��� -   $��label3��$��1��$��28��$	��100��$��Right=�$
��Left=�$��1,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Broker���� -   $��label4��$��2��$��28��$	��100��$��Right=�$
��Left=�$��1,6,0,0q�$	��Top=�$��2����  $! Client.Properties.Resources��$ TradeStartDate���� -	   $��label5��$��2��$��1��$��28��$	��100��$��Right=�$
��Left=�$��40,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -
   $��label6��$��2��$��2��$��28��$	��100��$��Right=�$
��Left=�$��40,6,0,0q�$	��Top=�$��2����  $! Client.Properties.Resources��$ TradeEndDate���� -   $��label7��$��3��$��28��$	��100��$��Right=�$
��Left=�$��1,6,0,0q�$	��Top=�$��2����  $! Client.Properties.Resources��$ PromptStartDate���� -   $��label8��$��2��$��3��$��28��$	��100��$��Right=�$
��Left=�$��40,6,0,0q�$	��Top=�$��2����  $! Client.Properties.Resources��$ PromptEndDate���� -   $��label9��$��4��$��28��$	��100��$��Right=�$
��Left=�$��1,6,0,0q�$	��Top=�$��2����  $! Client.Properties.Resources��$ 	Commodity���� -   $��	btnSearch��$��3��$��4��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��	comboBox1��$��1��$��1��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$ 	ShortName��	 �� SelectedValuePath$	 Id������ *	Brokers+
 �� SelectedValue
 �� *SelectedBrokerId+�� -   $��	comboBox2��$��3��$��1��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$	��120��$ 	ShortName��$	 Id������ *InnerCustomer+
 �� *SelectedInnerCustomer+(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��1��$��2��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$	��120��   SelectedDate �� *StartTradeDate+  -   $��datePicker2��$��3��$��2��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$	��120�� �� *EndTradeDate+  -   $��datePicker3��$��1��$��3��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$	��120�� �� *StartPromptDate+  -   $��datePicker4��$��3��$��3��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$	��120�� �� *EndPromptDate+�� -   $��	comboBox3��$��1��$��4��$��23��$
��Left=�$��0,8,0,0q�$	��Top=�$	��120��$
 Name��$	 Id������ *Commodities+
 �� *SelectedCommodityId+�� -   $��label10��$��2��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��2����  $! Client.Properties.Resources��$ AdvancedQuery��