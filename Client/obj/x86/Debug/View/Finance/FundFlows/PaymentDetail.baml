   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5	   s   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      1   +Client.View.Finance.FundFlows.PaymentDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5   	   >my/clr-namespace:Utility.Controls;assembly=Utility     5	   s   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$/  )Client.View.Finance.FundFlows.ResFundFlow��5   	    � Language 5   	   5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5	   	        ResxName$! Client.Properties.Resources��
   Key$ Payment�� � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%�  &	        '�� �     '�� m    '  �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5    
   "  6   .�5!      ��  � ��$ 23��6'   64   �� 5"       � ��$	 120��6&   64   5#      5$      .��5&      �� $
��Auto=�6   $
��Auto=�68   .��5'   
   � -   5        $��rootGrid��5'      .+�5(      �� -   5        $��lbTitle��5(   W   $
��Left=�6f   $��6,6,0,0q�6�   $��32��6�   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     $! Client.Properties.Resources��$ Payment��6�   �� 5)      #��[  6Y   $��6,38,0,0q�6}   $	��Top=�6�   $
��Left=�6�   
���<����6     $! Client.Properties.Resources��$ 	ReceiptBP��6�   �� 5*      $��
122,40,0,0q�6   	 �� TextWrapping$
	 Wrap=�6*   $	��Top=�6>   $
��Left=�6V   {�.  ��6q   �� *BPartnerName+6�   �� 5+      -   5        $��button1��5+   R   $	��...��6   $
��Left=�6#   $��
246,40,0,0q�6>   $	��Top=�6a   $��25��6y   $��23��6�   {�6�   �� *
IsBPEnable+�� 5,      #��[  6�   $��
278,38,0,0q�6�   $
��Left=�6�   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ PaymentBPShort��
 � ToolTip
 6^     $! Client.Properties.Resources��$ 	PaymentBP��6  �� 5-       �� DisplayMemberPath$ 	ShortName��6   $
��Left=�65   $��
394,40,0,0q�6z    �� SelectedValuePath$ Id��6�   $	��Top=�6�   ��6P   �� *InternalCustomers+ �� SelectedValue 6�   �� *ICId+{�6�   �� *IsInternalCustomerEnable+�� 5.      #��[  6S   $��6,70,0,0q�6w   $
��Left=�6�   $	��Top=�6�   
���<����6     *PaymentDateShort+
 66     *PaymentDate+6�     5/      $
��Left=�6   $��
122,72,0,0q�64   $	��Top=�6k      SelectedDate 6H   �� *	TradeDate+ � DataContext 6�   �� �� 50      #��[  6U   $��
278,70,0,0q�6y   $
��Left=�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Quota��6�   �� 51      $��
394,72,0,0q�6   $
��Left=�6*   $	��Top=�6E   {�.  ��6]   �� *	QuotaNo+6v   �� 52      -   5        $��button3��52   R   $	��...��6   $
��Left=�6#   $��
518,72,0,0q�6>   $	��Top=�6a   $��25��6y   $��23��6�   6�   �� 53      #��[  6W   $��	6,102,0,0q�6{   $
��Left=�6�   $	��Top=�6�   
���<����6     *PaymentAmountShort+
 68     *PaymentAmount+6�   &    Utility.Controls.CurrencyTextBox  54      -   5        $��currencyTextBox1��54   ]   $��23��6!   $
��Left=�6-   $��122,104,0,0q�6H   $	��Top=�6u   $	��120��6�      IsPositiveNumber .    Text 6�   �� *Amount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z 6�   �� 55      #��[  6�   $��278,102,0,0q�6�   $
��Left=�6�   $	��Top=�6  
���<����6     $! Client.Properties.Resources��$ PaymentCurrencyShort��
 6d     $! Client.Properties.Resources��$ PaymentCurrency��6  �� 56      -   5        $��txtPaymentCurrencyName��56   �   $
 Name��6   $
��Left=�60   $��394,104,0,0q�6n   $ Id��6�   $	��Top=�6�   ��6K   �� *
Currencies+ 6�   �� *SelectedPaymentCurrencyId+6�   �� 57      #��[  6�   $��	6,134,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ SettleCurrencyShort��
 6c     $! Client.Properties.Resources��$ SettleCurrency��6�   �� 58      -   5        $��currencyTextBox3��58   F   $
��Left=�6   $��122,136,0,0q�61   $	��Top=�6�    �� 
IsReadOnly . 
 6^     $! Client.Properties.Resources��$ SettleCurrency����6�   �� *SettlementCurrencyName+6�   �� 59      #��[  6�   $��278,134,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ SettleRateShort��
 6_     $! Client.Properties.Resources��$ 
SettleRate��6�     5:      -   5        $��currencyTextBox2��5:   �   $
��Left=�6!   $��394,136,0,0q�6<   $��23��6Q   $	��Top=�6	  $	��120��6!  
 6]     $! Client.Properties.Resources��$ 
SettleRate�� 6�   �� *Rate+   STR_RATE# Z 6!  �� 5;      #��[  6�   $��	6,166,0,0q�6�   $
��Left=�6�   $	��Top=�6  
���<����6     $! Client.Properties.Resources��$ FinancialAccountShort��
 6e     $! Client.Properties.Resources��$ FinancialAccount��6  �� 5<      $
��Left=�6   $��122,168,0,0q�61   $
	 Wrap=�6l   $	��Top=�6�   {�.  ��6F   �� *FinancialAccountName+6�   �� 5=      -	   5        $��button4��5=   S   $	��...��6   $
��Left=�6#   $��246,168,0,0q�6>   $	��Top=�6b   $��25��6z   $��23��6�   6�   �� 5>      #��[  6�   $��278,166,0,0q�6�   $
��Left=�6�   $	��Top=�6  
���<����6     $! Client.Properties.Resources��$ PaymentAccountShort��
 6c     $! Client.Properties.Resources��$ PaymentAccount��6  �� 5?      -
   5        $��cbCmmodityType��5?   �   $��394,168,0,0q�6   $
��Left=�6,   $	��Top=�6G   $ Id��6�   $ Description��6�   ��6_   �� *BankAccounts+ 6�   �� *SelectedBankAccountId+6�   �� 5@      $
��Left=�6X   #��[  6s   $��	6,230,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Comments��6�   �� 5A      -   5        $��textBox6��5A   >   $	��100��6   $
��Left=�6#   $	��Top=�6N   $	��392��6f   $��122,232,0,0q�6r    �� 
AcceptsTab .   �� AcceptsReturn . $
	 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�    �� 	MaxLength$	 255��6  ��6�   �� *Description+6  �� 5B      -   5        $��210,355,0,0q�5B   U   $��23��6j   $	��Top=�6v   $
��Left=�6�   $��60��6�   ��6     $! Client.Properties.Resources��$
 Save��6�   �� 5C      -   5        $
��Left=�5C   W   $��305,355,0,0q�6r   $	��Top=�6�   $��60��6�   $��23��6�   ��6     $! Client.Properties.Resources��$ Cancel��6�   �� 5D      $��383,355,0,0q�6\   $��23��6q   $
��Left=�6}   $	��Top=�6�   $��60��6�   $y�Hidden=�6�   ��6     $! Client.Properties.Resources��$ SaveAsDraft��6�   �� 5E      -   5        $��label1��5E   u   $��付款方式��6   #��[  6#   $
��Left=�6G   $��	6,198,0,0q�6b   $	��Top=�6�   �� 5F      -   5        $��	comboBox1��5F   �   $��23��6   $
��Left=�6#   $ Id��6c   $
 Name��6z   $��122,200,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6>   �� *PaymentMeans+ 6�   �� *PaymentMeanId+6�   �� 5G      -   5        $��	checkBox1��5G   g   $!��该批次已完成收付款��6   $��16��6+   $
��Left=�67   $��394,204,0,0q�6R   $	��Top=�6x    d� 	IsChecked 6�   �� *IsFundflowFinished+5H      5I      5J      