   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      >    8Client.View.SystemSetting.ApprovalSetting.ApprovalDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -cclr-namespace:Client.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      -   'Client.Base.BaseClient.ObjectBaseWindow    IsEnabledChanged$$  ApprovalDetailIsEnabledChanged��5   =   $	��469��5   �   $	��600��6�   $	��517��6�    � WindowStartupLocation$ CenterScreen=�5      0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��5       � Title 5   I        ResxName$! Client.Properties.Resources��
   Key$ ApprovalDetail�� � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5       �� 
TargetType	 �� Property
 �� Value,   &Client.Converters.BoolReverseConverter 	  boolC  StageDelete  ConditionDelete  Actions �� DataType �� Orientation  ConditionActions��%�  '��       '�� �     '��     &	  �    &	 �    &	 �    &	 �    7  &	 �    7  �� 5   
   " ��6   .�5      �� 	 � ��$
 28��6'   64   �� 5      	 � ��$	
 111��6&   64   �� 5      	 � ��$
 Right=�6;   6K   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 23��6'   64   �� 5      	 � ��$	
 120��6&   64   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 23��6'   64   �� 5      	 � ��$	
 120��6&   64   5        5   
   61   �� 5    
   6.   �� 5!   
   62   �� 5#   
   $ DBEntity:ApprovalStage��6'   .R�5$      �� $ 
Horizontal=�6   .+�5%      �� 8��  ��6     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6�   5&      5'      �� 5)   
   $  DBEntity:ApprovalCondition��60   .R�5*      �� $ 
Horizontal=�6   .+�5+      �� 8��  ��6     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6�   5,      5-      5.       J� CommandBindings 50      )  #System.Windows.Input.CommandBinding  51   
   -   5           Command# [ 51      52   :     53   
   -   5        # [ 53      54   >   .��57      �� $
��Auto=�6   $
��Auto=�68   .��58   
   � -   5        $��rootGrid��58       � RowDefinitions 59      �� 5:      $
��Auto �6    �� 5;      $
��Auto �6    �� 5<      $
��Auto �6    �� 5=      $��* �6    .+�5?      �� -   5        $��lbTitle��5?   X   $��32��6g   $
��Left=�6s   $��6,6,0,0q�6�   $
��auto��5@      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5?        $! Client.Properties.Resources��$ Approval��5@   K   �� 5A      -   5        $��label1��5A   �   $��28��6T   $
��Left=�6`   $��6,38,0,0q�6{   $	��Top=�5B      
���<����5A        $! Client.Properties.Resources��$
 Name��5B   ,   �� 5C      -   5        $��textBox1��5C   Q   $��23��6   $
��Left=�6"   $��
122,40,0,0q�6=   $	��Top=�6a   $	��120��5D       �� 	MaxLength$ 20��68   ��6"   �� *Name+68   �� 5E      -   5        $��label2��5E   �   $
��Left=�6\   $��
278,38,0,0q�6w   $	��Top=�6�   
���<����6     $! Client.Properties.Resources��$ DocumentType��6�   �� 5F      -   5        $��	comboBox1��5F   R   $��23��6   $
��Left=�6#   $��
394,40,0,0q�6>   $	��Top=�6c   $	��120��6{    �� SelectedValuePath$ Id��6�    �� DisplayMemberPath$
 Name��6�   ��6�   �� *	Documents+ �� SelectedValue 5G      �� *
DocumentId+�� 5H      -	   5        $��label4��5H   �   $��28��6W   $
��Left=�6c   $��6,66,0,0q�6~   $	��Top=�5I      ��5H        $! Client.Properties.Resources��$ Default��5I      �� 5J      -
   5        $��	checkBox1��5J   ]   $�� ��6   $��16��6"   $
��Left=�6.   $��
122,72,0,0q�6I   $	��Top=�5K      {�6/   �� *ConditionEnabled+ �� 	Converter# [   d� 	IsChecked 5L      �� *	IsDefault+�� 5M      -   5        $��label3��5M   �   $��28��6X   $
��Left=�6d   $��6,95,0,0q�6   $	��Top=�5N      ��5M        $! Client.Properties.Resources��$ Comments��5N      �� 5O      -   5        $��textBox2��5O   R   $	��100��6   $
��Left=�6#   $��
122,97,0,0q�6>   $	��Top=�6b   $	��392��5P       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�67   " �� VerticalScrollBarVisibility$
 Auto=�6K   ��6n   �� *Description+9� 5Q      -   5        $��	expander1��5R      $��1��5Q      $
��Auto��6F   $
��Left=�6T   $��	122,9,0,0q�6o   $	��Top=�5R   (   $	��392��6@    9� 
IsExpanded . ��5Q   $     *ApprovalCondition+.��5S      � .+�5T      �� -   5        $��button4��5T   �   $��23��6f   $
��Left=�6r   $��0,6,0,0q�6�   $	��Top=�5U      $��45��65   ��5T        $! Client.Properties.Resources��$ AddWithSymbol��{�5U   U   �� *ConditionEnabled+&   System.Windows.Controls.DataGrid  5V      -   5        $��	dataGrid2��5W         AutoGenerateColumns .  $��0,38,0,0q�5V   ;      
IsReadOnly .   DataGridStyle#��[ 5X   @     DataGridRowStyle   RowStyle# [ 6g   $
��Left=�6�   $
��auto��6�   $
��auto��6�   $	��Top=�6�   ��5W   0   �� *
Conditions+   Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .   DataGridColumnHeaderStyle   HeaderStyle# [ 6�       Header  61     $! Client.Properties.Resources��$ Currency��1	  +System.Windows.Controls.DataGridBoundColumn! 	  Binding! 6t   �� *Currency.Name+6�     5[       . # [ 6�     61     $B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��$ Floor��! 6�   �� *
LowerLimit+6�     5\       .  # [ 6�     61     $B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��$ Ceiling��! 6�   �� *
UpperLimit+6  4
  .System.Windows.Controls.DataGridTemplateColumn
  5]      " 
  CellTemplate#" [ 6y   # [ 6�     65     $! Client.Properties.Resources��$ 	Operation��6�   5_      5`      5a      9� 5b      -   5        $��	expander2��5c      $��2��5b      $
��auto��6B   $��	122,6,0,0q�6P    . $	��Top=�5c   :   $
��Left=�6R   $	��392��6m   ��5b   $     *ApprovalStage+.��5d      � .+�5e      �� -   5        $��button1��5e   �   $��23��6f   $
��Left=�6r   $��1,6,0,0q�6�   $	��Top=�5f      $��45��65   ��5e        $! Client.Properties.Resources��$ AddWithSymbol��5f   @     5g      -   5        $��	dataGrid1��5h       .  $
��Auto��5g   ;   $
��Left=�6I   $��1,38,0,0q�6d   $	��Top=�5h   0   $
��Auto��6H    . #��[ 5i      # [ 6F   ��5h   U   �� *Stages+ 5j        5k       . # [ 6�     61     $! Client.Properties.Resources��$ Number��! 6r   �� *
StageIndex+6�     5l       .  # [ 6�     61     $B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��$ Approver��! 6�   �� *ApprovalUser.Name+6
  
  5m      #" [ 6y   # [ 6�     65     $! Client.Properties.Resources��$ 	Operation��6�   5o      5p      5q      �� 5r      -   5        $��button2��5r   �   $��3��6U   $��25��6b   $
��Left=�6n   $��
210,25,0,0q�6�   $	��Top=�5s      $��60��6-   ��5r        $! Client.Properties.Resources��$
 Save��5s   8   �� 5t      -   5        $��button3��5t   �   $��3��6W   $��25��6d   $
��Left=�6p   $��
305,25,0,0q�6�   $	��Top=�5u      $��60��6-   ��5t        $! Client.Properties.Resources��$ Cancel��5u   8   5w      5x      5z      