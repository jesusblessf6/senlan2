   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      6    0Client.View.Futures.HedgeGroups.HedgeGroupDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$3  -Client.View.Futures.HedgeGroups.ResHedgeGroup��5       � Language 5	      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5           ResxName$! Client.Properties.Resources��
   Key$ 
HedgeGroup�� � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value  AverageLabelStyle(  "System.Windows.Controls.DatePicker-   'Client.Converters.ContractTypeConverter  ctConverter2   ,Client.Converters.PositionDirectionConverter  pdConverter-   'Client.Converters.PositionTypeConverter  ptConverter/   )Client.Converters.AvailableHedgeLot2Color  AvailableHedgeLot2Color.   (Client.Converters.AvailableHedgeLot2Bool  AvailableHedgeLot2Bool2	   ,Client.Converters.PositionOpenCloseConverter  OpenCloseConverter  RemoveAddedQuota 	 RemoveAddedLMEPosition 
 RemoveAddedSHFEPosition  AddQuota  AddLMEPosition  AddSHFEPosition  CellStyleForQuota	 �� 	Converter  CellStyleForPosition��%�  &	        &	 �     '�� �    '�� c    '  �    &	 Q    &	 d    &	 w    &	 �    &	 �    &	 �    &	 �    &		 �    &	
 �    &	 �    &	     &	 "    &	 5    7  &	 �    7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5        � ��$ Right=�6;   6K   5!      �� 5$   
   " ��6   .�5%      ��  � ��$ 23��6'   64   �� 5&       � ��$	 120��6&   64   5'      �� 5)   
   " ��6   .�5*      ��  � ��$ 23��6'   64   �� 5+       � ��$	 120��6&   64   5,      �� 5.   
   "  6   .�5/      ��  � ��$ 23��6'   64   �� 50       � ��$	 120��6&   64   51        53   
   68     54   
   6=     55   
   68     56   
   6F     57   
   6D   	  58   
   6D   �� 5:   
   63   �� 5;   
   69   �� 5<   
   6:   �� 5>   
   6+   �� 5?   
   61   �� 5@   
   62   �� 5B   
   " ��6*   .�5C      ��  � �� 6+   �� *AvailableQuantityForHedge+8	   6�   5D      �� 5F   
   " ��6-   .�5G      ��  � �� 6+   �� *AvailableLotForHedge+8	   6�   5H      5I      
 J� CommandBindings
 5K      )
  #System.Windows.Input.CommandBinding
  5L   
   -   5         
  Command# [ 5L      6�   
  5M   
   -   5        # [	 5M      6�   
  5N   
   -   5        # [
 5N      6�   
  5O   
   -   5        # [ 5O      6{   
  5P   
   -   5        # [ 5P      6�   
  5Q   
   -   5        # [ 5Q      6�   .��5T      �� $
��Auto=�6   $
��Auto=�68   .��5U   
   � -   5        $��rootGrid��5U       � RowDefinitions 5V      �� 5W      $��40 �6    �� 5X      $
��auto �6    �� 5Y      $��* �6     � ColumnDefinitions 5[      �� 5\      $
��Auto �6#   �� 5]      $��* �6#   .+�5_      �� -   5        $��lbTitle��5_   �   $��31��6Z   $
��Left=�6f   $��6,6,0,0q�6�   $	��Top=�6�   $��16(�6�   $
��Bold"�6�   $��2��6�   ��6     $! Client.Properties.Resources��$ 
HedgeGroup��6�   �� 5`      -	   5        $��label1��5`      #��[  6/   $
��Left=�6S   $��6,1,0,0q�6n   $	��Top=�6�   
���<��$��2��6�   ��6     *	HedgeName+6�   �� 5a      -
   5        $��textBox1��5a   D   $
��Left=�6   $��	122,2,0,0q�61   $	��Top=�6T   $��2��6�   ��6l   �� *HedgeGroupName+6�   �� 5b      -   5        $��label2��5b   �   #��[  6/   $
��Left=�6S   $��	278,1,0,0q�6n   $	��Top=�6�   $��2��6�   ��6     *	HedgeDate+6�     5c      -   5        $��datePicker1��5c   G   $
��Left=�6   $��	394,2,0,0q�64   $	��Top=�6Z   $��2��6�   $��2��6�      SelectedDate 6r   �� *HedgeGroupDate+6�   �� 5d      -   5        $��label3��5d   �   $��
278,32,0,0q�6\   #��[  6p   $	��Top=�6�   
���<��$
��Left=�6�   $��2��6�   ��6     $! Client.Properties.Resources��$ ExchangeRate��6�   &   Utility.Controls.CurrencyTextBox  5e      -   5        $��currencyTextBox1��5e   \   $��23��6!   $
��Left=�6-   $��
394,34,0,0q�6H   $	��Top=�6t   $	��120��6�   $��2��6�   $��2��6�    � ToolTip 6�     *
USDVSCNY+   Text 6�   �� *Rate+6�   �� 5f      -   5        $��label15��5f   �   $��28��6.   $
��Left=�6:   $
��Left=�6\   $��
520,34,0,0q�6w   $	��Top=�6�   $��2��6�   $��2��6�   ��6     *
USDVSCNY+6�   �� 5g      -   5        $��
separator1��5g   S   $��5��6   $��Stretch=�6#   $��6,63,6,0q�6A   $	��Top=�6e   $
��Auto��6}   $��2��6�   $��2��6�   � 5i      -   5        $��leftGrid��5i      $	��177��6#   $
��Auto��63   $
��Left=�6A   $��6,74,0,0q�6\   $	��Top=�6n   
�������$��2��6�    5j      �� 5k      $
��Auto �6$   �� 5l      $
��Auto �6$   �� 5m      $
��Auto �6$   �� 5n      $
��Auto �6$   �� 5o      $
��Auto �6$   �� 5p      $
��Auto �6$   �� 5q      $��* �6$   .+�5s      �� -   5        $��label4��5s   m   $��28��65   $
��Left=�6A   $��6,6,0,0q�6\   $	��Top=�6{   ��6     *QuotaDetail+6{   &   System.Windows.Controls.DataGrid  5t      -   5        $��	dataGrid1��5t   �      AutoGenerateColumns .     
IsReadOnly . $
��Auto��6I   $
��Left=�6{   $��26,5,6,6q�6�   $	��Top=�6�   $
��Auto��6�   $��1��6�   ��6W   �� *AddedQuotas+   Columns 5u      0  *System.Windows.Controls.DataGridTextColumn  5v      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6o      CanUserSort .    Header 6-     $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6|   �� *Quota.QuotaNo+6�     5w      $
 Auto 6l    .  6-     $! Client.Properties.Resources��$
 Type�� 6y   �� *Quota.Contract.ContractType+#	 [ 6�     5x      $
 Auto 6j    .  6-     $! Client.Properties.Resources��$ BP�� 6w   �� **(Quota.Contract.BusinessPartner.ShortName+6�     5y      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	Commodity�� 6~   �� *Quota.Commodity.Name+6�     5z      $
 Auto 6p    .  6-     $! Client.Properties.Resources��$ Quantity�� 6}   �� *Quota.ActualQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�     5{      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	PricedQty�� 6~   �� *Quota.PricedQuantity+# Z 6�     5|      $
 Auto 6t    .  6-     $! Client.Properties.Resources��$ AveragePrice�� 6�   �� *Quota.AveragePrice+   	STR_PRICE# Z 6�     5}      $
 Auto 6w    .  6-     $! Client.Properties.Resources��$ PricingCurrency�� 6�   �� *Quota.Currency.Name+6�     5~      $
 Auto 6p    .  6-     $! Client.Properties.Resources��$ Comments�� 6}   �� *Quota.Contract.Description+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Auto 6u    .   61     $! Client.Properties.Resources��$ 	Operation��   CellTemplate 5�      �� 5�   "    �� DataType$ DBEntity:HedgeLineQuota��6/   .R�5�   &   �� #��[ 6�   ��6-     $! Client.Properties.Resources��$ Remove����6o   �� *	QuotaId+6�   5�   #   5�      5�      �� 5�      -   5        $��label5��5�   �   $��2��6_   $��28��6l   $
��Left=�6x   $��6,6,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ LMEPosition��6�     5�      -   5        $��	dataGrid2��5�   �    .   . $��3��6I   $
��Auto��6V   $
��Left=�6�   $��26,5,6,6q�6�   $	��Top=�6�   $
��Auto��6�   ��6d   �� *AddedLMEPositions+ 5�        5�      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	TradeDate�� 6~   �� *LMEPosition.TradeDate+$ {0:yyyy-MM-dd}��6�     5�      $
 Auto 6r    .  6-     $! Client.Properties.Resources��$ 
PromptDate�� 6   �� *LMEPosition.PromptDate+$ {0:yyyy-MM-dd}��6�     5�      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	Commodity�� 6~   �� *LMEPosition.Commodity.Name+6�     5�      $
 Auto 6k    .  6-     $! Client.Properties.Resources��$	 Lot�� 6x   �� *AssignedLotAmount+   STR_INTEGER# Z 6�     5�      $
 Auto 6m    .  6-     $! Client.Properties.Resources��$ Price�� 6z   �� *LMEPosition.AgentPrice+# Z 6�     5�      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	Direction�� 6~   �� *LMEPosition.TradeDirection+#	 [ 6�     5�      $
 Auto 6r    .  6-     $! Client.Properties.Resources��$ 
Commission�� 6   �� *AssignedCommission+   
STR_AMOUNT# Z 6�     5�      $
 Auto 6n    .  6-     $! Client.Properties.Resources��$ Broker�� 6{   �� *LMEPosition.Agent.ShortName+6�     5�      $
 Auto 6u    .   61     $! Client.Properties.Resources��$ 	Operation�� 5�      �� 5�   "   $# DBEntity:HedgeLineLMEPosition��6/   .R�5�   &   �� #��[	 6�   ��6-     $! Client.Properties.Resources��$ Remove����6o   �� *LMEPositionId+6�   5�   #   5�      5�      �� 5�      -   5        $��label6��5�   �   $��4��6`   $��28��6m   $
��Left=�6y   $��6,6,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ SHFEPosition��6�     5�      -   5        $��	dataGrid3��5�   �    .   . $��5��6I   $
��Auto��6V   $
��Left=�6�   $��26,5,6,6q�6�   $	��Top=�6�   $
��Auto��6�   ��6d   �� *AddedSHFEPositions+ 5�        5�      $
 Auto 6t    .  6-     $! Client.Properties.Resources��$ SHFEContract�� 6�   �� *SHFEPosition.Alias+6�     5�      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	TradeDate�� 6~   �� **(SHFEPosition.SHFECapitalDetail.TradeDate+$ {0:yyyy-MM-dd}��6�     5�      $
 Auto 6r    .  6-     $! Client.Properties.Resources��$ 
PromptDate�� 6   �� *SHFEPosition.PromptDate+$ {0:yyyy-MM-dd}��6�     5�      $
 Auto 6k    .  6-     $! Client.Properties.Resources��$	 Lot�� 6x   �� *AssignedLotAmount+# Z 6�     5�      $
 Auto 6m    .  6-     $! Client.Properties.Resources��$ Price�� 6z   �� *SHFEPosition.Price+# Z 6�     5�      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	Direction�� 6~   �� * SHFEPosition.PositionDirection+#	 [ 6�     5�      $
 Auto 6q    .  6-     $! Client.Properties.Resources��$ 	OpenClose�� 6~   �� *SHFEPosition.OpenClose+#	 [ 6�     5�      $
 Auto 6r    .  6-     $! Client.Properties.Resources��$ 
Commission�� 6   �� *AssignedCommission+# Z 6�     5�      $
 Auto 6n    .  6-     $! Client.Properties.Resources��$ Broker�� 6{   �� *:8SHFEPosition.SHFECapitalDetail.BusinessPartner.ShortName+6�     5�      $
 Auto 6u    .   61     $! Client.Properties.Resources��$ 	Operation�� 5�      �� 5�   "   $$ DBEntity:HedgeLineSHFEPosition��6/   .R�5�   &   �� #��[
 6�   ��6-     $! Client.Properties.Resources��$ Remove����6o   �� *SHFEPositionId+6�   5�   #   5�      5�      �� 5�      -   5        $��button4��5�   �   $��23��6Y   $
��Left=�6e   $��
150,19,0,0q�6�   $	��Top=�6�   $��60��6�   $��6��6�   ��6     $! Client.Properties.Resources��$
 Save��6�   �� 5�      -   5        $��button5��5�   �   $��23��6[   $
��Left=�6g   $��
245,20,0,0q�6�   $	��Top=�6�   $��60��6�   $��6��6�   ��6     $! Client.Properties.Resources��$ Cancel��6�   �� 5�      -   5        $��label19��5�   �   #��[ 6V   $
��Left=�6�   $��4,31,0,0q�6�   $	��Top=�6�   
����  ���6     $! Client.Properties.Resources��$ PL��6�   �� 5�      -   5        $��label20��5�   w   $��28��6<   $
��Left=�6H   $��
110,31,0,0q�6c   $	��Top=�6�   
����  ���6   �� *QuotaFixedPLStr+6�   �� 5�      -   5        $��label25��5�   �   
����  �#��[ 6h   $
��Left=�6�   $��5,31,0,0q�6�   $	��Top=�6�   $��2��6�   ��6     $! Client.Properties.Resources��$ PL��6�   �� 5�      -   5        $��label26��5�   �   
����  �$��28��6G   $
��Left=�6S   $��
110,31,0,0q�6n   $	��Top=�6�   $��2��6�   ��6   �� *
LMEPLStr+6�   �� 5�      -   5        $��label28��5�   �   
����  �#��[ 6h   $��5,31,0,0q�6�   $	��Top=�6�   $��4��6�   $
��Left=�6�   ��6     $! Client.Properties.Resources��$ PL��6�   �� 5�      -   5        $��label29��5�   �   
����  �$��28��6H   $
��Left=�6T   $��
110,31,0,0q�6o   $	��Top=�6�   $��4��6�   ��6   �� *	SHFEPLStr+6�   5�      � 5�      -    5        $��	rightGrid��5�      $��0��6$   $
��Left=�62   $��	10,74,0,0q�6M   $	��Top=�6`   $	��469��6x   $��1��6�   
�������$��2��6�    5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�      9� -!   5        $��	expander1��5�   �   $
��Auto��6a   $
��Left=�6o   $��6,6,0,0q�6�   $	��Top=�6�   $	��550��6�   $
��Auto��6�   ��6     $! Client.Properties.Resources��$ SelectQuota��.��5�      �� $��Stretch=�6   $��Stretch=�69   $��1q�6W   $��2q�6b   
�������._�5�      � $
��Auto��6   $	��550��6-   $
��Auto��6<   .+�5�      �� #��[  6b   $��1,7,0,0q�6�   $	��Top=�6�   $
��Left=�6�   ��6$     $! Client.Properties.Resources��$ BP��6�   �� 5�      -"   5        $��textBox2��5�   T   $
��Left=�6&   $��	117,9,0,0q�6A   $	��Top=�6d    �� 
IsReadOnly . ��5�   &   �� *QuotaBPName+�� 5�      -#   5        $��button1��5�   m   $	��...��6%   $��23��63   $
��Left=�6?   $��	241,9,0,0q�6Z   $	��Top=�6|   $��25��6�   6�   �� 5�      -$   5        $��label7��5�   �   #��[  6p   $
��Left=�6�   $��	280,7,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ InternalCustomer��6�   �� 5�      -%   5        $��	comboBox1��5�   V   $
��Left=�6'   $��
396,9,10,0q�6B   $	��Top=�6g     �� SelectedValuePath$  Id��5�   Q   ! �� DisplayMemberPath$! 	ShortName��6h   ��6'   �� *InternalCustomers+" �� SelectedValue" 6�   �� *QuotaInternalCustomerId+�� 5�      -&   5        $��label8��5�   �   #��[  6i   $
��Left=�6�   $��1,39,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ 	StartDate��6�     5�      -'   5        $��datePicker2��5�   X   $
��Left=�6)   $��
117,41,0,0q�6D   $	��Top=�6k    6�   �� *QuotaStartDate+�� 5�      -(   5        $��label9��5�   �   #��[  6g   $
��Left=�6�   $��
280,39,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ EndDate��6�     5�      -)   5        $��datePicker3��5�   X   $
��Left=�6)   $��
396,41,0,0q�6D   $	��Top=�6k    5�   )   �� *QuotaEndDate+�� 5�      -*   5        $��label10��5�   �   #��[  6i   $
��Left=�6�   $��1,71,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ 	Commodity��6�   �� 5�      -+   5        $��	comboBox2��5�   V   $
��Left=�6'   $��
117,73,0,0q�6B   $	��Top=�6g   $  Id��5�   K   $
! Name��6b   ��6'   �� *Commodities+" 6{   �� *QuotaCommodityId+�� 5�      -,   5        $��label35��5�   �   #��[  6c   $
��Left=�6�   $��
280,71,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$	 UDF��6�   �� 5�      --   5        $��	comboBox8��5�   V   $
��Left=�6'   $��
396,73,0,0q�6B   $	��Top=�6g   $
! Name��5�   H   $  Id��6a   ��6'   �� *
UDFTypes+" 6x   �� *SelectedUDFTypeId+�� 5�      -.   5        $��button2��5�   �   $��23��6f   $
��Left=�6r   $��241,108,0,0q�6�   $	��Top=�6�   $��60��6�   ��6%     $! Client.Properties.Resources��$ Query��6�   �� 5�      -/   5        $��button3��5�   �   $��23��6f   $
��Left=�6r   $��336,108,0,0q�6�   $	��Top=�6�   $��60��6�   ��6%     $! Client.Properties.Resources��$ Reset��6�   $  Utility.Controls.PagingControl  5�      -0   5        $��pagingControl1��5�   ]   $
��Left=�6/   $��	7,143,0,0q�6J   $	��Top=�6s     5�      -1   5        $��	dataGrid4��5�   �    .   . $
��Auto��6U   $
��Left=�6�   $��	7,180,6,6q�6�   $	��Top=�6�   $
��Auto��6�   ��6c   �� *Quotas+ 5�   "     5�   &   #   ElementStyle## [ 6{   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ QuotaNo�� 6�   �� *	QuotaNo+6�     5�   &   ## [ 6x   $
 Auto 6�    .  69     $! Client.Properties.Resources��$
 Type�� 6�   �� *Contract.ContractType+#	 [ 6    5�   &   ## [ 6v   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ BP�� 6�   �� *$"Contract.BusinessPartner.ShortName+6    5�   &   ## [ 6}   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *Commodity.Name+6�     5�   &   ## [ 6|   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ Quantity�� 6�   �� *ActualQuantity+# Z 6/    5�   &   ## [ 6}   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 	PricedQty�� 6�   �� *PricedQuantity+# Z 60    5   &   ## [ 6�   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ AveragePrice�� 6�   �� *AveragePrice+# Z 6.    5  &   ## [ 6w   $
 Auto 6�    .  69     $! Client.Properties.Resources��$	 UDF�� 6�   �� *Contract.ContractUDF.Name+6�     5  &   $
 Auto 6�    .   6=     $! Client.Properties.Resources��$ 	Operation�� 5  *   �� 5  .   $ DBEntity:Quota��6;   .R�5  2   �� #��[ 6�   ��69     $! Client.Properties.Resources��$ Select����6{   �� *Id+{�6�   �� *AvailableQuantityForHedge+#	 [ 6$  5  /   5  '   5
     5     5     5     9� 5     -2   5        $��	expander2��5  �   $��1��6   $
��Auto��6J   $
��Left=�6X   $��6,6,0,0q�6s   $	��Top=�6�   $	��550��6�   $
��auto��6�   ��6(     *SelectLMEPosition+.��5     �� $��Stretch=�6   $��Stretch=�69   $��1q�6W   $��2q�6b   
�������._�5     � $
��Auto��6   $
��Auto��6-   $	��550��6:   .+�5     �� $��1,7,0,0q�6i   #��[  6z   $	��Top=�6�   $
��Left=�6�   ��6$     $! Client.Properties.Resources��$ 	Commodity��6�   �� 5     -3   5        $��	comboBox3��5  U   $
��Left=�6'   $��	117,9,0,0q�6B   $	��Top=�6f   $  Id��5  K   $
! Name��6b   ��6'   �� *Commodities+" 6{   �� *LMEPositionCommodityId+�� 5     -4   5        $��label17��5  �   #��[  6p   $
��Left=�6�   $��	280,7,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ InternalCustomer��6�   �� 5     -5   5        $��
comboBox11��5  U   $
��Left=�6'   $��	396,9,0,0q�6B   $	��Top=�6g   $  Id��5  Q   $! 	ShortName��6h   ��6'   �� *InternalCustomers+" 6�   �� *LMEPositionInternalCustomerId+�� 5     -6   5        $��label11��5  �   #��[  6o   $
��Left=�6�   $��1,39,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ PromptStartDate��6�     5     -7   5        $��datePicker4��5  X   $
��Left=�6)   $��
117,41,0,0q�6D   $	��Top=�6k    6�   �� *LMEPositionStartDate+�� 5     -8   5        $��label12��5  �   #��[  6m   $
��Left=�6�   $��
280,39,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ PromptEndDate��6�     5     -9   5        $��datePicker5��5  X   $
��Left=�6)   $��
396,41,0,0q�6D   $	��Top=�6k    6�   �� *LMEPositionEndDate+�� 5     -:   5        $��label13��5  �   #��[  6i   $
��Left=�6�   $��1,71,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ 	Direction��6�   �� 5     -;   5        $��	comboBox4��5  V   $
��Left=�6'   $��
117,73,0,0q�6B   $	��Top=�6g   $
! Name��5  J   $  Id��6c   ��6'   �� *
Directions+" 6z   �� *LMEPositionDirectionId+�� 5     -<   5        $��label14��5  �   #��[  6f   $
��Left=�6�   $��
280,71,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ Broker��6�   �� 5      -=   5        $��	comboBox5��5   V   $
��Left=�6'   $��
396,73,0,0q�6B   $	��Top=�6g   $  Id��5!  G   $! 	ShortName��6^   ��6'   �� *	Brokers+" 6|   �� *LMEPositionBrokerId+�� 5"     ->   5        $��label16��5"  �   #��[  6l   $
��Left=�6�   $��	1,103,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ PositionType��6�   �� 5#     -?   5        $��	comboBox6��5#  W   $
��Left=�6'   $��117,105,0,0q�6B   $	��Top=�6h   $  Id��5$  M   $
! Name��6d   ��6'   �� *PositionTypes+" 6}   �� *LMEPositionTypeId+�� 5%     -@   5        $��button6��5%  �   $��23��6f   $
��Left=�6r   $��361,105,0,0q�6�   $	��Top=�6�   $��60��6�   ��6%     $! Client.Properties.Resources��$ Query��6�   �� 5&     -A   5        $��button7��5&  �   $��23��6f   $
��Left=�6r   $��456,105,0,0q�6�   $	��Top=�6�   $��60��6�   ��6%     $! Client.Properties.Resources��$ Reset��6�     5'     -B   5        $��pagingControl2��5'  ]   $
��Left=�6/   $��	7,143,0,0q�6J   $	��Top=�6s     5(     -C   5        $��	dataGrid5��5(  �    .   . $
��Auto��6U   $
��Left=�6c   $��	7,180,6,6q�6�   $	��Top=�6�   $
��Auto��6�   ��6~   �� *LMEPositions+ 5)  "     5*  &   ## [ 6}   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 	TradeDate�� 6�   �� *	TradeDate+$ {0:yyyy-MM-dd}��6    5+  &   ## [ 6~   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 
PromptDate�� 6�   �� *
PromptDate+$ {0:yyyy-MM-dd}��6    5,  &   ## [ 6}   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *Commodity.Name+6�     5-  &   ## [ 6w   $
 Auto 6�    .  69     $! Client.Properties.Resources��$	 Lot�� 6�   �� *	LotAmount+# Z 6'    5.  &   ## [ 6�   $
 Auto 6�    .  69     $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ AvailableLot�� 6�   �� *AvailableLotForHedge+# Z 6M    5/  &   ## [ 6y   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ Price�� 6�   �� *
AgentPrice+# Z 6(    50  &   ## [ 6}   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 	Direction�� 6�   �� *TradeDirection+#	 [ 6    51  &   ## [ 6�   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ PositionType�� 6�   �� *PositionType+#	 [ 6     52  &   ## [ 6~   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 
Commission�� 6�   �� *AgentCommission+# Z 63    53  &   ## [ 6z   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ Broker�� 6�   �� *Agent.ShortName+6�     54  &   $
 Auto 6�    .   6=     $! Client.Properties.Resources��$ 	Operation�� 55  *   �� 56  .   $ DBEntity:LMEPosition��6;   .R�57  2   �� #��[ 6�   ��69     $! Client.Properties.Resources��$ Select����6{   �� *Id+{�6�   �� *AvailableLotForHedge+#	 [ 6%  58  /   5:  '   5<     5=     5>     5?     9� 5@     -D   5        $��	expander3��5@  �   $��2��6   $
��Auto��6K   $
��Left=�6Y   $��6,6,0,0q�6t   $	��Top=�6�   $	��550��6�   $
��Auto��6�   ��6(     *SelectSHFEPosition+.��5A     �� $��Stretch=�6   $��Stretch=�69   $��1q�6W   $��2q�6b   
�������._�5B     � $	��550��6   $
��Auto��6.   $
��Auto��6<   .+�5C     �� -E   5        $��label21��5C  �   $��1,7,0,0q�6i   #��[  6z   $	��Top=�6�   $
��Left=�6�   ��6$     $! Client.Properties.Resources��$ 	Commodity��6�   �� 5D     -F   5        $��
comboBox23��5D  U   $
��Left=�6'   $��	117,9,0,0q�6B   $	��Top=�6g   $  Id��5E  K   $
! Name��6b   ��6'   �� *Commodities+" 6{   �� *SHFEPositionCommodityId+�� 5F     -G   5        $��label27��5F  �   #��[  6p   $
��Left=�6�   $��	280,7,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ InternalCustomer��6�   �� 5G     -H   5        $��
comboBox21��5G  U   $
��Left=�6'   $��	396,9,0,0q�6B   $	��Top=�6g   $  Id��5H  Q   $! 	ShortName��6h   ��6'   �� *InternalCustomers+" 6�   �� * SHFEPositionInternalCustomerId+�� 5I     -I   5        $��label221��5I  �   #��[  6n   $
��Left=�6�   $��1,39,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ TradeStartDate��6�     5J     -J   5        $��datePicker24��5J  X   $
��Left=�6)   $��
117,41,0,0q�6D   $	��Top=�6l    5K  )   �� *SHFEPositionStartDate+�� 5L     -K   5        $��label22��5L  �   #��[  6l   $
��Left=�6�   $��
280,39,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ TradeEndDate��6�     5M     -L   5        $��datePicker25��5M  X   $
��Left=�6)   $��
396,41,0,0q�6D   $	��Top=�6l    6�   �� *SHFEPositionEndDate+�� 5N     -M   5        $��label23��5N  �   #��[  6i   $
��Left=�6�   $��1,71,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ 	Direction��6�   �� 5O     -N   5        $��
comboBox24��5O  V   $
��Left=�6'   $��
117,73,0,0q�6B   $	��Top=�6h   $  Id��5P  J   $
! Name��6a   ��6'   �� *
Directions+" 6z   �� *SHFEPositionDirectionId+�� 5Q     -O   5        $��label24��5Q  �   #��[  6f   $
��Left=�6�   $��
280,71,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ Broker��6�   �� 5R     -P   5        $��
comboBox25��5R  V   $
��Left=�6'   $��
396,73,0,0q�6B   $	��Top=�6h   $  Id��5S  G   $! 	ShortName��6^   ��6'   �� *	Brokers+" 6|   �� *SHFEPositionBrokerId+�� 5T     -Q   5        $��label18��5T  �   #��[  6l   $
��Left=�6�   $��	1,103,0,0q�6�   $	��Top=�6�   ��6$     $! Client.Properties.Resources��$ PositionType��6�   �� 5U     -R   5        $��	comboBox7��5U  W   $
��Left=�6'   $��117,105,0,0q�6B   $	��Top=�6h   $  Id��5V  M   $
! Name��6d   ��6'   �� *PositionTypes+" 6}   �� *SHFEPositionTypeId+�� 5W     -S   5        $��button26��5W  �   $��23��6f   $
��Left=�6r   $��361,105,0,0q�6�   $	��Top=�6�   $��60��6�   ��6%     $! Client.Properties.Resources��$ Query��6�   �� 5X     -T   5        $��button27��5X  �   $��23��6f   $
��Left=�6r   $��456,105,0,0q�6�   $	��Top=�6�   $��60��6�   ��6%     $! Client.Properties.Resources��$ Reset��6�     5Y     -U   5        $��pagingControl22��5Y  ]   $
��Left=�6/   $��	7,143,0,0q�6J   $	��Top=�6t     5Z     -V   5        $��
dataGrid25��5Z  �    .   . $
��Auto��6U   $
��Left=�6�   $��	7,180,6,6q�6�   $	��Top=�6�   $
��Auto��6�   ��6c   �� *SHFEPositions+ 5[  "     5\  &   ## [ 6�   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ SHFEContract�� 6�   �� *Alias+6�     5]  &   ## [ 6}   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 	TradeDate�� 6�   �� *SHFECapitalDetail.TradeDate+$ {0:yyyy-MM-dd}��6#    5^  &   ## [ 6~   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 
PromptDate�� 6�   �� *
PromptDate+$ {0:yyyy-MM-dd}��6    5_  &   ## [ 6w   $
 Auto 6�    .  69     $! Client.Properties.Resources��$	 Lot�� 6�   �� *LotQuantity+# Z 6)    5`  &   ## [ 6�   $
 Auto 6�    .  69     $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ AvailableLot�� 6�   �� *AvailableLotForHedge+# Z 6M    5a  &   ## [ 6y   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ Price�� 6�   �� *Price+# Z 6#    5b  &   ## [ 6}   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 	Direction�� 6�   �� *PositionDirection+#	 [ 6"    5c  &   $
 Auto 6}    .  69     $! Client.Properties.Resources��$ 	OpenClose�� 6�   �� *	OpenClose+#	 [ 6�     5d  &   ## [ 6�   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ PositionType�� 6�   �� *PositionType+#	 [ 6     5e  &   ## [ 6~   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ 
Commission�� 6�   �� *
Commission+# Z 6.    5f  &   ## [ 6z   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ Broker�� 6�   �� *-+SHFECapitalDetail.BusinessPartner.ShortName+6    5g  &   $
 Auto 6�    .   6=     $! Client.Properties.Resources��$ 	Operation�� 5h  *   �� 5i  .   $ DBEntity:LMEPosition��6;   .R�5j  2   �� #��[ 6�   ��69     $! Client.Properties.Resources��$ Select����6{   �� *Id+{�6�   �� *AvailableLotForHedge+#	 [ 6&  5k  /   5m  '   5o     5p     5q     5r     5s     �� 5t     -W   5        $��button8��5t  m   $��23��63   $
��Left=�6?   $��	122,0,0,7q�6Z   $��75��6|   $��1��6�   ��6     *SettlementPL+6�   �� 5u     -X   5        $��label30��5u  �   $��28��6W   $��Right=�6c   $��60��6�   $
��Left=�6�   $��	209,0,0,0q�6�   $	��Top=�6�   
����  �$��1��6�   $��2��6  ��6     $! Client.Properties.Resources��$ TotalPL��6  �� 5v     -Y   5        $��label31��5v  m   $��28��63   $
��Left=�6?   $��	271,0,0,0q�6Z   $	��Top=�6|   
����  �$��1��6�   $��2��6�   ��6   �� *
TotalPLStr+6�   �� 5w     -Z   5        $��label36��5w  j   $��保值类型��6   $��2��6#   $��28��60   $
��Left=�6<   $��	58,32,0,0q�6W   $	��Top=�6y   �� 5x     -[   5        $��	comboBox9��5x  _   $��2��6   $��23��6$   $
��Left=�60   $��
122,34,0,0q�6K   $	��Top=�6p   $	��120��6�   $  Id��6�   $
! Name��6�   ��6�   �� *ArbitrageTypes+" 6�   �� *SelectedArbitrageTypeId+5y     5z     5{     