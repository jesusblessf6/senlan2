   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  8   2Client.View.Physical.Contracts.ShortContractDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract��$
��Auto��$
��auto�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ShortContract+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker.  (Client.Converters.ApproveStatusConverter   ApproveStatusConverter  AttachmentDownLoad  AttachmentDelete  QuotaBrandRelEdit  QuotaBrandRelDelete  RelQuotaEdit  RelQuotaDelete  QuotaBrandRelActions �� DataType �� Orientation	   ResxName

   Key  RelQuotaActions 	 AttachmentActions��%�  '��       '�� S     '�� �     '  �     &	      &	     &	     &	     &	     &	     &	     &	 $    7  7  &	 :    7  7  &		 9    7  7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� �� �� �� �� �� �� $ DBEntity:QuotaBrandRel��.R��� $ 
Horizontal=�.+��� $��btQuotaBrandRelEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��btQuotaBrandRelDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+�� .R��� $ 
Horizontal=�.+��� $��btRelQuotaEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *
QuotaStage+�� $��btRelQuotaDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *
QuotaStage+�� $ DBEntity:Attachment��.R��� $ 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $!	 Client.Properties.Resources��$
 Download������ *Id+�� $��btAttachmentDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��auto �.+��� -    ��Name$ 
lbSupplier��$
��Left=�
���<��$��
278,38,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Supplier���� -	   $��btnSupplier��$	��...��$��23��$��
518,40,0,0q�$	��Top=�$
��Left=�$��25��{��� *
IsBPEnable+�� -
   $ 
label3Copy��$��6,70,0,0q�$
��Left=�
���<��$	��Top=���  $!	 Client.Properties.Resources��$
 Quantity��&   Utility.Controls.CurrencyTextBox  -     Name$ textBox1Copy2��$��23��$	��120��$��
122,72,0,0q�$
��Left=�$	��Top=�   Text �� *
Quantity+$   DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z {��� *IsQuantityEnable+�� -   $ lbPrice��$
��Left=�$��
278,70,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 Price��  -   $ txtPrice��$��23��$	��120��$��
394,72,0,0q�$
��Left=�$	��Top=� �� *Price+   	STR_PRICE# Z {��� *IsPriceEnable+�� $
��Left=�$��	6,168,0,0q�
���<��$	��Top=���  *
SignDate+  -   $��datePicker1��$
��Left=�$	��Top=�$��122,168,0,0q�   SelectedDate �� *
SignDate+{��� *IsSignDateEnable+�� $
��Left=�$��278,166,0,0q�
���<��$	��Top=���  $!	 Client.Properties.Resources��$
 SignSide���� -   $��	comboBox2�� �� DisplayMemberPath$ 	ShortName��$
��Left=�$��394,168,0,0q� �� SelectedValuePath$ Id��$	��Top=����� *InnerCustomers+ �� SelectedValue �� *SelectedInternalCustomerId+{��� *IsSignBPEnable+�� -   $��lbShipCondition��$��6��$
��Left=�$��6,0,0,3q�$
��Auto����  $!	 Client.Properties.Resources��$
 ShipTerm���� -   $��tbShipCondition��$��6��$��23��$
��Left=�$��	122,2,0,6q�$	��120������ *
ShipTerm+�� $
��Left=�$��	6,198,0,0q�
���<��$	��Top=���  $!	 Client.Properties.Resources��$
 	Commodity���� -    ��Name$ cboxCommodity��$
��Left=�$��122,200,0,0q�$	��Top=�$
 Name��$ Id������ *
Commoditys+ �� *CommodityId+{��� *IsCommodityEnable+�� $
��Left=�$��278,198,0,0q�
���<��$	��Top=���  $!	 Client.Properties.Resources��$
 CommodityType���� -   $ cboxCommodityType��$
��Left=�$��394,200,0,0q�$	��Top=�$
 Name��$ Id������ *CommodityTypes+ �� *CommodityTypeId+�� $
��Left=�$��	6,230,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Brand���� -   $ comboBox1Copy3��$
��Left=�$��122,232,0,0q�$	��Top=�$
 Name��$ Id������ *Brands+ �� *	BrandId+�� $
��Left=�$��278,230,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Specification���� -   $ comboBox1Copy4��$��394,232,0,0q�$	��Top=�$
 Name��$ Id��$
��Left=����� *Specifications+ �� *SpecificationId+�� -   $��lbPricingType��$
��Left=�$��6,0,0,0q�
���<��$	��Top=�$��2����  $!	 Client.Properties.Resources��$
 PricingType���� -   $ cbxPricingType��$
��Left=�$��	122,2,0,0q�$	 Key��$ Value��$��23��$	��Top=�$��2������ *PricingTypes+ �� *SelectPricingType+{��� *IsPricingTypeEnable+�� -   $ lbPricingStartDate��$
��Left=�$��6,0,0,0q�$��3��$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 PricingStartDate��  -     Name$ dpPricingStartDate��$
��Left=�$��	122,2,0,0q�$	��Top=�$��3�� �� *PricingStartDate+{��� *IsPricingStartDateEnable+�� -   $ lbPricingEndDate��$
��Left=�$��	278,0,0,0q�$��Right=�$��3��$��28��$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 PricingEndDate��  -   $ dpPricingEndDate��$
��Left=�$��	394,2,0,0q�$	��Top=�$��3�� �� *PricingEndDate+{��� *IsPricingEndDateEnable+�� -   $ lbSettlementCurrency��$
��Left=�
���<��$��	278,0,0,0q�$	��Top=�$��6��$y�	Collapsed=���  $!	 Client.Properties.Resources��$
 SettleCurrency���� -   $ cbSettlementCurrency��$��	394,2,0,7q�$��6��$y�	Collapsed=�$
��Left=�$��23���� -   $ lbSettlementRate��$
��Left=�$��	278,0,0,0q�
���<��$	��Top=�$��5����  $!	 Client.Properties.Resources��$
 ExchangeRate��  -   $ txtSettlementRate��$
��Left=�$	��120��$��	394,2,0,7q�$��23��$��5�� �� *SettlementRate+   STR_RATE# Z �� -    $��lbPricingCurrency��$��5��$
��Left=�$��6,0,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 PricingCurrency���� -!   $��cbPricingCurrency��$��5��$
��Left=�$��	122,2,0,7q�$
 Name��$ Id��$��23������ *
Currencies+ �� *SelectPricingCurrencyId+�� $
��Left=�
���   �$��6,38,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 
ContractNo���� -"   $��textBox1��$
��Left=�$	��Top=�$��
122,40,0,0q����� *
ContractNo+�� $
��Left=�$��	6,134,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 FinancialStatus���� -#   $��	comboBox1��$
��Left=�$	 Key��$ Value��$��122,136,0,0q�$	��Top=�{�.  ���� *StatusTypes+ �� *FinanceStatus+�� -$   $ label3Copy2��$��278,134,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 
ShipStatus���� -%   $ comboBox1Copy��$
��Left=�$��394,136,0,0q�$	 Key��$ Value��$	��Top=�{�.  ���� *StatusTypes+ �� *DeliveryStatus+�� -&   $ lbPricingBasis��$
��Left=�$��	278,0,0,0q�$	��Top=�
���<��$��2����  $!	 Client.Properties.Resources��$
 PricingReference���� -'   $ cbxPricingBasis��$
��Left=�$��	394,2,0,0q�$	��Top=�$	 Key��$ Value��$��2������ *PricingBasises+ �� *SelectPricingBasis+{��� *IsPricingBasisEnable+�� -(   $ 	lbPremium��$
��Left=�$��6,32,0,0q�
���   �$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 Premium��  -)   $ 
txtPremium��$��23��$	��120��$��
122,34,0,7q�$
��Left=�$��3�� �� *	Premium+{��� *IsPremiumEnable+�� -*   $ lbPricingSide��$
��Left=�$��
278,32,0,0q�$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 PricingSide��	� -+   $��rbtPricingSideTheir��$��20��$	��Top=�$��Center=�$
��left=�$��
394,38,0,0q�$��3����  $!	 Client.Properties.Resources��$
 OppoSide�� d� 	IsChecked �� *PricingSideTheir+	� -,   $��rbtPricingSideOwn��$
��Left=�$��
474,38,0,0q�$��20��$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 OurSide�� �� *PricingSideOwn+�� --   $ lbWarehouse��$
��Left=�$��6,0,0,0q�$��4��$	��Top=���  $!	 Client.Properties.Resources��$
 	Warehouse���� -.    ��Name$ btnWarhouse��$	��...��$��25��$��23��$��	246,2,0,7q�$
��Left=�$��4���� -/   $ lbDeliveryDate��$��	278,0,0,0q�$��Right=�$
��Left=�$��4��$	��Top=���  *DeliveryDate+  -0   $ dpDeliveryDate��$
��Left=�$��	394,2,0,7q�$��4��$��23�� �� *DeliveryDate+�� -1   $��button1��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��8����  $!	 Client.Properties.Resources��$
 AddWithSymbol���� $��6,0,0,0q�$
��Left=�$	��Top=�$��9����  $!	 Client.Properties.Resources��$
 Comments���� -2   $��textBox6��" �� VerticalScrollBarVisibility$
 Auto=�$��	122,2,0,0q� �� TextWrapping$
 Wrap=�$	��100��$	��Top=�$
��Left=�$	��392��$��9������ *Description+�� -3   $��210,130,0,0q�$	��Top=�$
��Left=�$��60��$��9��$��23����  $!	 Client.Properties.Resources��$

 Save���� -4   $	��Top=�$
��Left=�$��60��$��271,134,0,0q�$��9��$��23��$y�Hidden=���  $!	 Client.Properties.Resources��$
 SaveAsDraft��{��� *IsSaveAsDraftEnable+�� -5   $	��Top=�$��305,130,0,0q�$
��Left=�$��60��$��23��$��9����  $!	 Client.Properties.Resources��$
 Cancel���� -6   $ lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *DomesticPurchaseContractShort+�� -7    ��Name$ textBox1Copy��$
��Left=�$	��Top=�  �� 
IsReadOnly  . $��
394,40,0,0q�{�.  ���� *SupplierName+�� $
��Left=�$��	6,102,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 DocumentStatus���� -8   $ textBox1Copy3��$��122,104,0,0q�$	��Top=�{�.  $
��Left=����� *
BillStatus+�� -9   $ label3Copy1��$��278,102,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 ApprovalStatus���� -:   $ textBox1Copy4��$��394,104,0,0q�$
��Left=�$	��Top=�{�.  ���� *ApproveStatus+! �� 	Converter#! [  �� -;   $ txtWarehouse��$��	122,2,0,7q�$
��Left=�{�.  $��4��$��23������ *WarehouseName+�� $��6,0,0,0q�$	��Top=�$
��Left=�$��8����  $!	 Client.Properties.Resources��$
 
Attachment��&   System.Windows.Controls.DataGrid  -<   $��dataGridAttachment��"   AutoGenerateColumns" .  $
��auto��$
��Left=�#   
IsReadOnly# . $   CanUserAddRows$ .  $��
122,34,0,7q�$��8��$
��Auto��$	��Top=����� *Attachments+%   Columns% 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn& 
  Header&   $!	 Client.Properties.Resources��$
 AttachmentName��1  +System.Windows.Controls.DataGridBoundColumn'   Binding' �� *Name+4  .System.Windows.Controls.DataGridTemplateColumn  (   CellTemplate#( [	 ) 
  CanUserSort) .  &   $!	 Client.Properties.Resources��$
 	Operation���� $
��Left=�$��6,32,0,0q�$	��Top=�$��2����  $!	 Client.Properties.Resources��$	
 UDF���� -=   $��	comboBox3��$
 Name��$
��Left=�$��
122,34,0,7q�$ Id��$��2��$��23��$	��Top=����� *Udfs+ �� *SelectedUsdId+�� ->   $��label1��$
��Left=�$��6,0,0,0q�$	��Top=�$��1����  *More+y��� *IsUseMultipleBrands+�� -?   $��button2��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��45��$��1����  $!	 Client.Properties.Resources��$
 AddWithSymbol��y��� *IsUseMultipleBrands+  -@   $��	dataGrid1��" .  $
��Left=�$��
122,34,0,7q�$*   HorizontalScrollBarVisibility$
* Auto=�$
��Auto��# . $
��Auto��$	��Top=�$��1������ y��� *IsUseMultipleBrands+% 	  + 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
+ Auto &   $!	 Client.Properties.Resources��$
 Brand��' �� *
Brand.Name+	  $
+ Auto &   $!	 Client.Properties.Resources��$
 Specification��' �� *Specification.Name+	  $
+ Auto &   $!	 Client.Properties.Resources��$
 Price��' �� *Price+# Z 	  $
+ Auto &   $!	 Client.Properties.Resources��$
 Quantity��' �� *
Quantity+# Z 	  $
+ Auto &   $!	 Client.Properties.Resources��$
 	Warehouse��' �� *Warehouse.Name+  #( [ $
+ auto ) .  &   $!	 Client.Properties.Resources��$
 	Operation���� 
���   �$
��Left=�$��
271,32,0,0q�$	��Top=�$��2��$	��117����  *OriginContractNo+�� -A   $��textBox2��$
��Left=�$��
394,34,0,7q�$	��Top=�$��2������ *ExContractNo+�� -B   $��lbRel��$y�	Collapsed=�$��关联交易��$��1��$��28��$
��Left=�$��6,0,0,24q�$	��110��$��Bottom=��� -C   $��btnRel��$y�	Collapsed=�$��23��$
��Left=�$��
122,0,0,27q�$��45��$��1��$��Bottom=���  $!	 Client.Properties.Resources��$
 AddWithSymbol��{��� *IsRelTransactionNewBtnEnable+  -D   $��	dataGrid2��$y�	Collapsed=�" .  $
��Auto��$
��Left=�$
* Auto=�# . $��	122,0,0,0q�$��Bottom=�$
��Auto��$��1������ % 	  $
+ Auto ' �� *BusinessParnterName+&   $!	 Client.Properties.Resources��$
 InternalCustomer��	  $
+ Auto ' �� *Price+# Z &   $!	 Client.Properties.Resources��$
 Price��	  $& 签署日期��$
+ Auto ' �� *
SignDate+$ 
yyyy-MM-dd��	  $& 收票日期��$
+ Auto ' �� *VATInvoiceDate+$ 
yyyy-MM-dd��  ) .  #( [ $
+ auto &   $!	 Client.Properties.Resources��$
 	Operation���� -E   $��lbVATInvoiceDate��$
��Left=�$��	278,0,0,3q�$	��Top=�$	��110��$��6������ *VATInvoiceStr+  -F   $��datePicker2��$
��Left=�$��	394,2,0,0q�$	��Top=�$��6��$��23�� �� *VATInvoiceDate+�� -G   $��paymentMean��$	 Key��$
��Left=�$��122,264,0,7q�$ Value��$	��Top=����� *PaymentMean+ �� *SelectPaymentMeanId+�� -H   $��label6��$
��Left=�$��	6,262,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 PaymentMean���� -I   $��label2��$��对手合同号��$��28��$
��Left=�$��278,262,0,0q�$	��Top=�$	��110��y��� *IsAutoNoVisible+�� -J   $��textBox3��$��23��$
��Left=�$��394,264,0,7q�$	��Top=�$	��120��y��� *IsAutoNoVisible+���� *AutoContractNo+