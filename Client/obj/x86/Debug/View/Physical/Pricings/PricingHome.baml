   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      /    )Client.View.Physical.Pricings.PricingHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5        *ManualPricingHome+ � 	Resources 5         PartialPricingList  CompletedPricingList  UnpricedPricingList��%W   &	        &	      &	 &     �� 5   
   65   �� 5   
   67   �� 5   
   66   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6�     5   
   -   5        # [ 5      6�     5   
   -   5        # [ 5      6�   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   7   $��32��6F   $
��Left=�6R   $��6,6,0,0q�6m   $	��Top=�6~   $
��Bold"�6�   $��16(�6�   ��6     *ManualPricingHome+6�   �� 5      -   5        $��	groupBox1��5   m   $	��180��62   $
��Left=�6?   $��	40,40,0,0q�6Z   $	��Top=�6~   $	��250��6�   ��6     *
AddPricing+.��5      � .+�5      �� -   5        $��label1��5   �   $��28��6e   $	��100��6q   $��Right=�6}   $
��Left=�6�   $��6,46,0,0q�6�   $	��Top=�6�   ��6        ResxName$! Client.Properties.Resources��
   Key$ ManualPricing��6�   �� 5      -   5        $��button1��5   d   $��+��6   $��23��6)   $
��Left=�65   $��
120,47,0,0q�6P   $	��Top=�6s   $��75��6�   6�   �� 5       -	   5        $��label2��5    �   $��28��6:   $	��100��6F   $��Right=�6R   $
��Left=�6u   $��6,80,0,0q�6�   $	��Top=�6�   ��6     *PricingDefer+6�   �� 5!      -
   5        $��button2��5!   d   $��+��6   $��23��6)   $
��Left=�65   $��
120,81,0,0q�6P   $	��Top=�6s   $��75��6�   6�   5"      5#      �� 5$      -   5        $��	groupBox2��5$   �   $	��180��6Y   $
��Left=�6f   $��
330,40,0,0q�6�   $	��Top=�5%      $	��250��6/   $y�Hidden=�6;   ��5$        $! Client.Properties.Resources��$ Reports��.��5&      � .+�5'      �� -   5        $��
textBlock1��5'   g   $��23��6    $
��auto��6,   $
��Left=�69   $��	27,23,0,0q�6T   $	��Top=�6y   �� 5(      .�6$   .�5)      �� �6"     *PricingDetail+6@   5*      5+      5,      5-      �� 5.      -   5        $��	groupBox3��5.   �   $	��270��6W   $
��Left=�6d   $��
40,225,0,0q�6   $	��Top=�6�   $	��540��6�   ��6     $! Client.Properties.Resources��$ Query��.��5/      � .+�50      �� -   5        $��label3��50   �   $��28��6e   $
��Left=�6q   $��6,6,0,0q�6�   $	��Top=�6�   $
��Bold"�6�   ��6     $! Client.Properties.Resources��$ QueryShortcut��6�   �� 51      -   5        $��
textBlock4��51   Z   $��23��6    $
��Left=�6,   $��	42,40,0,0q�6G   $	��Top=�6l   $��90��6�   �� 52       �� Command# [ 6$   .�6S   .�53      �� �6"     *UnpricedQuota+54      55      �� 56      -   5        $��
textBlock2��56   h   $��23��6    $
��Left=�6,   $��
171,40,0,0q�6G   $
��Auto��6[   $	��Top=�6z   �� 57      # [  6$   .�6R   .�58      �� �6"     *PartialPricedQuota+6E   59      5:      �� 5;      -   5        $��
textBlock3��5;   f   $��23��6    $��90��6,   $
��Left=�67   $��
300,40,0,0q�6R   $	��Top=�6x   �� 5<      # [ 6$   .�6T   .�5=      �� �6"     *PricedQuota+6>   5>      5?      �� 5@      -   5        $��label4��5@   �   $��28��6e   $
��Left=�6q   $��6,70,0,0q�6�   $	��Top=�6�   $
��Bold"�6�   ��6     $! Client.Properties.Resources��$ AdvancedQuery��6�   �� 5A      -   5        $��label5��5A   �   $��28��6]   $	��100��6i   $��Right=�6u   $
��Left=�6�   $��1,98,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ Quota��6�   �� 5B      -   5        $��textBox1��5B   ?   $��23��6   $��107,100,0,0q�6*   $	��Top=�6O   $
��Left=�6g   $	��120��6�   {�.  ��6�   �� *	QuotaNo+6�   �� 5C      -   5        $��button3��5C   g   $	��...��6   $��23��6+   $
��Left=�67   $��231,100,0,0q�6R   $	��Top=�6v   $��25��6�   6�   �� 5D      -   5        $��label6��5D   �   $��28��6Z   $	��100��6f   $��Right=�6r   $
��Left=�6�   $��
267,98,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ BP��6�   �� 5E      -   5        $��textBox2��5E   l   $��23��6   $
��Left=�6*   {�.  $��373,100,0,0q�6W   $	��Top=�6|   $	��120��6�   ��6�   �� *BPName+�� 5F      -   5        $��button4��5F   g   $	��...��6   $��23��6+   $
��Left=�67   $��497,100,0,0q�6R   $	��Top=�6v   $��25��6�   6�   �� 5G      -   5        $��label7��5G   �   $��28��6c   $	��100��6o   $��Right=�6{   $
��Left=�6�   $��	1,130,0,0q�6�   $	��Top=�6�   ��6     $! Client.Properties.Resources��$ PricingSide��6�   �� 5H      -   5        $��	comboBox1��5H   [   $��23��6   $
��Left=�6+   $��107,132,0,0q�6F   $	��Top=�6l   $	��120��6�   	 �� SelectedValuePath$	 Id��5I   D   
 �� DisplayMemberPath$

 Name��6[   ��6   �� *PricingSides+ �� SelectedValue 6t   �� *SelectedPricingSideId+�� 5J      -   5        $��button5��5J   �   $��23��6^   $
��Left=�6j   $��188,173,0,0q�6�   $	��Top=�6�   $��75��6�   ��6     $! Client.Properties.Resources��$ Query��6�   �� 5K      -   5         ��Name$ button6��5K   �   $��23��6^   $
��Left=�6j   $��292,173,0,0q�6�   $	��Top=�6�   $��75��6�   ��6     $! Client.Properties.Resources��$ Reset��6�   �� 5L      -   5        $��	checkBox1��5L   o   $!��仅显示当前用户文档��6   $��16��63   $
��Left=�6?   $��373,135,0,0q�6Z   $	��Top=�6�    d� 	IsChecked 6�   �� *ContainCurrentUser+5M      5N      5O      5P      5Q      