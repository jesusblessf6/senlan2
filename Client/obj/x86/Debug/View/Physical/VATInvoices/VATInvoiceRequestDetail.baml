   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6K   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      >   8Client.View.Physical.VATInvoices.VATInvoiceRequestDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      6
Convertersclr-namespace:Client.Converters     6K   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *VATInvoiceRequest+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker 
 Delete  Edit  Actions �� DataType �� Orientation	   ResxName

   Key.  (Client.Converters.ApproveStatusConverter  asConverter��%Y  &	        '�� �     '�� m    '  �    &	 [    &	 n    &	 �    7  7  &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5       �� 5"   
   "  6   .�5#      ��  � ��$ 23��6'   64   �� 5$       � ��$	 120��6&   64   5%      �� 5'   
   6)   �� 5(   
   6'   �� 5)   
   $$ DBEntity:VATInvoiceRequestLine��6'   .R�5*      �� $ 
Horizontal=�6   .+�5+      �� $��btEdit��6   8��  ��6'     $!	 Client.Properties.Resources��$

 Edit����6�   �� *Id+6�   �� 5,      $��	btnDelete��6   8�� ��6*     $!	 Client.Properties.Resources��$
 Delete����6�   �� *Id+6�   5-      5.        5/   
   6B   50       J� CommandBindings 52      )  #System.Windows.Input.CommandBinding  53   
   -   5           Command# [ 53      6u     54   
   -   5        # [ 54      6o   .��57      �� $
��Auto=�6   $
��Auto=�68   .��58   
   � -   5         �Name$ rootGrid��58       � RowDefinitions 59      �� 5:      $
��auto �6    �� 5;      $
��auto �6    �� 5<      $
��auto �6    �� 5=      $
��auto �6    .+�5@      �� -   5        $��lbTitle��5@   7   $��32��6F   $
��Left=�6R   $��6,6,0,0q�6m   $
��auto��6~   $	��Top=�5A      $
��Bold"�6,   $��16(�6>   ��5@        *VATInvoiceRequest+5A   >   �� 5B      -   5        $��label7��5C      #��[  5B   U   $
��Left=�6y   $��6,38,0,0q�6�   $	��Top=�5C   "   
���<����5B        $!	 Client.Properties.Resources��$
 Buyer��5C   :   �� 5D      -   5        $��textBox5��5D   E   $
��Left=�6   $��
122,40,0,0q�61   $	��Top=�6U   {�.  ��5E      �� *BPName+6.   �� 5F      -   5        $��button2��5F   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,40,0,0q�6J   $	��Top=�5G      $��25��6-   68   �� 5H      -   5        $��label13��5I      #��[  5H   /   $
��Left=�6S   $��
278,38,0,0q�6n   $	��Top=�5I   #   
���<����5H        *	InvoiceBP+5I   ;   �� 5J      -	   5        $��	comboBox5��5J   F   $
��Left=�6   $��
394,40,0,0q�62   $	��Top=�6W    �� SelectedValuePath$ Id��5K   ;    �� DisplayMemberPath$ 	ShortName��6R   ��6   �� *InternalBPs+ �� SelectedValue 5L      �� *InternalBPId+�� 5M      -
   5        $��label9��5N      #��[  5M   Y   $
��Left=�6}   $��6,70,0,0q�6�   $	��Top=�5N   "   ��5M        $!	 Client.Properties.Resources��$
 	ApplyDate��5N   "     5O      -   5        $��datePicker1��5O   H   $
��Left=�6   $��
122,72,0,7q�64   $	��Top=�6[      SelectedDate 5P      �� *RequestDate+&   System.Windows.Controls.DataGrid  5Q      -   5        $��vatdataGrid��5Q   a      AutoGenerateColumns .  $
��Left=�63   $��	122,2,0,7q�6N   $	��Top=�5R         
IsReadOnly . $��2��6A      Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6k      CanUserSort .    Header 6)     $!	 Client.Properties.Resources��$
 QuotaNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5U   )   �� *Quota.QuotaNo+6M     5V      $
 Auto	 6l    .  6)     $!	 Client.Properties.Resources��$
 Quantity�� 5W   )   �� *UnOpenedQuantity+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6�     5X      $
 Auto	 6q    .  6)     $!	 Client.Properties.Resources��$
 AppliedAmount�� 5Y   )   �� *RequestAmount+   
STR_AMOUNT# Z 6�     5Z      $
 Auto	 6�    .  6)     $4	 .Client.View.Physical.VATInvoices.ResVATInvoice��$
 InvoicePrice�� 5[   )   �� *RequestPrice+   	STR_PRICE# Z 6�     5\      $
 Auto	 6q    .  6)     $!	 Client.Properties.Resources��$
 ApplyQuantity�� 5]   )   �� *RequestQuantity+# Z 6�     5^      $ 申请已开数量��6)   $
 Auto	 69    .  5_   )   �� *VATInvoicedQuantity+# Z 6�     5`      $
 Auto	 6r    .  6)     $!	 Client.Properties.Resources��$
 ApprovalStatus�� 5a   )   �� *ApproveStatus+ �� 	Converter# [ 6u   4  .System.Windows.Controls.DataGridTemplateColumn  5b      $
 Auto	 6q    .     CellTemplate# [ 5c   -    5b   -     $!	 Client.Properties.Resources��$
 	Operation��5c   W   5e      $   Utility.Controls.PagingControl  5f      -   5        $��	pagerList��5f   M   $
��Left=�6   $��	122,0,0,0q�6:   $	��Top=�6^   $��2��5g      $y�	Collapsed=�6,   �� 5i      -   5        $��label15��5j      #��[  5i   X   $
��Left=�6|   $��6,0,0,0q�6�   $	��Top=�5j   #   $��3��6;   ��5i        $!	 Client.Properties.Resources��$
 Comments��5j   ;   �� 5k      -   5        $��textBox7��5k   Q   $	��100��6   $
��Left=�6#   $��	122,2,0,0q�6>   $	��Top=�6a   $	��392��5l      $��3��6;   ��6"   �� *	Comment+6;   �� 5m      -   5        $��button3��5m   �   $��23��6U   $
��Left=�6a   $��210,130,0,0q�6|   $	��Top=�5n      $��60��6-   $��3��6E   ��5m        $!	 Client.Properties.Resources��$

 Save��5n   E   �� 5o      -   5        $��button4��5o   �   $��23��6W   $
��Left=�6c   $��305,130,0,0q�6~   $	��Top=�5p      $��60��6-   $��3��6G   ��5o        $!	 Client.Properties.Resources��$
 Cancel��5p   G   �� 5q      -   5        $��button5��5r      $��23��5q   \   $y�Hidden=�6h   $
��Left=�6|   $��378,134,0,0q�6�   $	��Top=�5r   $   $��60��6<   $��3��6G   ��5q        $!	 Client.Properties.Resources��$
 SaveAsDraft��5r   G   �� 5s      -   5        $��button6��5s   �   $��23��6^   $
��Left=�6j   $��	122,2,0,7q�6�   $	��Top=�5t      $��45��6-   $��1��6L   ��5s        $!	 Client.Properties.Resources��$
 AddWithSymbol��5t   L   �� 5u      -   5        $��label2��5v   %   #��[  5u   V   $��1��6z   $
��Left=�6�   $��6,0,0,0q�5v      $	��Top=�63   ��5u        $!	 Client.Properties.Resources��$
 Detail��5v   3   �� 5w      -   5        $��button1��5w   _   $��+批量新增��6   $��23��6%   $
��Left=�61   $��	173,2,0,7q�6L   $	��Top=�6n   $��75��6�   $��1��6�   5x      5y      5z      