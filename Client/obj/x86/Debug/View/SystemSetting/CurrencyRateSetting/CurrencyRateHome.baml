   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 6:   ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      D    >Client.View.SystemSetting.CurrencyRateSetting.CurrencyRateHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -cclr-namespace:Client.Converters     5      =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     6:   ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$J  DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   9     *CurrencyAndRate+ � 	Resources 5      ,   &Client.Converters.BoolReverseConverter   BoolConverter  CurrencyEdit  CurrencyDelete  CurrencyView  RateEdit  
RateDelete  RateView  CurrencyActions �� DataType �� Orientation   ResxName
   Key �� 	Converter  RateActions 	 CurrencyLink	 �� Command
 �� CommandParameter 
 RateLink �� StringFormat��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     7  7   7  7   &	 <    7  7  &		 �    7  &	
 [    7    5   
   69   �� 5   
   6/   �� 5   
   61   �� 5   
   6/   �� 5   
   6+   �� 5   
   6-   �� 5   
   6+   �� 5   
   $ DBEntity:Currency��6/   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btCurrencyEdit��6   8��  ��6/     $! Client.Properties.Resources��$
 Edit����5      �� *Id+{�69   �� *
IsSystem+8  6�   �� 5      $��btCurrencyDelete��6   8�� ��61     $! Client.Properties.Resources��$ Delete����5      �� *Id+{�69   �� *
IsSystem+8  6�   5      5       �� 5"   
   $ DBEntity:Rate��6+   .R�5#      �� $ 
Horizontal=�6   .+�5$      �� $��
btRateEdit��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����5%      �� *Id+6;   �� 5&      $��btRateDelete��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5'      �� *Id+6;   5(      5)      �� 5+   
   $ DBEntity:Currency��6,   .R�5,      �� �� 5-      8	   
 6D   �� *Id+.�6d   .�5.      �� �6   �� *Name+62   5/      50      51      �� 52   
   $ DBEntity:Rate��6(   .R�53      �� �� 54      8	   
 6@   �� *Id+.�6`   .�55      �� �6   �� *	RateValue+$ N��6G   56      57      58      59       J� CommandBindings 5;      )  #System.Windows.Input.CommandBinding  5<   
   -   5           Command# [ 5<      5=   ;     5>   
   -   5        # [ 5>      5?   =     5@   
   -   5        # [ 5@      5A   ;     5C   
   -   5        # [ 5C      6{     5D   
   -   5        # [ 5D      5E   9     5F   
   -   5        # [ 5F      6{   .��5I      �� $
��Auto=�6   $
��Auto=�68   .��5J   
   � -   5        $��rootGrid��5J      .+�5K      �� -   5        $��lbTitle��5K   5   $��32��6D   $
��Left=�6P   $��6,6,0,0q�6k   $
��auto��6|   $	��Top=�5L      $
��Bold"�6,   $��16(�6>   ��5K        *CurrencyAndRate+5L   >   �� 5M      -	   5        $��tabControl1��5M   +   $��6,40,0,0q�6   $	��300��6>   $
��Auto��6N   $	��394��6\   $
��Left=�5N      $	��Top=�64   .@�5O      �� -
   5        $��
tiCurrency��5O   ]   ��6     $! Client.Properties.Resources��$ Currency��.��5P      � .+�5Q      �� -   5        $��button1��5Q   �   $��23��6j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�5R   !   $��45��69   ��5Q   !     $! Client.Properties.Resources��$ AddWithSymbol��5R   D   &   System.Windows.Controls.DataGrid  5S      -   5        $��	dataGrid1��5T   5      AutoGenerateColumns .  $
��Auto��5S   ?   $
��Left=�6M   $��6,38,0,0q�5T   #   $	��Top=�6F   $
��Auto��6^      
IsReadOnly . ��6k   �� *
Currencies+   Columns 5V      4  .System.Windows.Controls.DataGridTemplateColumn  5W   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�      CanUserSort .    SortMemberPath$
 Name��5X   9      CellTemplate# [	 6O      Header 5W   9     $J DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting��$ CurrencyName��5X   ~   0	  *System.Windows.Controls.DataGridTextColumn	  5Y   "   $
 Auto 6�    .  65     $J DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting��$ CurrencyCode��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5Z   5   �� *Code+6P   	  5[   "   $
 Auto 6x    .  65     $! Client.Properties.Resources��$ Comments�� 5\   5   �� *Description+6W     5]   "   $
 Auto 6}    .  # [ 5^   9    5]   9     $! Client.Properties.Resources��$ 	Operation��5^   k   5`      5a      5b      �� 5c      -   5        $��tiRate��5c   a   ��6     $! Client.Properties.Resources��$ ExchangeRate��.��5d      � .+�5e      �� -   5        $��btRate��5e   �   $��23��6j   $
��Left=�6v   $��6,6,0,0q�6�   $	��Top=�5f   !   $��45��69   ��5e   !     $! Client.Properties.Resources��$ AddWithSymbol��5f   D     5g      -   5        $��ratedataGrid��5h   5    .  $
��Auto��5g   ?   $
��Left=�6M   $��6,38,0,0q�5h   #   $	��Top=�6I   $
��Auto��6a    . ��6n   �� *Rates+ 5j      	  5k   "   $
 Auto 6�    .  65     $J DClient.View.SystemSetting.CurrencyRateSetting.ResCurrencyRateSetting��$ CurrencyName�� 5l   5   �� *Currency.Name+6Y     5m   "   $
 Auto 6�    . $ 	RateValue��5n   9   # [
 6T    5m   9     $! Client.Properties.Resources��$ ExchangeRate��5n      	  5o   "   $
 Auto 6x    .  65     $! Client.Properties.Resources��$ Comments�� 5p   5   �� *Description+6W     5q   "   $
 Auto 6}    .  # [ 5r   9    5q   9     $! Client.Properties.Resources��$ 	Operation��5r   h   5t      5u      5v      5w      5x      5y      5z      