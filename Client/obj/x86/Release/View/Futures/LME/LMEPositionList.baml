   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity -    'Client.View.Futures.LME.LMEPositionList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$$  Client.View.Futures.LME.ResLME�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ LMEPosition�� � 	Resources 2   ,Client.Converters.PositionDirectionConverter   PositionDirectionConverter-   'Client.Converters.PositionTypeConverter  PositionTypeConverter  ListEdit  
ListDelete  ListActions �� DataType �� Orientation��%P  &	        &	      &	 
     &	      &	      7  7      �� �� �� $ DBEntity:LMEPosition��.R��� $ 
Horizontal=�.+��� $��
btListEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btListDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�.��� -   
 �Name$
 rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  $! Client.Properties.Resources��$ LMEPosition��$  Utility.Controls.PagingControl  -     Name$ 	pagerList��$��6,40,0,0q�$
��Left=�$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ listGrid��$��6,77,0,0q�   AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[   DataGridRowStyle   RowStyle# [    
IsReadOnly . $	��Top=�$
��Left=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $! Client.Properties.Resources��$ 	Commodity��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Commodity.Name+     $! Client.Properties.Resources��$ 	TradeDate�� �� *	TradeDate+ �� StringFormat$ 
yyyy-MM-dd��     $! Client.Properties.Resources��$ 
PromptDate�� �� *
PromptDate+$ 
yyyy-MM-dd��     $! Client.Properties.Resources��$	 Lot�� �� *	LotAmount+$  DBEntity.EnumEntity.RoundRules   STR_INTEGER# Z      $! Client.Properties.Resources��$ 	Direction�� �� *TradeDirection+ �� 	Converter# [       $! Client.Properties.Resources��$ PositionType�� �� *PositionType+# [      $! Client.Properties.Resources��$ AgentCommission�� �� *AgentCommission+   
STR_AMOUNT# Z      $! Client.Properties.Resources��$ CustomerCommission�� �� *ClientCommission+# Z      $! Client.Properties.Resources��$ BP�� �� *Client.ShortName+     $$ Client.View.Futures.LME.ResLME��$ CustomerPrice�� �� *ClientPrice+   	STR_PRICE# Z      $! Client.Properties.Resources��$ Broker�� �� *Agent.ShortName+     $$ Client.View.Futures.LME.ResLME��$ BrokerPrice�� �� *
AgentPrice+# Z      $! Client.Properties.Resources��$ QuotaNo�� �� *Quota.QuotaNo+     $! Client.Properties.Resources��$ InternalCustomer�� �� *InternalBP.ShortName+4  .System.Windows.Controls.DataGridTemplateColumn   	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  	  CanUserSort .     CellTemplate# [    $! Client.Properties.Resources��$ 	Operation��