   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5	   2   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5
      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5      6    0Client.View.Physical.Payments.PaymentRequestList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     5	   2   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5
      ;
baseClient$clr-namespace:Client.Base.BaseClient     5      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Payments.ResPayment��5       � Language 5      5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5	        *PaymentRequestList+ � 	Resources 5      .   (Client.Converters.ApproveStatusConverter   ApproveStatusConverter5   /Client.Converters.PaymentRequestStatusConverter ! PaymentRequestStatusConverter  PaymentRequestEdit  PaymentRequestDelete  PaymentRequestPrint  PaymentRequestActions �� DataType �� Orientation   ResxName
   Key��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     7  7  7    5   
   6,     5   
   63   �� 5   
   65   �� 5   
   67   �� 5   
   66   �� 5   
   $ DBEntity:PaymentRequest��65   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��btPaymentRequestEdit��6   8��  ��65     $! Client.Properties.Resources��$
 Edit����5      �� *Id+6;   �� 5      $��btPaymentRequestDelete��6   8�� ��67     $! Client.Properties.Resources��$ Delete����5      �� *Id+6;   �� 5      $��btPaymentRequestPrint��6   $��打印��66   8�� $y�Hidden=�5   9   ��6   �� *Id+6O   5      5      5        J� CommandBindings 5"      )  #System.Windows.Input.CommandBinding  5#   
   -   5        	   Command#	 [ 5#      5$   A     5%   
   -   5        #	 [ 5%      5&   C     5'   
   -   5        #	 [ 5'      5(   B   .��5+      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5,      .��5-   
   � -   5        
 �Name$
 rootGrid��5-      .+�5.      �� $ 
Horizontal=�6   $��6,40,0,0q�62   $
��Auto��6D   $
��Auto��6R   $	��Top=�6_   $
��Left=�6w   .+�5/      $  Utility.Controls.PagingControl  -   5        $��pagingControl1��5/   >   $
��Left=�6#   $	��Top=�50      �� 51      -   5        $��打印付款申请��51      $��10,0,0,0q�6*   $��23��6P   6^   52      �� 54      -   5        $��label1��54   8   $��32��6F   $
��Left=�6R   $��6,6,0,0q�6m   $
��auto��6~   $	��Top=�55      $
��Bold"�6,   $��16(�6>   ��54        *PaymentRequestList+55   >   &   System.Windows.Controls.DataGrid  56      -   5          Name$ contractGrid��56   E      AutoGenerateColumns .  $��6,77,0,0q�63   $	��Top=�6[      
IsReadOnly . $
��Left=�57   J     DataGridStyle#��[ 6e     DataGridRowStyle   RowStyle# [ 58      ��6D   ��    Columns 59      4  .System.Windows.Controls.DataGridTemplateColumn  5:      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 6-    	  
IsReadOnly .  	  Header 5;      �� 5<      -	   5        $��cbSelectAll��5<   I   $��全选��6\   $��Center=�6i   $��Center=�6�    d� 	IsChecked 6'   �� *IsSelectAll+6�      CellTemplate 5>      �� 5?      $ DBEntity:PaymentRequest��6+   .R�5@   "   �� -
   5        $��Center=�5@   r   $��Center=�6�    6+   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�{�6�   �� *	Printable+
 � Tag 6�   �� *Id+60  5A      5C      0  *System.Windows.Controls.DataGridTextColumn  5D        DataGridColumnHeaderStyle 	  HeaderStyle# [ 6�    6)     $! Client.Properties.Resources��$ QuotaNo��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6k   �� *Quota.QuotaNo+6�     5E      # [ 6�    6)     $! Client.Properties.Resources��$ ApplyDateShort�� 6r   �� *RequestDate+ �� StringFormat$ 
yyyy-MM-dd��6�     5F      # [ 5G   )    5F   )     $! Client.Properties.Resources��$ 	ReceiptBP�� 6m   �� *" ReceiveBusinessPartner.ShortName+5G   )     5H      # [ 5I   )    5H   )     $! Client.Properties.Resources��$ 	PaymentBP�� 6m   �� *PayBusinessPartner.ShortName+5I   )     5J      # [ 5K   )    5J   )     $! Client.Properties.Resources��$ AppliedAmount�� 6q   �� *RequestAmount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT# Z 5K   )     5L      # [ 5M   )    5L   )     $! Client.Properties.Resources��$ PaymentCurrency�� 6s   �� *Currency.Name+5M   )     5N      # [ 5P   )    5N   )     $! Client.Properties.Resources��$ 
PaidAmount�� 5O   )   �� *
PaidAmount+# Z 5P   )     5Q      # [ 5R   )    5Q   )     $! Client.Properties.Resources��$ PaymentMean�� 6o   �� *PaymentMean.Name+5R   )     5S      # [ 5T   )    5S   )     $! Client.Properties.Resources��$ PaymentUsage�� 6p   �� *PaymentUsage.Name+5T   )     5U      # [ 5W   )    5U   )     $. (Client.View.Physical.Payments.ResPayment��$ PaymentStatus�� 5V   )   �� *IsPaid+ �� 	Converter# [ 5W   )     5X      # [ 5Y   )    5X   )     $. (Client.View.Physical.Payments.ResPayment��$ 	Applicant�� 6z   �� *	User.Name+5Y   )     5Z      # [ 5[   )    5Z   )     $! Client.Properties.Resources��$ Approval�� 6l   �� *Approval.Name+5[   )     5]       	  CanUserSort .  # [ 5^   -    5]   -     $! Client.Properties.Resources��$ ApprovalDetail�� 5_      �� 5`      $ DBEntity:PaymentRequest��6+   .R�5a   "   �� �� 5b   &   
��� � ��6=   �� *CustomerStrField1+6b    �� 5c   &   
���  ���6;   �� *CustomerStrField2+6`   5d   #   5e      5g        5h      # [ 6r    6)     $! Client.Properties.Resources��$ ApprovalStatus�� 5i   )   �� *ApproveStatus+# [    5j      # [ 5k   )    5j   )     $! Client.Properties.Resources��$ RejectReason�� 6p   �� *RejectReason+5k   d     5l      $
 auto
 6q    .  # [ 5m   -   # [ 6f    5l   -     $! Client.Properties.Resources��$ 	Operation��5m   �   5o      5p      5q      5r      