   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      6    0Client.View.Reports.BusinessPartnerContractOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       N� Title$" BusinessPartnerContractOrder��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%  &	        '�� �     '  m    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5       .��5"      �� $
��Auto=�6   $
��Auto=�68   .��5#   
   � -   5         �Name$ rootGrid��5#      .+�5$      �� -   5        $��	groupBox1��5$   �   $	��100��6\   $
��Left=�6i   $��6,40,0,0q�6�   $	��Top=�6�   $	��800��6�   ��6        ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��5%      � .+�5&      �� -   5        $��label2��5&   �   $��内部客户��6   
���<��#��[  6@   $
��Left=�6d   $��1,10,0,0q�6   $	��Top=�6�   �� 5'      -   5        $��label3��5'   �   #��[  6   $��金属��6@   
���<��$
��Left=�6b   $��
260,10,0,0q�6}   $	��Top=�6�   �� 5(      -   5        $��label4��5(   �   #��[  6   $��起始日期��6@   
���<��$
��Left=�6d   $��1,42,0,0q�6   $	��Top=�6�     5)      -   5        $��datePicker1��5)   s   $
��Left=�6!   $��
107,44,0,0q�6_   $	��Top=�6�   
   SelectedDate
 6<   �� *	StartDate+6�     5*      -   5        $��datePicker2��5*   q   $
��Left=�6!   $��
366,44,0,0q�6]   $	��Top=�6�   
 6<   �� *	EndDate+6�   �� 5+      -   5        $��label5��5+   �   #��[  6   $��截止日期��6@   
���<��$
��Left=�6d   $��
260,42,0,0q�6   $	��Top=�6�   �� 5,      -	   5        $��label6��5,   �   #��[  6   $��业务类型��6@   
���<��$
��Left=�6d   $��
519,10,0,0q�6   $	��Top=�6�   �� 5-      -
   5        $��	comboBox1��5.   U   $
��Left=�5-       �� DisplayMemberPath$
 Name��6`    �� SelectedValuePath$ Id��6y   $��
366,12,0,0q�5.   A   $	��Top=�6f   ��5-   :   �� *CommodityList+ �� SelectedValue 5.      �� *CommodityId+6f   �� 5/      -   5        $��	comboBox2��50   a   $
��Left=�5/      $ Value��6_   $	 Key��50   #   $ 1��6;   $��
625,12,0,0q�6M   $	��Top=�6r   ��5/   :   �� *ContractType+50   r   �� 51      -   5        $��button1��51   e   $��查询��6   $��23��6*   $
��Left=�66   $��
625,44,0,0q�6Q   $	��Top=�6t   $��75��6�   6�   �� 52      -   5        $��	comboBox3��52   �   $
��Left=�6   $ 	ShortName��6:   $ Id��6�   $��
107,12,0,0q�6�   $	��Top=�6�   ��6X   �� *InternalCustomerList+ 6�   �� *SelectedInternalCustomerId+6�   53      54      �� 56      -   5        $��
separator1��56   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   &   System.Windows.Controls.DataGrid  58      -   5        $��	dataGrid1��58   �      AutoGenerateColumns .  $
��Left=�63   $
��auto��6N   $��	6,166,0,0q�6t   $	��Top=�6�   $
��auto��6�     DataGridStyle#��[ 6�     DataGridRowStyle   RowStyle# [ 6�      
IsReadOnly . ��6\   ��    Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ 客户名称��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *BusinessParnterName+6a     5;      $ 数量��6)    65   �� *Qty+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�     5<      $ 金额��6)    65   �� *Amount+   
STR_AMOUNT# Z 6�     5=      $ 均价��6)    65   �� *
AvgPrice+   	STR_PRICE# Z 6�   5?      �� 5@      -   5        $��lbTitle��5@   ~   $��客户购销排行表��6   $
��Bold"�6&   $��16(�68   $��32��6F   $
��Left=�6R   $��6,6,0,0q�6m   $	��Top=�6�   5A      5B      5C      