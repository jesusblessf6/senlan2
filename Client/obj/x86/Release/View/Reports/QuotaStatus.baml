   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C&clr-namespace:Client.ViewModel.ReportsClient.ViewModel.Reports  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity %    Client.View.Reports.QuotaStatus   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     :Reports&clr-namespace:Client.ViewModel.Reports     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *QuotaStatusChange+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker  ChangeStatus/   )Client.Converters.CompleteStatusConverter  CompleteStatusConverter*   $Client.Converters.VATStatusConverter  VATStatusConverter��%?  &	        '�� �     '  �     &	 �     &	 �     &	 �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120����      J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$��16(�$
��Bold"���  *QuotaStatusChange+�� -   $��	groupBox1��$	��130��$
��Left=�$��6,40,0,0q�$	��Top=�$	��800����  	   ResxName$!	 Client.Properties.Resources��

   Key$
 
Conditions��.��� .+��� -   $��label1��#��[  $
��Left=�$��1,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Quota���� -   $��textBox1��$��23��$
��Left=�$��
107,12,0,0q�$	��Top=�$	��120��{�.  ���� *	QuotaNo+�� -   $��button1��$	��...��$��23��$
��Left=�$��
231,12,0,0q�$	��Top=�$��25���� -   $��label2��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	StartDate��  -	   $��datePicker1��$
��Left=�$��
366,12,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -
   $��label3��#��[  $
��Left=�$��
519,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 EndDate��  -   $��datePicker2��$
��Left=�$��
625,12,0,0q�$	��Top=� �� *	EndDate+�� -   $��label4��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 BP���� -   $��textBox2��$��23��$
��Left=�$��
107,44,0,0q�$	��Top=�$	��120��{�.  ���� *BusinessPartnerName+�� -   $��button2��$	��...��$��23��$
��Left=�$��
231,44,0,0q�$	��Top=�$��25���� -   $��label5��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 InternalCustomer���� -   $��	comboBox1��$
��Left=�$��
366,44,0,0q�$	��Top=� �� DisplayMemberPath$ 	ShortName�� �� SelectedValuePath$ Id������ *InternalCustomers+ �� SelectedValue �� *SelectedInternalCustomerId+�� -   $��label6��$
��Left=�#��[  $��
519,42,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 FinancialStatus���� -   $��	comboBox2��$
��Left=�$��
625,44,0,0q�$	��Top=�$
 Name��$ Id������ *FinancialStatuses+ �� *SelectedFinancialStatus+�� -   $��label7��#��[  $
��Left=�$��1,74,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 
ShipStatus���� -   $��	comboBox3��$
��Left=�$��
107,76,0,0q�$	��Top=�$
 Name��$ Id������ *DeliveryStatuses+ �� *SelectedDeliveryStatus+�� -   $��label8��$
��Left=�#��[  $��
260,74,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 	TradeType���� -   $��	comboBox4��$��23��$
��Left=�$��
366,76,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *BusinessTypes+ �� *SelectedBusinessType+�� -   $��button3��$��23��$
��Left=�$��
568,76,0,0q�$	��Top=�$��75����  $!	 Client.Properties.Resources��$
 Query���� -   $��button4��$��23��$
��Left=�$��
670,76,0,0q�$	��Top=�$��75����  $!	 Client.Properties.Resources��$
 Reset���� -   $��
separator1��$��17��$��	6,176,6,0q�$	��Top=�$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��	6,193,0,0q�$	��Top=�$��31��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,230,0,0q�$	��Top=�$
��Auto��   
IsReadOnly .   DataGridStyle#��[   DataGridRowStyle   RowStyle# [ ���� *	Results+   Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  
  CanUserSort .   DataGridColumnHeaderStyle 
  HeaderStyle# [  
  Header   $!	 Client.Properties.Resources��$
 QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	QuotaNo+	  $
 Auto  . # [    $!	 Client.Properties.Resources��$

 Date�� �� *ImplementedDate+ �� StringFormat$ {0:yyyy-MM-dd}��	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 BP�� �� *BusinessPartnerName+	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 	Commodity�� �� *CommodityName+	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 Brand�� �� *	BrandName+	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 ActualQuantity�� �� *ActualQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 Price�� �� *Price+   	STR_PRICE# Z 	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 Currency�� �� *CurrencyName+	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 
Receivable�� �� *ReceivableAmount+   
STR_AMOUNT# Z 	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 Payable�� �� *PayableAmount+# Z 	  $
 Auto  . # [    $#	 Client.View.Reports.ResReport��$
 Received�� �� *ReceivedAmount+# Z 	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 
PaidAmount�� �� *
PaidAmount+# Z 	  $
 Auto  . # [    $#	 Client.View.Reports.ResReport��$
 AmountRemain�� �� *RemainAmount+# Z 	  $
 Auto  . # [    $#	 Client.View.Reports.ResReport��$
 VATInvoicedQty�� �� *VATQuantity+# Z 	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 FinancialStatus�� �� *FinancialStatusId+ �� 	Converter# [ 	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 
ShipStatus�� �� *DeliveryStatusId+# [ 	  $
 Auto  . # [    $!	 Client.Properties.Resources��$
 InvoicedStatus�� �� *	VATStatus+# [ 4  .System.Windows.Controls.DataGridTemplateColumn  # [ $
 Auto  .     $!	 Client.Properties.Resources��$
 	Operation��   CellTemplate ��  �� DataType$% Reports:QuotaStatusChangeLineVM��.R��� #��[ ��  $#	 Client.View.Reports.ResReport��$
 ChangeStatus������ *	QuotaId+