   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5	      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      5clr-namespace:Client.ConvertersClient.Converters 5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      2   ,Client.View.Reports.QuotaInvoiceDetailReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      -cclr-namespace:Client.Converters     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   @     *VATInvoiceDetail+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker*  $Client.Converters.VATStatusConverter  VATStatusConverter��%  &	        '�� �     '  m    &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5!   
   6<   5"      .��5$      �� $
��Auto=�6   $
��Auto=�68   .��5%   
   � -   5        $��rootGrid��5%      .+�5&      �� -   5        $��lbTitle��5'      $��34��5&   6   $
��Left=�6B   $��6,6,0,0q�6]   $	��Top=�5(      $��16(�6,   $
��auto��6:   $
��Bold"�6G   ��5&        *VATInvoiceDetail+5(   G   �� 5)      -   5        $��
separator1��5)   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   &   System.Windows.Controls.DataGrid  5*      -   5        $��	dataGrid1��5+   )      AutoGenerateColumns .  $
��Auto��5*   3   $
��Left=�6A   $��	6,191,0,0q�6\      
IsReadOnly . $	��Top=�5+   :   $
��Auto��6R   ��5,      �� *Quotas+	   Columns	 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn
   CanUserSort
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5/   <      Header 5.   )        ResxName$! Client.Properties.Resources��
   Key$ QuotaNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5/   I   �� *	QuotaNo+50        51      $ 预开/收票日期��6)   
 . $
 Auto 52   <    6I   �� *VATInvoiceDate+ �� StringFormat$ 
yyyy-MM-dd��53        54      
 . $
 Auto 55   <    54   )     $! Client.Properties.Resources��$ 	Commodity�� 56   )   �� *Commodity.Name+57        58      
 . $
 Auto 59   <    58   )     $! Client.Properties.Resources��$ Brand�� 59   I   �� *
Brand.Name+5:        5;      
 . $
 Auto 5<   <    5;   )     $! Client.Properties.Resources��$ Quantity�� 5=   )   �� *
Quantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY# Z 5>        5?      
 . $
 Auto 5@   <    5?   )     $! Client.Properties.Resources��$ ActualQuantity�� 5A   )   �� *VerifiedQuantity+# Z 5B        5C      
 . $
 Auto 5D   <    5C   )     $! Client.Properties.Resources��$ Price�� 5E   )   �� *
FinalPrice+ 
  	STR_PRICE# Z 5F        5G      
 . $
 Auto 5H   <    5G   )     $# Client.View.Reports.ResReport��$ InvoicedQty�� 5I   )   �� *VATInvoicedQuantity+# Z 5J        5K      
 .  $
 Auto 5L   =    5K   )     $! Client.Properties.Resources��$ InvoicedStatus�� 5M   )   �� *	VATStatus+ �� 	Converter# [ 5N       �� 
GroupStyle 5Q      (  "System.Windows.Controls.GroupStyle  5R        GroupHerderStyle   ContainerStyle# [ 6!      Panel 5S      �� 5T      .R�5U   "   >  8System.Windows.Controls.Primitives.DataGridRowsPresenter  5V      5X      5Z      �� 5[      -   5        $��	groupBox1��5\   D   $	��100��5[   \   $
��Left=�5\      $��6,40,0,0q�62   $	��Top=�5]      $	��980��6/   ��5[        $! Client.Properties.Resources��$ 
Conditions��.��5^      � .+�5_      �� -   5        $��label3��5a   .   #��[  5`      $
��Left=�6@   $��1,10,0,0q�5a      $	��Top=�6<   
���<����5_        $! Client.Properties.Resources��$ InternalCustomer��5a   T   �� 5b      -   5        $��	comboBox1��5b   3   $��
107,12,0,0q�6    �� SelectedValuePath$ Id��5c       �� DisplayMemberPath$ 	ShortName��66   $
��Left=�5e      $	��Top=�6:   ��5b   D   �� *InternalCustomers+ �� SelectedValue 5d      �� *InternalCustomerId+5e   :   �� 5f      -   5        $��label5��5g   .   #��[  5f   9   $
��Left=�6]   $��1,42,0,0q�5g      
���<��$	��Top=�6Q   ��5f        *OpenCollect+5g   Q   �� 5h      -	   5        $��	comboBox3��5h   3   $��
107,44,0,0q�6   $ Id��5i      $
 Name��66   $
��Left=�5j   J   $	��Top=�5k      ��5h   D   �� *VATInvoiceTypes+ 5j      �� *VATInvoiceTypeId+5k      �� 5l      -
   5        $��label2��5n   0   #��[  5m      $
��Left=�6@   $��
227,10,0,0q�5n      $	��Top=�6>   ��5l        $! Client.Properties.Resources��$ BP��5n   >   �� 5o      -   5        $��textBox1��5o   Y   $��23��6   $
��Left=�6*   $��
333,12,0,0q�6E   $	��Top=�5p      $	��120��66   {�.  ��6T   �� *BPName+�� 5q      -   5        $��button1��5q   f   $	��...��6   $��23��6+   $
��Left=�67   $��
457,12,0,0q�6R   $	��Top=�5r      $��25��65   6@   �� 5s      -   5        $��label4��5u   0   #��[  5t      $
��Left=�6@   $��
481,10,0,0q�5u      $	��Top=�6>   ��5s        $! Client.Properties.Resources��$ 	Commodity��5u   >   �� 5v      -   5        $��	comboBox2��5v   N   $
��Left=�6   $��
587,12,0,0q�6:   $	��Top=�6_   $ Id��5w   C   $
 Name��6Z   ��6   �� *Commodities+ 5x      �� *CommodityId+�� 5y      -   5        $��label6��5{   0   #��[  5z      $
��Left=�6@   $��
227,42,0,0q�5{      $	��Top=�6>   ��5y        $! Client.Properties.Resources��$ 	StartDate��5{   >     5|      -   5        $��datePicker1��5|   5   $��
333,44,0,0q�6!   $
��Left=�5}   !   $	��Top=�6<      SelectedDate 5|   H   �� *	StartDate+5}   <   �� 5~      -   5        $��label7��5�   0   $
��Left=�5      #��[  67   $��
481,42,0,0q�5�      $	��Top=�6>   ��5~        $! Client.Properties.Resources��$ EndDate��5�   >     5�      -   5        $��datePicker2��5�   5   $��
587,44,0,0q�6!   $
��Left=�5�   !   $	��Top=�6<    5�   H   �� *	EndDate+5�   <   �� 5�      -   5        $��button3��5�   L   $��23��5�   ^   $
��Left=�5�      $��
872,44,0,0q�68   $	��Top=�5�      $��60��65   $y�	Collapsed=�6U   ��5�        $! Client.Properties.Resources��$ Reset��5�   U   �� 5�      -   5        $��label1��5�   �   $
��Left=�6|   $��
706,10,0,0q�6�   #��[  6�   $	��Top=�6�   $	��100��6�   ��6     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ OpenInvoiceStatus��6�   �� 5�      -   5        $��	comboBox4��5�   p   $
��Left=�6   $��
812,12,0,0q�6\   $ Value��6�   $	 Key��6�   $	��Top=�6�   ��6:   �� *	VATStatus+ 6�   �� *SelectedVATStatus+6�   �� 5�      -   5        $��button2��5�   �   $��23��6^   $
��Left=�6j   $��
812,44,0,0q�6�   $	��Top=�6�   $��50��6�   ��6     $! Client.Properties.Resources��$ Query��6�   �� 5�      -   5        $��button4��5�   j   $��导出Excel��6   $��23��6/   $
��Left=�6;   $��
872,44,0,0q�6V   $	��Top=�6y   $��60��6�   6�   5�      5�      �� 5�      -   5        $��label8��5�   p   $��实际数量：��6   
���  ��$��28��65   $
��Left=�6A   $��
13,161,0,0q�6\   $	��Top=�6~   �� 5�      -   5        $��label9��5�   �   $��28��6p   $
��Left=�6|   $��
76,161,0,0q�6�   $	��Top=�6�   ��6   �� *VerQtyCount+# Z 6�   �� 5�      -   5        $��label10��5�   V   $��	金额：��6   
���  ��$��28��63   $��239,161,724,0q�6?   $	��Top=�6e   �� 5�      -   5        $��label11��5�   �   $��28��6i   $
��Left=�6u   $��280,161,0,0q�6�   $	��Top=�6�   ��6   �� *Amount+ 
  
STR_AMOUNT# Z 6�   5�      5�      5�      