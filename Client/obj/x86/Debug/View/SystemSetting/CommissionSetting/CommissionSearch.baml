   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      B    <Client.View.SystemSetting.CommissionSetting.CommissionSearch   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$F  @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   l     *CommissionSettingList+ � 	Resources 5      3   -Client.Converters.CommissionRuleTypeConverter   CommissionRuleTypeConverter  CommissionLineEdit  CommissionLineDelete  CommissionLineActions �� DataType �� Orientation   ResxName
   Key��%�  &	        &	      &	 &     &	 9     7  7    5   
   61   �� 5   
   65   �� 5   
   67   �� 5   
   $ DBEntity:CommissionLine��65   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btCommissionLineEdit��6   8��  ��65     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btCommissionLineDelete��6   8�� ��67     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [ 5      5   A     5   
   -   5        #	 [ 5      5    C   .��5"      � -   5        
 �Name$
 rootGird��5"      .+�5#   
   �� -   5        $��lbTitle��5$   0   $��32��5#   7   $
��Left=�6C   $��6,6,0,0q�6^   $	��Top=�6o   $
��Bold"�5$      $��16(�6"   ��5#        *CommissionSettingList+5$   0   $  Utility.Controls.PagingControl  5%   
   -   5          Name$ pagerContract��5%      $��31��62   $
��auto��6>   $��6,40,0,0q�6K   $
��Left=�6]   $	��Top=�5&      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ commissionGrid��5'   %   $��6,77,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $
��Left=�5(   %   $
��auto��6@   $
��auto��6M   $	��Top=�6[      Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header 6%     $F @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$ BrokerOrCustomer��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6�   �� *BusinessPartner.ShortName+6�     5+       6%     $! Client.Properties.Resources��$ InternalCustomer�� 6p   �� *InternalBP.ShortName+6�      RowDetailsTemplate 5-      �� 5.      $ DBEntity:Commission��6   .R�5/        $��dataGridDetail��6    .   .   . ��65   �� *CommissionLines+ 51        52       61     $! Client.Properties.Resources��$ 	Commodity�� 6u   �� *Commodity.Name+6�     53       61     $F @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 Rule�� 54   1   �� *
RuleType+ �� 	Converter# [  6�     55       61     $F @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$ CommissionRate�� 6�   �� *	RuleValue+6�     56       61     $F @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$ Rule2�� 57   1   �� *	RuleType2+# [  6�     58       61     $F @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$ CommissionRate2�� 6�   �� *
RuleValue2+6�     59      $ 界限内规则1��61    6A   �� *InLimitRuleType1+# [  6�     5:      $ 界限内费率1��61    6A   �� *InLimitRuleValue1+$
  DBEntity.EnumEntity.RoundRules 
  STR_RATE �� StringFormat# Z 6�     5;      $ 界限内规则2��61    6A   �� *InLimitRuleType2+# [  6�     5<      $ 界限内费率2��61    6A   �� *InLimitRuleValue2+# Z 6�     5=      $ 界限外规则1��61    6A   �� *OutLimitRuleType1+# [  6�     5>      $ 界限外费率1��61    6A   �� *OutLimitRuleValue1+# Z 6�     5?      $ 界限外规则2��61    6A   �� *OutLimitRuleType2+# [  6�     5@      $ 界限外费率2��61    6A   �� *OutLimitRuleValue2+# Z 6�     5A       61     $! Client.Properties.Resources��$ Comments�� 6t   �� *	Comment+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5B         CellTemplate# [ 6y    65     $! Client.Properties.Resources��$ 	Operation��6�   5D      5E      5G      5H      5I      