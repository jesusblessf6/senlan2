   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      6    0Client.View.Physical.Payments.PaymentRequestHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5
   9     *PaymentRequestHome+.��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5      .+�5      �� -   5        $��	groupBox1��5   �   $	��180��6U   $
��Left=�6b   $��	40,40,0,0q�6}   $	��Top=�5      $	��250��6/   ��5           ResxName$! Client.Properties.Resources��
   Key$	 Add��.��5      � .+�5      �� -   5        $��label1��5   �   $��28��6f   $
��Left=�6r   $��7,63,0,0q�6�   $	��Top=�5      $	��100��64   $��Right=�6@   ��5        $! Client.Properties.Resources��$ PaymentRequest��5   @   �� 5      -   5        $��button1��5   d   $��+��6   $��23��6)   $
��Left=�65   $��
121,64,0,0q�6P   $	��Top=�5      $��75��65   6@   5      5      �� 5      -   5        $��	groupBox2��5   �   $	��180��6Y   $
��Left=�6f   $��
330,40,0,0q�6�   $	��Top=�5      $	��250��6/   $y�Hidden=�6;   ��5        $! Client.Properties.Resources��$ Reports��.��5      � .+�5      �� -   5        $��button2��5   t   $��23��6:   $
��Left=�6F   $��	27,23,0,0q�6a   $	��Top=�5      $
��auto��65      
LinkButton#��[  6B   ��5        *ApprovalLog+5   B   5      5      �� 5      -   5        $��	groupBox3��5   �   $	��270��6W   $
��Left=�6d   $��
40,225,0,0q�6   $	��Top=�5      $	��540��6/   ��5        $! Client.Properties.Resources��$ Query��.��5       � .+�5!      �� -   5        $��label2��5!   �   $��28��6e   $
��Left=�6q   $��6,6,0,0q�6�   $	��Top=�5"      $
��Bold"�64   ��5!        $! Client.Properties.Resources��$ QueryShortcut��5"   4   �� 5#      -	   5        $��button3��5$      $��23��5#   L   $
��Left=�6X   $��	30,40,0,0q�6s   $	��Top=�5$   ,   $	��110��6D   #��[  6P   ��5#        *MyUnderApprovalPaymentRequest+5$   u   �� 5%      -
   5        $��button4��5%      $��23��6D   $
��Left=�6P   $��
155,40,0,0q�6k   $	��Top=�5&      $	��107��65   #��[  6A   $y�Hidden=�6�   ��5%        *MyPaymentRequestDraft+5&   �   �� 5'      -   5        $��button5��5'   g   $	��...��6   $��23��6+   $
��Left=�67   $��231,100,0,0q�6R   $	��Top=�5(      $��25��65   6@   �� 5)      -   5        $��	comboBox2��5)   [   $��23��6   $
��Left=�6+   $��373,100,0,0q�6F   $	��Top=�5*      $	��120��67    �� SelectedValuePath$ Id��6l    �� DisplayMemberPath$ 	ShortName��5+      ��5*   C   �� *BusinessPartners+ �� SelectedValue 5+   =   �� *	PayBPId+(  "System.Windows.Controls.DatePicker  5,      -   5        $��datePicker1��5,   ]   $��23��6!   $
��Left=�6-   $��107,132,0,0q�6H   $	��Top=�5-   !   $	��120��69   	   SelectedDate	 6E   �� *	StartDate+  5.      -   5        $��datePicker2��5.   ]   $��23��6!   $
��Left=�6-   $��373,132,0,0q�6H   $	��Top=�5/   !   $	��120��69   	 6E   �� *	EndDate+�� 50      -   5        $��	comboBox1��50   [   $��23��6   $
��Left=�6+   $��107,164,0,0q�6F   $	��Top=�51      $	��120��67   $ Value��6d   $	 Key��6~   ��6C   �� *
PRStatus+ 52      �� *PaymentComplete+�� 54      -   5        $��button6��54   �   $��23��6^   $
��Left=�6j   $��373,195,0,0q�6�   $	��Top=�55      $��75��65   ��54        $! Client.Properties.Resources��$ Query��55   @   �� 56      -   5        $��textBox3��56   Z   $��23��6   $
��Left=�6*   $��107,100,0,0q�6E   $	��Top=�57      $	��120��66   
 �� 
IsReadOnly
 . ��6B   �� *	ShortName+6]   �� 58      -   5        $��label3��58   �   $��28��6e   $
��Left=�6q   $��6,70,0,0q�6�   $	��Top=�59      $
��Bold"�64   ��58        $! Client.Properties.Resources��$ AdvancedQuery��59   4   �� 5:      -   5        $��label4��5;   ?   $
��Left=�5:   ?   $��	1,130,0,0q�6Z   $	��100��6m   $��Right=�5;      $��28��6M   $	��Top=�6Y   ��5:        *ApplyingStartDate+5;   Y   �� 5<      -   5        $��label5��5=   ?   $��28��5<   ;   $
��Left=�6G   $��	1,162,0,0q�6b   $	��100��6u   $��Right=�5=      $	��Top=�6M   ��5<        *PaymentStatus+5=   M   �� 5>      -   5        $��label6��5>   �   $��28��6a   $
��Left=�6m   $��1,98,0,0q�6�   $	��Top=�5?      $	��100��64   $��Right=�6@   ��5>        $! Client.Properties.Resources��$ 	ReceiptBP��5?   @   �� 5@      -   5        $��label7��5@   y   $��28��6=   $
��Left=�6I   $��267,130,0,0q�6d   $	��Top=�5A      $	��100��64   $��Right=�6@   ��5@        *ApplyingEndDate+5A   @   �� 5B      -   5        $��label8��5B   �   $��28��6a   $
��Left=�6m   $��
267,98,0,0q�6�   $	��Top=�5C      $	��100��64   $��Right=�6@   ��5B        $! Client.Properties.Resources��$ 	PaymentBP��5C   @   �� 5D      -   5        $��label10��5D   �   $��	批次号��6   $��28��6*   $	��100��66   $��Right=�6B   $
��Left=�6e   $��267,162,0,0q�6�   $	��Top=�6�   �� 5E      -   5        $��textBox1��5E   Z   $��23��6   $
��Left=�6*   $��373,164,0,0q�6E   $	��Top=�6j   $	��120��6�   ��6�   �� *	QuotaNo+�� 5F      -   5        $��	checkBox1��5F   o   $!��仅显示当前用户文档��6   $��16��63   $
��Left=�6?   $��107,199,0,0q�6Z   $	��Top=�6�    d� 	IsChecked 6�   �� *IsOnlyCurrentUser+5G      5H      �� 5I      -   5        $��lbTitle��5J   4   $��32��5I   8   $
��Left=�6D   $��6,6,0,0q�6_   $	��Top=�6p   $
��Bold"�5J      $��16(�6&   ��5I        *PaymentRequestHome+5J   4   5K      5L      5M      