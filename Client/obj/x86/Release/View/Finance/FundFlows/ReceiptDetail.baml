   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 1   +Client.View.Finance.FundFlows.ReceiptDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$/  )Client.View.Finance.FundFlows.ResFundFlow�� N� Title$ 收款明细�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%V  &	        '�� �     '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid�� � ColumnDefinitions �� $	��600 �.+��� -   $��button1��$	��...��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25��$��23��{��� *
IsBPEnable+�� 	 �� DisplayMemberPath$	 	ShortName��$
��Left=�$��
394,40,0,0q�
 �� SelectedValuePath$
 Id��$	��Top=����� *InternalCustomers+ �� SelectedValue �� *ICId+{��� *IsInternalCustomerEnable+�� -   $ ��txtReceiveblesCurrencyName��$
	 Name��$
��Left=�$��394,104,0,0q�$
 Id��$	��Top=����� *
Currencies+ �� *SelectedPaymentCurrencyId+�� -   $��button4��$	��...��$
��Left=�$��246,168,0,0q�$	��Top=�$��25��$��23���� -   $��cbCmmodityType��$��394,168,0,0q�$
��Left=�$	��Top=�$
 Id��$	 Description������ *BankAccounts+ �� *SelectedBankAccountId+  $
��Left=�$��
122,72,0,0q�$	��Top=�   SelectedDate �� *	TradeDate+�� -   $��button3��$	��...��$
��Left=�$��
518,72,0,0q�$	��Top=�$��25��$��23��&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��122,104,0,0q�$	��Top=�$	��120��   IsPositiveNumber .    Text �� *Amount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z   -   $��currencyTextBox2��$��23��$
��Left=�$��394,136,0,0q�$	��Top=�$	��120�� �� *Rate+   STR_RATE# Z �� -	   $��textBox6��$	��100��$
��Left=�$��122,232,0,0q�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=� �� 	MaxLength$	 255������ *Description+�� -
   $��210,355,0,0q�$	��Top=�$
��Left=�$��60��$��23����     ResxName$! Client.Properties.Resources��
   Key$
 Save���� $��440,355,100,0q�$��Center=�$	��Top=�$��60��$��23��$y�Hidden=���  $! Client.Properties.Resources��$ SaveAsDraft���� -   $
��Left=�$��302,356,0,0q�$	��Top=�$��60��$��23����  $! Client.Properties.Resources��$ Cancel���� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *	Receipt+�� #��[  $��6,38,0,0q�$	��Top=�$
��Left=�
���<����  $! Client.Properties.Resources��$ 	PaymentBP���� $��
122,40,0,0q�$
 Wrap=�$	��Top=�$
��Left=�{�.  ���� *BPartnerName+�� #��[  $��
278,38,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ 	ReceiptBP���� #��[  $��6,70,0,0q�$
��Left=�$	��Top=�
���<����  *ReceiptDate+�� #��[  $��
278,70,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ Quota���� $��
394,72,0,0q�$
��Left=�$	��Top=�{�.  ���� *	QuotaNo+�� #��[  $��	6,102,0,0q�$
��Left=�$	��Top=�
���<����  *ReceiptAmount+�� #��[  $��278,102,0,0q�$
��Left=�$	��Top=�
���<����  *ReceiptCurrency+�� $
��Left=� �� 
IsReadOnly . $��122,136,0,0q�$
 Wrap=�$	��Top=����� *SettlementCurrencyName+�� #��[  $��	6,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ SettleCurrency���� #��[  $��278,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ 
SettleRate���� #��[  $��	6,166,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ FinancialAccount���� $
��Left=�$��122,168,0,0q�$
 Wrap=�$	��Top=�{�.  ���� *FinancialAccountName+�� #��[  $��278,166,0,0q�$
��Left=�$	��Top=�
���<����  $! Client.Properties.Resources��$ ReceiptAccount���� $
��Left=�#��[  $��	6,230,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -   $��	comboBox1��$��23��$
��Left=�$��122,200,0,0q�$	��Top=�$	��120��$
 Id��$
	 Name������ *PaymentMeans+ �� *PaymentMeanId+�� -   $��label2��$��付款方式��$��28��$
��Left=�$��	6,198,0,0q�$	��Top=�#��[  �� -   $��	checkBox1��$!��该批次已完成收付款��$��16��$
��Left=�$��394,204,0,0q�$	��Top=� d� 	IsChecked �� *IsFundflowFinished+