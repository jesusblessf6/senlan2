   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 6    0Client.View.Physical.Payments.PaymentRequestList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *PaymentRequestList+ � 	Resources .   (Client.Converters.ApproveStatusConverter   ApproveStatusConverter5   /Client.Converters.PaymentRequestStatusConverter ! PaymentRequestStatusConverter  PaymentRequestEdit  PaymentRequestDelete  PaymentRequestPrint  PaymentRequestActions �� DataType �� Orientation   ResxName
   Key��%�  &	        &	      &	 
     &	      &	      &	      7  7  7      �� �� �� �� $ DBEntity:PaymentRequest��.R��� $ 
Horizontal=�.+��� $��btPaymentRequestEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btPaymentRequestDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $��btPaymentRequestPrint��$��打印��8�� $y�Hidden=����� *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [   -   #	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -   
 �Name$
 rootGrid��.+��� $ 
Horizontal=�$��6,40,0,0q�$
��Auto��$
��Auto��$	��Top=�$
��Left=�.+�$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$	��Top=��� -   $��打印付款申请��$��10,0,0,0q�$��23���� -   $��label1��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *PaymentRequestList+&   System.Windows.Controls.DataGrid  -     Name$ contractGrid��   AutoGenerateColumns .  $��6,77,0,0q�$	��Top=�   
IsReadOnly . $
��Left=�  DataGridStyle#��[   DataGridRowStyle   RowStyle# [ ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
  	  
IsReadOnly .  	  Header �� -	   $��cbSelectAll��$��全选��$��Center=�$��Center=� d� 	IsChecked �� *IsSelectAll+   CellTemplate �� $ DBEntity:PaymentRequest��.R��� $��Center=�$��Center=� �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *	Printable+0  *System.Windows.Controls.DataGridTextColumn    DataGridColumnHeaderStyle 	  HeaderStyle# [    $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Quota.QuotaNo+  # [    $! Client.Properties.Resources��$ ApplyDateShort�� �� *RequestDate+ �� StringFormat$ 
yyyy-MM-dd��  # [    $! Client.Properties.Resources��$ 	ReceiptBP�� �� *" ReceiveBusinessPartner.ShortName+  # [    $! Client.Properties.Resources��$ 	PaymentBP�� �� *PayBusinessPartner.ShortName+  # [    $! Client.Properties.Resources��$ AppliedAmount�� �� *RequestAmount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT# Z   # [    $! Client.Properties.Resources��$ PaymentCurrency�� �� *Currency.Name+  # [    $! Client.Properties.Resources��$ 
PaidAmount�� �� *
PaidAmount+# Z   # [    $! Client.Properties.Resources��$ PaymentMean�� �� *PaymentMean.Name+  # [    $! Client.Properties.Resources��$ PaymentUsage�� �� *PaymentUsage.Name+  # [    $. (Client.View.Physical.Payments.ResPayment��$ PaymentStatus�� �� *IsPaid+ �� 	Converter# [   # [    $. (Client.View.Physical.Payments.ResPayment��$ 	Applicant�� �� *	User.Name+  # [    $! Client.Properties.Resources��$ Approval�� �� *Approval.Name+   	  CanUserSort .  # [    $! Client.Properties.Resources��$ ApprovalDetail�� �� $ DBEntity:PaymentRequest��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+  # [    $! Client.Properties.Resources��$ ApprovalStatus�� �� *ApproveStatus+# [    # [    $! Client.Properties.Resources��$ RejectReason�� �� *RejectReason+  $
 auto
  .  # [ # [    $! Client.Properties.Resources��$ 	Operation��