   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5      /   )Client.View.Physical.Contracts.MoreDetail   5      6my/clr-namespace:Utility.Controls;assembly=Utility  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$0  *Client.View.Physical.Contracts.ResContract��5      $	��250��5      $	��550��6%    � Language 5   c   5  /Infralution.Localization.Wpf.UICultureExtension   � Title 5   W     *	BrandSpec+ � 	Resources 5	       �� 
TargetType �� Property �� Value��%�  '��       '�� �     '��     �� 5
   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$	 110��6&   64   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      5      .��5      � -   5         �Name$ rootGrid��5      .+�5   
   �� -   5        $��lbTitle��5   +   $��32��6:   $
��Left=�5      $��6,6,0,0q�6+   $
��auto��6<   $	��Top=�6I   $
��Bold"�6a   $��16(�6s   ��5        *	BrandSpec+5   s   �� 5    
   -   5        $��label1��5!   =   
���<��$
��Left=�6   $��6,38,0,0q�6+   $	��Top=�6K   ��5            ResxName$! Client.Properties.Resources��
	   Key$	 Brand��5!   K   �� 5"   
   -   5        $��	comboBox1��5"   N   $��23��6   $
��Left=�6   $��
122,40,0,0q�6:   $	��Top=�6_   
 �� DisplayMemberPath$

 Name��5#   T    �� SelectedValuePath$ Id��6m   ��6   �� *Brands+ �� SelectedValue 62   �� *	BrandId+6m   �� 5$   
   -   5        $��label2��5%   $   $
��Left=�5$   Y   $��
278,38,0,0q�5%      $	��Top=�62   ��5$        $! Client.Properties.Resources��$	 Specification��5%   2   �� 5&   
   -   5        $��	comboBox2��5&   B   $
��Left=�6   $��
394,40,0,0q�6.   $	��Top=�6S   $

 Name��5'   d   $ Id��5(      ��5'      �� *Specifications+ 6:   �� *SpecificationId+5(      �� 5)   
   -   5        $��label3��5*   =   
���<��$
��Left=�6   $��6,70,0,0q�6+   $	��Top=�6K   ��5)        $! Client.Properties.Resources��$	 Quantity��5*   K   &    Utility.Controls.CurrencyTextBox  5+   
   -   5        $��currencyTextBox1��5+   X   $��23��6   $
��Left=�6)   $��
122,72,0,0q�6D   $	��Top=�5,      $	��120��65      Text 6A   �� *
Quantity+�� 5-   
   -	   5        $��label4��5.   ?   
���<��$
��Left=�6   $��
278,70,0,0q�6+   $	��Top=�6M   ��5-        $! Client.Properties.Resources��$	 Price��5.   M     5/   
   -
   5        $��currencyTextBox2��5/   X   $��23��6   $
��Left=�6)   $��
394,72,0,0q�6D   $	��Top=�50      $	��120��65    6A   �� *Price+�� 51   
   -   5        $��label5��52   #   $
��Left=�51   U   $��	6,102,0,0q�52      $	��Top=�61   ��51        $! Client.Properties.Resources��$	 	Warehouse��52   1   �� 53   
   -   5        $��textBox1��53   B   $
��Left=�6   $��122,104,0,0q�6-   $	��Top=�6R    �� 
IsReadOnly . ��54      �� *WarehouseName+61   �� 55   
   -   5        $��button1��55   [   $	��...��6   $��23��6   $
��Left=�6+   $��246,104,0,0q�6F   $	��Top=�56      $��25��6)   64   �� 57   
   -   5        $��button2��58   A   $��25��57   T   $
��Left=�58      $��210,152,0,0q�6,   $	��Top=�6P   $��60��6h   ��57        $! Client.Properties.Resources��$	 Confirm��58   s   �� 59   
   -   5        $��button3��5:   A   $��25��59   S   $
��Left=�5:      $��305,152,0,0q�6,   $	��Top=�6P   $��60��6h   ��59        $! Client.Properties.Resources��$	 Cancel��5:   s   5;      5<      