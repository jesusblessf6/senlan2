   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   1   A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      =   7Client.View.SystemSetting.DataDictSetting.VATRateDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5   1   ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$B  <Client.View.SystemSetting.DataDictSetting.ResDataDictSetting��5      $	��323��5      $	��600��6%    � WindowStartupLocation$ CenterScreen=�5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5   O     *VAT+ � 	Resources 5
       �� 
TargetType �� Property �� Value��%�  '��       '�� �     '��     �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   )   $��32��68   $
��Left=�6D   $��6,6,0,0q�6_   $
��auto��6p   $	��Top=�5       $
��Bold"�6,   $��16(�6>   ��5        *VAT+5    >   �� 5!      -   5        $��label1��5!   ?   $��6,38,0,0q�6-   
���<��$
��Left=�5"      $	��Top=�6/   ��5!        *	TaxCode+5"   /   �� 5#      -   5        $��textBox1��5#   *   $��
122,40,0,0q�6    �� 	MaxLength$ 20��6P   $
��Left=�5$      $	��Top=�61   ��5#   :   �� *Code+5$   1   �� 5%      -   5        $
��btOK��5%   �   $��25��6U   $
��Left=�6a   $��210,229,0,0q�6|   $	��Top=�5&      $��60��6-   ��5%        	   ResxName$!	 Client.Properties.Resources��

   Key$

 Save��5&   8   �� 5'      -   5        $��btCancel��5'   �   $��25��6W   $
��Left=�6c   $��305,229,0,0q�6~   $	��Top=�5(      $��60��6-   ��5'        $!	 Client.Properties.Resources��$
 Cancel��5(   8   �� 5)      -   5        $��textBox2��5)   S   $	��100��6   $
��Left=�6#   $��122,104,0,0q�6>   $	��Top=�5*      $	��392��6.   $	 250��6W   ��6:   �� *Description+6W   �� 5+      -   5        $��label2��5+   k   $��	6,102,0,0q�6X   $
��Left=�6y   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 Comments��6�   �� 5,      -	   5        $��label3��5,   <   $��6,70,0,0q�6*   
���   �$
��Left=�6]   $	��Top=�5-      ��5,        *Rate+5-      �� 5.      -
   5        $��ratetype��5.   +   $��
394,40,0,0q�6    �� DisplayMemberPath$
 Name��6\    �� SelectedValuePath$ Id��5/      $
��Left=�6M   $	��Top=�6h   ��5.   ;   �� *
VATTypes+ �� SelectedValue 5/   .   �� *Type+6h   �� 50      -   5        $��label4��50   \   $
��Left=�6-   $��
278,38,0,0q�6H   $	��Top=�6j   
���<����6     *	VATType+6�   &    Utility.Controls.CurrencyTextBox  51      -   5        $��currencyTextBox1��51   5   $��
122,72,0,0q�6!   $��23��6h   $	��Top=�52   !   $
��Left=�69   $	��120��6T      Text 51   M   �� *	RateValue+52   T   53      54      56      