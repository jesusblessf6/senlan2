   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   �   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      J   DClient.View.Physical.CommercialInvoices.ProvisionalCommercialInvoice   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   �   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9        ResxName$! Client.Properties.Resources��
   Key$ ProvisionalInvoice�� � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker   AttachmentDownLoad  AttachmentDelete  DeleteDelivery  DeleteLetterOfCredit  DeliveryActions	 �� DataType
 �� Orientation  LetterOfCreditActions  AttachmentActions��%E  '��       '�� �     '��     '  �    &	      &	     &	 .    &	 A    &	 T    7  &	 E    7  &	 B    7   7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5       ��  � ��$ 23��6'   64   �� 5!       � ��$	 120��6&   64   5"      �� 5$   
   65   �� 5%   
   63   �� 5&   
   61   �� 5'   
   67   �� 5)   
   $	 DBEntity:Delivery��6/   .R�5*      �� $
 
Horizontal=�6   .+�5+      �� $��btDeleteDelivery��6   8��  ��61     $! Client.Properties.Resources��$ Delete����5,      �� *Id+6;   5-      5.      �� 50   
   $	 DBEntity:LetterOfCredit��65   .R�51      �� $
 
Horizontal=�6   .+�52      �� $��btDeleteLetterOfCredit��6   8��  ��67     $! Client.Properties.Resources��$ Delete����53      �� *Id+6;   54      55      �� 57   
   $	 DBEntity:Attachment��61   .R�58      �� $
 
Horizontal=�6   .+�59      �� $��btAttachmentDownLoad��6   8��  ��65     $! Client.Properties.Resources��$ Download����5:      �� *Id+6;   �� 5;      $��btAttachmentDelete��6   8�� ��63     $! Client.Properties.Resources��$ Delete����5<      �� *Id+6;   5=      5>      5@       J� CommandBindings 5A      )  #System.Windows.Input.CommandBinding  5B   
   -   5           Command# [ 5B      5C   =     5D   
   -   5        # [ 5D      5E   C     5F   
   -   5        # [  5F      5G   A     5H   
   -   5        # [ 5H      5I   ?   .��5K      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5L      .��5M   
   � -   5         �Name$ rootGrid��5M       � RowDefinitions 5N      �� 5O      $
��Auto �6    �� 5P      $
��auto �6    �� 5Q      $
��auto �6    �� 5R      $
��auto �6    �� 5S      $
��auto �6    �� 5T      $
��auto �6    �� 5U      $
��auto �6    �� 5V      $
��auto �6    �� 5W      $
��auto �6    �� 5X      $
��auto �6    .+�5[      �� -   5        $��textBox1��5[   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   ��5\      �� *	InvoiceNo+�� 5]      -   5        $��btnQuota��5]   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
518,40,0,0q�6J   $	��Top=�5^      $��25��6-   {�6N   �� *IsQuotaEnable+  5_      -   5        $��invoicedDate��5_   H   $
��Left=�6   $��
122,72,0,0q�64   $	��Top=�6\      SelectedDate 5`      �� *InvoicedDate+�� 5c      -	   5        $��textBox4��5c   F   $
��Left=�6   $��122,104,0,7q�61   $	��Top=�6V   ��5d      �� *DeliveryTerm+�� 5e      -
   5        $��paymentMean��5e   G   $
��Left=�6   $��394,104,0,7q�62   $	��Top=�6Z    �� DisplayMemberPath$	 Key��5f   ;    �� SelectedValuePath$ Value��6S   ��6   �� *PaymentMean+ �� SelectedValue 5g      �� *SelectPaymentMeanId+{�6E   �� *IsPaymentMeansEnable+�� 5h      -   5        $��button2��5h   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5i      $��45��6-   $��1��68   ��5h        $! Client.Properties.Resources��$ AddWithSymbol��{�5i   Z   �� *IsLCAddEnable+�� 5j      -   5        $��button3��5j   �   $��3��6^   $��23��6k   $
��Left=�6w   $��	122,2,0,0q�6�   $	��Top=�5k      $��45��6-   ��5j        $! Client.Properties.Resources��$ AddWithSymbol��{�5k   M   �� *IsDeliveryAddEnable+&    Utility.Controls.CurrencyTextBox  5l      -   5        $��currencyTextBox1��5m      $��5��5l   !   $��23��6.   $
��Left=�6:   $��122,130,0,7q�6U   $	��Top=�5m   &   $	��120��6>      Text 6J   �� *Money+ �� UpdateSourceTrigger$ PropertyChanged=�{�6�   �� *IsAmountEnable+6�   �� 5n      -   5        $��textBox9��5n   ^   $��8��6   $	��100��6#   $
��Left=�60   $��	122,2,0,0q�6K   $	��Top=�5o      $	��392��6.    �� TextWrapping$
 Wrap=�6R   ��6:   �� *Remark+6R   �� 5p      -   5        $��button4��5q      $��8��5p   U   $��25��6b   $
��Left=�6n   $��210,130,0,0q�6�   $	��Top=�5q   $   $��60��6<   ��5p        $! Client.Properties.Resources��$
 Save��5q   G   �� 5r      -   5        $��button5��5s      $��8��5r   W   $��25��6d   $
��Left=�6p   $��305,130,0,0q�6�   $	��Top=�5s   $   $��60��6<   ��5r        $! Client.Properties.Resources��$ Cancel��5s   G   �� 5v      -   5        $��lbTitle��5w   L   $��32��5v   J   $
��Left=�6V   $��6,6,0,0q�6q   $
��auto��6�   $	��Top=�5w      $
��Bold"�6,   $��16(�6>   ��5v        *&$PurchaseCommercialInvoiceProvisional+5w   L   �� 5x      -   5        $��label1��5x   �   $
��Left=�6]   $��6,38,0,0q�6x   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ CommInvoiceNo��6�   �� 5y      -   5        $��label2��5y   �   $
��Left=�6[   $��6,70,0,0q�6v   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ InvoiceDate��6�   �� 5z      -   5        $��label3��5z   �   $
��Left=�6W   $��
278,38,0,0q�6r   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ QuotaNo��6�   �� 5{      -   5        $��textBox2��5{   E   $
��Left=�6   $��
394,40,0,0q�61   $	��Top=�6U   {�.  ��5|      �� *	QuotaNo+6/   �� 5}      -   5        $��
lbSupplier��5}   �   $
��Left=�6X   $��
278,70,0,0q�6s   $	��Top=�5~      ��5}        $! Client.Properties.Resources��$ Supplier��5~      �� 5      -   5        $��textBox3��5   E   $
��Left=�6   $��
394,72,0,0q�61   $	��Top=�6U    �� 
IsReadOnly . ��5�      �� *SupplierName+64   �� 5�      -   5        $��label5��5�   �   $
��Left=�6X   $��	6,102,0,0q�6s   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ ShipTerm��6�   �� 5�      -   5        $��label6��5�   �   $
��Left=�6[   $��278,102,0,0q�6v   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ PaymentMean��6�   &   System.Windows.Controls.DataGrid  5�      -   5        $��	dataGrid1��5�   /      AutoGenerateColumns .  $
��auto��5�   3   $
��Left=�6A   $��
122,34,0,7q�6\   $	��Top=�5�   @   $
��auto��6X      CanUserAddRows .     
IsReadOnly . $��1��5�      ��5�      ��    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header 6)     $! Client.Properties.Resources��$ LoCNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6i   �� *LetterOfCredit.LCNo+  5�       6)     $! Client.Properties.Resources��$ 	LoCAmount�� 6m   �� *LetterOfCredit.IssueAmount+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z   5�       6)     $! Client.Properties.Resources��$ LoCCurrency�� 6o   �� *LetterOfCredit.Currency.Name+  5�       6)     $! Client.Properties.Resources��$ 
LCInterest�� 6n   �� *LetterOfCredit.Interest+# Z   5�       6)     $! Client.Properties.Resources��$ LCPresentAmount�� 6r   �� *LetterOfCredit.PresentAmount+# Z   5�      $ 分配金额��6)    67   �� *AllocationAmount+# Z 4  .System.Windows.Controls.DataGridTemplateColumn  5�         CellTemplate# [ 6q    6-     $! Client.Properties.Resources��$ 	Operation��6q   5�        5�      -   5        $��	dataGrid2��5�   /    .  $
��auto��5�   3   $
��Left=�6A   $��
122,34,0,7q�6\   $	��Top=�5�   @   $
��auto��6X    .   . $��3��6�   ��6   ��  5�        5�       6)     $! Client.Properties.Resources��$
 BLNo�� 6h   �� *
DeliveryNo+  5�       6)     $! Client.Properties.Resources��$ IssuingDate�� 5�   )   �� *	IssueDate+$ {0:yyyy-MM-dd}��  5�       6)     $! Client.Properties.Resources��$ 	Commodity�� 6m   �� *,*DeliveryLines/CommodityType.Commodity.Name+  5�       6)     $! Client.Properties.Resources��$ Brand�� 6i   �� *TotalBrands+  5�       6)     $! Client.Properties.Resources��$ 	NetWeight�� 6m   �� *TotalNetWeight+  
  STR_QUANTITY# Z    5�       6)     $! Client.Properties.Resources��$ GrossWeight�� 6o   �� *TotalGrossWeight+# Z    5�      # [ 6q    6-     $! Client.Properties.Resources��$ 	Operation��6q   5�      �� 5�      -   5        $��label7��5�   �   $��5��6Y   $
��Left=�6f   $��6,0,0,0q�6�   $	��Top=�5�      ��5�        $! Client.Properties.Resources��$ 	NetWeight��5�      �� 5�      -   5        $��textBox5��5�   Q   $��5��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   {�.  ��5�   +   �� *
NetWeights+# Z  6�   �� 5�      -   5        $��label8��5�   �   $
��Left=�6[   $��	278,0,0,0q�6v   $	��Top=�6�   $��5��5�      ��5�        $! Client.Properties.Resources��$ GrossWeight��5�      �� 5�      -   5        $��textBox6��5�   P   $��23��6   $
��Left=�6"   $��	394,2,0,0q�6=   $	��Top=�6`   $	��120��5�   +   $��5��67   {�.  ��6D   �� *GrossWeight+# Z  6�   �� 5�      -    5        $��label9��5�   ^   $��结算金额��6   $��5��6#   $
��Left=�60   $��	6,128,0,0q�6K   $	��Top=�5�      �� 5�      -!   5        $��label10��5�   �   $
��Left=�6_   $��
278,32,0,0q�6z   $	��Top=�6�   $��5��5�      ��5�        $! Client.Properties.Resources��$ PricingCurrency��5�      �� 5�      -"   5        $��textBox7��5�   Q   $��23��6   $
��Left=�6"   $��
394,34,0,0q�6=   $	��Top=�6a   $��5��5�      {�.  ��6#   �� *
Currency+6=   �� 5�      -#   5        $��label11��5�   (   $��Right=�5�   Z   $
��Left=�6}   $��
278,96,0,0q�5�      $	��Top=�67   $��5��6O   ��5�        $! Client.Properties.Resources��$ 
LCInterest��5�   O   �� 5�      -$   5        $��textBox8��5�   E   $
��Left=�6   $��
394,98,0,0q�61   $	��Top=�6U   $��5��6m   {�.  ��5�      �� *
Interest+# Z 6e   �� 5�      -%   5        $��label12��5�   i   $��
278,64,0,0q�6U   $	��Top=�6x   $��5��6�   $
��Left=�5�      
���<����5�        $! Client.Properties.Resources��$ Price��5�   /     5�      -&   5        $��currencyTextBox2��5�   \   $��23��6!   $
��Left=�6-   $��
394,66,0,0q�6H   $	��Top=�5�      $	��120��6&   $��5��62    6?   �� *Price+$ PropertyChanged=�{�6{   �� *IsPriceEnable+�� 5�      -'   5        $��label13��5�   �   $��8��6X   $
��Left=�6e   $��6,0,0,0q�6�   $	��Top=�5�      ��5�        $! Client.Properties.Resources��$ Comments��5�      �� 5�      -(   5        $��label4��5�   �   $��5��6^   $
��Left=�6k   $��6,32,0,0q�6�   $	��Top=�5�      
���<����5�        $! Client.Properties.Resources��$ SettleCurrency��5�   ,   �� 5�      -)   5        $��	comboBox1��5�   S   $��5��6   $
��Left=�6$   $��
122,34,0,0q�6?   $	��Top=�5�      $
 Name��6R   $ Id��6k   ��6/   �� *
Currencies+ 5�      �� *SelectCurrencyId+{�6B   �� *IsSettlementCurrencyEnable+6s   �� 5�      -*   5        $��label14��5�   �   $��5��6\   $
��Left=�6i   $��6,64,0,0q�6�   $	��Top=�5�      ��5�        $! Client.Properties.Resources��$ ExchangeRate��5�        5�      -+   5        $��currencyTextBox3��5�      $��5��5�   !   $��23��6.   $
��Left=�6:   $��
122,66,0,0q�6U   $	��Top=�5�   &   $	��120��6>    6J   �� *SettlementRate+$ PropertyChanged=�{�6�   �� *IsExchangeRateEnable+�� 5�      -,   5        $��label15��5�   �   $��1��6^   $
��Left=�6k   $��6,0,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ LetterOfCredit��{�6�   �� *IsExchangeRateEnable+�� 5�      --   5        $��deliverieName��5�   M   $��3��6   $
��Left=�6!   $��6,0,0,0q�6<   $	��Top=�5�      �� 5�      -.   5        $��lblBankAccount��5�   �   $��5��6[   $
��Left=�6h   $��278,128,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ BankAccount��y�6�   �� *	IsVisible+�� 5�      -/   5        $��cbBankAccount��5�   T   $��5��6   $
��Left=�6$   $��394,130,0,7q�6?   $ AccountCode��6i   $ Id��5�   G   $	��Top=�6   ��5�   �   �� *BankAccountList+ 5�      �� *SelectedBankAccountID+y�6^   �� *	IsVisible+6   �� 5�      -0   5        $��button1��5�   j   $��+新增��6   $��7��6#   $��23��60   $
��Left=�6<   $��	122,2,0,0q�6W   $	��Top=�6y   $��45��6�   6�     5�      -1   5        $��dataGridAttachment��5�   X    .   .  $
��Left=�6    . $��
122,34,0,7q�6D   $
��Auto��6r   $��7��6   $
��auto��6�   $	��Top=�6�   ��5�   3   �� *Attachments+ 5�        5�       6)   �� *Name+ 6B     $! Client.Properties.Resources��$ AttachmentName��  5�      !   CanUserSort! .  # [ 6A    5�   -     $! Client.Properties.Resources��$ 	Operation��5�      �� 5�      -2   5        $��label16��5�   �   $��7��6Z   $��28��6g   $
��Left=�6s   $��6,0,0,0q�6�   $	��Top=�6�   $	��110��6�   ��6     $! Client.Properties.Resources��$ 
Attachment��6�   �� 5�      -3   5        $��label17��5�   Z   $��比例��6   $��28��6!   $
��Left=�6-   $��6,96,0,0q�6H   $	��Top=�6i   $	��110��6�   $��5��6�   �� 5�      -4   5        $��	textBox10��5�   Q   $��23��6   $
��Left=�6"   $��
122,98,0,0q�6=   $	��Top=�6�   $	��120��6�   $��5��6�   ��6b   �� *Ratio+$ PropertyChanged=�6�   �� 5�      -5   5        $��label18��5�   [   $��%��6   $��23��6    $
��Left=�6,   $��
240,96,0,0q�6G   $	��Top=�6j   $��20��6�   $��5��6�   �� 5�      -6   5        $��	checkBox1��5�   u   $*��$该批次已完成全部商业发票��6   $��6��6.   $��16��6;   $
��Left=�6G   $��	122,2,0,7q�6b   $	��Top=�6�   " d� 	IsChecked" 6�   �� *IsCIFinished+y�6�   �� *IsFinishedVisible+5�      5�      5�      