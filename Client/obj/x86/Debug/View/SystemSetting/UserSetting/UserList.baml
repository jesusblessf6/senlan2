   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   (   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      4   .Client.View.SystemSetting.UserSetting.UserList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   (   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$:  4Client.View.SystemSetting.UserSetting.ResUserSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *
UserList+ � 	Resources 5         EditUser  ViewUser  
DeleteUser  LinkCommodity  LinkInternalCustomer  
UserAction �� DataType �� Orientation   ResxName
   Key  UserView �� Command	 �� CommandParameter��%  &	        &	      &	 &     &	 9     &	 L     &	 _     7   7  7  7  &	     7  �� 5   
   6+   �� 5   
   6+   �� 5   
   6-   �� 5   
   60   �� 5   
   67   �� 5   
   $ DBEntity:User��6*   .R�5      �� $��spUserAction��6   $ 
Horizontal=�6-   .+�5      �� $��
btEditUser��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btDeleteUser��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   �� 5      $��btLinkCommodity��6   8�� ��60     $! Client.Properties.Resources��$ 	Commodity����5      �� *Id+6;   �� 5      $��btLinkInternalCustomer��6   8�� ��67     $! Client.Properties.Resources��$ InternalCustomer����5      �� *Id+6;   5      5      �� 5    
   $ DBEntity:User��6(   .R�5!      �� �� 5"      8   	 6@   �� *Id+.�6`   .�5#      �� �6   �� *Name+62   5$      5%      5&      5'      
 J� CommandBindings
 5)      )  #System.Windows.Input.CommandBinding  5*   
   -   5           Command# [  5*      6{     5+   
   -   5        # [ 5+      6{     5,   
   -   5        # [ 5,      5-   9     5.   
   -   5        # [ 5.      5/   <     50   
   -   5        # [ 50      51   5   .��54      �� $
��Auto=�6   $
��Auto=�68   .��55   
   � -   5        $��rootGrid��55      .+�56      �� -   5        $��lbTitle��56   .   $��32��6=   $
��Left=�6I   $��6,6,0,0q�6d   $
��auto��6u   $	��Top=�57      $
��Bold"�6,   $��16(�6>   ��56        *
UserList+57   >   $   Utility.Controls.PagingControl  58      -   5        $��pagingControl1��58   X   $
��Left=�6   $��6,70,0,0q�6:   $��31��6L   $	��Top=�59      &   System.Windows.Controls.DataGrid  5:      -	   5        $��	dataGrid1��5;         AutoGenerateColumns .  $
��Auto��5:   3   $
��Left=�6A   $��	6,107,0,0q�6\   $	��Top=�5;   (   $
��Auto��6@      
IsReadOnly . ��6M   ��    Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�      Header 6)     $! Client.Properties.Resources��$ 	LoginName��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6�   �� *	LoginName+6�   4
  .System.Windows.Controls.DataGridTemplateColumn
  5?       . $
 Auto 6�    
  CellTemplate# [ 5@   -      SortMemberPath$
 Name��6V    5?   -     $: 4Client.View.SystemSetting.UserSetting.ResUserSetting��$
 Name��5@   n     5A       . $
 Auto 6{    6)     $! Client.Properties.Resources��$
 Role�� 6�   �� *	Role.Name+6�     5B       .  $
 Auto 6�    6)     $! Client.Properties.Resources��$ Comments�� 6�   �� *Description+6�   
  5C       .  $
 Auto 6�   # [ 5D   -    5C   -     $! Client.Properties.Resources��$ 	Operation��5D   Z   5F      �� 5G      -
   5        $��button1��5G   �   $��23��6^   $
��Left=�6j   $��6,40,0,0q�6�   $	��Top=�5H      $��60��6-   ��5G        $! Client.Properties.Resources��$ AddWithSymbol��5H   8   5I      5J      5K      