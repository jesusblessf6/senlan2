   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   	   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5	      A   ;Client.View.SystemSetting.WarehouseSetting.StorageFeeDetail   5      6my/clr-namespace:Utility.Controls;assembly=Utility  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$8  2Client.View.Physical.WarehouseOuts.ResWarehouseOut��5       � Title$ StorageFeeDetail��5
      $	��258��5      $	��574��6%    � 
ResizeMode$ NoResize=�61    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension  .��5      � -   5         �Name$ rootGrid��5       � RowDefinitions 5   
   �� 5      $
��129* �6   �� 5      $	��90* �6   .+�5   
   �� -   5        $��label10��5       $��仓储费明细��6   $��32��6/   $
��Left=�6;   $
��Left=�6^   $��6,6,0,0q�6y   $
��auto��6�   $	��Top=�5      $
��Bold"�6(   $��16(�6:   �� 5   
   -   5        $��label1��5   n   $��开始日期��6   
���<��$��28��64   $
��Left=�6@   $��	60,41,0,0q�6[   $	��Top=�6|   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   P   $��25��6   $
��Left=�6!   $��
122,40,0,0q�6<   $	��Top=�6c   $	��120��6{      SelectedDate 6�   �� *	StartDate+�� 5   
   -   5        $��label2��5   o   $��结束日期��6   
���<��$��28��64   $
��Left=�6@   $��
330,40,0,0q�6[   $	��Top=�6}     5   
   -   5        $��datePicker2��5   P   $��25��6   $
��Left=�6!   $��
394,40,0,0q�6<   $	��Top=�6c   $	��120��6{    6�   �� *	EndDate+�� 5   
   -   5        $��label3��5   l   $��金属��6   
���<��$��28��62   $
��Left=�6>   $��	82,73,0,0q�6Y   $	��Top=�6z   �� 5   
   -   5        $��	comboBox1��5   N   $��23��6   $
��Left=�6   $��
122,74,0,0q�6:   $	��Top=�6_   $	��120��6w    �� SelectedValuePath$ Id��6�    �� DisplayMemberPath$
 Name��6�   ��6�   �� *CommodityList+	 �� SelectedValue	 5      �� *CommodityID+�� 5   
   -	   5        $��label4��5   Z   $��仓租单价��6   $��28��6   $
��Left=�6+   $��
330,73,0,0q�6F   $	��Top=�6h   &    Utility.Controls.CurrencyTextBox  5   
   -
   5        $��currencyTextBox1��5   X   $��23��6   $
��Left=�6)   $��
394,74,0,0q�6D   $	��Top=�6p   $	��120��6�   
   Text
 6�   �� *PricePerUnit+$  DBEntity.EnumEntity.RoundRules   	STR_PRICE �� StringFormat# Z �� 5   
   -   5        $��label5��5   Y   $��	仓单费��6   $��28��6   $
��Left=�6*   $��
72,104,0,0q�6E   $	��Top=�6g   $��2��6     5   
   -   5        $��currencyTextBox2��5   Y   $��23��6   $
��Left=�6)   $��122,106,0,0q�6D   $	��Top=�6q   $	��120��6�   
 6�   �� *
WarrantFee+# Z �� 5   
   -   5        $��label6��5   \   $��货权转移费��6   $��26��6    $
��Left=�6,   $��318,104,0,0q�6G   $	��Top=�6j   $��2��6�     5   
   -   5        $��currencyTextBox3��5   Y   $��23��6   $
��Left=�6)   $��394,106,0,0q�6D   $	��Top=�6q   $	��120��6�   
 6�   �� *TransFerFee+# Z �� 5    
   -   5        $��button1��5    Y   $��确定��6   $��23��6   $
��Left=�6*   $��
210,25,0,0q�6E   $	��Top=�6h   $��60��6�   $��1��6�   �� 5!   
   -   5        $��button2��5!   Y   $��取消��6   $��23��6   $
��Left=�6*   $��
305,25,0,0q�6E   $	��Top=�6h   $��60��6�   $��1��6�   5"      5#      