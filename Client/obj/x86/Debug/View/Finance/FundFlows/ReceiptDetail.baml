   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      1   +Client.View.Finance.FundFlows.ReceiptDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$/  )Client.View.Finance.FundFlows.ResFundFlow��5       N� Title$ 收款明细��5       � Language 5   Z   5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5
       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%�  &	        '�� �     '�� m    '  �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5        � ��$	 120��6&   64   5!      5#      .��5%      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5&      .��5'   
   � -   5         �Name$ rootGrid��5'       � ColumnDefinitions 5(      �� 5)      $	��600 �6#   .+�5,      �� -   5        $��button1��5,   R   $	��...��6   $
��Left=�6#   $��
246,40,0,0q�6>   $	��Top=�6a   $��25��5-      $��23��6    {�6E   �� *
IsBPEnable+�� 5.      	 �� DisplayMemberPath$	 	ShortName��6   $
��Left=�65   $��
394,40,0,0q�5/      
 �� SelectedValuePath$
 Id��6J   $	��Top=�6a   ��5.   P   �� *InternalCustomers+ �� SelectedValue 5/   +   �� *ICId+{�6y   �� *IsInternalCustomerEnable+�� 50      -   5        $ ��txtReceiveblesCurrencyName��51   �   $
	 Name��50      $
��Left=�60   $��394,104,0,0q�51      $
 Id��6`   $	��Top=�6w   ��50   K   �� *
Currencies+ 51   ,   �� *SelectedPaymentCurrencyId+6�   �� 52      -   5        $��button4��52   S   $	��...��6   $
��Left=�6#   $��246,168,0,0q�6>   $	��Top=�6b   $��25��53      $��23��6    6,   �� 54      -   5        $��cbCmmodityType��56   G   $��394,168,0,0q�54      $
��Left=�6,   $	��Top=�6G   $
 Id��55   <   $	 Description��6S   ��6   �� *BankAccounts+ 56      �� *SelectedBankAccountId+6G     59      $
��Left=�6   $��
122,72,0,0q�64   $	��Top=�5:         SelectedDate 59   H   �� *	TradeDate+5:      �� 5;      -   5        $��button3��5;   R   $	��...��6   $
��Left=�6#   $��
518,72,0,0q�6>   $	��Top=�6a   $��25��5<      $��23��6    6,   &    Utility.Controls.CurrencyTextBox  5=      -   5        $��currencyTextBox1��5>   !   $��23��5=   !   $
��Left=�6-   $��122,104,0,0q�6H   $	��Top=�5>   9   $	��120��6Q      IsPositiveNumber .    Text 6]   �� *Amount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z 6�     5@      -   5        $��currencyTextBox2��5A   !   $��23��5@   !   $
��Left=�6-   $��394,136,0,0q�6H   $	��Top=�5A   9   $	��120��6Q    6]   �� *Rate+   STR_RATE# Z �� 5B      -	   5        $��textBox6��5B   S   $	��100��6   $
��Left=�6#   $��122,232,0,0q�6>   $	��Top=�5C      $	��392��6.    �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6b   " �� VerticalScrollBarVisibility$
 Auto=�5D       �� 	MaxLength$	 255��6V   ��69   �� *Description+6V   �� 5E      -
   5        $��210,355,0,0q�5E   U   $	��Top=�6j   $
��Left=�5F      $��60��60   $��23��6;   ��5E           ResxName$! Client.Properties.Resources��
   Key$
 Save��5F   G   �� 5G      $��440,355,100,0q�6\   $��Center=�6s   $	��Top=�5H      $��60��6-   $��23��68   $y�Hidden=�6D   ��5G        $! Client.Properties.Resources��$ SaveAsDraft��5H   D   �� 5I      -   5        $
��Left=�5I   W   $��302,356,0,0q�6r   $	��Top=�6�   $��60��6�   $��23��5J      ��5I        $! Client.Properties.Resources��$ Cancel��5J   !   �� 5M      -   5        $��lbTitle��5M   -   $
��Left=�6<   $��6,6,0,0q�6W   $��32��5N      $	��Top=�6    $
��Bold"�68   $��16(�6J   ��5M        *	Receipt+5N   J   �� 5O      #��[  6Y   $��6,38,0,0q�6}   $	��Top=�5P      $
��Left=�6,   
���<����5O        $! Client.Properties.Resources��$ 	PaymentBP��5P   G   �� 5Q      $��
122,40,0,0q�6   $
 Wrap=�6*   $	��Top=�6>   $
��Left=�5R      {�.  ��61   �� *BPartnerName+6O   �� 5T      #��[  6Y   $��
278,38,0,0q�6}   $
��Left=�5U      $	��Top=�6/   
���<����5T        $! Client.Properties.Resources��$ 	ReceiptBP��5U   G   �� 5W      #��[  61   $��6,70,0,0q�6U   $
��Left=�5X      $	��Top=�6/   
���<����5W        *ReceiptDate+5X   G   �� 5Z      #��[  6U   $��
278,70,0,0q�6y   $
��Left=�5[      $	��Top=�6/   ��5Z        $! Client.Properties.Resources��$ Quota��5[   /   �� 5\      $��
394,72,0,0q�6   $
��Left=�6*   $	��Top=�6E   {�.  ��5]      �� *	QuotaNo+6/   �� 5_      #��[  63   $��	6,102,0,0q�6W   $
��Left=�5`      $	��Top=�6/   
���<����5_        *ReceiptAmount+5`   G   �� 5b      #��[  65   $��278,102,0,0q�6Y   $
��Left=�5c      $	��Top=�6/   
���<����5b        *ReceiptCurrency+5c   G   �� 5d      $
��Left=�6    �� 
IsReadOnly . $��122,136,0,0q�6C   $
 Wrap=�5e   >   $	��Top=�6R   ��6   �� *SettlementCurrencyName+6R   �� 5f      #��[  6^   $��	6,134,0,0q�6�   $
��Left=�5g      $	��Top=�6/   ��5f        $! Client.Properties.Resources��$ SettleCurrency��5g   /   �� 5i      #��[  6Z   $��278,134,0,0q�6~   $
��Left=�5j      $	��Top=�6/   ��5i        $! Client.Properties.Resources��$ 
SettleRate��5j   /   �� 5l      #��[  6`   $��	6,166,0,0q�6�   $
��Left=�5m      $	��Top=�6/   
���<����5l        $! Client.Properties.Resources��$ FinancialAccount��5m   G   �� 5n      $
��Left=�6   $��122,168,0,0q�61   $
 Wrap=�5o      $	��Top=�6*   {�.  ��5n   F   �� *FinancialAccountName+5o   B   �� 5q      #��[  6^   $��278,166,0,0q�6�   $
��Left=�5r      $	��Top=�6/   
���<����5q        $! Client.Properties.Resources��$ ReceiptAccount��5r   G   �� 5t      $
��Left=�6X   #��[  6s   $��	6,230,0,0q�6�   $	��Top=�5u      ��5t        $! Client.Properties.Resources��$ Comments��5u      �� 5w      -   5        $��	comboBox1��5w   S   $��23��6   $
��Left=�6#   $��122,200,0,0q�6>   $	��Top=�6d   $	��120��6|   $
 Id��6�   $
	 Name��6�   ��6�   �� *PaymentMeans+ 6�   �� *PaymentMeanId+�� 5x      -   5        $��label2��5x   ]   $��付款方式��6   $��28��6#   $
��Left=�6/   $��	6,198,0,0q�6J   $	��Top=�6k   #��[  6�   �� 5y      -   5        $��	checkBox1��5y   g   $!��该批次已完成收付款��6   $��16��6+   $
��Left=�67   $��394,204,0,0q�6R   $	��Top=�6x    d� 	IsChecked 6�   �� *IsFundflowFinished+5z      5{      5|      