   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  D    >Client.View.SystemSetting.CurrencyRateSetting.CurrencyRateHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$J  DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *CurrencyAndRate+ � 	Resources ,   &Client.Converters.BoolReverseConverter   BoolConverter  CurrencyEdit  CurrencyDelete  CurrencyView  RateEdit  
RateDelete  RateView  CurrencyActions �� DataType �� Orientation   ResxName
   Key �� 	Converter  RateActions 	 CurrencyLink	 �� Command
 �� CommandParameter 
 RateLink �� StringFormat��%�  &	        &	      &	 
     &	      &	      &	      &	      &	 #     7  7   7  7   &	 `    7  7  &		 [    7  &	
 �    7    �� �� �� �� �� �� �� $ DBEntity:Currency��.R��� $ 
Horizontal=�.+��� $��btCurrencyEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+{��� *
IsSystem+8  �� $��btCurrencyDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+{��� *
IsSystem+8  �� $ DBEntity:Rate��.R��� $ 
Horizontal=�.+��� $��
btRateEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btRateDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:Currency��.R��� �� 8	   
 �� *Id+.�.��� ��� *Name+�� $ DBEntity:Rate��.R��� �� 8	   
 �� *Id+.�.��� ��� *	RateValue+$ N�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *CurrencyAndRate+�� -	   $��tabControl1��$��6,40,0,0q�$	��300��$
��Auto��$	��394��$
��Left=�$	��Top=�.@��� -
   $��
tiCurrency����  $! Client.Properties.Resources��$ Currency��.��� .+��� -   $��button1��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,38,0,0q�$	��Top=�$
��Auto��   
IsReadOnly . ���� *
Currencies+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    SortMemberPath$
 Name��   CellTemplate# [	    Header   $J DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting��$ CurrencyName��0	  *System.Windows.Controls.DataGridTextColumn	  $
 Auto  .    $J DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting��$ CurrencyCode��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Code+	  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation���� -   $��tiRate����  $! Client.Properties.Resources��$ ExchangeRate��.��� .+��� -   $��btRate��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -   $��ratedataGrid�� .  $
��Auto��$
��Left=�$��6,38,0,0q�$	��Top=�$
��Auto�� . ���� *Rates+ 	  $
 Auto  .    $J DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting��$ CurrencyName�� �� *Currency.Name+  $
 Auto  . $ 	RateValue��# [
    $! Client.Properties.Resources��$ ExchangeRate��	  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation��