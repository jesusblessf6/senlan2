   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient ;   5Client.View.Physical.VATInvoices.VATInvoiceLineDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     $	��380��$	��550��0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice�� � 
ResizeMode$ NoResize=� � Title   *InvoiceDetail+ � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources  �� 
TargetType �� Property �� Value��%  '��       '�� �     '�� �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��button2��$	��...��$��23��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25���� -   $��	comboBox5��	 �� DisplayMemberPath$
	 Code��$��23��$
��Left=�$��
394,72,0,0q�
 �� SelectedValuePath$
 Id��$	��Top=�$	��120������ *
VATRates+ �� SelectedValue �� *	VATRateId+&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox3��$��23��$
��Left=�$��
122,72,0,0q�$	��Top=�$	��120��   Text �� *VATInvoiceQuantity+  -   $��currencyTextBox1��$��23��$
��Left=�$��122,104,0,0q�$	��Top=�$	��120�� �� *	VATAmount+�� -   $��cbVATStatus��$
��Left=�$��122,136,0,0q�$	��Top=�$y�	Collapsed=���  *FullyInvoiced+ d� 	IsChecked �� *	VATStatus+�� -   $��textBox6��$	��100��$
��Left=�$��122,168,0,0q�$	��Top=�$	��392������ *	Comment+�� -   $��button3��$��23��$
��Left=�$��210,292,0,0q�$	��Top=�$��60����     ResxName$! Client.Properties.Resources��
   Key$
 Save���� -	   $��button5��$��23��$y�Hidden=�$
��Left=�$��371,292,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ SaveAsDraft���� -
   $��button4��$��23��$
��Left=�$��305,292,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Cancel���� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$
��Left=�$	��Top=�$
��Bold"�$��16(���  *InvoiceDetail+�� -   $��label2��$��6,38,0,0q�
���<��$	��Top=�$
��Left=���  $! Client.Properties.Resources��$ Quota���� -   $��textBox1��$
��Left=�{�.  $��
122,40,0,0q�$	��Top=����� *	QuotaNo+�� -   $��label3��$��批次未开数量��$
��Left=�$��
278,38,0,0q�$	��Top=�  -   $��currencyTextBox2��$��23��$
��Left=�$��
394,40,0,0q�$	��Top=�$	��120��{�.   �� *UnOpenedQuantity+�� -   $��label4��$
��Left=�$��6,70,0,0q�$	��Top=���  *
InvoiceQty+�� -   $��label6��$
��Left=�$��
278,70,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ TaxRate��  -   $��currencyTextBox4��$��23��$
��Left=� �� 
IsReadOnly . $��394,104,0,0q�$	��Top=�$	��120�� �� *	RateValue+�� -   $��label9��$
��Left=�$��	6,102,0,0q�$	��Top=���  *InvoiceAmountTaxIncluded+�� -   $��label5��$
��Left=�$��278,102,0,0q�$	��Top=���  *	TaxAmount+�� -   $��label10��$
��Left=�$��	6,166,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments��  -   $��currencyTextBox5��$��23��$
��Left=�$��394,136,0,0q�$	��Top=�$	��120�� �� *
VATPrice+�� -   $��label7��$
��Left=�$��278,134,0,0q�$	��Top=���  *InvoicePrice+