   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  B    <Client.View.SystemSetting.BankAccountSetting.BankAccountHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$H  BClient.View.SystemSetting.BankAccountSetting.ResBankAccountSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *BankAndAccountHome+ � 	Resources 0  *Client.Converters.BankAccountTypeConverter   ConvertType  BankEdit  
BankDelete  BankView  AccountEdit  AccountDelete  AccountView  BankActions �� DataType �� Orientation   ResxName
   Key  AccountActions 	 BankLink �� Command	 �� CommandParameter 
 AccountLink��%j  &	        &	      &	 
     &	      &	      &	      &	      &	 #     7  7  &	     7  7  &		 &    7  &	
 ~    7    �� �� �� �� �� �� �� $ DBEntity:Bank��.R��� $ 
Horizontal=�.+��� $��
btBankEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btBankDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:BankAccount��.R��� $ 
Horizontal=�.+��� $��btAccountEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btAccountDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:Bank��.R��� �� 8   	 �� *Id+.�.��� ��� *Name+�� $ DBEntity:BankAccount��.R��� �� 8   	 �� *Id+.�.��� ��� *AccountCode+
 J� CommandBindings
 )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *BankAndAccountHome+�� -	   $��tabControl1��$
��Auto��$
��Left=�$��6,40,0,0q�$	��Top=�$
��auto��$	��380��$	��600��.@��� -
   $��tiBank����  $! Client.Properties.Resources��$
 Bank��.��� .+��� -   $��button1��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��$  Utility.Controls.PagingControl  -   $��pagingControl1��$��	6,105,0,0q�$��31��$	��Top=�$
��Left=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,142,0,0q�$	��Top=�$
��Auto��   
IsReadOnly .   DataGridStyle#��[   DataGridRowStyle   RowStyle# [ ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	    CanUserSort .   DataGridColumnHeaderStyle   HeaderStyle# [    SortMemberPath$
 Name��   CellTemplate# [	    Header   $! Client.Properties.Resources��$ BankName��0
  *System.Windows.Controls.DataGridTextColumn
  $ SWIFT��$
 Auto	  . # [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Code+
  $
 Auto	  . # [    $H BClient.View.SystemSetting.BankAccountSetting.ResBankAccountSetting��$ BankAddress�� �� *	Address+
  $
 Auto	  . # [    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto	  .  # [ # [    $! Client.Properties.Resources��$ 	Operation���� -   $��	groupBox1��$��65��$
��Left=�$��6,35,0,0q�$	��Top=�$	��580����  $! Client.Properties.Resources��$ 
Conditions��.���  � ColumnDefinitions �� $
��266* �.+��� -   $��label2��$��6,10,0,0q�$	��Top=�$
��Left=�$��60��$��28��$��Right=���  $! Client.Properties.Resources��$
 Name���� -   $��txtName��$
��Left=�$��	72,12,0,0q�$	��Top=�$	��120��$��23������ *
SearchName+�� -   $��	btnSearch��$��23��$
��left=�$��
201,12,0,0q�$	��Top=�$��75�� �� 	IsDefault . ��  $! Client.Properties.Resources��$ Query���� -   $��	tiAccount����  $! Client.Properties.Resources��$ BankAccount��.��� .+��� -   $��button2��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -   $��pagingControl2��$��	6,105,0,0q�$��31��$	��Top=�$
��Left=�  -   $��	dataGrid2�� .  $
��Auto��$
��Left=�$��	6,142,0,0q�$	��Top=�$
��Auto�� . #��[ # [ ����  
  $
 Auto	  . # [    $! Client.Properties.Resources��$ BankName�� �� *	Bank.Name+  $
 Auto	  . # [ $ AccountCode��# [
    $! Client.Properties.Resources��$ AccountCode��
  $
 Auto	  . # [    $! Client.Properties.Resources��$ BankAccountCurrency�� �� *Currency.Name+
  $
 Auto	  . # [    $! Client.Properties.Resources��$ AccountUsage�� �� *Usage+ �� 	Converter# [  
  $
 Auto	  . # [    $! Client.Properties.Resources��$ CustomerName�� �� *BusinessPartner.ShortName+
  $
 Auto	  . # [    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto	  .  # [ # [    $! Client.Properties.Resources��$ 	Operation���� -   $��	groupBox2��$��65��$
��Left=�$��6,35,0,0q�$	��Top=�$	��580����  $! Client.Properties.Resources��$ 
Conditions��.���  �� $
��266* �.+��� -   $��label1��$��28��$
��Left=�$��Right=�$��6,10,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$
 Name���� -   $��	txtBAName��$��23��$
��Left=�$��	72,12,0,0q�$	��Top=�$	��120������ *SearchBankAccountName+�� -   $��button3��$��23��$
��Left=�$��
479,12,0,0q�$	��Top=�$��75�� . ��  $! Client.Properties.Resources��$ Query���� -   $��label3��$��28��$
��Left=�$��Right=�$��
198,10,0,0q�$	��Top=�$	��100����  $! Client.Properties.Resources��$ CustomerName���� -   $��button4��$	��...��$��23��$
��Left=�$��
428,12,0,0q�$	��Top=�$��25���� -   $��textBox5��$
��Left=�{�.  $��
304,12,0,0q�$	��Top=�$	��120��$��23������ *SearchCustomerName+