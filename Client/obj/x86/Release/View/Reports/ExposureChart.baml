   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  S OZedGraph, Version=5.1.5.28844, Culture=neutral, PublicKeyToken=02a83cbd123fcd605(clr-namespace:ZedGraph;assembly=ZedGraphZedGraph A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient '   !Client.View.Reports.ExposureChart   WwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  5zedgraph(clr-namespace:ZedGraph;assembly=ZedGraph  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ExposureTrend+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%V  &	        '�� �     '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -    ��Name$ lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *ExposureTrend+7   1System.Windows.Forms.Integration.WindowsFormsHost  $��	6,166,0,0q�$	��816��$
��Left=�$	��280��$	��Top=�	   Child.	   ZedGraph.ZedGraphControl  -   zedGraphControlLine��&   System.Windows.Controls.DataGrid  -   $��	dataGrid2��
   CanUserAddRows
 .     
IsReadOnly .    AutoGenerateColumns . $	��170��$   HorizontalScrollBarVisibility$
 Auto=�$
��Left=�$��	6,452,0,0q�$	��Top=�$	��816������ �� -   $��	groupBox1��$	��100��$
��Left=�$��6,40,0,0q�$	��Top=�$	��816����     ResxName$! Client.Properties.Resources��
   Key$ 
Conditions��.��� .+��� -   $��label2��#��[  $
��Left=�$��1,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -   $��	comboBox2��$
��Left=�$��
107,12,0,0q�$	��Top=� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *CommodityList+ �� SelectedValue �� *CommodityID+�� -   $��label3��#��[  $
��Left=�$��
260,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ InternalCustomer���� -	   $��	comboBox3��$
��Left=�$��
366,12,0,0q�$	��Top=�$ Id��$ 	ShortName������ *InternalCustomerList+ �� *InternalCustomerID2+�� -
   $��label4��
���<��#��[  $
��Left=�$��1,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	StartDate��  -   $��datePicker1��$
��Left=�$��
107,44,0,0q�$	��Top=�   SelectedDate �� *	StartDate+�� -   $��label5��
���<��#��[  $
��Left=�$��
260,42,0,0q�$	��Top=���  $! Client.Properties.Resources��$ EndDate��  -   $��datePicker2��$
��Left=�$��
366,44,0,0q�$	��Top=� �� *	EndDate+�� -   $��button2��$��23��$
��Left=�$��
625,44,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��label1��
���<��$	��120��$��28��$��Right=�$
��Left=�$��
499,10,0,0q�$	��Top=���  *DomesticHedgeRatio+�� -   $��textBox1��$��23��$
��Left=�$��
625,12,0,0q�$	��Top=�$	��120������ *ProportionValue+�� -   $��
separator1��$��17��$��6,146,132,0q�$	��Top=�