   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 0    *Client.View.Finance.FundFlows.FundFlowList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$/  )Client.View.Finance.FundFlows.ResFundFlow�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *FundFlowList+ � 	Resources -   'Client.Converters.FundFlowTypeConverter   FundFlowTypeConverter  ListEdit  
ListDelete  ListActions �� DataType �� Orientation   ResxName
   Key��%�  &	        &	      &	 
     &	      7  7    �� �� �� $ DBEntity:FundFlow��.R��� $ 
Horizontal=�.+��� $��
btListEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+{��� *AutoGenGeneratedCanOperation+�� $��btListDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+{��� *AutoGenGeneratedCanOperation+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�.��� -   
 �Name$
 rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *FundFlowList+$  Utility.Controls.PagingControl  -     Name$ pager��$��6,40,0,0q�$
��Left=�$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ 
entityList��$��6,77,0,0q�   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $	��Top=�$
��Left=�  DataGridStyle#��[   DataGridRowStyle   RowStyle# [ ���� *	FundFlows+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header   $! Client.Properties.Resources��$ BP��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *BusinessPartner.ShortName+     $! Client.Properties.Resources��$ InternalCustomer�� �� *InternalCustomer.ShortName+     $! Client.Properties.Resources��$ Quota�� �� *Quota.QuotaNo+     $! Client.Properties.Resources��$ Amount�� �� *Amount+$
  DBEntity.EnumEntity.RoundRules 
  
STR_AMOUNT �� StringFormat# Z      $! Client.Properties.Resources��$ Currency�� �� *Currency.Name+     $/ )Client.View.Finance.FundFlows.ResFundFlow��$ FundFlowType�� �� *RorP+ �� 	Converter# [       $! Client.Properties.Resources��$
 Date�� �� *	TradeDate+$ 
yyyy-MM-dd��     $! Client.Properties.Resources��$ FinancialAccount�� �� *FinancialAccount.Name+  $ 付款方式�� �� *PaymentMean.Name+4  .System.Windows.Controls.DataGridTemplateColumn     Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .     CellTemplate# [    $! Client.Properties.Resources��$ 	Operation��