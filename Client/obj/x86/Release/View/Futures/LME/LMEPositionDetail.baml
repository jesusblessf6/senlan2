   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient /   )Client.View.Futures.LME.LMEPositionDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$$  Client.View.Futures.LME.ResLME�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *LMECommonPosition+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%V  &	        '�� �     '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -   $��rootGrid�� � ColumnDefinitions �� $��0 ��� $	��116 ��� $��6 ��� $	��124 ��� $��30 ��� $	��111 ��� $��6 ��� $	��120 ��� $��4 ��� $	��53* � � RowDefinitions �� $��38 ��� $��31 ��� $��1 ��� $��31 ��� $��1 ��� $��31 ��� $��1 ��� $��31 ��� $��1 ��� $��31 ��� $��1 ��� $
��AUTO ��� $��0 ��� $
��AUTO ��� $��1 ��� $	��102 ��� $��1 ��� $	��20* �.+��� -   $��lbTitle��$��4��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *LMECommonPosition+�� #��[  $��1��$��6,0,0,0q�$��1��$	��Top=�$
��Left=�
���<����  	   ResxName$!	 Client.Properties.Resources��

   Key$
 	Commodity���� -   $��	comboBox3�� �� DisplayMemberPath$
 Name��$
��Left=�$��0,2,0,0q� �� SelectedValuePath$ Id��$	��Top=�$��3��$��1��$��2������ *Metals+ �� SelectedValue �� *SelectedMetal+{��� *IsCommodityEnable+�� $��5��#��[  $��1,0,0,0q�$��1��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$	
 Lot��&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox2��$��23��$
��Left=�$��0,2,0,0q�$	��Top=�$	��120��$��7��$��1��   IsPositiveNumber .    	IsInteger .    Text �� *	LotAmount+{��� *IsLotQuantityEnable+�� #��[  $��1��$��6,0,0,0q�$��3��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 	TradeDate��  $
��Left=�$��0,2,0,0q�$	��Top=�$��3��$��3��   SelectedDate �� *	TradeDate+�� $��5��#��[  $��1,0,0,0q�$��3��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 
PromptDate��  $
��Left=�$��0,2,0,0q�$	��Top=�$��7��$��3��$��3�� �� *
PromptDate+�� #��[  $��1��$��6,0,0,0q�$��5��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 	Direction���� -   $��	comboBox1��$	 Key��$
��Left=�$��0,2,0,0q�$ Value��$	��Top=�$��3��$��5������ *TradeDirections+ �� *TradeDirection+{��� *IsTradeDirectionEnable+�� $��5��#��[  $��1,0,0,0q�$��5��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 PositionType���� -   $��	comboBox5��$	 Key��$
��Left=�$��0,2,0,0q�$ Value��$	��Top=�$��7��$��5��$��3������ *PositionTypes+ �� *PositionType+�� #��[  $��1��$��6,0,0,0q�$��7��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 InternalCustomer���� -   $��	comboBox2��$ 	ShortName��$
��Left=�$��0,2,0,0q�$ Id��$	��Top=�$��3��$��7��$��2������ *ICs+ �� *ICId+�� $��5��#��[  $��13��$
��Left=�$	��Top=�$y�	Collapsed=�$��1,0,0,0q���  $!	 Client.Properties.Resources��$
 Quota���� -   $��button3��$	��...��$
��Left=�$��0,2,0,0q�$	��Top=�$y�	Collapsed=�$��25��$��23��$��9��$��13���� $��7��$��0,2,0,0q�$��13��$
��Left=�$	��Top=�$y�	Collapsed=� �� 
IsReadOnly . ���� *	QuotaNo+�� #��[  $��5��$
��Left=�$	��Top=�
���<��$��7��$��1,0,0,0q���  $!	 Client.Properties.Resources��$
 Broker���� -	   $��	comboBox4��$ 	ShortName��$
��Left=�$��0,2,0,0q�$ Id��$	��Top=�$��7��$��7������ *	Brokers+ �� *
BrokerId+�� $��1��$��6,0,0,0q�#��[  $��9��$
��Left=�$	��Top=�
���<����  *BrokerPrice+  -
   $��currencyTextBox1��$��23��$
��Left=�$��0,2,0,0q�$	��Top=�$	��120��$��3��$��9�� �� *
AgentPrice+{��� *IsPriceEnable+�� -   $��lbClient��#��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1��$��11����  $!	 Client.Properties.Resources��$
 BP���� -   $��	txtClient��$
��Left=�$��0,2,0,7q� �� TextWrapping$
 Wrap=�$��3��$��11��{�.  ���� *BPartnerName+�� -   $��	btnClient��$	��...��$
��Left=�$��0,2,0,0q�$��25��$��4��$��11��$��23��$	��Top=��� -   $��lbClientPrice��$
��Left=�#��[  $��1,0,0,0q�$	��Top=�$��5��$��11����  *CustomerPrice+  -   $��txtClientPrice��$��23��$
��Left=�$��0,2,0,0q�$	��Top=�$	��120��$��7��$��11�� �� *ClientPrice+�� $
��Left=�#��[  $	��Top=�$��9��
���<��$��5��$��1,0,0,0q���  $!	 Client.Properties.Resources��$
 AgentCommission��  -   $��currencyTextBox5��$��23��$
��Left=�$��0,2,0,0q�$	��Top=�$	��120��$��7��$��9�� �� *AgentCommission+�� -   $��lbClientCommission��$
��Left=�#��[  $	��Top=�$��1��$��13��$��6,0,0,0q���  $!	 Client.Properties.Resources��$
 CustomerCommission��  -   $��txtClientCommission��$
��Left=�$��0,2,0,6q�$	��120��$��23��$��3��$��13�� �� *ClientCommission+�� $
��Left=�#��[  $��6,0,0,0q�$	��Top=�$��1��$��15����  $!	 Client.Properties.Resources��$
 Comments���� -   $��textBox6��$��3��$	��100��$
��Left=�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn . $
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=� �� 	MaxLength$	 255��$��6��$��15��$��0,2,0,0q����� *	Comment+�� -   $��3��$��
112,25,0,0q�$��17��$	��Top=�$
��Left=�$��60��$��23��$��3����  $!	 Client.Properties.Resources��$

 Save���� $��7��$��	60,24,0,0q�$��17��$y�Hidden=�$
��Left=�$	��Top=�$��60��$��23����  $!	 Client.Properties.Resources��$
 SaveAsDraft���� -   $
��Left=�$��	35,25,0,0q�$	��Top=�$��60��$��23��$��5��$��17����  $!	 Client.Properties.Resources��$
 Cancel��