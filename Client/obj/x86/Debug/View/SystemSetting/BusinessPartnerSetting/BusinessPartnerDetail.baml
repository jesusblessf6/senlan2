   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   \   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6�   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      L   FClient.View.SystemSetting.BusinessPartnerSetting.BusinessPartnerDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   \   6
Convertersclr-namespace:Client.Converters     6�   <baseClient2$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$P  JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��5      $	��600��5      $	��600��6(    � WindowStartupLocation$ CenterScreen=�67    � SizeToContent$ WidthAndHeight=�5	       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5           ResxName$! Client.Properties.Resources��
   Key$ BP�� � 	Resources 5       �� 
TargetType   
LabelStyle	 �� Property
 �� Value0 *Client.Converters.BankAccountTypeConverter  ConvertType��%�  &	        '�� �     &	 m    �� 5   
   " ��6   .�5      �� 	 � ��$
 28��6'   64   �� 5      	 � ��$
 28��6*   67   �� 5      	 � ��$	
 110��6&   64   �� 5      	 � ��$	
 110��6)   67   �� 5      	 � ��$
 Right=�6;   6K   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 23��6'   64   �� 5      	 � ��$	
 120��6&   64   5        5   
   6.   5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5       � RowDefinitions 5      �� 5      $
��Auto �6    �� 5       $	��162 �6    �� 5!      $��0 �6    �� 5"      $��2* �6    .+�5$      �� -   5        $��lbTitle��5$   R   $��32��6a   $
��Left=�6m   $��6,6,0,0q�6�   $
��auto��5%      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5$        $! Client.Properties.Resources��$ BP��5%   K   �� 5&      -   5        $��label2��5&   b   #��[  6,   $��6,40,0,0q�6P   $
��Left=�5'      $	��Top=�6/   ��5&        *BPType+5'   /   	� 5(      -   5        $��rBtnCustomer��5(   ~   $��16��6^   $��
122,45,0,0q�6j    	� 	GroupName$
 Type��6�   $	��Top=�5)   =   $
��Left=�6U   $��75��6p   ��5(        $! Client.Properties.Resources��$ Customer�� d� 	IsChecked 5)      �� *TypeCustomer+6p   	� 5*      -   5        $��rBtn1��5*   �   $
 Type��6\   $��16��6m   $��
202,45,0,0q�6y   $
��Left=�5+   C   $��60��6^   $	��Top=�6i   ��5*        $! Client.Properties.Resources��$ Broker�� 5+      �� *TypeFuturesCompany+6i   	� 5,      -   5        $��rBtnInnerCustomer��5,   �   $
 Type��6f   $��16��6w   $��
282,45,0,0q�6�   $	��Top=�5-   B   $
��Left=�6Z   $	��120��6u   ��5,        $! Client.Properties.Resources��$ InternalCustomer�� 5-      �� *TypeInnerCustomer+6u   �� 5.      -   5        $��label3��5.   g   #��[  61   $��6,70,0,0q�6U   
���<��$
��Left=�5/   )   $	��Top=�6D   ��5.        *BPShortName+5/   D   �� 50      -   5        $��txtShortName��50   *   $��
122,72,0,0q�6    �� 	MaxLength$	 100��6Y   $
��Left=�51      $	��Top=�61   ��50   >   �� *	ShortName+51   1   �� 52      -	   5        $��label4��52   d   #��[  6,   $��
278,70,0,0q�6P   
���<��$
��Left=�53   )   $	��Top=�6D   ��52        *BPCode+53   D   �� 54      -
   5        $��txtCustomerCode��54   *   $��
394,72,0,0q�6   $ 50��6W   $
��Left=�55      $	��Top=�61   ��54   A   �� *Code+55   1   �� 56      -   5        $��label5��56   g   #��[  60   $��	6,102,0,0q�6T   
���<��$
��Left=�57   )   $	��Top=�6D   ��56        *
BPFullName+57   D   �� 58      -   5        $��txtFullName��58   R   $��23��6   $
��Left=�6"   $��122,104,0,0q�6=   $	��Top=�59      $	��392��6.   $	 100��6T   ��6:   �� *
FullName+6T   �� 5:      -   5        $��label12��5:   �   #��[  65   $
��Left=�6Y   $��	6,134,0,0q�6t   $	��Top=�6�   ��6     *EnglishFullName+6�   �� 5;      -   5        $��textBox1��5;   R   $��23��6   $
��Left=�6"   $��122,136,0,0q�6=   $	��Top=�6b   $	��392��6z   ��6�   �� *EnglishName+�� 5<      -   5        $��label6��5<   l   #��[  65   $��	6,166,0,0q�6Y   $
��Left=�5=      $	��Top=�6/   ��5<        *DetailedAddress+5=   /   �� 5>      -   5        $��
txtAddress��5>   R   $��23��6   $
��Left=�6"   $��122,168,0,0q�6=   $	��Top=�5?      $	��392��6.   $	 200��6S   ��6:   �� *	Address+6S   �� 5@      -   5        $��label7��5@   �   #��[  6]   $��	6,230,0,0q�6�   $
��Left=�5A      $��60��6/   $	��Top=�6:   ��5@        $! Client.Properties.Resources��$ ContactPerson��5A   :   �� 5B      -   5        $��	txtPerson��5B   F   $
��Left=�6   $��122,232,0,0q�61   $	��Top=�6W   $ 50��5C   .   ��6   �� *Person+6.   �� 5D      -   5        $��label8��5D   �   #��[  6S   $��278,230,0,0q�6w   $
��Left=�5E      $	��Top=�6/   ��5D        $! Client.Properties.Resources��$	 Tel��5E   /   �� 5F      -   5        $��txtPhone��5F   +   $��394,232,0,0q�6   $ 20��6V   $
��Left=�5G      $	��Top=�61   ��5F   ;   �� *	Telephone+5G   1   �� 5H      -   5        $��label9��5H   �   #��[  6S   $��	6,262,0,0q�6w   $
��Left=�5I      $	��Top=�6/   ��5H        $! Client.Properties.Resources��$	 Fax��5I   /   �� 5J      -   5        $��txtFax��5J   +   $��122,264,0,0q�6   $ 20��6N   $
��Left=�6]   $	��Top=�5K      ��5J   9   �� *Fax+5K      �� 5L      -   5        $��label10��5L   �   #��[  6X   $��278,262,0,0q�6|   $
��Left=�5M      $	��Top=�6/   ��5L        $! Client.Properties.Resources��$ PostCode��5M   /   �� 5N      -   5        $��txtZip��5N   +   $��394,264,0,0q�6   $ 20��6R   $
��Left=�5O      $	��Top=�61   ��5N   9   �� *	ZipCode+5O   1   �� 5P      -   5        $��label1��5P   e   #��[  6.   $��	6,361,0,0q�6R   $
��Left=�5Q      $	��Top=�6/   ��5P        *
BankList+5Q   /   &   System.Windows.Controls.DataGrid  5R      -   5        $��dataGridBanks��5S   <      AutoGenerateColumns .  $
��Left=�5R   3   $��122,363,6,0q�6N   $
��Auto��5S   Q      
IsReadOnly . |�.    DataGridStyle#��[ 5T   J     DataGridRowStyle   RowStyle# [ 6q   $
��auto��6�   $	��Top=�6�   ��5S      �� *BankAccounts+   Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5V        DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [ 6�      Header 6)     $! Client.Properties.Resources��$
 Bank��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6h   �� *	Bank.Name+6�     5W      # [ 6�    6)     $! Client.Properties.Resources��$ AccountCode�� 6o   �� *AccountCode+6�     5X      # [ 6�    6)     $! Client.Properties.Resources��$ BankAccountCurrency�� 6w   �� *Currency.Name+6�     5Y      # [ 6�    6)     $! Client.Properties.Resources��$ AccountUsage�� 6p   �� *Usage+ �� 	Converter# [ 6�     5Z      # [ 6�    6)     $! Client.Properties.Resources��$ Comments�� 6l   �� *Description+6�   5\      �� 5]      -   5        $��label11��5]   �   #��[  6X   $��6,7,0,0q�6|   $
��Left=�6�   $	��Top=�6�   $��1��6�   ��6     $! Client.Properties.Resources��$ Comments��6�   �� 5^      -   5        $��	txtRemark��5^   Q   $	��100��6   $
��Left=�6#   $��	122,9,0,0q�6>   $	��Top=�6b   $	��392��5_       �� TextWrapping$
 Wrap=�6:   $��1��6N   ��6"   �� *Remark+6N   �� 5`      -   5        $��btnOK��5`   �   $��25��6X   $
��Left=�6d   $��210,134,0,0q�6   $	��Top=�5a      $��60��6-   $��1��6E   ��5`        $! Client.Properties.Resources��$ Confirm��5a   E   �� 5b      -   5        $��	btnCancel��5b   �   $��25��6W   $
��Left=�6c   $��305,134,0,0q�6~   $	��Top=�5c      $��60��6-   $��1��6G   ��5b        $! Client.Properties.Resources��$ Cancel��5c   G   �� 5d      -   5        $��label13��5d   �   #��[  64   $
��Left=�6X   $��	8,198,0,0q�6s   $	��Top=�6�   ��6     *EnglishAddress+6�   �� 5e      -    5        $��textBox2��5e   R   $��23��6   $
��Left=�6"   $��122,200,0,0q�6=   $	��Top=�6b   $	��392��6z   ��6�   �� *EnglishAddress+�� 5f      -!   5        $��label14��5f   Y   $
��Left=�6+   $��	6,294,0,0q�6F   #��[  6h   $	��Top=�6�   ��6     *TaxId+6�   �� 5g      -"   5        $��textBox3��5g   U   $
��Left=�6   $��122,296,0,0q�61   $ 20��6F   $	��Top=�6|   ��6e   �� *TaxNo+6|   $   Utility.Controls.PagingControl  5h      -#   5        $��
pgBankList��5h   [   $��31��6   $
��Left=�6+   $��122,326,0,0q�6F   $	��Top=�6m   �� 5i      -$   5        $��	checkBox1��5i   d   $��默认内部客户��6   $��16��6(   $
��Left=�64   $��394,299,0,0q�6O   $	��Top=�6u   y�6�   �� *	IsVisible+ 6�   �� *	IsDefault+5j      5k      5l      