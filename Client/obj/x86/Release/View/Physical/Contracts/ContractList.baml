   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 1   +Client.View.Physical.Contracts.ContractList   6my/clr-namespace:Utility.Controls;assembly=Utility  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ContractList+ � 	Resources ,  &Client.Converters.PricingTypeConverter   PricingTypeConverter-  'Client.Converters.PricingBasisConverter  PricingBasisConverter.  (Client.Converters.ApproveStatusConverter  ApproveStatusConverter+  %Client.Converters.VisibilityConverter  VisibilityConverter  	QuotaEdit  ContractSplit  QuotaDelete  PricingView  PrintContract 	 AttachmentView 
 QuotaDetailView  MoreBrandsView  QuotaActions �� DataType �� Orientation   ResxName
   Key  QuotaNoLink �� Command	 �� CommandParameter 
 dgCell
 �� 
TargetType �� Property �� Value��%A  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 2     &	 7     &	 <     7  7  7  7  7 	 &	     7 
 &	 l            �� �� �� �� �� �� �� �� �� $ DBEntity:Quota��.R��� $ 
Horizontal=�$��Center=�.+��� $��btQuotaEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+{��� *AutoGenGeneratedCanEdit+�� $��btContractSplit��$��拆分��$y�	Collapsed=�8�� ���� *
ContractId+{��� *
CanBeSplit+�� $��btQuotaDelete��8�� ��  $! Client.Properties.Resources��$ Nullify������ *Id+{��� *AutoGenGeneratedCanEdit+�� $��btPrint��$��Right=�8�� $y�	Collapsed=���  $! Client.Properties.Resources��$ Print������ *
ContractId+�� $��btAttachmentView��$��Right=�8�� ��  $! Client.Properties.Resources��$ 
Attachment������ *
ContractId+�� $ DBEntity:Quota��.R��� $��Center=��� 8   	 �� *Id+.�.��� ��� *	QuotaNo+�� "
 ��.���  � ��$ Center=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [
   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [	 .���� $
��Auto=�$
��Auto=�.��� -	    �Name$ rootGrid��.+��� -
   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(����� *Title+�� $��6,40,0,0q�$ 
Horizontal=�$
��Auto��$	��Top=�$
��Left=�$
��Auto��.+�$   Utility.Controls.PagingControl  -   $��pagerContract��$
��Left=�$	��Top=��� $��	总数量��
���  ��$��10,0,0,0q�$��Center=��� $��10,0,0,0q�$��Center=����� *
TotalQty+ �� StringFormat$ N2���� $��	总金额��
���  ��$��10,0,0,0q�$��Center=��� $��10,0,0,0q�$��Center=����� *TotalAmount+$ N2���� -   $��打印合同��$��10,0,0,0q�$��23���� -   $��导出Excel��$��10,0,0,0q�$��23��&	   System.Windows.Controls.DataGrid	  -   $��dataGridQuotas�� 	  AutoGenerateColumns .   	  CanUserAddRows .   	  
IsReadOnly . $��6,80,0,0q� 	  AlternatingRowBackground
 �����$	��Top=�$
��Left=�$
��Auto��  DataGridStyle#��[   DataGridRowStyle 	  RowStyle# [ ���� *
QuotasView+ 	  Columns 4
  .System.Windows.Controls.DataGridTemplateColumn
  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    
IsReadOnly .    Header �� -   $��cbSelectAll��$��全选��$��Center=�$��Center=� d� 	IsChecked �� *IsSelectAll+ 
  CellTemplate �� $ DBEntity:Quota��.R��� $��Center=�$��Center=� �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *	Printable+
     SortMemberPath$ QuotaNo��   CanUserSort .   DataGridColumnHeaderStyle   HeaderStyle# [ # [    $! Client.Properties.Resources��$ QuotaNo��0  *System.Windows.Controls.DataGridTextColumn  # [ 1  +System.Windows.Controls.DataGridBoundColumn    ElementStyle#  [    $0 *Client.View.Physical.Contracts.ResContract��$ OriginContractNo��!   Binding! �� *Contract.ExContractNo+  # [ $
 Auto  . #  [    $! Client.Properties.Resources��$ BP��! �� *$"Contract.BusinessPartner.ShortName+  # [ $
 Auto  . #  [    $! Client.Properties.Resources��$ SignSide��! �� *%#Contract.InternalCustomer.ShortName+  # [ #  [    $! Client.Properties.Resources��$ 	Commodity��! �� *Commodity.Name+  # [ #  [    $! Client.Properties.Resources��$ Brand��! �� *TotalBrands+  # [ #  [    $! Client.Properties.Resources��$ 	Warehouse��! �� *Warehouse.Name+  # [ #  [    $! Client.Properties.Resources��$	 UDF��! �� *Contract.ContractUDF.Name+  # [ #  [    $! Client.Properties.Resources��$ ImplementedDate��! �� *ImplementedDate+$ 
yyyy-MM-dd��
  # [ $ Quantity�� .    $! Client.Properties.Resources��$ Quantity�� �� $ DBEntity:Quota��.R��� $��Center=�.+��� y��� *IsMoreBrands+" �� 	Converter#" [ �� # [ 	 �� *Id+.�.��� ��� *
Quantity+$  DBEntity.EnumEntity.RoundRules#   STR_QUANTITY# Z# �� y��� *IsNotMoreBrands+#" [ �� ��� *
Quantity+# Z# 
  # [    $! Client.Properties.Resources��$ Price��$   ClipboardContentBinding$ �� *
StrPrice+ �� $ DBEntity:Quota��.R��� $��Center=��� # [ 	 �� *Id+.�.��� ��� *
StrPrice+  # [ #  [    $! Client.Properties.Resources��$ PricingCurrency��! �� *Currency.Name+  # [ #  [    $! Client.Properties.Resources��$ PricingType��! �� *PricingType+#" [    # [ %   
Visibility$% Hidden=�#  [    $! Client.Properties.Resources��$ PricingReference��! �� *PricingBasis+#" [   # [ $% Hidden=�#  [    $! Client.Properties.Resources��$ PricingStartDate��! �� *PricingStartDate+$ 
yyyy-MM-dd��  # [ $% Hidden=�#  [    $! Client.Properties.Resources��$ PricingEndDate��! �� *PricingEndDate+$ 
yyyy-MM-dd��   . # [ #  [    $! Client.Properties.Resources��$ ApprovalStatus��! �� *ApproveStatus+#" [    . # [ #  [    $! Client.Properties.Resources��$ Approval��! �� *Approval.Name+
   .  # [    $! Client.Properties.Resources��$ ApprovalDetail�� �� $ DBEntity:Quota��.R��� $��Center=��� 
��� � ���� *CustomerStrField1+ �� 
���  ����� *CustomerStrField2+   . $
 Auto # [ #  [    $! Client.Properties.Resources��$ RejectReason��! �� *RejectReason+
  $ 流转信息��$% Hidden=� . $
 Auto # [  �� .R��� $
��Wrap=�$	��300��$��Center=����� *RelQuotaStr+
  $
 Auto  .  # [ # [    $! Client.Properties.Resources��$ 	Operation��& �� 
GroupStyle& (  "System.Windows.Controls.GroupStyle    GroupHerderStyle'   ContainerStyle#' [ (   Panel( �� .R�>  8System.Windows.Controls.Primitives.DataGridRowsPresenter  