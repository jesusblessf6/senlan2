   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 2    ,Client.View.Reports.PhysicalAndFuturesReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *PhysicalFuturesPnL+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%d  &	        '�� �     '  �     &	 �     &	 �     7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� " ��.���  � �� �� *
LineType+8   .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $	��68* �.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *PhysicalFuturesPnL+�� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��620����  	   ResxName$!	 Client.Properties.Resources��

   Key$
 
Conditions��.��� .+��� -   $��label1��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	Commodity���� -   $��	comboBox1��$
��Left=�$��
366,12,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Commodities+ �� SelectedValue �� *SelectedCommodityId+�� -   $��label3��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	StartDate��  -   $��datePicker1��$
��Left=�$��
107,44,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -   $��label4��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 EndDate��  -	   $��datePicker2��$
��Left=�$��
366,44,0,0q�$	��Top=� �� *	EndDate+�� -
   $��label5��#��[  $
��Left=�$��1,10,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 InternalCustomer���� -   $��	comboBox3��$
��Left=�$��
107,12,0,0q�$	��Top=�$ 	ShortName��$ Id������ *InternalCustomers+ �� *SelectedInternalCustomerId+�� -   $��button1��$��23��$
��Left=�$��
505,44,0,0q�$	��Top=�$��75����  $!	 Client.Properties.Resources��$
 Query��&   System.Windows.Controls.DataGrid  -   $��dataGridSHFE��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	12,40,0,0q�$	��Top=�$
��Auto��$��3��   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .  1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [    Header   $!	 Client.Properties.Resources��$
 Broker��  $
 Auto  .  # [    $!	 Client.Properties.Resources��$
 	Commodity�� 	  Binding �� *CommodityName+  $
 Auto  .  # [    $!	 Client.Properties.Resources��$
 ClosePL�� �� *
ClosePNL+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z   $
 Auto  .  # [    $#	 Client.View.Reports.ResReport��$
 FloatPnL�� �� *
FloatPNL+# Z   $
 Auto  .  # [    $!	 Client.Properties.Resources��$
 
Commission�� �� *
Commission+# Z   $
 Auto  .  # [    $!	 Client.Properties.Resources��$
 TotalPL�� �� *PNL+# Z  �� 
GroupStyle (  "System.Windows.Controls.GroupStyle    GroupHerderStyle   ContainerStyle# [    Panel �� .R�>  8System.Windows.Controls.Primitives.DataGridRowsPresenter    -   $��dataGridLME�� .  $
��Auto��$
��Left=� . $��	12,40,0,0q�$	��Top=�$
��Auto��$��4������ *	Summaries+    . $
 Auto # [    $#	 Client.View.Reports.ResReport��$
 
BrokerName�� �� *
BrokerName+   . $
 Auto # [    $#	 Client.View.Reports.ResReport��$
 DuedLockedPnL�� �� *DuedLockedPL+# Z    . $
 Auto # [    $#	 Client.View.Reports.ResReport��$
 UnduedLockedPnL�� �� *UnduedLockedPL+# Z    . $
 Auto # [    $#	 Client.View.Reports.ResReport��$
 UnduedFloatPnL�� �� *UnduedFloatPL+# Z    . $
 Auto # [    $!	 Client.Properties.Resources��$
 Summary�� �� *SumPL+# Z    # [  �� .R�  �� -   $��label2��$��3��$��28��$
��Left=�$��6,15,0,0q�$	��Top=���  *	SHFEPnL+�� -   $��label6��$��4��$��28��$
��Left=�$��6,15,0,0q�$	��Top=���  *LMEPositionPL+�� -   $��label7��$��28��$
��Left=�$��6,15,0,0q�$	��Top=�$��2����  *PhysicalForeignTradePnL+  -   $��dataGridPhysicalExternal�� .  $
��Auto��$
��Left=� . $��	12,40,0,0q�$	��Top=�$
��Auto��$��2������     .  # [ $
 Auto  �� *CommodityName+   $!	 Client.Properties.Resources��$
 	Commodity��   .  # [ $
 Auto  �� *	BuySumQty+ 
  STR_QUANTITY# Z    $!	 Client.Properties.Resources��$
 PurchaseQty��   .  # [ $
 Auto  �� *BuyAvgPrice+ 
  	STR_PRICE# Z    $#	 Client.View.Reports.ResReport��$
 PruchaseAveragePrice��   .  # [ $
 Auto  �� *
SellSumQty+# Z    $!	 Client.Properties.Resources��$
 SalesQty��   .  # [ $
 Auto  �� *SellAvgPrice+# Z    $#	 Client.View.Reports.ResReport��$
 SalesAveragePrice��   .  # [ $
 Auto  �� *	SellPNL+# Z    $#	 Client.View.Reports.ResReport��$
 SalesPnL��   .  # [ $
 Auto  �� *InventorySumQty+# Z    $#	 Client.View.Reports.ResReport��$
 	Inventory��   .  # [ $
 Auto  �� *LatestPrice+# Z    $#	 Client.View.Reports.ResReport��$
 LatestPrice��   .  # [ $
 Auto  �� *
FloatPNL+# Z    $#	 Client.View.Reports.ResReport��$
 FloatPnL��   .  # [ $
 Auto  �� *
TotalPNL+# Z    $!	 Client.Properties.Resources��$
 TotalPL��   # [  �� .R�    -   $��dataGridPhysicalDomestic�� .  $
��Auto��$
��Left=� . $��	12,40,0,0q�$	��Top=�$
��Auto��$��1������     .  # [ $
 Auto  �� *CommodityName+   $!	 Client.Properties.Resources��$
 	Commodity��   .  # [ $
 Auto  �� *	BuySumQty+# Z    $!	 Client.Properties.Resources��$
 PurchaseQty��   .  # [ $
 Auto  �� *BuyAvgPrice+# Z    $#	 Client.View.Reports.ResReport��$
 PruchaseAveragePrice��   .  # [ $
 Auto  �� *
SellSumQty+# Z    $!	 Client.Properties.Resources��$
 SalesQty��   .  # [ $
 Auto  �� *SellAvgPrice+# Z    $#	 Client.View.Reports.ResReport��$
 SalesAveragePrice��   .  # [ $
 Auto  �� *	SellPNL+# Z    $#	 Client.View.Reports.ResReport��$
 SalesPnL��   .  # [ $
 Auto  �� *InventorySumQty+# Z    $#	 Client.View.Reports.ResReport��$
 	Inventory��   .  # [ $
 Auto  �� *LatestPrice+# Z    $#	 Client.View.Reports.ResReport��$
 LatestPrice��   .  # [ $
 Auto  �� *
FloatPNL+# Z    $#	 Client.View.Reports.ResReport��$
 FloatPnL��   .  # [ $
 Auto  �� *
TotalPNL+# Z    $!	 Client.Properties.Resources��$
 TotalPL��   # [  �� .R�  �� -   $��label8��$��28��$
��Left=�$��	6,15,0,22q�$	��top=�$��1����  *PhysicalDomesticTradePnL+�� -   $��
separator1��$��17��$��6,0,6,0q�$	��Top=�$��1��