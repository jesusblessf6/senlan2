   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  6:   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      6    0Client.View.Reports.ExternalDeliveryCirculReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      6Q   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     6:   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5	   J     *ForeignBLWRFlowReport+ � 	Resources 5
       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker/   )Client.Converters.LineType2ColorConverter  LineTypeConverter  	LineStyle �� 	Converter��%  &	        '�� �     '�� m    '  �    &	 [    &	 n    7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5        � ��$	 120��6&   64   5!        5#   
   6@   �� 5%   
   " ��6"   .�5&      ��  � �� 6+   �� *
LineType+8   6v   5'      5(      .��5*      �� $
��Auto=�6   $
��Auto=�68   .��5+   
   � -   5        $��rootGrid��5+      .+�5,      �� -   5        $��lbTitle��5,   ;   $
��Left=�6J   $��6,6,0,0q�6e   $��32��6v   $	��Top=�5-      $
��Bold"�6,   $��16(�6>   ��5,        *ForeignBLWRFlowReport+5-   >   �� 5.      -   5        $��
separator1��5.   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   &   System.Windows.Controls.DataGrid  5/      -   5        $��	dataGrid1��50         AutoGenerateColumns .  $
��Auto��5/   3   $
��Left=�6A   $��	6,166,0,0q�6\   $	��Top=�50   (   $
��Auto��6@   	   
IsReadOnly	 . ��6_   �� *	Summaries+
   Columns
 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6}   1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [ 53   )      Header 52   )        ResxName$! Client.Properties.Resources��
   Key$ FlowId��53   U     54       . $
 Auto 6�   # [ 55   H    54   )     $# Client.View.Reports.ResReport��$ 
DocumentNo�� 	  Binding 55   )   �� *
DeliveryNo+6t     56       . $
 Auto 6�   # [ 57   J    56   )     $! Client.Properties.Resources��$ DocumentType�� 57   )   �� *DeliveryType+6v     58       . $
 Auto 6�   # [ 59   _    58   )     $# Client.View.Reports.ResReport��$ PurchaseDate�� 59   )   �� *	BuyDate+ �� StringFormat$ 
yyyy-MM-dd��6�     5:       . $
 Auto 6|   # [ 5;   G    5:   )     $! Client.Properties.Resources��$ Buyer�� 5;   )   �� *	BuyBPName+6s     5<       . $
 Auto 6�   # [ 5=   `    5<   )     $# Client.View.Reports.ResReport��$ 	SalesDate�� 5=   )   �� *
SellDate+$ 
yyyy-MM-dd��6�     5>       . $
 Auto 6   # [ 5?   H    5>   )     $! Client.Properties.Resources��$ Supplier�� 5?   )   �� *
SellBPName+6t     5@       . $
 Auto 6�   # [ 5A   )    5@   )     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *CommodityName+5A   U     5B       . $
 Auto 6|   # [ 5C   G    5B   )     $! Client.Properties.Resources��$ Brand�� 5C   )   �� *	BrandName+6s     5E       . $
 Auto 6�   # [ 5F   �    5E   )     $! Client.Properties.Resources��$ 	NetWeight�� 5F   )   �� *	NetWeight+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY# Z 6�     5G       . $
 Auto 6�   # [ 5H   �    5G   )     $! Client.Properties.Resources��$ GrossWeight�� 5H   )   �� *GrossWeight+# Z 6�     5I       . $
 Auto 6�   # [ 5J   C    5I   )     $# Client.View.Reports.ResReport��$ LoCInfo�� 5J   )   �� *LCMsg+6o    �� 
GroupStyle 5L      (  "System.Windows.Controls.GroupStyle  5M        GroupHerderStyle   ContainerStyle# [ 6!      Panel 5N      �� 5O      .R�5P   "   >  8System.Windows.Controls.Primitives.DataGridRowsPresenter  5Q      5S         RowStyle 5U      �� 5V      )  #System.Windows.Controls.DataGridRow"  6   .�5W      ��  � ��
 �����67    �� Triggers 5X      P� 5Y       P� Property �@ 
IsSelected P� Value . . �5Z   "   ��  � ��
 ����6?   �� 5[   "    � ��
 ����6?   5\      5^         	CellStyle 5`      �� 5a      *  $System.Windows.Controls.DataGridCell"  6    5b      P� 5c       �@ 
IsSelected . . �5d   "   ��  � ��
 ����6?   �� 5e   "    � ��
 ����6?   5f      5h      5j      �� 5k      -   5        $��	groupBox1��5k   �   $	��100��6\   $
��Left=�6i   $��6,40,0,0q�6�   $	��Top=�5l      $	��800��6/   ��5k        $! Client.Properties.Resources��$ 
Conditions��.��5m      � .+�5n      �� -   5        $��label1��5o   .   #��[  5n   ^   $
��Left=�6�   $��1,10,0,0q�5o      $	��Top=�6<   ��5n        $! Client.Properties.Resources��$ FlowId��5o   <   �� 5p      -   5        $��label3��5q   0   #��[  5p   a   $
��Left=�6�   $��
260,10,0,0q�5q      $	��Top=�6>   ��5p        $! Client.Properties.Resources��$ 	StartDate��5q   >     5r      -   5        $��datePicker1��5r   P   $
��Left=�6!   $��
366,12,0,0q�6<   $	��Top=�5s   !      SelectedDate 69   �� *	StartDate+�� 5t      -	   5        $��label4��5t   �   #��[  6_   $
��Left=�6�   $��
260,42,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ EndDate��6�     5u      -
   5        $��datePicker2��5u   P   $
��Left=�6!   $��
366,44,0,0q�6<   $	��Top=�5v   !    69   �� *	EndDate+�� 5w      -   5        $��label5��5x   0   #��[  5w   h   $
��Left=�6�   $��
519,10,0,0q�5x      $	��Top=�6>   ��5w        $! Client.Properties.Resources��$ InternalCustomer��5x   >   �� 5y      -   5        $��	comboBox3��5y   N   $
��Left=�6   $��
625,12,0,0q�6:   $	��Top=�6_    �� DisplayMemberPath$ 	ShortName��5z   I    �� SelectedValuePath$ Id��6g   ��6   �� *InternalCustomers+ �� SelectedValue 5{      �� *SelectedInternalCustomerId+�� 5|      -   5        $��button1��5|   �   $��23��6^   $
��Left=�6j   $��
625,44,0,0q�6�   $	��Top=�5}      $��75��65   ��5|        $! Client.Properties.Resources��$ Query��5}   @   �� 5~      -   5        $��label2��5   .   #��[  5~   ]   $
��Left=�6�   $��1,42,0,0q�5      $	��Top=�6<   ��5~        $! Client.Properties.Resources��$ Buyer��5   <   �� 5�      -   5        $��textBox2��5�   k   $��23��6   $
��Left=�6*   {�.  $��
107,44,0,0q�6W   $	��Top=�6�   $	��120��6�   ��6{   �� *BPName+6�   �� 5�      -   5        $��button2��5�   f   $	��...��6   $��23��6+   $
��Left=�67   $��
231,44,0,0q�6R   $	��Top=�6u   $��25��6�   6�   �� 5�      -   5        $��textBox3��5�   M   $
��Left=�6   $��
107,12,0,0q�69   $	��Top=�6w   ��6]   �� *
CirculNo+6w   5�      5�      5�      5�      5�      