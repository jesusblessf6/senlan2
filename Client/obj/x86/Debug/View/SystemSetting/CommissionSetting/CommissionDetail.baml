   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6C   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      B    <Client.View.SystemSetting.CommissionSetting.CommissionDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6C   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$F  @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *CommissionSetting+ � 	Resources 5       �� 
TargetType �� Property �� Value3   -Client.Converters.CommissionRuleTypeConverter   CommissionRuleTypeConverter  CommissionLineEdit  CommissionLineDelete  CommissionLineActions �� DataType �� Orientation	   ResxName

   Key��%�  '��       '�� �     '��     &	  �    &	 �    &	 �    &	 �    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5   
   61   �� 5    
   65   �� 5!   
   67   �� 5#   
   $ DBEntity:CommissionLine��65   .R�5$      �� $ 
Horizontal=�6   .+�5%      �� $��btCommissionLineEdit��6   8��  ��65     $!	 Client.Properties.Resources��$

 Edit����5&      �� *Id+6;   �� 5'      $��btCommissionLineDelete��6   8�� ��67     $!	 Client.Properties.Resources��$
 Delete����5(      �� *Id+6;   5)      5*      5+       J� CommandBindings 5,      )  #System.Windows.Input.CommandBinding  5-   
   -   5           Command# [ 5-      5.   A     5/   
   -   5        # [ 5/      50   C   .��53      � -   5         �Name$ rootGrid��53       � RowDefinitions 54   
   �� 55      $
��Auto �6   �� 56      $
��443* �6   .+�58   
   �� -   5        $��lbTitle��59   H   $��32��58   .   $
��Left=�6:   $��6,6,0,0q�6U   $
��auto��6f   $	��Top=�59      $
��Bold"�6(   $��16(�6:   ��58      �� *	TitleName+59   H   �� 5:   
   -   5        $��label5��5:   w   
���<��$
��Left=�6J   $��6,38,0,0q�6e   $	��Top=�6�   ��6   �� *CustomerTypeName+6�   �� 5;   
   -   5        $��textBox1��5;   A   $
��Left=�6   $��
122,40,0,0q�6-   $	��Top=�6Q   {�.  ��6i   �� *CustomerName+6�   �� 5<   
   -   5        $��button5��5<   Z   $	��...��6   $��23��6   $
��Left=�6+   $��
246,40,0,0q�6F   $	��Top=�5=      $��25��6)   64   �� 5>   
   -   5        $��label2��5>   �   
���<��$
��Left=�6q   $��
278,38,0,0q�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 InternalCustomer��6�   �� 5?   
   -	   5        $��	comboBox1��5?   B   $
��Left=�6   $��
394,40,0,0q�6.   $	��Top=�6S    �� SelectedValuePath$ Id��5A       �� DisplayMemberPath$ 	ShortName��6*   ��5@      �� *InternalCustomerList+ �� SelectedValue 6@   �� *SelectInternalCustomerID+5A   *   �� 5B   
   -
   5        $��label4��5C   "   $
��Left=�5B   9   $��6,70,0,0q�5C      $	��Top=�60   ��5B        *CommissionSettingDetail+5C   0   �� 5D   
   -   5        $��button1��5D   �   $��23��6Z   $
��Left=�6f   $��
122,72,0,0q�6�   $	��Top=�5E      $��45��6)   ��5D        $!	 Client.Properties.Resources��$
 AddWithSymbol��5E   4   &   System.Windows.Controls.DataGrid  5F   
   -   5        $��	dataGrid1��5F   _      AutoGenerateColumns .  $
��Left=�6/   $��122,104,0,0q�6J      
IsReadOnly . $	��Top=�5G   =   $
��auto��6U   $
��auto��6b   $   HorizontalScrollBarVisibility$
 Auto=�5H      ��5G      ��    Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header 6%     $!	 Client.Properties.Resources��$
 	Commodity��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6i   �� *Commodity.Name+6�     5K       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$

 Rule�� 5L   %   �� *
RuleType+ �� 	Converter# [  6}     5M       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 CommissionRate�� 6�   �� *	RuleValue+$	  DBEntity.EnumEntity.RoundRules 	  STR_RATE �� StringFormat# Z 6�     5N       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 Rule2�� 5O   %   �� *	RuleType2+# [  6~     5P       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 CommissionRate2�� 6�   �� *
RuleValue2+# Z 6�     5Q      $ 界限内规则1��6%    65   �� *InLimitRuleType1+# [  6�     5R      $ 界限内费率1��6%    65   �� *InLimitRuleValue1+# Z 6�     5S      $ 界限内规则2��6%    65   �� *InLimitRuleType2+# [  6�     5T      $ 界限内费率2��6%    65   �� *InLimitRuleValue2+# Z 6�     5U      $ 界限外规则1��6%    65   �� *OutLimitRuleType1+# [  6�     5V      $ 界限外费率1��6%    65   �� *OutLimitRuleValue1+# Z 6�     5W      $ 界限外规则2��6%    65   �� *OutLimitRuleType2+# [  6�     5X      $ 界限外费率2��6%    65   �� *OutLimitRuleValue2+# Z 6�     5Y       6%     $!	 Client.Properties.Resources��$
 Comments�� 6h   �� *	Comment+6�   4
  .System.Windows.Controls.DataGridTemplateColumn
  5Z       
  CellTemplate# [ 6m    6)     $!	 Client.Properties.Resources��$
 	Operation��6�   5\      �� 5]   
   -   5        $��button2��5]   �   $��25��6Q   $
��Left=�6]   $��
210,25,0,0q�6x   $	��Top=�5^      $��60��6)   $��1��6I   ��5]        $!	 Client.Properties.Resources��$

 Save��5^   I   �� 5_   
   -   5        $��button3��5_   �   $��25��6X   $
��Left=�6d   $��
257,25,0,0q�6   $y�	Collapsed=�5`      $	��Top=�6(   $��60��6@   $��1��6K   ��5_        $!	 Client.Properties.Resources��$
 SaveAsDraft��5`   K   �� 5a   
   -   5        $��button4��5a   �   $��25��6S   $
��Left=�6_   $��
305,25,0,0q�6z   $	��Top=�5b      $��60��6)   $��1��6I   ��5a        $!	 Client.Properties.Resources��$
 Cancel��5b   I   5c      5d      