   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5	      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6K   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      C   =Client.View.Physical.CommercialInvoices.CommercialInvoiceList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      6
Convertersclr-namespace:Client.Converters     6K   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   :     *CommercialInvoiceList+ � 	Resources 5      ,  &Client.Converters.InvoiceTypeConverter   InvoiceTypeConverter4  .Client.Converters.InvoicePrintVisibleConverter   InvoicePrintVisibleConverter0 *Client.Converters.NullEmptyInt2BoolReverse  	Null2Bool  InvoiceEdit  InvoiceDelete  InvoicePrint  PrintDocument  AttachmentView  InvoiceActions �� DataType �� Orientation   ResxName
   Key �� 	Converter��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     7  7  7  7  7  7  7  7  7    5   
   6*     5   
   62     5   
   6B   �� 5   
   6.   �� 5   
   60   �� 5   
   6/   �� 5   
   60   �� 5   
   61   �� 5   
   $  DBEntity:CommercialInvoice��6.   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btInvoiceEdit��6   8��  ��6.     $! Client.Properties.Resources��$
 Edit����5      �� *Id+{�69   �� *BaseCommercialInvoiceId+8  6�   �� 5      $��btInvoiceDelete��6   8�� ��60     $! Client.Properties.Resources��$ Delete����5      �� *Id+{�69   �� *BaseCommercialInvoiceId+8  6�   �� 5      $��btAttachmentView��6|   $��Right=�6`   8�� ��6     $! Client.Properties.Resources��$ 
Attachment����6�   �� *Id+6�   �� 5      $��btInvoicePrint��6   8�� ��6/     $! Client.Properties.Resources��$ Print��y�5       �� *Quota.Contract.ContractType+8  ��5!   A   �� *Id+6c   �� 5"      $��btDocumentPrint��6   $��打印单据��60   8�� y�5#      �� *Quota.Contract.ContractType+8  ��5$   B   �� *Id+6d   5&      5'      5)      	 J� CommandBindings	 5+      )  #System.Windows.Input.CommandBinding  5,   
   -   5        
   Command#
 [ 5,      5-   :     5.   
   -   5        #
 [ 5.      5/   <     50   
   -   5        #
 [ 50      51   ;     52   
   -   5        #
 [ 52      53   <     54   
   -   5        #
 [ 54      55   =   .��58      �� $
��Auto=�6   $
��Auto=�68   .��59   
   � -   5        $��rootGrid��59      .+�5:      �� -   5        $��lbTitle��5:      $��32��6#   $
��Left=�6/   $��6,6,0,0q�6J   $
��auto��6[   $	��Top=�5;      $
��Bold"�6,   $��16(�6>   &   System.Windows.Controls.DataGrid  5<      -   5          Name$ 	dataGrid1��5<   A   $��6,72,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $
��auto��5=   @   $	��Top=�6N   $
��Left=�6f   $
��auto��6�   ��5<   )   ��    Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$ CommInvoiceNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6q   �� *	InvoiceNo+  5@       6)     $! Client.Properties.Resources��$ QuotaNo�� 6k   �� *Quota.QuotaNo+  5A       6)     $! Client.Properties.Resources��$ Supplier�� 6l   �� **(Quota.Contract.BusinessPartner.ShortName+  5B       6)     $! Client.Properties.Resources��$ InternalCustomer�� 6t   �� *+)Quota.Contract.InternalCustomer.ShortName+  5C       6)     $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ InvoiceType�� 5D   )   �� *InvoiceType+# [    5E      $ 开票日期��6)    67   �� *InvoicedDate+ �� StringFormat$ 
yyyy/MM/dd��6t     5F       6)     $B <Client.View.Physical.CommercialInvoices.ResCommercialInvoice��$ RelatedInvoiceNo�� 6�   �� *FinalInvoice.InvoiceNo+  5G       6)     $! Client.Properties.Resources��$ 	Commodity�� 6m   �� *Quota.Commodity.Name+  5H      $ 结算金额��6)    67   �� *Amount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT# Z   5I       6)     $! Client.Properties.Resources��$ SettleCurrency�� 6r   �� *Currency.Name+  5J       6)     $! Client.Properties.Resources��$ GrossWeight�� 6o   �� *GrossWeights+   STR_QUANTITY# Z   5K       6)     $! Client.Properties.Resources��$ 	NetWeight�� 6m   �� *
NetWeights+# Z   5L       6)     $! Client.Properties.Resources��$ Comments�� 6l   �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  5M       	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6q    	  CanUserSort .     CellTemplate# [ 5N   -    5M   -     $! Client.Properties.Resources��$ 	Operation��5N   ^   5P      $   Utility.Controls.PagingControl  5Q      -	   5        $��pagingControl1��5Q   L   $
��Left=�6   $��6,40,0,0q�6:   $	��Top=�5R      5S      5T      5U      