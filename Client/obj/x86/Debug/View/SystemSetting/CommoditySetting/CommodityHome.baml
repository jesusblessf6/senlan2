   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      >    8Client.View.SystemSetting.CommoditySetting.CommodityHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$D  >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5           ResxName$! Client.Properties.Resources��
   Key$ 	Commodity�� � 	Resources 5         CommodityTypeEdit  CommodityTypeDelete  CommodityTypeView  	BrandEdit  BrandDelete  	BrandView  SpecificationEdit  SpecificationDelete  SpecificationView,   &Client.Converters.BoolReverseConverter 	 BoolConverter 
 CommodityTypeActions �� DataType �� Orientation �� 	Converter  CommodityTypeLink	 �� Command
 �� CommandParameter  BrandActions  	BrandLink  SpecificationActions  SpecificationLink��%S  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     7   7 	 7  7 	 &	 �    7  &	 9    7  7  &	 �    7  &	 P    7  7  &	 �    7  �� 5   
   64   �� 5   
   66   �� 5   
   64   �� 5   
   6,   �� 5   
   6.   �� 5   
   6,   �� 5   
   64   �� 5   
   66   �� 5   
   64     5   
   5      �� 5!   
   $ DBEntity:CommodityType��64   .R�5"      �� $ 
Horizontal=�6   .+�5#      �� $��btCommodityTypeEdit��6   8��  ��64     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+{�6�   �� *
IsSystem+8  6  �� 5$      $��btCommodityTypeDelete��6   8�� ��66     $! Client.Properties.Resources��$ Delete����6�   �� *Id+{�6�   �� *
IsSystem+8  6  5%      5&      �� 5(   
   $ DBEntity:CommodityType��61   .R�5)      �� �� 5*      8	   
 6I   �� *Id+.�6i   .�5+      �� �6   �� *Name+62   5,      5-      5.      �� 50   
   $ DBEntity:Brand��6,   .R�51      �� $ 
Horizontal=�6   .+�52      �� $��btBrandEdit��6   8��  ��6,     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6�   �� 53      $��btBrandDelete��6   8�� ��6.     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6�   54      55      �� 57   
   $ DBEntity:Brand��6)   .R�58      �� �� 59      8	   
 6A   �� *Id+.�6a   .�5:      �� �6   �� *Name+62   5;      5<      5=      �� 5?   
   $ DBEntity:Specification��64   .R�5@      �� $ 
Horizontal=�6   .+�5A      �� $��btSpecificationEdit��6   8��  ��64     $! Client.Properties.Resources��$
 Edit����6�   �� *Id+6�   �� 5B      $��btSpecificationDelete��6   8�� ��66     $! Client.Properties.Resources��$ Delete����6�   �� *Id+6�   5C      5D      �� 5F   
   $ DBEntity:Specification��61   .R�5G      �� �� 5H      8	   
 6I   �� *Id+.�6i   .�5I      �� �6   �� *Name+62   5J      5K      5L      5N       J� CommandBindings 5P      )  #System.Windows.Input.CommandBinding  5Q   
   -   5           Command# [  5Q      6�     5R   
   -   5        # [ 5R      6�     5S   
   -   5        # [ 5S      6�     5U   
   -   5        # [ 5U      6~     5V   
   -   5        # [ 5V      6�     5W   
   -   5        # [ 5W      6~     5Y   
   -   5        # [ 5Y      6�     5Z   
   -   5        # [ 5Z      6�     5[   
   -	   5        # [ 5[      6�   .��5^      �� $
��Auto=�6   $
��Auto=�68   .��5_   
   � -
   5        $��rootGrid��5_      .+�5`      �� -   5        $��lbTitle��5`   6   $��32��6E   $
��Left=�6Q   $��6,6,0,0q�6l   $
��auto��6}   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   ��6     *CommoditySetting+6�   �� 5a      -   5        $��tabControl1��5a   +   $��6,40,0,0q�6   $	��380��6>   $
��Auto��6N   $	��900��6\   $
��Left=�6h   $	��Top=�6�   .@�5b      �� -   5        $��tiCommodity��5b   ^   ��6     $! Client.Properties.Resources��$ 	Commodity��.��5c      � .+�5d      $  Utility.Controls.PagingControl  -   5        $��pagingControl1��5d   <   $��6,6,0,0q�6+   $��31��6R   $	��Top=�6^   $
��Left=�6v   &   System.Windows.Controls.DataGrid  5e      -   5        $��	dataGrid1��5e   z      AutoGenerateColumns .  $
��Auto��6?   $
��Left=�6M   $��6,43,0,0q�6h   $	��Top=�5f   %   $
��Auto��6=      
IsReadOnly . ��6J   �� *Commodities+   Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h   "   ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6y      CanUserSort .    Header 65     $! Client.Properties.Resources��$ 	Commodity��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6�   �� *Name+6�     5i   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ SHFEUnit�� 6�   �� *
SHFEUnit+6�     5j   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ SGEUnit�� 6�   �� *	SGEUnit+6�     5k   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ LMEUnit�� 6�   �� *	LMEUnit+6�     5l   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 
SHFELotQty�� 6�   �� *SHFEQtyPerHand+$  DBEntity.EnumEntity.RoundRules   STR_INTEGER �� StringFormat# Z 6    5m   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	SGELotQty�� 6�   �� *SGEQtyPerHand+# Z 6    5n   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	LMELotQty�� 6�   �� *LMEQtyPerHand+# Z 6    5o   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 
SHFEDelQty�� 6�   �� *SHFEQtyForDel+# Z 6    5p   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	SGEDelQty�� 6�   �� *SGEQtyForDel+# Z 6    5q   "   $
 Auto	 6�    .  65     $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	LMEDelQty�� 6�   �� *LMEQtyForDel+# Z 6  5s      5t      5u      �� 5v      -   5        $��tiCommodityType��5v   b   ��6     $! Client.Properties.Resources��$ CommodityType��.��5w      � .+�5x      �� -   5        $��button2��5x   �   $��23��6j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�6�   $��45��6�   ��6!     $! Client.Properties.Resources��$ AddWithSymbol��6�     5y      -   5        $��pagingControl2��5y   Y   $
��Left=�6+   $��	6,105,0,0q�6F   $	��Top=�6o   $��31��6�     5z      -   5        $��	dataGrid2��5z   {    .  $
��Auto��6?   $
��Left=�6M   $��	6,142,0,0q�6h   $	��Top=�5{   )   $
��Auto��6A    . ��6N   �� *CommodityTypes+ 5|      4  .System.Windows.Controls.DataGridTemplateColumn  5}   "      SortMemberPath$
 Name��6�   $
 Auto	 6�    .    CellTemplate# [ 6�    69     $! Client.Properties.Resources��$ CommodityType��6�     5~   "   $
 Auto	 6y    .  65     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *Commodity.Name+6�     5   "   $
 Auto	 6{    .  65     $! Client.Properties.Resources��$ EnglishName�� 6�   �� *EnglishName+6�     5�   "   $
 Auto	 6x    .  65     $! Client.Properties.Resources��$ Comments�� 6�   �� *Description+6�     5�   "   $
 Auto	 6}    .  # [
 6�    69     $! Client.Properties.Resources��$ 	Operation��6�   5�      �� 5�      -   5        $��	groupBox1��5�   �   $��65��6h   $
��Left=�6t   $��6,35,0,0q�6�   $	��Top=�6�   $	��550��6�   ��6#     $! Client.Properties.Resources��$ 
Conditions��.��5�      � .+�5�   "   �� -   5        $��	comboBox3��5�   �    �� DisplayMemberPath$
 Name��6+   $��23��6D   $
��Left=�6P   ��SearchCommodities6k   $��	92,12,0,0q�6�    �� SelectedValuePath$ Id��6�   $	��Top=�6�   $	��120��6
   �� SelectedValue 6�   �� *SearchCommodityId+6
  �� 5�   "   -   5        $��button5��5�   �   $��23��6j   $
��Left=�6v   $��
239,12,0,0q�6�   $	��Top=�6�   $��75��6�   ��6)     $! Client.Properties.Resources��$ Query��6�   �� 5�   "   -   5        $��label3��5�   �   $��28��6m   $��80��6y   $��Right=�6�   $
��Left=�6�   $��6,10,0,0q�6�   $	��Top=�6�   ��6(     $! Client.Properties.Resources��$ 	Commodity��6�   5�      5�      5�      5�      �� 5�      -   5        $��tiBrand��5�   Z   ��6     $! Client.Properties.Resources��$ Brand��.��5�      � -   5        $��nodeGrid��5�      .+�5�      �� -   5        $��button3��5�   �   $��23��6j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�6�   $��45��6�   ��6!     $! Client.Properties.Resources��$ AddWithSymbol��6�     5�      -   5        $��pagingControl3��5�   Y   $
��Left=�6+   $��	6,145,0,0q�6F   $	��Top=�6o   $��31��6�     5�      -   5        $��	dataGrid3��5�   {    .  $
��Auto��6?   $
��Left=�6M   $��	6,182,0,0q�6h   $	��Top=�5�   %   $
��Auto��6=    . ��6J   �� *Brands+ 5�        5�   "   $
 Name��69   $
 Auto	 6�    . # [ 6�    6O     $! Client.Properties.Resources��$ Brand��6�     5�   "   $
 Auto	 6y    .  65     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *Commodity.Name+6�     5�   "   $
 Auto	 6}    .  65     $! Client.Properties.Resources��$ CommodityType�� 6�   �� *CommodityType.Name+6�     5�   "   $
 Auto	 6}    .  65     $! Client.Properties.Resources��$ OriginCountry�� 6�   �� *Country.ChineseName+6�     5�   "   $
 Auto	 6x    .  65     $! Client.Properties.Resources��$ Comments�� 6�   �� *Description+6�     5�   "   $
 Auto	 6}    .  # [ 6�    69     $! Client.Properties.Resources��$ 	Operation��6�   5�      �� 5�      -   5        $��	groupBox2��5�   �   $	��105��6h   $
��Left=�6u   $��6,35,0,0q�6�   $	��Top=�6�   $	��580��6�   ��6#     $! Client.Properties.Resources��$ 
Conditions��.��5�      � .+�5�   "   �� -   5        $��	comboBox1��5�   e   $��23��6+   $
��Left=�67   $��	92,12,0,0q�6R   $	��Top=�6v   $	��120��6�   $
 Name��6�   $ Id��6�   ��SearchCommodities6�    6�   �� *SearchCommodityId+6  �� 5�   "   -   5        $��label1��5�   �   $��28��6m   $��80��6y   $��Right=�6�   $
��Left=�6�   $��6,10,0,0q�6�   $	��Top=�6�   ��6(     $! Client.Properties.Resources��$ 	Commodity��6�   �� 5�   "   -    5        $��label2��5�   �   $��28��6q   $	��100��6}   $��Right=�6�   $
��Left=�6�   $��
218,10,0,0q�6�   $	��Top=�6�   ��6(     $! Client.Properties.Resources��$ CommodityType��6�   �� 5�   "   -!   5        $��	comboBox2��5�   f   $��23��6+   $
��Left=�67   $��
324,12,0,0q�6R   $	��Top=�6w   $	��120��6�   $
 Name��6�   $ Id��6�   ��SearchCommodityTypes6�    6�   �� *SearchCommodityTypeId+6�   �� 5�   "   -"   5        $��button1��5�   �   $��23��6j   $
��Left=�6v   $��
470,12,0,0q�6�   $	��Top=�6�   $��75��6�   ��6)     $! Client.Properties.Resources��$ Query��6�   �� 5�   "   -#   5        $��label6��5�   �   $��28��6i   $
��Left=�6u   $��6,42,0,0q�6�   $	��Top=�6�   $��80��6�   $��Right=�6�   ��6(     $! Client.Properties.Resources��$ Brand��6�   �� 5�   "   -$   5        $��textBox1��5�   d   $��23��6*   $
��Left=�66   $��	92,44,0,0q�6Q   $	��Top=�6t   $	��120��6�   ��6�   �� *	BrandName+5�      5�      5�      5�      �� 5�      -%   5        $��tiSpecification��5�   b   ��6     $! Client.Properties.Resources��$ Specification��.��5�      � .+�5�      �� -&   5        $��button4��5�   �   $��23��6j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�6�   $��45��6�   ��6!     $! Client.Properties.Resources��$ AddWithSymbol��6�     5�      -'   5        $��pagingControl4��5�   Y   $
��Left=�6+   $��	6,105,0,0q�6F   $	��Top=�6o   $��31��6�     5�      -(   5        $��	dataGrid4��5�   {    .  $
��Auto��6?   $
��Left=�6M   $��	6,142,0,0q�6h   $	��Top=�5�   %   $
��Auto��6=    . ��6J   �� *Specifications+ 5�        5�   "   $
 Auto	 6�    . $
 Name��6�   # [ 6�    69     $! Client.Properties.Resources��$ Specification��6�     5�   "   $
 Auto	 6y    .  65     $! Client.Properties.Resources��$ 	Commodity�� 6�   �� *Commodity.Name+6�     5�   "   $
 Auto	 6}    .  65     $! Client.Properties.Resources��$ CommodityType�� 6�   �� *CommodityType.Name+6�     5�   "   $
 Auto	 6x    .  65     $! Client.Properties.Resources��$ Comments�� 6�   �� *Description+6�     5�   "   $
 Auto	 6}    .  # [ 6�    69     $! Client.Properties.Resources��$ 	Operation��6�   5�      �� 5�      -)   5        $��	groupBox3��5�   �   $��65��6h   $
��Left=�6t   $��6,35,0,0q�6�   $	��Top=�6�   $	��580��6�   ��6#     $! Client.Properties.Resources��$ 
Conditions��.��5�      � .+�5�   "   �� -*   5        $��	comboBox5��5�   �   $
 Name��6+   $��23��6D   $
��Left=�6P   ��SearchCommodityTypes6k   $��
324,12,0,0q�6�   $ Id��6�   $	��Top=�6�   $	��120��6   6�   �� *SearchCommodityTypeId+6  �� 5�   "   -+   5        $��button6��5�   �   $��23��6j   $
��Left=�6v   $��
470,12,0,0q�6�   $	��Top=�6�   $��75��6�   ��6)     $! Client.Properties.Resources��$ Query��6�   �� 5�   "   -,   5        $��label5��5�   �   $��28��6q   $	��100��6}   $��Right=�6�   $
��Left=�6�   $��
218,10,0,0q�6�   $	��Top=�6�   ��6(     $! Client.Properties.Resources��$ CommodityType��6�   �� 5�   "   --   5        $��label4��5�   �   $��28��6m   $
��Left=�6y   $��6,10,0,0q�6�   $��80��6�   $��Right=�6�   $	��Top=�6�   ��6(     $! Client.Properties.Resources��$ 	Commodity��6�   �� 5�   "   -.   5        $��	comboBox4��5�   �   $
 Name��6+   $��23��6D   $
��Left=�6P   ��SearchCommodities6k   $��	92,12,0,0q�6�   $ Id��6�   $	��Top=�6�   $	��120��6
   6�   �� *SearchCommodityId+6  5�      5�      5�      5�      5�      5�      5�      5�      