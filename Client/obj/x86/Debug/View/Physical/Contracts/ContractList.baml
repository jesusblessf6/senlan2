   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      1   +Client.View.Physical.Contracts.ContractList   5      6my/clr-namespace:Utility.Controls;assembly=Utility  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      Elocal3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   Q     *ContractList+ � 	Resources 5      ,  &Client.Converters.PricingTypeConverter   PricingTypeConverter-  'Client.Converters.PricingBasisConverter  PricingBasisConverter.  (Client.Converters.ApproveStatusConverter  ApproveStatusConverter+  %Client.Converters.VisibilityConverter  VisibilityConverter  	QuotaEdit  ContractSplit  QuotaDelete  PricingView  PrintContract 	 AttachmentView 
 QuotaDetailView  MoreBrandsView  QuotaActions �� DataType �� Orientation   ResxName
   Key  QuotaNoLink �� Command	 �� CommandParameter 
 dgCell
 �� 
TargetType �� Property �� Value��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     7  7  7  7  7 	 &	 �    7 
 &	 �      5   
   6*     5   
   6+     5   
   6,     5   
   6)   �� 5   
   6,   �� 5   
   60   �� 5   
   6.   �� 5   
   6.   �� 5   
   60   �� 5   
   61   �� 5   
   62   �� 5   
   61   �� 5   
   $ DBEntity:Quota��6,   .R�5      �� $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��btQuotaEdit��6   8��  ��6,     $! Client.Properties.Resources��$
 Edit����5!      �� *Id+{�69   �� *AutoGenGeneratedCanEdit+5"      �� 5#      $��btContractSplit��6   $��拆分��60   $y�	Collapsed=�6=   8�� ��5%      �� *
ContractId+{�6A   �� *
CanBeSplit+5&      �� 5'      $��btQuotaDelete��6   8�� ��6.     $! Client.Properties.Resources��$ Nullify����5)      �� *Id+{�69   �� *AutoGenGeneratedCanEdit+5*      �� 5+      $��btPrint��5,      $��Right=�5+   Z   8�� $y�	Collapsed=�5,   y   ��5+        $! Client.Properties.Resources��$ Print����5,   (   �� *
ContractId+5-      �� 5.      $��btAttachmentView��5/   5   $��Right=�6   8�� ��5.        $! Client.Properties.Resources��$ 
Attachment����5/   M   �� *
ContractId+51      52      53      �� 55   
   $ DBEntity:Quota��6+   .R�56      �� $��Center=�6   �� 57      8   	 6G   �� *Id+.�6g   .�58      �� �6   �� *	QuotaNo+65   59      5:      5;      �� 5=   
   "
 ��6   .�5>      ��  � ��$ Center=�62   5?      5@       J� CommandBindings 5B      )  #System.Windows.Input.CommandBinding  5C   
   -   5           Command# [ 5C      5E        5G   
   -   5        # [
 5G      5I        5J   
   -   5        # [ 5J      5L        5M   
   -   5        # [ 5M      5O        5P   
   -   5        # [ 5P      5R        5S   
   -   5        # [ 5S      5U        5V   
   -   5        # [ 5V      5X        5Y   
   -   5        # [	 5Y      5[      .��5^      �� $
��Auto=�6   $
��Auto=�68   .��5_   
   � -	   5         �Name$ rootGrid��5_      .+�5`      �� -
   5        $��lbTitle��5`      $��32��6=   $
��Left=�6I   $��6,6,0,0q�6d   $
��auto��5a      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5`   #   �� *Title+5a   K   �� 5b      $��6,40,0,0q�6   $ 
Horizontal=�6+   $
��Auto��6D   $	��Top=�6R   $
��Left=�6j   $
��Auto��6�   .+�5c      $   Utility.Controls.PagingControl  -   5        $��pagerContract��5c   >   $
��Left=�6#   $	��Top=�6S   �� 5d      $��	总数量��6   
���  ��$��10,0,0,0q�5e      $��Center=�6*   5f      �� 5g      $��10,0,0,0q�6G   $��Center=�6Y   ��6   �� *
TotalQty+ �� StringFormat$ N2��6v   �� 5h      $��	总金额��6   
���  ��$��10,0,0,0q�5i      $��Center=�6*   5j      �� 5k      $��10,0,0,0q�6J   $��Center=�6\   ��6   �� *TotalAmount+$ N2��6y   �� 5l      -   5        $��打印合同��5l      $��10,0,0,0q�6(   $��23��6N   6\   �� 5m      -   5        $��导出Excel��5m      $��10,0,0,0q�6+   $��23��6S   6a   5n      &	   System.Windows.Controls.DataGrid	  5o      -   5        $��dataGridQuotas��5o       	  AutoGenerateColumns .   	  CanUserAddRows .   	  
IsReadOnly . $��6,80,0,0q�5q   )    	  AlternatingRowBackground
 �����$	��Top=�6a   $
��Left=�5r      $
��Auto��5s        DataGridStyle#��[ 6E     DataGridRowStyle 	  RowStyle# [ 5t      ��5o   -   �� *
QuotasView+ 	  Columns 5u      4
  .System.Windows.Controls.DataGridTemplateColumn
  5v      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6-      
IsReadOnly .    Header 5w      �� 5x      -   5        $��cbSelectAll��5x   I   $��全选��6\   $��Center=�6i   $��Center=�6�    d� 	IsChecked 6'   �� *IsSelectAll+6�    
  CellTemplate 5z      �� 5{      $ DBEntity:Quota��6+   .R�5|   "   �� $��Center=�6�   $��Center=�6�    6+   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{�6q   �� *	Printable+6�   5}      5      
  5�         SortMemberPath$ QuotaNo��5�   -      CanUserSort .   DataGridColumnHeaderStyle   HeaderStyle# [ 5�   -   # [ 5�   -    5�   -     $! Client.Properties.Resources��$ QuotaNo��5�   -   0  *System.Windows.Controls.DataGridTextColumn  5�      # [ 5�      1  +System.Windows.Controls.DataGridBoundColumn    ElementStyle#  [ 6R    5�        $0 *Client.View.Physical.Contracts.ResContract��$ OriginContractNo��!   Binding! 5�      �� *Contract.ExContractNo+5�   R     5�      # [ 5�   )   $
 Auto 6b    . #  [ 5�   <    5�   )     $! Client.Properties.Resources��$ BP��! 5�   )   �� *$"Contract.BusinessPartner.ShortName+5�        5�      # [ 5�   )   $
 Auto 6b    . #  [ 5�   <    5�   )     $! Client.Properties.Resources��$ SignSide��! 5�   )   �� *%#Contract.InternalCustomer.ShortName+5�        5�      # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ 	Commodity��! 5�   )   �� *Commodity.Name+5�   b     5�      # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ Brand��! 5�   )   �� *TotalBrands+5�   b     5�      # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ 	Warehouse��! 5�   )   �� *Warehouse.Name+5�   b     5�      # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$	 UDF��! 5�   )   �� *Contract.ContractUDF.Name+5�   b     5�      # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ ImplementedDate��! 5�   )   �� *ImplementedDate+$ 
yyyy-MM-dd��5�   b   
  5�      # [ 6p   $ Quantity��6�    .  6-     $! Client.Properties.Resources��$ Quantity�� 5�      �� 5�      $ DBEntity:Quota��6+   .R�5�   "   �� $��Center=�6-   .+�5�   &   �� y�60   �� *IsMoreBrands+" �� 	Converter#" [ �� 5�   &   # [ 60   	 6Z   �� *Id+.�6z   .�5�   *   �� �6.   �� *
Quantity+$  DBEntity.EnumEntity.RoundRules#   STR_QUANTITY# Z# 6�   5�   '   5�   '   �� 5�   &   y�60   �� *IsNotMoreBrands+#" [ �� 5�   *   �6.   �� *
Quantity+# Z# 6�   5�   '   5�   #   5�      5�        5�      $ 实际数量��6)   # [ 5�   )   #  [ 6b   ! 5�   )   �� *VerifiedQuantity+# Z# 5�   b   
  5�      # [ 5�   -    5�   -     $! Client.Properties.Resources��$ Price��$   ClipboardContentBinding$ 5�   -   �� *
StrPrice+ 5�      �� 5�      $ DBEntity:Quota��6+   .R�5�   "   �� $��Center=�6,   �� 5�   &   # [ 60   	 6W   �� *Id+.�6w   .�5�   *   �� �6.   �� *
StrPrice+6J   5�   '   5�   #   5�      5�        5�      # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ PricingCurrency��! 5�   )   �� *Currency.Name+5�   b     5�      # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ PricingType��! 5�   )   �� *PricingType+#" [  5�   b     5�      # [ 5�   )   %   
Visibility$% Hidden=�6b   #  [ 6v    5�   )     $! Client.Properties.Resources��$ PricingReference��! 5�   )   �� *PricingBasis+#" [ 5�   v     5�      # [ 5�   )   $% Hidden=�5�   g   #  [ 6{    5�   )     $! Client.Properties.Resources��$ PricingStartDate��! 5�   )   �� *PricingStartDate+$ 
yyyy-MM-dd��5�        5�      # [ 5�   )   $% Hidden=�5�   e   #  [ 6y    5�   )     $! Client.Properties.Resources��$ PricingEndDate��! 5�   )   �� *PricingEndDate+$ 
yyyy-MM-dd��5�        5�       . # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ ApprovalStatus��! 5�   )   �� *ApproveStatus+#" [ 5�        5�       . # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ Approval��! 5�   <   �� *Approval.Name+5�      
  5�       .  # [ 5�   -    5�   -     $! Client.Properties.Resources��$ ApprovalDetail�� 5�      �� 5�      $ DBEntity:Quota��6+   .R�5�   "   �� $��Center=�6,   �� 5�   &   
��� � ��6=   �� *CustomerStrField1+6b    �� 5�   &   
���  ���6;   �� *CustomerStrField2+6`   5�   #   5�      5�        5�       . $
 Auto 5�   ]   # [ 5�   )   #  [ 6b    5�   )     $! Client.Properties.Resources��$ RejectReason��! 5�   )   �� *RejectReason+5�      
  5�      $ 流转信息��6-   $% Hidden=�6;    . $
 Auto 5�   =   # [ 5�   )    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6,   $	��300��6@   $��Center=�6i   ��6L   �� *RelQuotaStr+6i   5�      5�      
  5�      $
 Auto 5�   -    .  # [ 5�   -   # [ 5�   -    5�   -     $! Client.Properties.Resources��$ 	Operation��5�      & �� 
GroupStyle& 5�      (  "System.Windows.Controls.GroupStyle  5�        GroupHerderStyle'   ContainerStyle#' [ 6!   (   Panel( 5�      �� 5�      .R�5�   "   >  8System.Windows.Controls.Primitives.DataGridRowsPresenter  5�      5     5     5     5     5     