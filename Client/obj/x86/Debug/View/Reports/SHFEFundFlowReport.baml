   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5   D   B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      ,    &Client.View.Reports.SHFEFundFlowReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     6D   >my/clr-namespace:Utility.Controls;assembly=Utility     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5        N� Title$  SHFE出入金明细��5       � 	Resources 5	       �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker��%  &	        '�� �     '  m    �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5      " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   "  6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5      .+�5       �� -   5        $��lbTitle��5    }   $��SHFE出入金明细��6   $��6,6,0,0q�6(   $��32��69   $	��Top=�6E   $
��Bold"�6]   $��16(�6o   $
��Left=�6�   �� 5!      -   5        $��	groupBox1��5!   �   $	��100��6\   $
��Left=�6i   $��6,40,0,0q�6�   $	��Top=�6�   $	��600��6�   ��6   0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ 
Conditions��.��5"      � .+�5#      �� -   5        $��button2��5#   �   $��23��6^   $
��Left=�6j   $��
505,44,0,0q�6�   $	��Top=�6�   $��75��6�   ��6     $! Client.Properties.Resources��$ Query��6�   �� 5$      -   5        $��label5��5$   �   $
��Left=�6a   $��1,42,0,0q�6|   #��[  6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ 	StartDate��6�     5%      -   5        $��datePicker1��5%   P   $
��Left=�6!   $��
107,44,0,0q�6<   $	��Top=�6�      SelectedDate 6c   �� *	StartDate+6�   �� 5&      -   5        $��label6��5&   �   $
��Left=�6_   $��
260,42,0,0q�6z   #��[  6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ EndDate��6�     5'      -   5        $��datePicker2��5'   P   $
��Left=�6!   $��
366,44,0,0q�6<   $	��Top=�6�    6c   �� *	EndDate+6�   �� 5(      -	   5        $��label2��5(   �   $
��Left=�6^   $��1,10,0,0q�6y   #��[  6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Broker��6�   �� 5)      -
   5        $��	comboBox2��5)   �   	 �� DisplayMemberPath$	 	ShortName��6   $
��Left=�6=   $��
107,12,0,0q�6x   
 �� SelectedValuePath$
 Id��6�   $	��Top=�6�   ��6X   �� *	Brokers+ �� SelectedValue 6�   �� *SelectedBrokerId+6�   �� 5*      -   5        $��label3��5*   �   $
��Left=�6h   $��
260,10,0,0q�6�   #��[  6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ InternalCustomer��6�   �� 5+      -   5        $��	comboBox1��5+   �   $	 	ShortName��6   $
��Left=�6=   $��
366,12,0,0q�6~   $
 Id��6�   $	��Top=�6�   $	��120��6  ��6X   �� *InnerCustomer+ 6�   �� *SelectedInnerCustomer+6  5,      5-      �� 5.      -   5        $��
separator1��5.   7   $��17��6   $��	6,146,6,0q�6$   $	��Top=�6I   $  Utility.Controls.PagingControl  5/      -   5        $��pagingControl1��5/   Y   $
��Left=�6   $��	6,163,0,0q�6:   $��31��6M   $	��Top=�6o   &   System.Windows.Controls.DataGrid  50      -   5        $��dataGridSHFEFundFlow��50   o      AutoGenerateColumns .  $
��Auto��63   $
��Left=�6A   $��	6,200,0,0q�6\   $	��Top=�6�   $
��Auto��6�      CanUserAddRows .     
IsReadOnly .    Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ 发生日期��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	TradeDate+ �� StringFormat$ 
yyyy-MM-dd��  53      $ 入金��6)    65   �� *
AmountIn+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT# Z   54      $ 出金��6)    65   �� *	AmountOut+# Z   55      $ 方式��6)    65   �� *Type+  56      $ 摘要��6)    65   �� *
Abstract+  57       6)     $! Client.Properties.Resources��$ Broker�� 6j   �� *-+SHFECapitalDetail.BusinessPartner.ShortName+  58       6)     $! Client.Properties.Resources��$ InternalCustomer�� 6t   �� *.,SHFECapitalDetail.BusinessPartner1.ShortName+5:      5;      5<      5=      