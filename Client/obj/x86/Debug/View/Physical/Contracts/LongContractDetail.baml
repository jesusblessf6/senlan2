   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5   2   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 6c   7    1Client.View.Physical.Contracts.LongContractDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5   2   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      >my/clr-namespace:Utility.Controls;assembly=Utility     6c   0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *LongContract+ � 	Resources 5       �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker,   &Client.Converters.PricingTypeConverter   PricingTypeConverter  AttachmentDownLoad  AttachmentDelete  	QuotaEdit  QuotaDelete  PricingView  AttachmentActions �� DataType �� Orientation	   ResxName

   Key  QuotaActions��%�  '��       '�� �     '��     '  �    &	      &	     &	 .    &	 A    &	 T    &	 g    &	 z    7  7  &	 �    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5        � ��$	 120��6&   64   5!        5#   
   6*   �� 5%   
   65   �� 5&   
   63   �� 5'   
   6,   �� 5(   
   6.   �� 5)   
   6.   �� 5+   
   $ DBEntity:Attachment��61   .R�5,      �� $ 
Horizontal=�6   .+�5-      �� $��btAttachmentDownLoad��6   8��  ��65     $!	 Client.Properties.Resources��$
 Download����5.      �� *Id+6;   �� 5/      $��btAttachmentDelete��6   8�� ��63     $!	 Client.Properties.Resources��$
 Delete����50      �� *Id+6;   51      52      �� 54   
   $ DBEntity:Quota��6,   .R�55      �� $ 
Horizontal=�6   .+�56      �� $��btQuotaEdit��6   8��  ��6,     $!	 Client.Properties.Resources��$

 Edit����57      �� *Id+6;   �� 58      $��btQuotaDelete��6   8�� ��6.     $!	 Client.Properties.Resources��$
 Delete����59      �� *Id+6;   5:      5;      5<       J� CommandBindings 5>      )  #System.Windows.Input.CommandBinding  5?   
   -   5           Command# [ 5?      5@   8     5A   
   -   5        # [ 5A      5B   :     5C   
   -   5        # [ 5C      5D   A     5E   
   -   5        # [ 5E      5F   ?     5G   
   -   5        # [ 5G      5H   :   .��5K      �� $
��Auto=�6   $
��Auto=�68   .��5L   
   � -   5         �Name$ rootGrid��5L       � RowDefinitions 5N      �� 5O      $
��auto �6    �� 5P      $
��auto �6    �� 5Q      $
��auto �6    �� 5R      $
��auto �6    �� 5S      $
��183* �6    .+�5V      �� -   5        $��lbTitle��5W   @   $�� ��5V      $��6,6,0,0q�6   $
��Left=�60   $
��Auto��6K   $	��Top=�6X   $
��Bold"�5W      $��32��6&   $��16(�62   6@   �� 5X      $��6,38,0,0q�6Z   $
��Left=�6l   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 
ContractNo��6�   �� 5Y      $��
122,40,0,0q�6   $	��Top=�6*   $
��Left=�6B   ��6]   �� *
ContractNo+�� 5Z      -   5         ��Name$ 
lbSupplier��5[   )   $��
278,38,0,0q�5Z   X   $
��Left=�6l   $	��Top=�6�   
���<����6     $!	 Client.Properties.Resources��$
 Supplier��5[   )   �� 5\      $��
394,40,0,0q�6   $	��Top=�6*   $
��Left=�6B    �� 
IsReadOnly . |�.  {�.  ��5]      �� *SupplierName+6X   �� 5^      -	   5         ��Name$ btnSupplier��5_   !   $	��...��5^      $��
518,40,0,0q�6#   $	��Top=�67   $
��Left=�6O   $��25��6j   $��23��5_      {�6O   �� *
IsBPEnable+�� 5`      $��6,70,0,0q�6.   $
��Left=�6@   
���<��$	��Top=�5a   )   ��5`        *
SignDate+5a   )     5b      $��
122,72,0,0q�6   $
��Left=�6-   $	��Top=�5c   ;      SelectedDate 6   �� *
SignDate+6;   �� 5d      $��
278,70,0,0q�6X   $
��Left=�6l   
���<��$	��Top=�5e   )   ��5d        $!	 Client.Properties.Resources��$
 SignSide��5e   )   �� 5f      -
   5        $��	comboBox2��5g   U    �� DisplayMemberPath$ 	ShortName��5f      $
��Left=�65   $��
394,72,0,0q�5g   A    �� SelectedValuePath$ Id��5h   L   $	��Top=�5i      ��5g      �� *InternalCustomers+ �� SelectedValue 5h      �� *SelectedInternalCustomerId+{�6c   �� *IsSignBPEnable+5i   /   �� 5k      $��6,32,0,0q�6U   $
��Left=�6g   $	��Top=�5l      $��2��6,   ��5k        $!	 Client.Properties.Resources��$
 Quota��5l   ,   �� 5m      -   5        $��btnAdd��5m   �   $��23��6^   $
��Left=�6j   $��
122,34,0,0q�6�   $	��Top=�5n      $��45��6-   $��2��6L   ��5m        $!	 Client.Properties.Resources��$
 AddWithSymbol��5n   L   &   System.Windows.Controls.DataGrid  5o      -   5        $��dataGridQuotas��5o   +   $��
122,66,0,7q�6      AlternatingRowBackground
 �����   CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�5q      $
��Auto��62   $
��Auto��6?   $	��Top=�6M   $��2��6e   ��5p   .   �� *Quotas+   Columns 5r      0  *System.Windows.Controls.DataGridTextColumn  5s      ,  &System.Windows.Controls.DataGridColumn   Header 6)     $!	 Client.Properties.Resources��$
 	Commodity��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6m   �� *Commodity.Name+  5t       6)     $!	 Client.Properties.Resources��$
 CommodityType�� 6q   �� *CommodityType.Name+  5u       6)     $!	 Client.Properties.Resources��$
 Brand�� 6i   �� *
Brand.Name+  5v       6)     $!	 Client.Properties.Resources��$
 Specification�� 6q   �� *Specification.Name+  5w       6)     $!	 Client.Properties.Resources��$
 Quantity�� 6l   �� *
Quantity+$
  DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY �� StringFormat# Z   5x       6)     $!	 Client.Properties.Resources��$
 PricingType�� 5y   )   �� *PricingType+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5z       6-     $!	 Client.Properties.Resources��$
 Price��    CellTemplate  5{      �� 5|      $ DBEntity:Quota��6+   .R�5}   "   �� �� 5~   &   ! �� Command#! [ 60   " �� CommandParameter" 6W   �� *Id+.�6w   .�5   *   �� �6.   �� *
StrPrice+6J   5�   '   5�   #   5�      5�        5�       6)     $!	 Client.Properties.Resources��$
 PricingStartDate�� 6t   �� *PricingStartDate+$ 
yyyy-MM-dd��  5�       6)     $!	 Client.Properties.Resources��$
 PricingEndDate�� 6r   �� *PricingEndDate+$ 
yyyy-MM-dd��  5�      #   CanUserSort# .  #  [ 5�   -    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�   -   5�      �� 5�      $��6,0,0,0q�6Z   $
��Left=�6k   $	��Top=�6�   $��3��6�   ��6     $!	 Client.Properties.Resources��$
 
Attachment��6�   �� 5�      -   5        $��button1��5�   �   $��23��6^   $
��Left=�6j   $��	122,2,0,0q�6�   $	��Top=�5�      $��45��6-   $��3��6M   ��5�        $!	 Client.Properties.Resources��$
 AddWithSymbol��5�   M     5�      -   5        $��dataGridAttachment��5�   X    .   .  $
��Left=�6    . $��
122,34,0,7q�6D   $
��Auto��6r   $��3��6   $
��auto��6�   $	��Top=�6�   ��5�   3   �� *Attachments+ 5�        5�       6)   �� *Name+ 6B     $!	 Client.Properties.Resources��$
 AttachmentName��  5�      # .  #  [ 6A    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�      �� 5�      $��6,0,0,0q�6X   $
��Left=�6i   $	��Top=�6�   $��4��6�   ��6     $!	 Client.Properties.Resources��$
 Comments��6�   �� 5�      $��	122,2,0,0q�6   $ �� TextWrapping$
$ Wrap=�6)   $
��Left=�6Z   $	��392��5�      $	��100��6"   $	��Top=�6/   $��4��6G   ��5�   =   �� *Description+5�   G   �� 5�      -   5        $��210,130,0,0q�5�   U   $��23��6j   $
��Left=�6v   $	��Top=�6�   $��60��5�      $��4��6-   ��5�        $!	 Client.Properties.Resources��$

 Save��5�   -   �� 5�      -   5        $��336,130,0,0q�5�   \   $��23��6q   $��60��6}   $
��Left=�6�   $	��Top=�5�      $��4��6-   $y�Hidden=�6x   ��5�        $!	 Client.Properties.Resources��$
 SaveAsDraft��{�5�   N   �� *IsSaveAsDraftEnable+6x   �� 5�      -   5        $��btCancel��5�   �   $��23��6W   $
��Left=�6c   $��305,130,0,0q�6~   $	��Top=�5�      $��60��6-   $��4��68   ��5�        $!	 Client.Properties.Resources��$
 Cancel��5�   E   �� 5�      $
��Left=�6S   $��	6,102,0,0q�6n   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$	
 UDF��6�   �� 5�      -   5        $��	comboBox1��5�   }   $
 Name��6   $
��Left=�60   $��122,104,0,7q�6h   $ Id��6�   $	��Top=�6�   ��6K   �� *Udfs+ 6�   �� *SelectedUsdId+6�   �� 5�      $
��Left=�66   $��269,102,0,0q�6Q   $	��Top=�6f   $	��119��6~   ��6     *OriginContractNo+6~   �� 5�      $
��Left=�6   $��394,104,0,7q�61   $	��Top=�6d   ��6F   �� *ExContractNo+6d   �� 5�      -   5        $��label1��5�   _   $��对手合同号��6   $��28��6$   $
��Left=�60   $��
278,32,0,0q�6K   $	��Top=�6m   $	��110��6�   $��1��6�   $��2��6�   y�6�   �� *IsAutoNoVisible+6�   �� 5�      -   5        $��textBox1��5�   Q   $��23��6   $
��Left=�6"   $��
394,34,0,0q�6=   $	��Top=�6a   $	��120��6y   $��1��6�   y�6�   �� *IsAutoNoVisible+��6�   �� *AutoContractNo+6�   �� 5�      -   5        $��label2��5�   k   $��数量上下浮��6   $��1��6$   $��28��61   $
��Left=�6=   $��	278,0,0,0q�6X   $	��Top=�6y   $	��110��6�   �� 5�      -   5        $��label3��5�   g   $��±��6   $��1��6    $��28��6-   $
��Left=�69   $��	388,0,0,0q�6T   $	��Top=�6u   $��22��6�   �� 5�      -   5        $��label4��5�   g   $��%��6   $��1��6    $��28��6-   $
��Left=�69   $��	508,1,0,0q�6T   $	��Top=�6u   $��23��6�   &   Utility.Controls.CurrencyTextBox  5�      -   5        $��currencyTextBox1��5�   h   $��1��6!   $��23��6.   $
��Left=�6:   $��	410,2,0,0q�6U   $	��Top=�6�   $	��103��6�   %   Text% 6�   �� *
QtyLimit+�� 5�      -   5        $��label5��5�   `   $��是否需要自动生成��6   $��28��6'   $
��Left=�63   $��6,32,0,0q�6N   $	��Top=�6n   $	��110��6�   $��1��6�   y�6�   �� *IsNeedAutoVisible+�� 5�      -   5        $��	checkBox1��5�   R   $��16��6   $
��Left=�6#   $��
122,38,0,0q�6>   $	��Top=�6c   $��1��6{   & d� 	IsChecked& 6�   �� *IsNeedAutoGenerated+y�6�   �� *IsNeedAutoVisible+�� 5�      -   5        $��label8��5�   [   $��银行账号��6   $��28��6#   $
��Left=�6/   $��6,0,0,0q�6J   $	��Top=�6i   $	��110��6�   $��1��6�   �� 5�      -   5        $��	comboBox4��5�   n   $
��Left=�6@   $��	122,2,0,7q�6[   $	��Top=�6   $ Id��5�   ?   $ Description��6V   $��1��5�   B   {�5�      �� *IsAccountPayEnable+��5�      �� *PayBankAccounts+ 5�      �� *PayBankAccountId+6B   �� 5�      -   5        $��label9��5�   Z   $��	业务员��6   $��28��6"   $
��Left=�6.   $��6,0,0,0q�6I   $	��Top=�6h   $	��110��6�   $��2��6�   �� 5�      -   5        $��	comboBox5��5�   R   $��23��6   $
��Left=�6#   $��	122,2,0,7q�6?   $	��Top=�6c   $	��120��6{   $
 Name��6�   $ Id��6�   $��2��6�   ��6�   �� *Users+ 6�   �� *SelectedUserId+6�   5�   
   5�      5�      