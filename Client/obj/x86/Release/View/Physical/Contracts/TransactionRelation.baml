   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 
 Client8   2Client.View.Physical.Contracts.TransactionRelation   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     >my/clr-namespace:Utility.Controls;assembly=Utility     -     � Title$  关联交易明细��$	��199��$	��550�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       '�� S     '�� �     �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120��.��� -   $��rootGrid�� � RowDefinitions �� $	��96* ��� $	��64* �.+��� -   $��label1��$��6,39,0,0q�$��28��$	��110��$��Right=�$
��Left=�$	��Top=�
���<����0  *Infralution.Localization.Wpf.ResxExtension  	   ResxName$!	 Client.Properties.Resources��

   Key$
 InternalCustomer���� -   $��	comboBox1��$��23��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 	ShortName������ *InnerCustomers+ �� SelectedValue �� *SelectedInternalCustomerId+{��� *IsRelBPEnable+�� -   $��label2��$��28��$
��Left=�$��
240,39,0,0q�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 Price��&   Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��
356,40,0,0q�$	��Top=�$	��120��   Text �� *Price+$   DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z {��� *IsPriceEnable+�� -   $��button1��$��23��$
��Left=�$��
210,25,0,0q�$	��Top=�$��60��$��1����  $!	 Client.Properties.Resources��$

 Save���� -   $��button2��$��23��$
��Left=�$��
305,25,0,0q�$	��Top=�$��60��$��1����  $!	 Client.Properties.Resources��$
 Cancel���� -	   $��lbTitle��$��关联交易明细��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(��� -
   $��label3��$��签署日期��
���<��$��28��$
��Left=�$��Right=�$��6,71,0,0q�$	��Top=�$	��110��$��2��(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$
��Left=�$��
122,72,0,0q�$	��Top=�$	��120��   SelectedDate �� *
SignDate+{��� *IsDateEnable+�� -   $��label4��$��收票日期��$��2��$��28��$
��Left=�$��
241,70,0,0q�$	��Top=�$	��110��  -   $��datePicker2��$
��Left=�$��
356,70,0,0q�$	��Top=�$	��120�� �� *VATInvoiceDate+