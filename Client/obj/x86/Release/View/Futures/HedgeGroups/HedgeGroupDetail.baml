   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 6    0Client.View.Futures.HedgeGroups.HedgeGroupDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$3  -Client.View.Futures.HedgeGroups.ResHedgeGroup�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ 
HedgeGroup�� � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value  AverageLabelStyle(  "System.Windows.Controls.DatePicker-   'Client.Converters.ContractTypeConverter  ctConverter2   ,Client.Converters.PositionDirectionConverter  pdConverter-   'Client.Converters.PositionTypeConverter  ptConverter/   )Client.Converters.AvailableHedgeLot2Color  AvailableHedgeLot2Color.   (Client.Converters.AvailableHedgeLot2Bool  AvailableHedgeLot2Bool2	   ,Client.Converters.PositionOpenCloseConverter  OpenCloseConverter  RemoveAddedQuota 	 RemoveAddedLMEPosition 
 RemoveAddedSHFEPosition  AddQuota  AddLMEPosition  AddSHFEPosition  CellStyleForQuota	 �� 	Converter  CellStyleForPosition��%7  &	        &	 �     '��      '�� :    '  t    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &		 �    &	
 �    &	 �    &	 �    &	 �    &	 �    7  &	 0    7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��          	  �� �� �� �� �� �� �� " ��.���  � �� �� *AvailableQuantityForHedge+8	   �� " ��.���  � �� �� *AvailableLotForHedge+8	   
 J� CommandBindings
 )
  #System.Windows.Input.CommandBinding
  -    
  Command# [ 
  -   # [	 
  -   # [
 
  -   # [ 
  -   # [ 
  -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $��40 ��� $
��auto ��� $��* � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -   $��lbTitle��$��31��$
��Left=�$��6,6,0,0q�$	��Top=�$��16(�$
��Bold"�$��2����  $! Client.Properties.Resources��$ 
HedgeGroup���� -	   $��label1��#��[  $
��Left=�$��6,1,0,0q�$	��Top=�
���<��$��2����  *	HedgeName+�� -
   $��textBox1��$
��Left=�$��	122,2,0,0q�$	��Top=�$��2������ *HedgeGroupName+�� -   $��label2��#��[  $
��Left=�$��	278,1,0,0q�$	��Top=�$��2����  *	HedgeDate+  -   $��datePicker1��$
��Left=�$��	394,2,0,0q�$	��Top=�$��2��$��2��   SelectedDate �� *HedgeGroupDate+�� -   $��label3��$��
278,32,0,0q�#��[  $	��Top=�
���<��$
��Left=�$��2����  $! Client.Properties.Resources��$ ExchangeRate��&   Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��
394,34,0,0q�$	��Top=�$	��120��$��2��$��2�� � ToolTip   *
USDVSCNY+   Text �� *Rate+�� -   $��label15��$��28��$
��Left=�$
��Left=�$��
520,34,0,0q�$	��Top=�$��2��$��2����  *
USDVSCNY+�� -   $��
separator1��$��5��$��Stretch=�$��6,63,6,0q�$	��Top=�$
��Auto��$��2��$��2��� -   $��leftGrid��$	��177��$
��Auto��$
��Left=�$��6,74,0,0q�$	��Top=�
�������$��2�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��label4��$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  *QuotaDetail+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .     
IsReadOnly . $
��Auto��$
��Left=�$��26,5,6,6q�$	��Top=�$
��Auto��$��1������ *AddedQuotas+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    Header   $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Quota.QuotaNo+  $
 Auto  .    $! Client.Properties.Resources��$
 Type�� �� *Quota.Contract.ContractType+#	 [   $
 Auto  .    $! Client.Properties.Resources��$ BP�� �� **(Quota.Contract.BusinessPartner.ShortName+  $
 Auto  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Quota.Commodity.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Quantity�� �� *Quota.ActualQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z   $
 Auto  .    $! Client.Properties.Resources��$ 	PricedQty�� �� *Quota.PricedQuantity+# Z   $
 Auto  .    $! Client.Properties.Resources��$ AveragePrice�� �� *Quota.AveragePrice+   	STR_PRICE# Z   $
 Auto  .    $! Client.Properties.Resources��$ PricingCurrency�� �� *Quota.Currency.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Quota.Contract.Description+4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto  .     $! Client.Properties.Resources��$ 	Operation��   CellTemplate ��  �� DataType$ DBEntity:HedgeLineQuota��.R��� #��[ ��  $! Client.Properties.Resources��$ Remove������ *	QuotaId+�� -   $��label5��$��2��$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ LMEPosition��  -   $��	dataGrid2�� .   . $��3��$
��Auto��$
��Left=�$��26,5,6,6q�$	��Top=�$
��Auto������ *AddedLMEPositions+   $
 Auto  .    $! Client.Properties.Resources��$ 	TradeDate�� �� *LMEPosition.TradeDate+$ {0:yyyy-MM-dd}��  $
 Auto  .    $! Client.Properties.Resources��$ 
PromptDate�� �� *LMEPosition.PromptDate+$ {0:yyyy-MM-dd}��  $
 Auto  .    $! Client.Properties.Resources��$ 	Commodity�� �� *LMEPosition.Commodity.Name+  $
 Auto  .    $! Client.Properties.Resources��$	 Lot�� �� *AssignedLotAmount+   STR_INTEGER# Z   $
 Auto  .    $! Client.Properties.Resources��$ Price�� �� *LMEPosition.AgentPrice+# Z   $
 Auto  .    $! Client.Properties.Resources��$ 	Direction�� �� *LMEPosition.TradeDirection+#	 [   $
 Auto  .    $! Client.Properties.Resources��$ 
Commission�� �� *AssignedCommission+   
STR_AMOUNT# Z   $
 Auto  .    $! Client.Properties.Resources��$ Broker�� �� *LMEPosition.Agent.ShortName+  $
 Auto  .     $! Client.Properties.Resources��$ 	Operation�� �� $# DBEntity:HedgeLineLMEPosition��.R��� #��[	 ��  $! Client.Properties.Resources��$ Remove������ *LMEPositionId+�� -   $��label6��$��4��$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ SHFEPosition��  -   $��	dataGrid3�� .   . $��5��$
��Auto��$
��Left=�$��26,5,6,6q�$	��Top=�$
��Auto������ *AddedSHFEPositions+   $
 Auto  .    $! Client.Properties.Resources��$ SHFEContract�� �� *SHFEPosition.Alias+  $
 Auto  .    $! Client.Properties.Resources��$ 	TradeDate�� �� **(SHFEPosition.SHFECapitalDetail.TradeDate+$ {0:yyyy-MM-dd}��  $
 Auto  .    $! Client.Properties.Resources��$ 
PromptDate�� �� *SHFEPosition.PromptDate+$ {0:yyyy-MM-dd}��  $
 Auto  .    $! Client.Properties.Resources��$	 Lot�� �� *AssignedLotAmount+# Z   $
 Auto  .    $! Client.Properties.Resources��$ Price�� �� *SHFEPosition.Price+# Z   $
 Auto  .    $! Client.Properties.Resources��$ 	Direction�� �� * SHFEPosition.PositionDirection+#	 [   $
 Auto  .    $! Client.Properties.Resources��$ 	OpenClose�� �� *SHFEPosition.OpenClose+#	 [   $
 Auto  .    $! Client.Properties.Resources��$ 
Commission�� �� *AssignedCommission+# Z   $
 Auto  .    $! Client.Properties.Resources��$ Broker�� �� *:8SHFEPosition.SHFECapitalDetail.BusinessPartner.ShortName+  $
 Auto  .     $! Client.Properties.Resources��$ 	Operation�� �� $$ DBEntity:HedgeLineSHFEPosition��.R��� #��[
 ��  $! Client.Properties.Resources��$ Remove������ *SHFEPositionId+�� -   $��button4��$��23��$
��Left=�$��
150,19,0,0q�$	��Top=�$��60��$��6����  $! Client.Properties.Resources��$
 Save���� -   $��button5��$��23��$
��Left=�$��
245,20,0,0q�$	��Top=�$��60��$��6����  $! Client.Properties.Resources��$ Cancel���� -   $��label19��#��[ $
��Left=�$��4,31,0,0q�$	��Top=�
����  ���  $! Client.Properties.Resources��$ PL���� -   $��label20��$��28��$
��Left=�$��
110,31,0,0q�$	��Top=�
����  ����� *QuotaFixedPLStr+�� -   $��label25��
����  �#��[ $
��Left=�$��5,31,0,0q�$	��Top=�$��2����  $! Client.Properties.Resources��$ PL���� -   $��label26��
����  �$��28��$
��Left=�$��
110,31,0,0q�$	��Top=�$��2������ *
LMEPLStr+�� -   $��label28��
����  �#��[ $��5,31,0,0q�$	��Top=�$��4��$
��Left=���  $! Client.Properties.Resources��$ PL���� -   $��label29��
����  �$��28��$
��Left=�$��
110,31,0,0q�$	��Top=�$��4������ *	SHFEPLStr+� -    $��	rightGrid��$��0��$
��Left=�$��	10,74,0,0q�$	��Top=�$	��469��$��1��
�������$��2�� �� $
��Auto ��� $
��Auto ��� $��* �.+�9� -!   $��	expander1��$
��Auto��$
��Left=�$��6,6,0,0q�$	��Top=�$	��550��$
��Auto����  $! Client.Properties.Resources��$ SelectQuota��.���� $��Stretch=�$��Stretch=�$��1q�$��2q�
�������._�� $
��Auto��$	��550��$
��Auto��.+��� #��[  $��1,7,0,0q�$	��Top=�$
��Left=���  $! Client.Properties.Resources��$ BP���� -"   $��textBox2��$
��Left=�$��	117,9,0,0q�$	��Top=� �� 
IsReadOnly . ���� *QuotaBPName+�� -#   $��button1��$	��...��$��23��$
��Left=�$��	241,9,0,0q�$	��Top=�$��25���� -$   $��label7��#��[  $
��Left=�$��	280,7,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -%   $��	comboBox1��$
��Left=�$��
396,9,10,0q�$	��Top=�  �� SelectedValuePath$  Id��! �� DisplayMemberPath$! 	ShortName������ *InternalCustomers+" �� SelectedValue" �� *QuotaInternalCustomerId+�� -&   $��label8��#��[  $
��Left=�$��1,39,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	StartDate��  -'   $��datePicker2��$
��Left=�$��
117,41,0,0q�$	��Top=� �� *QuotaStartDate+�� -(   $��label9��#��[  $
��Left=�$��
280,39,0,0q�$	��Top=���  $! Client.Properties.Resources��$ EndDate��  -)   $��datePicker3��$
��Left=�$��
396,41,0,0q�$	��Top=� �� *QuotaEndDate+�� -*   $��label10��#��[  $
��Left=�$��1,71,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -+   $��	comboBox2��$
��Left=�$��
117,73,0,0q�$	��Top=�$  Id��$
! Name������ *Commodities+" �� *QuotaCommodityId+�� -,   $��label35��#��[  $
��Left=�$��
280,71,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 UDF���� --   $��	comboBox8��$
��Left=�$��
396,73,0,0q�$	��Top=�$
! Name��$  Id������ *
UDFTypes+" �� *SelectedUDFTypeId+�� -.   $��button2��$��23��$
��Left=�$��241,108,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Query���� -/   $��button3��$��23��$
��Left=�$��336,108,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Reset��$  Utility.Controls.PagingControl  -0   $��pagingControl1��$
��Left=�$��	7,143,0,0q�$	��Top=�  -1   $��	dataGrid4�� .   . $
��Auto��$
��Left=�$��	7,180,6,6q�$	��Top=�$
��Auto������ *Quotas+   #   ElementStyle## [ $
 Auto  .    $! Client.Properties.Resources��$ QuotaNo�� �� *	QuotaNo+  ## [ $
 Auto  .    $! Client.Properties.Resources��$
 Type�� �� *Contract.ContractType+#	 [   ## [ $
 Auto  .    $! Client.Properties.Resources��$ BP�� �� *$"Contract.BusinessPartner.ShortName+  ## [ $
 Auto  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  ## [ $
 Auto  .    $! Client.Properties.Resources��$ Quantity�� �� *ActualQuantity+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ 	PricedQty�� �� *PricedQuantity+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ AveragePrice�� �� *AveragePrice+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$	 UDF�� �� *Contract.ContractUDF.Name+  $
 Auto  .     $! Client.Properties.Resources��$ 	Operation�� �� $ DBEntity:Quota��.R��� #��[ ��  $! Client.Properties.Resources��$ Select������ *Id+{��� *AvailableQuantityForHedge+#	 [ 9� -2   $��	expander2��$��1��$
��Auto��$
��Left=�$��6,6,0,0q�$	��Top=�$	��550��$
��auto����  *SelectLMEPosition+.���� $��Stretch=�$��Stretch=�$��1q�$��2q�
�������._�� $
��Auto��$
��Auto��$	��550��.+��� $��1,7,0,0q�#��[  $	��Top=�$
��Left=���  $! Client.Properties.Resources��$ 	Commodity���� -3   $��	comboBox3��$
��Left=�$��	117,9,0,0q�$	��Top=�$  Id��$
! Name������ *Commodities+" �� *LMEPositionCommodityId+�� -4   $��label17��#��[  $
��Left=�$��	280,7,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -5   $��
comboBox11��$
��Left=�$��	396,9,0,0q�$	��Top=�$  Id��$! 	ShortName������ *InternalCustomers+" �� *LMEPositionInternalCustomerId+�� -6   $��label11��#��[  $
��Left=�$��1,39,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PromptStartDate��  -7   $��datePicker4��$
��Left=�$��
117,41,0,0q�$	��Top=� �� *LMEPositionStartDate+�� -8   $��label12��#��[  $
��Left=�$��
280,39,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PromptEndDate��  -9   $��datePicker5��$
��Left=�$��
396,41,0,0q�$	��Top=� �� *LMEPositionEndDate+�� -:   $��label13��#��[  $
��Left=�$��1,71,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Direction���� -;   $��	comboBox4��$
��Left=�$��
117,73,0,0q�$	��Top=�$
! Name��$  Id������ *
Directions+" �� *LMEPositionDirectionId+�� -<   $��label14��#��[  $
��Left=�$��
280,71,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Broker���� -=   $��	comboBox5��$
��Left=�$��
396,73,0,0q�$	��Top=�$  Id��$! 	ShortName������ *	Brokers+" �� *LMEPositionBrokerId+�� ->   $��label16��#��[  $
��Left=�$��	1,103,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PositionType���� -?   $��	comboBox6��$
��Left=�$��117,105,0,0q�$	��Top=�$  Id��$
! Name������ *PositionTypes+" �� *LMEPositionTypeId+�� -@   $��button6��$��23��$
��Left=�$��361,105,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Query���� -A   $��button7��$��23��$
��Left=�$��456,105,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Reset��  -B   $��pagingControl2��$
��Left=�$��	7,143,0,0q�$	��Top=�  -C   $��	dataGrid5�� .   . $
��Auto��$
��Left=�$��	7,180,6,6q�$	��Top=�$
��Auto������ *LMEPositions+   ## [ $
 Auto  .    $! Client.Properties.Resources��$ 	TradeDate�� �� *	TradeDate+$ {0:yyyy-MM-dd}��  ## [ $
 Auto  .    $! Client.Properties.Resources��$ 
PromptDate�� �� *
PromptDate+$ {0:yyyy-MM-dd}��  ## [ $
 Auto  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  ## [ $
 Auto  .    $! Client.Properties.Resources��$	 Lot�� �� *	LotAmount+# Z   ## [ $
 Auto  .    $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ AvailableLot�� �� *AvailableLotForHedge+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ Price�� �� *
AgentPrice+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ 	Direction�� �� *TradeDirection+#	 [   ## [ $
 Auto  .    $! Client.Properties.Resources��$ PositionType�� �� *PositionType+#	 [   ## [ $
 Auto  .    $! Client.Properties.Resources��$ 
Commission�� �� *AgentCommission+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ Broker�� �� *Agent.ShortName+  $
 Auto  .     $! Client.Properties.Resources��$ 	Operation�� �� $ DBEntity:LMEPosition��.R��� #��[ ��  $! Client.Properties.Resources��$ Select������ *Id+{��� *AvailableLotForHedge+#	 [ 9� -D   $��	expander3��$��2��$
��Auto��$
��Left=�$��6,6,0,0q�$	��Top=�$	��550��$
��Auto����  *SelectSHFEPosition+.���� $��Stretch=�$��Stretch=�$��1q�$��2q�
�������._�� $	��550��$
��Auto��$
��Auto��.+��� -E   $��label21��$��1,7,0,0q�#��[  $	��Top=�$
��Left=���  $! Client.Properties.Resources��$ 	Commodity���� -F   $��
comboBox23��$
��Left=�$��	117,9,0,0q�$	��Top=�$  Id��$
! Name������ *Commodities+" �� *SHFEPositionCommodityId+�� -G   $��label27��#��[  $
��Left=�$��	280,7,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -H   $��
comboBox21��$
��Left=�$��	396,9,0,0q�$	��Top=�$  Id��$! 	ShortName������ *InternalCustomers+" �� * SHFEPositionInternalCustomerId+�� -I   $��label221��#��[  $
��Left=�$��1,39,0,0q�$	��Top=���  $! Client.Properties.Resources��$ TradeStartDate��  -J   $��datePicker24��$
��Left=�$��
117,41,0,0q�$	��Top=� �� *SHFEPositionStartDate+�� -K   $��label22��#��[  $
��Left=�$��
280,39,0,0q�$	��Top=���  $! Client.Properties.Resources��$ TradeEndDate��  -L   $��datePicker25��$
��Left=�$��
396,41,0,0q�$	��Top=� �� *SHFEPositionEndDate+�� -M   $��label23��#��[  $
��Left=�$��1,71,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Direction���� -N   $��
comboBox24��$
��Left=�$��
117,73,0,0q�$	��Top=�$  Id��$
! Name������ *
Directions+" �� *SHFEPositionDirectionId+�� -O   $��label24��#��[  $
��Left=�$��
280,71,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Broker���� -P   $��
comboBox25��$
��Left=�$��
396,73,0,0q�$	��Top=�$  Id��$! 	ShortName������ *	Brokers+" �� *SHFEPositionBrokerId+�� -Q   $��label18��#��[  $
��Left=�$��	1,103,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PositionType���� -R   $��	comboBox7��$
��Left=�$��117,105,0,0q�$	��Top=�$  Id��$
! Name������ *PositionTypes+" �� *SHFEPositionTypeId+�� -S   $��button26��$��23��$
��Left=�$��361,105,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Query���� -T   $��button27��$��23��$
��Left=�$��456,105,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Reset��  -U   $��pagingControl22��$
��Left=�$��	7,143,0,0q�$	��Top=�  -V   $��
dataGrid25�� .   . $
��Auto��$
��Left=�$��	7,180,6,6q�$	��Top=�$
��Auto������ *SHFEPositions+   ## [ $
 Auto  .    $! Client.Properties.Resources��$ SHFEContract�� �� *Alias+  ## [ $
 Auto  .    $! Client.Properties.Resources��$ 	TradeDate�� �� *SHFECapitalDetail.TradeDate+$ {0:yyyy-MM-dd}��  ## [ $
 Auto  .    $! Client.Properties.Resources��$ 
PromptDate�� �� *
PromptDate+$ {0:yyyy-MM-dd}��  ## [ $
 Auto  .    $! Client.Properties.Resources��$	 Lot�� �� *LotQuantity+# Z   ## [ $
 Auto  .    $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ AvailableLot�� �� *AvailableLotForHedge+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ Price�� �� *Price+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ 	Direction�� �� *PositionDirection+#	 [   $
 Auto  .    $! Client.Properties.Resources��$ 	OpenClose�� �� *	OpenClose+#	 [   ## [ $
 Auto  .    $! Client.Properties.Resources��$ PositionType�� �� *PositionType+#	 [   ## [ $
 Auto  .    $! Client.Properties.Resources��$ 
Commission�� �� *
Commission+# Z   ## [ $
 Auto  .    $! Client.Properties.Resources��$ Broker�� �� *-+SHFECapitalDetail.BusinessPartner.ShortName+  $
 Auto  .     $! Client.Properties.Resources��$ 	Operation�� �� $ DBEntity:LMEPosition��.R��� #��[ ��  $! Client.Properties.Resources��$ Select������ *Id+{��� *AvailableLotForHedge+#	 [ �� -W   $��button8��$��23��$
��Left=�$��	122,0,0,7q�$��75��$��1����  *SettlementPL+�� -X   $��label30��$��28��$��Right=�$��60��$
��Left=�$��	209,0,0,0q�$	��Top=�
����  �$��1��$��2����  $! Client.Properties.Resources��$ TotalPL���� -Y   $��label31��$��28��$
��Left=�$��	271,0,0,0q�$	��Top=�
����  �$��1��$��2������ *
TotalPLStr+�� -Z   $��label36��$��保值类型��$��2��$��28��$
��Left=�$��	58,32,0,0q�$	��Top=��� -[   $��	comboBox9��$��2��$��23��$
��Left=�$��
122,34,0,0q�$	��Top=�$	��120��$  Id��$
! Name������ *ArbitrageTypes+" �� *SelectedArbitrageTypeId+