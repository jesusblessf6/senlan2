   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity /   )Client.View.Futures.SHFE.SHFEPositionList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$&   Client.View.Futures.SHFE.ResSHFE�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *
SHFEList+ � 	Resources 2  ,Client.Converters.PositionDirectionConverter   PositionDirectionConverter2  ,Client.Converters.PositionOpenCloseConverter  PositionOpenCloseConverter-  'Client.Converters.PositionTypeConverter  PositionTypeConverter  PositionView  ViewPosition �� DataType �� Orientation   ResxName
   Key��%�   &	        &	      &	 
     &	      &	      7        �� �� $ DBEntity:SHFEPosition��.R��� $ 
Horizontal=�.+��� $��btPositionView��8��  ��  $! Client.Properties.Resources��$
 View������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -   
 �Name$
 rootGrid��.+�$   Utility.Controls.PagingControl  -     Name$ pager��$
��Left=�$��6,40,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��dataGridPosition��   AutoGenerateColumns .  $
��Auto��$
��Left=�  DataGridStyle#��[   DataGridRowStyle   RowStyle# [ $��6,77,0,0q�$	��Top=�$
��Auto��   CanUserAddRows .     
IsReadOnly .  � DataContext ��    Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header   $! Client.Properties.Resources��$ SHFEContract��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Alias+	     $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+	     $! Client.Properties.Resources��$ 	TradeDate�� �� *SHFECapitalDetail.TradeDate+ �� StringFormat$ 
yyyy-MM-dd��	     $! Client.Properties.Resources��$	 Lot�� �� *LotQuantity+$  DBEntity.EnumEntity.RoundRules   STR_INTEGER# Z 	     $! Client.Properties.Resources��$ Price�� �� *Price+   	STR_PRICE# Z 	     $! Client.Properties.Resources��$ 	Direction�� �� *PositionDirection+ �� 	Converter# [  	     $! Client.Properties.Resources��$ 	OpenClose�� �� *	OpenClose+# [ 	     $! Client.Properties.Resources��$ PositionType�� �� *PositionType+# [ 	     $! Client.Properties.Resources��$ Broker�� �� *-+SHFECapitalDetail.BusinessPartner.ShortName+	     $! Client.Properties.Resources��$ InternalCustomer�� �� *.,SHFECapitalDetail.BusinessPartner1.ShortName+	     $! Client.Properties.Resources��$ 
Commission�� �� *
Commission+   
STR_AMOUNT# Z 	     $! Client.Properties.Resources��$ ClosePL�� �� *PNL+# Z 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [  
  CanUserSort .     $! Client.Properties.Resources��$ 	Operation���� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *
SHFEList+