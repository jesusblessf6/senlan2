   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity J   DClient.View.Physical.CommercialInvoices.ProvisionalCommercialInvoice   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.Physical.CommercialInvoices.ResCommercialInvoice�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ ProvisionalInvoice�� � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   AttachmentDownLoad  AttachmentDelete  DeleteDelivery  DeleteLetterOfCredit  DeliveryActions	 �� DataType
 �� Orientation  LetterOfCreditActions  AttachmentActions��%�  '��       '�� S     '�� �     '  �     &	      &	     &	     &	     &	     7  &	 �    7  &	 e    7   7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� �� �� $	 DBEntity:Delivery��.R��� $
 
Horizontal=�.+��� $��btDeleteDelivery��8��  ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $	 DBEntity:LetterOfCredit��.R��� $
 
Horizontal=�.+��� $��btDeleteLetterOfCredit��8��  ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $	 DBEntity:Attachment��.R��� $
 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $! Client.Properties.Resources��$ Download������ *Id+�� $��btAttachmentDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [    -   # [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��textBox1��$
��Left=�$��
122,40,0,0q�$	��Top=����� *	InvoiceNo+�� -   $��btnQuota��$	��...��$��23��$
��Left=�$��
518,40,0,0q�$	��Top=�$��25��{��� *IsQuotaEnable+  -   $��invoicedDate��$
��Left=�$��
122,72,0,0q�$	��Top=�   SelectedDate �� *InvoicedDate+�� -	   $��textBox4��$
��Left=�$��122,104,0,7q�$	��Top=����� *DeliveryTerm+�� -
   $��paymentMean��$
��Left=�$��394,104,0,7q�$	��Top=� �� DisplayMemberPath$	 Key�� �� SelectedValuePath$ Value������ *PaymentMean+ �� SelectedValue �� *SelectPaymentMeanId+{��� *IsPaymentMeansEnable+�� -   $��button2��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��1����  $! Client.Properties.Resources��$ AddWithSymbol��{��� *IsLCAddEnable+�� -   $��button3��$��3��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��{��� *IsDeliveryAddEnable+&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��5��$��23��$
��Left=�$��122,130,0,7q�$	��Top=�$	��120��   Text �� *Money+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *IsAmountEnable+�� -   $��textBox9��$��8��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392�� �� TextWrapping$
 Wrap=����� *Remark+�� -   $��button4��$��8��$��25��$
��Left=�$��210,130,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$
 Save���� -   $��button5��$��8��$��25��$
��Left=�$��305,130,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Cancel���� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *&$PurchaseCommercialInvoiceProvisional+�� -   $��label1��$
��Left=�$��6,38,0,0q�$	��Top=���  $! Client.Properties.Resources��$ CommInvoiceNo���� -   $��label2��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InvoiceDate���� -   $��label3��$
��Left=�$��
278,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ QuotaNo���� -   $��textBox2��$
��Left=�$��
394,40,0,0q�$	��Top=�{�.  ���� *	QuotaNo+�� -   $��
lbSupplier��$
��Left=�$��
278,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Supplier���� -   $��textBox3��$
��Left=�$��
394,72,0,0q�$	��Top=� �� 
IsReadOnly . ���� *SupplierName+�� -   $��label5��$
��Left=�$��	6,102,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ShipTerm���� -   $��label6��$
��Left=�$��278,102,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PaymentMean��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��auto��$
��Left=�$��
122,34,0,7q�$	��Top=�$
��auto��   CanUserAddRows .     
IsReadOnly . $��1������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header   $! Client.Properties.Resources��$ LoCNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *LetterOfCredit.LCNo+     $! Client.Properties.Resources��$ 	LoCAmount�� �� *LetterOfCredit.IssueAmount+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z      $! Client.Properties.Resources��$ LoCCurrency�� �� *LetterOfCredit.Currency.Name+     $! Client.Properties.Resources��$ 
LCInterest�� �� *LetterOfCredit.Interest+# Z      $! Client.Properties.Resources��$ LCPresentAmount�� �� *LetterOfCredit.PresentAmount+# Z   $ 分配金额�� �� *AllocationAmount+# Z 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [    $! Client.Properties.Resources��$ 	Operation��  -   $��	dataGrid2�� .  $
��auto��$
��Left=�$��
122,34,0,7q�$	��Top=�$
��auto�� .   . $��3������       $! Client.Properties.Resources��$
 BLNo�� �� *
DeliveryNo+     $! Client.Properties.Resources��$ IssuingDate�� �� *	IssueDate+$ {0:yyyy-MM-dd}��     $! Client.Properties.Resources��$ 	Commodity�� �� *,*DeliveryLines/CommodityType.Commodity.Name+     $! Client.Properties.Resources��$ Brand�� �� *TotalBrands+     $! Client.Properties.Resources��$ 	NetWeight�� �� *TotalNetWeight+  
  STR_QUANTITY# Z       $! Client.Properties.Resources��$ GrossWeight�� �� *TotalGrossWeight+# Z    # [    $! Client.Properties.Resources��$ 	Operation���� -   $��label7��$��5��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	NetWeight���� -   $��textBox5��$��5��$
��Left=�$��	122,2,0,0q�$	��Top=�{�.  ���� *
NetWeights+# Z  �� -   $��label8��$
��Left=�$��	278,0,0,0q�$	��Top=�$��5����  $! Client.Properties.Resources��$ GrossWeight���� -   $��textBox6��$��23��$
��Left=�$��	394,2,0,0q�$	��Top=�$	��120��$��5��{�.  ���� *GrossWeight+# Z  �� -    $��label9��$��结算金额��$��5��$
��Left=�$��	6,128,0,0q�$	��Top=��� -!   $��label10��$
��Left=�$��
278,32,0,0q�$	��Top=�$��5����  $! Client.Properties.Resources��$ PricingCurrency���� -"   $��textBox7��$��23��$
��Left=�$��
394,34,0,0q�$	��Top=�$��5��{�.  ���� *
Currency+�� -#   $��label11��$��Right=�$
��Left=�$��
278,96,0,0q�$	��Top=�$��5����  $! Client.Properties.Resources��$ 
LCInterest���� -$   $��textBox8��$
��Left=�$��
394,98,0,0q�$	��Top=�$��5��{�.  ���� *
Interest+# Z �� -%   $��label12��$��
278,64,0,0q�$	��Top=�$��5��$
��Left=�
���<����  $! Client.Properties.Resources��$ Price��  -&   $��currencyTextBox2��$��23��$
��Left=�$��
394,66,0,0q�$	��Top=�$	��120��$��5�� �� *Price+$ PropertyChanged=�{��� *IsPriceEnable+�� -'   $��label13��$��8��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -(   $��label4��$��5��$
��Left=�$��6,32,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ SettleCurrency���� -)   $��	comboBox1��$��5��$
��Left=�$��
122,34,0,0q�$	��Top=�$
 Name��$ Id������ *
Currencies+ �� *SelectCurrencyId+{��� *IsSettlementCurrencyEnable+�� -*   $��label14��$��5��$
��Left=�$��6,64,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ExchangeRate��  -+   $��currencyTextBox3��$��5��$��23��$
��Left=�$��
122,66,0,0q�$	��Top=�$	��120�� �� *SettlementRate+$ PropertyChanged=�{��� *IsExchangeRateEnable+�� -,   $��label15��$��1��$
��Left=�$��6,0,0,0q�$	��Top=���  $! Client.Properties.Resources��$ LetterOfCredit��{��� *IsExchangeRateEnable+�� --   $��deliverieName��$��3��$
��Left=�$��6,0,0,0q�$	��Top=��� -.   $��lblBankAccount��$��5��$
��Left=�$��278,128,0,0q�$	��Top=���  $! Client.Properties.Resources��$ BankAccount��y��� *	IsVisible+�� -/   $��cbBankAccount��$��5��$
��Left=�$��394,130,0,7q�$ AccountCode��$ Id��$	��Top=����� *BankAccountList+ �� *SelectedBankAccountID+y��� *	IsVisible+�� -0   $��button1��$��+新增��$��7��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��  -1   $��dataGridAttachment�� .   .  $
��Left=� . $��
122,34,0,7q�$
��Auto��$��7��$
��auto��$	��Top=����� *Attachments+    �� *Name+   $! Client.Properties.Resources��$ AttachmentName��  !   CanUserSort! .  # [    $! Client.Properties.Resources��$ 	Operation���� -2   $��label16��$��7��$��28��$
��Left=�$��6,0,0,0q�$	��Top=�$	��110����  $! Client.Properties.Resources��$ 
Attachment���� -3   $��label17��$��比例��$��28��$
��Left=�$��6,96,0,0q�$	��Top=�$	��110��$��5���� -4   $��	textBox10��$��23��$
��Left=�$��
122,98,0,0q�$	��Top=�$	��120��$��5������ *Ratio+$ PropertyChanged=��� -5   $��label18��$��%��$��23��$
��Left=�$��
240,96,0,0q�$	��Top=�$��20��$��5���� -6   $��	checkBox1��$*��$该批次已完成全部商业发票��$��6��$��16��$
��Left=�$��	122,2,0,7q�$	��Top=�" d� 	IsChecked" �� *IsCIFinished+y��� *IsFinishedVisible+