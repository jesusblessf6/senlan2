   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Client.View.ReportsClient.View.Reports  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity $    Client.View.Reports.APARReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5Reports!clr-namespace:Client.View.Reports     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ReceivableAndPayable+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value 
 style1 �� 
TargetType 9�Name	 9� 
IsExpanded 
 style2 
 style33   -Client.View.Reports.ListViewItemStyleSelector  ListViewStyleSelector
   
FirstStyle   SecondStyle   
ThirdStyle��%�  &	        '�� �     '�� �     &	 �     &	 o    &	 �    &	 Q    7  7  7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � �� �� " ��.R�9� $	 exp��	 .  ��� .+��� $��5,10,0,0q����� *Name+.���� �� " ��.���  � �� �� " ��.R�9� 	 .  ��� .+��� $��20,0,0,0q����� *Name+.���� �� " ��.���  � �� �� " ��.R�9� 	 .  ��� .+��� $��40,0,0,0q����� *Name+.����   8
   8  8  .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *ReceivableAndPayable+�� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��800����     ResxName$! Client.Properties.Resources��
   Key$ 
Conditions��.��� .+��� -   $��label2��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Customer���� -   $��textBox1��$
��Left=�$��
107,44,0,0q�$	��Top=�{�.  ���� *BpName+�� -   $��button1��$	��...��$��23��$
��Left=�$��
231,44,0,0q�$	��Top=�$��25���� -   $��label3��#��[  $
��Left=�$��1,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox1��$
��Left=�$��
107,12,0,0q�$	��Top=� �� DisplayMemberPath$ 	ShortName�� �� SelectedValuePath$ Id������ *InnerCustomers+ �� SelectedValue �� *InnerCustomerId+�� -	   $��label4��#��[  $
��Left=�$��
500,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -
   $��	comboBox2��$
��Left=�$��
606,12,0,0q�$	��Top=�$
 Name��$ Id������ *Metals+ �� *	MetalId+�� -   $��button2��$��23��$
��Left=�$��
606,44,0,0q�$	��Top=�$��48�� �� 	IsDefault . ��  $! Client.Properties.Resources��$ Query���� -   $��label5��$
��Left=�$��
272,10,0,0q�#��[  $	��Top=���  $! Client.Properties.Resources��$ 	StartDate��(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$
��Left=�$��
378,12,0,0q�$	��Top=�$	��120��   SelectedDate �� *	StartDate+�� -   $��label6��$
��Left=�$��
272,42,0,0q�#��[  $	��Top=���  $! Client.Properties.Resources��$ EndDate��  -   $��datePicker2��$
��Left=�$��
378,44,0,0q�$	��Top=�$	��120�� �� *	EndDate+�� -   $��button3��$��导出Excel��$��23��$
��Left=�$��
666,44,0,0q�$	��Top=�$��60���� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��dataGridAPAR��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,166,0,0q�$	��Top=�$
��Auto��   CanUserAddRows .     
IsReadOnly . ���� *
APARView+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header   $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	QuotaNo+     $! Client.Properties.Resources��$ 	Commodity�� �� *CommodityName+     $! Client.Properties.Resources��$ Brand�� �� *	BrandName+     $! Client.Properties.Resources��$
 Date�� �� *Date+ �� StringFormat$ 
yyyy-MM-dd��     $! Client.Properties.Resources��$ ActualQuantity�� �� *VerQty+$	  DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY# Z      $! Client.Properties.Resources��$ Price�� �� *Price+ 	  	STR_PRICE# Z      $! Client.Properties.Resources��$ PricingCurrency�� �� *PricingCurrency+  $ 增票数量�� �� *VatInvoiceQty+# Z   $ 增票金额�� �� *VatInvoiceAmount+ 	  
STR_AMOUNT# Z      $! Client.Properties.Resources��$ 
Receivable�� �� *	BReceived+# Z      $! Client.Properties.Resources��$ Payable�� �� *BPaid+# Z      $# Client.View.Reports.ResReport��$ Received�� �� *	SReceived+# Z      $# Client.View.Reports.ResReport��$
 Paid�� �� *SPaid+# Z      $# Client.View.Reports.ResReport��$ AmountRemain�� �� *AmountRemain+# Z      $! Client.Properties.Resources��$ SettleCurrency�� �� *SettleCurrency+