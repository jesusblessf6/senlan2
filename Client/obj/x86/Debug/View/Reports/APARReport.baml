   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Client.View.ReportsClient.View.Reports  5	   (   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      $    Client.View.Reports.APARReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5Reports!clr-namespace:Client.View.Reports     5	   (   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5	        *ReceivableAndPayable+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value 
 style1 �� 
TargetType 9�Name	 9� 
IsExpanded 
 style2 
 style33   -Client.View.Reports.ListViewItemStyleSelector  ListViewStyleSelector
   
FirstStyle   SecondStyle   
ThirdStyle��%  &	        '�� �     '�� m    &	 �    &	 �    &	     &	     7  7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5    
   " ��6   .�5!      ��  � �� 5"      �� 5#      " ��6&   .R�5$      9� $	 exp��6#   	 .  ��5%      � 5&   "   .+�5'   &   �� $��5,10,0,0q�6F   ��60   �� *Name+6Z   5(   #   .��5*      �� 5+      5,      5.      50      �� 52   
   " ��6   .�53      ��  � �� 54      �� 55      " ��6&   .R�56      9� 	 .  ��57      � 58   "   .+�59   &   �� $��20,0,0,0q�6F   ��60   �� *Name+6Z   5:   #   .��5<      �� 5=      5>      5@      5B      �� 5D   
   " ��6   .�5E      ��  � �� 5F      �� 5G      " ��6&   .R�5H      9� 	 .  ��5I      � 5J   "   .+�5K   &   �� $��40,0,0,0q�6F   ��60   �� *Name+6Z   5L   #   .��5N      �� 5O      5P      5R      5T        5V   
   8
   8  8  6�   5W      .��5Y      �� $
��Auto=�6   $
��Auto=�68   .��5Z   
   � -   5         �Name$ rootGrid��5Z      .+�5[      �� -   5        $��lbTitle��5[   :   $
��Left=�6I   $��6,6,0,0q�6d   $��32��6u   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     *ReceivableAndPayable+6�   �� 5\      -   5        $��	groupBox1��5\   �   $	��100��6\   $
��Left=�6i   $��6,40,0,0q�6�   $	��Top=�6�   $	��900��6�   ��6        ResxName$! Client.Properties.Resources��
   Key$ 
Conditions��.��5]      � .+�5^      �� -   5        $��label2��5^   �   #��[  6`   $
��Left=�6�   $��1,42,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Customer��6�   �� 5_      -   5        $��textBox1��5_   M   $
��Left=�6   $��
107,44,0,0q�69   $	��Top=�6]   {�.  ��6�   �� *BpName+�� 5`      -   5        $��button1��5`   f   $	��...��6   $��23��6+   $
��Left=�67   $��
231,44,0,0q�6R   $	��Top=�6u   $��25��6�   6�   �� 5a      -   5        $��label3��5a   �   #��[  6h   $
��Left=�6�   $��1,10,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ InternalCustomer��6�   �� 5b      -   5        $��	comboBox1��5b   N   $
��Left=�6   $��
107,12,0,0q�6:   $	��Top=�6_    �� DisplayMemberPath$ 	ShortName��6�    �� SelectedValuePath$ Id��6�   ��6w   �� *InnerCustomers+ �� SelectedValue 6�   �� *InnerCustomerId+�� 5c      -	   5        $��label4��5c   �   #��[  6a   $
��Left=�6�   $��
486,10,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ 	Commodity��6�   �� 5d      -
   5        $��	comboBox2��5d   N   $
��Left=�6   $��
593,12,0,0q�6:   $	��Top=�6_   $
 Name��6�   $ Id��6�   ��6w   �� *Metals+ 6�   �� *	MetalId+�� 5e      -   5        $��button2��5e   �   $��23��6^   $
��Left=�6j   $��
730,12,0,0q�6�   $	��Top=�6�   $��60��6�    �� 	IsDefault . ��6     $! Client.Properties.Resources��$ Query��6�   �� 5f      -   5        $��label5��5f   �   $
��Left=�6a   $��
244,10,0,0q�6|   #��[  6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ 	StartDate��6�   (  "System.Windows.Controls.DatePicker  5g      -   5        $��datePicker1��5g   P   $
��Left=�6!   $��
350,12,0,0q�6<   $	��Top=�6�   $	��120��6�      SelectedDate 6c   �� *	StartDate+6�   �� 5h      -   5        $��label6��5h   �   $��Right=�6_   $
��Left=�6�   $��
282,42,0,0q�6�   $	��Top=�6�   $��60��6�   ��6     $! Client.Properties.Resources��$ EndDate��6�     5i      -   5        $��datePicker2��5i   P   $
��Left=�6!   $��
350,44,0,0q�6<   $	��Top=�6�   $	��120��6�    6c   �� *	EndDate+6�   �� 5j      -   5        $��button3��5j   j   $��导出Excel��6   $��23��6/   $
��Left=�6;   $��
734,43,0,0q�6V   $	��Top=�6y   $��60��6�   6�   �� 5k      -   5        $��label1��5k   Y   $��	批次号��6   $
��Left=�6*   $��
486,42,0,0q�6E   #��[  6g   $	��Top=�6�   �� 5l      -   5        $��textBox2��5l   M   $
��Left=�6   $��
593,44,0,0q�69   $	��Top=�6v   ��6]   �� *	QuotaNo+6v   �� 5m      -   5        $��打印��5m      $
��Left=�6*   $	��Top=�6E   $��45��6]   $��
800,44,0,0q�6h   6|   5n      5o      �� 5p      -   5        $��
separator1��5p   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   &   System.Windows.Controls.DataGrid  5q      -   5        $��dataGridAPAR��5q   ~      AutoGenerateColumns .  $	��500��63   $	��800��6@   $
��Left=�6P   $��	6,166,0,0q�6k   $	��Top=�6�   $
��Auto��6�      CanUserAddRows .     
IsReadOnly .    CanUserSortColumns .  ��6�   ��    Columns 5r      4  .System.Windows.Controls.DataGridTemplateColumn  5s      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6-      
IsReadOnly .    Header 5t      �� 5u      -   5        $��cbSelectAll��5u   '   $��全选��6\   $��Center=�6i   $��Center=�6�    d� 	IsChecked 6:   �� *IsSelectAll+6�      CellTemplate 5w      �� 5x      .R�5y   "   �� $��IsSelect��6�   $��Center=�6�   $��Center=�6�    6+   �� *IsPrintSelected+ �� UpdateSourceTrigger$ PropertyChanged=�y�6v   �� *	IsVisible+6�   5z      5|      0	  *System.Windows.Controls.DataGridTextColumn	  5}       6)     $! Client.Properties.Resources��$ QuotaNo��1
  +System.Windows.Controls.DataGridBoundColumn  
  Binding  6k   �� *
QuotaNoStr+	  5~       6)     $! Client.Properties.Resources��$ 	Commodity��  6m   �� *CommodityName+	  5       6)     $! Client.Properties.Resources��$ Brand��  6i   �� *	BrandName+	  5�       6)     $! Client.Properties.Resources��$
 Date��  6h   �� *Date+! �� StringFormat$! 
yyyy-MM-dd��	  5�       6)     $! Client.Properties.Resources��$ ActualQuantity��  6r   �� *VerQty+$  DBEntity.EnumEntity.RoundRules"   STR_QUANTITY#! Z" 	  5�       6)     $! Client.Properties.Resources��$ Price��  6i   �� *NPrice+#   	STR_PRICE#! Z# 	  5�       6)     $! Client.Properties.Resources��$ PricingCurrency��  6s   �� *PricingCurrency+	  5�      $ 增票数量��6)     67   �� *VatInvoiceQty+#! Z" 	  5�      $ 增票金额��6)     67   �� *VatInvoiceAmount+$   
STR_AMOUNT#! Z$ 	  5�       6)     $! Client.Properties.Resources��$ 
Receivable��  6n   �� *	BReceived+#! Z$ 	  5�       6)     $! Client.Properties.Resources��$ Payable��  6k   �� *BPaid+#! Z$ 	  5�       6)     $# Client.View.Reports.ResReport��$ Received��  6n   �� *	SReceived+#! Z$ 	  5�       6)     $# Client.View.Reports.ResReport��$
 Paid��  6j   �� *SPaid+#! Z$ 	  5�       6)     $# Client.View.Reports.ResReport��$ AmountRemain��  6r   �� *AmountRemain+#! Z$ 	  5�       6)     $! Client.Properties.Resources��$ SettleCurrency��  6r   �� *SettleCurrency+5�      5�      5�      5�      