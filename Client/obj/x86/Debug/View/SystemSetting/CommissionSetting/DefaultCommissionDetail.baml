   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      I    CClient.View.SystemSetting.CommissionSetting.DefaultCommissionDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$F  @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *DefaultRule+ � 	Resources 5       �� 
TargetType �� Property �� Value3   -Client.Converters.CommissionRuleTypeConverter   CommissionRuleTypeConverter  CommissionLineEdit  CommissionLineDelete  CommissionLineActions �� DataType �� Orientation	   ResxName

   Key��%   '��       '�� �     &	      &	 -    &	 @    &	 S    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5        5   
   61   �� 5   
   65   �� 5   
   67   �� 5   
   $ DBEntity:CommissionLine��65   .R�5       �� $ 
Horizontal=�6   .+�5!      �� $��btCommissionLineEdit��6   8��  ��65     $!	 Client.Properties.Resources��$

 Edit����5"      �� *Id+6;   �� 5#      $��btCommissionLineDelete��6   8�� ��67     $!	 Client.Properties.Resources��$
 Delete����5$      �� *Id+6;   5%      5&      5'       J� CommandBindings 5(      )  #System.Windows.Input.CommandBinding  5)   
   -   5           Command# [ 5)      5*   A     5+   
   -   5        # [ 5+      5,   C   .��5/      � -   5         �Name$ rootGrid��5/       � RowDefinitions 50   
   �� 51      $
��Auto �6   �� 52      $
��443* �6   .+�54   
   �� -   5        $��lbTitle��55   H   $��32��54   .   $
��Left=�6:   $��6,6,0,0q�6U   $
��auto��6f   $	��Top=�55      $
��Bold"�6(   $��16(�6:   ��54      �� *	TitleName+55   H   �� 56   
   -   5        $��label2��56   �   
���<��$
��Left=�6r   $��6,38,0,0q�6�   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 InternalCustomer��6�   �� 57   
   -   5        $��	comboBox1��57   N   $��23��6   $
��Left=�6   $��
122,40,0,0q�6:   $	��Top=�6_   $	��120��58       �� SelectedValuePath$ Id��59       �� DisplayMemberPath$ 	ShortName��6*   ��58      �� *InternalCustomerList+ �� SelectedValue 6L   �� *SelectInternalCustomerID+59   *   �� 5:   
   -   5        $��label4��5;   "   $
��Left=�5:   9   $��6,70,0,0q�5;      $	��Top=�60   ��5:        *CommissionSettingDetail+5;   0   �� 5<   
   -   5        $��button1��5<   �   $��23��6Z   $
��Left=�6f   $��
122,72,0,0q�6�   $	��Top=�5=      $��45��6)   ��5<        $!	 Client.Properties.Resources��$
 AddWithSymbol��5=   4   &   System.Windows.Controls.DataGrid  5>   
   -	   5        $��	dataGrid1��5?         AutoGenerateColumns .  $
��Left=�5>   /   $��122,104,0,0q�6J   $
��auto��6_   $
��auto��6l   $	��Top=�5?   <   $   HorizontalScrollBarVisibility$
 Auto=�6T      
IsReadOnly . ��6$   ��    Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header 6%     $!	 Client.Properties.Resources��$
 	Commodity��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6i   �� *Commodity.Name+6�     5B       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$

 Rule�� 5C   %   �� *
RuleType+ �� 	Converter# [  6}     5D       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 CommissionRate�� 6�   �� *	RuleValue+$	  DBEntity.EnumEntity.RoundRules 	  STR_RATE �� StringFormat# Z 6�     5F       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 Rule2�� 5G   %   �� *	RuleType2+# [  6~     5H       6%     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 CommissionRate2�� 6�   �� *
RuleValue2+# Z 6�     5I      $ 界限内规则1��6%    65   �� *InLimitRuleType1+# [  6�     5J      $ 界限内费率1��6%    65   �� *InLimitRuleValue1+# Z 6�     5K      $ 界限内规则2��6%    65   �� *InLimitRuleType2+# [  6�     5L      $ 界限内费率2��6%    65   �� *InLimitRuleValue2+# Z 6�     5M      $ 界限外规则1��6%    65   �� *OutLimitRuleType1+# [  6�     5N      $ 界限外费率1��6%    65   �� *OutLimitRuleValue1+# Z 6�     5O      $ 界限外规则2��6%    65   �� *OutLimitRuleType2+# [  6�     5P      $ 界限外费率2��6%    65   �� *OutLimitRuleValue2+# Z 6�     5Q       6%     $!	 Client.Properties.Resources��$
 Comments�� 6h   �� *	Comment+6�   4
  .System.Windows.Controls.DataGridTemplateColumn
  5R       
  CellTemplate# [ 6m    6)     $!	 Client.Properties.Resources��$
 	Operation��6�   5T      �� 5U   
   -
   5        $��button2��5U   �   $��25��6Q   $
��Left=�6]   $��
210,25,0,0q�6x   $	��Top=�5V      $��60��6)   $��1��6I   ��5U        $!	 Client.Properties.Resources��$

 Save��5V   I   �� 5W   
   -   5        $��button3��5W   �   $��25��6X   $
��Left=�6d   $��
399,25,0,0q�6   $y�	Collapsed=�5X      $	��Top=�6(   $��60��6@   $��1��6K   ��5W        $!	 Client.Properties.Resources��$
 SaveAsDraft��5X   K   �� 5Y   
   -   5        $��button4��5Y   �   $��25��6S   $
��Left=�6_   $��
305,25,0,0q�6z   $	��Top=�5Z      $��60��6)   $��1��6I   ��5Y        $!	 Client.Properties.Resources��$
 Cancel��5Z   I   5[      5\      