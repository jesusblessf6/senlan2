   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 6C   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      <    6Client.View.Physical.VATInvoices.VATInvoiceRequestList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     6C   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��5      $
��auto��5   %    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *VATInvoiceRequestList+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker  ListEdit  
ListDelete  	Operation  ListActions �� DataType �� Orientation	   ResxName

   Key  ListOperations.   (Client.Converters.ApproveStatusConverter  asConverter��%Y  &	        '�� �     '�� k    '  �    &	 Y    &	 l    &	     &	 �    7  7  &	 
    7  &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$ 90��6&   63   �� 5       � ��$ 90��6)   66   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5       �� 5"   
   "  6   .�5#      ��  � ��$ 23��6'   64   �� 5$       � ��$	 120��6&   64   5%      �� 5'   
   6+   �� 5(   
   6-   �� 5)   
   6,   �� 5*   
   $  DBEntity:VATInvoiceRequest��6+   .R�5+      �� $ 
Horizontal=�6   .+�5,      �� $��
btListEdit��6   8��  ��6+     $!	 Client.Properties.Resources��$

 Edit����5-      �� *Id+6;   �� 5.      $��btListDelete��6   8�� ��6-     $!	 Client.Properties.Resources��$
 Delete����5/      �� *Id+6;   50      51      �� 52   
   $  DBEntity:VATInvoiceRequest��6.   .R�53      �� $ 
Horizontal=�6   .+�54      �� $��btOpenInvoice��6   $��开票��6.   8��  ��55      �� *Id+6;   56      57        58   
   6B   59       J� CommandBindings 5;      )  #System.Windows.Input.CommandBinding  5<   
   -   5           Command# [ 5<      5=   7     5>   
   -   5        # [ 5>      5?   9     5@   
   -   5        # [ 5@      5A   8   .��5D      �� $
��Auto=�6   $
��Auto=�68   .��5E   
   � -   5         �Name$ rootGrid��5E       � RowDefinitions 5F      �� 5G      $
��Auto �6    �� 5H      $
��443* �6    .+�5J      �� -   5        $��lbTitle��5J   ;   $��32��6J   $
��Left=�6V   $��6,6,0,0q�6q   $
��auto��5K      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5J        *VATInvoiceRequestList+5K   K   �� 5L      $ 
Horizontal=�6   $��6,0,0,0q�62   $��1��6C   $
��Left=�6P   $
��Auto��6k   $
��Auto��6x   $	��Top=�6�   .+�5M      $  Utility.Controls.PagingControl  -   5          Name$ 	pagerList��5M   #   $
��Left=�66   $	��Top=�6Q   �� 5N      $��	总数量��6   
���  ��$��10,0,0,0q�67   $��Bottom=�6I   6m   �� 5O      $��10,0,0,0q�6:   $��Bottom=�6L   ��6   �� *TotalQuantity+6p   �� 5P      $��	总金额��6   
���  ��$��10,0,0,0q�67   $��Bottom=�6I   6m   �� 5Q      $��10,0,0,0q�68   $��Bottom=�6J   ��6   �� *TotalAmount+6n   �� 5R      -   5        $��button1��5R   I   $��导出Excel��6   $��23��6+   $��20,0,0,0q�67   $��75��6X   6c   �� 5S      -   5        $��button2��5S   4   $��批量开票��6   $��23��6(   $��75��6C   $��10,0,0,0q�6N   $��Bottom=�6`   $y�Hidden=�6�   5T      &   System.Windows.Controls.DataGrid  5V      -	   5          Name$ listGrid��5V   )   $��6,37,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $
��Left=�5W   I   $
��auto��6d   $	��Top=�6q   $��1��5X         Columns 5Y      4  .System.Windows.Controls.DataGridTemplateColumn  5Z      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 6-    	  
IsReadOnly .  	  
Visibility$ Hidden=�6L    	  Header 5[      �� 5\      -
   5        $��cbSelectAll��5\   G   $��全选��6Z   $��Center=�6g   $��Center=�6�    d� 	IsChecked 6'   �� *	SelectAll+6�      CellTemplate 5^      �� 5_      $$ DBEntity:VATInvoiceRequestLine��6+   .R�5`   "   �� $��Center=�6�   $��Center=�6�    6+   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{�6q   �� *InvoiceSelectedEnable+6�   5a      5c      0  *System.Windows.Controls.DataGridTextColumn  5d      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 Buyer��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5e   )   �� *(&VATInvoiceRequest.BusinessPartner.Name+  5f      $
 Auto
 6)    66     $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 	InvoiceBP�� 5g   )   �� *.,VATInvoiceRequest.InternalCustomer.ShortName+  5h      $
 Auto
 6)   $ 创建日期��66    5i   )   �� *VATInvoiceRequest.Created+ �� StringFormat$ yyyy-MM-dd HH:mm��  5j      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 QuotaNo�� 6x   �� *Quota.QuotaNo+  5k      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 	Commodity�� 6z   �� *Quota.Commodity.Name+  5l      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 CommodityType�� 6~   �� *Quota.CommodityType.Name+  5m      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 Brand�� 6v   �� *Quota.Brand.Name+  5n      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 Quantity�� 6y   �� *Quota.VerifiedQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z   5o      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 ApplyQuantity�� 6~   �� *RequestQuantity+# Z   5p      $
 Auto
 6)   $ 申请已开数量��66    6F   �� *VATInvoicedQuantity+# Z   5q      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 AppliedAmount�� 6~   �� *RequestAmount+   
STR_AMOUNT# Z   5r      $
 Auto
 6)    66     $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 InvoicePrice�� 6�   �� *RequestPrice+    	STR_PRICE# Z    5s      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 Approval�� 6y   �� *Approval.Name+  5t      $
 Auto
 6-   ! 	  CanUserSort! .   6:     $!	 Client.Properties.Resources��$
 ApprovalDetail�� 5u      �� 5v      $$ DBEntity:VATInvoiceRequestLine��6+   .R�5w   "   �� �� 5x   &   
��� � ��6=   �� *CustomerStrField1+6b    �� 5y   &   
���  ���6;   �� *CustomerStrField2+6`   5z   #   5{      5}        5~      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 ApprovalStatus�� 5   )   �� *ApproveStatus+" �� 	Converter#" [ 6u     5�      $
 Auto
 6)    66     $!	 Client.Properties.Resources��$
 RejectReason�� 6}   �� *RejectReason+6�     5�      $
 Auto
 6q   ! .  # [ 5�   -    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�   [     5�      $
 Auto
 6q   ! .  # [ 5�   -   $ Hidden=�6\    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�   r   5�      �� 5�      -   5        $��grid1��5�   �   $	��100��6\   $
��Left=�6i   $��6,40,0,0q�6�   $	��633��6�   $y�	Collapsed=�5�      $	��Top=�6.   ��5�        $!	 Client.Properties.Resources��$
 
Conditions��.��5�      � .+�5�      �� -   5        $��label6��5�   .   #��[  5�   ]   $��1,10,0,0q�5�      $	��Top=�6<   $��90��6T   $
��Left=�6_   ��5�        $!	 Client.Properties.Resources��$
 Buyer��5�   _   �� 5�      -   5        $��textBox3��5�   L   $
��Left=�6   $��	97,12,0,0q�69   $	��Top=�5�   6   ��6   �� *BPName+66   �� 5�      -   5        $��button5��5�   f   $	��...��6   $��23��6+   $
��Left=�67   $��
221,12,0,0q�6R   $	��Top=�5�      $��25��65   6@   �� 5�      -   5        $��label4��5�   0   $
��Left=�5�   7   #��[  6R   $��
256,10,0,0q�5�      $	��Top=�6>   ��5�        *	InvoiceBP+5�   >   �� 5�      -   5        $��	comboBox3��5�   W   # �� DisplayMemberPath$# 	ShortName��5�      $
��Left=�6=   $��
352,12,0,0q�5�   C   $ �� SelectedValuePath$$ Id��5�      $	��Top=�66   ��5�      �� *InternalBPs+% �� SelectedValue% 6h   �� *InternalBPId+5�   6     5�      -   5        $��datePicker1��5�   O   $
��Left=�6!   $��	97,44,0,0q�6<   $	��Top=�5�   K   &   SelectedDate& 6!   �� *RequestStartDate+6K     5�      -   5        $��datePicker2��5�   P   $
��Left=�6!   $��
352,44,0,0q�6<   $	��Top=�5�   I   & 6!   �� *RequestEndDate+6I   �� 5�      -   5        $��	btnSearch��5�   �   $��23��6^   $
��Left=�6j   $��
487,44,0,0q�6�   $	��Top=�5�      $��75��65   ��5�        $!	 Client.Properties.Resources��$
 Query��5�   @   �� 5�      -   5        $��label10��5�   .   #��[  5�   a   $��1,42,0,0q�5�      $	��Top=�6=   $��90��6U   $
��Left=�6`   ��5�        $!	 Client.Properties.Resources��$
 	StartDate��5�   `   �� 5�      -   5        $��label11��5�   �   #��[  6_   $
��Left=�6�   $��
256,42,0,0q�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 EndDate��6�   5�      5�      �� 5�      -   5        $��
separator1��5�   7   $��13��6   $��	7,145,5,0q�6$   $	��Top=�6I   $y�	Collapsed=�6a   5�      5�      5�      