   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity A   ;Client.View.SystemSetting.WarehouseSetting.StorageFeeDetail   6my/clr-namespace:Utility.Controls;assembly=Utility  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut�� � Title$ StorageFeeDetail��$	��258��$	��574�� � 
ResizeMode$ NoResize=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension  .��� -    �Name$ rootGrid�� � RowDefinitions �� $
��129* ��� $	��90* �.+��� -   $��label10��$��仓储费明细��$��32��$
��Left=�$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(��� -   $��label1��$��开始日期��
���<��$��28��$
��Left=�$��	60,41,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120��   SelectedDate �� *	StartDate+�� -   $��label2��$��结束日期��
���<��$��28��$
��Left=�$��
330,40,0,0q�$	��Top=�  -   $��datePicker2��$��25��$
��Left=�$��
394,40,0,0q�$	��Top=�$	��120�� �� *	EndDate+�� -   $��label3��$��金属��
���<��$��28��$
��Left=�$��	82,73,0,0q�$	��Top=��� -   $��	comboBox1��$��23��$
��Left=�$��
122,74,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *CommodityList+	 �� SelectedValue	 �� *CommodityID+�� -	   $��label4��$��仓租单价��$��28��$
��Left=�$��
330,73,0,0q�$	��Top=�&    Utility.Controls.CurrencyTextBox  -
   $��currencyTextBox1��$��23��$
��Left=�$��
394,74,0,0q�$	��Top=�$	��120��
   Text
 �� *PricePerUnit+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z �� -   $��label5��$��	仓单费��$��28��$
��Left=�$��
72,104,0,0q�$	��Top=�$��2��  -   $��currencyTextBox2��$��23��$
��Left=�$��122,106,0,0q�$	��Top=�$	��120��
 �� *
WarrantFee+# Z �� -   $��label6��$��货权转移费��$��26��$
��Left=�$��318,104,0,0q�$	��Top=�$��2��  -   $��currencyTextBox3��$��23��$
��Left=�$��394,106,0,0q�$	��Top=�$	��120��
 �� *TransFerFee+# Z �� -   $��button1��$��确定��$��23��$
��Left=�$��
210,25,0,0q�$	��Top=�$��60��$��1���� -   $��button2��$��取消��$��23��$
��Left=�$��
305,25,0,0q�$	��Top=�$��60��$��1��