   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters 6K   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5	      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient 5
      J   DClient.View.SystemSetting.BusinessPartnerSetting.BusinessPartnerHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5      6
Convertersclr-namespace:Client.Converters     6K   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5	      ;
baseClient$clr-namespace:Client.Base.BaseClient     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$P  JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��5      $
��auto��5   $   $
��auto��61    � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   !     *BPHome+ � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value4  .Client.Converters.BusinessPartnerTypeConverter  ConvertType.  (Client.Converters.ApproveStatusConverter  ApproveStatusConverter  PartnerEdit  PartnerDelete  PartnerView  PartnerActions �� DataType �� Orientation	   ResxName

   Key��%!  &	        '�� �     '�� m    &	 �    &	 �    &	 
    &	     &	 0    &	 C    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 28��6'   64   �� 5       � ��$ 28��6*   67   �� 5       � ��$	 100��6&   64   �� 5       � ��$	 100��6)   67   �� 5       � ��$ Right=�6;   6K   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   64   �� 5       � ��$	 120��6&   64   5         5"   
   62     5#   
   6M   �� 5%   
   6.   �� 5&   
   60   �� 5'   
   6.   �� 5)   
   $ DBEntity:BusinessPartner��6.   .R�5*      �� $ 
Horizontal=�6   .+�5+      �� $��btPartnerEdit��6   8��  ��6.     $!	 Client.Properties.Resources��$

 Edit����5,      �� *Id+6;   �� 5-      $��btPartnerDelete��6   8�� ��60     $!	 Client.Properties.Resources��$
 Delete����5.      �� *Id+6;   5/      50      51       J� CommandBindings 53      )  #System.Windows.Input.CommandBinding  54   
   -   5           Command# [ 54      55   :     56   
   -   5        # [ 56      57   <     58   
   -   5        # [ 58      59   :   .��5<      �� $
��Auto=�6   $
��Auto=�68   .��5=   
   � -   5         �Name$ rootGrid��5=      .+�5>      �� -   5        $��lbTitle��5>   d   $��32��6,   $
��Left=�68   $��6,6,0,0q�6S   $
��auto��6s   $	��Top=�5?      $
��Bold"�6,   $��16(�6>   ��5>        *BPList+5?   >   �� 5@      -   5        $��btnAdd��5@   �   $��23��6^   $
��Left=�6j   $��6,40,0,0q�6�   $	��Top=�5A      $��60��6-   ��5@        $!	 Client.Properties.Resources��$
 AddWithSymbol��5A   8   �� 5B      -   5        $��
separator1��5B   6   $��17��6   $��6,63,6,0q�6$   $	��Top=�6H   �� 5C      -   5        $��	groupBox1��5C   �   $��65��6\   $
��Left=�6h   $��6,75,0,0q�6�   $	��Top=�5D      $	��600��6/   ��5C        $!	 Client.Properties.Resources��$
 
Conditions��.��5E      � .+�5F      �� -	   5        $��label2��5G   .   $
��Left=�5F   \   #��[  6w   $��1,10,0,0q�5G      $	��Top=�6<   ��5F        $!	 Client.Properties.Resources��$

 Name��5G   <   �� 5H      -
   5        $��txtName��5H   M   $
��Left=�6   $��
107,12,0,0q�69   $	��Top=�6\   ��5I      �� *
SearchName+�� 5J      -   5        $��label3��5K   0   #��[  5J   \   $
��Left=�6�   $��
240,10,0,0q�5K      $	��Top=�6>   ��5J        $!	 Client.Properties.Resources��$

 Type��5K   >   �� 5L      -   5        $��comboBoxType��5L   N   $
��Left=�6   $��
346,12,0,0q�6:   $	��Top=�5M       �� DisplayMemberPath$
 Name��6d    �� SelectedValuePath$ Id��6}   ��67   �� *BusinessPartnerTypes+ �� SelectedValue 5N      �� *SelectedType+6H   �� 5O      -   5        $��	btnSearch��5O   �   $��23��6^   $
��left=�6j   $��
481,12,0,0q�6�   $	��Top=�5P      $��45��65   ��5O        $!	 Client.Properties.Resources��$
 Query��5P   @   5Q      5R      �� 5S      -   5        $��
separator2��5S   7   $��17��6   $��	6,140,6,0q�6$   $	��Top=�6I   $   Utility.Controls.PagingControl  5T      -   5        $��
pgPartners��5T   2   $��	6,154,0,0q�6   $��31��6D   $	��Top=�6P   $
��Left=�5U      &   System.Windows.Controls.DataGrid  5V      -   5        $��dataGridPartner��5V   a      AutoGenerateColumns .  $
��Left=�63   $��	6,191,0,0q�6N   $	��Top=�5W         CanUserAddRows .     
IsReadOnly .   DataGridStyle#��[ 5Y        DataGridRowStyle   RowStyle# [ 6>   ��5W   F   ��    Columns 5Z      4  .System.Windows.Controls.DataGridTemplateColumn  5[      ,	  &System.Windows.Controls.DataGridColumn 	  CanUserSort .  	  SortMemberPath$ 	ShortName��6�    	 DataGridColumnHeaderStyle 	  HeaderStyle# [	 5\   -    	  Header 5[   -     $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 BPShortName��   CellTemplate 5]      �� 5^      $ DBEntity:BusinessPartner��6+   .R�5_   "   �� �� 5`   &    �� Command# [ 60    �� CommandParameter 6W   �� *Id+.�6w   .�5a   *   �� �6.   �� *	ShortName+6K   5b   '   5c   #   5d      5f      0
  *System.Windows.Controls.DataGridTextColumn
  5g       .  	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   # [	 6�    6)     $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 
BPFullName��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *Name+6  
  5h       . $
 Auto 6�   # [	 6�    6)     $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 EnglishFullName�� 6�   �� *EnglishName+6  
  5i      # [	 6h    . $
 Auto 5j   �    5i   )     $!	 Client.Properties.Resources��$

 Type�� 5j   )   �� *CustomerType+ �� 	Converter# [ 6�   
  5k       . $
 Auto 6�   # [	 5l   )    5k   )     $P	 JClient.View.SystemSetting.BusinessPartnerSetting.ResBusinessPartnerSetting��$
 BPCode�� 6�   �� *Code+5l   e   
  5m       . $
 Auto 6�   # [	 5n   )    5m   )     $!	 Client.Properties.Resources��$
 Address�� 6k   �� *	Address+5n   e   
  5o       . $
 Auto 6�   # [	 5p   )    5o   )     $!	 Client.Properties.Resources��$
 ContactPerson�� 6q   �� *ContactPerson+5p   e   
  5q       . $
 Auto 6�   # [	 5r   )    5q   )     $!	 Client.Properties.Resources��$	
 Tel�� 6g   �� *ContactPhone+5r   d   
  5s       . $
 Auto 6�   # [	 5t   )    5s   )     $!	 Client.Properties.Resources��$	
 Fax�� 6g   �� *Fax+5t   e   
  5u       . $
 Auto 6�   # [	 5v   )    5u   )     $!	 Client.Properties.Resources��$
 PostCode�� 6l   �� *	ZipCode+5v   e   
  5w       . # [	 5z   )    5w   )     $!	 Client.Properties.Resources��$
 ApprovalStatus�� 5y   )   �� *ApproveStatus+# [ 5{      
  5|       . # [	 5~   )    5|   )     $!	 Client.Properties.Resources��$
 Approval�� 5}   <   �� *Approval.Name+5        5�       .  # [	 5�   -    5�   -     $!	 Client.Properties.Resources��$
 ApprovalDetail�� 5�      �� 5�      $ DBEntity:BusinessPartner��6+   .R�5�   "   �� $��Center=�6,   �� 5�   &   
��� � ��6=   �� *CustomerStrField1+6b    �� 5�   &   
���  ���6;   �� *CustomerStrField2+6`   5�   #   5�      5�      
  5�       . $
 Auto 5�   ]   # [	 5�   )    5�   )     $!	 Client.Properties.Resources��$
 RejectReason�� 5�   )   �� *RejectReason+5�      
  5�       . $
 Auto 6�   # [	 5�   )    5�   )     $!	 Client.Properties.Resources��$
 Comments�� 6l   �� *Remark+5�   e     5�      $
 Auto 6q    .  # [	 5�   )   # [ 5�   -    5�   -     $!	 Client.Properties.Resources��$
 	Operation��5�   ^   5�      5�      5�      5�      