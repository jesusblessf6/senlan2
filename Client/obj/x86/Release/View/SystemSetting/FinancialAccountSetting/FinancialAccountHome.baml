   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient L   FClient.View.SystemSetting.FinancialAccountSetting.FinancialAccountHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$R  LClient.View.SystemSetting.FinancialAccountSetting.ResFinancialAccountSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *FinancialAccountList+ � 	Resources    EditFinancialAccountCommand ! DeleteFinancialAccountCommand��%   &	        &	      �� ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -   $��label1��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  *FinancialAccountList+�� -   $��button1��$��23��$
��Left=�$��6,12,0,0q�$	��Top=�$��60��$��1����     ResxName$! Client.Properties.Resources��
   Key$ AddWithSymbol��R� -   $��tvFinancialAccount��$
��Left=�$��
20,40,0,50q�$
��Auto��$	��150��$��50��$��0��	 R� SelectedValuePath$	 Id������ ���� 
 �� 
TargetType"
 Q�.���  �� Property �@Q�
IsExpanded �� Value . ��  �@Q�
IsSelected �� *
IsSelected+ �� Mode$ TwoWay=���  � ��$ 14(� �� Triggers P�  P� Property �@Q�
IsSelected P� Value . . ���  � ��$
 Bold"�����  �� DataType$ DBEntity:FinancialAccount�� �� ItemsSource �� *
Children+.R��� ���� *Name+� -   $��grid1��$��
6,40,20,50q�$��1�� �� $	��300��.+��� -   $��
rectangle1��
���   �$��2���� $��6,6,0,0q� �� Orientation$ 
Horizontal=�$
��Auto��$	��Top=�$
��Left=�$
��Auto��.+��� -	   $$��lbSelectedFinancialAccountName��$��28��$
��Left=�$��10,6,0,0q�$	��Top=�$��0������ *SelectedFinancialAccountName+�� -
   $��button2��$��23��$
��Left=�$��10,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$
 Edit���� -   $��button3��$��23��$
��Left=�$��10,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ Delete��&   System.Windows.Controls.DataGrid  -   $��dgFinancialAccountDetails��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	16,77,0,0q�$	��Top=�$
��Auto��   
IsReadOnly .    SelectionUnit$
 Cell=�   SelectionMode$ Extended=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    Header   $R LClient.View.SystemSetting.FinancialAccountSetting.ResFinancialAccountSetting��$ 
SubAccount��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+4	  .System.Windows.Controls.DataGridTemplateColumn	  $
 Auto  .     $! Client.Properties.Resources��$ 	Operation�� 	  CellTemplate �� $ DBEntity:FinancialAccount��.R��� $ 
Horizontal=�.+��� $��20��$��11(�$��30��#��[  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��20��$��11(�$��30��#��[ ��  $! Client.Properties.Resources��$ Delete������ *Id+$
   Utility.Controls.PagingControl
  -   $��pagingControl1��$
��Left=�$��	16,40,0,0q�$	��Top=�