   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity      Client.View.Reports.Ledger   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *Ledger+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%V  &	        '�� �     '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *Ledger+�� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��900����     ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��� .+��� -   $��label12��#��[  $
��Left=�$��1,10,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$	 	Commodity���� -   $��comboBoxMetal��
 �� DisplayMemberPath$

 Name��$
��Left=�$��
107,12,0,0q� �� SelectedValuePath$ Id��$	��Top=����� *Metals+ �� SelectedValue �� *SelectedMetalId+�� -   $��label2��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$	 SignSide���� -   $��	comboBox1��$
 	ShortName��$
��Left=�$��
366,12,0,0q�$ Id��$	��Top=����� *InternalCustomers+ �� *SelectedInternalCustomersId+�� -   $��label10��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 	StartDate���� -	   $��label11��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$	 EndDate��  -
   $��datePicker1��$
��Left=�$��
107,44,0,0q�$	��Top=�   SelectedDate �� *	StartDate+  -   $��datePicker2��$
��Left=�$��
366,44,0,0q�$	��Top=� �� *	EndDate+�� -   $��label3��#��[  $
��Left=�$��
519,10,0,0q�$	��Top=���  *CustomerName+�� -   $��textBox1��$��23��$
��Left=�$��
625,12,0,0q�$	��Top=�{�.  ���� *CustomerName+�� -   $��btnCustomer��$	��...��$��23��$
��Left=�$��
749,12,0,0q�$	��Top=�$��25���� -   $��button1��$��23��$
��Left=�$��
791,44,0,0q�$	��Top=�$��75�� �� 	IsDefault . ��  $! Client.Properties.Resources��$	 Query���� -   $��label6��$��采购客户��$
��Left=�$��
519,42,0,0q�#��[  $	��Top=��� -   $��textBox2��$��23��$
��Left=�$��
625,44,0,0q�$	��Top=�{�.  ���� *PurchaseCustomerName+�� -   $��buttonPurchaseCustomer��$	��...��$��23��$
��Left=�$��
749,44,0,0q�$	��Top=�$��25���� -   $��button2��$��导出Excel��$��23��$
��Left=�$��
791,13,0,0q�$	��Top=�$��75���� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=��� -   $��stackPanel1��$
��auto��$
��Left=�$��	6,166,0,0q�$	��Top=�$
��auto��.+��� -   $��lvGrid��$
��Auto������  �� View �� P���  �� Width$
 Auto����  $# Client.View.Reports.ResReport��$	 PurchaseQuotaNo�� �� DisplayMemberBinding ��  �� Path$ PQuotaNo��� $
 Auto����  $# Client.View.Reports.ResReport��$	 PurchaseDate�� �� *
PQuotaDate+ �� StringFormat$ 
yyyy-MM-dd���� $
 Auto����  $! Client.Properties.Resources��$	 Supplier�� �� *PQuotaSupplier+�� $
 Auto����  $! Client.Properties.Resources��$	 	Commodity�� �� *	MetalName+�� $
 Auto����  $! Client.Properties.Resources��$	 Brand�� �� *
PBrandName+�� $
 Auto����  $! Client.Properties.Resources��$	 QuotaQuantity�� �� *PQty+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z �� $
 Auto����  $! Client.Properties.Resources��$	 ActualQuantity�� �� *PVerifiedQty+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 SalesQty�� �� *	PSalesQty+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 Price�� �� *PPrice+   	STR_PRICE# Z �� $
 Auto����  $! Client.Properties.Resources��$	 Currency�� �� *	PCurrency+�� $
 Auto����  $! Client.Properties.Resources��$	 Payable�� �� *PPay+   
STR_AMOUNT# Z �� $
 Auto����  $! Client.Properties.Resources��$	 
PaidAmount�� �� *PPaid+# Z �� $
 Auto����  $# Client.View.Reports.ResReport��$	 Received�� �� *	PReceived+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 
Settlement�� �� *	PSettle+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 SettleCurrency�� �� *PSettleCurrency+�� $ 15�� �� CellTemplate �� .R��� 
�����F�$��15���� $
 Auto����  $# Client.View.Reports.ResReport��$	 SalesQuotaNo�� �� *
SQuotaNo+�� $
 Auto����  $# Client.View.Reports.ResReport��$	 	SalesDate�� �� *
SQuotaDate+$ 
yyyy-MM-dd���� $
 Auto����  $! Client.Properties.Resources��$	 Buyer�� �� *SQuotaBuyer+�� $
 Auto����  $! Client.Properties.Resources��$	 Brand�� �� *
SBrandName+�� $
 Auto����  $! Client.Properties.Resources��$	 QuotaQuantity�� �� *SQty+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 ActualQuantity�� �� *SVerifiedQty+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 Price�� �� *SPrice+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 Currency�� �� *	SCurrency+�� $
 Auto����  $! Client.Properties.Resources��$	 
Receivable�� �� *
SReceive+# Z �� $
 Auto����  $# Client.View.Reports.ResReport��$	 Received�� �� *	SReceived+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 
PaidAmount�� �� *SPaid+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 
Settlement�� �� *	SSettle+# Z �� $
 Auto����  $! Client.Properties.Resources��$	 SettleCurrency�� �� *SSettleCurrency+�� $
 Auto����  $# Client.View.Reports.ResReport��$	 PhysicalGrossProfit�� �� *Profit+# Z �� -   $��label5��$��25��$
��auto��$��0 10 0 0q���  *Calculation1+�� -   $��label4��$��25��$
��auto����  *Calculation2+