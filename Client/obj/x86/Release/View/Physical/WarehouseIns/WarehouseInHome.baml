   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  7    1Client.View.Physical.WarehouseIns.WarehouseInHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$6  0Client.View.Physical.WarehouseIns.ResWarehouseIn�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *WarehouseInHome+.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$
��Bold"�$��16(�$��32��$
��Left=�$��6,6,0,0q�$	��Top=���  *WarehouseInHome+�� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label2��$��28��$	��100��$��Right=�$��6,46,0,0q�$
��Left=�$	��Top=���  *DomesticBLWarehouseIn+�� -   $��button1��$��+��$��23��$
��Left=�$��
120,47,0,0q�$	��Top=�$��75���� -   $��label3��$��28��$	��100��$��Right=�$
��Left=�$��6,80,0,0q�$	��Top=���  *CustomBLWarehouseIn+�� -   $��button2��$��+��$��23��$
��Left=�$��
120,81,0,0q�$	��Top=�$��75���� -   $��	groupBox2��$	��180��$
��Left=�$y�Hidden=�$��
330,40,0,0q�$	��Top=�$	��250����  $! Client.Properties.Resources��$ Reports��.��� �� -	   $��	groupBox3��$	��270��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.��� .+��� -
   $��label4��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ QueryShortcut���� -   $��btnCurrentMonthList��$��23��$
��Left=�$��	30,40,0,0q�   
LinkButton#��[  $	��Top=�$��75����  *WarehouseInsOfTheMonth+�� -   $��btnLasttMonthList��$��23��$
��Left=�$��
120,40,0,0q�#��[  $	��Top=�$��75����  *WarehouseInsOfLastMonth+�� -   $��btnCurrentYearList��$��23��$
��Left=�$��
210,40,0,0q�#��[  $	��Top=�$��75����  *WarehouseInsOfTheYear+�� -   $��btnLastYearList��$��23��$
��Left=�$��
300,40,0,0q�#��[  $	��Top=�$��75����  *WarehouseInsOfLastYear+�� -   $��label5��$��28��$
��Left=�$��6,70,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��label6��$��28��$	��100��$��Right=�$
��Left=�$��1,98,0,0q�$	��Top=�$y�	Collapsed=���  $! Client.Properties.Resources��$ Supplier���� -   $��button3��$	��...��$��23��$
��Left=�$��231,100,0,0q�$	��Top=�$��25��$y�	Collapsed=��� -   $��button4��$	��...��$��23��$
��Left=�$��497,100,0,0q�$	��Top=�$��25���� -   $��	comboBox1��$��23��$
��Left=�$��107,164,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *VerifiedStatus+ �� SelectedValue �� *SelectedVerifiedStatus+�� -   $��button5��$��23��$
��Left=�$��231,200,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��textBox1��$��23��$
��Left=�$��107,100,0,0q�$	��Top=�$	��120��{�.  $y�	Collapsed=����� *SupplierName+�� -   $��label7��$��28��$	��100��$��Right=�$
��Left=�$��
267,98,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Warehouse���� -   $��textBox2��$��23��$
��Left=�$��373,100,0,0q�$	��Top=�$	��120��{�.  ���� *WarehouseName+�� -   $��label8��$��28��$	��100��$��Right=�$
��Left=�$��	1,162,0,0q�$	��Top=���  $! Client.Properties.Resources��$ QuantityConfirm���� -   $��label9��$��起始日期��$��28��$	��100��$��Right=�$
��Left=�$��	1,130,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��23��$
��Left=�$��107,132,0,0q�$	��Top=�$	��120��	   SelectedDate	 �� *	StartDate+  -   $��datePicker2��$��23��$
��Left=�$��373,132,0,0q�$	��Top=�$	��120��	 �� *	EndDate+�� -   $��label10��$��截止期日��$��28��$	��100��$��Right=�$
��Left=�$��267,130,0,0q�$	��Top=��� -   $��label11��$��金属��$��28��$	��100��$��Right=�$
��Left=�$��1,98,0,0q�$	��Top=��� -   $��	comboBox2��$��23��$
��Left=�$��107,100,0,0q�$	��Top=�$	��120��$ Id��$
 Name������ *CommodityList+ �� *CommodityId+�� -   $��	checkBox1��$!��仅显示当前用户文档��$��16��$
��Left=�$��373,168,0,0q�$	��Top=�
 d� 	IsChecked
 �� *ContainCurrentUser+