   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  8    2Client.View.Finance.LCAllocations.LCAllocationHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5base$clr-namespace:Client.Base.BaseClient       N� Title$  信用证分配��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��label1��$��信用证分配��$��16(�$
��Bold"�$��32��$
��Left=�$��6,6,0,0q�$	��Top=��� -   $��	groupBox1��$	��110��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label2��$��信用证分配明细��$��28��$
��Left=�$��Right=�$��6,31,0,0q�$	��Top=�$	��100���� -   $��button1��$��+��$��23��$
��Left=�$��
120,32,0,0q�$	��Top=�$��75���� -   $��	groupBox2��$	��330��$
��Left=�$��
40,156,0,0q�$	��Top=�$	��576����  $! Client.Properties.Resources��$ Query��.��� .+��� -   $��label6��$
��Bold"�$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ QueryShortcut���� -   $��button2��$��本月信用证分配��$��23��$
��Left=�$��	32,40,0,0q�$	��Top=�$��95��   
LinkButton#��[  �� -	   $��button3��$��本年信用证分配��$��23��$
��Left=�$��
145,40,0,0q�$	��Top=�$��99��#��[  �� -
   $��label7��$
��Bold"�$��28��$
��Left=�$��6,69,0,0q�$	��Top=���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��label3��$��客户��$��28��$
��Left=�$��
75,104,0,0q�$	��Top=��� -   $��textBox1��$��23��$
��Left=�{�.  $��115,106,0,0q�$	��Top=�$	��120������ *BPName+�� -   $��button4��$	��...��$��23��$
��Left=�$��241,105,0,0q�$	��Top=�$��28���� -   $��label4��$��内部客户��$��28��$
��Left=�$��312,103,0,0q�$	��Top=��� -   $��	comboBox1��$��23��$
��Left=�$��376,104,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$ 	ShortName�� �� SelectedValuePath$ Id������ *InternalCustomers+ �� SelectedValue �� *SelectedInternalCustomerId+�� -   $��label5��$��查询日开始日期��$��28��$
��Left=�$��
15,135,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��115,136,0,0q�$	��Top=�$	��120��   SelectedDate �� *EnquireStartDate+�� -   $��label8��$��截止日期��$��28��$
��Left=�$��312,135,0,0q�$	��Top=�  -   $��datePicker2��$��25��$
��Left=�$��376,136,0,0q�$	��Top=�$	��120�� �� *EnquireEndDate+�� -   $��label11��$��贴现日开始日期��$��28��$
��Left=�$��
15,167,0,0q�$	��Top=�  -   $��datePicker3��$��25��$
��Left=�$��115,168,0,0q�$	��Top=�$	��120�� �� *DiscountStartDate+�� -   $��label12��$��截止日期��$��28��$
��Left=�$��312,167,0,0q�$	��Top=�  -   $��datePicker4��$��25��$
��Left=�$��376,168,0,0q�$	��Top=�$	��120�� �� *DiscountEndDate+�� -   $��label9��$��	开证行��$��28��$
��Left=�$��
63,200,0,0q�$	��Top=��� -   $��textBox2��$��23��$
��Left=�$��115,201,0,0q�$	��Top=�$	��120������ *IssueBankName+�� -   $��label10��$��	承兑行��$��28��$
��Left=�$��324,200,0,0q�$	��Top=��� -   $��textBox3��$��23��$
��Left=�$��376,201,0,0q�$	��Top=�$	��120������ *AcceptingBankName+�� -   $��	checkBox1��$��仅查询本人文档��$��16��$
��Left=�$��115,238,0,0q�$	��Top=� d� 	IsChecked �� *OnlyForCurrentUser+�� -   $��button5��$��23��$
��Left=�$��327,234,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��button6��$��23��$
��Left=�$��421,234,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Reset��