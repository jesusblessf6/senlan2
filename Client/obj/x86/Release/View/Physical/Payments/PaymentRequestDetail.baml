   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 8   2Client.View.Physical.Payments.PaymentRequestDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ PaymentRequest�� � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker.  (Client.Converters.ApproveStatusConverter  ApproveStatusConverter  DeliveryDelete  DeliveryActions	 �� DataType
 �� Orientation��%$  &	        '�� �     '�� �     '  �     &	 .    &	 3    &	 8    7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� �� $	 DBEntity:Delivery��.R��� $
 
Horizontal=�.+��� $��btDeliveryDelete��8��  ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $	��55* �.+�  -   $��datePicker1��$
��Left=�$��
394,40,0,0q�$	��Top=�   SelectedDate �� *RequestDate+&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��122,104,0,0q�$	��Top=�$	��120��   Text �� *RequestAmount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z �� -   $��	comboBox3��$
��Left=�$��394,104,0,0q�$	��Top=� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *	Currencys+ �� SelectedValue �� *
CurrencyId+�� -   $��	comboBox1��$
��Left=�$��122,168,0,0q�$	��Top=�$ Id��$ 	ShortName������ *BusinessPartners+ �� *	PayBPId+�� -   $��	comboBox4��$
��Left=�$��394,168,0,0q�$	��Top=�$ Id��$ Description������ *PayBankAccounts+ �� *PayBankAccountId+�� -   $��button2��$	��...��$��23��$
��Left=�$��246,200,0,0q�$	��Top=�$��25���� -	   $��	comboBox5��$
��Left=�$��394,200,0,0q�$	��Top=�$ Id��$ Description������ *ReceiveBankAccounts+ �� *ReceiveBankAccountId+�� -
   $��	comboBox6��$
��Left=�$��122,232,0,0q�$ Id��$
 Name��$��23��$	��Top=����� *PaymentUsages+ �� *PaymentUsageId+�� -   $��	comboBox2��$
��Left=�$��394,232,0,0q�$ Id��$
 Name��$��23��$	��Top=����� *PaymentMeans+ �� *PaymentMeanId+�� -   $��button1��$	��...��$��23��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25���� -   $��textBox7��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392��$��3������ *	Comment+�� -   $��button3��$��23��$
��Left=�$��210,130,0,0q�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$
 Save���� -   $��button5��$��23��$
��Left=�$��411,130,0,0q�$	��Top=�$��60��$y�Hidden=�$��3����  $! Client.Properties.Resources��$ SaveAsDraft���� -   $��button4��$��23��$
��Left=�$��305,130,0,0q�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$ Cancel���� -   $��lbTitle��#��[  $��6,6,0,0q�$��16(�$
��Bold"�$��32��$	��Top=�$
��Left=�$
��auto����  $! Client.Properties.Resources��$ PaymentRequest���� -   $��label2��#��[  $
��Left=�$��6,38,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Quota���� -   $��label3��#��[  $
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Status���� -   $��label4��#��[  $
��Left=�$��	6,102,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ AppliedAmount���� -   $��label5��#��[  $
��Left=�$��	6,134,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 
PaidAmount���� -   $��label6��#��[  $
��Left=�$��	6,166,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ 	PaymentBP���� -   $��label7��#��[  $
��Left=�$��	6,198,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ 	ReceiptBP���� -   $��label8��#��[  $
��Left=�$��278,230,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ PaymentMean���� -   $��label9��#��[  $
��Left=�$��
278,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ 	ApplyDate���� -   $��label10��#��[  $
��Left=�$��
278,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ApprovalStatus���� -   $��label11��#��[  $
��Left=�$��278,102,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ PaymentCurrency���� -   $��label12��#��[  $
��Left=�$��278,166,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PaymentAccount���� -   $��label13��#��[  $
��Left=�$��278,198,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ReceiptAccount���� -   $��label14��#��[  $
��Left=�$��	6,230,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ PaymentUsage���� -   $��textBox1��$
��Left=�$��
122,40,0,0q�$	��Top=�{�.  ���� *	QuotaNo+�� -    $��textBox2��$
��Left=�$��
122,72,0,0q�$	��Top=� �� 
IsReadOnly . �� -!   $��textBox5��$
��Left=�$��122,200,0,0q�$	��Top=�{�.  ���� *	ShortName+�� -"   $��textBox6��$
��Left=�$��
394,72,0,0q�$	��Top=� . ���� *PRApproveStatus+ �� 	Converter# [ �� -#   $��label15��#��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��3����  $! Client.Properties.Resources��$ Comments��  -$   $��currencyTextBox2��$��23��$
��Left=�$��122,136,0,0q�$	��Top=�$	��120��{�.   �� *
PaidAmount+# Z �� -%   $��button6��$��23��$
��Left=�$��	122,5,0,0q�$	��Top=�$��45��$��1��$y�	Collapsed=���  $! Client.Properties.Resources��$ AddWithSymbol��$   Utility.Controls.PagingControl  -&   $��pagingControl1��$��	122,0,0,0q�$	��Top=�$
��auto��$
��Left=�$��2��$y�	Collapsed=�&	   System.Windows.Controls.DataGrid	  -'   $��deliverydataGrid�� 	  AutoGenerateColumns .  $
��Auto��$
��Left=�$��
122,32,0,0q�$	��Top=�$
��Auto�� 	  
IsReadOnly . $��2��$y�	Collapsed=� 	  Columns 0
  *System.Windows.Controls.DataGridTextColumn
  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    Header   $! Client.Properties.Resources��$
 BLNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
DeliveryNo+
  $
 Auto  .    $! Client.Properties.Resources��$ CommodityType�� �� *Quota.CommodityType.Name+
  $
 Auto  .    $! Client.Properties.Resources��$ Brand�� �� *TotalBrands+
  $
 Auto  .    $! Client.Properties.Resources��$ Quantity�� �� *
TotalQty+   STR_QUANTITY# Z 4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto  .      CellTemplate#  [    $! Client.Properties.Resources��$ 	Operation���� -(   $��label16��#��[  $��1��$
��Left=�$��6,3,0,0q�$	��Top=�$��2��$y�	Collapsed=���  $! Client.Properties.Resources��$ BLDetail���� -)   $��	checkBox1��$!��该批次完成付款申请��$��16��$
��Left=�$��394,140,0,0q�$	��Top=�! d� 	IsChecked! �� *IsPaymentRequestFinished+�� -*   $��label1��$��	中转行��#��[  $��28��$
��Left=�$��	6,262,0,0q�$	��Top=��� -+   $��	comboBox7��$��23��$
��Left=�$��122,264,0,7q�$	��Top=�$	��120��$ Id��$
 Name������ *IBanks+ �� *SelectedBankValue+