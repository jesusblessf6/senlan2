   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient F   @Client.View.SystemSetting.CommissionSetting.CommissionLineDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     <baseClient2$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$F  @Client.View.SystemSetting.CommissionSetting.ResCommissionSetting��$	��550��$	��550�� � 
ResizeMode$ NoResize=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title   *CommissionLineDetail+ � 	Resources  �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker��%)  '��       '�� S     '�� �     '  �     �� " ��.���  � ��$ 28����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120��.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *CommissionLineDetail+�� -   $��label2��$��6,38,0,0q�$
��Left=�$	��Top=���  	   ResxName$!	 Client.Properties.Resources��

   Key$
 	Commodity���� -   $��	comboBox1��$��
122,40,0,0q� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name��$
��Left=�$	��Top=����� *CommodityList+ �� SelectedValue �� *SelectCommodityID+�� -   $��	groupBox1��$��普通头寸��$��53��$
��Left=�$��5,79,0,0q�$	��Top=�$	��510��.��� -   $ grid1��.+��� -   $��label3��$��55,3,0,0q�$
��Left=�$	��Top=�$��50����  *Rate+&    Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��	112,5,0,0q�$	��Top=�$��68��   Text �� *	RuleValue+�� -	   $��	comboBox2��$��23��$
��Left=�$��	186,5,0,0q�$	��Top=�$��60��$ Value��$	 Key������ *CommissionRuleTypes+ �� *
RuleTypeID+�� -
   $��label7��$��+��$��28��$��16(�$
��Left=�$��Center=�$��	286,5,0,0q�$	��Top=�$��30���� -   $��textBox1��$��23��$
��Left=�$��	350,5,0,0q�$	��Top=�$��68������ *
RuleValue2+�� -   $��	comboBox3��$��23��$
��Left=�$��	424,5,0,0q�$	��Top=�$��60��$ Value��$	 Key������ *CommissionRuleTypes+ �� *RuleTypeID2+�� -   $��	groupBox2��$��调期头寸��$	��153��$
��Left=�$��	5,150,0,0q�$	��Top=�$	��510��.��� -   $ grid2��.+��� -   $��textBox2��$��23��$
��Left=�$��78,6,0,0q�$	��Top=�$��50������ *CarryDaysLimit+�� -   $��label8��$��天以内（包含）��$��28��$
��Left=�$��	129,4,0,0q�$	��Top=�$	��100���� -   $��	checkBox1��$��收取单边��$��16��$
��Left=�$��
230,10,0,0q�$	��Top=� d� 	IsChecked �� *InLimitIsOneLeg+�� -   $��label9��$��费率��$��28��$
��Left=�$��	55,35,0,0q�$	��Top=�$��50���� -   $��textBox4��$��23��$
��Left=�$��
112,35,0,0q�$	��Top=�$��68������ *InLimitRuleValue1+�� -   $��	comboBox4��$��23��$
��Left=�$��
186,35,0,0q�$	��Top=�$��60��$ Value��$	 Key������ *CommissionRuleTypes+ �� *InLimitRuleTypeID1+�� -   $��label10��$��+��$��28��$
��Left=�$��
286,35,0,0q�$	��Top=�$��30���� -   $��textBox5��$��23��$
��Left=�$��
350,35,0,0q�$	��Top=�$��68������ *InLimitRuleValue2+�� -   $��	comboBox5��$��23��$
��Left=�$��
424,35,0,0q�$	��Top=�$��60��$ Value��$	 Key������ *CommissionRuleTypes+ �� *InLimitRuleTypeID2+�� -   $��textBox6��$��23��$
��Left=�$��	78,65,0,0q�$	��Top=�$��50�� �� 
IsReadOnly . ���� *CarryDaysLimit+�� -   $��label11��$��	天以外��$��28��$
��Left=�$��
126,64,0,0q�$	��Top=�$��55���� -   $��	checkBox2��$��收取单边��$��16��$
��Left=�$��
230,69,0,0q�$	��Top=� �� *OutLimitIsOneLeg+�� -   $��label12��$��费率��$��28��$
��Left=�$��	55,95,0,0q�$	��Top=�$��50���� -   $��textBox7��$��23��$
��Left=�$��112,95,0,00q�$	��Top=�$��68������ *OutLimitRuleValue1+�� -   $��	comboBox6��$��23��$
��Left=�$��
186,95,0,0q�$	��Top=�$��60��$ Value��$	 Key������ *CommissionRuleTypes+ �� *OutLimitRuleTypeID1+�� -   $��label13��$��+��$��28��$
��Left=�$��
286,95,0,0q�$	��Top=�$��30���� -   $��textBox8��$��23��$
��Left=�$��
350,95,0,0q�$	��Top=�$��68������ *OutLimitRuleValue2+�� -    $��	comboBox7��$��23��$
��Left=�$��
424,95,0,0q�$	��Top=�$��60��$ Value��$	 Key������ *CommissionRuleTypes+ �� *OutLimitRuleTypeID2+�� -!   $��label4��$��	6,310,0,0q�$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 	StartDate��  -"   $��datePicker1��$��122,312,0,0q�$
��Left=�$	��Top=�   SelectedDate �� *	StartDate+�� -#   $��label5��$��250,310,0,0q�$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 EndDate��  -$   $��datePicker2��$��366,312,0,0q�$
��Left=�$	��Top=� �� *	EndDate+�� -%   $��label6��$
��Left=�$��	6,342,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$
 Comments���� -&   $��textBox3��$	��100��$
��Left=�$��122,344,0,0q�$	��Top=�$	��364�� �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *	Comment+�� -'   $��button1��$��25��$
��Left=�$��210,469,0,0q�$	��Top=�$��60����  $!	 Client.Properties.Resources��$

 Save���� -(   $��button2��$��25��$
��Left=�$��305,469,0,0q�$	��Top=�$��60����  $!	 Client.Properties.Resources��$
 Cancel��