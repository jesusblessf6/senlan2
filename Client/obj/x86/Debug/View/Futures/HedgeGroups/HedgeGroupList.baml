   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   H   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  6A   K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      4    .Client.View.Futures.HedgeGroups.HedgeGroupList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   H   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     6A   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$3  -Client.View.Futures.HedgeGroups.ResHedgeGroup��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5           ResxName$! Client.Properties.Resources��
   Key$ 
HedgeGroup�� � 	Resources 5         HedgeGroupLink  HedgeGroupEdit  HedgeGroupDelete1   +Client.Converters.HedgeGroupStatusConverter  hgsConverter.   (Client.Converters.ArbitrageTypeConverter  ArbitrageTypeConverter��%�   &	        &	      &	 &     &	 9     &	 L     �� 5   
   61   �� 5   
   61   �� 5   
   63     5   
   6=     5   
   6D   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6�     5   
   -   5        # [ 5      6�     5   
   -   5        # [ 5      6�   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5       �� -   5        $��lbTitle��5    Z   $��32��6j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     $! Client.Properties.Resources��$ 
HedgeGroup��6�   $  Utility.Controls.PagingControl  5!      -   5        $��pagingControl1��5!   L   $
��Left=�6   $��6,40,0,0q�6:   $	��Top=�6b   &   System.Windows.Controls.DataGrid  5"      -   5        $��	dataGrid1��5"   n      AutoGenerateColumns .  $
��Auto��63   $
��Left=�6A   $��6,77,0,0q�6\   $	��Top=�6   $
��Auto��6�   	   
IsReadOnly	 .   DataGridStyle#��[ 6�     DataGridRowStyle
   RowStyle#
 [ 6#  ��6�   �� *HedgeGroups+   Columns 5#      4  .System.Windows.Controls.DataGridTemplateColumn  5$      ,	  &System.Windows.Controls.DataGridColumn 	  CanUserSort .  	  SortMemberPath$
 Name��6    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 6�    	  Header 6-     $! Client.Properties.Resources��$
 Name��   CellTemplate 5%      �� 5&       �� DataType$ DBEntity:HedgeGroup��6+   .R�5'   "   �� �� 5(   &    �� Command# [  60    �� CommandParameter 6Z   �� *Id+.�6z   .�5)   *   �� �6.   �� *Name+6F   5*   '   5+   #   5,      5.      0  *System.Windows.Controls.DataGridTextColumn  5/       . $
 Auto
 6�    6'     $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ 	HedgeDate��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *	HedgeDate+ �� StringFormat$ {0:yyyy-MM-dd}��6�     50      $ 保值类型��6)    . $
 Auto
 6J    6W   �� *ArbitrageType+ �� 	Converter# [ 6�     51       . $
 Auto
 6�    6)     $! Client.Properties.Resources��$ ExchangeRate�� 6�   �� *Rate+$  DBEntity.EnumEntity.RoundRules   STR_RATE# Z 6�     52       . $
 Auto
 6�    6)     $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ SettlementStatus�� 6�   �� *Status+# [ 6�     53       . $
 Auto
 6y    6)     $! Client.Properties.Resources��$ PL�� 6�   �� *
PLAmount+   
STR_AMOUNT# Z 6�     54       . $
 Auto
 6�    6)     $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ 
PLCurrency�� 6�   �� *PLCurrency.Name+6�     55      $ 保本基差��6)   $
 Auto
 67    .  6W   �� *StopLossSpread+# Z 6�     56       .  $
 Auto
 6�    6-     $! Client.Properties.Resources��$ 	Operation�� 57      �� 58      $ DBEntity:HedgeGroup��6+   .R�59   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5:   &   �� #��[ 6m   ��6-     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6�   �� 5;   &   #��[ 6o   ��6-     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6�   5<   #   5=      5?      5A      5B      5C      5D      