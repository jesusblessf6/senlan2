   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  D   >Client.View.Physical.CommercialInvoices.FinalCommercialInvoice   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.Physical.CommercialInvoices.ResCommercialInvoice�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ FinalInvoice�� � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker1  +Client.Converters.InvoiceNetWeightConverter   InvoiceNetWeightConverter  DeleteInvoice  InvoiceActions	 �� DataType
 �� Orientation  AttachmentDownLoad  AttachmentDelete  AttachmentActions��%D  '��       '�� S     '�� �     '  �     &	      &	     &	     7  &	 �    &	 �    &	 �    7  7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� �� $ 	 DBEntity:CommercialInvoice��.R��� $
 
Horizontal=�.+��� $��btDeleteInvoice��8��  ��  $! Client.Properties.Resources��$ Delete������ *Id+�� �� �� $	 DBEntity:Attachment��.R��� $
 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $! Client.Properties.Resources��$ Download������ *Id+�� $��btAttachmentDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��textBox1��$
��Left=�$��
122,40,0,0q�$	��Top=����� *	InvoiceNo+�� -   $��btnQuota��$	��...��$��23��$
��Left=�$��
518,40,0,0q�$	��Top=�$��25��  -   $��invoicedDate��$
��Left=�$��
122,72,0,0q�$	��Top=�   SelectedDate �� *InvoicedDate+�� -   $��textBox4��$
��Left=�$��122,104,0,7q����� *DeliveryTerm+�� -	   $��paymentMean��$
��Left=�$��394,104,0,7q� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value������ *PaymentMean+ �� SelectedValue �� *SelectPaymentMeanId+�� -
   $��button2��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��1����  $! Client.Properties.Resources��$ AddWithSymbol��&   Utility.Controls.CurrencyTextBox  -   $��currencyTextBox2��$��23��$
��Left=�$��
122,34,0,0q�$	��Top=�$	��120��$��4��   Text �� *Price+�� -   $��textBox9��$��6��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392�� �� TextWrapping$
 Wrap=����� *Remark+�� -   $��button4��$��6��$��25��$
��Left=�$��210,130,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$
 Save���� -   $��button5��$��6��$��25��$
��Left=�$��305,130,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Cancel���� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  * PurchaseCommercialInvoiceFinal+�� -   $��label1��$
��Left=�$��6,38,0,0q�$	��Top=���  $! Client.Properties.Resources��$ CommInvoiceNo���� -   $��label2��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InvoiceDate���� -   $��label3��$
��Left=�$��
278,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ QuotaNo���� -   $��textBox2��$
��Left=�$��
394,40,0,0q�$	��Top=�{�.  ���� *	QuotaNo+�� -   $��
lbSupplier��$
��Left=�$��
278,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Supplier���� -   $��textBox3��$
��Left=�$��
394,72,0,0q�$	��Top=� �� 
IsReadOnly . ���� *SupplierName+�� -   $��label5��$
��Left=�$��	6,102,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ShipTerm���� -   $��label6��$
��Left=�$��278,102,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PaymentMean��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��auto��$
��Left=�$��
122,34,0,7q�$	��Top=�$
��auto��   CanUserAddRows .     
IsReadOnly . $��1������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $! Client.Properties.Resources��$ ProvisionalInvoiceNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *	InvoiceNo+  $ 结算金额�� �� *Amount+$   DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z      $! Client.Properties.Resources��$ SettleCurrency�� �� *Currency.Name+     $! Client.Properties.Resources��$ 	NetWeight�� �� *Id+ �� 	Converter# [     STR_QUANTITY# Z      $! Client.Properties.Resources��$ 
LCInterest�� �� *TotleInterest+# Z 4  .System.Windows.Controls.DataGridTemplateColumn      CellTemplate#  [    $! Client.Properties.Resources��$ 	Operation���� -   $��label7��$��4��$��28��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	NetWeight���� -   $��textBox5��$��4��$
��Left=�$��	122,2,0,0q�$	��Top=�{�.  ���� *
NetWeights+# Z �� -   $��label8��$
��Left=�$��	278,0,0,0q�$	��Top=�$��4����  $! Client.Properties.Resources��$ GrossWeight���� -   $��textBox6��$
��Left=�$��	394,2,0,0q�$	��Top=�$��4��{�.  ���� *GrossWeight+# Z �� -   $��label9��$��4��$
��Left=�$��6,96,0,0q�$	��Top=���  *AmountIncludingInterest+  -   $��currencyTextBox1��$��4��$��23��$
��Left=�$��
122,98,0,0q�$	��Top=�$	��120�� .  �� *Money+�� -   $��label10��$
��Left=�$��	6,160,0,0q�$	��Top=�$��4����  $! Client.Properties.Resources��$ PricingCurrency���� -    $��textBox7��$��122,162,0,7q�$	��Top=�$��4�� . $
��Left=�$	��120������ *
Currency+�� -!   $��label11��$
��Left=�$��6,64,0,0q�$	��Top=�$��4����  $! Client.Properties.Resources��$ 
LCInterest���� -"   $��textBox8��$
��Left=�$��
122,66,0,0q�$	��Top=�$��4��{�.  ���� *
Interest+# Z �� -#   $��label12��$
��Left=�$��6,32,0,0q�$	��Top=�$��4����  $! Client.Properties.Resources��$ Price���� -$   $��label13��$��6��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -%   $��	lbBalance��$
��Left=�$��278,128,0,0q�$	��Top=�$��4������ *LbName+�� -&   $��lbPriceingCurrencyBalance��$
��Left=�$��278,160,0,0q�$	��Top=�$��4������ *LbName+  -'   $��currencyTextBox3��$��23��$
��Left=�$��394,130,0,0q�$	��Top=�$	��120��$��4��{�.   �� *	Balance+# Z   -(   $��currencyTextBox5��$��23��$
��Left=�$��394,162,0,7q�$	��Top=�$	��120��$��4��{�.   �� *PricingCurrencyBalance+# Z �� -)   $��label4��
���<��$
��Left=�$��	6,128,0,0q�$	��Top=�$��4����  $! Client.Properties.Resources��$ SettleCurrency���� -*   $��	comboBox1��$
 Name��$
��Left=�$��122,130,0,7q�$ Id��$��4��$	��Top=����� *
Currencies+ �� *SelectCurrencyId+�� -+   $��label14��$
��Left=�$��
278,32,0,0q�$	��Top=�$��4����  $! Client.Properties.Resources��$ ExchangeRate��  -,   $��currencyTextBox4��$��23��$
��Left=�$��
394,34,0,7q�$	��Top=�$	��120��$��4�� �� *SettlementRate+�� --   $��label15��$��1��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ProvisionalInvoice���� -.   $��lblBankAccount��$��4��$
��Left=�$��
278,64,0,0q�$	��Top=���  $! Client.Properties.Resources��$ BankAccount��y��� *	IsVisible+�� -/   $��cbBankAccount��$��4��$��23��$
��Left=�$��
394,66,0,0q�$	��Top=�$	��120��$ AccountCode��$ Id������ *BankAccountList+ �� *SelectedBankAccountID+y��� *	IsVisible+�� -0   $��button1��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��5����  $! Client.Properties.Resources��$ AddWithSymbol���� $
��Left=�$��6,0,0,0q�$	��Top=�$��5����  $! Client.Properties.Resources��$ 
Attachment��  -1   $��dataGridAttachment�� .   .  $
��Left=� . $��
122,34,0,7q�$
��auto��$��5��$
��auto��$	��Top=�����     �� *Name+   $! Client.Properties.Resources��$ AttachmentName��  ! 	  CanUserSort! .  #  [    $! Client.Properties.Resources��$ 	Operation���� -2   $��	checkBox1��$*��$该批次已完成全部商业发票��$��4��$��16��$
��Left=�$��394,102,0,0q�$	��Top=�" d� 	IsChecked" �� *IsCIFinished+y��� *IsFinishedVisible+