   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 2   ,Client.View.Reports.QuotaInvoiceDetailReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     -cclr-namespace:Client.Converters     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *VATInvoiceDetail+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker*  $Client.Converters.VATStatusConverter  VATStatusConverter��%!  &	        '�� �     '  �     &	 �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��34��$
��Left=�$��6,6,0,0q�$	��Top=�$��16(�$
��auto��$
��Bold"���  *VATInvoiceDetail+�� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,191,0,0q�   
IsReadOnly . $	��Top=�$
��Auto������ *Quotas+	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   CanUserSort
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    Header      ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *	QuotaNo+  $ 预开/收票日期��
 . $
 Auto  �� *VATInvoiceDate+ �� StringFormat$ 
yyyy-MM-dd��  
 . $
 Auto    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  
 . $
 Auto    $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+  
 . $
 Auto    $! Client.Properties.Resources��$ Quantity�� �� *
Quantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY# Z   
 . $
 Auto    $! Client.Properties.Resources��$ ActualQuantity�� �� *VerifiedQuantity+# Z   
 . $
 Auto    $! Client.Properties.Resources��$ Price�� �� *
FinalPrice+ 
  	STR_PRICE# Z   
 . $
 Auto    $# Client.View.Reports.ResReport��$ InvoicedQty�� �� *VATInvoicedQuantity+# Z   
 .  $
 Auto    $! Client.Properties.Resources��$ InvoicedStatus�� �� *	VATStatus+ �� 	Converter# [  �� 
GroupStyle (  "System.Windows.Controls.GroupStyle    GroupHerderStyle   ContainerStyle# [    Panel �� .R�>  8System.Windows.Controls.Primitives.DataGridRowsPresenter  �� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��980����  $! Client.Properties.Resources��$ 
Conditions��.��� .+��� -   $��label3��#��[  $
��Left=�$��1,10,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox1��$��
107,12,0,0q� �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 	ShortName��$
��Left=�$	��Top=����� *InternalCustomers+ �� SelectedValue �� *InternalCustomerId+�� -   $��label5��#��[  $
��Left=�$��1,42,0,0q�
���<��$	��Top=���  *OpenCollect+�� -	   $��	comboBox3��$��
107,44,0,0q�$ Id��$
 Name��$
��Left=�$	��Top=����� *VATInvoiceTypes+ �� *VATInvoiceTypeId+�� -
   $��label2��#��[  $
��Left=�$��
227,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ BP���� -   $��textBox1��$��23��$
��Left=�$��
333,12,0,0q�$	��Top=�$	��120��{�.  ���� *BPName+�� -   $��button1��$	��...��$��23��$
��Left=�$��
457,12,0,0q�$	��Top=�$��25���� -   $��label4��#��[  $
��Left=�$��
481,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -   $��	comboBox2��$
��Left=�$��
587,12,0,0q�$	��Top=�$ Id��$
 Name������ *Commodities+ �� *CommodityId+�� -   $��label6��#��[  $
��Left=�$��
227,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	StartDate��  -   $��datePicker1��$��
333,44,0,0q�$
��Left=�$	��Top=�   SelectedDate �� *	StartDate+�� -   $��label7��$
��Left=�#��[  $��
481,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ EndDate��  -   $��datePicker2��$��
587,44,0,0q�$
��Left=�$	��Top=� �� *	EndDate+�� -   $��button3��$��23��$
��Left=�$��
872,44,0,0q�$	��Top=�$��60��$y�	Collapsed=���  $! Client.Properties.Resources��$ Reset���� -   $��label1��$
��Left=�$��
706,10,0,0q�#��[  $	��Top=�$	��100����  $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ OpenInvoiceStatus���� -   $��	comboBox4��$
��Left=�$��
812,12,0,0q�$ Value��$	 Key��$	��Top=����� *	VATStatus+ �� *SelectedVATStatus+�� -   $��button2��$��23��$
��Left=�$��
812,44,0,0q�$	��Top=�$��50����  $! Client.Properties.Resources��$ Query���� -   $��button4��$��导出Excel��$��23��$
��Left=�$��
872,44,0,0q�$	��Top=�$��60���� -   $��label8��$��实际数量：��
���  ��$��28��$
��Left=�$��
13,161,0,0q�$	��Top=��� -   $��label9��$��28��$
��Left=�$��
76,161,0,0q�$	��Top=����� *VerQtyCount+# Z �� -   $��label10��$��	金额：��
���  ��$��28��$��239,161,724,0q�$	��Top=��� -   $��label11��$��28��$
��Left=�$��280,161,0,0q�$	��Top=����� *Amount+ 
  
STR_AMOUNT# Z 