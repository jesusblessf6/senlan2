   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  S OZedGraph, Version=5.1.5.28844, Culture=neutral, PublicKeyToken=02a83cbd123fcd605(clr-namespace:ZedGraph;assembly=ZedGraphZedGraph A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 2   ,Client.View.Console.DashBoard.DashBoardChart   WwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  5zedgraph(clr-namespace:ZedGraph;assembly=ZedGraph  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Console.DashBoard.ResDashBoard�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *	DashBoard+.���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid�� � ColumnDefinitions �� $
��Auto ��� $
��Auto � � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� -   $��label2��$
��Bold"�$��15(�$��0,6,0,0q�$��36��$	��Top=�$��Center=���  *PhysicalInventory+�� -   $��label1��$��28��$��60��$��Right=�$
��Left=�$��	15,70,0,0q�$	��Top=���     ResxName$! Client.Properties.Resources��
   Key$ InternalCustomerShort�� � ToolTip   $! Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox1��$��23��$
��Left=�$��	82,72,0,0q�$	��Top=�$	��120��	 �� SelectedValuePath$	 Id��
 �� DisplayMemberPath$
 	ShortName������ *InternalCustomerList+ �� SelectedValue �� *InternalCustomerID+�� -   $��button1��$��23��$
��Left=�$��
226,72,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query��7   1System.Windows.Forms.Integration.WindowsFormsHost  $��
15,104,0,0q�$	��370��$
��Left=�$	��258��$	��Top=�   Child.   ZedGraph.ZedGraphControl  -   zedGraphControl��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns . $
��Auto��$   HorizontalScrollBarVisibility$
 Auto=�$
��Left=�$��	15,10,0,0q�$	��Top=�$
��Auto��   DataGridStyle#��[    DataGridRowStyle   RowStyle# [ $��1��$y�Hidden=����� �� -   $��label3��$
��Bold"�$��15(�$��36��$��Center=�$��0,6,0,0q�$	��Top=�$��1����  *PhysicalAmount+�� -	   $��label6��
���<��$��28��$
��Left=�$��Right=�$��	20,38,0,0q�$	��Top=�$��63��$��1����  $! Client.Properties.Resources��$ 	StartDate��(  "System.Windows.Controls.DatePicker  -
   $��datePicker3��$��23��$
��Left=�$��
100,40,0,0q�$	��Top=�$	��100��$��1��   SelectedDate �� *	StartDate+�� -   $��label7��$��Right=�
���<��$��28��$
��Left=�$��
200,38,0,0q�$	��Top=�$��62��$��1����  $! Client.Properties.Resources��$ EndDate��  -   $��datePicker4��$��23��$
��left=�$��270,40,27,0q�$	��Top=�$	��100��$��1�� �� *	EndDate+�� -   $��label8��$��28��$
��Left=�$��	20,70,0,0q�$	��Top=�$��63��$��Right=�$��1����  $! Client.Properties.Resources��$ InternalCustomerShort��   $! Client.Properties.Resources��$ InternalCustomer���� -   $��	comboBox4��$��23��$
��Left=�$��
100,72,0,0q�$	��Top=�$	��100��$	 Id��$
 	ShortName��$��1������ *InternalCustomerList+ �� *InternalCustomerID3+�� -   $��button3��$��23��$
��Left=�$��
270,72,0,0q�$	��Top=�$��75��$��1����  $! Client.Properties.Resources��$ Query��  $��
20,104,0,0q�$	��370��$
��Left=�$	��258��$	��Top=�$��1��.   -   zedGraphControlBar��  -   $��	dataGrid3�� .   .  . $
��Auto��$
 Auto=�$
��Left=�$��	20,10,0,0q�$y�Hidden=�$	��Top=�$
��Auto��#��[  # [ $��1��$��1������ 