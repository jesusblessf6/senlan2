   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity G    AClient.View.Physical.ForeignDeliveryPools.ForeignDeliveryPoolList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5base$clr-namespace:Client.Base.BaseClient     -cclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =dbEntity(clr-namespace:DBEntity;assembly=DBEntity     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity       N� Title$  外贸提单列表�� � 	Resources -   'Client.Converters.DeliveryTypeConverter   DeliveryTypeConverter  FDPEdit  	FDPDelete��%-   &	        &	      &	 
       �� ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��外贸提单列表��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$��16(�$
��Bold"�$  Utility.Controls.PagingControl  -   $��pager��$
��Left=�$��6,44,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��
entityList��   AutoGenerateColumns .  $
��Auto��   
IsReadOnly . $
��Left=�$��6,81,0,0q�$	��Top=�$
��Auto��   RowDetailsVisibilityMode$ Visible=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header 0  *Infralution.Localization.Wpf.ResxExtension  	   ResxName$!	 Client.Properties.Resources��

   Key$

 BLNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
DeliveryNo+     $!	 Client.Properties.Resources��$
 BLType�� �� *DeliveryType+ �� 	Converter# [       $!	 Client.Properties.Resources��$

 Date�� �� *	IssueDate+ �� StringFormat$ 
yyyy-MM-dd��     $!	 Client.Properties.Resources��$
 	Commodity�� �� *Commodity.Name+     $!	 Client.Properties.Resources��$
 	Warehouse�� �� *Warehouse.Name+4	  .System.Windows.Controls.DataGridTemplateColumn	     Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
    CanUserSort .     $!	 Client.Properties.Resources��$
 	Operation�� 	  CellTemplate ��  �� DataType$" dbEntity:ForeignDeliveryPool��.R���  �� Orientation$ 
Horizontal=�.+��� $��编辑��#��[ ���� *Id+�� $��删除��#��[ ���� *Id+   RowDetailsTemplate �� $" dbEntity:ForeignDeliveryPool��.R�  $��dataGridDetail�� .     CanUserAddRows .   . $��6,2,0,15q����� *ForeignDeliveryPoolLines+      $!	 Client.Properties.Resources��$
 CommodityType�� �� *CommodityType.Name+     $!	 Client.Properties.Resources��$
 Specification�� �� *Specification.Name+     $!	 Client.Properties.Resources��$
 Brand�� �� *
Brand.Name+     $!	 Client.Properties.Resources��$
 CardNo�� �� *PBNo+     $!	 Client.Properties.Resources��$
 	NetWeight�� �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z      $!	 Client.Properties.Resources��$
 GrossWeight�� �� *GrossWeight+# Z      $!	 Client.Properties.Resources��$
 Bundle�� �� *PackingQuantity+# Z 