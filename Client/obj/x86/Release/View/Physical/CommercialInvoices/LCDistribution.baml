   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 
 Client<   6Client.View.Physical.CommercialInvoices.LCDistribution   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     >my/clr-namespace:Utility.Controls;assembly=Utility     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  交单金额分配��$	��580��$	��260�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Height=� � Topmost . .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��交单金额分配��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$��16(�$	��142��$
��Bold"�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��auto��$
��Left=�$��	28,44,0,0q�$	��Top=�$
��auto��   CanUserAddRows .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 信用证号��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *LCNo+  $ 交单金额��	 �� *PresentAmount+$   DBEntity.EnumEntity.RoundRules
   
STR_AMOUNT �� StringFormat# Z
   $ 已分配金额��	 �� *DistriButionAmount+# Z
   $ 币种��	 �� *Currency.Name+�� -   $��label2��$��本次分配金额��$��28��$
��Left=�$��295,118,0,0q�$	��Top=�&   Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��383,119,0,0q�$	��Top=�$	��120��   Text �� *Amount+# Z
 �� -   $��button1��$��确定��$��23��$
��Left=�$��210,173,0,0q�$	��Top=�$��60���� -   $��button2��$��取消��$��23��$
��Left=�$��305,173,0,0q�$	��Top=�$��60���� -	   $��label3��$��可分配金额��$��28��$
��Left=�$��
28,118,0,0q�$	��Top=�  -
   $��currencyTextBox2��$��23��$
��Left=�$��104,119,0,0q�$	��Top=�$	��120�� �� 
IsReadOnly . {�.   �� *AllowAmount+# Z
 