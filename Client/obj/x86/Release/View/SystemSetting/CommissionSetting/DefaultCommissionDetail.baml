   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity I    CClient.View.SystemSetting.CommissionSetting.DefaultCommissionDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$F  @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *DefaultRule+ � 	Resources  �� 
TargetType �� Property �� Value3   -Client.Converters.CommissionRuleTypeConverter   CommissionRuleTypeConverter  CommissionLineEdit  CommissionLineDelete  CommissionLineActions �� DataType �� Orientation	   ResxName

   Key��%�  '��       '�� S     &	  �     &	 �     &	 �     &	 �     7  7  �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120��  �� �� �� $ DBEntity:CommissionLine��.R��� $ 
Horizontal=�.+��� $��btCommissionLineEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��btCommissionLineDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .��� -    �Name$ rootGrid�� � RowDefinitions �� $
��Auto ��� $
��443* �.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(����� *	TitleName+�� -   $��label2��
���<��$
��Left=�$��6,38,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 InternalCustomer���� -   $��	comboBox1��$��23��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 	ShortName������ *InternalCustomerList+ �� SelectedValue �� *SelectInternalCustomerID+�� -   $��label4��$
��Left=�$��6,70,0,0q�$	��Top=���  *CommissionSettingDetail+�� -   $��button1��$��23��$
��Left=�$��
122,72,0,0q�$	��Top=�$��45����  $!	 Client.Properties.Resources��$
 AddWithSymbol��&   System.Windows.Controls.DataGrid  -	   $��	dataGrid1��   AutoGenerateColumns .  $
��Left=�$��122,104,0,0q�$
��auto��$
��auto��$	��Top=�$   HorizontalScrollBarVisibility$
 Auto=�   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header   $!	 Client.Properties.Resources��$
 	Commodity��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Commodity.Name+     $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$

 Rule�� �� *
RuleType+ �� 	Converter# [       $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 CommissionRate�� �� *	RuleValue+$	  DBEntity.EnumEntity.RoundRules 	  STR_RATE �� StringFormat# Z      $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 Rule2�� �� *	RuleType2+# [       $F	 @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$
 CommissionRate2�� �� *
RuleValue2+# Z   $ 界限内规则1�� �� *InLimitRuleType1+# [    $ 界限内费率1�� �� *InLimitRuleValue1+# Z   $ 界限内规则2�� �� *InLimitRuleType2+# [    $ 界限内费率2�� �� *InLimitRuleValue2+# Z   $ 界限外规则1�� �� *OutLimitRuleType1+# [    $ 界限外费率1�� �� *OutLimitRuleValue1+# Z   $ 界限外规则2�� �� *OutLimitRuleType2+# [    $ 界限外费率2�� �� *OutLimitRuleValue2+# Z      $!	 Client.Properties.Resources��$
 Comments�� �� *	Comment+4
  .System.Windows.Controls.DataGridTemplateColumn
   
  CellTemplate# [    $!	 Client.Properties.Resources��$
 	Operation���� -
   $��button2��$��25��$
��Left=�$��
210,25,0,0q�$	��Top=�$��60��$��1����  $!	 Client.Properties.Resources��$

 Save���� -   $��button3��$��25��$
��Left=�$��
399,25,0,0q�$y�	Collapsed=�$	��Top=�$��60��$��1����  $!	 Client.Properties.Resources��$
 SaveAsDraft���� -   $��button4��$��25��$
��Left=�$��
305,25,0,0q�$	��Top=�$��60��$��1����  $!	 Client.Properties.Resources��$
 Cancel��