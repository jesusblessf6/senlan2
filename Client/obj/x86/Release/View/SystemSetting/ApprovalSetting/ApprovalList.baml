   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  <    6Client.View.SystemSetting.ApprovalSetting.ApprovalList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting�� N� Title   *ApprovalList+ � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources ,   &Client.Converters.Bool2StringConverter   Bool2String  ApprovalView  ApprovalEdit  ApprovalDelete  Actions �� DataType �� Orientation   ResxName
   Key  View �� Command	 �� CommandParameter��%�  &	        &	      &	 
     &	      &	      7  7  &	 �     7    �� �� �� �� $ DBEntity:Approval��.R��� $ 
Horizontal=�.+��� 8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� 8�� ��  $! Client.Properties.Resources��$ Nullify������ *Id+�� $ DBEntity:Approval��.R��� �� 8   	 �� *Id+.�.��� ��� *Name+
 J� CommandBindings
 )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$��16(�$
��auto��$	��Top=�$
��Bold"���  *ApprovalList+�� -   $��button1��$��23��$
��Left=�$��6,40,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ AddWithSymbol��$  Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��6,70,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,107,0,0q�$	��Top=�$
��Auto��   
IsReadOnly .   DataGridStyle#��[   DataGridRowStyle   RowStyle# [ ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [ ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    SortMemberPath$
 Name��  DataGridColumnHeaderStyle   HeaderStyle# [  	 DataGridCellStyle   	CellStyle# [	    Header   $! Client.Properties.Resources��$
 Name��0	  *System.Windows.Controls.DataGridTextColumn	   . # [ 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Document.Name+   $! Client.Properties.Resources��$ DocumentType��	   . # [  �� *	IsDefault+ �� 	Converter# [     $! Client.Properties.Resources��$ Default��	   . # [  �� *Description+   $! Client.Properties.Resources��$ Comments��   .  # [ # [    $! Client.Properties.Resources��$ 	Operation��