   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 6    0Client.View.Reports.ExternalDeliveryCirculReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ForeignBLWRFlowReport+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%�  &	        '�� �     '�� �     '  �     &	 .    &	 3    7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��  �� " ��.���  � �� �� *
LineType+8   .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *ForeignBLWRFlowReport+�� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,166,0,0q�$	��Top=�$
��Auto��	   
IsReadOnly	 . ���� *	Summaries+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [    Header      ResxName$! Client.Properties.Resources��
   Key$ FlowId��   . $
 Auto # [    $# Client.View.Reports.ResReport��$ 
DocumentNo�� 	  Binding �� *
DeliveryNo+   . $
 Auto # [    $! Client.Properties.Resources��$ DocumentType�� �� *DeliveryType+   . $
 Auto # [    $# Client.View.Reports.ResReport��$ PurchaseDate�� �� *	BuyDate+ �� StringFormat$ 
yyyy-MM-dd��   . $
 Auto # [    $! Client.Properties.Resources��$ Buyer�� �� *	BuyBPName+   . $
 Auto # [    $# Client.View.Reports.ResReport��$ 	SalesDate�� �� *
SellDate+$ 
yyyy-MM-dd��   . $
 Auto # [    $! Client.Properties.Resources��$ Supplier�� �� *
SellBPName+   . $
 Auto # [    $! Client.Properties.Resources��$ 	Commodity�� �� *CommodityName+   . $
 Auto # [    $! Client.Properties.Resources��$ Brand�� �� *	BrandName+   . $
 Auto # [    $! Client.Properties.Resources��$ 	NetWeight�� �� *	NetWeight+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY# Z    . $
 Auto # [    $! Client.Properties.Resources��$ GrossWeight�� �� *GrossWeight+# Z    . $
 Auto # [    $# Client.View.Reports.ResReport��$ LoCInfo�� �� *LCMsg+ �� 
GroupStyle (  "System.Windows.Controls.GroupStyle    GroupHerderStyle   ContainerStyle# [    Panel �� .R�>  8System.Windows.Controls.Primitives.DataGridRowsPresenter     RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��
 ����� �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  � ��
 ������  � ��
 ����   	CellStyle �� *  $System.Windows.Controls.DataGridCell"   P�  �@ 
IsSelected . . ���  � ��
 ������  � ��
 ������ -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��800����  $! Client.Properties.Resources��$ 
Conditions��.��� .+��� -   $��label1��#��[  $
��Left=�$��1,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ FlowId���� -   $��label3��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	StartDate��  -   $��datePicker1��$
��Left=�$��
366,12,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -	   $��label4��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ EndDate��  -
   $��datePicker2��$
��Left=�$��
366,44,0,0q�$	��Top=� �� *	EndDate+�� -   $��label5��#��[  $
��Left=�$��
519,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox3��$
��Left=�$��
625,12,0,0q�$	��Top=� �� DisplayMemberPath$ 	ShortName�� �� SelectedValuePath$ Id������ *InternalCustomers+ �� SelectedValue �� *SelectedInternalCustomerId+�� -   $��button1��$��23��$
��Left=�$��
625,44,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��label2��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Buyer���� -   $��textBox2��$��23��$
��Left=�{�.  $��
107,44,0,0q�$	��Top=�$	��120������ *BPName+�� -   $��button2��$	��...��$��23��$
��Left=�$��
231,44,0,0q�$	��Top=�$��25���� -   $��textBox3��$
��Left=�$��
107,12,0,0q�$	��Top=����� *
CirculNo+