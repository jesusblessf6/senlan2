   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 6    0Client.View.Reports.BusinessPartnerContractOrder   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� N� Title$" BusinessPartnerContractOrder�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%  &	        '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��800����     ResxName$! Client.Properties.Resources��
	   Key$	 
Conditions��.��� .+��� -   $��label2��$��内部客户��
���<��#��[  $
��Left=�$��1,10,0,0q�$	��Top=��� -   $��label3��#��[  $��金属��
���<��$
��Left=�$��
260,10,0,0q�$	��Top=��� -   $��label4��#��[  $��起始日期��
���<��$
��Left=�$��1,42,0,0q�$	��Top=�  -   $��datePicker1��$
��Left=�$��
107,44,0,0q�$	��Top=�
   SelectedDate
 �� *	StartDate+  -   $��datePicker2��$
��Left=�$��
366,44,0,0q�$	��Top=�
 �� *	EndDate+�� -   $��label5��#��[  $��截止日期��
���<��$
��Left=�$��
260,42,0,0q�$	��Top=��� -	   $��label6��#��[  $��业务类型��
���<��$
��Left=�$��
519,10,0,0q�$	��Top=��� -
   $��	comboBox1��$
��Left=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id��$��
366,12,0,0q�$	��Top=����� *CommodityList+ �� SelectedValue �� *CommodityId+�� -   $��	comboBox2��$
��Left=�$ Value��$	 Key��$ 1��$��
625,12,0,0q�$	��Top=����� *ContractType+�� -   $��button1��$��查询��$��23��$
��Left=�$��
625,44,0,0q�$	��Top=�$��75���� -   $��	comboBox3��$
��Left=�$ 	ShortName��$ Id��$��
107,12,0,0q�$	��Top=����� *InternalCustomerList+ �� *SelectedInternalCustomerId+�� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Left=�$
��auto��$��	6,166,0,0q�$	��Top=�$
��auto��  DataGridStyle#��[   DataGridRowStyle   RowStyle# [    
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 客户名称��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *BusinessParnterName+  $ 数量�� �� *Qty+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z   $ 金额�� �� *Amount+   
STR_AMOUNT# Z   $ 均价�� �� *
AvgPrice+   	STR_PRICE# Z �� -   $��lbTitle��$��客户购销排行表��$
��Bold"�$��16(�$��32��$
��Left=�$��6,6,0,0q�$	��Top=�