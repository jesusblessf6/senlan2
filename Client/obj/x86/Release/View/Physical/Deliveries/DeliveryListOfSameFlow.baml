   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5clr-namespace:Client.ConvertersClient.Converters  <    6Client.View.Physical.Deliveries.DeliveryListOfSameFlow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5base$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     -cclr-namespace:Client.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  提单流转明细��$	��500��$
��Auto�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=� � 	Resources /   )Client.Converters.LineType2ColorConverter   LineTypeConverter  	LineStyle �� 
TargetType �� Property �� Value �� 	Converter��%R   &	        &	      7     �� " ��.���  � �� �� *
LineType+8   .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��提单流转明细��$��31��$
��Left=�$��6,6,0,0q�$��16(�$
��Bold"�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,43,0,0q�$	��Top=�$
��Auto��	   
IsReadOnly	 . ���� 
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [    Header 0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ FlowId��   . $
 Auto # [    $# Client.View.Reports.ResReport��$ 
DocumentNo��   Binding �� *
DeliveryNo+   . $
 Auto # [    $! Client.Properties.Resources��$ DocumentType�� �� *DeliveryType+   . $
 Auto # [    $# Client.View.Reports.ResReport��$ PurchaseDate�� �� *	BuyDate+ �� StringFormat$ 
yyyy-MM-dd��   . $
 Auto # [    $! Client.Properties.Resources��$ Buyer�� �� *	BuyBPName+   . $
 Auto # [    $# Client.View.Reports.ResReport��$ 	SalesDate�� �� *
SellDate+$ 
yyyy-MM-dd��   . $
 Auto # [    $! Client.Properties.Resources��$ Supplier�� �� *
SellBPName+   . $
 Auto # [    $! Client.Properties.Resources��$ 	Commodity�� �� *CommodityName+   . $
 Auto # [    $! Client.Properties.Resources��$ Brand�� �� *	BrandName+   . $
 Auto # [    $! Client.Properties.Resources��$ 	NetWeight�� �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z    . $
 Auto # [    $! Client.Properties.Resources��$ GrossWeight�� �� *GrossWeight+# Z    . $
 Auto # [    $# Client.View.Reports.ResReport��$ LoCInfo�� �� *LCMsg+ �� 
GroupStyle (	  "System.Windows.Controls.GroupStyle	    GroupHerderStyle 	  ContainerStyle# [  	  Panel �� .R�>
  8System.Windows.Controls.Primitives.DataGridRowsPresenter
     RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��
 ����� �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  � ��
 ������  � ��
 ����   	CellStyle �� *  $System.Windows.Controls.DataGridCell"   P�  �@ 
IsSelected . . ���  � ��
 ������  � ��
 ����