   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	           Client.View.Reports.Ledger   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   @     *Ledger+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%�  &	        '�� �     '�� m    '  �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5!   
   "  6   .�5"      ��  � ��$ 23��6'   64   �� 5#       � ��$	 120��6&   64   5$      5&      .��5(      �� $
��Auto=�6   $
��Auto=�68   .��5)   
   � -   5         �Name$ rootGrid��5)      .+�5*      �� -   5        $��lbTitle��5*   ,   $
��Left=�6;   $��6,6,0,0q�6V   $��32��6g   $	��Top=�5+      $
��Bold"�6,   $��16(�6>   ��5*        *Ledger+5+   >   �� 5,      -   5        $��	groupBox1��5-   D   $	��100��5,   \   $
��Left=�5-      $��6,40,0,0q�62   $	��Top=�5.      $	��900��6/   ��5,           ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��5/      � .+�50      �� -   5        $��label12��52   .   #��[  51      $
��Left=�6@   $��1,10,0,0q�52      $	��Top=�6=   
���<����50        $! Client.Properties.Resources��$	 	Commodity��52   U   �� 53      -   5        $��comboBoxMetal��54   3   
 �� DisplayMemberPath$

 Name��53      $
��Left=�68   $��
107,12,0,0q�54       �� SelectedValuePath$ Id��55      $	��Top=�56      ��53   S   �� *Metals+ �� SelectedValue 54   H   �� *SelectedMetalId+56      �� 57      -   5        $��label2��59   0   #��[  58      $
��Left=�6@   $��
260,10,0,0q�59      $	��Top=�6>   
���<����57        $! Client.Properties.Resources��$	 SignSide��59   V   �� 5:      -   5        $��	comboBox1��5;   ]   $
 	ShortName��5:      $
��Left=�6=   $��
366,12,0,0q�5;   I   $ Id��5<   U   $	��Top=�5=      ��5;      �� *InternalCustomers+ 5<      �� *SelectedInternalCustomersId+5=      �� 5>      -   5        $��label10��5@   .   #��[  5?      $
��Left=�6@   $��1,42,0,0q�5@      $	��Top=�6=   ��5>        $! Client.Properties.Resources��$	 	StartDate��5@   =   �� 5A      -	   5        $��label11��5C   K   #��[  5B      $
��Left=�5C      $��
260,42,0,0q�67   $	��Top=�6Z   ��5A        $! Client.Properties.Resources��$	 EndDate��5C   Z     5D      -
   5        $��datePicker1��5D   P   $
��Left=�6!   $��
107,44,0,0q�6<   $	��Top=�5E   D      SelectedDate 6!   �� *	StartDate+6D     5F      -   5        $��datePicker2��5F   P   $
��Left=�6!   $��
366,44,0,0q�6<   $	��Top=�5G   B    6!   �� *	EndDate+6B   �� 5H      -   5        $��label3��5I   0   #��[  5H   :   $
��Left=�6^   $��
519,10,0,0q�5I      $	��Top=�6>   ��5H        *CustomerName+5I   >   �� 5J      -   5        $��textBox1��5J   Y   $��23��6   $
��Left=�6*   $��
625,12,0,0q�6E   $	��Top=�5K   <   {�.  ��6   �� *CustomerName+6T   �� 5L      -   5        $��btnCustomer��5L   f   $	��...��6   $��23��6+   $
��Left=�67   $��
749,12,0,0q�6R   $	��Top=�5M      $��25��65   6@   �� 5N      -   5        $��button1��5O   L   $��23��5N   ^   $
��Left=�5O      $��
791,44,0,0q�68   $	��Top=�5P      $��75��65    �� 	IsDefault . ��5N        $! Client.Properties.Resources��$	 Query��5P   U   �� 5Q      -   5        $��label6��5Q   Z   $��采购客户��6   $
��Left=�6+   $��
519,42,0,0q�6F   #��[  5R      $	��Top=�6@   �� 5S      -   5        $��textBox2��5S   Y   $��23��6   $
��Left=�6*   $��
625,44,0,0q�6E   $	��Top=�5T   D   {�.  ��6   �� *PurchaseCustomerName+6\   �� 5U      -   5        $��buttonPurchaseCustomer��5V      $	��...��5U      $��23��6+   $
��Left=�67   $��
749,44,0,0q�6R   $	��Top=�5V   ;   $��25��6S   5W      �� 5X      -   5        $��button2��5X   j   $��导出Excel��6   $��23��6/   $
��Left=�6;   $��
791,13,0,0q�6V   $	��Top=�6y   $��75��6�   6�   5Y      5Z      �� 5[      -   5        $��
separator1��5[   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   �� 5\      -   5        $��stackPanel1��5\   U   $
��auto��6   $
��Left=�6'   $��	6,166,0,0q�6B   $	��Top=�5]      $
��auto��61   .+�5�      �� -   5        $��lvGrid��5�      $
��Auto��6)   ��67   ��  �� View 5�      �� 5�      P�5�      �� 5�   "    �� Width$
 Auto��5�   %   ��5�   %     $# Client.View.Reports.ResReport��$	 PurchaseQuotaNo�� �� DisplayMemberBinding 5�   2   ��  �� Path$ PQuotaNo��� 5�   "   $
 Auto��5�   %   ��5�   %     $# Client.View.Reports.ResReport��$	 PurchaseDate�� 5�   2   �� *
PQuotaDate+ �� StringFormat$ 
yyyy-MM-dd���� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Supplier�� 5�   >   �� *PQuotaSupplier+�� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 	Commodity�� 5�   >   �� *	MetalName+�� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Brand�� 5�   >   �� *
PBrandName+�� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 QuotaQuantity�� 5�   1   �� *PQty+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z �� 5�   "   $
 Auto��5�   %   ��5�   %     $! Client.Properties.Resources��$	 ActualQuantity�� 5�   %   �� *PVerifiedQty+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 SalesQty�� 5�   1   �� *	PSalesQty+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Price�� 5�   1   �� *PPrice+   	STR_PRICE# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Currency�� 5�   >   �� *	PCurrency+�� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Payable�� 5�   1   �� *PPay+   
STR_AMOUNT# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 
PaidAmount�� 5�   1   �� *PPaid+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $# Client.View.Reports.ResReport��$	 Received�� 5�   1   �� *	PReceived+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 
Settlement�� 5�   1   �� *	PSettle+# Z �� 5�   "   $
 Auto��5�   %   ��5�   %     $! Client.Properties.Resources��$	 SettleCurrency�� 5�   2   �� *PSettleCurrency+�� 5�   "   $ 15��61    �� CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� 
�����F�$��15��6O   6_   5�   +   5�   #   �� 5�   "   $
 Auto��5�   %   ��5�   %     $# Client.View.Reports.ResReport��$	 SalesQuotaNo�� 5�   2   �� *
SQuotaNo+�� 5�   "   $
 Auto��5�   1   ��5�   1     $# Client.View.Reports.ResReport��$	 	SalesDate�� 5�   1   �� *
SQuotaDate+$ 
yyyy-MM-dd���� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Buyer�� 5�   >   �� *SQuotaBuyer+�� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Brand�� 5�   >   �� *
SBrandName+�� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 QuotaQuantity�� 5�   1   �� *SQty+# Z �� 5�   "   $
 Auto��5�   %   ��5�   %     $! Client.Properties.Resources��$	 ActualQuantity�� 5�   %   �� *SVerifiedQty+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Price�� 5�   1   �� *SPrice+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 Currency�� 5�   >   �� *	SCurrency+�� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 
Receivable�� 5�   1   �� *
SReceive+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $# Client.View.Reports.ResReport��$	 Received�� 5�   1   �� *	SReceived+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 
PaidAmount�� 5�   1   �� *SPaid+# Z �� 5�   "   $
 Auto��5�   1   ��5�   1     $! Client.Properties.Resources��$	 
Settlement�� 5�   1   �� *	SSettle+# Z �� 5�   "   $
 Auto��5�   %   ��5�   %     $! Client.Properties.Resources��$	 SettleCurrency�� 5�   2   �� *SSettleCurrency+�� 5�   "   $
 Auto��5�   %   ��5�   %     $# Client.View.Reports.ResReport��$	 PhysicalGrossProfit�� 5�   %   �� *Profit+# Z 5�      5�      �� 5�      -   5        $��label5��5�      $��25��5�   6   $
��auto��5�   &   $��0 10 0 0q�63   ��5�        *Calculation1+5�   3   �� 5�      -   5        $��label4��5�   B   $��25��66   $
��auto��6P   ��6     *Calculation2+6P   5�      5�      5�      5�      