   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5   	   B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   5   
 Client<   6Client.View.Physical.CommercialInvoices.LCDistribution   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5   	   >my/clr-namespace:Utility.Controls;assembly=Utility     5   5   @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  交单金额分配��5   	   $	��580��6   $	��260��6$    � WindowStartupLocation$ CenterScreen=�5   K    � SizeToContent$ Height=�5   e    � Topmost . .��5	      �� $
��Auto=�6   $
��Auto=�68   .��5
   
   � -   5        $��rootGrid��5
      .+�5      �� -   5        $��lbTitle��5   ]   $��交单金额分配��6   $��32��6%   $
��Left=�61   $��6,6,0,0q�6L   $	��Top=�6l   $��16(�6�   $	��142��6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5      -   5        $��	dataGrid1��5   o      AutoGenerateColumns .  $
��auto��63   $
��Left=�6A   $��	28,44,0,0q�6\   $	��Top=�6�   $
��auto��6�      CanUserAddRows .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 信用证号��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *LCNo+  5      $ 交单金额��6)   	 67   �� *PresentAmount+$   DBEntity.EnumEntity.RoundRules
   
STR_AMOUNT �� StringFormat# Z
   5      $ 已分配金额��6)   	 68   �� *DistriButionAmount+# Z
   5      $ 币种��6)   	 65   �� *Currency.Name+5      �� 5      -   5        $��label2��5   a   $��本次分配金额��6   $��28��6%   $
��Left=�61   $��295,118,0,0q�6L   $	��Top=�6o   &   Utility.Controls.CurrencyTextBox  5      -   5        $��currencyTextBox1��5   ]   $��23��6!   $
��Left=�6-   $��383,119,0,0q�6H   $	��Top=�6u   $	��120��6�      Text 6�   �� *Amount+# Z
 �� 5      -   5        $��button1��5   ^   $��确定��6   $��23��6"   $
��Left=�6.   $��210,173,0,0q�6I   $	��Top=�6m   $��60��6�   6�   �� 5      -   5        $��button2��5   ^   $��取消��6   $��23��6"   $
��Left=�6.   $��305,173,0,0q�6I   $	��Top=�6m   $��60��6�   6�   �� 5      -	   5        $��label3��5   _   $��可分配金额��6   $��28��6$   $
��Left=�60   $��
28,118,0,0q�6K   $	��Top=�6m     5      -
   5        $��currencyTextBox2��5   ]   $��23��6!   $
��Left=�6-   $��104,119,0,0q�6H   $	��Top=�6u   $	��120��6�    �� 
IsReadOnly . {�.   6�   �� *AllowAmount+# Z
 6�   5      5      5      