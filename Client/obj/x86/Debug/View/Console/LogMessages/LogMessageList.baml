   M S B A M L   `   `   `  ����C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5
   3   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      4   .Client.View.Console.LogMessages.LogMessageList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5
   3   ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$3  -Client.View.Console.LogMessages.ResLogMessage��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5
        *SubscribedLog+ � 	Resources 5         
MarkAsRead  DeleteMessage��%:   &	        &	      �� 5   
   6-   �� 5   
   60   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      5        5   
   -   5        # [ 5      5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   /   $
��Left=�6>   $��6,6,0,0q�6Y   $��32��6j   $	��Top=�5      $
��Bold"�6,   $��16(�6>   ��5        *	UnreadLog+5   >   $  Utility.Controls.PagingControl  5      -   5        $��pager��5   L   $
��Left=�6   $��6,40,0,0q�6:   $	��Top=�5       $��31��67   &   System.Windows.Controls.DataGrid  5!      -   5        $��
entityList��5"         AutoGenerateColumns .  $
��Auto��5!   3   $
��Left=�6A   $��6,77,0,0q�6\   $	��Top=�5#      $
��Auto��6/      
IsReadOnly .   DataGridStyle#��[ 5$        DataGridRowStyle   RowStyle# [ 6>   $��Infinity��5%   3   ��5#   <   �� 	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5'        DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn
   HeaderStyle#
 [ 6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5)   )      CanUserSort .    Header 5(   )        ResxName$3 -Client.View.Console.LogMessages.ResLogMessage��
   Key$ LogTime��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5*   )   �� *Log.LogTime+ �� StringFormat$ {0:yyyy-MM-dd HH:mm:ss}��5+        5,      #
 [ 6)   $
 Auto 5.   )    .  5-   )     $3 -Client.View.Console.LogMessages.ResLogMessage��$ OperationType�� 5.   I   �� *Log.LogAction.Name+5/        50      #
 [ 6)   $
 Auto 52   )    .  51   )     $! Client.Properties.Resources��$ DocumentType�� 52   I   �� *Log.Document.Name+53        54      #
 [ 6)   $
 Auto 56   )    .  55   )     $3 -Client.View.Console.LogMessages.ResLogMessage��$ 
DocumentId�� 56   I   �� *Log.ObjectId+57        58      #
 [ 6)   $
 Auto 5:   )    .  59   )     $3 -Client.View.Console.LogMessages.ResLogMessage��$ Operator�� 5:   I   �� *Log.User.Name+5;      4
  .System.Windows.Controls.DataGridTemplateColumn
  5<      #
 [ 6-    .  $
 Auto 5>   A    5=   -     $! Client.Properties.Resources��$ 	Operation�� 
  CellTemplate 5?      �� 5@       �� DataType$ DBEntity:LogMessage��6+   .R�5A   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5B   &   �� #��[  5D   )   ��5C   )     $3 -Client.View.Console.LogMessages.ResLogMessage��$ 
MarkAsRead����5D   O   �� *Id+5E   '   �� 5F   &   #��[ 5G   -   ��5F   -     $! Client.Properties.Resources��$ Delete����5G   V   �� *Id+5H   '   5I   #   5J      5L      5N      5O      5P      5Q      