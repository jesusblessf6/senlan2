   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5
   ^   <    6Client.View.Physical.VATInvoices.VATInvoiceRequestHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5
   ^   0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5
   9     *VATInvoiceRequestHome+.��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5      .+�5      �� -   5        $��lbTitle��5   ;   $��32��6J   $
��Left=�6V   $��6,6,0,0q�6q   $	��Top=�5      $
��Bold"�6,   $��16(�6>   ��5        *VATInvoiceRequestHome+5   >   �� 5      -   5        $��	groupBox1��5   �   $	��180��6U   $
��Left=�6b   $��	40,40,0,0q�6}   $	��Top=�5      $	��250��6/   ��5           ResxName$! Client.Properties.Resources��
   Key$	 Add��.��5      � .+�5      �� -   5        $��label1��5   I   $��增票申请��5      $��28��6+   $	��100��67   $��Right=�6C   $
��Left=�5      $��7,63,0,0q�67   $	��Top=�6W   �� 5      -   5        $��button1��5   d   $��+��6   $��23��6)   $
��Left=�65   $��
121,64,0,0q�6P   $	��Top=�5      $��75��65   6@   5      5      �� 5      -   5        $��	groupBox3��5   �   $	��320��6W   $
��Left=�6d   $��
40,225,0,0q�6   $	��Top=�5      $	��540��6/   ��5        $! Client.Properties.Resources��$ Query��.��5      � .+�5      �� -   5        $��label2��5      $
��Bold"�5   e   $��28��6w   $
��Left=�6�   $��6,6,0,0q�6�   $	��Top=�5   *   ��5        $! Client.Properties.Resources��$ QueryShortcut��5   *   �� 5      -   5        $��button3��5   r   $��23��68   $
��Left=�6D   $��	30,40,0,0q�6_   $	��Top=�5      $��75��65      
LinkButton#��[  6@   ��5        *	MyRequest+5   d   �� 5       -	   5        $��button4��5    i   $��本月申请明细��6   $��23��6.   $
��Left=�6:   $��
120,40,0,0q�6U   $	��Top=�5!      $
��auto��65   #��[  6B   6f   �� 5"      -
   5        $��label3��5#      $
��Bold"�5"   e   $��28��6w   $
��Left=�6�   $��6,70,0,0q�6�   $	��Top=�5#   *   ��5"        $! Client.Properties.Resources��$ AdvancedQuery��5#   *   �� 5$      -   5        $��label5��5%   L   $��28��5$   f   $	��100��6r   $��Right=�6~   $
��Left=�5%      $��267,130,0,0q�67   $	��Top=�6Z   ��5$        $! Client.Properties.Resources��$ ApprovalStatus��5%   Z   �� 5&      -   5        $��label6��5'   I   $��28��5&   ]   $	��100��6i   $��Right=�6u   $
��Left=�5'      $��1,98,0,0q�67   $	��Top=�6W   ��5&        $! Client.Properties.Resources��$ Buyer��5'   W   �� 5(      -   5        $��label8��5)   J   $��28��5(   a   $	��100��6m   $��Right=�6y   $
��Left=�5)      $��	1,130,0,0q�67   $	��Top=�6X   ��5(        $! Client.Properties.Resources��$ 	Commodity��5)   X   �� 5*      -   5        $��textBox3��5*   Z   $��23��6   $
��Left=�6*   $��107,100,0,0q�6E   $	��Top=�5+      $	��120��66   {�.  ��6B   �� *BPName+6Z   �� 5,      -   5        $��	comboBox1��5,   [   $��23��6   $
��Left=�6+   $��107,132,0,0q�6F   $	��Top=�5-      $	��120��67    �� SelectedValuePath$ Id��6b    �� DisplayMemberPath$
 Name��6y   ��6C   �� *Metals+ �� SelectedValue 5.      �� *SelectedMetal+�� 5/      -   5        $��	comboBox2��5/   [   $��23��6   $
��Left=�6+   $��373,132,0,0q�6F   $	��Top=�50      $	��120��67   $ Value��6i   $	 Key��51      ��50   C   �� *ApproveStatus+ 51   7   �� *ApproveStatusID+�� 52      -   5        $��button5��52   g   $	��...��6   $��23��6+   $
��Left=�67   $��231,100,0,0q�6R   $	��Top=�53      $��25��65   6@   �� 54      -   5        $��button6��54   �   $��23��6^   $
��Left=�6j   $��223,242,0,0q�6�   $	��Top=�55      $��75��65   ��54        $! Client.Properties.Resources��$ Query��55   @   �� 56      -   5        $��label4��57   K   $��28��56   7   $	��100��6C   $��Right=�6O   $
��Left=�57      $��
267,98,0,0q�67   $	��Top=�6Y   ��56        *	InvoiceBP+57   Y   �� 58      -   5        $��	comboBox3��59   X   $ 	ShortName��58      $��23��6=   $
��Left=�6I   $��373,100,0,0q�59   C   $ Id��5:      $	��Top=�66   $	��120��6N   ��59      �� *InternalBPs+ 6i   �� *InternalBPId+5:   N   �� 5;      -   5        $��	checkBox1��5;   o   $!��仅显示当前用户文档��6   $��16��63   $
��Left=�6?   $��107,202,0,0q�6Z   $	��Top=�6�   	 d� 	IsChecked	 6�   �� *IsOnlyCurrentUser+�� 5<      -   5        $��label7��5<   �   $��开始日期��6   $��28��6+   $
��Left=�67   $��	1,164,0,0q�6R   $��Right=�6e   $	��Top=�6�   $	��100��6�   (  "System.Windows.Controls.DatePicker  5=      -   5        $��datePicker1��5=   ]   $��25��6!   $
��Left=�6-   $��107,164,0,0q�6H   $	��Top=�6p   $	��120��6�   
   SelectedDate
 6�   �� *	StartDate+�� 5>      -   5        $��label9��5>   g   $��截止日期��6   $��28��6+   $
��Left=�67   $��267,164,0,0q�6R   $	��Top=�6u   $	��100��6�   $��Right=�6�     5?      -   5        $��datePicker2��5?   ]   $��25��6!   $
��Left=�6-   $��373,164,0,0q�6H   $	��Top=�6p   $	��120��6�   
 6�   �� *	EndDate+�� 5@      -   5        $��label10��5@   g   $��实际数量��6   $��28��6+   $
��Left=�67   $��267,196,0,0q�6R   $	��Top=�6v   $	��100��6�   $��Right=�6�   &   Utility.Controls.CurrencyTextBox  5A      -   5        $��currencyTextBox1��5A   e   $��23��6)   $
��Left=�65   $��373,198,0,0q�6P   $	��Top=�6}   $	��120��6�      Text 6�   �� *VerifiedQuantity+5B      5C      5D      5E      5F      