   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6K   5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5      D   >Client.View.Physical.CommercialInvoices.FinalCommercialInvoice   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      6
Convertersclr-namespace:Client.Converters     6K   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��5       � Language 6m   5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5           ResxName$! Client.Properties.Resources��
   Key$ FinalInvoice�� � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker1  +Client.Converters.InvoiceNetWeightConverter   InvoiceNetWeightConverter  DeleteInvoice  InvoiceActions	 �� DataType
 �� Orientation  AttachmentDownLoad  AttachmentDelete  AttachmentActions��%B  '��       '�� �     '��     '  �    &	      &	     &	 .    7  &	 '    &	 :    &	 M    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5       ��  � ��$ 23��6'   64   �� 5!       � ��$	 120��6&   64   5"        5#   
   6/   �� 5$   
   60   �� 5&   
   $ 	 DBEntity:CommercialInvoice��6.   .R�5'      �� $
 
Horizontal=�6   .+�5(      �� $��btDeleteInvoice��6   8��  ��60     $! Client.Properties.Resources��$ Delete����5)      �� *Id+6;   5*      5+      �� 5-   
   65   �� 5.   
   63   �� 50   
   $	 DBEntity:Attachment��61   .R�51      �� $
 
Horizontal=�6   .+�52      �� $��btAttachmentDownLoad��6   8��  ��65     $! Client.Properties.Resources��$ Download����53      �� *Id+6;   �� 54      $��btAttachmentDelete��6   8�� ��63     $! Client.Properties.Resources��$ Delete����55      �� *Id+6;   56      57      58       J� CommandBindings 5:      )  #System.Windows.Input.CommandBinding  5;   
   -   5           Command# [ 5;      5<   6     5>   
   -   5        # [ 5>      5?   A     5@   
   -   5        # [ 5@      5A   ?   .��5D      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5E      .��5F   
   � -   5         �Name$ rootGrid��5F       � RowDefinitions 5G      �� 5H      $
��Auto �6    �� 5I      $
��Auto �6    �� 5J      $
��Auto �6    �� 5K      $
��Auto �6    �� 5L      $
��Auto �6    �� 5M      $
��Auto �6    �� 5N      $
��Auto �6    .+�5Q      �� -   5        $��textBox1��5Q   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   ��5R      �� *	InvoiceNo+�� 5S      -   5        $��btnQuota��5S   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
518,40,0,0q�6J   $	��Top=�5T      $��25��6-   68     5U      -   5        $��invoicedDate��5U   H   $
��Left=�6   $��
122,72,0,0q�64   $	��Top=�6\      SelectedDate 5V      �� *InvoicedDate+�� 5W      -   5        $��textBox4��5W   F   $
��Left=�6   $��122,104,0,7q�61   ��6V   �� *DeliveryTerm+�� 5X      -	   5        $��paymentMean��5X   G   $
��Left=�6   $��394,104,0,7q�62    �� DisplayMemberPath$	 Key��6~    �� SelectedValuePath$ Value��6�   ��6Z   �� *PaymentMean+ �� SelectedValue 5Y      �� *SelectPaymentMeanId+�� 5Z      -
   5        $��button2��5Z   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5[      $��45��6-   $��1��68   ��5Z        $! Client.Properties.Resources��$ AddWithSymbol��5[   E   &   Utility.Controls.CurrencyTextBox  5\      -   5        $��currencyTextBox2��5\   \   $��23��6!   $
��Left=�6-   $��
122,34,0,0q�6H   $	��Top=�5]      $	��120��6&   $��4��62      Text 6?   �� *Price+�� 5^      -   5        $��textBox9��5^   ^   $��6��6   $	��100��6#   $
��Left=�60   $��	122,2,0,0q�6K   $	��Top=�5_      $	��392��6.    �� TextWrapping$
 Wrap=�6R   ��6:   �� *Remark+6R   �� 5`      -   5        $��button4��5a      $��6��5`   U   $��25��6b   $
��Left=�6n   $��210,130,0,0q�6�   $	��Top=�5a   $   $��60��6<   ��5`        $! Client.Properties.Resources��$
 Save��5a   G   �� 5b      -   5        $��button5��5c      $��6��5b   W   $��25��6d   $
��Left=�6p   $��305,130,0,0q�6�   $	��Top=�5c   $   $��60��6<   ��5b        $! Client.Properties.Resources��$ Cancel��5c   G   �� 5f      -   5        $��lbTitle��5g   L   $��32��5f   D   $
��Left=�6P   $��6,6,0,0q�6k   $
��auto��6|   $	��Top=�5g      $
��Bold"�6,   $��16(�6>   ��5f        * PurchaseCommercialInvoiceFinal+5g   L   �� 5h      -   5        $��label1��5h   �   $
��Left=�6]   $��6,38,0,0q�6x   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ CommInvoiceNo��6�   �� 5i      -   5        $��label2��5i   �   $
��Left=�6[   $��6,70,0,0q�6v   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ InvoiceDate��6�   �� 5j      -   5        $��label3��5j   �   $
��Left=�6W   $��
278,38,0,0q�6r   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ QuotaNo��5k      �� 5l      -   5        $��textBox2��5l   E   $
��Left=�6   $��
394,40,0,0q�61   $	��Top=�6U   {�.  ��5m      �� *	QuotaNo+6/   �� 5n      -   5        $��
lbSupplier��5n   �   $
��Left=�6X   $��
278,70,0,0q�6s   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Supplier��6�   �� 5o      -   5        $��textBox3��5o   E   $
��Left=�6   $��
394,72,0,0q�61   $	��Top=�6U    �� 
IsReadOnly . ��5p      �� *SupplierName+64   �� 5q      -   5        $��label5��5q   �   $
��Left=�6X   $��	6,102,0,0q�6s   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ ShipTerm��6�   �� 5r      -   5        $��label6��5r   �   $
��Left=�6[   $��278,102,0,0q�6v   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ PaymentMean��6�   &   System.Windows.Controls.DataGrid  5t      -   5        $��	dataGrid1��5u   /      AutoGenerateColumns .  $
��auto��5t   3   $
��Left=�6A   $��
122,34,0,7q�6\   $	��Top=�5u   @   $
��auto��6X      CanUserAddRows .     
IsReadOnly . $��1��5v      ��5u      ��    Columns 5w      0  *System.Windows.Controls.DataGridTextColumn  5x      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$ ProvisionalInvoiceNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6x   �� *	InvoiceNo+  5y      $ 结算金额��6)    67   �� *Amount+$   DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z   5z       6)     $! Client.Properties.Resources��$ SettleCurrency�� 6r   �� *Currency.Name+  5{       6)     $! Client.Properties.Resources��$ 	NetWeight�� 5|   )   �� *
NetWeights+   STR_QUANTITY# Z   5}       6)     $! Client.Properties.Resources��$ 
LCInterest�� 5~   )   �� *TotleInterest+# Z 4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate# [ 6q    6-     $! Client.Properties.Resources��$ 	Operation��6q   5�      �� 5�      -   5        $��label7��5�   �   $��4��6Y   $��28��6f   $
��Left=�6r   $��6,0,0,0q�6�   $	��Top=�5�      ��5�        $! Client.Properties.Resources��$ 	NetWeight��5�      �� 5�      -   5        $��textBox5��5�   Q   $��4��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   {�.  ��5�   +   �� *
NetWeights+# Z 6�   �� 5�      -   5        $��label8��5�   �   $
��Left=�6[   $��	278,0,0,0q�6v   $	��Top=�6�   $��4��6�   ��6     $! Client.Properties.Resources��$ GrossWeight��6�   �� 5�      -   5        $��textBox6��5�   D   $
��Left=�6   $��	394,2,0,0q�61   $	��Top=�6T   $��4��6l   {�.  ��5�      �� *GrossWeight+# Z 6g   �� 5�      -   5        $��label9��5�   y   $��4��6=   $
��Left=�6J   $��
278,96,0,0q�6e   $	��Top=�5�      ��5�        *AmountIncludingInterest+5�        5�      -   5        $��currencyTextBox1��5�      $��4��5�   !   $��23��6.   $
��Left=�6:   $��
394,98,0,0q�6U   $	��Top=�5�   %   $	��120��6=    .  6I   �� *Money+6`   �� 5�      -   5        $��label10��5�   �   $
��Left=�6_   $��
278,32,0,0q�6z   $	��Top=�6�   $��4��6�   ��6     $! Client.Properties.Resources��$ PricingCurrency��6�   �� 5�      -    5        $��textBox7��5�   *   $��
394,34,0,0q�6   $	��Top=�6:   $��4��6R    . $
��Left=�5�   (   $	��120��6C   ��5�   _   �� *
Currency+5�   C   �� 5�      -!   5        $��label11��5�   �   $
��Left=�6Z   $��6,96,0,0q�6u   $	��Top=�5�      $��4��6,   ��5�        $! Client.Properties.Resources��$ 
LCInterest��5�   ,   �� 5�      -"   5        $��textBox8��5�   E   $
��Left=�6   $��
122,98,0,0q�61   $	��Top=�6U   $��4��6m   {�.  ��5�      �� *
Interest+# Z 6e   �� 5�      -#   5        $��label12��5�   �   $
��Left=�6U   $��6,32,0,0q�6p   $	��Top=�6�   $��4��5�      ��5�        $! Client.Properties.Resources��$ Price��5�      �� 5�      -$   5        $��label13��5�   �   $��6��6X   $
��Left=�6e   $��6,0,0,0q�6�   $	��Top=�5�      ��5�        $! Client.Properties.Resources��$ Comments��5�      �� 5�      -%   5        $��	lbBalance��5�   _   $
��Left=�6/   $��278,128,0,0q�6J   $	��Top=�6p   $��4��6�   ��6   �� *LbName+6�   �� 5�      -&   5        $��lbPriceingCurrencyBalance��5�   _   $
��Left=�6/   $��278,192,0,0q�6J   $	��Top=�6�   $��4��6�   ��6   �� *LbName+6�     5�      -'   5        $��currencyTextBox3��5�   ]   $��23��6!   $
��Left=�6-   $��394,130,0,0q�6H   $	��Top=�5�   a   $	��120��6y   $��4��6�   {�.   6   �� *	Balance+# Z 6�     5�      -(   5        $��currencyTextBox5��5�   ]   $��23��6!   $
��Left=�6-   $��394,194,0,7q�6H   $	��Top=�5�   p   $	��120��6�   $��4��6�   {�.   6   �� *PricingCurrencyBalance+# Z 6�   �� 5�      -)   5        $��label4��5�   �   
���<��$
��Left=�6s   $��	6,128,0,0q�6�   $	��Top=�5�      $��4��6,   ��5�        $! Client.Properties.Resources��$ SettleCurrency��5�   ,   �� 5�      -*   5        $��	comboBox1��5�   O   $
 Name��5�      $
��Left=�60   $��122,130,0,7q�5�   :   $ Id��5�      $��4��6.   $	��Top=�6;   ��5�      �� *
Currencies+ 6`   �� *SelectCurrencyId+5�   ;   �� 5�      -+   5        $��label14��5�   �   $
��Left=�6\   $��6,64,0,0q�6w   $	��Top=�6�   $��4��6�   ��6     $! Client.Properties.Resources��$ ExchangeRate��6�     5�      -,   5        $��currencyTextBox4��5�      $��23��5�   !   $
��Left=�6-   $��
122,66,0,0q�6H   $	��Top=�5�   F   $	��120��6^   $��4��6j    6&   �� *SettlementRate+6j   �� 5�      --   5        $��label15��5�   �   $��1��6b   $
��Left=�6o   $��6,0,0,0q�6�   $	��Top=�5�      ��5�        $! Client.Properties.Resources��$ ProvisionalInvoice��5�      �� 5�      -.   5        $��lblBankAccount��5�      $��4��5�   [   $
��Left=�6h   $��	6,192,0,0q�6�   $	��Top=�5�   *   ��5�        $! Client.Properties.Resources��$ BankAccount��y�5�   B   �� *	IsVisible+�� 5�      -/   5        $��cbBankAccount��5�   `   $��4��6   $��23��6$   $
��Left=�60   $��122,194,0,7q�6K   $	��Top=�5�      $	��120��6/   $ AccountCode��6;   $ Id��5�   G   ��5�   [   �� *BankAccountList+ 5�      �� *SelectedBankAccountID+y�6^   �� *	IsVisible+�� 5�      -0   5        $��button1��5�   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�6�   $��45��6�   $��5��6�   ��6     $! Client.Properties.Resources��$ AddWithSymbol��6�   �� 5�      $
��Left=�6Z   $��6,0,0,0q�6u   $	��Top=�6�   $��5��6�   ��6     $! Client.Properties.Resources��$ 
Attachment��6�     5�      -1   5        $��dataGridAttachment��5�   �    .   .  $
��Left=�6J    . $��
122,34,0,7q�6�   $
��auto��6�   $��5��6�   $
��auto��6�   $	��Top=�6�   ��6w   ��  5�        5�       6)   �� *Name+ 6B     $! Client.Properties.Resources��$ AttachmentName��  5�        	  CanUserSort  .  # [ 6A    6s     $! Client.Properties.Resources��$ 	Operation��5�      �� 5�      -2   5        $��	checkBox1��5�   v   $*��$该批次已完成全部商业发票��6   $��4��6.   $��16��6;   $
��Left=�6G   $��
394,70,0,0q�6b   $	��Top=�6�   ! d� 	IsChecked! 6�   �� *IsCIFinished+y�6�   �� *IsFinishedVisible+�� 5�      -3   5        $��label16��5�   S   $��二次结算币种��6   $
��Left=�6%   $��	6,160,0,0q�6@   $	��Top=�6b   $��4��6z   �� 5�      -4   5        $��	comboBox2��5�   �   $
 Name��6   $
��Left=�60   $��122,162,0,0q�6n   $ Id��6�   $	��Top=�6�   $��4��6�   ��6K   �� *
Currencies+ 6�   �� *ClearBalanceCurrencyId+6�   �� 5�      -5   5        $��label17��5�   U   $��二次结算汇率��6   $
��Left=�6%   $��278,160,0,0q�6@   $	��Top=�6d   $��4��6|     5�      -6   5        $��currencyTextBox6��5�   ]   $��23��6!   $
��Left=�6-   $��394,162,0,0q�6H   $	��Top=�6�   $	��120��6�   $��4��6�    6u   �� *ClearBalanceRate+6�   5�      5�      5�      