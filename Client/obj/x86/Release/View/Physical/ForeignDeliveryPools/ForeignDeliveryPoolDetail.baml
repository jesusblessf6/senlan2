   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5(clr-namespace:DBEntity;assembly=DBEntityDBEntity I    CClient.View.Physical.ForeignDeliveryPools.ForeignDeliveryPoolDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5base$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     =dbEntity(clr-namespace:DBEntity;assembly=DBEntity       N� Title$  ForeignDeliveryPoolDetail�� � 	Resources    DetailLineEdit  DetailLineDelete  AttachmentDelete  AttachmentDownload  StorageDateEdit  StorageDateDelete��%Z   &	        &	      &	 
     &	      &	      &	      �� �� �� �� �� ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��lbTitle��$��PlaceHolder��$��32��$
��Bold"�$��16(�$
��Left=�$��6,6,0,0q�$	��Top=��� -	   $��lbDeliveryNo��$��28��$
��Left=�$��	46,38,0,0q�$	��Top=�
���<������ *DeliveryNoContent+ �� Mode$ OneWay=��� -
   $��textBox1��$��23��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120�� �� 	MaxLength$ 50������ *
DeliveryNo+�� -   $��label2��$��金属��$��28��$
��Left=�$��
355,38,0,0q�$	��Top=�
���<���� -   $��cbCommodity��$��23��$
��Left=�$��
395,40,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Commodities+	 �� SelectedValue	 �� *SelectedCommodityId+{��� *IsCommodityEnable+�� -   $��label3��$��单据类型��$��28��$
��Left=�$��	58,70,0,0q�$	��Top=��� -   $��textBox2��$��23��$
��Left=�$��
122,72,0,0q�$	��Top=�$	��120��
 �� 
IsReadOnly
 . ���� *DeliveryTypeName+�� -   $��label4��$��	发货人��$��28��$
��Left=�$��70,0,0,0q�$	��Top=�$��1��y��� *VisibilityForBL+$ OneWay=��� -   $��textBox3��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��120��{�.  $��1������ *ShipperName+y��� *VisibilityForBL+$ OneWay=��� -   $��button1��$	��...��$��23��$
��Left=�$��	246,2,0,0q�$	��Top=�$��27��$��1��y��� *VisibilityForBL+$ OneWay=��� -   $��label5��$��船号��$��28��$
��Left=�$��	355,0,0,0q�$	��Top=�$��1��y��� *VisibilityForBL+$ OneWay=��� -   $��textBox4��$��23��$
��Left=�$��	395,2,0,0q�$	��Top=�$	��120��$��1��$ 50������ *
VesselNo+y��� *VisibilityForBL+$ OneWay=��� -   $��label6��$��	承运商��$��28��$
��Left=�$��	70,32,0,0q�$	��Top=�$��1��y��� *VisibilityForBL+$ OneWay=��� -   $��textBox5��$��23��$
��Left=�$��
122,34,0,7q�$	��Top=�$	��120��{�.  $��1������ *ShipperPartyName+y��� *VisibilityForBL+$ OneWay=��� -   $��button2��$	��...��$��23��$
��Left=�$��
246,34,0,7q�$	��Top=�$��27��$��1��y��� *VisibilityForBL+$ OneWay=��� -   $��label7��$��	通知人��$��28��$
��Left=�$��
343,32,0,0q�$	��Top=�$��1��y��� *VisibilityForBL+$ OneWay=��� -   $��textBox6��$��23��$
��Left=�$��
395,34,0,7q�$	��Top=�$	��120��{�.  $��1������ *NotifyPartyName+y��� *VisibilityForBL+$ OneWay=��� -   $��button3��$	��...��$��23��$
��Left=�$��
519,34,0,7q�$	��Top=�$��27��$��1��y��� *VisibilityForBL+$ OneWay=��� -   $��label8��$��开具日期��$��28��$
��Left=�$��58,0,0,0q�$	��Top=�
���<��$��2��(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��	122,2,0,7q�$	��Top=�$	��120��$��2��   SelectedDate �� *	IssueDate+�� -   $��label9��$��装运日期��$��28��$
��Left=�$��	331,0,0,0q�$	��Top=�$��2��y��� *VisibilityForBL+$ OneWay=�  -   $��datePicker2��$��25��$
��Left=�$��	395,2,0,7q�$	��Top=�$	��120��$��2�� �� *OnBoardDate+y��� *VisibilityForBL+$ OneWay=��� -   $��label16��$��	仓储商��$��28��$
��Left=�$��70,0,0,0q�$	��Top=�$��3��y��� *VisibilityForWR+$ OneWay=��� -   $��textBox8��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��120��{�.  $��3������ *WarehouseProviderName+y��� *VisibilityForWR+$ OneWay=��� -    $��button5��$	��...��$��23��$
��Left=�$��	246,2,0,0q�$	��Top=�$��27��$��3��y��� *VisibilityForWR+$ OneWay=��� -!   $��label17��$��仓库��$��28��$
��Left=�$��	355,0,0,0q�$	��Top=�$��3��
���<��y��� *VisibilityForWR+$ OneWay=��� -"   $��textBox9��$��23��$
��Left=�$��	395,2,0,0q�$	��Top=�$	��120��{�.  $��3������ *WarehouseName+y��� *VisibilityForWR+$ OneWay=��� -#   $��button6��$	��...��$��23��$
��Left=�$��	519,2,0,0q�$	��Top=�$��27��$��3��y��� *VisibilityForWR+$ OneWay=��� -$   $��label1��$��仓储日期明细��$��3��$��28��$
��Left=�$��	34,32,0,0q�$	��Top=�y��� *VisibilityForWR+$ OneWay=��� -%   $��button10��$��+新增��$��23��$
��Left=�$��
122,34,0,0q�$	��Top=�$��55��$��3��y��� *VisibilityForWR+$ OneWay=�&   System.Windows.Controls.DataGrid  -&   $��dgStorageDates��   AutoGenerateColumns .  $��3��$
��Auto��$
��Left=�$��
122,66,0,7q�   
IsReadOnly . $	��Top=�$
��Auto������ *StorageDates+y��� *VisibilityForWR+$ OneWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 起始日期��   CanUserSort .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	StartDate+ �� StringFormat$ {0:yyyy-MM-dd}��  $ 截止日期�� . $
 Auto  �� *	EndDate+$ {0:yyyy-MM-dd}��4  .System.Windows.Controls.DataGridTemplateColumn  $ 操作��   CellTemplate ��  �� DataType$" dbEntity:FDPStorageFeeSEDate��.R���  �� Orientation$ 
Horizontal=�.+��� $��编辑��#��[ ���� *Id+�� $��删除��#��[ ���� *Id+�� -'   $��label10��$��打包规格��$��28��$
��Left=�$��
331,70,0,0q�$	��Top=��� -(   $��textBox7��$��23��$
��Left=�$��
395,72,0,0q�$	��Top=�$	��120��$ 50������ *PackingStandard+�� -)   $��label11��$��28��$
��Left=�$��70,0,0,0q�$	��Top=�$��	装运地��$��4��y��� *VisibilityForBL+$ OneWay=��� -*   $��	comboBox2��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��120��$��4��$ ChineseName��$ Id������ *	Countries+	 �� *SelectedLoadingPlaceId+y��� *VisibilityForBL+$ OneWay=��� -+   $��label12��$��	卸货地��$��28��$
��Left=�$��	343,0,0,0q�$	��Top=�$��4��y��� *VisibilityForBL+$ OneWay=��� -,   $��	comboBox3��$��23��$
��Left=�$��	395,2,0,0q�$	��Top=�$	��120��$��4��$ ChineseName��$ Id������ *	Countries+	 �� *SelectedDischargePlaceId+y��� *VisibilityForBL+$ OneWay=��� --   $��label13��$��	装运港��$��28��$
��Left=�$��	70,32,0,0q�$	��Top=�$��4��y��� *VisibilityForBL+$ OneWay=��� -.   $��	comboBox4��$��23��$
��Left=�$��
122,34,0,7q�$	��Top=�$	��120��$��4��$
 Name��$ Id������ *LoadingPorts+	 �� *SelectedLoadingPortId+y��� *VisibilityForBL+$ OneWay=��� -/   $��label14��$��	卸货港��$��28��$
��Left=�$��
343,32,0,0q�$	��Top=�$��4��y��� *VisibilityForBL+$ OneWay=��� -0   $��	comboBox5��$��23��$
��Left=�$��
395,34,0,7q�$	��Top=�$	��120��$��4��$
 Name��$ Id������ *DischargePorts+	 �� *SelectedDischargePortId+y��� *VisibilityForBL+$ OneWay=��� -1   $��label15��$��明细��$��28��$
��Left=�$��82,0,0,0q�$	��Top=�$��5���� -2   $��button4��$��+新增��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��55��$��5��{��� *IsLineNewBtnEnable+  -3   $��dgDetail�� .   . $
��Auto��$
��Left=�$��
122,34,0,7q�$	��Top=�$
��Auto��$��5������ *	Details+   $ 金属类型��$
 Auto  .  �� *CommodityType.Name+  $ 金属品牌��$
 Auto  .  �� *
Brand.Name+  $ 	原产地��$
 Auto  .  �� *OriginCountry.Name+  $ 净重��$
 Auto  .  �� *	NetWeight+$	  DBEntity.EnumEntity.RoundRules 	  STR_QUANTITY# Z   $ 毛重��$
 Auto  .  �� *GrossWeight+# Z   $ 捆数��$
 Auto  .  �� *PackingQuantity+ 	  STR_INTEGER# Z   $ 备注��$
 Auto  .  �� *	Comment+  $ 操作��$
 Auto  .   �� $&  dbEntity:ForeignDeliveryPoolLine��.R��� $ 
Horizontal=�.+��� $��编辑��#��[  ���� *Id+�� $��删除��#��[ ���� *Id+�� -4   $��label18��$��附件��$��6��$��28��$
��Left=�$��82,0,0,0q�$	��Top=��� -5   $��button7��$��+新增��$��6��$��23��$
��Left=�$��	122,2,0,0q�$	��Top=�$��55��  -6   $��dgAttachment�� .  $��6��$
��Auto��$
��Left=�$��
122,34,0,7q�$	��Top=�$
��Auto�� . ���� *Attachments+   $ 	附件名�� . $
 Auto  �� *Name+  $ 操作�� .  $
 Auto  �� $ dbEntity:Attachment��.R��� $ 
Horizontal=�.+��� $��下载��#��[ ���� *Id+�� $��删除��#��[ ���� *Id+�� -7   $��label19��$��备注��$��7��$��28��$
��Left=�$��82,0,0,0q�$	��Top=��� -8   $��	textBox10��$��7��$	��107��$
��Left=�$��	122,2,0,0q�$	��Top=�$	��393�� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *
Comments+�� -9   $��button8��$��保存��$��7��$��23��$
��Left=�$��210,140,0,0q�$	��Top=�$��60���� -:   $��button9��$��取消��$��7��$��23��$
��Left=�$��305,140,0,0q�$	��Top=�$��60��