   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	      G    AClient.View.Physical.ForeignDeliveryPools.ForeignDeliveryPoolHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5base$clr-namespace:Client.Base.BaseClient     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	        N� Title$  外贸提单池首页��6   .��5
      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   ^   $��外贸提单池首页��6   $��32��6&   $
��Left=�62   $��6,6,0,0q�6M   $	��Top=�5      $
��Bold"�6,   $��16(�6>   �� 5      -   5        $��	groupBox1��5   �   $	��180��6U   $
��Left=�6b   $��	40,40,0,0q�6}   $	��Top=�5      $	��250��6/   ��5      0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��5      � .+�5      �� -   5        $��label1��5   h   $��进口/转口提单��6   $��28��6.   $
��Left=�6:   $��	32,43,0,0q�6U   $	��Top=�6v   �� 5      -   5        $��button1��5   d   $��+��6   $��23��6)   $
��Left=�65   $��
130,44,0,0q�6P   $	��Top=�6s   $��75��6�   6�   �� 5      -   5        $��label2��5   h   $��进口/转口仓单��6   $��28��6.   $
��Left=�6:   $��	32,83,0,0q�6U   $	��Top=�6v   �� 5      -   5        $��button2��5   d   $��+��6   $��23��6)   $
��Left=�65   $��
130,84,0,0q�6P   $	��Top=�6s   $��75��6�   6�   5      5      �� 5      -   5        $��	groupBox3��5   �   $	��300��6W   $
��Left=�6d   $��
40,225,0,0q�6   $	��Top=�5      $	��540��6/   ��5        $! Client.Properties.Resources��$ Query��.��5      � .+�5      �� -	   5        $��label6��5      $
��Bold"�5   e   $��28��6w   $
��Left=�6�   $��6,6,0,0q�6�   $	��Top=�5   *   ��5        $! Client.Properties.Resources��$ QueryShortcut��5   *   �� 5      -
   5        $��btnLasttMonthList��5   K   $��本月外贸提/仓单��5   A   $��23��6T   $
��Left=�5      $��	30,40,0,0q�68      
LinkButton#��[  6d   $	��Top=�5      $
��auto��65   �� 5      -   5        $��label7��5       $
��Bold"�5   e   $��28��6w   $
��Left=�6�   $��6,70,0,0q�6�   $	��Top=�5    *   ��5        $! Client.Properties.Resources��$ AdvancedQuery��5    *   �� 5!      -   5        $��label3��5!   d   $��金属��6   $��28��6)   $
��Left=�65   $��
42,103,0,0q�6P   $	��Top=�6r   �� 5"      -   5        $��	comboBox1��5"   Z   $��23��6   $
��Left=�6+   $��
82,104,0,0q�6F   $	��Top=�6k   $	��120��6�    �� DisplayMemberPath$
 Name��5#   C    �� SelectedValuePath$ Id��6\   ��6   �� *Commodities+ �� SelectedValue 6s   �� *SelectedCommodityId+�� 5$      -   5        $��label4��5$   g   $��单据类型��6   $��28��6+   $
��Left=�67   $��279,104,0,0q�6R   $	��Top=�6u   �� 5%      -   5        $��	comboBox2��5%   [   $��23��6   $
��Left=�6+   $��343,104,0,0q�6F   $	��Top=�6l   $	��120��6�   $
 Name��5&   E   $ Id��6^   ��6   �� *DeliveryTypes+ 6u   �� *SelectedDeliveryTypeId+�� 5'      -   5        $��label5��5'   f   $��起始日期��6   $��28��6+   $
��Left=�67   $��
18,135,0,0q�6R   $	��Top=�6t   (  "System.Windows.Controls.DatePicker  5(      -   5        $��datePicker1��5(   \   $��25��6!   $
��Left=�6-   $��
82,136,0,0q�6H   $	��Top=�6o   $	��120��6�      SelectedDate 5)   !   �� *	StartDate+�� 5*      -   5        $��label8��5*   g   $��结束日期��6   $��28��6+   $
��Left=�67   $��279,135,0,0q�6R   $	��Top=�6u     5+      -   5        $��datePicker2��5+   ]   $��25��6!   $
��Left=�6-   $��343,136,0,0q�6H   $	��Top=�6p   $	��120��6�    5,   !   �� *	EndDate+�� 5-      -   5        $��label9��5-   e   $��	提单号��6   $��28��6*   $
��Left=�66   $��
30,166,0,0q�6Q   $	��Top=�6s   �� 5.      -   5        $��textBox1��5.   Y   $��23��6   $
��Left=�6*   $��
82,168,0,0q�6E   $	��Top=�6i   $	��120��6�   ��5/      �� *
DeliveryNo+�� 50      -   5        $��	checkBox1��50   o   $!��仅显示当前用户文档��6   $��16��63   $
��Left=�6?   $��343,200,0,0q�6Z   $	��Top=�6�   $	��142��6�    d� 	IsChecked 51      �� *OnlyCurrentUser+�� 52      -   5        $��button3��52   t   $��查询��6   $��23��6*   $
��Left=�6D   $��206,238,0,0q�6_   $	��Top=�6�   $��75��6�   �� 53      -   5        $��button4��53   Y   $��重置��6   $��23��6*   $��292,238,0,0q�6D   $	��Top=�6h   $
��Left=�6�   $��75��6�   �� 54      -   5        $��label10��54   e   $��净重��6   $��28��6)   $
��Left=�65   $��300,166,0,0q�6P   $	��Top=�6t   &   Utility.Controls.CurrencyTextBox  55      -   5        $��textBox2��55   e   $��23��6)   $
��Left=�65   $��343,168,0,0q�6P   $	��Top=�6�   $	��120��6�      Text 6u   �� *	NetWeight+6�   �� 56      -   5        $��label11��56   e   $��	标识号��6   $��28��6*   $
��Left=�66   $��
36,197,0,0q�6Q   $	��Top=�6t   �� 57      -   5        $��textBox3��57   Y   $��23��6   $
��Left=�6*   $��
85,200,0,0q�6E   $	��Top=�6i   $	��120��6�   ��6�   �� *MarkNo+58      59      5:      5;      5<      