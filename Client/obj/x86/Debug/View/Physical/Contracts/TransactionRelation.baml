   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5   	   B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   1   
 Client8   2Client.View.Physical.Contracts.TransactionRelation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5   	   >my/clr-namespace:Utility.Controls;assembly=Utility     5   1   -   5          � Title$  关联交易明细��5   	   $	��199��6   $	��550��6%    � WindowStartupLocation$ CenterScreen=�6l    � WindowStyle$ SingleBorderWindow=�6�    � 
ResizeMode$ NoResize=�6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� �     '��     �� 5   
   " ��6   .�5	      ��  � ��$ 28��6'   64   �� 5
       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5      .��5      � -   5        $��rootGrid��5       � RowDefinitions 5   
   �� 5      $	��96* �6   �� 5      $	��64* �6   .+�5   
   �� -   5        $��label1��5   �   $��6,39,0,0q�6\   $��28��6n   $	��110��6z   $��Right=�6�   $
��Left=�6�   $	��Top=�6�   
���<����6   0  *Infralution.Localization.Wpf.ResxExtension  	   ResxName$!	 Client.Properties.Resources��

   Key$
 InternalCustomer��6�   �� 5   
   -   5        $��	comboBox1��5   N   $��23��6   $
��Left=�6   $��
122,40,0,0q�6:   $	��Top=�6_   $	��120��6w    �� SelectedValuePath$ Id��5!       �� DisplayMemberPath$ 	ShortName��6*   ��5       �� *InnerCustomers+ �� SelectedValue 6:   �� *SelectedInternalCustomerId+{�5!   H   �� *IsRelBPEnable+�� 5"   
   -   5        $��label2��5"   �   $��28��6Q   $
��Left=�6]   $��
240,39,0,0q�6x   $	��Top=�6�   
���<����6     $!	 Client.Properties.Resources��$
 Price��6�   &   Utility.Controls.CurrencyTextBox  5#   
   -   5        $��currencyTextBox1��5#   X   $��23��6   $
��Left=�6)   $��
356,40,0,0q�6D   $	��Top=�6p   $	��120��6�      Text 6�   �� *Price+$   DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z {�6�   �� *IsPriceEnable+�� 5$   
   -   5        $��button1��5$   �   $��23��6Q   $
��Left=�6]   $��
210,25,0,0q�6x   $	��Top=�6�   $��60��6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$

 Save��6�   �� 5%   
   -   5        $��button2��5%   �   $��23��6S   $
��Left=�6_   $��
305,25,0,0q�6z   $	��Top=�6�   $��60��6�   $��1��6�   ��6     $!	 Client.Properties.Resources��$
 Cancel��6�   �� 5&   
   -	   5        $��lbTitle��5&   �   $��关联交易明细��6   $��32��6!   $
��Left=�6-   $��6,6,0,0q�6H   $
��auto��6Y   $	��Top=�6f   $
��Bold"�6~   $��16(�6�   6�   �� 5'   
   -
   5        $��label3��5'   �   $��签署日期��6   
���<��$��28��64   $
��Left=�6@   $��Right=�6[   $��6,71,0,0q�6~   $	��Top=�6�   $	��110��6�   $��2��6�   (  "System.Windows.Controls.DatePicker  5(   
   -   5        $��datePicker1��5(   D   $
��Left=�6   $��
122,72,0,0q�60   $	��Top=�6y   $	��120��6�      SelectedDate 6W   �� *
SignDate+{�6�   �� *IsDateEnable+�� 5)   
   -   5        $��label4��5)   k   $��收票日期��6   $��2��6   $��28��60   $
��Left=�6<   $��
241,70,0,0q�6W   $	��Top=�6y   $	��110��6�     5*   
   -   5        $��datePicker2��5*   D   $
��Left=�6   $��
356,70,0,0q�60   $	��Top=�6   $	��120��6�    6W   �� *VATInvoiceDate+6�   5+      5,      