   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  -    'Client.View.Reports.FDPStorageFeeDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� N� Title$ FDPStorageFeeDetail�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension  .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$��外贸仓单仓租明细��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(��� -   $��	groupBox3��$��查询条件��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��800��.��� -   $��grid3��.+��� -   $��label2��$��	仓单号��$��28��$
��Left=�$��	55,10,0,0q�$	��Top=��� -   $��textBox1��$��23��$
��Left=�$��
107,10,0,0q�$	��Top=�$	��120������ *
DeliveryNo+�� -   $��label3��$��仓库��$��28��$
��Left=�$��
326,10,0,0q�$	��Top=��� -   $��textBox2��$��23��$
��Left=�$��
366,10,0,0q�$	��Top=�$	��120��{�.  ���� *WarehouseName+�� -	   $��button1��$	��...��$��23��$
��Left=�$��
491,10,0,0q�$	��Top=�$��30���� -
   $��label4��$��起始日期��$��28��$
��Left=�$��	43,42,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��23��$
��Left=�$��
107,42,0,0q�$	��Top=�$	��120��   SelectedDate �� *	StartDate+�� -   $��label5��$��截止日期��$��28��$
��Left=�$��
302,42,0,0q�$	��Top=�  -   $��datePicker2��$��23��$
��Left=�$��
366,42,0,0q�$	��Top=�$	��120�� �� *	EndDate+�� -   $��button2��$��查询��$��23��$
��Left=�$��
491,42,0,0q�$	��Top=�$��60���� -   $��
separator1��$��17��$��	6,146,6,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��auto��$
��Left=�$��	6,166,0,0q�$	��Top=�$
��auto��   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	仓单号��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *
DeliveryNo+  $ 净重��	 �� *	NetWeight+  $ 毛重��	 �� *GrossWeight+  $ 捆数��	 �� *Bundle+  $ 仓库��	 �� *WarehouseName+  $ 起始日期��	 �� *	StartDate+
 �� StringFormat$
 {0:yyyy-MM-dd}��  $ 截止日期��	 �� *	EndDate+$
 {0:yyyy-MM-dd}��  $ 仓租��	 �� *
StorageFee+  $ 货权转移费��	 �� *TransferFee+  $ 	仓单费��	 �� *
WarrantFee+  $ 总计��	 �� *
TotalFee+  $ 币种��	 �� *CurrencyName+  $ 备注��	 �� *	Comment+