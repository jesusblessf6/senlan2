   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      5clr-namespace:Client.ConvertersClient.Converters  5      <    6Client.View.Physical.Deliveries.DeliveryListOfSameFlow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5base$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      -cclr-namespace:Client.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	        � Title$  提单流转明细��5      $	��500��6!   $
��Auto��61    � WindowStartupLocation$ CenterScreen=�6>    � SizeToContent$ WidthAndHeight=�5
   &    � 	Resources 5      /   )Client.Converters.LineType2ColorConverter   LineTypeConverter  	LineStyle �� 
TargetType �� Property �� Value �� 	Converter��%�   &	        &	      7     5   
   6@   �� 5   
   " ��6"   .�5      ��  � �� 6+   �� *
LineType+8   6v   5      5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   ]   $��提单流转明细��6   $��31��6%   $
��Left=�61   $��6,6,0,0q�6L   $��16(�6l   $
��Bold"�5      $	��Top=�5      &   System.Windows.Controls.DataGrid  5      -   5        $��	dataGrid1��5         AutoGenerateColumns .  $
��Auto��5   3   $
��Left=�6A   $��6,43,0,0q�6\   $	��Top=�5   (   $
��Auto��6@   	   
IsReadOnly	 . ��6_   �� 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5   <   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5   )      Header 5   )   0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ FlowId��5        5        . $
 Auto 5!   <   # [ 5"   H    5    )     $# Client.View.Reports.ResReport��$ 
DocumentNo��   Binding 5"   )   �� *
DeliveryNo+5#        5$       . $
 Auto 5%   <   # [ 5&   J    5$   )     $! Client.Properties.Resources��$ DocumentType�� 5&   )   �� *DeliveryType+5'        5(       . $
 Auto 5)   <   # [ 5+   )    5(   )     $# Client.View.Reports.ResReport��$ PurchaseDate�� 5*   )   �� *	BuyDate+ �� StringFormat$ 
yyyy-MM-dd��5,        5-       . $
 Auto 5.   <   # [ 5/   G    5-   )     $! Client.Properties.Resources��$ Buyer�� 5/   )   �� *	BuyBPName+50        51       . $
 Auto 52   <   # [ 54   )    51   )     $# Client.View.Reports.ResReport��$ 	SalesDate�� 53   )   �� *
SellDate+$ 
yyyy-MM-dd��55        56       . $
 Auto 57   <   # [ 58   H    56   )     $! Client.Properties.Resources��$ Supplier�� 58   )   �� *
SellBPName+59        5:       . $
 Auto 5;   <   # [ 5<   )    5:   )     $! Client.Properties.Resources��$ 	Commodity�� 5;   I   �� *CommodityName+5=        5>       . $
 Auto 5?   <   # [ 5@   G    5>   )     $! Client.Properties.Resources��$ Brand�� 5@   )   �� *	BrandName+5A        5B       . $
 Auto 5C   <   # [ 5E   )    5B   )     $! Client.Properties.Resources��$ 	NetWeight�� 5D   )   �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY# Z 5F        5G       . $
 Auto 5H   <   # [ 5J   )    5G   )     $! Client.Properties.Resources��$ GrossWeight�� 5I   )   �� *GrossWeight+# Z 5K        5L       . $
 Auto 5M   <   # [ 5N   C    5L   )     $# Client.View.Reports.ResReport��$ LoCInfo�� 5N   )   �� *LCMsg+5O       �� 
GroupStyle 5Q      (	  "System.Windows.Controls.GroupStyle	  5R        GroupHerderStyle 	  ContainerStyle# [ 6!    	  Panel 5S      �� 5T      .R�5U   "   >
  8System.Windows.Controls.Primitives.DataGridRowsPresenter
  5V      5X         RowStyle 5Z      �� 5[      )  #System.Windows.Controls.DataGridRow"  6   .�5\      ��  � ��
 �����67    �� Triggers 5]      P� 5^       P� Property �@ 
IsSelected P� Value . . �5_   "   ��  � ��
 ����6?   �� 5`   "    � ��
 ����6?   5a      5c         	CellStyle 5e      �� 5f      *  $System.Windows.Controls.DataGridCell"  6    5g      P� 5h       �@ 
IsSelected . . �5i   "   ��  � ��
 ����6?   �� 5j   "    � ��
 ����6?   5k      5m      5o      5p      5q      5r      