   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  <    6Client.View.SystemSetting.DataDictSetting.DataDictHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *
DataDict+ � 	Resources (   "Client.Converters.VATTypeConverter   ConvertType-   'Client.Converters.IsSystemTypeConverter  IsSystemType,   &Client.Converters.BoolReverseConverter  BoolConverter  CountryEdit  CountryDelete  CountryView  PortEdit  
PortDelete  PortView 	 PaymentMeanEdit 
 PaymentMeanDelete  PaymentMeanView  VATRateEdit  VATRateDelete  VATRateView  PaymentUsageEdit  PaymentUsageDelete  PaymentUsageView  UdfEdit  	UdfDelete  UdfView 
 DPEdit  DPDelete 
 DPView  CountryActions �� DataType �� Orientation   ResxName
   Key  PortActions  PaymentMeanActions �� 	Converter  VATRateActions  PaymentUsageActions  
UdfActions  CountryLink	 �� Command
 �� CommandParameter  PortLink   PaymentMeanLink ! VATRateLink " PaymentUsageLink��%R
  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 2     &	 7     &	 <     &	 A     &	 F     &	 K     &	 P     &	 U     &	 Z     &	 _     &	 d     &	 i     &	 n     &	 s     &	 x     7  7  &	 |    7  7  &	 w    7 	 7  7 
 7  &	 �    7  7  &	 �    7  7  &	 �    7  7  &	 �    7  &	 6    7  &	  �    7  &	! �    7  &	" H    7        �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� �� $ DBEntity:Country��.R��� $ 
Horizontal=�.+��� $��btCountryEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btCountryDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:Port��.R��� $ 
Horizontal=�.+��� $��
btPortEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btPortDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:PaymentMean��.R��� $ 
Horizontal=�.+��� $��btPaymentMeanEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+{��� *
IsSystem+8  �� $��btPaymentMeanDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+{��� *
IsSystem+8  �� $ DBEntity:VATRate��.R��� $ 
Horizontal=�.+��� $��btVATRateEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btVATRateDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:PaymentUsage��.R��� $ 
Horizontal=�.+��� $��btPaymentUsageEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btPaymentUsageDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:ContractUDF��.R��� $ 
Horizontal=�.+��� $��	btUdfEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btUdfDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:Country��.R��� �� 8	   
 �� *Id+.�.��� ��� *ChineseName+�� $ DBEntity:Port��.R��� �� 8	   
 �� *Id+.�.��� ��� *Name+�� $ DBEntity:PaymentMean��.R��� �� 8	   
 �� *Id+.�.��� ��� *Name+�� $ DBEntity:VATRate��.R��� �� 8	   
 �� *Id+.�.��� ��� *Code+�� $ DBEntity:PaymentUsage��.R��� �� 8	   
 �� *Id+.�.��� ��� *Name+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [	   -   # [
   -	   # [   -
   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  *
DataDict+�� -   $��tabControl1��$	��420��$
��Left=�$��6,40,0,0q�$	��Top=�$	��550��.@��� -   $��tabItem1����  $! Client.Properties.Resources��$ OriginCountry��.���� $
��Auto=�$
��Auto=�.��� .+��� -   $��button1��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��6,35,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,72,0,0q�   
IsReadOnly . $	��Top=�$
��Auto��$��2������    Columns 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  
  CanUserSort .  
  SortMemberPath$ ChineseName�� 	  CellTemplate# [  
  Header   $! Client.Properties.Resources��$ OriginCountry��0  *System.Windows.Controls.DataGridTextColumn  $
 Auto  .    $! Client.Properties.Resources��$ EnglishName��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+	  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation���� -   $��tabItem2����  *Port+.���� $
��Auto=�$
��Auto=�.��� .+��� -   $��button2��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -   $��portpagingControl��$
��Left=�$��6,35,0,0q�$��31��$	��Top=�  -    $��portDataGrid�� .  $
��Auto��$
��Left=�$��6,72,0,0q� . $	��Top=�$
��Auto��$��2������  	  $
 Auto  . $
 Name��# [    $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$
 Port��  $
 Auto  .    $! Client.Properties.Resources��$ OriginCountry�� �� *Country.ChineseName+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+	  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation���� -!   $��tabItem3����  $! Client.Properties.Resources��$ PaymentMean��.���� $
��Auto=�$
��Auto=�.��� .+��� -"   $��btPaymentMean��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -#   $��paymentmeanpagingControl��$
��Left=�$��6,35,0,0q�$��31��$	��Top=�  -$   $��paymentMeanDataGrid�� .  $
��Auto��$
��Left=�$��6,72,0,0q� . $	��Top=�$
��Auto��$��2������  	  $
 Auto  . $
 Name��# [     $! Client.Properties.Resources��$ PaymentMean��  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto  .    $! Client.Properties.Resources��$ SystemValue�� �� *
IsSystem+# [ 	  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation���� -%   $��tabItem4����  *VAT+.���� $
��Auto=�$
��Auto=�.��� .+��� -&   $��	btVATRate��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -'   $��vatratepagingControl��$
��Left=�$��6,35,0,0q�$	��Top=�  -(   $��vatRateDataGrid�� .  $
��Auto��$
��Left=�$��6,72,0,0q� . $	��Top=�$
��Auto��$��2������  	  $
 Auto  . # [!    $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$ TaxCode��  $
 Auto  .    $! Client.Properties.Resources��$
 Type�� �� *Type+# [    $
 Auto  . $
 Code��   $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$
 Rate�� �� *	RateValue+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+	  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation���� -)   $��tabItem5����  $! Client.Properties.Resources��$ PaymentUsage��.���� $
��Auto=�$
��Auto=�.��� .+��� -*   $��btPaymentUsage��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -+   $��paymentusagepagingControl��$
��Left=�$��6,35,0,0q�$��31��$	��Top=�  -,   $��paymentUsageDataGrid�� .  $
��Auto��$
��Left=�$��6,72,0,0q� . $	��Top=�$
��Auto��$��2������  	  $
 Auto  . $
 Name��# ["    $! Client.Properties.Resources��$
 Name��  $
 Auto  .    $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$ DefaultPaymentMean�� �� *PaymentMean.Name+  $
 Auto  .    $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$ DefaultFinancialAccount�� �� *FinancialAccount.Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $ 默认��$
 Auto  .  �� *	IsDefault+# [ 	  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation���� --   $��tabItem7��$��	提货人��.���� $
��Auto=�$
��Auto=�.��� .+��� -.   $��btAddDP��$��+新增��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45��  -/   $��dpListPager��$
��Left=�$��6,35,0,0q�$	��Top=�  -0   $��dgDPList�� .  $
��Auto��$
��Left=�$��6,72,0,0q�$	��Top=�$
��Auto�� . ����    $ 姓名��$
 Auto  .  �� *Name+  $ 车号��$
 Auto  .  �� *	VehicleNo+  $ 电话��$
 Auto  .  �� *Tel+  $ 身份证号��$
 Auto  .  �� *IdNo+  $ 备注��$
 Auto  .  �� *
Comments+	  $ 操作��$
 Auto  .  �� $ DBEntity:DeliveryPerson��.R��� $ 
Horizontal=�.+��� $��查看��#��[ ���� *Id+�� $��编辑��#��[ ���� *Id+�� $��删除��#��[ ���� *Id+�� -1   $��tabItem6����  $! Client.Properties.Resources��$	 UDF��.���� $
��Auto=�$
��Auto=�.��� .+��� -2   $��btUDF��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -3   $��udfPagingControl��$
��Left=�$��6,35,0,0q�$��31��$	��Top=�  -4   $��udfDataGrid�� .  $
��Auto��$
��Left=�$��6,72,0,0q� . $	��Top=�$
��Auto��$��2������    $
 Auto  .    $! Client.Properties.Resources��$
 Name�� �� *Name+  $
 Auto  .    $! Client.Properties.Resources��$ Comments�� �� *	Comment+  $ 默认��$
 Auto  .  �� *	IsDefault+# [ 	  $
 Auto  .  # [    $! Client.Properties.Resources��$ 	Operation��