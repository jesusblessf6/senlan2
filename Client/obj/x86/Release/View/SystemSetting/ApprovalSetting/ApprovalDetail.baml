   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  >    8Client.View.SystemSetting.ApprovalSetting.ApprovalDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -cclr-namespace:Client.Converters     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     -   'Client.Base.BaseClient.ObjectBaseWindow    IsEnabledChanged$$  ApprovalDetailIsEnabledChanged��$	��469��$	��600��$	��517�� � WindowStartupLocation$ CenterScreen=�0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting�� � Title      ResxName$! Client.Properties.Resources��
   Key$ ApprovalDetail�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources  �� 
TargetType	 �� Property
 �� Value,   &Client.Converters.BoolReverseConverter 	  boolC  StageDelete  ConditionDelete  Actions �� DataType �� Orientation  ConditionActions��%R  '��       '�� S     '�� �     &	  �     &	 �     &	 �     &	 �     7  &	 f    7  �� " ��.��� 	 � ��$
 28���� 	 � ��$	
 111���� 	 � ��$
 Right=��� " ��.��� 	 � ��$
 23���� 	 � ��$	
 120���� " ��.��� 	 � ��$
 23���� 	 � ��$	
 120��  �� �� �� $ DBEntity:ApprovalStage��.R��� $ 
Horizontal=�.+��� 8��  ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $  DBEntity:ApprovalCondition��.R��� $ 
Horizontal=�.+��� 8��  ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  $! Client.Properties.Resources��$ Approval���� -   $��label1��$��28��$
��Left=�$��6,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$
 Name���� -   $��textBox1��$��23��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120�� �� 	MaxLength$ 20������ *Name+�� -   $��label2��$
��Left=�$��
278,38,0,0q�$	��Top=�
���<����  $! Client.Properties.Resources��$ DocumentType���� -   $��	comboBox1��$��23��$
��Left=�$��
394,40,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *	Documents+ �� SelectedValue �� *
DocumentId+�� -	   $��label4��$��28��$
��Left=�$��6,66,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Default���� -
   $��	checkBox1��$�� ��$��16��$
��Left=�$��
122,72,0,0q�$	��Top=�{��� *ConditionEnabled+ �� 	Converter# [   d� 	IsChecked �� *	IsDefault+�� -   $��label3��$��28��$
��Left=�$��6,95,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -   $��textBox2��$	��100��$
��Left=�$��
122,97,0,0q�$	��Top=�$	��392�� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *Description+9� -   $��	expander1��$��1��$
��Auto��$
��Left=�$��	122,9,0,0q�$	��Top=�$	��392�� 9� 
IsExpanded . ��  *ApprovalCondition+.��� .+��� -   $��button4��$��23��$
��Left=�$��0,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��{��� *ConditionEnabled+&   System.Windows.Controls.DataGrid  -   $��	dataGrid2��   AutoGenerateColumns .  $��0,38,0,0q�   
IsReadOnly .   DataGridStyle#��[   DataGridRowStyle   RowStyle# [ $
��Left=�$
��auto��$
��auto��$	��Top=����� *
Conditions+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .   DataGridColumnHeaderStyle   HeaderStyle# [     Header    $! Client.Properties.Resources��$ Currency��1	  +System.Windows.Controls.DataGridBoundColumn! 	  Binding! �� *Currency.Name+   . # [     $B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��$ Floor��! �� *
LowerLimit+   .  # [     $B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��$ Ceiling��! �� *
UpperLimit+4
  .System.Windows.Controls.DataGridTemplateColumn
  " 
  CellTemplate#" [ # [     $! Client.Properties.Resources��$ 	Operation��9� -   $��	expander2��$��2��$
��auto��$��	122,6,0,0q� . $	��Top=�$
��Left=�$	��392����  *ApprovalStage+.��� .+��� -   $��button1��$��23��$
��Left=�$��1,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -   $��	dataGrid1�� .  $
��Auto��$
��Left=�$��1,38,0,0q�$	��Top=�$
��Auto�� . #��[ # [ ���� *Stages+    . # [     $! Client.Properties.Resources��$ Number��! �� *
StageIndex+   .  # [     $B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��$ Approver��! �� *ApprovalUser.Name+
  #" [ # [     $! Client.Properties.Resources��$ 	Operation���� -   $��button2��$��3��$��25��$
��Left=�$��
210,25,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$
 Save���� -   $��button3��$��3��$��25��$
��Left=�$��
305,25,0,0q�$	��Top=�$��60����  $! Client.Properties.Resources��$ Cancel��