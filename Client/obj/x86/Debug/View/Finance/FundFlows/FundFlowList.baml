   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      0    *Client.View.Finance.FundFlows.FundFlowList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$/  )Client.View.Finance.FundFlows.ResFundFlow��5   +    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *FundFlowList+ � 	Resources 5      -   'Client.Converters.FundFlowTypeConverter   FundFlowTypeConverter*   $Client.Converters.CreatedByConverter  CreatedByConverter  ListEdit  
ListDelete  ListActions �� DataType �� Orientation   ResxName
   Key��%[  &	        &	      &	 &     &	 9     &	 L     7  7    5   
   6+     5   
   6(   �� 5   
   6+   �� 5   
   6-   �� 5   
   $ DBEntity:FundFlow��6+   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��
btListEdit��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����5   =   �� *Id+{�6]   �� *AutoGenGeneratedCanOperation+5      �� 5      $��btListDelete��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5   ?   �� *Id+{�6_   �� *AutoGenGeneratedCanOperation+5      5      5      5       J� CommandBindings 5       )  #System.Windows.Input.CommandBinding  5!   
   -   5        	   Command#	 [ 5!      6{     5"   
   -   5        #	 [ 5"      5$      .��5&      �� $
��Auto=�6   $
��Auto=�68   .��5'   
   � -   5        
 �Name$
 rootGrid��5'      .+�5(      �� -   5        $��lbTitle��5(   2   $��32��6A   $
��Left=�6M   $��6,6,0,0q�6h   $
��auto��5)      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5(        *FundFlowList+5)   K   $  Utility.Controls.PagingControl  5*      -   5          Name$ pager��5*      $��6,40,0,0q�6.   $
��Left=�6@   $	��Top=�6[   &   System.Windows.Controls.DataGrid  5+      -   5          Name$ 
entityList��5+   K   $��6,77,0,0q�6      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $	��Top=�5-   3   $
��Left=�6K     DataGridStyle#��[ 5.        DataGridRowStyle   RowStyle# [ 6>   ��5+   )   �� *	FundFlows+   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$ BP��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 51   )   �� *BusinessPartner.ShortName+  52       6)     $! Client.Properties.Resources��$ InternalCustomer�� 53   )   �� *InternalCustomer.ShortName+  54      $ 	经办人��6)    55   )   �� *	CreatedBy+ �� 	Converter# [   56       6)     $! Client.Properties.Resources��$ Quota�� 57   )   �� *Quota.QuotaNo+  58       6)     $! Client.Properties.Resources��$ Amount�� 59   )   �� *Amount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z   5:       6)     $! Client.Properties.Resources��$ Currency�� 5;   )   �� *Currency.Name+  5<       5=        $/ )Client.View.Finance.FundFlows.ResFundFlow��$ FundFlowType�� 5>      �� *RorP+# [    5?       6)     $! Client.Properties.Resources��$
 Date�� 5@   )   �� *	TradeDate+$ 
yyyy-MM-dd��  5A       6)     $! Client.Properties.Resources��$ FinancialAccount�� 5B   )   �� *FinancialAccount.Name+  5C      $ 付款方式��6)    5D   )   �� *PaymentMean.Name+  5E      $ 备注��6)    5F   )   �� *Description+4  .System.Windows.Controls.DataGridTemplateColumn  5G       	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5H   -    	  CanUserSort .     CellTemplate# [ 5I   -    5G   -     $! Client.Properties.Resources��$ 	Operation��5J      5L      5M      5N      5O      