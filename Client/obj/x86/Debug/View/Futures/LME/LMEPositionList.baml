   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 6C   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      -    'Client.View.Futures.LME.LMEPositionList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     6C   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$$  Client.View.Futures.LME.ResLME��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   :        ResxName$! Client.Properties.Resources��
   Key$ LMEPosition�� � 	Resources 5      2   ,Client.Converters.PositionDirectionConverter   PositionDirectionConverter-   'Client.Converters.PositionTypeConverter  PositionTypeConverter  ListEdit  
ListDelete  ListActions �� DataType �� Orientation��%�  &	        &	      &	 &     &	 9     &	 L     7  7    5   
   60     5   
   6+   �� 5   
   6+   �� 5   
   6-   �� 5   
   $ DBEntity:LMEPosition��6+   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��
btListEdit��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btListDelete��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [ 5      6{     5   
   -   5        #	 [ 5      5   9   .��5"      �� $
��Auto=�6   $
��Auto=�68   .��5#   
   � -   5        
 �Name$
 rootGrid��5#      .+�5$      �� -   5        $��lbTitle��5$   5   $��32��6D   $
��Left=�6P   $��6,6,0,0q�6k   $
��auto��6|   $	��Top=�5%      $
��Bold"�6,   $��16(�6>   ��5$        *LMEPositionList+5%   >   $  Utility.Controls.PagingControl  5'      -   5          Name$ 	pagerList��5'      $��6,40,0,0q�62   $
��Left=�6D   $	��Top=�6_   &   System.Windows.Controls.DataGrid  5(      -   5          Name$ listGrid��5(   )   $��6,77,0,0q�6      AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[ 6o     DataGridRowStyle   RowStyle# [ 6�      
IsReadOnly . $	��Top=�5)   )   $
��Left=�6A      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$ 	Commodity��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6m   �� *Commodity.Name+  5,       6)     $! Client.Properties.Resources��$ 	TradeDate�� 6m   �� *	TradeDate+ �� StringFormat$ 
yyyy-MM-dd��  5-       6)     $! Client.Properties.Resources��$ 
PromptDate�� 6n   �� *
PromptDate+$ 
yyyy-MM-dd��  5.       6)     $! Client.Properties.Resources��$	 Lot�� 6g   �� *	LotAmount+$  DBEntity.EnumEntity.RoundRules   STR_INTEGER# Z   5/       6)     $! Client.Properties.Resources��$ 	Direction�� 50   )   �� *TradeDirection+ �� 	Converter# [    51       6)     $! Client.Properties.Resources��$ PositionType�� 52   )   �� *PositionType+# [   53       6)     $! Client.Properties.Resources��$ AgentCommission�� 6s   �� *AgentCommission+   
STR_AMOUNT# Z   54       6)     $! Client.Properties.Resources��$ CustomerCommission�� 6v   �� *ClientCommission+# Z   55       6)     $! Client.Properties.Resources��$ BP�� 6f   �� *Client.ShortName+  56       6)     $$ Client.View.Futures.LME.ResLME��$ CustomerPrice�� 6t   �� *ClientPrice+   	STR_PRICE# Z   57       6)     $! Client.Properties.Resources��$ Broker�� 6j   �� *Agent.ShortName+  58       6)     $$ Client.View.Futures.LME.ResLME��$ BrokerPrice�� 6r   �� *
AgentPrice+# Z   59       6)     $! Client.Properties.Resources��$ QuotaNo�� 6k   �� *Quota.QuotaNo+  5:       6)     $! Client.Properties.Resources��$ InternalCustomer�� 6t   �� *InternalBP.ShortName+4  .System.Windows.Controls.DataGridTemplateColumn  5;       	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6q    	  CanUserSort .     CellTemplate# [ 5<   -    5;   -     $! Client.Properties.Resources��$ 	Operation��5<   [   5>      5?      5@      5A      