   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity >   8Client.View.Physical.VATInvoices.VATInvoiceRequestDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *VATInvoiceRequest+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker 
 Delete  Edit  Actions �� DataType �� Orientation	   ResxName

   Key.  (Client.Converters.ApproveStatusConverter  asConverter��%�  &	        '�� �     '�� �     '  �     &	 .    &	 3    &	 8    7  7  &	 =    �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� $$ DBEntity:VATInvoiceRequestLine��.R��� $ 
Horizontal=�.+��� $��btEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��	btnDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+   J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *VATInvoiceRequest+�� -   $��label7��#��[  $
��Left=�$��6,38,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 Buyer���� -   $��textBox5��$
��Left=�$��
122,40,0,0q�$	��Top=�{�.  ���� *BPName+�� -   $��button2��$	��...��$��23��$
��Left=�$��
246,40,0,0q�$	��Top=�$��25���� -   $��label13��#��[  $
��Left=�$��
278,38,0,0q�$	��Top=�
���<����  *	InvoiceBP+�� -	   $��	comboBox5��$
��Left=�$��
394,40,0,0q�$	��Top=� �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 	ShortName������ *InternalBPs+ �� SelectedValue �� *InternalBPId+�� -
   $��label9��#��[  $
��Left=�$��6,70,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 	ApplyDate��  -   $��datePicker1��$
��Left=�$��
122,72,0,7q�$	��Top=�   SelectedDate �� *RequestDate+&   System.Windows.Controls.DataGrid  -   $��vatdataGrid��   AutoGenerateColumns .  $
��Left=�$��	122,2,0,7q�$	��Top=�   
IsReadOnly . $��2��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	    CanUserSort .    Header   $!	 Client.Properties.Resources��$
 QuotaNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Quota.QuotaNo+  $
 Auto	  .    $!	 Client.Properties.Resources��$
 Quantity�� �� *UnOpenedQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z   $
 Auto	  .    $!	 Client.Properties.Resources��$
 AppliedAmount�� �� *RequestAmount+   
STR_AMOUNT# Z   $
 Auto	  .    $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 InvoicePrice�� �� *RequestPrice+   	STR_PRICE# Z   $
 Auto	  .    $!	 Client.Properties.Resources��$
 ApplyQuantity�� �� *RequestQuantity+# Z   $ 申请已开数量��$
 Auto	  .  �� *VATInvoicedQuantity+# Z   $
 Auto	  .    $!	 Client.Properties.Resources��$
 ApprovalStatus�� �� *ApproveStatus+ �� 	Converter# [ 4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto	  .     CellTemplate# [    $!	 Client.Properties.Resources��$
 	Operation��$   Utility.Controls.PagingControl  -   $��	pagerList��$
��Left=�$��	122,0,0,0q�$	��Top=�$��2��$y�	Collapsed=��� -   $��label15��#��[  $
��Left=�$��6,0,0,0q�$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 Comments���� -   $��textBox7��$	��100��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��392��$��3������ *	Comment+�� -   $��button3��$��23��$
��Left=�$��210,130,0,0q�$	��Top=�$��60��$��3����  $!	 Client.Properties.Resources��$

 Save���� -   $��button4��$��23��$
��Left=�$��305,130,0,0q�$	��Top=�$��60��$��3����  $!	 Client.Properties.Resources��$
 Cancel���� -   $��button5��$��23��$y�Hidden=�$
��Left=�$��378,134,0,0q�$	��Top=�$��60��$��3����  $!	 Client.Properties.Resources��$
 SaveAsDraft���� -   $��button6��$��23��$
��Left=�$��	122,2,0,7q�$	��Top=�$��45��$��1����  $!	 Client.Properties.Resources��$
 AddWithSymbol���� -   $��label2��#��[  $��1��$
��Left=�$��6,0,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Detail���� -   $��button1��$��+批量新增��$��23��$
��Left=�$��	173,2,0,7q�$	��Top=�$��75��$��1��