   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  6    0Client.View.Physical.Payments.PaymentRequestHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *PaymentRequestHome+.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label1��$��28��$
��Left=�$��7,63,0,0q�$	��Top=�$	��100��$��Right=���  $! Client.Properties.Resources��$ PaymentRequest���� -   $��button1��$��+��$��23��$
��Left=�$��
121,64,0,0q�$	��Top=�$��75���� -   $��	groupBox2��$	��180��$
��Left=�$��
330,40,0,0q�$	��Top=�$	��250��$y�Hidden=���  $! Client.Properties.Resources��$ Reports��.��� .+��� -   $��button2��$��23��$
��Left=�$��	27,23,0,0q�$	��Top=�$
��auto��   
LinkButton#��[  ��  *ApprovalLog+�� -   $��	groupBox3��$	��270��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.��� .+��� -   $��label2��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ QueryShortcut���� -	   $��button3��$��23��$
��Left=�$��	30,40,0,0q�$	��Top=�$	��110��#��[  ��  *MyUnderApprovalPaymentRequest+�� -
   $��button4��$��23��$
��Left=�$��
155,40,0,0q�$	��Top=�$	��107��#��[  $y�Hidden=���  *MyPaymentRequestDraft+�� -   $��button5��$	��...��$��23��$
��Left=�$��231,100,0,0q�$	��Top=�$��25���� -   $��	comboBox2��$��23��$
��Left=�$��373,100,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 	ShortName������ *BusinessPartners+ �� SelectedValue �� *	PayBPId+(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��23��$
��Left=�$��107,132,0,0q�$	��Top=�$	��120��	   SelectedDate	 �� *	StartDate+  -   $��datePicker2��$��23��$
��Left=�$��373,132,0,0q�$	��Top=�$	��120��	 �� *	EndDate+�� -   $��	comboBox1��$��23��$
��Left=�$��107,164,0,0q�$	��Top=�$	��120��$ Value��$	 Key������ *
PRStatus+ �� *PaymentComplete+�� -   $��button6��$��23��$
��Left=�$��373,195,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��textBox3��$��23��$
��Left=�$��107,100,0,0q�$	��Top=�$	��120��
 �� 
IsReadOnly
 . ���� *	ShortName+�� -   $��label3��$��28��$
��Left=�$��6,70,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��label4��$
��Left=�$��	1,130,0,0q�$	��100��$��Right=�$��28��$	��Top=���  *ApplyingStartDate+�� -   $��label5��$��28��$
��Left=�$��	1,162,0,0q�$	��100��$��Right=�$	��Top=���  *PaymentStatus+�� -   $��label6��$��28��$
��Left=�$��1,98,0,0q�$	��Top=�$	��100��$��Right=���  $! Client.Properties.Resources��$ 	ReceiptBP���� -   $��label7��$��28��$
��Left=�$��267,130,0,0q�$	��Top=�$	��100��$��Right=���  *ApplyingEndDate+�� -   $��label8��$��28��$
��Left=�$��
267,98,0,0q�$	��Top=�$	��100��$��Right=���  $! Client.Properties.Resources��$ 	PaymentBP���� -   $��label10��$��	批次号��$��28��$	��100��$��Right=�$
��Left=�$��267,162,0,0q�$	��Top=��� -   $��textBox1��$��23��$
��Left=�$��373,164,0,0q�$	��Top=�$	��120������ *	QuotaNo+�� -   $��	checkBox1��$!��仅显示当前用户文档��$��16��$
��Left=�$��107,199,0,0q�$	��Top=� d� 	IsChecked �� *IsOnlyCurrentUser+�� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  *PaymentRequestHome+