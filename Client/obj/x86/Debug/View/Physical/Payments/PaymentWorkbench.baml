   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5	   0   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      4   .Client.View.Physical.Payments.PaymentWorkbench   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	   0   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5	        *PaymentWorkbench+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker  Payment  PaymentConsummation  PaymentWorkbenchActions �� DataType �� Orientation	   ResxName

   Key��%V  &	        '�� �     '�� k    '  �    &	 Y    &	 l    &	     7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$ 90��6&   63   �� 5       � ��$ 90��6)   66   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5!   
   "  6   .�5"      ��  � ��$ 23��6'   64   �� 5#       � ��$	 120��6&   64   5$      �� 5&   
   6*   �� 5'   
   66   �� 5)   
   $ DBEntity:PaymentRequest��67   .R�5*      �� $ 
Horizontal=�6   .+�5+      �� $��	btPayment��6   8��  ��6*     $!	 Client.Properties.Resources��$
 Payment����5,      �� *Id+6;   �� 5-      $��btPaymentConsummation��6   8�� ��66     $!	 Client.Properties.Resources��$
 PaymentComplete����5.      �� *Id+6;   5/      50      51       J� CommandBindings 53      )  #System.Windows.Input.CommandBinding  54   
   -   5           Command# [ 54      6x     55   
   -   5        # [ 55      56   B   .��59      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5:      .��5;   
   � -   5         �Name$ rootGrid��5;      .+�5<      �� -   5        $��	groupBox1��5<   �   $	��100��6\   $
��Left=�6i   $��6,40,0,0q�6�   $	��Top=�5=      $	��960��6/   ��5<        $!	 Client.Properties.Resources��$
 
Conditions��.��5>      � .+�5@      �� -   5        $��button1��5@   f   $	��...��6   $��23��6+   $
��Left=�67   $��
221,12,0,0q�6R   $	��Top=�5A      $��25��65   6@   �� 5B      -   5        $��	comboBox1��5B   N   $
��Left=�6   $��
352,12,0,0q�6:   $	��Top=�6_    �� SelectedValuePath$ Id��5C   H    �� DisplayMemberPath$ 	ShortName��6_   ��6   �� *BusinessPartners+ �� SelectedValue 5D      �� *	PayBPId+�� 5E      -   5        $��	comboBox2��5E   N   $
��Left=�6   $��
582,12,0,0q�6:   $	��Top=�6_   $ Id��5F   E   $
 Name��6\   ��6   �� *PaymentUsages+ 5G      �� *PaymentUsageId+�� 5H      -   5        $��	comboBox3��5H   M   $
��Left=�6   $��	97,44,0,0q�6:   $	��Top=�6^   $ Id��5I   B   $
 Name��6Y   ��6   �� *
Commoditys+ 5J      �� *CommodityId+  5K      -	   5        $��datePicker1��5K   P   $
��Left=�6!   $��
352,44,0,0q�6<   $	��Top=�5L   !      SelectedDate 69   �� *	StartDate+  5M      -
   5        $��datePicker2��5M   P   $
��Left=�6!   $��
582,44,0,0q�6<   $	��Top=�5N   !    69   �� *	EndDate+�� 5O      -   5        $��button2��5O   �   $��23��6^   $
��Left=�6j   $��
800,44,0,0q�6�   $	��Top=�6�   $��75��6�   ��6     $!	 Client.Properties.Resources��$
 Query��6�   �� 5P      -   5        $��label1��5P   �   #��[  6a   $
��Left=�6�   $��1,10,0,0q�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 	ReceiptBP��6�   �� 5Q      -   5        $��textBox1��5Q   L   $
��Left=�6   $��	97,12,0,0q�69   $	��Top=�6\   {�.  ��6t   �� *	ShortName+6�   �� 5R      -   5        $��label2��5R   �   #��[  6a   $
��Left=�6�   $��
256,10,0,0q�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 	PaymentBP��6�   �� 5S      -   5        $��label3��5S   �   #��[  6d   $
��Left=�6�   $��
486,10,0,0q�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 PaymentUsage��6�   �� 5T      -   5        $��label4��5T   �   #��[  6a   $
��Left=�6�   $��1,42,0,0q�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 	Commodity��6�   �� 5U      -   5        $��label5��5U   �   #��[  6@   $
��Left=�6d   $��
256,42,0,0q�6   $	��Top=�6�   ��6     *ApplyingStartDate+6�   �� 5V      -   5        $��label6��5W   K   #��[  5V   =   $
��Left=�5W      $��
486,42,0,0q�67   $	��Top=�6Y   ��5V        *ApplyingEndDate+5W   Y   �� 5X      -   5        $��label7��5X   Y   $��	批次号��6   $
��Left=�6*   $��
702,10,0,0q�6E   #��[  6g   $	��Top=�6�   �� 5Y      -   5        $��textBox2��5Y   Y   $��23��6   $
��Left=�6*   $��
800,12,0,0q�6E   $	��Top=�6i   $	��120��6�   ��6�   �� *	QuotaNo+5Z      5[      &   System.Windows.Controls.DataGrid  5\      -   5        $��	dataGrid1��5\   F      AutoGenerateColumns .  $��	6,186,0,0q�63   $	��Top=�6W      
IsReadOnly . $
��Auto��5]   )   $
��auto��67   $
��Left=�6e      Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6k      CanUserSort .    Header 6)     $!	 Client.Properties.Resources��$
 QuotaNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6�   �� *Quota.QuotaNo+6�     5`      $
 Auto 6m    .  6)     $!	 Client.Properties.Resources��$
 	PaymentBP�� 5a   )   �� *PayBusinessPartner.ShortName+6\     5b      $ 付款银行��6)   $
 Auto 67    .  5c   )   �� *PayBankAccount.Bank.Name+5d        5e      $ 付款账号��6)   $
 Auto 67    .  5f   )   �� *PayBankAccount.AccountCode+5g        5h      $
 Auto 6m    .  6)     $!	 Client.Properties.Resources��$
 	Commodity�� 5i   )   �� *Quota.Commodity.Name+6T     5j      $
 Auto 6p    .    SortMemberPath$
 Code��5k   O    5j   )     $!	 Client.Properties.Resources��$
 PaymentUsage�� 5k   )   �� *PaymentUsage.Name+5l        5m      $
 Auto 6o    .  6)     $!	 Client.Properties.Resources��$
 PaymentMean�� 5n   )   �� *PaymentMean.Name+6P     5o      $
 Auto 6m    . $
 Code��5p   Y    5o   )     $!	 Client.Properties.Resources��$
 	ReceiptBP�� 5p   )   �� *ReceiveBusinessPartner.Name+5q        5r      $ 收款银行��6)   $
 Auto 67    .  5s   )   �� *ReceiveBankAccount.Bank.Name+5t        5u      $ 收款账号��6)   $
 Auto 67    .  5v   )   �� * ReceiveBankAccount.AccountCode+5w        5x      $
 Auto 6q    .  6)     $!	 Client.Properties.Resources��$
 AppliedAmount�� 6�   �� *RequestAmount+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z 6�     5y      $
 Auto 6l    . $
 Code��5z   )    5y   )     $!	 Client.Properties.Resources��$
 Currency�� 6�   �� *Currency.Name+5{        5|      $
 Auto 6n    .  6)     $!	 Client.Properties.Resources��$
 
PaidAmount�� 5}   )   �� *
PaidAmount+# Z 6�     5~      $ 备注��6)   $
 Auto 65    .  5   )   �� *	Comment+6G     5�      $
 Auto 6l    .  6)     $!	 Client.Properties.Resources��$
 Approval�� 6�   �� *Approval.Name+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5�       .    DataGridColumnHeaderStyle   HeaderStyle# [ 5�   -    5�   -     $!	 Client.Properties.Resources��$
 ApprovalDetail��   CellTemplate 5�      �� 5�      $ DBEntity:PaymentRequest��6+   .R�5�   "   �� �� 5�   &   
��� � ��6=   �� *CustomerStrField1+6b    �� 5�   &   
���  ���6;   �� *CustomerStrField2+6`   5�   #   5�      5�        5�      $
 Auto 6m    .  6)     $!	 Client.Properties.Resources��$
 	ApplyDate�� 5�   )   �� *RequestDate+$ 
yyyy-MM-dd��6e     5�      $
 Auto 6z    .  6)     $.	 (Client.View.Physical.Payments.ResPayment��$
 	Applicant�� 6�   �� *	User.Name+6�     5�      $
 Auto 6q    .  # [ 5�   -    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�   g   5�      $   Utility.Controls.PagingControl  5�      -   5        $��pagingControl1��5�   M   $
��Left=�6   $��	6,149,0,0q�6:   $	��Top=�5�      $
��auto��67   �� 5�      -   5        $��lbTitle��5�   6   $
��Left=�6E   $��6,6,0,0q�6`   $��32��6q   $	��Top=�5�      $
��Bold"�6,   $��16(�6>   ��5�        *PaymentWorkbench+5�   >   5�      5�      5�      