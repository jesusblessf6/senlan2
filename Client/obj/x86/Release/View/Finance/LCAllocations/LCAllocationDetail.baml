   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls :    4Client.View.Finance.LCAllocations.LCAllocationDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5base$clr-namespace:Client.Base.BaseClient     >my/clr-namespace:Utility.Controls;assembly=Utility       N� Title$  LCAllocationDetail��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��label1��$��信用证分配��$��16(�$
��Bold"�$��32��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $��label2��$��客户��$��28��$
��Left=�$��	52,48,0,0q�$	��Top=�
���<���� -   $��textBox1��$��23��$
��Left=�$��	92,50,0,0q�$	��Top=�$	��120��{�.  ���� *BPName+�� -   $��button1��$	��...��$��23��$
��Left=�$��
216,50,0,0q�$	��Top=�$��27���� -   $��label3��$��内部客户��$��28��$
��Left=�$��
278,48,0,0q�$	��Top=�
���<���� -   $��	comboBox1��$��23��$
��Left=�$��
342,50,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$ 	ShortName�� �� SelectedValuePath$ Id������ *InternalCustomers+ �� SelectedValue �� *SelectedInternalCustomerId+�� -   $��label4��$��询问日期��$��28��$
��Left=�$��	28,81,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -	   $��datePicker1��$��25��$
��Left=�$��	92,82,0,0q�$	��Top=�$	��120��   SelectedDate �� *EnquireDate+�� -
   $��label5��$��金属��$��28��$
��Left=�$��
302,81,0,0q�$	��Top=��� -   $��	comboBox2��$��23��$
��Left=�$��
342,82,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *Commodities+ �� *SelectedCommodityId+�� -   $��label6��$��	开证行��$��28��$
��Left=�$��
40,113,0,0q�$	��Top=��� -   $��textBox6��$��23��$
��Left=�$��
92,115,0,0q�$	��Top=�$	��120������ *IssueBankName+�� -   $��label7��$��	承兑行��$��28��$
��Left=�$��290,113,0,0q�$	��Top=��� -   $��textBox7��$��23��$
��Left=�$��342,115,0,0q�$	��Top=�$	��120������ *AcceptingBankName+�� -   $��label8��$��币种��$��28��$
��Left=�$��
52,146,0,0q�$	��Top=��� -   $��	comboBox5��$��23��$
��Left=�$��
92,147,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *
Currencies+ �� *SelectedCurrencyId+�� -   $��label9��$��天数��$��28��$
��Left=�$��302,146,0,0q�$	��Top=�&   Utility.Controls.CurrencyTextBox  -   $��textBox2��$��23��$
��Left=�$��342,147,0,0q�$	��Top=�$	��120��   Text �� *Days+�� -   $��label10��$��数量��$��28��$
��Left=�$��
52,177,0,0q�$	��Top=�  -   $��currencyTextBox1��$��23��$
��Left=�$��
92,179,0,0q�$	��Top=�$	��120�� �� *
Quantity+�� -   $��label11��$��金额��$��28��$
��Left=�$��302,177,0,0q�$	��Top=�  -   $��currencyTextBox2��$��23��$
��Left=�$��342,179,0,0q�$	��Top=�$	��120�� �� *Amount+�� -   $��label12��$��报价��$��28��$
��Left=�$��
52,209,0,0q�$	��Top=��� -   $��textBox3��$��75��$
��Left=�$��
92,211,0,0q�$	��Top=�$	��370�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=����� *	Quotation+�� -   $��label13��$��	开证日��$��28��$
��Left=�$��
40,295,0,0q�$	��Top=�  -   $��datePicker2��$��25��$
��Left=�$��
92,296,0,0q�$	��Top=�$	��120�� �� *	IssueDate+�� -   $��label14��$��	贴现日��$��28��$
��Left=�$��290,295,0,0q�$	��Top=�  -   $��datePicker3��$��25��$
��Left=�$��342,296,0,0q�$	��Top=�$	��120�� �� *DiscountDate+�� -   $��label15��$��实际贴现利率��$��28��$
��Left=�$��	4,328,0,0q�$	��Top=��� -   $��textBox4��$��23��$
��Left=�$��
92,330,0,0q�$	��Top=�$	��120������ *ActualDiscounting+�� -    $��label16��$��	负责人��$��28��$
��Left=�$��290,328,0,0q�$	��Top=��� -!   $��	comboBox6��$��23��$
��Left=�$��342,330,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *
Responsors+ �� *SelectedResponsorId+�� -"   $��label17��$��备注��$��28��$
��Left=�$��
52,387,0,0q�$	��Top=��� -#   $��textBox5��$��87��$
��Left=�$��
92,388,0,0q�$	��Top=�$	��370�� . $
 Wrap=�$
 Auto=����� *
Comments+�� -$   $��	checkBox1��$��	已作废��$��16��$
��Left=�$��
92,362,0,0q�$	��Top=�	 d� 	IsChecked	 �� *
IsCanceled+�� -%   $��button2��$��保存��$��23��$
��Left=�$��166,512,0,0q�$	��Top=�$��75���� -&   $��button3��$��取消��$��23��$
��Left=�$��290,512,0,0q�$	��Top=�$��75��