   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      ;   5Client.View.Physical.VATInvoices.VATInvoiceLineDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      $	��380��5   l   $	��550��6y   0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��5       � 
ResizeMode$ NoResize=�5   P    � Title 5   O     *InvoiceDetail+ � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5	       �� 
TargetType �� Property �� Value��%  '��       '�� �     '�� m    �� 5
   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5      .+�5      �� -   5        $��button2��5   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,40,0,0q�6J   $	��Top=�5      $��25��6-   68   �� 5       -   5        $��	comboBox5��5!   +   	 �� DisplayMemberPath$
	 Code��5       $��23��60   $
��Left=�6<   $��
394,72,0,0q�5!      
 �� SelectedValuePath$
 Id��6`   $	��Top=�6w   $	��120��5"      ��5    W   �� *
VATRates+ �� SelectedValue 5!   <   �� *	VATRateId+5"      &    Utility.Controls.CurrencyTextBox  5#      -   5        $��currencyTextBox3��5#   \   $��23��6!   $
��Left=�6-   $��
122,72,0,0q�6H   $	��Top=�5$   E   $	��120��6]      Text 6!   �� *VATInvoiceQuantity+6]     5%      -   5        $��currencyTextBox1��5%   ]   $��23��6!   $
��Left=�6-   $��122,104,0,0q�6H   $	��Top=�5&   <   $	��120��6T    6!   �� *	VATAmount+6T   �� 5'      -   5        $��cbVATStatus��5'   f   $
��Left=�66   $��122,136,0,0q�6Q   $	��Top=�5(      ��5'        *FullyInvoiced+ d� 	IsChecked 5(   /   �� *	VATStatus+�� 5)      -   5        $��textBox6��5)   S   $	��100��6   $
��Left=�6#   $��122,168,0,0q�6>   $	��Top=�6c   $	��392��5*      ��6"   �� *	Comment+�� 5+      -   5        $��button3��5+   �   $��23��6U   $
��Left=�6a   $��210,292,0,0q�6|   $	��Top=�5,      $��60��6-   ��5+           ResxName$! Client.Properties.Resources��
   Key$
 Save��5,   8   �� 5-      -	   5        $��button5��5.      $��23��5-   \   $y�Hidden=�6h   $
��Left=�6|   $��371,292,0,0q�6�   $	��Top=�5.   $   $��60��6<   ��5-        $! Client.Properties.Resources��$ SaveAsDraft��5.   <   �� 5/      -
   5        $��button4��5/   �   $��23��6W   $
��Left=�6c   $��305,292,0,0q�6~   $	��Top=�50      $��60��6-   ��5/        $! Client.Properties.Resources��$ Cancel��50   8   �� 51      -   5        $��lbTitle��51   3   $��32��6B   $
��Left=�6N   $��6,6,0,0q�6i   $
��auto��6z   $
��Left=�6�   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     *InvoiceDetail+6�   �� 52      -   5        $��label2��52   g   $��6,38,0,0q�6U   
���<��$	��Top=�6�   $
��Left=�53      ��52        $! Client.Properties.Resources��$ Quota��53      �� 54      -   5        $��textBox1��54   W   $
��Left=�6   {�.  $��
122,40,0,0q�6C   $	��Top=�55   /   ��6   �� *	QuotaNo+6/   �� 56      -   5        $��label3��56   T   $��批次未开数量��6   $
��Left=�6%   $��
278,38,0,0q�6@   $	��Top=�6b     57      -   5        $��currencyTextBox2��57   \   $��23��6!   $
��Left=�6-   $��
394,40,0,0q�6H   $	��Top=�58   C   $	��120��6[   {�.   6!   �� *UnOpenedQuantity+6g   �� 59      -   5        $��label4��59   ]   $
��Left=�60   $��6,70,0,0q�6K   $	��Top=�6k   ��6     *
InvoiceQty+6k   �� 5;      -   5        $��label6��5;   �   $
��Left=�6W   $��
278,70,0,0q�6r   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ TaxRate��5<        5=      -   5        $��currencyTextBox4��5>   !   $��23��5=   !   $
��Left=�6-    �� 
IsReadOnly . $��394,104,0,0q�6Z   $	��Top=�5>   T   $	��120��6l    69   �� *	RateValue+6l   �� 5?      -   5        $��label9��5?   l   $
��Left=�6>   $��	6,102,0,0q�6Y   $	��Top=�6z   ��6     *InvoiceAmountTaxIncluded+6z   �� 5A      -   5        $��label5��5A   _   $
��Left=�6/   $��278,102,0,0q�6J   $	��Top=�6m   ��6     *	TaxAmount+6m   �� 5D      -   5        $��label10��5D   �   $
��Left=�6X   $��	6,166,0,0q�6s   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Comments��6�     5E      -   5        $��currencyTextBox5��5F   !   $��23��5E   !   $
��Left=�6-   $��394,136,0,0q�6H   $	��Top=�5F   S   $	��120��6k    69   �� *
VATPrice+6k   �� 5G      -   5        $��label7��5G   b   $
��Left=�62   $��278,134,0,0q�6M   $	��Top=�6p   ��6     *InvoicePrice+6p   5H      5I      5J      