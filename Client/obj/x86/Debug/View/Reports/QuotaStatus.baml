   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5
      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   7   C&clr-namespace:Client.ViewModel.ReportsClient.ViewModel.Reports  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      %    Client.View.Reports.QuotaStatus   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5
      >my/clr-namespace:Utility.Controls;assembly=Utility     5   7   :Reports&clr-namespace:Client.ViewModel.Reports     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *QuotaStatusChange+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker  ChangeStatus/   )Client.Converters.CompleteStatusConverter  CompleteStatusConverter*   $Client.Converters.VATStatusConverter  VATStatusConverter��%Y  &	        '�� �     '  m    &	 �    &	 �    &	 
    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5       ��  � ��$ 23��6'   64   �� 5!       � ��$	 120��6&   64   5"      �� 5$   
   6/     5&   
   6F     5'   
   6<   5(       J� CommandBindings 5*      )  #System.Windows.Input.CommandBinding  5+   
   -   5           Command# [ 5+      5-      .��50      �� $
��Auto=�6   $
��Auto=�68   .��51   
   � -   5        $��rootGrid��51      .+�52      �� -   5        $��lbTitle��53      $��32��52   7   $
��Left=�6C   $��6,6,0,0q�6^   $	��Top=�53   #   $��16(�6;   $
��Bold"�6I   ��52        *QuotaStatusChange+53   I   �� 55      -   5        $��	groupBox1��56   D   $	��130��55   \   $
��Left=�56      $��6,40,0,0q�62   $	��Top=�57      $	��800��6/   ��55        	   ResxName$!	 Client.Properties.Resources��

   Key$
 
Conditions��.��58      � .+�59      �� -   5        $��label1��5;      #��[  5:      $
��Left=�6@   $��1,10,0,0q�6[   $	��Top=�5;   *   ��59        $!	 Client.Properties.Resources��$
 Quota��5;   *   �� 5<      -   5        $��textBox1��5<   Y   $��23��6   $
��Left=�6*   $��
107,12,0,0q�6E   $	��Top=�5=      $	��120��66   {�.  ��6B   �� *	QuotaNo+6[   �� 5>      -   5        $��button1��5>   f   $	��...��6   $��23��6+   $
��Left=�67   $��
231,12,0,0q�6R   $	��Top=�5?      $��25��65   6@   �� 5@      -   5        $��label2��5B      #��[  5A      $
��Left=�6@   $��
260,10,0,0q�6[   $	��Top=�5B   *   ��5@        $!	 Client.Properties.Resources��$
 	StartDate��5B   *     5C      -	   5        $��datePicker1��5C   P   $
��Left=�6!   $��
366,12,0,0q�6<   $	��Top=�5D   !      SelectedDate 69   �� *	StartDate+�� 5E      -
   5        $��label3��5G      #��[  5F      $
��Left=�6@   $��
519,10,0,0q�6[   $	��Top=�5G   *   ��5E        $!	 Client.Properties.Resources��$
 EndDate��5G   *     5H      -   5        $��datePicker2��5H   P   $
��Left=�6!   $��
625,12,0,0q�6<   $	��Top=�5I   !    69   �� *	EndDate+�� 5J      -   5        $��label4��5L      #��[  5K      $
��Left=�6@   $��1,42,0,0q�6[   $	��Top=�5L   *   ��5J        $!	 Client.Properties.Resources��$
 BP��5L   *   �� 5M      -   5        $��textBox2��5M   Y   $��23��6   $
��Left=�6*   $��
107,44,0,0q�6E   $	��Top=�5N      $	��120��66   {�.  ��6T   �� *BusinessPartnerName+�� 5O      -   5        $��button2��5O   f   $	��...��6   $��23��6+   $
��Left=�67   $��
231,44,0,0q�6R   $	��Top=�5P      $��25��65   6@   �� 5Q      -   5        $��label5��5S      #��[  5R      $
��Left=�6@   $��
260,42,0,0q�6[   $	��Top=�5S   *   ��5Q        $!	 Client.Properties.Resources��$
 InternalCustomer��5S   *   �� 5T      -   5        $��	comboBox1��5T   N   $
��Left=�6   $��
366,44,0,0q�6:   $	��Top=�6_    �� DisplayMemberPath$ 	ShortName��5U   I    �� SelectedValuePath$ Id��5V      ��5U      �� *InternalCustomers+ �� SelectedValue 5V   6   �� *SelectedInternalCustomerId+�� 5W      -   5        $��label6��5Y   0   $
��Left=�5X      #��[  67   $��
519,42,0,0q�5Y      $	��Top=�6>   ��5W        $!	 Client.Properties.Resources��$
 FinancialStatus��5Y   >   �� 5Z      -   5        $��	comboBox2��5Z   N   $
��Left=�6   $��
625,44,0,0q�6:   $	��Top=�6_   $
 Name��5[   I   $ Id��6b   ��6   �� *FinancialStatuses+ 5\      �� *SelectedFinancialStatus+�� 5]      -   5        $��label7��5_      #��[  5^      $
��Left=�6@   $��1,74,0,0q�6[   $	��Top=�5_   *   ��5]        $!	 Client.Properties.Resources��$
 
ShipStatus��5_   *   �� 5`      -   5        $��	comboBox3��5`   N   $
��Left=�6   $��
107,76,0,0q�6:   $	��Top=�6_   $
 Name��5a   H   $ Id��6a   ��6   �� *DeliveryStatuses+ 5b      �� *SelectedDeliveryStatus+�� 5c      -   5        $��label8��5e      $
��Left=�5d      #��[  67   $��
260,74,0,0q�6[   $	��Top=�5e   *   
���<����5c        $!	 Client.Properties.Resources��$
 	TradeType��5e   B   �� 5f      -   5        $��	comboBox4��5f   Z   $��23��6   $
��Left=�6+   $��
366,76,0,0q�6F   $	��Top=�5g      $	��120��67   $
 Name��5h      $ Id��68   ��5g   C   �� *BusinessTypes+ 5i      �� *SelectedBusinessType+�� 5j      -   5        $��button3��5k   L   $��23��5j   ^   $
��Left=�5k      $��
568,76,0,0q�68   $	��Top=�6[   $��75��5l      ��5j        $!	 Client.Properties.Resources��$
 Query��5l   (   �� 5m      -   5        $��button4��5n   L   $��23��5m   ^   $
��Left=�5n      $��
670,76,0,0q�68   $	��Top=�6[   $��75��5o      ��5m        $!	 Client.Properties.Resources��$
 Reset��5o   (   5p      5q      �� 5r      -   5        $��
separator1��5r   7   $��17��6   $��	6,176,6,0q�6$   $	��Top=�6I   $  Utility.Controls.PagingControl  5s      -   5        $��pagingControl1��5s   M   $
��Left=�6   $��	6,193,0,0q�6:   $	��Top=�5t      $��31��67   &   System.Windows.Controls.DataGrid  5u      -   5        $��	dataGrid1��5v         AutoGenerateColumns .  $
��Auto��5u   3   $
��Left=�6A   $��	6,230,0,0q�6\   $	��Top=�5w      $
��Auto��6/      
IsReadOnly .   DataGridStyle#��[ 5x        DataGridRowStyle   RowStyle# [ 6>   ��5w   <   �� *	Results+   Columns 5y      0	  *System.Windows.Controls.DataGridTextColumn	  5z      ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5{   E    
  CanUserSort .   DataGridColumnHeaderStyle 
  HeaderStyle# [ 5|   )    
  Header 5z   )     $!	 Client.Properties.Resources��$
 QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5{   )   �� *	QuotaNo+5}      	  5~      $
 Auto 5   l    . # [ 5�   <    5~   )     $!	 Client.Properties.Resources��$

 Date�� 5   )   �� *ImplementedDate+ �� StringFormat$ {0:yyyy-MM-dd}��5�      	  5�      $
 Auto 5�   Q    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 BP�� 5�   )   �� *BusinessPartnerName+5�      	  5�      $
 Auto 5�   K    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 	Commodity�� 5�   )   �� *CommodityName+5�      	  5�      $
 Auto 5�   G    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 Brand�� 5�   )   �� *	BrandName+5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 ActualQuantity�� 5�   )   �� *ActualQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 Price�� 5�   )   �� *Price+   	STR_PRICE# Z 5�      	  5�      $
 Auto 5�   J    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 Currency�� 5�   )   �� *CurrencyName+5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 
Receivable�� 5�   )   �� *ReceivableAmount+   
STR_AMOUNT# Z 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 Payable�� 5�   )   �� *PayableAmount+# Z 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $#	 Client.View.Reports.ResReport��$
 Received�� 5�   )   �� *ReceivedAmount+# Z 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 
PaidAmount�� 5�   )   �� *
PaidAmount+# Z 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $#	 Client.View.Reports.ResReport��$
 AmountRemain�� 5�   )   �� *RemainAmount+# Z 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $#	 Client.View.Reports.ResReport��$
 VATInvoicedQty�� 5�   )   �� *VATQuantity+# Z 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 FinancialStatus�� 5�   )   �� *FinancialStatusId+ �� 	Converter# [ 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 
ShipStatus�� 5�   )   �� *DeliveryStatusId+# [ 5�      	  5�      $
 Auto 5�   )    . # [ 5�   )    5�   )     $!	 Client.Properties.Resources��$
 InvoicedStatus�� 5�   )   �� *	VATStatus+# [ 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      # [ 5�   -   $
 Auto 6f    .   5�   -     $!	 Client.Properties.Resources��$
 	Operation��   CellTemplate 5�      �� 5�       �� DataType$% Reports:QuotaStatusChangeLineVM��6+   .R�5�   "   �� #��[ 5�   )   ��5�   )     $#	 Client.View.Reports.ResReport��$
 ChangeStatus����5�   Q   �� *	QuotaId+5�   #   5�      5�      5�      5�      5�      5�      