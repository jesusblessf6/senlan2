   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      6    0Client.View.Physical.Pricings.AveragePricingHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5
   9     *AveragePricingHome+.��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � -   5        $��rootGrid��5      .+�5      �� -   5        $��lbTitle��5   4   $��32��5   8   $
��Left=�6D   $��6,6,0,0q�6_   $	��Top=�6p   $
��Bold"�5      $��16(�6&   ��5        *AveragePricingHome+5   4   �� 5      -   5        $��	groupBox1��5   R   $	��270��6   $
��Left=�6$   $��	40,40,0,0q�6?   $	��Top=�5      $	��540��6/   $��Normal"�6;   ��5      �� 5      �6        ResxName$! Client.Properties.Resources��
   Key$ Query��6Z   .��5      � .+�5      �� -   5        $��button1��5   t   $��23��6:   $
��Left=�6F   $��	30,40,0,0q�6a   $	��Top=�5      $��85��65      
LinkButton#��[  6@   ��5        *PricedQuota+5   d   �� 5      -   5        $��button2��5      $��23��5   <   $
��Left=�6H   $��
161,40,0,0q�6c   $	��Top=�5   ,   $��95��6D   #��[  6O   ��5        *UnpricedQuota+5   s   �� 5      -   5        $��button3��5      $��23��6D   $
��Left=�6P   $��
271,40,0,0q�6k   $	��Top=�5      $��76��65   #��[  6@   ��5        *PricedQuotaOfTheMonth+5   d   �� 5      -   5        $��button4��5   g   $	��...��6   $��23��6+   $
��Left=�67   $��231,100,0,0q�6R   $	��Top=�5      $��25��65   6@   �� 5      -   5        $��	comboBox3��5   [   $��23��6   $
��Left=�6+   $��373,100,0,0q�6F   $	��Top=�5      $	��120��67    �� SelectedValuePath$ Id��6m    �� DisplayMemberPath$ 	ShortName��5      ��5   C   �� *InternalCustomers+ �� SelectedValue 5   =   �� *InternalCustomerId+�� 5       -	   5        $��	comboBox1��5    [   $��23��6   $
��Left=�6+   $��107,132,0,0q�6F   $	��Top=�5!      $	��120��67   $ Id��6g   $
 Name��6~   ��6C   �� *Commodities+ 5"      �� *CommodityId+�� 5#      -
   5        $��	comboBox2��5#   [   $��23��6   $
��Left=�6+   $��373,132,0,0q�6F   $	��Top=�5$      $	��120��67   $ Id��6j   $
 Name��5%      ��5$   C   �� *PricingBasises+ 5%   8   �� *PricingBasisId+(  "System.Windows.Controls.DatePicker  5&      -   5        $��datePicker1��5&   ]   $��23��6!   $
��Left=�6-   $��107,164,0,0q�6H   $	��Top=�5'   !   $	��120��69      SelectedDate 6E   �� *	StartDate+  5(      -   5        $��datePicker2��5(   ]   $��23��6!   $
��Left=�6-   $��373,164,0,0q�6H   $	��Top=�5)   !   $	��120��69    6E   �� *	EndDate+�� 5*      -   5        $��button6��5*   �   $��23��6^   $
��Left=�6j   $��311,196,0,0q�6�   $	��Top=�5+      $��75��65   ��5*        $! Client.Properties.Resources��$ Query��5+   @   �� 5,      -   5        $��button5��5,   �   $��23��6^   $
��Left=�6j   $��418,196,0,0q�6�   $	��Top=�5-      $��75��65   ��5,        $! Client.Properties.Resources��$ Reset��5-   @   �� 5/      -   5        $��	checkBox1��5/   [   $!��仅显示当前用户文档��6   $��16��6   $
��Left=�6+   $��107,199,0,0q�6F   $	��Top=�6�   	 d� 	IsChecked	 6l   �� *ContainCurrentUser+6�   �� 50      -   5        $��label1��50   �   $��28��6e   $
��Left=�6q   $��6,6,0,0q�6�   $	��Top=�51      $
��Bold"�64   ��50        $! Client.Properties.Resources��$ QueryShortcut��51   4   �� 52      -   5        $��label2��52   �   $��28��6e   $
��Left=�6q   $��6,70,0,0q�6�   $	��Top=�53      $
��Bold"�64   ��52        $! Client.Properties.Resources��$ AdvancedQuery��53   4   �� 54      -   5        $��label3��55   I   $��28��54   Z   $	��100��6f   $��Right=�6r   $
��Left=�55      $��1,98,0,0q�67   $	��Top=�6W   ��54        $! Client.Properties.Resources��$ BP��55   W   �� 56      -   5        $��textBox1��56   Z   $��23��6   $
��Left=�6*   $��107,100,0,0q�6E   $	��Top=�57      $	��120��66   
 �� 
IsReadOnly
 . ��6T   �� *BusinessPartnerName+�� 58      -   5        $��label4��59   K   $��28��58   h   $	��100��6t   $��Right=�6�   $
��Left=�59      $��
267,98,0,0q�67   $	��Top=�6Y   ��58        $! Client.Properties.Resources��$ InternalCustomer��59   Y   �� 5:      -   5        $��label5��5;   J   $��28��5:   a   $	��100��6m   $��Right=�6y   $
��Left=�5;      $��	1,130,0,0q�67   $	��Top=�6X   ��5:        $! Client.Properties.Resources��$ 	Commodity��5;   X   �� 5<      -   5        $��label6��5=   L   $��28��5<   h   $	��100��6t   $��Right=�6�   $
��Left=�5=      $��267,130,0,0q�67   $	��Top=�6Z   ��5<        $! Client.Properties.Resources��$ PricingReference��5=   Z   �� 5>      -   5        $��label7��5?   J   $��28��5>   h   $	��100��6t   $��Right=�6�   $
��Left=�5?      $��	1,162,0,0q�67   $	��Top=�6X   ��5>        $! Client.Properties.Resources��$ PricingStartDate��5?   X   �� 5@      -   5        $��label8��5A   L   $��28��5@   f   $	��100��6r   $��Right=�6~   $
��Left=�5A      $��267,162,0,0q�67   $	��Top=�6Z   ��5@        $! Client.Properties.Resources��$ PricingEndDate��5A   Z   5B      5C      5D      5E      5F      