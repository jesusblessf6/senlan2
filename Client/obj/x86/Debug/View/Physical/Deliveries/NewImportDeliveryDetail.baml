   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5	      5clr-namespace:Client.ConvertersClient.Converters 5
      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5      =   7Client.View.Physical.Deliveries.NewImportDeliveryDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      6
Convertersclr-namespace:Client.Converters     5
      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$1  +Client.View.Physical.Deliveries.ResDelivery��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *ImportDelivery+ � 	Resources 5      -  'Client.Converters.DeliveryTypeConverter   DeliveryTypeConverter �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker  DeliveryDelete  DeliveryEdit  DeliveryActions �� DataType �� Orientation	   ResxName

   Key��%;  &	        '��      '�� �     '�� -    '  �    &	     &	 .    &	 A    7  7    5   
   6+   �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5       �� 5"   
   "  6   .�5#      ��  � ��$ 23��6'   64   �� 5$       � ��$	 120��6&   64   5%      �� 5'   
   61   �� 5(   
   6/   �� 5*   
   $ DBEntity:Delivery��6/   .R�5+      �� $ 
Horizontal=�6   .+�5,      �� $��btDeliveryDelete��6   8��  ��61     $!	 Client.Properties.Resources��$
 Delete����5-      �� *Id+6;   �� 5.      $��btDeliveryEdit��6   8�� ��6/     $!	 Client.Properties.Resources��$

 Edit��{�6�   �� *CanEditEnable+��5/      �� *ProvisionalID+6F   50      51      52       J� CommandBindings 53      )  #System.Windows.Input.CommandBinding  54   
   -   5           Command# [ 54      55   =     56   
   -   5        # [ 56      57   ;   .��59      � -   5         �Name$ rootGrid��59      .+�5:   
   �� -   5         ��Name$ lbTitle��5:      $
��Left=�6!   $��6,6,0,0q�6<   $��16(�6M   $
��auto��5;      $
��Bold"�6!   $��32��63   $	��Top=�6?   ��6W   �� *Title+�� 5<   
   -   5        $��label1��5<      $
��Left=�6   $��6,70,0,0q�69   $	��Top=�6K   
���<����5=   )     $!	 Client.Properties.Resources��$
 Quota��6l   �� 5>   
   -   5         ��Name$ 
tbCustomer��5>      $
��Left=�6&   $	��Top=�6A   {�.  $��
122,72,0,0q�5?   (   ��5>   Y   �� *	QuotaNo+5?   (   �� 5@   
   -   5        $��btnOrderLine��5@   6   $	��...��6   $��23��6   $��25��6+   $
��Left=�5A      $��
246,72,0,0q�60   $	��Top=�6D   {�6\   �� *IsQuotaEnable+ � ToolTip 6�   �� *ContractInfo+�� 5B   
   $
��Left=�6   $��
278,70,0,0q�6+   $	��Top=�6?   
���<����6l   �� *	lbContent+6�   �� 5C   
   -   5        $��tbDeliveryNo��5C      $
��Left=�6&   $	��Top=�6A   $��
394,72,0,0q�5D      {�.  6*   �� 5E   
   -	   5        $��button2��5E   �   $	��...��6   $��23��6   $
��Left=�6+   $��
518,71,0,0q�6m   $	��Top=�6�   $��25��6�   {�6F   �� *IsPoolNoBtnEnale+6�   �� 5G   
   -
   5        $��label8��5G   �   $
��Left=�6R   $��	6,104,0,0q�6m   $	��Top=�5H      $��4��6,   ��5G        $!	 Client.Properties.Resources��$
 Detail��5H   ,   &   System.Windows.Controls.DataGrid  5I   
   -   5        $��dataGridDeliveryLines��5I   C      CanUserSortColumns .  $��122,106,0,0q�6.      CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�5J   t   $	��410��6�   $
��auto��5K      $	��Top=�6$   ��5J   .   ��    Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5M      ,  &System.Windows.Controls.DataGridColumn   Header$ 	单据号��6%   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 62   �� *
DeliveryNo+  5N      $ 开具日期��6%    63   �� *	IssueDate+ �� StringFormat$ 
yyyy-MM-dd��  5O      $ 仓库��6%    61   �� *WarehouseName+  5P      $ 类型��6%    61   �� *DeliveryType+ �� 	Converter# [    5Q      $ 金属类型��6%    63   �� *CommodityTypeName+  5R      $ 品牌��6%    61   �� *	BrandName+  5S       6%     $!	 Client.Properties.Resources��$
 	NetWeight�� 6i   �� *TotalNetWeight+$
   DBEntity.EnumEntity.RoundRules 
  STR_QUANTITY# Z   5T       6%     $!	 Client.Properties.Resources��$
 GrossWeight�� 6k   �� *TotalGrossWeight+# Z   5U       6%     $!	 Client.Properties.Resources��$
 Bundle�� 6f   �� *TotalPackingQty+# Z   5V       6%     $!	 Client.Properties.Resources��$
 Comments�� 6h   �� *	Comment+4  .System.Windows.Controls.DataGridTemplateColumn  5W         CanUserSort .     CellTemplate# [ 5X   -    5W   )     $!	 Client.Properties.Resources��$
 	Operation��5X   -   5Z      �� 5[   
   -   5        $��246,540,0,0q�5[   Q   $
��Left=�5\      $	��Top=�60   $��60��6H   $��25��6`   ��5[        $!	 Client.Properties.Resources��$

 Save��5\   `   �� 5]   
   -   5        $��341,540,0,0q�5]   S   $��60��6�   $
��Left=�5^      $	��Top=�60   $��25��6W   ��5]        $!	 Client.Properties.Resources��$
 Cancel��5^   W   5_      5`      