   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 6C   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      5    /Client.View.Physical.VATInvoices.VATInvoiceList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     6C   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *VATInvoiceList+ � 	Resources 5      *   $Client.Converters.VATStatusConverter   ConvertStatus/   )Client.Converters.VATInvoiceTypeConverter  ConvertVATInvoiceTypes  ListEdit  
ListDelete  ListActions �� DataType �� Orientation   ResxName
   Key��%�  &	        &	      &	 &     &	 9     &	 L     7  7    5   
   6(     5   
   6-   �� 5   
   6+   �� 5   
   6-   �� 5   
   $ DBEntity:VATInvoice��6+   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��
btListEdit��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btListDelete��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [ 5      6{     5    
   -   5        #	 [ 5       5!   9   .��5$      �� $
��Auto=�6   $
��Auto=�68   .��5%   
   � -   5        
 �Name$
 rootGrid��5%      .+�5&      �� -   5        $��lbTitle��5&   4   $��32��6C   $
��Left=�6O   $��6,6,0,0q�6j   $
��auto��6{   $	��Top=�5'      $
��Bold"�6,   $��16(�6>   ��5&        *VATInvoiceList+5'   >   �� 5(      $ 
Horizontal=�6   $��6,40,0,0q�62   $��1��6D   $
��Left=�6Q   $
��Auto��6l   $
��Auto��6y   $	��Top=�6�   .+�5)      $  Utility.Controls.PagingControl  -   5          Name$ 	pagerList��5)   #   $
��Left=�66   $	��Top=�6Q   �� 5*      $��	总数量��6   
���  ��$��10,0,0,0q�67   $��Bottom=�6I   6m   �� 5+      $��10,0,0,0q�6:   $��Bottom=�6L   ��6   �� *TotalQuantity+6q   �� 5,      $��	总金额��6   
���  ��$��10,0,0,0q�67   $��Bottom=�6I   6m   �� 5-      $��10,0,0,0q�68   $��Bottom=�6J   ��6   �� *TotalAmount+6o   �� 5.      -   5        $��button1��5.   7   $��导出Excel��6   $��23��6+   $��75��6F   $��10,0,0,0q�6Q   $��Bottom=�6c   6�   5/      &   System.Windows.Controls.DataGrid  51      -   5          Name$ listGrid��51   )   $��6,77,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $	��Top=�52   I   $
��Left=�6a   $
��auto��6|      Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 6)    	  Header 66     $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6x   �� *Quota.QuotaNo+6�     56      $
 auto
 6)    66     $! Client.Properties.Resources��$ Supplier�� 6y   �� *!VATInvoice.BusinessPartner.Name+  57      $
 auto
 6)    66     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 	InvoiceBP�� 6�   �� *" VATInvoice.BusinessPartner1.Name+  58      $
 auto
 6)    66     $! Client.Properties.Resources��$ InvoiceDate�� 59   )   �� *VATInvoice.InvoicedDate+ �� StringFormat$ 
yyyy-MM-dd��  5:      $
 auto
 6)   $ 批次未开数量��66    6F   �� *UnOpenedQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z   5;      $
 auto
 6)    66     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ 
InvoiceQty�� 6�   �� *VATInvoiceQuantity+# Z   5<      $
 auto
 6)    	  
Visibility$ Hidden=�6�    66     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicedQty�� 6�   �� *Quota.VATInvoicedQuantity+# Z 6�     5=      $
 auto
 6)    66     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoiceAmount�� 6�   �� *	VATAmount+   
STR_AMOUNT# Z   5>      $
 auto
 6)    66     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ InvoicePrice�� 6�   �� *
VATPrice+   	STR_PRICE# Z   5?      $
 auto
 6)    66     $4 .Client.View.Physical.VATInvoices.ResVATInvoice��$ OpenInvoiceStatus�� 5@   )   �� *Quota.VATStatus+ �� 	Converter# [    5A      $
 auto
 6)   $ 
开/收票��66    5B   )   �� *VATInvoice.VATInvoiceType+# [ 4  .System.Windows.Controls.DataGridTemplateColumn  5C      $
 Auto
 6q    	  CanUserSort .     CellTemplate# [ 5D   -    5C   -     $! Client.Properties.Resources��$ 	Operation��5D   [   5F      5G      5H      5I      