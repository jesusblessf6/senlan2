   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6K   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      <    6Client.View.SystemSetting.DataDictSetting.DataDictHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6K   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   C     *
DataDict+ � 	Resources 5      (   "Client.Converters.VATTypeConverter   ConvertType-   'Client.Converters.IsSystemTypeConverter  IsSystemType,   &Client.Converters.BoolReverseConverter  BoolConverter  CountryEdit  CountryDelete  CountryView  PortEdit  
PortDelete  PortView 	 PaymentMeanEdit 
 PaymentMeanDelete  PaymentMeanView  VATRateEdit  VATRateDelete  VATRateView  PaymentUsageEdit  PaymentUsageDelete  PaymentUsageView  UdfEdit  	UdfDelete  UdfView 
 DPEdit  DPDelete 
 DPView  CountryActions �� DataType �� Orientation   ResxName
   Key  PortActions  PaymentMeanActions �� 	Converter  VATRateActions  PaymentUsageActions  
UdfActions  CountryLink	 �� Command
 �� CommandParameter  PortLink   PaymentMeanLink ! VATRateLink " PaymentUsageLink��%  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 
    &	     &	 0    &	 C    &	 V    &	 i    &	 |    &	 �    &	 �    &	 �    &	 �    7  7  &	 <    7  7  &	 �    7 	 7  7 
 7  &	 g    7  7  &	 �    7  7  &	 ^	    7  7  &	 �
    7  &	 �    7  &	  8    7  &	! �    7  &	" �    7    5   
   6&     5   
   6+     5   
   6*   �� 5   
   6.   �� 5   
   60   �� 5   
   6.   �� 5   
   6+   �� 5   
   6-   �� 5   
   6+   �� 5   
   62   �� 5   
   64   �� 5   
   62   �� 5   
   6.   �� 5   
   60   �� 5   
   6.   �� 5!   
   63   �� 5"   
   65   �� 5#   
   63   �� 5%   
   6*   �� 5&   
   6,   �� 5'   
   6*   �� 5)   
   6)   �� 5*   
   6+   �� 5+   
   6)   �� 5-   
   $ DBEntity:Country��6.   .R�5.      �� $ 
Horizontal=�6   .+�5/      �� $��btCountryEdit��6   8��  ��6.     $! Client.Properties.Resources��$
 Edit����50      �� *Id+6;   �� 51      $��btCountryDelete��6   8�� ��60     $! Client.Properties.Resources��$ Delete����52      �� *Id+6;   53      54      �� 56   
   $ DBEntity:Port��6+   .R�57      �� $ 
Horizontal=�6   .+�58      �� $��
btPortEdit��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����59      �� *Id+6;   �� 5:      $��btPortDelete��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5;      �� *Id+6;   5<      5=      �� 5?   
   $ DBEntity:PaymentMean��62   .R�5@      �� $ 
Horizontal=�6   .+�5A      �� $��btPaymentMeanEdit��6   8��  ��62     $! Client.Properties.Resources��$
 Edit����5B      �� *Id+{�69   �� *
IsSystem+8  6�   �� 5C      $��btPaymentMeanDelete��6   8�� ��64     $! Client.Properties.Resources��$ Delete����5D      �� *Id+{�69   �� *
IsSystem+8  6�   5E      5F      �� 5H   
   $ DBEntity:VATRate��6.   .R�5I      �� $ 
Horizontal=�6   .+�5J      �� $��btVATRateEdit��6   8��  ��6.     $! Client.Properties.Resources��$
 Edit����5K      �� *Id+6;   �� 5L      $��btVATRateDelete��6   8�� ��60     $! Client.Properties.Resources��$ Delete����5M      �� *Id+6;   5N      5O      �� 5Q   
   $ DBEntity:PaymentUsage��63   .R�5R      �� $ 
Horizontal=�6   .+�5S      �� $��btPaymentUsageEdit��6   8��  ��63     $! Client.Properties.Resources��$
 Edit����5T      �� *Id+6;   �� 5U      $��btPaymentUsageDelete��6   8�� ��65     $! Client.Properties.Resources��$ Delete����5V      �� *Id+6;   5W      5X      �� 5Z   
   $ DBEntity:ContractUDF��6*   .R�5[      �� $ 
Horizontal=�6   .+�5\      �� $��	btUdfEdit��6   8��  ��6*     $! Client.Properties.Resources��$
 Edit����5]      �� *Id+6;   �� 5^      $��btUdfDelete��6   8�� ��6,     $! Client.Properties.Resources��$ Delete����5_      �� *Id+6;   5`      5a      �� 5c   
   $ DBEntity:Country��6+   .R�5d      �� �� 5e      8	   
 6C   �� *Id+.�6c   .�5f      �� �6   �� *ChineseName+69   5g      5h      5i      �� 5k   
   $ DBEntity:Port��6(   .R�5l      �� �� 5m      8	   
 6@   �� *Id+.�6`   .�5n      �� �6   �� *Name+62   5o      5p      5q      �� 5s   
   $ DBEntity:PaymentMean��6/   .R�5t      �� �� 5u      8	   
 6G   �� *Id+.�6g   .�5v      �� �6   �� *Name+62   5w      5x      5y      �� 5{   
   $ DBEntity:VATRate��6+   .R�5|      �� �� 5}      8	   
 6C   �� *Id+.�6c   .�5~      �� �6   �� *Code+62   5      5�      5�      �� 5�   
   $ DBEntity:PaymentUsage��60   .R�5�      �� �� 5�      8	   
 6H   �� *Id+.�6h   .�5�      �� �6   �� *Name+62   5�      5�      5�      5�       J� CommandBindings 5�      )  #System.Windows.Input.CommandBinding  5�   
   -   5           Command# [ 5�      5�   :     5�   
   -   5        # [ 5�      5�   <     5�   
   -   5        # [ 5�      5�   :     5�   
   -   5        # [ 5�      6{     5�   
   -   5        # [ 5�      5�   9     5�   
   -   5        # [ 5�      6{     5�   
   -   5        # [	 5�      5�   >     5�   
   -   5        # [
 5�      5�   @     5�   
   -	   5        # [ 5�      5�   >     5�   
   -
   5        # [ 5�      5�   :     5�   
   -   5        # [ 5�      5�   <     5�   
   -   5        # [ 5�      5�   :     5�   
   -   5        # [ 5�      5�   ?     5�   
   -   5        # [ 5�      5�   A     5�   
   -   5        # [ 5�      5�   ?     5�   
   -   5        # [ 5�      5�   6     5�   
   -   5        # [ 5�      5�   8     5�   
   -   5        # [ 5�      5�   6     5�   
   -   5        # [ 5�      5�   5     5�   
   -   5        # [ 5�      5�   7     5�   
   -   5        # [ 5�      5�   5   .��5�      �� $
��Auto=�6   $
��Auto=�68   .��5�   
   � -   5        $��rootGrid��5�      .+�5�      �� -   5        $��lbTitle��5�   f   $��32��6.   $
��Left=�6:   $��6,6,0,0q�6U   $	��Top=�5�      $
��Bold"�6,   $��16(�6>   ��5�        *
DataDict+5�   >   �� 5�      -   5        $��tabControl1��5�   S   $	��420��6   $
��Left=�6&   $��6,40,0,0q�6A   $	��Top=�5�      $	��550��61   .@�5�      �� -   5        $��tabItem1��5�   b   ��6     $! Client.Properties.Resources��$ OriginCountry��.��5�      �� $
��Auto=�6#   $
��Auto=�6H   .��5�      � .+�5�      �� -   5        $��button1��5�   %   $��23��5�   n   $
��Left=�6z   $��6,6,0,0q�6�   $	��Top=�5�   4   $��45��6L   ��5�   %     $! Client.Properties.Resources��$ AddWithSymbol��5�   W   $  Utility.Controls.PagingControl  5�      -   5        $��pagingControl1��5�   \   $
��Left=�6/   $��6,35,0,0q�6J   $	��Top=�5�   /   &   System.Windows.Controls.DataGrid  5�      -   5        $��	dataGrid1��5�   9      AutoGenerateColumns .  $
��Auto��5�   C   $
��Left=�6Q   $��6,72,0,0q�5�   '      
IsReadOnly . $	��Top=�6\   $
��Auto��6t   $��2��5�   H   ��5�   �   ��    Columns 5�   "   4	  .System.Windows.Controls.DataGridTemplateColumn	  5�   &   ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�    
  CanUserSort .  
  SortMemberPath$ ChineseName��5�   =    	  CellTemplate# [ 6Z    
  Header 5�   =     $! Client.Properties.Resources��$ OriginCountry��5�   �   0  *System.Windows.Controls.DataGridTextColumn  5�   &   $
 Auto 6    .  69     $! Client.Properties.Resources��$ EnglishName��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   9   �� *Name+6T     5�   &   $
 Auto 6|    .  69     $! Client.Properties.Resources��$ Comments�� 5�   9   �� *Description+6[   	  5�   &   $
 Auto 6�    .  # [ 5�   =    5�   =     $! Client.Properties.Resources��$ 	Operation��5�   n   5�      5�      5�      5�      �� 5�      -   5        $��tabItem2��5�   /   ��6     *Port+.��5�      �� $
��Auto=�6#   $
��Auto=�6H   .��5�      � .+�5�      �� -   5        $��button2��5�   %   $��23��5�   n   $
��Left=�6z   $��6,6,0,0q�6�   $	��Top=�5�   4   $��45��6L   ��5�   %     $! Client.Properties.Resources��$ AddWithSymbol��5�   W     5�      -   5        $��portpagingControl��5�   /   $
��Left=�5�   /   $��6,35,0,0q�6J   $��31��6\   $	��Top=�5�   H     5�      -    5        $��portDataGrid��5�   9    .  $
��Auto��5�   C   $
��Left=�6Q   $��6,72,0,0q�5�   '    . $	��Top=�6_   $
��Auto��6w   $��2��5�   K   ��5�   �   ��  5�   "   	  5�   &   $
 Auto 6�    . $
 Name��5�   =   # [ 6S    5�   =     $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$
 Port��5�   ~     5�   &   $
 Auto 6�    .  69     $! Client.Properties.Resources��$ OriginCountry�� 5�   9   �� *Country.ChineseName+6c     5�   &   $
 Auto 6|    .  69     $! Client.Properties.Resources��$ Comments�� 5�   9   �� *Description+6[   	  5�   &   $
 Auto 6�    .  # [ 5�   =    5�   =     $! Client.Properties.Resources��$ 	Operation��5�   k   5�      5�      5�      5�      �� 5�      -!   5        $��tabItem3��5�   `   ��6     $! Client.Properties.Resources��$ PaymentMean��.��5�      �� $
��Auto=�6#   $
��Auto=�6H   .��5�      � .+�5�      �� -"   5        $��btPaymentMean��5�   %   $��23��5�   n   $
��Left=�6z   $��6,6,0,0q�6�   $	��Top=�5�   :   $��45��6R   ��5�   %     $! Client.Properties.Resources��$ AddWithSymbol��5�   ]     5�      -#   5        $��paymentmeanpagingControl��5�   /   $
��Left=�5�   /   $��6,35,0,0q�6J   $��31��6\   $	��Top=�5�   O     5�      -$   5        $��paymentMeanDataGrid��5�   9    .  $
��Auto��5�   C   $
��Left=�6Q   $��6,72,0,0q�5�   '    . $	��Top=�6f   $
��Auto��6~   $��2��5   j   ��6'   ��  5  "   	  5  &   $
 Auto 6�    . $
 Name��5  =   # [  6S    5  =     $! Client.Properties.Resources��$ PaymentMean��5  �     5  &   $
 Auto 6|    .  69     $! Client.Properties.Resources��$ Comments�� 5  9   �� *Description+6[     5  &   $
 Auto 6    .  69     $! Client.Properties.Resources��$ SystemValue�� 5  9   �� *
IsSystem+# [ 6�   	  5  &   $
 Auto 6�    .  # [ 5	  =    5  =     $! Client.Properties.Resources��$ 	Operation��5	  r   5     5     5     5     �� 5     -%   5        $��tabItem4��5  .   ��6     *VAT+.��5     �� $
��Auto=�6#   $
��Auto=�6H   .��5     � .+�5     �� -&   5        $��	btVATRate��5  %   $��23��5  n   $
��Left=�6z   $��6,6,0,0q�6�   $	��Top=�5  6   $��45��6N   ��5  %     $! Client.Properties.Resources��$ AddWithSymbol��5  Y     5     -'   5        $��vatratepagingControl��5  \   $
��Left=�6/   $��6,35,0,0q�6J   $	��Top=�5  /     5     -(   5        $��vatRateDataGrid��5  9    .  $
��Auto��5  C   $
��Left=�6Q   $��6,72,0,0q�5  '    . $	��Top=�6b   $
��Auto��6z   $��2��5  N   ��5  �   ��  5  "   	  5  &   $
 Auto 6�    . # [! 5  =    5  =     $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$ TaxCode��5  k     5  &   $
 Auto 6x    .  69     $! Client.Properties.Resources��$
 Type�� 5  9   �� *Type+# [  6|     5  &   $
 Auto 6�    . $
 Code��5   W    5  9     $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$
 Rate�� 5   9   �� *	RateValue+5!  '     5#  &   $
 Auto 6|    .  69     $! Client.Properties.Resources��$ Comments�� 5$  9   �� *Description+6[   	  5%  &   $
 Auto 6�    .  # [ 5&  =    5%  =     $! Client.Properties.Resources��$ 	Operation��5&  n   5(     5)     5*     5+     �� 5-     -)   5        $��tabItem5��5-  a   ��6     $! Client.Properties.Resources��$ PaymentUsage��.��5.     �� $
��Auto=�6#   $
��Auto=�6H   .��5/     � .+�50     �� -*   5        $��btPaymentUsage��51  %   $��23��50  n   $
��Left=�6z   $��6,6,0,0q�6�   $	��Top=�51  ;   $��45��6S   ��50  %     $! Client.Properties.Resources��$ AddWithSymbol��51  ^     52     -+   5        $��paymentusagepagingControl��53  /   $
��Left=�52  /   $��6,35,0,0q�6J   $��31��6\   $	��Top=�53  P     54     -,   5        $��paymentUsageDataGrid��55  9    .  $
��Auto��54  C   $
��Left=�6Q   $��6,72,0,0q�55  '    . $	��Top=�6g   $
��Auto��6   $��2��56  k   ��6'   ��  57  "   	  58  &   $
 Auto 6|    . $
 Name��59  =   # [" 6S    58  =     $! Client.Properties.Resources��$
 Name��59  �     5:  &   $
 Auto 6�    .  69     $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$ DefaultPaymentMean�� 5;  9   �� *PaymentMean.Name+5<  '     5=  &   $
 Auto 6�    .  69     $B <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��$ DefaultFinancialAccount�� 5>  9   �� *FinancialAccount.Name+5?  '     5@  &   $
 Auto 6|    .  69     $! Client.Properties.Resources��$ Comments�� 5A  9   �� *Description+6[     5B  &   $ 默认��69   $
 Auto 6E    .  5C  9   �� *	IsDefault+# [ 6�   	  5D  &   $
 Auto 6�    .  # [ 5E  =    5D  =     $! Client.Properties.Resources��$ 	Operation��5E  s   5G     5H     5I     5J     �� 5K     --   5        $��tabItem7��5K  '   $��	提货人��6   .��5L     �� $
��Auto=�6#   $
��Auto=�6H   .��5M     � .+�5N     �� -.   5        $��btAddDP��5N  k   $��+新增��6%   $��23��63   $
��Left=�6?   $��6,6,0,0q�6Z   $	��Top=�6z   $��45��6�   6�     5O     -/   5        $��dpListPager��5O  \   $
��Left=�6/   $��6,35,0,0q�6J   $	��Top=�6o     5P     -0   5        $��dgDPList��5Q  '    .  $
��Auto��5P  C   $
��Left=�6Q   $��6,72,0,0q�6l   $	��Top=�5Q  7   $
��Auto��6O    . ��6n   ��  5S  "     5T  &   $ 姓名��69   $
 Auto 6E    .  6e   �� *Name+  5U  &   $ 车号��69   $
 Auto 6E    .  6e   �� *	VehicleNo+  5V  &   $ 电话��69   $
 Auto 6E    .  6e   �� *Tel+6     5W  &   $ 身份证号��69   $
 Auto 6G    .  6g   �� *IdNo+  5X  &   $ 备注��69   $
 Auto 6E    .  6e   �� *
Comments+	  5Y  &   $ 操作��6=   $
 Auto 6I    .  5Z  *   �� 5[  .   $ DBEntity:DeliveryPerson��6;   .R�5\  2   �� $ 
Horizontal=�6=   .+�5]  6   �� $��查看��6=   #��[ 6J   ��6l   �� *Id+6�   �� 5^  6   $��编辑��6=   #��[ 6J   ��6l   �� *Id+6�   �� 5_  6   $��删除��6=   #��[ 6J   ��6n   �� *Id+6�   5`  3   5a  /   5c  '   5e     5f     5g     5h     �� 5j     -1   5        $��tabItem6��5j  X   ��6     $! Client.Properties.Resources��$	 UDF��.��5k     �� $
��Auto=�6#   $
��Auto=�6H   .��5l     � .+�5m     �� -2   5        $��btUDF��5n  %   $��23��5m  n   $
��Left=�6z   $��6,6,0,0q�6�   $	��Top=�5n  2   $��45��6J   ��5m  %     $! Client.Properties.Resources��$ AddWithSymbol��5n  U     5o     -3   5        $��udfPagingControl��5p  /   $
��Left=�5o  /   $��6,35,0,0q�6J   $��31��6\   $	��Top=�5p  G     5q     -4   5        $��udfDataGrid��5r  9    .  $
��Auto��5q  C   $
��Left=�6Q   $��6,72,0,0q�5r  '    . $	��Top=�6^   $
��Auto��6v   $��2��5s  b   ��6'   ��  5t  "     5u  &   $
 Auto 6x    .  69     $! Client.Properties.Resources��$
 Name�� 5v  <   �� *Name+6W     5w  &   $
 Auto 6|    .  69     $! Client.Properties.Resources��$ Comments�� 5x  9   �� *	Comment+6W     5y  &   $ 默认��69   $
 Auto 6E    .  5z  9   �� *	IsDefault+# [ 6�   	  5{  &   $
 Auto 6�    .  # [ 5|  =    5{  =     $! Client.Properties.Resources��$ 	Operation��5|  j   5~     5     5�     5�     5�     5�     5�     5�     