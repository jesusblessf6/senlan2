   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity >    8Client.View.SystemSetting.CommoditySetting.CommodityHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -cclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$D  >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title      ResxName$! Client.Properties.Resources��
   Key$ 	Commodity�� � 	Resources    CommodityTypeEdit  CommodityTypeDelete  CommodityTypeView  	BrandEdit  BrandDelete  	BrandView  SpecificationEdit  SpecificationDelete  SpecificationView,   &Client.Converters.BoolReverseConverter 	 BoolConverter 
 CommodityTypeActions �� DataType �� Orientation �� 	Converter  CommodityTypeLink	 �� Command
 �� CommandParameter  BrandActions  	BrandLink  SpecificationActions  SpecificationLink��%y  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 2     7   7 	 7  7 	 &	 ~    7  &	 �    7  7  &	 �    7  &	 6    7  7  &	 L    7  �� �� �� �� �� �� �� �� ��   �� $ DBEntity:CommodityType��.R��� $ 
Horizontal=�.+��� $��btCommodityTypeEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+{��� *
IsSystem+8  �� $��btCommodityTypeDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+{��� *
IsSystem+8  �� $ DBEntity:CommodityType��.R��� �� 8	   
 �� *Id+.�.��� ��� *Name+�� $ DBEntity:Brand��.R��� $ 
Horizontal=�.+��� $��btBrandEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btBrandDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:Brand��.R��� �� 8	   
 �� *Id+.�.��� ��� *Name+�� $ DBEntity:Specification��.R��� $ 
Horizontal=�.+��� $��btSpecificationEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+�� $��btSpecificationDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+�� $ DBEntity:Specification��.R��� �� 8	   
 �� *Id+.�.��� ��� *Name+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -   # [   -	   # [ .���� $
��Auto=�$
��Auto=�.��� -
   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *CommoditySetting+�� -   $��tabControl1��$��6,40,0,0q�$	��380��$
��Auto��$	��900��$
��Left=�$	��Top=�.@��� -   $��tiCommodity����  $! Client.Properties.Resources��$ 	Commodity��.��� .+�$  Utility.Controls.PagingControl  -   $��pagingControl1��$��6,6,0,0q�$��31��$	��Top=�$
��Left=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $
��Auto��$
��Left=�$��6,43,0,0q�$	��Top=�$
��Auto��   
IsReadOnly . ���� *Commodities+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	    CanUserSort .    Header   $! Client.Properties.Resources��$ 	Commodity��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Name+  $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ SHFEUnit�� �� *
SHFEUnit+  $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ SGEUnit�� �� *	SGEUnit+  $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ LMEUnit�� �� *	LMEUnit+  $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 
SHFELotQty�� �� *SHFEQtyPerHand+$  DBEntity.EnumEntity.RoundRules   STR_INTEGER �� StringFormat# Z   $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	SGELotQty�� �� *SGEQtyPerHand+# Z   $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	LMELotQty�� �� *LMEQtyPerHand+# Z   $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 
SHFEDelQty�� �� *SHFEQtyForDel+# Z   $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	SGEDelQty�� �� *SGEQtyForDel+# Z   $
 Auto	  .    $D >Client.View.SystemSetting.CommoditySetting.ResCommoditySetting��$ 	LMEDelQty�� �� *LMEQtyForDel+# Z �� -   $��tiCommodityType����  $! Client.Properties.Resources��$ CommodityType��.��� .+��� -   $��button2��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -   $��pagingControl2��$
��Left=�$��	6,105,0,0q�$	��Top=�$��31��  -   $��	dataGrid2�� .  $
��Auto��$
��Left=�$��	6,142,0,0q�$	��Top=�$
��Auto�� . ���� *CommodityTypes+ 4  .System.Windows.Controls.DataGridTemplateColumn     SortMemberPath$
 Name��$
 Auto	  .    CellTemplate# [    $! Client.Properties.Resources��$ CommodityType��  $
 Auto	  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  $
 Auto	  .    $! Client.Properties.Resources��$ EnglishName�� �� *EnglishName+  $
 Auto	  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto	  .  # [
    $! Client.Properties.Resources��$ 	Operation���� -   $��	groupBox1��$��65��$
��Left=�$��6,35,0,0q�$	��Top=�$	��550����  $! Client.Properties.Resources��$ 
Conditions��.��� .+��� -   $��	comboBox3�� �� DisplayMemberPath$
 Name��$��23��$
��Left=���SearchCommodities$��	92,12,0,0q� �� SelectedValuePath$ Id��$	��Top=�$	��120�� �� SelectedValue �� *SearchCommodityId+�� -   $��button5��$��23��$
��Left=�$��
239,12,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -   $��label3��$��28��$��80��$��Right=�$
��Left=�$��6,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -   $��tiBrand����  $! Client.Properties.Resources��$ Brand��.��� -   $��nodeGrid��.+��� -   $��button3��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -   $��pagingControl3��$
��Left=�$��	6,145,0,0q�$	��Top=�$��31��  -   $��	dataGrid3�� .  $
��Auto��$
��Left=�$��	6,182,0,0q�$	��Top=�$
��Auto�� . ���� *Brands+   $
 Name��$
 Auto	  . # [    $! Client.Properties.Resources��$ Brand��  $
 Auto	  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  $
 Auto	  .    $! Client.Properties.Resources��$ CommodityType�� �� *CommodityType.Name+  $
 Auto	  .    $! Client.Properties.Resources��$ OriginCountry�� �� *Country.ChineseName+  $
 Auto	  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto	  .  # [    $! Client.Properties.Resources��$ 	Operation���� -   $��	groupBox2��$	��105��$
��Left=�$��6,35,0,0q�$	��Top=�$	��580����  $! Client.Properties.Resources��$ 
Conditions��.��� .+��� -   $��	comboBox1��$��23��$
��Left=�$��	92,12,0,0q�$	��Top=�$	��120��$
 Name��$ Id����SearchCommodities �� *SearchCommodityId+�� -   $��label1��$��28��$��80��$��Right=�$
��Left=�$��6,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -    $��label2��$��28��$	��100��$��Right=�$
��Left=�$��
218,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ CommodityType���� -!   $��	comboBox2��$��23��$
��Left=�$��
324,12,0,0q�$	��Top=�$	��120��$
 Name��$ Id����SearchCommodityTypes �� *SearchCommodityTypeId+�� -"   $��button1��$��23��$
��Left=�$��
470,12,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -#   $��label6��$��28��$
��Left=�$��6,42,0,0q�$	��Top=�$��80��$��Right=���  $! Client.Properties.Resources��$ Brand���� -$   $��textBox1��$��23��$
��Left=�$��	92,44,0,0q�$	��Top=�$	��120������ *	BrandName+�� -%   $��tiSpecification����  $! Client.Properties.Resources��$ Specification��.��� .+��� -&   $��button4��$��23��$
��Left=�$��6,6,0,0q�$	��Top=�$��45����  $! Client.Properties.Resources��$ AddWithSymbol��  -'   $��pagingControl4��$
��Left=�$��	6,105,0,0q�$	��Top=�$��31��  -(   $��	dataGrid4�� .  $
��Auto��$
��Left=�$��	6,142,0,0q�$	��Top=�$
��Auto�� . ���� *Specifications+   $
 Auto	  . $
 Name��# [    $! Client.Properties.Resources��$ Specification��  $
 Auto	  .    $! Client.Properties.Resources��$ 	Commodity�� �� *Commodity.Name+  $
 Auto	  .    $! Client.Properties.Resources��$ CommodityType�� �� *CommodityType.Name+  $
 Auto	  .    $! Client.Properties.Resources��$ Comments�� �� *Description+  $
 Auto	  .  # [    $! Client.Properties.Resources��$ 	Operation���� -)   $��	groupBox3��$��65��$
��Left=�$��6,35,0,0q�$	��Top=�$	��580����  $! Client.Properties.Resources��$ 
Conditions��.��� .+��� -*   $��	comboBox5��$
 Name��$��23��$
��Left=���SearchCommodityTypes$��
324,12,0,0q�$ Id��$	��Top=�$	��120�� �� *SearchCommodityTypeId+�� -+   $��button6��$��23��$
��Left=�$��
470,12,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -,   $��label5��$��28��$	��100��$��Right=�$
��Left=�$��
218,10,0,0q�$	��Top=���  $! Client.Properties.Resources��$ CommodityType���� --   $��label4��$��28��$
��Left=�$��6,10,0,0q�$��80��$��Right=�$	��Top=���  $! Client.Properties.Resources��$ 	Commodity���� -.   $��	comboBox4��$
 Name��$��23��$
��Left=���SearchCommodities$��	92,12,0,0q�$ Id��$	��Top=�$	��120�� �� *SearchCommodityId+