   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5      S OZedGraph, Version=5.1.5.28844, Culture=neutral, PublicKeyToken=02a83cbd123fcd605(clr-namespace:ZedGraph;assembly=ZedGraphZedGraph 5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      2   ,Client.View.Console.DashBoard.DashBoardChart   5      WwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  5      5zedgraph(clr-namespace:ZedGraph;assembly=ZedGraph  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Console.DashBoard.ResDashBoard��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   !     *	DashBoard+.��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   5      �� 5      $
��Auto �6#   5       � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   .+�5      �� -   5        $��label2��5      $
��Bold"�5   7   $��15(�6I   $��0,6,0,0q�6W   $��36��6h   $	��Top=�5      $��Center=�66   ��5        *PhysicalInventory+5   6   �� 5      -   5        $��label1��5   #   $��28��5   �   $��60��6�   $��Right=�6�   $
��Left=�6�   $��	15,70,0,0q�5      $	��Top=�61   ��5           ResxName$! Client.Properties.Resources��
   Key$ InternalCustomerShort�� � ToolTip 6e     $! Client.Properties.Resources��$ InternalCustomer��5   1   �� 5      -   5        $��	comboBox1��5   Q   $��23��6   $
��Left=�6#   $��	82,72,0,0q�6>   $	��Top=�6b   $	��120��5       	 �� SelectedValuePath$	 Id��6L   
 �� DisplayMemberPath$
 	ShortName��5!   @   ��5       �� *InternalCustomerList+ �� SelectedValue 5!      �� *InternalCustomerID+6@   �� 5"      -   5        $��button1��5"   �   $��23��6V   $
��Left=�6b   $��
226,72,0,0q�6}   $	��Top=�5#      $��75��6)   ��5"        $! Client.Properties.Resources��$ Query��5#   4   7   1System.Windows.Forms.Integration.WindowsFormsHost  5$      $��
15,104,0,0q�6#   $	��370��67   $
��Left=�6C   $	��258��6^   $	��Top=�6k      Child. 5%        ZedGraph.ZedGraphControl  -   5        zedGraphControl��5%   +   5&      &   System.Windows.Controls.DataGrid  5'      -   5        $��	dataGrid1��5(   t      CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns . $
��Auto��6   $   HorizontalScrollBarVisibility$
 Auto=�6!   $
��Left=�6F   $��	15,10,0,0q�6a   $	��Top=�5)      $
��Auto��6+      DataGridStyle#��[  68     DataGridRowStyle   RowStyle# [ 6_   $��1��6�   $y�Hidden=�6�   ��5'   [   �� 5)   �   �� 5+      -   5        $��label3��5,   !   $
��Bold"�5+   4   $��15(�6F   $��36��6T   $��Center=�6`   $��0,6,0,0q�5,      $	��Top=�6/   $��1��6G   ��5+        *PhysicalAmount+5,   G   �� 5-      -	   5        $��label6��5.      
���<��$��28��5-   n   $
��Left=�6z   $��Right=�6�   $��	20,38,0,0q�6�   $	��Top=�5.      $��63��66   $��1��6A   ��5-        $! Client.Properties.Resources��$ 	StartDate��5.   A   (  "System.Windows.Controls.DatePicker  5/      -
   5        $��datePicker3��5/   T   $��23��6   $
��Left=�6%   $��
100,40,0,0q�6@   $	��Top=�50      $	��100��6-   $��1��6\      SelectedDate 69   �� *	StartDate+6\   �� 51      -   5        $��label7��52      $��Right=�51   W   
���<��$��28��6�   $
��Left=�6�   $��
200,38,0,0q�6�   $	��Top=�52      $��62��66   $��1��6A   ��51        $! Client.Properties.Resources��$ EndDate��52   A     53      -   5        $��datePicker4��53   U   $��23��6   $
��left=�6%   $��270,40,27,0q�6@   $	��Top=�54      $	��100��6-   $��1��6Z    69   �� *	EndDate+6Z   �� 55      -   5        $��label8��55   �   $��28��6�   $
��Left=�6�   $��	20,70,0,0q�6�   $	��Top=�56      $��63��6(   $��Right=�63   $��1��6V   ��55        $! Client.Properties.Resources��$ InternalCustomerShort�� 6e     $! Client.Properties.Resources��$ InternalCustomer��56   V   �� 57      -   5        $��	comboBox4��57   R   $��23��6   $
��Left=�6#   $��
100,72,0,0q�6>   $	��Top=�6c   $	��100��58      $	 Id��6L   $
 	ShortName��59   A   $��1��6_   ��58      �� *InternalCustomerList+ 59      �� *InternalCustomerID3+6_   �� 5:      -   5        $��button3��5:   �   $��23��6V   $
��Left=�6b   $��
270,72,0,0q�6}   $	��Top=�5;      $��75��6)   $��1��6I   ��5:        $! Client.Properties.Resources��$ Query��5;   I     5<      $��
20,104,0,0q�6#   $	��370��67   $
��Left=�6C   $	��258��6^   $	��Top=�6k   $��1��6�   . 5=        -   5        zedGraphControlBar��5=   +   5>        5?      -   5        $��	dataGrid3��5@   t    .   .  . $
��Auto��6   $
 Auto=�6!   $
��Left=�6F   $��	20,10,0,0q�6a   $y�Hidden=�6�   $	��Top=�5A      $
��Auto��6+   #��[  68   # [ 6_   $��1��6�   $��1��6�   ��5?   [   �� 5A   �   5B      5C      5D      