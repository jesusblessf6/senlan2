   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6I   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      2   ,Client.View.Physical.Deliveries.DeliveryList   5      6my/clr-namespace:Utility.Controls;assembly=Utility  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6I   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   Q     *DeliveryList+ � 	Resources 5      +  %Client.Converters.VisibilityConverter   VisibilityConverter*  $Client.Converters.TradeTypeConverter  TradeTypeConverter-  'Client.Converters.DeliveryTypeConverter  DeliveryTypeConverter+  %Client.Converters.IsVerifiedConverter  IsVerifiedConverter  DeliveryEdit  DeliveryPrint  DeliveryLineDelete  ShowCirculDetail 
 MDView 	 	ConvertWR 
 DeliveryActions �� DataType �� Orientation   ResxName
   Key  DeliveryLineActions 
 dgCell �� 
TargetType	 �� Property
 �� Value��%  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     7  7 	 &	 /    7  &	 ;      5   
   6)     5   
   6(     5   
   6+     5   
   6)   �� 5   
   6/   �� 5   
   60   �� 5   
   65   �� 5   
   63   �� 5   
   6)   �� 5   
   6,   �� 5   
   $ DBEntity:Delivery��6/   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btDeliveryEdit��6   8��  ��6/     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5       $��btDeliveryConvertWR��6   $��	转仓单��64   8�� ��5!      �� *Id+{�69   �� *CanConvertWR+6^   5"      5#      �� 5$   
   $ DBEntity:DeliveryLine��63   .R�5%      �� $ 
Horizontal=�6   $��Center=�62   .+�5&      �� $��btDeliveryLinedelete��6   8��  ��65     $! Client.Properties.Resources��$ Nullify����5'      �� *Id+6;   5(      5)      �� 5+   
   " ��6   .�5,      �� 	 � ��$
 Center=�62   5-      5/       J� CommandBindings 51      )  #System.Windows.Input.CommandBinding  52   
   -   5           Command# [ 52      53   ;     54   
   -   5        # [ 54      55   <     56   
   -   5        # [ 56      57   A     58   
   -   5        # [ 58      59   ?     5:   
   -   5        # [ 5:      5<        5=   
   -   5        # [	 5=      5?      .��5B      �� $
��Auto=�6   $
��Auto=�68   .��5C   
   � -   5         �Name$ rootGrid��5C      .+�5D      �� -   5         ��Name$ lbTitle��5D      $��32��6%   $
��Left=�61   $��6,6,0,0q�6L   $
��auto��6]   $	��Top=�5E      $
��Bold"�6,   $��16(�6>   ��6M   �� *Title+6i   �� 5G      $ 
Horizontal=�6   $��6,40,0,0q�62   $
��Auto��6D   $	��Top=�6R   $
��Left=�6j   $
��Auto��6�   .+�5H      $   Utility.Controls.PagingControl  -	   5          Name$ pagerDelivery��5H   #   $
��Left=�6;   $	��Top=�6V   �� 5I      $��实际数量��6   
���  ��$��10,0,0,0q�68   $��Center=�6J   6n   �� 5J      $��10,0,0,0q�6=   $��Center=�6O   ��6   �� *TotalVerifiedQty+6s   �� 5K      -
   5        $��打印提单��5K      $��10,0,0,0q�6(   $��23��6|   y�6N   �� *IsPrintControlsVisible+6�   5L      &	   System.Windows.Controls.DataGrid	  5N      -   5         	 Name$ deliveryGrid��5N   )   $��6,77,0,0q�6    	  AutoGenerateColumns .   	  CanUserAddRows .    DataGridStyle#��[ 6r     DataGridRowStyle 	  RowStyle# [ 6�   $
��Left=�5O   S   $	��Top=�6n    	  RowDetailsVisibilityMode$ Visible=�6�   ��6;   ��  	  Columns 5P      4
  .System.Windows.Controls.DataGridTemplateColumn
  5Q      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6-      
IsReadOnly .    Header 5R      �� 5S      -   5        $��cbSelectAll��5S   I   $��全选��6\   $��Center=�6i   $��Center=�6�    d� 	IsChecked 6'   �� *IsSelectAll+y�6�   �� *IsPrintControlsVisible+6�    
  CellTemplate 5U      �� 5V      $ DBEntity:Delivery��6+   .R�5W   "   �� $��Center=�6�   $��Center=�6�    6+   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{�6q   �� *	Printable+y�6�   �� *IsPrintControlsVisible+6�   5X      5Z      0  *System.Windows.Controls.DataGridTextColumn  5\       . 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6�    6;     $! Client.Properties.Resources��$ QuotaNo��   Binding 6}   �� *Quota.QuotaNo+6�     5]       . # [ 6�    6;     $! Client.Properties.Resources��$ Price�� 6{   �� *Quota.FinalPrice+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z 6�     5^       . # [ 6�    6;     $! Client.Properties.Resources��$ BP�� 6x   �� **(Quota.Contract.BusinessPartner.ShortName+6�   
  5_      $ 	单据号��6-     DataGridColumnHeaderStyle    HeaderStyle#  [ 6:   !   SortMemberPath$! 
DeliveryNo��6s   "   CanUserSort" .  5`      �� 5a      $ DBEntity:Delivery��6+   .R�5b   "   �� $��Center=�6-   .+�5c   &   �� y�60   �� *IsTD+# �� 	Converter## [  �� 5d   &   $ �� Command#$ [ 60   % �� CommandParameter% 6R   �� *Id+.�6r   .�5e   *   �� �6.   �� *DeliveryNoStr+& �� Mode$& OneWay=�6\   5f   '   5g   '   �� 5h   &   y�60   �� *IsMD+## [  �� 5i   *   �6.   �� *
DeliveryNo+6L   5j   '   5k   #   5l      5n        5o       . $ 单据类型��6;   # [ 5p   |    6)   �� *DeliveryType+## [ 6|     5q       . # [ 6�    6;     $! Client.Properties.Resources��$
 Date�� 6z   �� *	IssueDate+$ 
yyyy-MM-dd��6�     5r       . # [ 6�    6;     $! Client.Properties.Resources��$ 	Commodity�� 6   �� *Quota.Commodity.Name+6�     5s       . # [ 6�    6;     $1 +Client.View.Physical.Deliveries.ResDelivery��$ 
CargoOwner�� 6�   �� *+)Quota.Contract.InternalCustomer.ShortName+6�     5t       . # [ 6�    6;     $! Client.Properties.Resources��$ 	Warehouse�� 6   �� *Warehouse.Name+6�     5u       . # [ 5v   �    5u   ;     $! Client.Properties.Resources��$ 	TradeType�� 5v   )   �� *Quota.Contract.TradeType+## [ 6�     5w       . # [ 6�    6;     $! Client.Properties.Resources��$ QuantityConfirm�� 6�   �� *
IsVerified+## [ 6�     5x      $ 	提单号��6)    66   �� *ConvertedTd.DeliveryNo+
  5y       . $ 流转标识号��6?    5z      �� 5{      $ DBEntity:Delivery��6+   .R�5|   "   �� $��Center=�6,   �� 5}   &   #$ [ 60   % 6\   �� *
CirculNo+.�6�   .�5~   *   �� �6.   �� *
CirculNo+6J   5   '   5�   #   5�      5�      
  5�      $ 流转信息��6-   $
 Auto 6;   '   
Visibility$' Hidden=�6H   #  [ 6]    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   $	��300��6@   $��Center=�6o   ��6L   �� *Quota.RelQuotaStr+6o   5�      5�      
  5�       . $
 Auto 6�   " .  # [
 5�   -    5�   ?     $! Client.Properties.Resources��$ 	Operation��5�   `   ( 	  RowDetailsTemplate( 5�      �� 5�      $ DBEntity:Delivery��6#   .R�5�      	  $��dataGridDetail��6#    .   .  ) 	  
IsReadOnly) . $��6,2,0,15q�5�   h   ��5�   9   �� *DeliveryLines+ 5�        5�   "    65     $! Client.Properties.Resources��$ CommodityType�� 6}   �� *CommodityType.Name+  5�   "    65     $! Client.Properties.Resources��$ Specification�� 6}   �� *Specification.Name+  5�   "    65     $! Client.Properties.Resources��$ Brand�� 6u   �� *
Brand.Name+  5�   "    65     $! Client.Properties.Resources��$ CardNo�� 6v   �� *PBNo+  5�   "    65     $! Client.Properties.Resources��$ 	NetWeight�� 6y   �� *	NetWeight+*   STR_QUANTITY# Z*   5�   "    65     $! Client.Properties.Resources��$ GrossWeight�� 6{   �� *GrossWeight+# Z*   5�   "    65     $1 +Client.View.Physical.Deliveries.ResDelivery��$ ActualWeight�� 6�   �� *VerifiedWeight+# Z*   5�   "    65     $! Client.Properties.Resources��$ Bundle�� 6v   �� *PackingQuantity+# Z*   5�   "    65     $! Client.Properties.Resources��$ QuantityConfirm�� 6   �� *
IsVerified+## [ 
  5�   "   $
 Auto 6}   " .  # [ 5�   9    5�   9     $! Client.Properties.Resources��$ 	Operation��5�   o   5�      5�      5�      5�      5�      5�      