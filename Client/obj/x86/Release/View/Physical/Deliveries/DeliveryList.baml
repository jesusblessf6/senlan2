   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 2   ,Client.View.Physical.Deliveries.DeliveryList   6my/clr-namespace:Utility.Controls;assembly=Utility  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *DeliveryList+ � 	Resources +  %Client.Converters.VisibilityConverter   VisibilityConverter*  $Client.Converters.TradeTypeConverter  TradeTypeConverter-  'Client.Converters.DeliveryTypeConverter  DeliveryTypeConverter+  %Client.Converters.IsVerifiedConverter  IsVerifiedConverter  DeliveryEdit  DeliveryPrint  DeliveryLineDelete  ShowCirculDetail 
 MDView 	 DeliveryActions �� DataType �� Orientation   ResxName
   Key 
 DeliveryLineActions 
 dgCell �� 
TargetType	 �� Property
 �� Value��%*  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     7  &	
 �     7  &	 �            �� �� �� �� �� �� $ DBEntity:Delivery��.R��� $ 
Horizontal=�.+��� $��btDeliveryEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $ DBEntity:DeliveryLine��.R��� $ 
Horizontal=�$��Center=�.+��� $��btDeliveryLinedelete��8��  ��  $! Client.Properties.Resources��$ Nullify������ *Id+�� " ��.��� 	 � ��$
 Center=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -    �Name$ rootGrid��.+��� -    ��Name$ lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(����� *Title+�� $ 
Horizontal=�$��6,40,0,0q�$
��Auto��$	��Top=�$
��Left=�$
��Auto��.+�$   Utility.Controls.PagingControl  -     Name$ pagerDelivery��$
��Left=�$	��Top=��� $��实际数量��
���  ��$��10,0,0,0q�$��Center=��� $��10,0,0,0q�$��Center=����� *TotalVerifiedQty+�� -	   $��打印提单��$��10,0,0,0q�$��23��y��� *IsPrintControlsVisible+&	   System.Windows.Controls.DataGrid	  -
    	 Name$ deliveryGrid��$��6,77,0,0q� 	  AutoGenerateColumns .   	  CanUserAddRows .    DataGridStyle#��[   DataGridRowStyle 	  RowStyle# [ $
��Left=�$	��Top=� 	  RowDetailsVisibilityMode$ Visible=�����  	  Columns 4
  .System.Windows.Controls.DataGridTemplateColumn
  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    
IsReadOnly .    Header �� -   $��cbSelectAll��$��全选��$��Center=�$��Center=� d� 	IsChecked �� *IsSelectAll+y��� *IsPrintControlsVisible+ 
  CellTemplate �� $ DBEntity:Delivery��.R��� $��Center=�$��Center=� �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *	Printable+y��� *IsPrintControlsVisible+0  *System.Windows.Controls.DataGridTextColumn   . 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [    $! Client.Properties.Resources��$ QuotaNo��   Binding �� *Quota.QuotaNo+   . # [    $! Client.Properties.Resources��$ Price�� �� *Quota.FinalPrice+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z    . # [    $! Client.Properties.Resources��$ BP�� �� **(Quota.Contract.BusinessPartner.ShortName+
  $ 	单据号��  DataGridColumnHeaderStyle    HeaderStyle#  [ !   SortMemberPath$! 
DeliveryNo��"   CanUserSort" .  �� $ DBEntity:Delivery��.R��� $��Center=�.+��� y��� *IsTD+# �� 	Converter## [  �� $ �� Command#$ [ % �� CommandParameter% �� *Id+.�.��� ��� *DeliveryNoStr+& �� Mode$& OneWay=��� y��� *IsMD+## [  �� ��� *
DeliveryNo+   . $ 单据类型��# [  �� *DeliveryType+## [    . # [    $! Client.Properties.Resources��$
 Date�� �� *	IssueDate+$ 
yyyy-MM-dd��   . # [    $! Client.Properties.Resources��$ 	Commodity�� �� *Quota.Commodity.Name+   . # [    $1 +Client.View.Physical.Deliveries.ResDelivery��$ 
CargoOwner�� �� *+)Quota.Contract.InternalCustomer.ShortName+   . # [    $! Client.Properties.Resources��$ 	Warehouse�� �� *Warehouse.Name+   . # [    $! Client.Properties.Resources��$ 	TradeType�� �� *Quota.Contract.TradeType+## [    . # [    $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+## [ 
   . $ 流转标识号�� �� $ DBEntity:Delivery��.R��� $��Center=��� #$ [ % �� *
CirculNo+.�.��� ��� *
CirculNo+
  $ 流转信息��$
 Auto '   
Visibility$' Hidden=�#  [  �� .R��� $
��Wrap=�$	��300��$��Center=����� *Quota.RelQuotaStr+
   . $
 Auto " .  # [	    $! Client.Properties.Resources��$ 	Operation��( 	  RowDetailsTemplate( �� $ DBEntity:Delivery��.R�	  $��dataGridDetail�� .   .  ) 	  
IsReadOnly) . $��6,2,0,15q����� *DeliveryLines+      $! Client.Properties.Resources��$ CommodityType�� �� *CommodityType.Name+     $! Client.Properties.Resources��$ Specification�� �� *Specification.Name+     $! Client.Properties.Resources��$ Brand�� �� *
Brand.Name+     $! Client.Properties.Resources��$ CardNo�� �� *PBNo+     $! Client.Properties.Resources��$ 	NetWeight�� �� *	NetWeight+*   STR_QUANTITY# Z*      $! Client.Properties.Resources��$ GrossWeight�� �� *GrossWeight+# Z*      $1 +Client.View.Physical.Deliveries.ResDelivery��$ ActualWeight�� �� *VerifiedWeight+# Z*      $! Client.Properties.Resources��$ Bundle�� �� *PackingQuantity+# Z*      $! Client.Properties.Resources��$ QuantityConfirm�� �� *
IsVerified+## [ 
  $
 Auto " .  # [
    $! Client.Properties.Resources��$ 	Operation��