   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5clr-namespace:Client.ConvertersClient.Converters B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  8   2Client.View.Finance.LCAllocations.LCAllocationList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5base$clr-namespace:Client.Base.BaseClient     5	converterclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =dbEntity(clr-namespace:DBEntity;assembly=DBEntity       N� Title$  信用证分配列表�� � 	Resources    EditLCAllocation  DeleteLCAllocation  CancelLCAllocation,  &Client.Converters.BoolReverseConverter  BoolReverse��%<   &	        &	      &	 
     &	      �� �� ��    J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��label1��$��信用证分配列表��$��16(�$
��Bold"�$��32��$
��Left=�$��	10,10,0,0q�$	��Top=�$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��	28,48,0,0q�$	��Top=��� -   $��
textBlock1��$��23��$
��Left=�$��
552,56,0,0q�$	��Top=��� .�数量合计： �� ��� *QtySum+$   DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z  �� .�| �� .�金额合计： �� ��� *USDAmountSum+   
STR_AMOUNT# Z  �� .�USD / �� ��� *CNYAmountSum+# Z  �� .�CNY&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	28,85,0,0q�$	��Top=�$
��Auto��   
IsReadOnly . ���� 	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 询问日期��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *EnquireDate+$ {0:yyyy-MM-dd}��  $
 客户��$
 Auto  �� *BusinessPartner.ShortName+  $
 内部客户��$
 Auto  �� *InternalCustomer.ShortName+  $
 	开证行��$
 Auto  �� *IssueBankName+  $
 币种��$
 Auto  �� *Currency.Name+  $
 天数��$
 Auto  �� *Days+   STR_INTEGER# Z   $
 金属��$
 Auto  �� *Commodity.Name+  $
 数量��$
 Auto  �� *
Quantity+# Z   $
 金额��$
 Auto  �� *Amount+# Z   $
 报价��$
 Auto  �� *	Quotation+  $
 	承兑行��$
 Auto  �� *AcceptingBankName+  $
 	开证日��$
 Auto  �� *	IssueDate+$ {0:yyyy-MM-dd}��  $
 	贴现日��$
 Auto  �� *DiscountDate+$ {0:yyyy-MM-dd}��  $
 实际贴现利率��$
 Auto  �� *ActualDiscounting+  $
 	负责人��$
 Auto  �� *Responsor.Name+  $
 备注��$
 Auto  �� *
Comments+4
  .System.Windows.Controls.DataGridTemplateColumn
  $
 操作�� 
  CellTemplate ��  �� DataType$ dbEntity:LCAllocation��.R���  �� Orientation$ 
Horizontal=�.+��� $��编辑��#��[  ���� *Id+�� $��作废��#��[ ���� *Id+{��� *
IsCanceled+ �� 	Converter# [ �� $��删除��#��[ ���� *Id+