   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient J   DClient.View.SystemSetting.BusinessPartnerSetting.BusinessPartnerHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$P  JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
��auto��$
��auto�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *BPHome+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value4  .Client.Converters.BusinessPartnerTypeConverter  ConvertType  PartnerEdit  PartnerDelete  PartnerView  PartnerActions �� DataType �� Orientation	   ResxName

   Key��%l  &	        '�� �     '�� �     &	 �     &	 �     &	 �     &	     &	     7  7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 100����  � ��$	 100����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120��  �� �� �� �� $ DBEntity:BusinessPartner��.R��� $ 
Horizontal=�.+��� $��btPartnerEdit��8��  ��  $!	 Client.Properties.Resources��$

 Edit������ *Id+�� $��btPartnerDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *BPList+�� -   $��btnAdd��$��23��$
��Left=�$��6,40,0,0q�$	��Top=�$��60����  $!	 Client.Properties.Resources��$
 AddWithSymbol���� -   $��
separator1��$��17��$��6,63,6,0q�$	��Top=��� -   $��	groupBox1��$��65��$
��Left=�$��6,75,0,0q�$	��Top=�$	��600����  $!	 Client.Properties.Resources��$
 
Conditions��.��� .+��� -	   $��label2��$
��Left=�#��[  $��1,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$

 Name���� -
   $��txtName��$
��Left=�$��
107,12,0,0q�$	��Top=����� *
SearchName+�� -   $��label3��#��[  $
��Left=�$��
240,10,0,0q�$	��Top=���  $!	 Client.Properties.Resources��$

 Type���� -   $��comboBoxType��$
��Left=�$��
346,12,0,0q�$	��Top=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *BusinessPartnerTypes+ �� SelectedValue �� *SelectedType+�� -   $��	btnSearch��$��23��$
��left=�$��
481,12,0,0q�$	��Top=�$��45����  $!	 Client.Properties.Resources��$
 Query���� -   $��
separator2��$��17��$��	6,140,6,0q�$	��Top=�$   Utility.Controls.PagingControl  -   $��
pgPartners��$��	6,154,0,0q�$��31��$	��Top=�$
��Left=�&   System.Windows.Controls.DataGrid  -   $��dataGridPartner��   AutoGenerateColumns .  $
��Left=�$��	6,191,0,0q�$	��Top=�   CanUserAddRows .     
IsReadOnly .   DataGridStyle#��[   DataGridRowStyle   RowStyle# [ ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    SortMemberPath$ 	ShortName��  DataGridColumnHeaderStyle   HeaderStyle# [    Header   $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 BPShortName��   CellTemplate �� $ DBEntity:BusinessPartner��.R��� ��  �� Command# [  �� CommandParameter �� *Id+.�.��� ��� *	ShortName+0	  *System.Windows.Controls.DataGridTextColumn	   .    Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 # [    $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 
BPFullName��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+	   . $
 Auto
 # [    $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 EnglishFullName�� �� *EnglishName+	  # [  . $
 Auto
    $!	 Client.Properties.Resources��$

 Type�� �� *CustomerType+ �� 	Converter# [ 	   . $
 Auto
 # [    $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 BPCode�� �� *Code+	   . $
 Auto
 # [    $!	 Client.Properties.Resources��$
 Address�� �� *	Address+	   . $
 Auto
 # [    $!	 Client.Properties.Resources��$
 ContactPerson�� �� *ContactPerson+	   . $
 Auto
 # [    $!	 Client.Properties.Resources��$	
 Tel�� �� *ContactPhone+	   . $
 Auto
 # [    $!	 Client.Properties.Resources��$	
 Fax�� �� *Fax+	   . $
 Auto
 # [    $!	 Client.Properties.Resources��$
 PostCode�� �� *	ZipCode+	   . $
 Auto
 # [    $!	 Client.Properties.Resources��$
 Comments�� �� *Remark+  $
 Auto
  .  # [ # [    $!	 Client.Properties.Resources��$
 	Operation��