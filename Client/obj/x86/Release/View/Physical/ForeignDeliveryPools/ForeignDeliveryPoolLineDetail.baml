   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity M    GClient.View.Physical.ForeignDeliveryPools.ForeignDeliveryPoolLineDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5base$clr-namespace:Client.Base.BaseClient     >my/clr-namespace:Utility.Controls;assembly=Utility     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity       � Title$#  ForeignDeliveryPoolLineDetail��$	��396��$	��582��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��PlaceHolder��$��32��$
��Bold"�$��16(�$
��Left=�$��6,6,0,0q�$	��Top=��� -   $��label1��$��金属类型��$��28��$
��Left=�$��	55,38,0,0q�$	��Top=�
���<���� -   $��	comboBox1��$��23��$
��Left=�$��
122,40,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *CommodityTypes+ �� SelectedValue �� *SelectedCommodityTypeId+�� -   $��label2��$��金属品牌��$��28��$
��Left=�$��
331,38,0,0q�$	��Top=��� -   $��	comboBox2��$��23��$
��Left=�$��
395,40,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *Brands+ �� *SelectedBrandId+�� -   $��label3��$��规格��$��28��$
��Left=�$��	79,70,0,0q�$	��Top=��� -   $��	comboBox3��$��23��$
��Left=�$��
122,72,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *Specifications+ �� *SelectedSpecificationId+�� -	   $��label4��$��卡号��$��28��$
��Left=�$��
355,70,0,0q�$	��Top=�y��� *VisibilityForWR+ �� Mode$ OneWay=��� -
   $��textBox1��$��23��$
��Left=�$��
395,72,0,0q�$	��Top=�$	��120������ *PBNo+y��� *VisibilityForWR+$ OneWay=��� -   $��label5��$��净重��$��28��$
��Left=�$��
79,102,0,0q�$	��Top=�&   Utility.Controls.CurrencyTextBox  -   $��currencyTextBox1��$��23��$
��Left=�$��122,104,0,0q�$	��Top=�$	��120��   Text �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z �� -   $��label6��$��毛重��$��28��$
��Left=�$��355,102,0,0q�$	��Top=�  -   $��currencyTextBox2��$��23��$
��Left=�$��395,104,0,0q�$	��Top=�$	��120�� �� *GrossWeight+# Z �� -   $��label7��$��	原产地��$��28��$
��Left=�$��
67,134,0,0q�$	��Top=��� -   $��	comboBox4��$��23��$
��Left=�$��122,136,0,0q�$	��Top=�$	��120��$ ChineseName��$ Id������ *	Countries+ �� *SelectedCountryId+�� -   $��label8��$��捆数��$��28��$
��Left=�$��355,134,0,0q�$	��Top=�  -   $��currencyTextBox3��$��23��$
��Left=�$��395,136,0,0q�$	��Top=�$	��120�� �� *PackingQuantity+# Z �� -   $��label9��$��备注��$��28��$
��Left=�$��
79,166,0,0q�$	��Top=��� -   $��textBox2��$��99��$
��Left=�$��122,168,0,0q�$	��Top=�$	��393�� �� 
IsReadOnly .  	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=����� *
Comments+�� -   $��button1��$��保存��$��23��$
��Left=�$��210,300,0,0q�$	��Top=�$��60���� -   $��button2��$��取消��$��23��$
��Left=�$��305,300,0,0q�$	��Top=�$��60��