   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      5clr-namespace:Client.ConvertersClient.Converters 5	      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5      5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      8   2Client.View.Finance.LCAllocations.LCAllocationList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      5base$clr-namespace:Client.Base.BaseClient     5      5	converterclr-namespace:Client.Converters     5	      >my/clr-namespace:Utility.Controls;assembly=Utility     5      =dbEntity(clr-namespace:DBEntity;assembly=DBEntity     5        N� Title$  信用证分配列表��5       � 	Resources 5         EditLCAllocation  DeleteLCAllocation  CancelLCAllocation,  &Client.Converters.BoolReverseConverter  BoolReverse��%t   &	        &	      &	 &     &	 9     �� 5   
   63   �� 5   
   65   �� 5   
   65     5   
   6?   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6�     5   
   -   5        # [ 5      6�     5   
   -   5        # [ 5      6�   .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��label1��5   �   $��信用证分配列表��6   $��16(�6&   $
��Bold"�64   $��32��6F   $
��Left=�6R   $��	10,10,0,0q�6m   $	��Top=�6�   $  Utility.Controls.PagingControl  5      -   5        $��pagingControl1��5   M   $
��Left=�6   $��	28,48,0,0q�6:   $	��Top=�6c   �� 5       -   5        $��
textBlock1��5    S   $��23��6   $
��Left=�6$   $��
552,56,0,0q�6?   $	��Top=�6e   �� 5!      .�6   数量合计：6    �� 5"      �6   �� *QtySum+$   DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z 6l    �� 5#      .�6   |6    �� 5$      .�6   金额合计：6    �� 5%      �6   �� *USDAmountSum+   
STR_AMOUNT# Z 6p    �� 5&      .�6   USD /6    �� 5'      �6   �� *CNYAmountSum+# Z 6p    �� 5(      .�6   CNY6   5)      &   System.Windows.Controls.DataGrid  5*      -   5        $��	dataGrid1��5+         AutoGenerateColumns .  $
��Auto��5*   K   $
��Left=�6Y   $��	28,85,0,0q�6t   $	��Top=�5+   (   $
��Auto��6@      
IsReadOnly . ��5*   3   �� 	   Columns	 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn
   Header$
 询问日期��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 67   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6D   �� *EnquireDate+$ {0:yyyy-MM-dd}��  5.      $
 客户��6)   $
 Auto 65    6B   �� *BusinessPartner.ShortName+  5/      $
 内部客户��6)   $
 Auto 67    6D   �� *InternalCustomer.ShortName+  50      $
 	开证行��6)   $
 Auto 66    6C   �� *IssueBankName+  51      $
 币种��6)   $
 Auto 65    6B   �� *Currency.Name+  52      $
 天数��6)   $
 Auto 65    6B   �� *Days+   STR_INTEGER# Z   53      $
 金属��6)   $
 Auto 65    6B   �� *Commodity.Name+  54      $
 数量��6)   $
 Auto 65    6B   �� *
Quantity+# Z   55      $
 金额��6)   $
 Auto 65    6B   �� *Amount+# Z   56      $
 报价��6)   $
 Auto 65    6B   �� *	Quotation+  57      $
 	承兑行��6)   $
 Auto 66    6C   �� *AcceptingBankName+6k     58      $
 	开证日��6)   $
 Auto 66    6C   �� *	IssueDate+$ {0:yyyy-MM-dd}��  59      $
 	贴现日��6)   $
 Auto 66    6C   �� *DiscountDate+$ {0:yyyy-MM-dd}��  5:      $
 实际贴现利率��6)   $
 Auto 69    6F   �� *ActualDiscounting+  5;      $
 	负责人��6)   $
 Auto 66    6C   �� *Responsor.Name+  5<      $
 备注��6)   $
 Auto 65    6B   �� *
Comments+4
  .System.Windows.Controls.DataGridTemplateColumn
  5=      $
 操作��6-    
  CellTemplate 5>      �� 5?       �� DataType$ dbEntity:LCAllocation��6+   .R�5@   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5A   &   �� $��编辑��6-   #��[  6:   ��6f   �� *Id+6�   �� 5B   &   $��作废��6-   #��[ 6:   ��6h   �� *Id+{�6�   �� *
IsCanceled+ �� 	Converter# [ 6�   �� 5C   &   $��删除��6-   #��[ 6:   ��6h   �� *Id+6�   5D   #   5E      5G      5J      5K      5L      5M      