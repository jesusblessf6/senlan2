   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity <    6Client.View.Physical.VATInvoices.VATInvoiceRequestList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��$
��auto�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *VATInvoiceRequestList+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker  ListEdit  
ListDelete  	Operation  ListActions �� DataType �� Orientation	   ResxName

   Key  ListOperations.   (Client.Converters.ApproveStatusConverter  asConverter��%5  &	        '�� ~     '�� �     '  �     &	 ,    &	 1    &	 6    &	 ;    7  7  &	 C    7  &	 �    �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$ 90����  � ��$ 90����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� �� $  DBEntity:VATInvoiceRequest��.R��� $ 
Horizontal=�.+��� $��
btListEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��btListDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+�� $  DBEntity:VATInvoiceRequest��.R��� $ 
Horizontal=�.+��� $��btOpenInvoice��$��开票��8��  ���� *Id+   J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $
��443* �.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *VATInvoiceRequestList+�� $ 
Horizontal=�$��6,0,0,0q�$��1��$
��Left=�$
��Auto��$
��Auto��$	��Top=�.+�$  Utility.Controls.PagingControl  -     Name$ 	pagerList��$
��Left=�$	��Top=��� $��	总数量��
���  ��$��10,0,0,0q�$��Bottom=��� $��10,0,0,0q�$��Bottom=����� *TotalQuantity+�� $��	总金额��
���  ��$��10,0,0,0q�$��Bottom=��� $��10,0,0,0q�$��Bottom=����� *TotalAmount+�� -   $��button1��$��导出Excel��$��23��$��20,0,0,0q�$��75��$y�	Collapsed=��� -   $��button2��$��批量开票��$��23��$��75��$��10,0,0,0q�$��Bottom=�$y�Hidden=�&   System.Windows.Controls.DataGrid  -	     Name$ listGrid��$��6,37,0,0q�   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $
��Left=�$
��auto��$	��Top=�$��1��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
  	  
IsReadOnly .  	  
Visibility$ Hidden=� 	  Header �� -
   $��cbSelectAll��$��全选��$��Center=�$��Center=� d� 	IsChecked �� *	SelectAll+   CellTemplate �� $$ DBEntity:VATInvoiceRequestLine��.R��� $��Center=�$��Center=� �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *InvoiceSelectedEnable+0  *System.Windows.Controls.DataGridTextColumn  $
 Auto
    $!	 Client.Properties.Resources��$
 Buyer��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *(&VATInvoiceRequest.BusinessPartner.Name+  $
 Auto
    $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 	InvoiceBP�� �� *.,VATInvoiceRequest.InternalCustomer.ShortName+  $
 Auto
 $ 创建日期�� �� *VATInvoiceRequest.Created+ �� StringFormat$ yyyy-MM-dd HH:mm��  $
 Auto
    $!	 Client.Properties.Resources��$
 QuotaNo�� �� *Quota.QuotaNo+  $
 Auto
    $!	 Client.Properties.Resources��$
 	Commodity�� �� *Quota.Commodity.Name+  $
 Auto
    $!	 Client.Properties.Resources��$
 CommodityType�� �� *Quota.CommodityType.Name+  $
 Auto
    $!	 Client.Properties.Resources��$
 Brand�� �� *Quota.Brand.Name+  $
 Auto
    $!	 Client.Properties.Resources��$
 Quantity�� �� *Quota.VerifiedQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z   $
 Auto
    $!	 Client.Properties.Resources��$
 ApplyQuantity�� �� *RequestQuantity+# Z   $
 Auto
 $ 申请已开数量�� �� *VATInvoicedQuantity+# Z   $
 Auto
    $!	 Client.Properties.Resources��$
 AppliedAmount�� �� *RequestAmount+   
STR_AMOUNT# Z   $
 Auto
    $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 InvoicePrice�� �� *RequestPrice+    	STR_PRICE# Z    $
 Auto
    $!	 Client.Properties.Resources��$
 Approval�� �� *Approval.Name+  $
 Auto
 ! 	  CanUserSort! .     $!	 Client.Properties.Resources��$
 ApprovalDetail�� �� $$ DBEntity:VATInvoiceRequestLine��.R��� �� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+  $
 Auto
    $!	 Client.Properties.Resources��$
 ApprovalStatus�� �� *ApproveStatus+" �� 	Converter#" [   $
 Auto
    $!	 Client.Properties.Resources��$
 RejectReason�� �� *RejectReason+  $
 Auto
 ! .  # [    $!	 Client.Properties.Resources��$
 	Operation��  $
 Auto
 ! .  # [ $ Hidden=�   $!	 Client.Properties.Resources��$
 	Operation���� -   $��grid1��$	��100��$
��Left=�$��6,40,0,0q�$	��633��$y�	Collapsed=�$	��Top=���  $!	 Client.Properties.Resources��$
 
Conditions��.��� .+��� -   $��label6��#��[  $��1,10,0,0q�$	��Top=�$��90��$
��Left=���  $!	 Client.Properties.Resources��$
 Buyer���� -   $��textBox3��$
��Left=�$��	97,12,0,0q�$	��Top=����� *BPName+�� -   $��button5��$	��...��$��23��$
��Left=�$��
221,12,0,0q�$	��Top=�$��25���� -   $��label4��$
��Left=�#��[  $��
256,10,0,0q�$	��Top=���  *	InvoiceBP+�� -   $��	comboBox3��# �� DisplayMemberPath$# 	ShortName��$
��Left=�$��
352,12,0,0q�$ �� SelectedValuePath$$ Id��$	��Top=����� *InternalBPs+% �� SelectedValue% �� *InternalBPId+  -   $��datePicker1��$
��Left=�$��	97,44,0,0q�$	��Top=�&   SelectedDate& �� *RequestStartDate+  -   $��datePicker2��$
��Left=�$��
352,44,0,0q�$	��Top=�& �� *RequestEndDate+�� -   $��	btnSearch��$��23��$
��Left=�$��
487,44,0,0q�$	��Top=�$��75����  $!	 Client.Properties.Resources��$
 Query���� -   $��label10��#��[  $��1,42,0,0q�$	��Top=�$��90��$
��Left=���  $!	 Client.Properties.Resources��$
 	StartDate���� -   $��label11��#��[  $
��Left=�$��
256,42,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 EndDate���� -   $��
separator1��$��13��$��	7,145,5,0q�$	��Top=�$y�	Collapsed=�