   M S B A M L   `   `   `  ���� C  ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient @   :Client.View.SystemSetting.WarehouseSetting.WarehouseDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      L
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$D  >Client.View.SystemSetting.WarehouseSetting.ResWarehouseSetting��$
��auto��$	��600�� � WindowStartupLocation$ CenterScreen=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title      ResxName$! Client.Properties.Resources��
   Key$ 	Warehouse�� � 	Resources  �� 
TargetType �� Property	 �� Value   StorageFeeRuleEdit  StorageFeeRuleDelete  StorageFeeRulesActions
 �� DataType �� Orientation��%�  '��       '�� S     &	  �     &	 �     &	 �     7   7  �� " ��.���  � ��$	 28����  � ��$		 110����  � ��$	 Right=��� " ��.���  � ��$	 23����  � ��$		 120���� �� �� $
 DBEntity:StorageFeeRule��.R��� $ 
Horizontal=�.+��� $��btStorageFeeRuleEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btStorageFeeRuleDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $	��195 ��� $��34 ��� $
��auto ��� $	��55* �.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  $! Client.Properties.Resources��$ 	Warehouse���� -   $��label2��$��6,38,0,0q�
���<��$
��Left=�$	��Top=���  *	ShortName+�� -   $��textBox1��$��
122,40,0,0q� �� 	MaxLength$ 20��$
��Left=�$	��Top=����� *Name+�� -   $��label3��$��6,70,0,0q�$
��Left=�$	��Top=���  *
FullName+�� -   $��textBox2��$��23��$
��Left=�$��
122,72,0,0q�$	��Top=�$	��392��$ 50������ *
FullName+�� -	   $��label4��$��	6,102,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ ContactPerson���� -
   $��textBox3��$��122,104,0,0q�$ 20��$
��Left=�$	��Top=����� *ContactPerson+�� -   $��label8��$��278,102,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$	 Tel���� -   $��textBox7��$��394,104,0,0q�$ 20��$
��Left=�$	��Top=����� *Phone+�� -   $��label5��$��	6,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$	 Fax���� -   $��textBox4��$
��Left=�$��122,136,0,0q�$	��Top=�$ 20������ *Fax+�� -   $��label1��$��278,134,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ PostCode���� -   $��textBox8��$
��Left=�$��394,136,0,0q�$	��Top=�$ 10������ *
PostCode+�� -   $��label6��$��	6,166,0,0q�$
��Left=�$	��Top=���  *	Address+�� -   $��textBox5��$��23��$
��Left=�$��122,168,0,0q�$	��Top=�$	��392��$	 200������ *	Address+�� -   $��label7��$��3��$��6,6,0,0q�$
��Left=�$	��Top=���  $! Client.Properties.Resources��$ Comments���� -   $��textBox6��$	��100��$
��Left=�$��	122,8,0,0q�$	��Top=�$	��392�� �� 
AcceptsTab .   �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$	 200��$��3������ *Description+�� -   $
��btOK��$��25��$
��Left=�$��210,123,0,0q�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$ Confirm���� -   $��btCancel��$��25��$
��Left=�$��305,123,0,0q�$	��Top=�$��60��$��3����  $! Client.Properties.Resources��$ Cancel���� -   $��label9��$��币种��
���<��$��28��$
��Left=�$��
320,35,0,0q�$	��Top=�$��68���� -   $��	comboBox1��$��23��$
��Left=�$��
394,35,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *CurrencyList+ �� SelectedValue �� *
CurrencyId+�� -   $��label10��$��	仓储费��$��28��$
��Left=�$��6,0,0,2q�$��Bottom=�$	��110��$��1���� -   $��button1��$��新增��$��23��$��1��$
��Left=�$��	122,0,0,6q�$��Bottom=�$��45��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��auto��$��2��$
��Left=�$��	122,0,0,0q�$��Bottom=�$
��auto��   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 金属��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Commodity.Name+  $ 开始日期�� �� *	StartDate+ �� StringFormat$ 
yyyy/MM/dd��  $ 结束日期�� �� *	EndDate+$ 
yyyy/MM/dd��  $ 仓租单价�� �� *PricePerUnit+$   DBEntity.EnumEntity.RoundRules   	STR_PRICE# Z   $ 货权转移费�� �� *TransferFee+# Z   $ 	仓单费�� �� *
WarrantFee+# Z 4	  .System.Windows.Controls.DataGridTemplateColumn	     Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
    CanUserSort .    	  CellTemplate#  [    $! Client.Properties.Resources��$ 	Operation��