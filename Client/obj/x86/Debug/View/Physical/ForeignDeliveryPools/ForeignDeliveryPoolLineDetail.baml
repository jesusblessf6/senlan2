   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5   	   B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   	   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5   	   M    GClient.View.Physical.ForeignDeliveryPools.ForeignDeliveryPoolLineDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5base$clr-namespace:Client.Base.BaseClient     5   	   >my/clr-namespace:Utility.Controls;assembly=Utility     5   	   J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5   	     � Title$#  ForeignDeliveryPoolLineDetail��5   	   $	��396��6/   $	��582��6<   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5	   
   � -   5        $��rootGrid��5	      .+�5
      �� -   5        $��lbTitle��5
   �   $��PlaceHolder��6   $��32��6*   $
��Bold"�66   $��16(�6H   $
��Left=�6V   $��6,6,0,0q�6q   $	��Top=�6�   �� 5      -   5        $��label1��5   ]   $��金属类型��6   $��28��6#   $
��Left=�6/   $��	55,38,0,0q�6J   $	��Top=�6k   
���<��6�   �� 5      -   5        $��	comboBox1��5   R   $��23��6   $
��Left=�6#   $��
122,40,0,0q�6>   $	��Top=�6c   $	��120��6{    �� DisplayMemberPath$
 Name��5   >    �� SelectedValuePath$ Id��6W   ��6   �� *CommodityTypes+ �� SelectedValue 5      �� *SelectedCommodityTypeId+�� 5      -   5        $��label2��5   ^   $��金属品牌��6   $��28��6#   $
��Left=�6/   $��
331,38,0,0q�6J   $	��Top=�6l   �� 5      -   5        $��	comboBox2��5   R   $��23��6   $
��Left=�6#   $��
395,40,0,0q�6>   $	��Top=�6c   $	��120��6{   $
 Name��5   6   $ Id��6O   ��6   �� *Brands+ 6f   �� *SelectedBrandId+�� 5      -   5        $��label3��5   [   $��规格��6   $��28��6!   $
��Left=�6-   $��	79,70,0,0q�6H   $	��Top=�6i   �� 5      -   5        $��	comboBox3��5   R   $��23��6   $
��Left=�6#   $��
122,72,0,0q�6>   $	��Top=�6c   $	��120��6{   $
 Name��5   >   $ Id��6W   ��6   �� *Specifications+ 6n   �� *SelectedSpecificationId+�� 5      -	   5        $��label4��5   \   $��卡号��6   $��28��6!   $
��Left=�6-   $��
355,70,0,0q�6H   $	��Top=�6j   y�5      �� *VisibilityForWR+ �� Mode$ OneWay=��� 5      -
   5        $��textBox1��5   Q   $��23��6   $
��Left=�6"   $��
395,72,0,0q�6=   $	��Top=�6a   $	��120��6y   ��5      �� *PBNo+y�6,   �� *VisibilityForWR+$ OneWay=��� 5      -   5        $��label5��5   \   $��净重��6   $��28��6!   $
��Left=�6-   $��
79,102,0,0q�6H   $	��Top=�6j   &   Utility.Controls.CurrencyTextBox  5      -   5        $��currencyTextBox1��5   ]   $��23��6!   $
��Left=�6-   $��122,104,0,0q�6H   $	��Top=�6u   $	��120��6�      Text 5   &   �� *	NetWeight+$  DBEntity.EnumEntity.RoundRules   STR_QUANTITY �� StringFormat# Z �� 5      -   5        $��label6��5   ]   $��毛重��6   $��28��6!   $
��Left=�6-   $��355,102,0,0q�6H   $	��Top=�6k     5      -   5        $��currencyTextBox2��5   ]   $��23��6!   $
��Left=�6-   $��395,104,0,0q�6H   $	��Top=�6u   $	��120��6�    5   !   �� *GrossWeight+# Z �� 5      -   5        $��label7��5   ]   $��	原产地��6   $��28��6"   $
��Left=�6.   $��
67,134,0,0q�6I   $	��Top=�6k   �� 5       -   5        $��	comboBox4��5    S   $��23��6   $
��Left=�6#   $��122,136,0,0q�6>   $	��Top=�6d   $	��120��6|   $ ChineseName��5!   9   $ Id��6Y   ��6   �� *	Countries+ 6p   �� *SelectedCountryId+�� 5"      -   5        $��label8��5"   ]   $��捆数��6   $��28��6!   $
��Left=�6-   $��355,134,0,0q�6H   $	��Top=�6k     5#      -   5        $��currencyTextBox3��5#   ]   $��23��6!   $
��Left=�6-   $��395,136,0,0q�6H   $	��Top=�6u   $	��120��6�    5$   !   �� *PackingQuantity+# Z �� 5%      -   5        $��label9��5%   \   $��备注��6   $��28��6!   $
��Left=�6-   $��
79,166,0,0q�6H   $	��Top=�6j   �� 5&      -   5        $��textBox2��5&   R   $��99��6   $
��Left=�6"   $��122,168,0,0q�6=   $	��Top=�6b   $	��393��6z    �� 
IsReadOnly .  	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��5'      �� *
Comments+�� 5(      -   5        $��button1��5(   ^   $��保存��6   $��23��6"   $
��Left=�6.   $��210,300,0,0q�6I   $	��Top=�6m   $��60��6�   6�   �� 5)      -   5        $��button2��5)   ^   $��取消��6   $��23��6"   $
��Left=�6.   $��305,300,0,0q�6I   $	��Top=�6m   $��60��6�   6�   5*      5+      5,      