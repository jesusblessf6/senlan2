   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  7    1Client.View.Physical.Deliveries.SalesDeliveryHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *SalesDeliveryHome+.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  *SalesDeliveryHome+�� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label2��$��28��$	��100��$��Right=�$
��Left=�$��	18,31,0,0q�$	��Top=���  *DomesticSwitchDelivery+�� -   $��button1��$��+��$��23��$
��Left=�$��
132,32,0,0q�$	��Top=�$��75�� � ToolTip   *AddDomesticSwitchDelivery+�� -   $��label3��$��28��$	��100��$��Right=�$
��Left=�$��	18,65,0,0q�$	��Top=���  *
SwitchBL+�� -   $��button2��$��+��$��23��$
��Left=�$��
132,66,0,0q�$	��Top=�$��75��   *AddSwitchBL+�� -   $��label4��$��28��$	��100��$��Right=�$
��Left=�$��	18,99,0,0q�$	��Top=���  *
ExportWR+�� -	   $��button3��$��+��$��23��$
��Left=�$��132,100,0,0q�$	��Top=�$��75��   *AddExportWR+�� -
   $��	groupBox2��$	��180��$
��Left=�$��
330,40,0,0q�$	��Top=�$	��250��$y�Hidden=���  $! Client.Properties.Resources��$ Reports��.��� .+��� -   $��btnSalesDeliveryDetail��$��23��$
��Left=�$��	27,23,0,0q�   
LinkButton#��[  $	��Top=�$
��auto����  *DomesticSwitchDeliveryDetail+�� -   $��btnReexportDeliveryDetail��$��23��$��	28,56,0,0q�#��[  $
��auto��$
��Left=�$	��Top=���  *SwitchDeliveryDetail+�� -   $��	groupBox3��$	��341��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.��� .+��� -   $��label6��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ QueryShortcut���� -   $��btnCurrentMonthList��$��23��$
��Left=�$��	30,40,0,0q�#��[  $	��Top=�$��70����  *DeliveryOfTheMonth+�� -   $��btnLasttMonthList��$��23��$
��Left=�$��
120,40,0,0q�#��[  $	��Top=�$��70����  *DeliveryOfLastMonth+�� -   $��btnThisYearList��$��23��$
��Left=�$��
210,40,0,0q�#��[  $	��Top=�$��70����  *DeliveryOfTheYear+�� -   $��label7��$
��Bold"�$��28��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��label8��$��28��$	��100��$��Right=�$
��Left=�$��1,98,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Buyer���� -   $��btnCustomer��$	��...��$��23��$
��Left=�$��231,100,0,0q�$	��Top=�$��25���� -   $��label12��$��Right=�$��28��$	��100��$
��Left=�$��	0,194,0,0q�$	��Top=���  $! Client.Properties.Resources��$ CommodityType���� -   $��comboBoxMetal�� �� DisplayMemberPath$
 Name��$��23��$
��Left=�$��107,196,0,0q� �� SelectedValuePath$ Id��$	��Top=�$	��120������ *CommodityTypes+	 �� SelectedValue	 �� *SelectedCommodityTypeId+�� -   $��label10��$��28��$	��100��$��Right=�$
��Left=�$��	1,130,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	StartDate���� -   $��label11��$��28��$	��100��$��Right=�$
��Left=�$��267,130,0,0q�$	��Top=���  $! Client.Properties.Resources��$ EndDate��(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��23��$
��Left=�$��107,132,0,0q�$	��Top=�$	��120��
   SelectedDate
 �� *	StartDate+  -   $��datePicker2��$��23��$
��Left=�$��373,132,0,0q�$	��Top=�$	��120��
 �� *	EndDate+�� -   $��	btnSearch��$��23��$
��Left=�$��373,260,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��textBox1��$��23��$
��Left=�$��107,100,0,0q�$	��Top=�$	��120��{�.  ���� *SupplierName+�� -   $��label5��$��28��$
��Left=�$��Right=�$��	1,162,0,0q�$	��Top=�$	��100����  $! Client.Properties.Resources��$ QuantityConfirm���� -   $��	comboBox1��$
 Name��$��23��$
��Left=�$��107,164,0,0q�$ Id��$	��Top=�$	��120������ *DlvIsVerifieds+	 �� *SelectedIsVerified+�� -   $��label9��$��28��$
��Left=�$��Right=�$��267,162,0,0q�$	��Top=�$	��100����  $! Client.Properties.Resources��$ 	TradeType���� -    $��comboBoxTradeType��$	 Key��$��23��$
��Left=�$��373,164,0,0q�$ Value��$	��Top=�$	��120������ *
TradeTypes+	 �� *SelectedTradeType+�� -!   $��	checkBox1��$!��仅显示当前用户文档��$��16��$
��Left=�$��107,264,0,0q�$	��Top=� d� 	IsChecked �� *IsOnlyCurrentUser+�� -"   $��label13��$��仓库��$��28��$
��Left=�$��
332,98,0,0q�$	��Top=��� -#   $��textBox2��$��23��$
��Left=�$��372,100,0,0q�$	��Top=�$	��120��{�.  ���� *WarehouseName+�� -$   $��button4��$	��...��$��23��$
��Left=�$��496,100,0,0q�$	��Top=�$��25���� -%   $��label1��$��28��$
��Left=�$��Right=�$��267,194,0,0q�$	��Top=�$	��100����  $! Client.Properties.Resources��$ Brand���� -&   $��label14��$��	批次号��$��28��$
��Left=�$��
55,226,0,0q�$	��Top=��� -'   $��textBox3��$��23��$
��Left=�$��107,228,0,0q�$	��Top=�$	��120������ *	QuotaNo+�� -(   $��	comboBox2��$
 Name��$��23��$
��Left=�$��373,196,0,0q�$ Id��$	��Top=�$	��120������ *Brands+	 �� *SelectedBrand+�� -)   $��label15��$��发货单号��$��28��$
��Left=�$��Right=�$��267,226,0,0q�$	��Top=�$	��100���� -*   $��textBox4��$��23��$
��Left=�$��372,228,0,0q�$	��Top=�$	��120������ *BLNo+