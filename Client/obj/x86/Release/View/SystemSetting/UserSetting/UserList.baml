   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 4   .Client.View.SystemSetting.UserSetting.UserList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.SystemSetting.UserSetting.ResUserSetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *
UserList+ � 	Resources    EditUser  ViewUser  
DeleteUser  LinkCommodity  LinkInternalCustomer  
UserAction �� DataType �� Orientation   ResxName
   Key  UserView �� Command	 �� CommandParameter��%�  &	        &	      &	 
     &	      &	      &	      7   7  7  7  &	     7  �� �� �� �� �� �� $ DBEntity:User��.R��� $��spUserAction��$ 
Horizontal=�.+��� $��
btEditUser��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btDeleteUser��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $��btLinkCommodity��8�� ��  $! Client.Properties.Resources��$ 	Commodity������ *Id+�� $��btLinkInternalCustomer��8�� ��  $! Client.Properties.Resources��$ InternalCustomer������ *Id+�� $ DBEntity:User��.R��� �� 8   	 �� *Id+.�.��� ��� *Name+
 J� CommandBindings
 )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *
UserList+$   Utility.Controls.PagingControl  -   $��pagingControl1��$
��Left=�$��6,70,0,0q�$��31��$	��Top=�&   System.Windows.Controls.DataGrid  -	   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��	6,107,0,0q�$	��Top=�$
��Auto��   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    Header   $! Client.Properties.Resources��$ 	LoginName��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *	LoginName+4
  .System.Windows.Controls.DataGridTemplateColumn
   . $
 Auto  
  CellTemplate# [    SortMemberPath$
 Name��   $: 4Client.View.SystemSetting.UserSetting.ResUserSetting��$
 Name��   . $
 Auto    $! Client.Properties.Resources��$
 Role�� �� *	Role.Name+   .  $
 Auto    $! Client.Properties.Resources��$ Comments�� �� *Description+
   .  $
 Auto # [    $! Client.Properties.Resources��$ 	Operation���� -
   $��button1��$��23��$
��Left=�$��6,40,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ AddWithSymbol��