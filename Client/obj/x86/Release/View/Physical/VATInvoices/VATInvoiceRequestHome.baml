   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls <    6Client.View.Physical.VATInvoices.VATInvoiceRequestHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     >my/clr-namespace:Utility.Controls;assembly=Utility     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *VATInvoiceRequestHome+.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  *VATInvoiceRequestHome+�� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label1��$��增票申请��$��28��$	��100��$��Right=�$
��Left=�$��7,63,0,0q�$	��Top=��� -   $��button1��$��+��$��23��$
��Left=�$��
121,64,0,0q�$	��Top=�$��75���� -   $��	groupBox3��$	��320��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.��� .+��� -   $��label2��$
��Bold"�$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ QueryShortcut���� -   $��button3��$��23��$
��Left=�$��	30,40,0,0q�$	��Top=�$��75��   
LinkButton#��[  ��  *	MyRequest+�� -	   $��button4��$��本月申请明细��$��23��$
��Left=�$��
120,40,0,0q�$	��Top=�$
��auto��#��[  �� -
   $��label3��$
��Bold"�$��28��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��label5��$��28��$	��100��$��Right=�$
��Left=�$��267,130,0,0q�$	��Top=���  $! Client.Properties.Resources��$ ApprovalStatus���� -   $��label6��$��28��$	��100��$��Right=�$
��Left=�$��1,98,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Buyer���� -   $��label8��$��28��$	��100��$��Right=�$
��Left=�$��	1,130,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -   $��textBox3��$��23��$
��Left=�$��107,100,0,0q�$	��Top=�$	��120��{�.  ���� *BPName+�� -   $��	comboBox1��$��23��$
��Left=�$��107,132,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *Metals+ �� SelectedValue �� *SelectedMetal+�� -   $��	comboBox2��$��23��$
��Left=�$��373,132,0,0q�$	��Top=�$	��120��$ Value��$	 Key������ *ApproveStatus+ �� *ApproveStatusID+�� -   $��button5��$	��...��$��23��$
��Left=�$��231,100,0,0q�$	��Top=�$��25���� -   $��button6��$��23��$
��Left=�$��223,242,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��label4��$��28��$	��100��$��Right=�$
��Left=�$��
267,98,0,0q�$	��Top=���  *	InvoiceBP+�� -   $��	comboBox3��$ 	ShortName��$��23��$
��Left=�$��373,100,0,0q�$ Id��$	��Top=�$	��120������ *InternalBPs+ �� *InternalBPId+�� -   $��	checkBox1��$!��仅显示当前用户文档��$��16��$
��Left=�$��107,202,0,0q�$	��Top=�	 d� 	IsChecked	 �� *IsOnlyCurrentUser+�� -   $��label7��$��开始日期��$��28��$
��Left=�$��	1,164,0,0q�$��Right=�$	��Top=�$	��100��(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��107,164,0,0q�$	��Top=�$	��120��
   SelectedDate
 �� *	StartDate+�� -   $��label9��$��截止日期��$��28��$
��Left=�$��267,164,0,0q�$	��Top=�$	��100��$��Right=�  -   $��datePicker2��$��25��$
��Left=�$��373,164,0,0q�$	��Top=�$	��120��
 �� *	EndDate+�� -   $��label10��$��实际数量��$��28��$
��Left=�$��267,196,0,0q�$	��Top=�$	��100��$��Right=�&   Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��373,198,0,0q�$	��Top=�$	��120��   Text �� *VerifiedQuantity+