   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5      S OZedGraph, Version=5.1.5.28844, Culture=neutral, PublicKeyToken=02a83cbd123fcd605(clr-namespace:ZedGraph;assembly=ZedGraphZedGraph 5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      '   !Client.View.Reports.ExposureChart   5      WwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  5      5zedgraph(clr-namespace:ZedGraph;assembly=ZedGraph  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   !     *ExposureTrend+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%�  &	        '�� �     '�� m    '  �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5!   
   "  6   .�5"      ��  � ��$ 23��6'   64   �� 5#       � ��$	 120��6&   64   5$      5%      .��5'      �� $
��Auto=�6   $
��Auto=�68   .��5(   
   � -   5         �Name$ rootGrid��5(      .+�5)      �� -   5         ��Name$ lbTitle��5)      $
��Left=�6D   $��6,6,0,0q�6_   $��32��6p   $	��Top=�5*      $
��Bold"�6,   $��16(�6>   ��5)   %     *ExposureTrend+5*   >   7   1System.Windows.Forms.Integration.WindowsFormsHost  5+      $��	6,166,0,0q�6#   $	��816��66   $
��Left=�6B   $	��280��6]   $	��Top=�5,   #   	   Child.	 5-        ZedGraph.ZedGraphControl  -   5        zedGraphControlLine��5-   +   5.      &   System.Windows.Controls.DataGrid  5/      -   5        $��	dataGrid2��50   w   
   CanUserAddRows
 .     
IsReadOnly .    AutoGenerateColumns . $	��170��6   $   HorizontalScrollBarVisibility$
 Auto=�6$   $
��Left=�6I   $��	6,452,0,0q�6d   $	��Top=�51      $	��816��6/   ��5/   [   �� 51   =   �� 52      -   5        $��	groupBox1��52   �   $	��100��6\   $
��Left=�6i   $��6,40,0,0q�6�   $	��Top=�53      $	��816��6/   ��52           ResxName$! Client.Properties.Resources��
   Key$ 
Conditions��.��54      � .+�55      �� -   5        $��label2��56   .   #��[  55   a   $
��Left=�6�   $��1,10,0,0q�56      $	��Top=�6<   ��55        $! Client.Properties.Resources��$ 	Commodity��56   <   �� 57      -   5        $��	comboBox2��57   N   $
��Left=�6   $��
107,12,0,0q�6:   $	��Top=�6_    �� SelectedValuePath$ Id��58   E    �� DisplayMemberPath$
 Name��59      ��58      �� *CommodityList+ �� SelectedValue 6\   �� *CommodityID+59      �� 5:      -   5        $��label3��5;   0   #��[  5:   h   $
��Left=�6�   $��
260,10,0,0q�5;      $	��Top=�6>   ��5:        $! Client.Properties.Resources��$ InternalCustomer��5;   >   �� 5<      -	   5        $��	comboBox3��5<   N   $
��Left=�6   $��
366,12,0,0q�6:   $	��Top=�6_   $ Id��5=   L   $ 	ShortName��5>      ��5=      �� *InternalCustomerList+ 6c   �� *InternalCustomerID2+5>      �� 5?      -
   5        $��label4��5@   I   
���<��#��[  5?   v   $
��Left=�5@      $��1,42,0,0q�67   $	��Top=�6W   ��5?        $! Client.Properties.Resources��$ 	StartDate��5@   W     5A      -   5        $��datePicker1��5A   P   $
��Left=�6!   $��
107,44,0,0q�6<   $	��Top=�5B   !      SelectedDate 69   �� *	StartDate+�� 5C      -   5        $��label5��5D   K   
���<��#��[  5C   t   $
��Left=�5D      $��
260,42,0,0q�67   $	��Top=�6Y   ��5C        $! Client.Properties.Resources��$ EndDate��5D   Y     5E      -   5        $��datePicker2��5E   P   $
��Left=�6!   $��
366,44,0,0q�6<   $	��Top=�5F   !    69   �� *	EndDate+�� 5G      -   5        $��button2��5G   �   $��23��6^   $
��Left=�6j   $��
625,44,0,0q�6�   $	��Top=�5H      $��75��65   ��5G        $! Client.Properties.Resources��$ Query��5H   @   �� 5I      -   5        $��label1��5I   �   
���<��$	��120��6U   $��28��6a   $��Right=�6m   $
��Left=�6�   $��
499,10,0,0q�6�   $	��Top=�6�   ��6     *DomesticHedgeRatio+6�   �� 5J      -   5        $��textBox1��5J   Y   $��23��6   $
��Left=�6*   $��
625,12,0,0q�6E   $	��Top=�6i   $	��120��6�   ��6�   �� *ProportionValue+5K      5L      �� 5M      -   5        $��
separator1��5M   9   $��17��6   $��6,146,132,0q�6$   $	��Top=�6K   5N      5O      5P      