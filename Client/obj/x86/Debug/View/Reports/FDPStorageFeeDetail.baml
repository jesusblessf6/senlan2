   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      -    'Client.View.Reports.FDPStorageFeeDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$#  Client.View.Reports.ResReport��5       N� Title$ FDPStorageFeeDetail��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension  .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5      .+�5      �� -   5        $��lbTitle��5   �   $��外贸仓单仓租明细��6   $
��Left=�6'   $��6,6,0,0q�6B   $��32��6S   $	��Top=�6_   $
��Bold"�6w   $��16(�6�   6�   �� 5      -   5        $��	groupBox3��5   `   $��查询条件��6   $	��100��6%   $
��Left=�62   $��6,40,0,0q�6M   $	��Top=�6q   $	��800��6�   .��5      � -   5        $��grid3��5      .+�5      �� -   5        $��label2��5   d   $��	仓单号��6   $��28��6*   $
��Left=�66   $��	55,10,0,0q�6Q   $	��Top=�6r   �� 5      -   5        $��textBox1��5   Y   $��23��6   $
��Left=�6*   $��
107,10,0,0q�6E   $	��Top=�6i   $	��120��6�   ��6�   �� *
DeliveryNo+�� 5      -   5        $��label3��5   d   $��仓库��6   $��28��6)   $
��Left=�65   $��
326,10,0,0q�6P   $	��Top=�6r   �� 5      -   5        $��textBox2��5   Y   $��23��6   $
��Left=�6*   $��
366,10,0,0q�6E   $	��Top=�6i   $	��120��6�   {�.  ��6�   �� *WarehouseName+6�   �� 5      -	   5        $��button1��5   f   $	��...��6   $��23��6+   $
��Left=�67   $��
491,10,0,0q�6R   $	��Top=�6u   $��30��6�   6�   �� 5      -
   5        $��label4��5   e   $��起始日期��6   $��28��6+   $
��Left=�67   $��	43,42,0,0q�6R   $	��Top=�6s   (  "System.Windows.Controls.DatePicker  5      -   5        $��datePicker1��5   \   $��23��6!   $
��Left=�6-   $��
107,42,0,0q�6H   $	��Top=�6o   $	��120��6�      SelectedDate 6�   �� *	StartDate+�� 5      -   5        $��label5��5   f   $��截止日期��6   $��28��6+   $
��Left=�67   $��
302,42,0,0q�6R   $	��Top=�6t     5      -   5        $��datePicker2��5   \   $��23��6!   $
��Left=�6-   $��
366,42,0,0q�6H   $	��Top=�6o   $	��120��6�    6�   �� *	EndDate+�� 5      -   5        $��button2��5   e   $��查询��6   $��23��6*   $
��Left=�66   $��
491,42,0,0q�6Q   $	��Top=�6t   $��60��6�   6�   5      5      �� 5      -   5        $��
separator1��5   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   &   System.Windows.Controls.DataGrid  5      -   5        $��	dataGrid1��5   �      AutoGenerateColumns .  $
��auto��63   $
��Left=�6Y   $��	6,166,0,0q�6t   $	��Top=�6�   $
��auto��6�      
IsReadOnly . ��6A   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ 	仓单号��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *
DeliveryNo+6W     5!      $ 净重��6)   	 65   �� *	NetWeight+6U     5"      $ 毛重��6)   	 65   �� *GrossWeight+6W     5#      $ 捆数��6)   	 65   �� *Bundle+6R     5$      $ 仓库��6)   	 65   �� *WarehouseName+6Y     5%      $ 起始日期��6)   	 67   �� *	StartDate+
 �� StringFormat$
 {0:yyyy-MM-dd}��6v     5&      $ 截止日期��6)   	 67   �� *	EndDate+$
 {0:yyyy-MM-dd}��6t     5'      $ 仓租��6)   	 65   �� *
StorageFee+6V     5(      $ 货权转移费��6)   	 68   �� *TransferFee+6Z     5)      $ 	仓单费��6)   	 66   �� *
WarrantFee+6W     5*      $ 总计��6)   	 65   �� *
TotalFee+6T     5+      $ 币种��6)   	 65   �� *CurrencyName+6X     5,      $ 备注��6)   	 65   �� *	Comment+6S   5.      50      51      52      