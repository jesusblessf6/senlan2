   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5   ^   B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6K   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      <    6Client.View.SystemSetting.ApprovalSetting.ApprovalList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     6^   >my/clr-namespace:Utility.Controls;assembly=Utility     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6K   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��5       N� Title 5   9     *ApprovalList+ � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5      ,   &Client.Converters.Bool2StringConverter   Bool2String  ApprovalView  ApprovalEdit  ApprovalDelete  Actions �� DataType �� Orientation   ResxName
   Key  View �� Command	 �� CommandParameter��%�  &	        &	      &	 &     &	 9     &	 L     7  7  &	 �    7    5   
   67   �� 5   
   6/   �� 5   
   6/   �� 5   
   61   �� 5   
   $ DBEntity:Approval��6'   .R�5      �� $ 
Horizontal=�6   .+�5      �� 8��  ��6     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6�   �� 5      8�� ��6     $! Client.Properties.Resources��$ Nullify����6�   �� *Id+6�   5      5      �� 5   
   $ DBEntity:Approval��6$   .R�5      �� �� 5      8   	 6D   �� *Id+.�6d   .�5      �� �6   �� *Name+62   5      5      5       5!      
 J� CommandBindings
 5#      )  #System.Windows.Input.CommandBinding  5$   
   -   5           Command# [ 5$      5%   ;     5&   
   -   5        # [ 5&      5'   ;     5(   
   -   5        # [ 5(      5)   =   .��5,      �� $
��Auto=�6   $
��Auto=�68   .��5-   
   � -   5        $��rootGrid��5-      .+�5.      �� -   5        $��lbTitle��5.   j   $��32��62   $
��Left=�6>   $��6,6,0,0q�6Y   $��16(�6y   $
��auto��6�   $	��Top=�5/      $
��Bold"�6,   ��5.        *ApprovalList+5/   ,   �� 50      -   5        $��button1��50   �   $��23��6^   $
��Left=�6j   $��6,40,0,0q�6�   $	��Top=�51      $��60��6-   ��50        $! Client.Properties.Resources��$ AddWithSymbol��51   8   $  Utility.Controls.PagingControl  52      -   5        $��pagingControl1��52   L   $
��Left=�6   $��6,70,0,0q�6:   $	��Top=�53      &   System.Windows.Controls.DataGrid  54      -   5        $��	dataGrid1��55         AutoGenerateColumns .  $
��Auto��54   3   $
��Left=�6A   $��	6,107,0,0q�6\   $	��Top=�55   (   $
��Auto��6@      
IsReadOnly .   DataGridStyle#��[ 56   8     DataGridRowStyle   RowStyle# [ 6_   ��55   M   ��    Columns 57      4  .System.Windows.Controls.DataGridTemplateColumn  58         CellTemplate# [ 6-   ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    SortMemberPath$
 Name��59   -     DataGridColumnHeaderStyle   HeaderStyle# [ 6C    	 DataGridCellStyle   	CellStyle# [	 5:   -      Header 58   R     $! Client.Properties.Resources��$
 Name��5:   ^   0	  *System.Windows.Controls.DataGridTextColumn	  5;       . # [ 5<   )   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5;   )   �� *Document.Name+ 6K     $! Client.Properties.Resources��$ DocumentType��5<   d   	  5=       . # [ 5>   ~    5=   )   �� *	IsDefault+ �� 	Converter# [   5>   )     $! Client.Properties.Resources��$ Default��5?   ,   	  5@       . # [ 5A   )    5@   )   �� *Description+ 6I     $! Client.Properties.Resources��$ Comments��5A   e     5B       .  # [ 6�   # [ 5C   -    5B   -     $! Client.Properties.Resources��$ 	Operation��5C   i   5E      5F      5G      5I      