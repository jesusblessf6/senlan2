   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5   	   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5   	   3    -Client.View.Physical.Contracts.MoreBrandsList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;
baseClient$clr-namespace:Client.Base.BaseClient     5   	   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5   	     � Title$  多品牌明细��5   	   $	��301��6   $	��379��6$   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5	      �� -   5        $��label1��5	   \   $��多品牌列表��6   $��28��6$   $
��Left=�60   $��6,6,0,0q�6K   $	��Top=�6j   $
��Bold"�6�   $��16(�6�   &   System.Windows.Controls.DataGrid  5
      -   5        $��	dataGrid1��5
   `      AutoGenerateColumns .  $
��Left=�63   $��6,40,0,0q�6N   $   HorizontalScrollBarVisibility$
 Auto=�6�   $
��Auto��6�      
IsReadOnly . $
��Auto��6�   $	��Top=�6�   ��6q   �� *QuotaBrandRels+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6i      Header 6)   0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ Brand��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6v   �� *
Brand.Name+6�     5      $
 Auto 6q    6)     $! Client.Properties.Resources��$ Specification��	 6~   �� *Specification.Name+6�     5      $
 Auto 6i    6)     $! Client.Properties.Resources��$ Price��	 6v   �� *Price+$  DBEntity.EnumEntity.RoundRules
   	STR_PRICE �� StringFormat# Z
 6�     5      $
 Auto 6l    6)     $! Client.Properties.Resources��$ Quantity��	 6y   �� *
Quantity+   STR_QUANTITY# Z 6�     5      $
 Auto 6m    6)     $! Client.Properties.Resources��$ 	Warehouse��	 6z   �� *Warehouse.Name+6�   5      5      5      5      