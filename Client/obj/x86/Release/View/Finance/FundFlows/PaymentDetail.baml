   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 1   +Client.View.Finance.FundFlows.PaymentDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$/  )Client.View.Finance.FundFlows.ResFundFlow�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ Payment�� � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%V  &	        '�� �     '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  $! Client.Properties.Resources��$ Payment���� #��[  $��6,38,0,0q�$	��Top=�$
��Left=�
���<����  $! Client.Properties.Resources��$ 	ReceiptBP���� $��
122,40,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$
��Left=�{�.  ���� *BPartnerName+�� -   $��button1��$	��...��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25��$��23��{��� *
IsBPEnable+�� #��[  $��
278,38,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ PaymentBPShort��
 � ToolTip
   $! Client.Properties.Resources��$ 	PaymentBP����  �� DisplayMemberPath$ 	ShortName��$
��Left=�$��
394,40,0,0q� �� SelectedValuePath$ Id��$	��Top=����� *InternalCustomers+ �� SelectedValue �� *ICId+{��� *IsInternalCustomerEnable+�� #��[  $��6,70,0,0q�$
��Left=�$	��Top=�
���<����  *PaymentDateShort+
   *PaymentDate+  $
��Left=�$��
122,72,0,0q�$	��Top=�   SelectedDate �� *	TradeDate+ � DataContext �� �� #��[  $��
278,70,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ Quota���� $��
394,72,0,0q�$
��Left=�$	��Top=�{�.  ���� *	QuotaNo+�� -   $��button3��$	��...��$
��Left=�$��
518,72,0,0q�$	��Top=�$��25��$��23���� #��[  $��	6,102,0,0q�$
��Left=�$	��Top=�
���<����  *PaymentAmountShort+
   *PaymentAmount+&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��122,104,0,0q�$	��Top=�$	��120��   IsPositiveNumber .    Text �� *Amount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z �� #��[  $��278,102,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ PaymentCurrencyShort��
   $! Client.Properties.Resources��$ PaymentCurrency���� -   $��txtPaymentCurrencyName��$
 Name��$
��Left=�$��394,104,0,0q�$ Id��$	��Top=����� *
Currencies+ �� *SelectedPaymentCurrencyId+�� #��[  $��	6,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ SettleCurrencyShort��
   $! Client.Properties.Resources��$ SettleCurrency���� -   $��currencyTextBox3��$
��Left=�$��122,136,0,0q�$	��Top=� �� 
IsReadOnly . 
   $! Client.Properties.Resources��$ SettleCurrency������ *SettlementCurrencyName+�� #��[  $��278,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ SettleRateShort��
   $! Client.Properties.Resources��$ 
SettleRate��  -   $��currencyTextBox2��$
��Left=�$��394,136,0,0q�$��23��$	��Top=�$	��120��
   $! Client.Properties.Resources��$ 
SettleRate�� �� *Rate+   STR_RATE# Z �� #��[  $��	6,166,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ FinancialAccountShort��
   $! Client.Properties.Resources��$ FinancialAccount���� $
��Left=�$��122,168,0,0q�$
	 Wrap=�$	��Top=�{�.  ���� *FinancialAccountName+�� -	   $��button4��$	��...��$
��Left=�$��246,168,0,0q�$	��Top=�$��25��$��23���� #��[  $��278,166,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ PaymentAccountShort��
   $! Client.Properties.Resources��$ PaymentAccount���� -
   $��cbCmmodityType��$��394,168,0,0q�$
��Left=�$	��Top=�$ Id��$ Description������ *BankAccounts+ �� *SelectedBankAccountId+�� $
��Left=�#��[  $��	6,230,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -   $��textBox6��$	��100��$
��Left=�$	��Top=�$	��392��$��122,232,0,0q� �� 
AcceptsTab .   �� AcceptsReturn . $
	 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=� �� 	MaxLength$	 255������ *Description+�� -   $��210,355,0,0q�$��23��$	��Top=�$
��Left=�$��60����  $! Client.Properties.Resources��$
 Save���� -   $
��Left=�$��305,355,0,0q�$	��Top=�$��60��$��23����  $! Client.Properties.Resources��$ Cancel���� $��383,355,0,0q�$��23��$
��Left=�$	��Top=�$��60��$y�Hidden=���  $! Client.Properties.Resources��$ SaveAsDraft���� -   $��label1��$��付款方式��#��[  $
��Left=�$��	6,198,0,0q�$	��Top=��� -   $��	comboBox1��$��23��$
��Left=�$ Id��$
 Name��$��122,200,0,0q�$	��Top=�$	��120������ *PaymentMeans+ �� *PaymentMeanId+�� -   $��	checkBox1��$!��该批次已完成收付款��$��16��$
��Left=�$��394,204,0,0q�$	��Top=� d� 	IsChecked �� *IsFundflowFinished+