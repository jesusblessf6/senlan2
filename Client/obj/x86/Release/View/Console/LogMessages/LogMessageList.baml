   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 4   .Client.View.Console.LogMessages.LogMessageList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$3  -Client.View.Console.LogMessages.ResLogMessage�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *SubscribedLog+ � 	Resources    
MarkAsRead  DeleteMessage��%   &	        &	      �� ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *	UnreadLog+$  Utility.Controls.PagingControl  -   $��pager��$
��Left=�$��6,40,0,0q�$	��Top=�$��31��&   System.Windows.Controls.DataGrid  -   $��
entityList��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,77,0,0q�$	��Top=�$
��Auto��   
IsReadOnly .   DataGridStyle#��[   DataGridRowStyle   RowStyle# [ $��Infinity������ 	   Columns	 0  *System.Windows.Controls.DataGridTextColumn    DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn
   HeaderStyle#
 [    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    CanUserSort .    Header      ResxName$3 -Client.View.Console.LogMessages.ResLogMessage��
   Key$ LogTime��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Log.LogTime+ �� StringFormat$ {0:yyyy-MM-dd HH:mm:ss}��  #
 [ $
 Auto  .    $3 -Client.View.Console.LogMessages.ResLogMessage��$ OperationType�� �� *Log.LogAction.Name+  #
 [ $
 Auto  .    $! Client.Properties.Resources��$ DocumentType�� �� *Log.Document.Name+  #
 [ $
 Auto  .    $3 -Client.View.Console.LogMessages.ResLogMessage��$ 
DocumentId�� �� *Log.ObjectId+  #
 [ $
 Auto  .    $3 -Client.View.Console.LogMessages.ResLogMessage��$ Operator�� �� *Log.User.Name+4
  .System.Windows.Controls.DataGridTemplateColumn
  #
 [  .  $
 Auto    $! Client.Properties.Resources��$ 	Operation�� 
  CellTemplate ��  �� DataType$ DBEntity:LogMessage��.R���  �� Orientation$ 
Horizontal=�.+��� #��[  ��  $3 -Client.View.Console.LogMessages.ResLogMessage��$ 
MarkAsRead������ *Id+�� #��[ ��  $! Client.Properties.Resources��$ Delete������ *Id+