   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6K   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5
      B    <Client.View.SystemSetting.BankAccountSetting.BankAccountHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6K   ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$H  BClient.View.SystemSetting.BankAccountSetting.ResBankAccountSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   l     *BankAndAccountHome+ � 	Resources 5      0  *Client.Converters.BankAccountTypeConverter   ConvertType  BankEdit  
BankDelete  BankView  AccountEdit  AccountDelete  AccountView  BankActions �� DataType �� Orientation   ResxName
   Key  AccountActions 	 BankLink �� Command	 �� CommandParameter 
 AccountLink��%\  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     7  7  &	 �    7  7  &		 h    7  &	
     7    5   
   6.   �� 5   
   6+   �� 5   
   6-   �� 5   
   6+   �� 5   
   6.   �� 5   
   60   �� 5   
   6.   �� 5   
   $ DBEntity:Bank��6+   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��
btBankEdit��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btBankDelete��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   5      5      �� 5    
   $ DBEntity:BankAccount��6.   .R�5!      �� $ 
Horizontal=�6   .+�5"      �� $��btAccountEdit��6   8��  ��6.     $! Client.Properties.Resources��$
 Edit����5#      �� *Id+6;   �� 5$      $��btAccountDelete��6   8�� ��60     $! Client.Properties.Resources��$ Delete����5%      �� *Id+6;   5&      5'      �� 5)   
   $ DBEntity:Bank��6(   .R�5*      �� �� 5+      8   	 6@   �� *Id+.�6`   .�5,      �� �6   �� *Name+62   5-      5.      5/      �� 51   
   $ DBEntity:BankAccount��6+   .R�52      �� �� 53      8   	 6C   �� *Id+.�6c   .�54      �� �6   �� *AccountCode+69   55      56      57      58      
 J� CommandBindings
 5:      )  #System.Windows.Input.CommandBinding  5;   
   -   5           Command# [ 5;      6{     5<   
   -   5        # [ 5<      5=   9     5>   
   -   5        # [ 5>      6{     5?   
   -   5        # [ 5?      5@   :     5A   
   -   5        # [ 5A      5B   <     5C   
   -   5        # [ 5C      5D   :   .��5G      �� $
��Auto=�6   $
��Auto=�68   .��5H   
   � -   5        $��rootGrid��5H      .+�5I      �� -   5        $��lbTitle��5I   p   $��32��68   $
��Left=�6D   $��6,6,0,0q�6_   $
��auto��5J      $	��Top=�6!   $
��Bold"�69   $��16(�6K   ��5I        *BankAndAccountHome+5J   K   �� 5K      -	   5        $��tabControl1��5K   T   $
��Auto��6   $
��Left=�6'   $��6,40,0,0q�6B   $	��Top=�5L      $
��auto��61   $	��380��6>   $	��600��6N   .@�5M      �� -
   5        $��tiBank��5M   Y   ��6     $! Client.Properties.Resources��$
 Bank��.��5N      � .+�5O      �� -   5        $��button1��5P   !   $��23��5O   j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�5P   0   $��45��6H   ��5O   !     $! Client.Properties.Resources��$ AddWithSymbol��5P   S   $  Utility.Controls.PagingControl  5Q      -   5        $��pagingControl1��5Q   >   $��	6,105,0,0q�6+   $��31��6T   $	��Top=�5R   +   $
��Left=�6C   &   System.Windows.Controls.DataGrid  5S      -   5        $��	dataGrid1��5T   6      AutoGenerateColumns .  $
��Auto��5S   ?   $
��Left=�6M   $��	6,142,0,0q�5T   #   $	��Top=�6G   $
��Auto��6_      
IsReadOnly .   DataGridStyle#��[ 5U   D     DataGridRowStyle   RowStyle# [ 6k   ��5T   l   ��    Columns 5V      4  .System.Windows.Controls.DataGridTemplateColumn  5W   "   ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6|      CanUserSort .   DataGridColumnHeaderStyle   HeaderStyle# [ 6�      SortMemberPath$
 Name��5X   9      CellTemplate# [	 6O      Header 5W   9     $! Client.Properties.Resources��$ BankName��5X   {   0
  *System.Windows.Controls.DataGridTextColumn
  5Y   "   $ SWIFT��65   $
 Auto	 6D    . # [ 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5Z   5   �� *Code+6Q   
  5[   "   $
 Auto	 6�    . # [ 6�    65     $H BClient.View.SystemSetting.BankAccountSetting.ResBankAccountSetting��$ BankAddress�� 5\   5   �� *	Address+6T   
  5]   "   $
 Auto	 6x    . # [ 6�    65     $! Client.Properties.Resources��$ Comments�� 5^   5   �� *Description+6X     5_   "   $
 Auto	 6}    .  # [ 6�   # [ 5`   5    5_   9     $! Client.Properties.Resources��$ 	Operation��5`   d   5b      �� 5c      -   5        $��	groupBox1��5c   �   $��65��6h   $
��Left=�6t   $��6,35,0,0q�6�   $	��Top=�6�   $	��580��6�   ��6#     $! Client.Properties.Resources��$ 
Conditions��.��5d      �  � ColumnDefinitions 5e   "   �� 5f   &   $
��266* �67   .+�5i   "   �� -   5        $��label2��5i   z   $��6,10,0,0q�6h   $	��Top=�6�   $
��Left=�6�   $��60��6�   $��28��6�   $��Right=�6�   ��6(     $! Client.Properties.Resources��$
 Name��6�   �� 5j   "   -   5        $��txtName��5j   X   $
��Left=�6*   $��	72,12,0,0q�6E   $	��Top=�6�   $	��120��6�   $��23��6�   ��6g   �� *
SearchName+6�   �� 5k   "   -   5        $��	btnSearch��5k   �   $��23��6�   $
��left=�6�   $��
201,12,0,0q�6�   $	��Top=�6�   $��75��6�    �� 	IsDefault . ��6@     $! Client.Properties.Resources��$ Query��6�   5l      5m      5n      5o      �� 5p      -   5        $��	tiAccount��5p   `   ��6     $! Client.Properties.Resources��$ BankAccount��.��5q      � .+�5r      �� -   5        $��button2��5s   !   $��23��5r   j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�5s   0   $��45��6H   ��5r   !     $! Client.Properties.Resources��$ AddWithSymbol��5s   S     5t      -   5        $��pagingControl2��5t   >   $��	6,105,0,0q�6+   $��31��6T   $	��Top=�5u   +   $
��Left=�6C     5v      -   5        $��	dataGrid2��5w   6    .  $
��Auto��5v   ?   $
��Left=�6M   $��	6,142,0,0q�5w   #   $	��Top=�6G   $
��Auto��6_    . #��[ 5x   D   # [ 6k   ��5w   l   ��  5y      
  5z   "   $
 Auto	 6x    . # [ 6�    65     $! Client.Properties.Resources��$ BankName�� 5{   5   �� *	Bank.Name+6V     5|   "   $
 Auto	 6    . # [ 6�   $ AccountCode��5}   9   # [
 6V    5|   9     $! Client.Properties.Resources��$ AccountCode��5}   �   
  5~   "   $
 Auto	 6�    . # [ 6�    65     $! Client.Properties.Resources��$ BankAccountCurrency�� 5   5   �� *Currency.Name+6Z   
  5�   "   $
 Auto	 6|    . # [ 6�    65     $! Client.Properties.Resources��$ AccountUsage�� 5�   5   �� *Usage+ �� 	Converter# [  6z   
  5�   "   $
 Auto	 6|    . # [ 6�    65     $! Client.Properties.Resources��$ CustomerName�� 5�   5   �� *BusinessPartner.ShortName+6f   
  5�   "   $
 Auto	 6x    . # [ 6�    65     $! Client.Properties.Resources��$ Comments�� 5�   5   �� *Description+6X     5�   "   $
 Auto	 6}    .  # [ 6�   # [ 5�   9    5�   9     $! Client.Properties.Resources��$ 	Operation��5�   k   5�      �� 5�      -   5        $��	groupBox2��5�   �   $��65��6h   $
��Left=�6t   $��6,35,0,0q�6�   $	��Top=�6�   $	��580��6�   ��6#     $! Client.Properties.Resources��$ 
Conditions��.��5�      �  5�   "   �� 5�   &   $
��266* �67   .+�5�   "   �� -   5        $��label1��5�   �   $��28��6h   $
��Left=�6t   $��Right=�6�   $��6,10,0,0q�6�   $	��Top=�6�   $��60��6�   ��6(     $! Client.Properties.Resources��$
 Name��6�   �� 5�   "   -   5        $��	txtBAName��5�   d   $��23��6*   $
��Left=�66   $��	72,12,0,0q�6Q   $	��Top=�6�   $	��120��6�   ��6u   �� *SearchBankAccountName+6�   �� 5�   "   -   5        $��button3��5�   �   $��23��6�   $
��Left=�6�   $��
479,12,0,0q�6�   $	��Top=�6�   $��75��6�    . ��6G     $! Client.Properties.Resources��$ Query��6�   �� 5�   "   -   5        $��label3��5�   �   $��28��6p   $
��Left=�6|   $��Right=�6�   $��
198,10,0,0q�6�   $	��Top=�6�   $	��100��6�   ��6(     $! Client.Properties.Resources��$ CustomerName��6�   �� 5�   "   -   5        $��button4��5�   r   $	��...��6)   $��23��67   $
��Left=�6C   $��
428,12,0,0q�6^   $	��Top=�6�   $��25��6�   6�   �� 5�   "   -   5        $��textBox5��5�   k   $
��Left=�6*   {�.  $��
304,12,0,0q�6W   $	��Top=�6�   $	��120��6�   $��23��6�   ��6{   �� *SearchCustomerName+6�   5�      5�      5�      5�      5�      5�      5�      5�      