   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   Q   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      /   )Client.View.Futures.SHFE.SHFEPositionList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   Q   6
Convertersclr-namespace:Client.Converters     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$&   Client.View.Futures.SHFE.ResSHFE��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *
SHFEList+ � 	Resources 5      2  ,Client.Converters.PositionDirectionConverter   PositionDirectionConverter2  ,Client.Converters.PositionOpenCloseConverter  PositionOpenCloseConverter-  'Client.Converters.PositionTypeConverter  PositionTypeConverter  PositionView  ViewPosition �� DataType �� Orientation   ResxName
   Key��%s  &	        &	      &	 &     &	 9     &	 L     7    5   
   60     5   
   60     5   
   6+   �� 5   
   6/   �� 5   
   $ DBEntity:SHFEPosition��6,   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btPositionView��6   8��  ��6/     $! Client.Properties.Resources��$
 View����5      �� *Id+6;   5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [ 5      5   ;   .��5!      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5"      .��5#   
   � -   5        
 �Name$
 rootGrid��5#      .+�5$      $   Utility.Controls.PagingControl  -   5          Name$ pager��5%      $
��Left=�5$      $��6,40,0,0q�6:   $	��Top=�6L   5%      &   System.Windows.Controls.DataGrid  5&      -   5        $��dataGridPosition��5'   )      AutoGenerateColumns .  $
��Auto��5&   3   $
��Left=�6A     DataGridStyle#��[ 6u     DataGridRowStyle   RowStyle# [ 6�   $��6,77,0,0q�5'      $	��Top=�6A   $
��Auto��6Y      CanUserAddRows .     
IsReadOnly .  � DataContext 5&   \   ��    Columns 5)      0	  *System.Windows.Controls.DataGridTextColumn	  5*      ,
  &System.Windows.Controls.DataGridColumn 
  Header 6)     $! Client.Properties.Resources��$ SHFEContract��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6p   �� *Alias+	  5+       6)     $! Client.Properties.Resources��$ 	Commodity�� 6m   �� *Commodity.Name+	  5,       6)     $! Client.Properties.Resources��$ 	TradeDate�� 5-   )   �� *SHFECapitalDetail.TradeDate+ �� StringFormat$ 
yyyy-MM-dd��	  5.       6)     $! Client.Properties.Resources��$	 Lot�� 6g   �� *LotQuantity+$  DBEntity.EnumEntity.RoundRules   STR_INTEGER# Z 	  5/       6)     $! Client.Properties.Resources��$ Price�� 6i   �� *Price+   	STR_PRICE# Z 	  50       6)     $! Client.Properties.Resources��$ 	Direction�� 51   )   �� *PositionDirection+ �� 	Converter# [  	  52       6)     $! Client.Properties.Resources��$ 	OpenClose�� 53   )   �� *	OpenClose+# [ 	  54       6)     $! Client.Properties.Resources��$ PositionType�� 55   )   �� *PositionType+# [ 	  56       6)     $! Client.Properties.Resources��$ Broker�� 6j   �� *-+SHFECapitalDetail.BusinessPartner.ShortName+	  57       6)     $! Client.Properties.Resources��$ InternalCustomer�� 6t   �� *.,SHFECapitalDetail.BusinessPartner1.ShortName+	  58       6)     $! Client.Properties.Resources��$ 
Commission�� 6n   �� *
Commission+   
STR_AMOUNT# Z 	  59       6)     $! Client.Properties.Resources��$ ClosePL�� 6k   �� *PNL+# Z 4  .System.Windows.Controls.DataGridTemplateColumn  5:         CellTemplate# [ 6-    
  CanUserSort .   6Z     $! Client.Properties.Resources��$ 	Operation��5<      5>      �� 5?      -   5        $��lbTitle��5?   .   $��32��6=   $
��Left=�6I   $��6,6,0,0q�6d   $
��auto��5@      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5?        *
SHFEList+5@   K   5A      5B      5C      