   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 4   .Client.View.Physical.Payments.PaymentWorkbench   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *PaymentWorkbench+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker  Payment  PaymentConsummation  PaymentWorkbenchActions �� DataType �� Orientation	   ResxName

   Key��%�  &	        '�� ~     '�� �     '  �     &	 ,    &	 1    &	 6    7  7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$ 90����  � ��$ 90����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� $ DBEntity:PaymentRequest��.R��� $ 
Horizontal=�.+��� $��	btPayment��8��  ��  $!	 Client.Properties.Resources��$
 Payment������ *Id+�� $��btPaymentConsummation��8�� ��  $!	 Client.Properties.Resources��$
 PaymentComplete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -    �Name$ rootGrid��.+��� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��820����  $!	 Client.Properties.Resources��$
 
Conditions��.��� .+��� -   $��button1��$	��...��$��23��$
��Left=�$��
221,12,0,0q�$	��Top=�$��25���� -   $��	comboBox1��$
��Left=�$��
352,12,0,0q�$	��Top=� �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 	ShortName������ *BusinessPartners+ �� SelectedValue �� *	PayBPId+�� -   $��	comboBox2��$
��Left=�$��
582,12,0,0q�$	��Top=�$ Id��$
 Name������ *PaymentUsages+ �� *PaymentUsageId+�� -   $��	comboBox3��$
��Left=�$��	97,44,0,0q�$	��Top=�$ Id��$
 Name������ *
Commoditys+ �� *CommodityId+  -	   $��datePicker1��$
��Left=�$��
352,44,0,0q�$	��Top=�   SelectedDate �� *	StartDate+  -
   $��datePicker2��$
��Left=�$��
582,44,0,0q�$	��Top=� �� *	EndDate+�� -   $��button2��$��23��$
��Left=�$��
717,44,0,0q�$	��Top=�$��75����  $!	 Client.Properties.Resources��$
 Query���� -   $��label1��#��[  $
��Left=�$��1,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	ReceiptBP���� -   $��textBox1��$
��Left=�$��	97,12,0,0q�$	��Top=�{�.  ���� *	ShortName+�� -   $��label2��#��[  $
��Left=�$��
256,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	PaymentBP���� -   $��label3��#��[  $
��Left=�$��
486,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 PaymentUsage���� -   $��label4��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	Commodity���� -   $��label5��#��[  $
��Left=�$��
256,42,0,0q�$	��Top=���  *ApplyingStartDate+�� -   $��label6��#��[  $
��Left=�$��
486,42,0,0q�$	��Top=���  *ApplyingEndDate+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $��	6,186,0,0q�$	��Top=�   
IsReadOnly . $
��Auto��$
��auto��$
��Left=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    Header   $!	 Client.Properties.Resources��$
 QuotaNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Quota.QuotaNo+  $
 Auto  .    $!	 Client.Properties.Resources��$
 	PaymentBP�� �� *PayBusinessPartner.ShortName+  $ 付款银行��$
 Auto  .  �� *PayBankAccount.Bank.Name+  $ 付款账号��$
 Auto  .  �� *PayBankAccount.AccountCode+  $
 Auto  .    $!	 Client.Properties.Resources��$
 	Commodity�� �� *Quota.Commodity.Name+  $
 Auto  .    SortMemberPath$
 Code��   $!	 Client.Properties.Resources��$
 PaymentUsage�� �� *PaymentUsage.Name+  $
 Auto  .    $!	 Client.Properties.Resources��$
 PaymentMean�� �� *PaymentMean.Name+  $
 Auto  . $
 Code��   $!	 Client.Properties.Resources��$
 	ReceiptBP�� �� *ReceiveBusinessPartner.Name+  $ 收款银行��$
 Auto  .  �� *ReceiveBankAccount.Bank.Name+  $ 收款账号��$
 Auto  .  �� * ReceiveBankAccount.AccountCode+  $
 Auto  .    $!	 Client.Properties.Resources��$
 AppliedAmount�� �� *RequestAmount+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z   $
 Auto  . $
 Code��   $!	 Client.Properties.Resources��$
 Currency�� �� *Currency.Name+  $
 Auto  .    $!	 Client.Properties.Resources��$
 
PaidAmount�� �� *
PaidAmount+# Z   $
 Auto  .    $!	 Client.Properties.Resources��$
 Approval�� �� *Approval.Name+4  .System.Windows.Controls.DataGridTemplateColumn   .    DataGridColumnHeaderStyle   HeaderStyle# [    $!	 Client.Properties.Resources��$
 ApprovalDetail��   CellTemplate �� $ DBEntity:PaymentRequest��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+  $
 Auto  .    $!	 Client.Properties.Resources��$
 	ApplyDate�� �� *RequestDate+$ 
yyyy-MM-dd��  $
 Auto  .    $.	 (Client.View.Physical.Payments.ResPayment��$
 	Applicant�� �� *	User.Name+  $
 Auto  .  # [    $!	 Client.Properties.Resources��$
 	Operation��$   Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��	6,149,0,0q�$	��Top=�$
��auto���� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *PaymentWorkbench+