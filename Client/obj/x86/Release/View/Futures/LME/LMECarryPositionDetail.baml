   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 4   .Client.View.Futures.LME.LMECarryPositionDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$$  Client.View.Futures.LME.ResLME�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *LMECarryPosition+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%V  &	        '�� �     '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -   $��rootGrid�� � ColumnDefinitions �� $��0 ��� $	��116 ��� $��6 ��� $	��124 ��� $��30 ��� $	��111 ��� $��6 ��� $	��120 ��� $��4 ��� $	��53* � � RowDefinitions �� $��38 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $
��auto ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $��32 ��� $��0 ��� $
��auto ��� $��0 ��� $	��106 ��� $��0 ��� $	��120 ��� $��0 ��� $	��20* �.+��� -   $��lbTitle��$��3��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *LMECarryPosition+�� #��[  $��1��$��6,0,0,0q�$��1��$	��Top=�$
��Left=�
���<����  	   ResxName$!	 Client.Properties.Resources��

   Key$
 	Commodity���� -   $��	comboBox3�� �� DisplayMemberPath$
 Name��$
��Left=�$��0,2,0,0q� �� SelectedValuePath$ Id��$��3��$��1��$	��Top=����� *Metals+ �� SelectedValue �� *SelectedMetal+{��� *IsCommodityEnable+�� #��[  $��5��$��1,0,0,0q�$��1��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$	
 Lot��&   Utility.Controls.CurrencyTextBox  -   $��currencyTextBox2��$��23��$
��Left=�$��0,2,0,0q�$	��Top=�$	��120��$��7��$��1��   IsPositiveNumber .    	IsInteger .    Text �� *	LotAmount+$   DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {��� *IsLotQuantityEnable+�� #��[  $��1��$��6,0,0,0q�$��3��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 InternalCustomer���� -   $��	comboBox2��$ 	ShortName��$
��Left=�$��0,2,0,0q�$ Id��$	��Top=�$��3��$��3������ *ICs+ �� *ICId+�� #��[  $��5��$��1,0,0,0q�$��3��$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 Quota���� -   $��button3��$	��...��$
��Left=�$��0,2,0,0q�$	��Top=�$��25��$��23��$��9��$��3���� $��7��$��0,2,0,0q�$��3��$
��Left=�$	��Top=�{�.  ���� *	QuotaNo+�� #��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1��$��5��
���<����  $!	 Client.Properties.Resources��$
 	TradeDate��  $��3��$
��Left=�$��0,2,0,0q�$	��Top=�$��5��   SelectedDate �� *	TradeDate+�� #��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1��$��7��
���<����  $!	 Client.Properties.Resources��$
 	Direction���� -   $��	comboBox1��$	 Key��$��3��$
��Left=�$��0,2,0,0q�$ Value��$	��Top=�$��7������ *TradeDirections+ �� *TradeDirection+{��� *IsTradeDirectionEnable+�� #��[  $
��Left=�$��1,0,0,0q�$	��Top=�$��5��$��7��
���<����  $!	 Client.Properties.Resources��$
 PositionType���� -   $��	comboBox5��$	 Key��$��7��$
��Left=�$��0,2,0,0q�$ Value��$	��Top=�$��7������ *PositionTypes+ �� *PositionType+�� #��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1��$��9��
���<����  $!	 Client.Properties.Resources��$
 
PromptDate��  $��3��$
��Left=�$��0,2,0,0q�$	��Top=�$��9�� �� *
PromptDate+�� #��[  $��1��$��6,0,0,0q�$��11��$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 Broker���� -	   $��	comboBox4��$ 	ShortName��$
��Left=�$��0,2,0,0q�$ Id��$	��Top=�$��3��$��11������ *	Brokers+ �� *
BrokerId+�� #��[  $��5��$��1,0,0,0q�$��11��$
��Left=�$	��Top=�
���<����  *BrokerPrice+  -
   $��currencyTextBox1��$
��Left=�$	��120��$��7��$��11��$��0,2,0,0q�$��23��$	��Top=� �� *
AgentPrice+   	STR_PRICE# Z {��� *IsPriceEnable+�� -   $��lbClient��#��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1��$��15����  $!	 Client.Properties.Resources��$
 BP���� -   $��	txtClient��$
��Left=�$��0,2,0,7q� �� TextWrapping$
 Wrap=�$��3��$��15��{�.  ���� *BPartnerName+�� -   $��	btnClient��$	��...��$
��Left=�$��0,2,0,0q�$	��Top=�$��25��$��23��$��4��$��15��{��� *
IsLMEAgent+�� -   $��lbClientPrice��#��[  $
��Left=�$��1,0,0,0q�$	��Top=�$��5��$��13����  *CustomerPrice+  -   $��txtClientPrice��$��23��$
��Left=�$	��Top=�$	��120��$��7��$��13��$��0,2,0,0q� �� *ClientPrice+# Z {��� *
IsLMEAgent+�� #��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��13��
���<��$��1����  $!	 Client.Properties.Resources��$
 AgentCommission��  -   $��currencyTextBox5��$��23��$
��Left=�$	��Top=�$	��120��$��3��$��13��$��0,2,0,0q� �� *AgentCommission+   
STR_AMOUNT# Z �� -   $��lbClientCommission��#��[  $
��Left=�$��1,0,0,0q�$	��Top=�$��5��$��15����  $!	 Client.Properties.Resources��$
 CustomerCommission��  -   $��txtClientCommission��$��23��$
��Left=�$	��Top=�$	��120��$��7��$��15��$��0,2,0,0q� �� *ClientCommission+# Z {��� *
IsLMEAgent+�� #��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1��$��17��
���<����  $!	 Client.Properties.Resources��$
 	Direction���� -   $��	comboBox7��$	 Key��$��3��$
��Left=�$��0,2,0,0q�$ Value��$	��Top=�$��17��{�.  ���� *TradeDirections+ �� *TradeDirection2+�� #��[  $��5��$
��Left=�$��1,0,0,0q�$	��Top=�$��17��
���<����  $!	 Client.Properties.Resources��$
 PositionType���� -   $��	comboBox8��$	 Key��$��7��$
��Left=�$��0,2,0,0q�$ Value��$	��Top=�$��17��{�.  ���� *PositionTypes+ �� *PositionType2+�� #��[  $��1��$
��Left=�$��6,0,0,0q�$	��Top=�$��19��
���<����  $!	 Client.Properties.Resources��$
 
PromptDate��  $��3��$
��Left=�$��0,2,0,0q�$	��Top=�$��19�� �� *PromptDate2+�� #��[  $��1��$��21��$
��Left=�$��6,0,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 Broker���� -   $��	comboBox6��$ 	ShortName��$��3��$��21��$
��Left=�$��0,2,0,0q�$ Id��$	��Top=����� *	Brokers+ �� *	BrokerId2+�� #��[  $��5��$��21��$��1,0,0,0q�$	��Top=�
���<��$
��Left=���  *BrokerPrice+  -   $��currencyTextBox6��$��7��$��21��$��23��$
��Left=�$	��Top=�$	��120��$��0,2,0,0q� �� *AgentPrice2+# Z {��� *IsPriceEnable+�� -   $��	lbClient2��#��[  $��1��$��25��$
��Left=�$��6,0,0,0q�$��28��$	��Top=���  $!	 Client.Properties.Resources��$
 BP���� -   $��
txtClient2��$��3��$��25��$
��Left=�{�.  $��0,2,0,7q�$
 Wrap=�$��23������ *BPartnerName2+�� -   $��
btnClient2��$	��...��$��4��$��25��$
��Left=�$��0,2,0,0q�$	��Top=�$��25��$��23��{�.  �� -   $��lbClientPrice2��#��[  $��5��$��23��$
��Left=�$��1,0,0,0q�$	��Top=���  *CustomerPrice+  -   $��txtClientPrice2��$��7��$��23��$��23��$
��Left=�$	��Top=�$	��120��$��0,2,0,0q� �� *ClientPrice2+# Z �� #��[  $��23��$
��Left=�$��6,0,0,0q�$	��Top=�
���<��$��1����  $!	 Client.Properties.Resources��$
 AgentCommission��  -   $��currencyTextBox8��$��3��$��23��$��23��$
��Left=�$	��Top=�$	��120��$��0,2,0,0q� �� *AgentCommission2+# Z �� -   $��lbClientCommission2��#��[  $��5��$��25��$
��Left=�$��1,0,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 CustomerCommission��  -   $��txtClientCommission2��$��7��$��25��$��23��$
��Left=�$	��Top=�$	��120��$��0,2,0,0q� �� *ClientCommission2+# Z �� #��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��1��$��27����  $!	 Client.Properties.Resources��$
 Comments���� -   $��textBox6��$��3��$	��100��$
��Left=�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn . $
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=� �� 	MaxLength$	 255��$��6��$��27��$��0,2,0,0q����� *	Comment+�� -    $��3��$��
107,25,0,0q�$��29��$	��Top=�$
��Left=�$��60��$��23��$��12����  $!	 Client.Properties.Resources��$

 Save���� $y�Hidden=�$��7��$��	23,24,0,0q�$��29��$
��Left=�$	��Top=�$��60��$��23����  $!	 Client.Properties.Resources��$
 SaveAsDraft���� -!   $
��Left=�$��	48,25,0,0q�$	��Top=�$��60��$��23��$��5��$��29����  $!	 Client.Properties.Resources��$
 Cancel��