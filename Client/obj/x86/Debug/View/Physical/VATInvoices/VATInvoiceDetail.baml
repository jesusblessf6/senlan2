   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6K   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      7   1Client.View.Physical.VATInvoices.VATInvoiceDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6K   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   J     *VATInvoiceIssuing+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker 
 Delete  Edit  Actions �� DataType �� Orientation	   ResxName

   Key��%5  &	        '�� �     '�� m    '  �    &	 [    &	 n    &	 �    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5    
   "  6   .�5!      ��  � ��$ 23��6'   64   �� 5"       � ��$	 120��6&   64   5#      �� 5%   
   6)   �� 5&   
   6'   �� 5(   
   $ DBEntity:VATInvoiceLine��6'   .R�5)      �� $ 
Horizontal=�6   .+�5*      �� $��btEdit��6   8��  ��6'     $!	 Client.Properties.Resources��$

 Edit����6�   �� *Id+6�   �� 5+      $��	btnDelete��6   8�� ��6*     $!	 Client.Properties.Resources��$
 Delete����6�   �� *Id+6�   5,      5-      5.       J� CommandBindings 50      )  #System.Windows.Input.CommandBinding  51   
   -   5           Command# [ 51      6u     52   
   -   5        # [ 52      6o   .��55      �� $
��Auto=�6   $
��Auto=�68   .��56   
   � -   5         �Name$ rootGrid��56       � RowDefinitions 57      �� 58      $	��134 �6    �� 59      $��31 �6    �� 5:      $
��auto �6    �� 5;      $
��auto �6    �� 5<      $	��55* �6    .+�5?      �� -   5        $��button2��5?   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,40,0,0q�6J   $	��Top=�5@      $��25��6-   68   �� 5A      -   5        $��	comboBox5��5A   G   $
��Left=�6   $��122,104,0,7q�62   $	��Top=�6X    �� SelectedValuePath$ Id��5B   ;    �� DisplayMemberPath$ 	ShortName��6R   ��6   �� *InternalBPs+ �� SelectedValue 5C      �� *InternalBPId+  5D      -   5        $��datePicker1��5D   H   $
��Left=�6   $��
122,72,0,0q�64   $	��Top=�6[      SelectedDate 5E      �� *InvoicedDate+�� 5F      -   5        $��textBox1��5G   Q    �� AcceptsReturn .  �� 
AcceptsTab .   �� TextWrapping$
 Wrap=�5F   >   " �� VerticalScrollBarVisibility$
 Auto=�6R   $��87��5G      $
��Left=�6"   $��
394,40,0,0q�6=   $	��Top=�5H      $	��215��6.   ��5G   a   �� *	InvoiceNo+5H   .   &   System.Windows.Controls.DataGrid  5I      -   5        $��vatdataGrid��5I   a      AutoGenerateColumns .  $
��Left=�63   $��	122,2,0,7q�6N   $	��Top=�5J         
IsReadOnly . $��3��6A      Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6k      CanUserSort .    Header 6)     $!	 Client.Properties.Resources��$
 QuotaNo��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5M   )   �� *Quota.QuotaNo+6M     5N      $ 批次未开数量��6)   $
 Auto 69    .  5O   )   �� *UnOpenedQuantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY �� StringFormat# Z 6�     5P      $ 批次已开数量��6)   $
 Auto 69    .  5Q   )   �� *Quota.VATInvoicedQuantity+# Z 6�     5R      $
 Auto 6�    .  6)     $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 
InvoiceQty�� 5S   )   �� *VATInvoiceQuantity+# Z 6�     5T      $
 Auto 6�    .  6)     $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 InvoiceAmount�� 6�   �� *	VATAmount+  
  
STR_AMOUNT# Z  6�     5U      $
 Auto 6�    .  6)     $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 InvoicePrice�� 6�   �� *
VATPrice+! 
  	STR_PRICE# Z! 6�     5V      $
 Auto 6k    .  6)     $!	 Client.Properties.Resources��$
 TaxRate�� 5W   )   �� *VATRate.Code+6L   4  .System.Windows.Controls.DataGridTemplateColumn  5X      $
 Auto 6q    .  "   CellTemplate#" [ 5Y   -    5X   -     $!	 Client.Properties.Resources��$
 	Operation��5Y   W   5[      $   Utility.Controls.PagingControl  5\      -	   5        $��	pagerList��5\   M   $
��Left=�6   $��	122,0,0,0q�6:   $	��Top=�6^   $��2��5]      $y�	Collapsed=�6,   �� 5^      -
   5        $��textBox7��5_   Q    .  .  $
 Wrap=�5^   >   $
 Auto=�6R   $	��100��5_      $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   $	��392��6y   $��4��5`   /   ��6   �� *	Comment+6/   �� 5a      -   5        $��button3��5a   �   $��23��6U   $
��Left=�6a   $��210,130,0,0q�6|   $	��Top=�5b      $��60��6-   $��4��6E   ��5a        $!	 Client.Properties.Resources��$

 Save��5b   E   �� 5c      -   5        $��button5��5d      $��23��5c   \   $y�Hidden=�6h   $
��Left=�6|   $��421,134,0,0q�6�   $	��Top=�5d   $   $��60��6<   $��4��6G   ��5c        $!	 Client.Properties.Resources��$
 SaveAsDraft��5d   G   �� 5e      -   5        $��button4��5e   �   $��23��6W   $
��Left=�6c   $��305,130,0,0q�6~   $	��Top=�5f      $��60��6-   $��4��6G   ��5e        $!	 Client.Properties.Resources��$
 Cancel��5f   G   �� 5g      -   5        $��lbTitle��5g   7   $��32��6F   $
��Left=�6R   $��6,6,0,0q�6m   $
��auto��6~   $	��Top=�5h      $
��Bold"�6,   $��16(�6>   ��5g        *VATInvoiceIssuing+5h   >   �� 5i      -   5        $��lbPBName��5j      #��[  5i   U   $
��Left=�6y   $��6,40,0,0q�6�   $	��Top=�5j   $   
���<����5i        $!	 Client.Properties.Resources��$
 Buyer��5j   <   �� 5k      -   5        $��textBox5��5k   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   {�.  ��5l      �� *BPName+6.   �� 5m      -   5        $��label2��5n      #��[  5m   Y   $
��Left=�6}   $��
278,38,0,0q�6�   $	��Top=�5n   "   ��5m        $!	 Client.Properties.Resources��$
 	InvoiceNo��5n   "   �� 5o      -   5        $��label9��5p      #��[  5o   [   $
��Left=�6   $��6,70,0,0q�6�   $	��Top=�5p   "   ��5o        $!	 Client.Properties.Resources��$
 InvoiceDate��5p   "   �� 5q      -   5        $��label13��5r      #��[  5q   /   $
��Left=�6S   $��	6,102,0,0q�6n   $	��Top=�5r   #   
���<����5q        *	InvoiceBP+5r   ;   �� 5s      -   5        $��label15��5t      #��[  5s   X   $
��Left=�6|   $��6,0,0,0q�6�   $	��Top=�5t   #   $��4��6;   ��5s        $!	 Client.Properties.Resources��$
 Comments��5t   ;   �� 5u      -   5        $��button6��5u   �   $
��Left=�6^   $��	122,2,0,7q�6y   $��45��6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 AddWithSymbol��6�   �� 5v      -   5        $��label1��5w      #��[  5v   3   $
��Left=�6W   $��6,0,0,0q�6r   $	��Top=�5w   "   $��1��6:   $��2��6G   ��5v        *InvoiceDetail+5w   G   5x      5y      5z      