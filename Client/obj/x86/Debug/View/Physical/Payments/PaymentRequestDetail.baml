   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6K   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      8   2Client.View.Physical.Payments.PaymentRequestDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      6
Convertersclr-namespace:Client.Converters     6K   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   J        ResxName$! Client.Properties.Resources��
   Key$ PaymentRequest�� � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker.  (Client.Converters.ApproveStatusConverter  ApproveStatusConverter  DeliveryDelete  DeliveryActions	 �� DataType
 �� Orientation��%�  &	        '�� �     '�� m    '  �    &	 [    &	 n    &	 �    7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5!   
   "  6   .�5"      ��  � ��$ 23��6'   64   �� 5#       � ��$	 120��6&   64   5$        5&   
   6,   �� 5(   
   61   �� 5)   
   $	 DBEntity:Delivery��6/   .R�5*      �� $
 
Horizontal=�6   .+�5+      �� $��btDeliveryDelete��6   8��  ��61     $! Client.Properties.Resources��$ Delete����5,      �� *Id+6;   5-      5.      5/       J� CommandBindings 51      )  #System.Windows.Input.CommandBinding  52   
   -   5           Command# [ 52      53   =   .��56      �� $
��Auto=�6   $
��Auto=�68   .��58   
   � -   5         �Name$ rootGrid��58       � RowDefinitions 59      �� 5:      $
��Auto �6    �� 5;      $
��auto �6    �� 5<      $
��auto �6    �� 5=      $	��55* �6    .+�5@        -   5        $��datePicker1��5@   H   $
��Left=�6   $��
394,40,0,0q�64   $	��Top=�6[      SelectedDate 5A      �� *RequestDate+&    Utility.Controls.CurrencyTextBox  5B      -   5        $��currencyTextBox1��5B   �   $��23��6M   $
��Left=�6Y   $��122,104,0,0q�6t   $	��Top=�5C   !   $	��120��69   {�5B   !   �� *IsRequestAmountEnable+   Text 5C   E   �� *RequestAmount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z �� 5D      -   5        $��	comboBox3��5D   n   $
��Left=�6>   $��394,104,0,0q�6Y   $	��Top=�6    �� SelectedValuePath$ Id��5E   9    �� DisplayMemberPath$
 Name��6P   {�5D      �� *IsCurrencyEnable+��5E      �� *	Currencys+ �� SelectedValue 6i   �� *
CurrencyId+5F      �� 5G      -   5        $��	comboBox1��5G   k   $
��Left=�6;   $��122,168,0,0q�6V   $	��Top=�6|   $ Id��5H   @   $ 	ShortName��6W   {�5G      �� *IsBPPayEnable+��5H      �� *BusinessPartners+ 5I      �� *	PayBPId+69   �� 5J      -   5        $��	comboBox4��5J   p   $
��Left=�6@   $��394,168,0,0q�6[   $	��Top=�6�   $ Id��5K   ?   $ Description��6V   {�5J      �� *IsAccountPayEnable+��5K      �� *PayBankAccounts+ 5L      �� *PayBankAccountId+�� 5M      -   5        $��button2��5M   �   $	��...��6=   $��23��6K   $
��Left=�6W   $��246,200,0,0q�6r   $	��Top=�5N      $��25��6-   {�5M      �� *IsBPReceiveEnable+5N   8   �� 5O      -	   5        $��	comboBox5��5O   t   $
��Left=�6D   $��394,200,0,0q�6_   $	��Top=�6�   $ Id��5P   C   $ Description��6Z   {�5O      �� *IsAccountReceiveEnable+��5P      �� *ReceiveBankAccounts+ 5Q      �� *ReceiveBankAccountId+�� 5R      -
   5        $��	comboBox6��5R   r   $
��Left=�6B   $��122,232,0,0q�6]   $ Id��6�   $
 Name��6�   $��23��5S   u   $	��Top=�6�   {�5R      �� *IsPaymentUsageEnable+��6�   �� *PaymentUsages+ 5S      �� *PaymentUsageId+6�   �� 5T      -   5        $��	comboBox2��5T   q   $
��Left=�6A   $��394,232,0,0q�6\   $ Id��6�   $
 Name��6�   $��23��5U   ?   $	��Top=�6K   {�5T      �� *IsPaymentMeanEnable+��6�   �� *PaymentMeans+ 5U      �� *PaymentMeanId+6K   �� 5V      -   5        $��button1��5V   �   $	��...��6<   $��23��6J   $
��Left=�6V   $��
246,40,0,0q�6q   $	��Top=�5W      $��25��6-   {�5V      �� *IsQuotaBtnEnable+5W   8   �� 5X      -   5        $��textBox7��5X   Q   $	��100��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   $	��392��5Y      $��3��6;   ��6"   �� *	Comment+6;   �� 5Z      -   5        $��button3��5Z   �   $��23��6U   $
��Left=�6a   $��210,130,0,0q�6|   $	��Top=�5[      $��60��6-   $��3��6E   ��5Z        $! Client.Properties.Resources��$
 Save��5[   E   �� 5\      -   5        $��button5��5\   �   $��23��6\   $
��Left=�6h   $��411,130,0,0q�6�   $	��Top=�5]      $��60��6-   $y�Hidden=�6J   $��3��6^   ��5\        $! Client.Properties.Resources��$ SaveAsDraft��5]   ^   �� 5^      -   5        $��button4��5^   �   $��23��6W   $
��Left=�6c   $��305,130,0,0q�6~   $	��Top=�5_      $��60��6-   $��3��6G   ��5^        $! Client.Properties.Resources��$ Cancel��5_   G   �� 5`      -   5        $��lbTitle��5a       #��[  5`      $��6,6,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��32��5a      $	��Top=�6/   $
��Left=�6G   $
��auto��6b   ��5`   8     $! Client.Properties.Resources��$ PaymentRequest��5a   b   �� 5b      -   5        $��label2��5c      #��[  5b      $
��Left=�6y   $��6,38,0,0q�6�   $	��Top=�5c   "   ��5b   8     $! Client.Properties.Resources��$ Quota��5c   "   �� 5d      -   5        $��label3��5e      #��[  5d      $
��Left=�6z   $��278,260,0,0q�6�   $	��Top=�5e   "   $y�	Collapsed=�6:   ��5d   8     $! Client.Properties.Resources��$ Status��5e   :   �� 5f      -   5        $��label4��5g      #��[  5f      $
��Left=�6�   $��	6,102,0,0q�6�   $	��Top=�5g   "   
���<����5f   8     $! Client.Properties.Resources��$ AppliedAmount��5g   :   �� 5h      -   5        $��label5��5i      #��[  5h      $
��Left=�6~   $��	6,134,0,0q�6�   $	��Top=�5i   "   ��5h   8     $! Client.Properties.Resources��$ 
PaidAmount��5i   "   �� 5j      -   5        $��label6��5k      #��[  5j      $
��Left=�6}   $��	6,166,0,0q�6�   $	��Top=�5k   "   
���<����5j   8     $! Client.Properties.Resources��$ 	PaymentBP��5k   :   �� 5l      -   5        $��label7��5m      #��[  5l      $
��Left=�6}   $��	6,198,0,0q�6�   $	��Top=�5m   "   
���<����5l   8     $! Client.Properties.Resources��$ 	ReceiptBP��5m   :   �� 5n      -   5        $��label8��5o      #��[  5n      $
��Left=�6   $��278,230,0,0q�6�   $	��Top=�5o   "   
���<����5n   8     $! Client.Properties.Resources��$ PaymentMean��5o   :   �� 5p      -   5        $��label9��5q      #��[  5p      $
��Left=�6}   $��
278,38,0,0q�6�   $	��Top=�5q   "   
���<����5p   8     $! Client.Properties.Resources��$ 	ApplyDate��5q   :   �� 5r      -   5        $��label10��5s      #��[  5r      $
��Left=�6�   $��
278,70,0,0q�6�   $	��Top=�5s   #   ��5r   8     $! Client.Properties.Resources��$ ApprovalStatus��5s   #   �� 5t      -   5        $��label11��5u      #��[  5t      $
��Left=�6�   $��278,102,0,0q�6�   $	��Top=�5u   #   
���<����5t   8     $! Client.Properties.Resources��$ PaymentCurrency��5u   ;   �� 5v      -   5        $��label12��5w      #��[  5v      $
��Left=�6�   $��278,166,0,0q�6�   $	��Top=�5w   #   ��5v   8     $! Client.Properties.Resources��$ PaymentAccount��5w   #   �� 5x      -   5        $��label13��5y      #��[  5x      $
��Left=�6�   $��278,198,0,0q�6�   $	��Top=�5y   #   ��5x   8     $! Client.Properties.Resources��$ ReceiptAccount��5y   #   �� 5z      -   5        $��label14��5{      #��[  5z      $
��Left=�6�   $��	6,230,0,0q�6�   $	��Top=�5{   #   
���<����5z   8     $! Client.Properties.Resources��$ PaymentUsage��5{   ;   �� 5|      -   5        $��textBox1��5|   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   {�.  ��5}      �� *	QuotaNo+6/   �� 5~      -    5        $��textBox2��5~   F   $
��Left=�6   $��394,262,0,0q�61   $	��Top=�6V    �� 
IsReadOnly . $y�	Collapsed=�5   (   �� 5�      -!   5        $��textBox5��5�   F   $
��Left=�6   $��122,200,0,0q�61   $	��Top=�6V   {�.  ��5�      �� *	ShortName+61   �� 5�      -"   5        $��textBox6��5�   *   $��
394,72,0,0q�6   $	��Top=�6:    . $
��Left=�5�   {   $	��120��6�   ��6(   �� *PRApproveStatus+ �� 	Converter# [ 6�   �� 5�      -#   5        $��label15��5�      #��[  5�      $
��Left=�6|   $��6,0,0,0q�6�   $	��Top=�5�   #   $��3��6;   ��5�   8     $! Client.Properties.Resources��$ Comments��5�   ;     5�      -$   5        $��currencyTextBox2��5�   ]   $��23��6!   $
��Left=�6-   $��122,136,0,0q�6H   $	��Top=�5�   !   $	��120��69   {�.   6E   �� *
PaidAmount+# Z 6�   �� 5�      -%   5        $��button6��5�   �   $��23��6^   $
��Left=�6j   $��	122,5,0,0q�6�   $	��Top=�5�      $��45��6-   $��1��6Q   $y�	Collapsed=�6^   ��5�        $! Client.Properties.Resources��$ AddWithSymbol��5�   ^   $   Utility.Controls.PagingControl  5�      -&   5        $��pagingControl1��5�   2   $��	122,0,0,0q�6   $	��Top=�6H   $
��auto��6`   $
��Left=�5�      $��2��6:   $y�	Collapsed=�6G   &	   System.Windows.Controls.DataGrid	  5�      -'   5        $��deliverydataGrid��5�       	  AutoGenerateColumns .  $
��Auto��5�   3   $
��Left=�6A   $��
122,32,0,0q�6\   $	��Top=�5�   /   $
��Auto��6G    	  
IsReadOnly . $��2��6f   $y�	Collapsed=�6s    	  Columns 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6h      CanUserSort .    Header 6)     $! Client.Properties.Resources��$
 BLNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   )   �� *
DeliveryNo+6J   
  5�      $
 Auto 6q    .  6)     $! Client.Properties.Resources��$ CommodityType�� 5�   )   �� *Quota.CommodityType.Name+6X   
  5�      $
 Auto 6i    .  6)     $! Client.Properties.Resources��$ Brand�� 6�   �� *TotalBrands+6�   
  5�      $
 Auto 6l    .  6)     $! Client.Properties.Resources��$ Quantity�� 6�   �� *
TotalQty+   STR_QUANTITY# Z 6�   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $
 Auto 6q    .      CellTemplate#  [ 5�   -    5�   -     $! Client.Properties.Resources��$ 	Operation��5�   _   5�      �� 5�      -(   5        $��label16��5�   %   #��[  5�      $��1��6|   $
��Left=�6�   $��6,3,0,0q�5�      $	��Top=�64   $��2��6L   $y�	Collapsed=�6]   ��5�   8     $! Client.Properties.Resources��$ BLDetail��5�   ]   �� 5�      -)   5        $��	checkBox1��5�   g   $!��该批次完成付款申请��6   $��16��6+   $
��Left=�67   $��394,140,0,0q�6R   $	��Top=�6x   ! d� 	IsChecked! 6�   �� *IsPaymentRequestFinished+�� 5�      -*   5        $��label1��5�   �   $��	中转行��6   #��[  6"   $��28��6F   $
��Left=�6R   $��	6,262,0,0q�6m   $	��Top=�6�   �� 5�      -+   5        $��	comboBox7��5�   ~   $��23��6B   $
��Left=�6N   $��122,264,0,7q�6i   $	��Top=�6�   $	��120��6�   $ Id��6�   $
 Name��6�   {�6   �� *IsTransferBankEnable+��6�   �� *IBanks+ 5�      �� *SelectedBankValue+�� 5�      -,   5        $��button7��5�   �   $	��...��69   $��23��6G   $
��Left=�6S   $��
246,72,0,0q�6n   $	��Top=�6�   $��25��6�   {�6   �� *IsCIBtnEnable+6�   �� 5�      --   5        $��label17��5�   P   $��商业发票��6   $
��Left=�6#   $��6,70,0,0q�6>   #��[  6_   $	��Top=�6�   �� 5�      -.   5        $��textBox3��5�   W   $
��Left=�6   {�.  $��
122,72,0,0q�6C   $	��Top=�6�   ��6g   �� *	InvoiceNo+6�   5�      5�      5�      