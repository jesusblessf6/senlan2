   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 4    .Client.View.Futures.HedgeGroups.HedgeGroupList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$3  -Client.View.Futures.HedgeGroups.ResHedgeGroup�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ 
HedgeGroup�� � 	Resources    HedgeGroupLink  HedgeGroupEdit  HedgeGroupDelete1   +Client.Converters.HedgeGroupStatusConverter  hgsConverter.   (Client.Converters.ArbitrageTypeConverter  ArbitrageTypeConverter��%K   &	        &	      &	 
     &	      &	      �� �� ��      J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  $! Client.Properties.Resources��$ 
HedgeGroup��$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��6,40,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,77,0,0q�$	��Top=�$
��Auto��	   
IsReadOnly	 .   DataGridStyle#��[   DataGridRowStyle
   RowStyle#
 [ ���� *HedgeGroups+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn 	  CanUserSort .  	  SortMemberPath$
 Name�� 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
  	  Header   $! Client.Properties.Resources��$
 Name��   CellTemplate ��  �� DataType$ DBEntity:HedgeGroup��.R��� ��  �� Command# [   �� CommandParameter �� *Id+.�.��� ��� *Name+0  *System.Windows.Controls.DataGridTextColumn   . $
 Auto
    $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ 	HedgeDate��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	HedgeDate+ �� StringFormat$ {0:yyyy-MM-dd}��  $ 保值类型�� . $
 Auto
  �� *ArbitrageType+ �� 	Converter# [    . $
 Auto
    $! Client.Properties.Resources��$ ExchangeRate�� �� *Rate+$  DBEntity.EnumEntity.RoundRules   STR_RATE# Z    . $
 Auto
    $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ SettlementStatus�� �� *Status+# [    . $
 Auto
    $! Client.Properties.Resources��$ PL�� �� *
PLAmount+   
STR_AMOUNT# Z    . $
 Auto
    $3 -Client.View.Futures.HedgeGroups.ResHedgeGroup��$ 
PLCurrency�� �� *PLCurrency.Name+  $ 保本基差��$
 Auto
  .  �� *StopLossSpread+# Z    .  $
 Auto
    $! Client.Properties.Resources��$ 	Operation�� �� $ DBEntity:HedgeGroup��.R���  �� Orientation$ 
Horizontal=�.+��� #��[ ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� #��[ ��  $! Client.Properties.Resources��$ Delete������ *Id+