   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   I   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      >   8Client.View.SystemSetting.CurrencyRateSetting.RateDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   I   ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$F  @Client.View.SystemSetting.CurrencyRateSetting.ResCurrencySetting��5      $	��278��5   ^   $	��550��5       � WindowStartupLocation$ CenterScreen=�6$    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5           ResxName$! Client.Properties.Resources��
   Key$ ExchangeRate�� � 	Resources 5
       �� 
TargetType �� Property	 �� Value��%�  '��       '�� �     '��     �� 5   
   " ��6   .�5      ��  � ��$	 28��6'   64   �� 5       � ��$		 110��6&   64   �� 5       � ��$	 Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$	 23��6'   64   �� 5       � ��$		 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$	 23��6'   64   �� 5       � ��$		 120��6&   64   5      5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   \   $��32��6k   $
��Left=�6w   $��6,6,0,0q�6�   $
��auto��6�   $	��Top=�5       $
��Bold"�6,   $��16(�6>   ��5        $! Client.Properties.Resources��$ ExchangeRate��5    >   �� 5!      -   5        $��label1��5!   4   $	��100��6   $��6,38,0,0q�6"   
���<��$
��Left=�6W   $	��Top=�5"      �� 5#      -   5        $��	comboBox1��5#   +   $��
122,40,0,0q�6   
 �� SelectedValuePath$
 Id��6_    �� DisplayMemberPath$
 Name��5$      $
��Left=�6\   $	��Top=�6w   ��5#   <   �� *
Currencies+ �� SelectedValue 5$   0   �� *ForeignCurrencyId+6w   �� 5%      -   5        $��label2��5%   d   $��=��6   $��28��6    $��
246,38,0,0q�6,   $��Center=�6@   $	��Top=�5&      $
��Left=�6,   $��18��6G   �� 5'      -   5        $��label3��5'   g   $��
394,38,0,0q�6S   
���<��$
��Left=�6�   $��60��5(      $
��Left=�6   $��28��6A   $	��Top=�6M   ��5'        $! Client.Properties.Resources��$	 CNY��5(   M   &    Utility.Controls.CurrencyTextBox  5)      -   5        $��textBox1��5)   \   $��23��6!   $
��Left=�6-   $��
268,40,0,0q�6H   $	��Top=�5*   !   $	��120��69      Text 6E   �� *CurrencyRate+�� 5+      -   5        $��label4��5+   j   $��6,70,0,0q�6X   $
��Left=�6x   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Comments��6�   �� 5,      -	   5        $��textBox3��5,   R   $	��100��6   $
��Left=�6#   $��
122,72,0,0q�6>   $	��Top=�6b   $	��392��5-       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�67   " �� VerticalScrollBarVisibility$
 Auto=�6K    �� 	MaxLength$ 50��5.      ��5-   n   �� *Description+5.      �� 5/      -
   5        $
��btOK��5/   �   $��25��6X   $
��Left=�6d   $��210,197,0,0q�6   $	��Top=�50      $��60��6-   ��5/        $! Client.Properties.Resources��$ Confirm��50   8   �� 51      -   5        $��btCancel��51   �   $��25��6W   $
��Left=�6c   $��305,197,0,0q�6~   $	��Top=�52      $��60��6-   ��51        $! Client.Properties.Resources��$ Cancel��52   8   55      56      58      