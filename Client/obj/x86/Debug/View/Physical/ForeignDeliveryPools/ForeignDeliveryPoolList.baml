   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5
      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      G    AClient.View.Physical.ForeignDeliveryPools.ForeignDeliveryPoolList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5base$clr-namespace:Client.Base.BaseClient     5      -cclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5
      =dbEntity(clr-namespace:DBEntity;assembly=DBEntity     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5        N� Title$  外贸提单列表��5
       � 	Resources 5      -   'Client.Converters.DeliveryTypeConverter   DeliveryTypeConverter  FDPEdit  	FDPDelete��%W   &	        &	      &	 &       5   
   6"   �� 5   
   6*   �� 5   
   6,   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6z     5   
   -   5        # [ 5      6�   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   ]   $��外贸提单列表��6   $��32��6%   $
��Left=�61   $��6,6,0,0q�6L   $	��Top=�6l   $��16(�5      $
��Bold"�6"   $  Utility.Controls.PagingControl  5      -   5        $��pager��5   L   $
��Left=�6   $��6,44,0,0q�6:   $	��Top=�6Y   &   System.Windows.Controls.DataGrid  5      -   5        $��
entityList��5          AutoGenerateColumns .  $
��Auto��5   3      
IsReadOnly . $
��Left=�6S   $��6,81,0,0q�6n   $	��Top=�5    A   $
��Auto��6Y      RowDetailsVisibilityMode$ Visible=�5!      ��5    )   ��    Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header 6)   0  *Infralution.Localization.Wpf.ResxExtension  	   ResxName$!	 Client.Properties.Resources��

   Key$

 BLNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6h   �� *
DeliveryNo+  5$      $ 	标识号��6)    66   �� *MarkNo+6S     5%       6)     $!	 Client.Properties.Resources��$
 BLType�� 5&   )   �� *DeliveryType+ �� 	Converter# [    5'       6)     $!	 Client.Properties.Resources��$

 Date�� 6h   �� *	IssueDate+ �� StringFormat$ 
yyyy-MM-dd��  5(       6)     $!	 Client.Properties.Resources��$
 	Commodity�� 6m   �� *Commodity.Name+  5)       6)     $!	 Client.Properties.Resources��$
 	Warehouse�� 6m   �� *Warehouse.Name+4	  .System.Windows.Controls.DataGridTemplateColumn	  5*         Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 6q      CanUserSort .   6-     $!	 Client.Properties.Resources��$
 	Operation�� 	  CellTemplate 5+      �� 5,       �� DataType$" dbEntity:ForeignDeliveryPool��6+   .R�5-   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5.   &   �� $��编辑��6-   #��[ 6:   ��6]   �� *Id+6   �� 5/   &   $��删除��6-   #��[ 6:   ��6_   �� *Id+6�   50   #   51      53         RowDetailsTemplate 55      �� 56      $" dbEntity:ForeignDeliveryPool��6#   .R�57        $��dataGridDetail��6#    .     CanUserAddRows .   . $��6,2,0,15q�58   h   ��57   9   �� *ForeignDeliveryPoolLines+ 59        5:   "    65     $!	 Client.Properties.Resources��$
 CommodityType�� 6}   �� *CommodityType.Name+  5;   "    65     $!	 Client.Properties.Resources��$
 Specification�� 6}   �� *Specification.Name+  5<   "    65     $!	 Client.Properties.Resources��$
 Brand�� 6u   �� *
Brand.Name+  5=   "    65     $!	 Client.Properties.Resources��$
 CardNo�� 6v   �� *PBNo+  5>   "    65     $!	 Client.Properties.Resources��$
 	NetWeight�� 6y   �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z   5?   "    65     $!	 Client.Properties.Resources��$
 GrossWeight�� 6{   �� *GrossWeight+# Z   5@   "    65     $!	 Client.Properties.Resources��$
 Bundle�� 6v   �� *PackingQuantity+# Z 5B      5C      5E      5F      5G      5H      