   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5    /Client.View.Physical.VATInvoices.VATInvoiceList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *VATInvoiceList+ � 	Resources *   $Client.Converters.VATStatusConverter   ConvertStatus/   )Client.Converters.VATInvoiceTypeConverter  ConvertVATInvoiceTypes  ListEdit  
ListDelete  ListActions �� DataType �� Orientation   ResxName
   Key��%O  &	        &	      &	 
     &	      &	      7  7      �� �� �� $ DBEntity:VATInvoice��.R��� $ 
Horizontal=�.+��� $��
btListEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btListDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�.��� -   
 �Name$
 rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *VATInvoiceList+�� $ 
Horizontal=�$��6,40,0,0q�$��1��$
��Left=�$
��Auto��$
��Auto��$	��Top=�.+�$  Utility.Controls.PagingControl  -     Name$ 	pagerList��$
��Left=�$	��Top=��� $��	总数量��
���  ��$��10,0,0,0q�$��Bottom=��� $��10,0,0,0q�$��Bottom=����� *TotalQuantity+�� $��	总金额��
���  ��$��10,0,0,0q�$��Bottom=��� $��10,0,0,0q�$��Bottom=����� *TotalAmount+�� -   $��button1��$��导出Excel��$��23��$��75��$��10,0,0,0q�$��Bottom=�&   System.Windows.Controls.DataGrid  -     Name$ listGrid��$��6,77,0,0q�   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $	��Top=�$
��Left=�$
��auto��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
  	  Header   $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Quota.QuotaNo+  $
 auto
    $! Client.Properties.Resources��$ Supplier�� �� *!VATInvoice.BusinessPartner.Name+  $
 auto
    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 	InvoiceBP�� �� *" VATInvoice.BusinessPartner1.Name+  $
 auto
    $! Client.Properties.Resources��$ InvoiceDate�� �� *VATInvoice.InvoicedDate+ �� StringFormat$ 
yyyy-MM-dd��  $
 auto
 $ 批次未开数量�� �� *UnOpenedQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z   $
 auto
    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 
InvoiceQty�� �� *VATInvoiceQuantity+# Z   $
 auto
  	  
Visibility$ Hidden=�   $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicedQty�� �� *Quota.VATInvoicedQuantity+# Z   $
 auto
    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoiceAmount�� �� *	VATAmount+   
STR_AMOUNT# Z   $
 auto
    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicePrice�� �� *
VATPrice+   	STR_PRICE# Z   $
 auto
    $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ OpenInvoiceStatus�� �� *Quota.VATStatus+ �� 	Converter# [    $
 auto
 $ 
开/收票�� �� *VATInvoice.VATInvoiceType+# [ 4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto
  	  CanUserSort .     CellTemplate# [    $! Client.Properties.Resources��$ 	Operation��