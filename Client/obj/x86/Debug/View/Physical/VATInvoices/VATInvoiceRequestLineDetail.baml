   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      B   <Client.View.Physical.VATInvoices.VATInvoiceRequestLineDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      <baseClient2$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$4  .Client.View.Physical.VATInvoices.ResVATInvoice��5      $	��350��5   v   $	��600��6�    � 
ResizeMode$ NoResize=�5   Q    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5   O     *VATInvoiceRequestDetail+ � 	Resources 5	       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 110��6&   64   �� 5       � ��$	 110��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5      .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5         �Name$ rootGrid��5      .+�5      �� -   5        $��lbTitle��5   z   $��6,6,0,0q�6=   $��16(�6N   $
��Bold"�6\   $��32��6n   $	��Top=�5      $
��Left=�6,   $
��auto��6G   ��5        *VATInvoiceRequestDetail+5   G   �� 5      -   5        $��label2��5   �   $��28��6U   $
��Left=�6a   $��6,38,0,0q�6|   $	��Top=�5      
���<����5        	   ResxName$!	 Client.Properties.Resources��

   Key$
 Quota��5   ,   �� 5       -   5        $��textBox1��5    W   $
��Left=�6   {�.  $��
122,40,0,0q�6C   $	��Top=�5!   /   ��6   �� *	QuotaNo+6/   �� 5"      -   5        $��button2��5"   ^   $	��...��6   $��23��6#   $
��Left=�6/   $��
246,40,0,0q�6J   $	��Top=�5#      $��25��6-   68   �� 5$      -   5        $��label3��5$   `   $��批次未开数量��6   $��28��6%   $
��Left=�61   $��
278,38,0,0q�6L   $	��Top=�5%      &    Utility.Controls.CurrencyTextBox  5&      -   5        $��currencyTextBox2��5&   \   $��23��6!   $
��Left=�6-   $��
394,40,0,0q�6H   $	��Top=�5'   C   $	��120��6[   {�.     Text 6!   �� *UnOpenedQuantity+6g   �� 5(      -   5        $��label9��5(   �   $
��Left=�6V   $��6,70,0,0q�6q   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 Amount��6�     5)      -	   5        $��currencyTextBox1��5)   \   $��23��6!   $
��Left=�6-   $��
122,72,0,0q�6H   $	��Top=�5*   @   $	��120��6X    6!   �� *RequestAmount+6X   �� 5+      -
   5        $��label4��5+   �   $
��Left=�6]   $��
278,70,0,0q�6x   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 ApplyQuantity��6�     5,      -   5        $��currencyTextBox3��5,   \   $��23��6!   $
��Left=�6-   $��
394,72,0,0q�6H   $	��Top=�5-   B   $	��120��6Z    6!   �� *RequestQuantity+6Z   �� 5/      -   5        $��label10��5/   �   $��28��6X   $
��Left=�6d   $��	6,134,0,0q�6   $	��Top=�50      ��5/        $!	 Client.Properties.Resources��$
 Comments��50      �� 51      -   5        $��textBox6��51   S   $	��100��6   $
��Left=�6#   $��122,136,0,0q�6>   $	��Top=�6c   $	��392��52      ��6"   �� *	Comment+�� 54      -   5        $��button3��54   �   $��23��6U   $
��Left=�6a   $��210,260,0,0q�6|   $	��Top=�55      $��60��6-   ��54        $!	 Client.Properties.Resources��$

 Save��55   8   �� 56      -   5        $��button5��57      $��23��56   \   $y�Hidden=�6h   $
��Left=�6|   $��282,260,0,0q�6�   $	��Top=�57   $   $��60��6<   ��56        $!	 Client.Properties.Resources��$
 SaveAsDraft��57   <   �� 58      -   5        $��button4��58   �   $��23��6W   $
��Left=�6c   $��305,260,0,0q�6~   $	��Top=�59      $��60��6-   ��58        $!	 Client.Properties.Resources��$
 Cancel��59   8   �� 5:      -   5        $��label5��5:   �   $
��Left=�6U   $��	6,102,0,0q�6p   $	��Top=�6�   ��6     $!	 Client.Properties.Resources��$
 Price��6�     5;      -   5        $��currencyTextBox4��5<   !   $��23��5;   !   $
��Left=�6-   $��122,104,0,0q�6H   $	��Top=�5<   W   $	��120��6o    69   �� *RequestPrice+6o   �� 5=      -   5        $��	checkBox1��5=   g   $!��该批次增票申请完成��6   $��16��6+   $
��Left=�67   $��394,108,0,0q�6R   $	��Top=�6x    d� 	IsChecked 6�   �� *IsVatRequestFinished+5>      5?      5@      