   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C    =Client.View.Physical.CommercialInvoices.CommercialInvoiceHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.Physical.CommercialInvoices.ResCommercialInvoice�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *CommercialInvoiceHome+.���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid��.+��� -    ��Name$ lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  *CommercialInvoiceHome+�� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label2��$��28��$
��Left=�$��6,27,0,0q�$	��Top=�$	��100��$��Right=���  $! Client.Properties.Resources��$ ProvisionalInvoice���� -   $��btnTemporary��$��+��$��23��$
��Left=�$��
120,28,0,0q�$	��Top=�$��75�� � ToolTip   *AddProvisionalInvoice+�� -   $��label3��$
��Left=�$��6,61,0,0q�$��28��$	��Top=�$	��100��$��Right=���  $! Client.Properties.Resources��$ FinalInvoice���� -   $��btnFinal��$��+��$��23��$��
120,62,0,0q�$	��Top=�$
��Left=�$��75��   *AddFinalInvoice+�� -   $��label5��$��商业发票��$��28��$
��Left=�$��	48,95,0,0q�$	��Top=��� -	   $��button1��$��+��$��23��$
��Left=�$��
120,96,0,0q�$	��Top=�$��75���� -
   $��	groupBox2��$	��180��$
��Left=�$y�Hidden=�$��
330,40,0,0q�$	��Top=�$	��250����  $! Client.Properties.Resources��$ Reports��.���� �� -   $��	groupBox3��$	��290��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.��� .+��� -   $��label6��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ QueryShortcut���� -   $"��btnCurrentMonthTemporaryList��$��23��$
��Left=�$��	30,40,0,0q�   
LinkButton#��[  $	��Top=�$
��auto����  * CurrentMonthProvisionalInvoice+�� -   $��btnCurrenttMonthFinalList��$��23��$
��Left=�$��
120,40,0,0q�#��[  $	��Top=�$
��auto����  *CurrentMonthFinalInvoice+�� -   $��label7��$
��Bold"�$��28��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��
lbSupplier��$��28��$
��Left=�$��1,98,0,0q�$	��Top=�$	��100��$��Right=���  $! Client.Properties.Resources��$ Supplier���� -   $��btnCustomer��$	��...��$��23��$
��Left=�$��231,100,0,0q�$	��Top=�$��25���� -   $��label9��$��28��$
��Left=�$��
267,98,0,0q�$	��Top=�$	��100��$��Right=���  $! Client.Properties.Resources��$ 	Commodity���� -   $��comboBoxTradeType��$��23��$
��Left=�$��373,100,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$	 Key��	 �� SelectedValuePath$	 Value������ *
Commoditys+
 �� SelectedValue
 �� *	CTypeId+�� -   $��label10��$��28��$
��Left=�$��	1,130,0,0q�$	��100��$��Right=�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -   $��label11��$��28��$
��Left=�$��267,130,0,0q�$	��Top=�$	��100��$��Right=���  *InvoiceType+�� -   $��	comboBox2��$	 Key��$��23��$
��Left=�$��107,132,0,0q�$	 Value��$	��Top=�$	��120������ *InnerCustomers+
 �� *
InterCusId+�� -   $��	comboBox1��$	 Key��$��23��$
��Left=�$��373,132,0,0q�$	 Value��$	��Top=�$	��120������ *InvoiceTypes+
 �� *CommerTypeId+�� -   $��label1��$��28��$
��Left=�$��	1,162,0,0q�$	��100��$��Right=�$	��Top=���  $! Client.Properties.Resources��$ InvoiceDate��(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��23��$
��Left=�$��107,164,0,0q�$	��Top=�$	��120��   SelectedDate �� *	StartDate+  -   $��datePicker2��$��23��$
��Left=�$��373,164,0,0q�$	��Top=�$	��120�� �� *	EndDate+�� -   $��	btnSearch��$��23��$
��Left=�$��213,233,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��textBox1��$��23��$
��Left=�$��107,100,0,0q�$	��Top=�$	��120��{�.  ���� *SName+�� -   $��label4��$��28��$
��Left=�$��267,162,0,0q�$	��100��$��Right=�$	��Top=���  $! Client.Properties.Resources��$ EndDate���� -   $��	checkBox1��$!��仅显示当前用户文档��$��16��$
��Left=�$��373,199,0,0q�$	��Top=� d� 	IsChecked �� *IsOnlyCurrentUser+�� -   $��label8��$��	批次号��$��28��$
��Left=�$��	1,194,0,0q�$	��Top=�$��Right=�$	��100���� -    $��textBox2��$��23��$
��Left=�$��107,196,0,0q�$	��Top=�$	��120������ *	QuotaNo+�� -!   $��button2��$��本月商业发票��$��23��$
��Left=�$��
211,40,0,0q�#��[  $	��Top=�$
��auto��