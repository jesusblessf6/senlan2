   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5
   &   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      L   FClient.View.SystemSetting.FinancialAccountSetting.FinancialAccountHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5
   &   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$R  LClient.View.SystemSetting.FinancialAccountSetting.ResFinancialAccountSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5
        *FinancialAccountList+ � 	Resources 5         EditFinancialAccountCommand ! DeleteFinancialAccountCommand��%:   &	        &	      �� 5   
   6>   �� 5   
   6@   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6�     5   
   -   5        # [ 5      6�   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� -   5        $��label1��5   r   $��32��6:   $
��Left=�6F   $��6,6,0,0q�6a   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     *FinancialAccountList+6�   �� 5      -   5        $��button1��5   �   $��23��6^   $
��Left=�6j   $��6,12,0,0q�6�   $	��Top=�6�   $��60��6�   $��1��6�   ��6        ResxName$! Client.Properties.Resources��
   Key$ AddWithSymbol��6�   R� 5       -   5        $��tvFinancialAccount��5    F   $
��Left=�6   $��
20,40,0,50q�62   $
��Auto��6`   $	��150��6m   $��50��6|   $��0��6�   	 R� SelectedValuePath$	 Id��5!   /   ��6   �� ��5"      �� 5#      
 �� 
TargetType"
 Q�6   .�5$      ��  �� Property �@Q�
IsExpanded �� Value . 67   �� 5%       �@Q�
IsSelected 67   �� *
IsSelected+ �� Mode$ TwoWay=��� 5&       � ��$ 14(�65    �� Triggers 5'      P� 5(       P� Property �@Q�
IsSelected P� Value . . �5)   "   ��  � ��$
 Bold"�6?   5*      5,      ��5.      �� 5/       �� DataType$ DBEntity:FinancialAccount��6P    �� ItemsSource 6/   �� *
Children+.R�50      �� ��6$   �� *Name+51      53      � 54      -   5        $��grid1��54   '   $��
6,40,20,50q�6   $��1��64    55      �� 56      $	��300��6'   .+�58      �� -   5        $��
rectangle1��58      
���   �$��2��6=   �� 59      $��6,6,0,0q�6    �� Orientation$ 
Horizontal=�6.   $
��Auto��6G   $	��Top=�6U   $
��Left=�6m   $
��Auto��6�   .+�5:      �� -	   5        $$��lbSelectedFinancialAccountName��5:   �   $��28��6M   $
��Left=�6Y   $��10,6,0,0q�6t   $	��Top=�6�   $��0��6�   ��6   �� *SelectedFinancialAccountName+6�   �� 5;      -
   5        $��button2��5;   �   $��23��6]   $
��Left=�6i   $��10,6,0,0q�6�   $	��Top=�6�   $��45��6�   ��6     $! Client.Properties.Resources��$
 Edit��6�   �� 5<      -   5        $��button3��5<   �   $��23��6_   $
��Left=�6k   $��10,6,0,0q�6�   $	��Top=�6�   $��45��6�   ��6     $! Client.Properties.Resources��$ Delete��6�   5=      &   System.Windows.Controls.DataGrid  5>      -   5        $��dgFinancialAccountDetails��5>   s      AutoGenerateColumns .  $
��Auto��67   $
��Left=�6E   $��	16,77,0,0q�6`   $	��Top=�5?      $
��Auto��63      
IsReadOnly .    SelectionUnit$
 Cell=�6j      SelectionMode$ Extended=�5@      ��5?   @   ��    Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�      CanUserSort .    Header 6-     $R LClient.View.SystemSetting.FinancialAccountSetting.ResFinancialAccountSetting��$ 
SubAccount��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *Name+6�     5C      $
 Auto 6p    .  6-     $! Client.Properties.Resources��$ Comments�� 6�   �� *Description+6�   4	  .System.Windows.Controls.DataGridTemplateColumn	  5D      $
 Auto 6u    .   61     $! Client.Properties.Resources��$ 	Operation�� 	  CellTemplate 5E      �� 5F   "   $ DBEntity:FinancialAccount��6/   .R�5G   &   �� $ 
Horizontal=�61   .+�5H   *   �� $��20��6q   $��11(�6}   $��30��6�   #��[  6�   ��61     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6�   �� 5I   *   $��20��6s   $��11(�6   $��30��6�   #��[ 6�   ��61     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6�   5J   '   5K   #   5M      5O      $
   Utility.Controls.PagingControl
  5P      -   5        $��pagingControl1��5P   Q   $
��Left=�6#   $��	16,40,0,0q�6>   $	��Top=�6g   5Q      5S      5T      5U      