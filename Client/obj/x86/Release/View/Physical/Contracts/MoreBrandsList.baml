   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 3    -Client.View.Physical.Contracts.MoreBrandsList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity       � Title$  多品牌明细��$	��301��$	��379��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��label1��$��多品牌列表��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Left=�$��6,40,0,0q�$   HorizontalScrollBarVisibility$
 Auto=�$
��Auto��   
IsReadOnly . $
��Auto��$	��Top=����� *QuotaBrandRels+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    Header 0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ Brand��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *
Brand.Name+  $
 Auto    $! Client.Properties.Resources��$ Specification��	 �� *Specification.Name+  $
 Auto    $! Client.Properties.Resources��$ Price��	 �� *Price+$  DBEntity.EnumEntity.RoundRules
   	STR_PRICE �� StringFormat# Z
   $
 Auto    $! Client.Properties.Resources��$ Quantity��	 �� *
Quantity+   STR_QUANTITY# Z   $
 Auto    $! Client.Properties.Resources��$ 	Warehouse��	 �� *Warehouse.Name+