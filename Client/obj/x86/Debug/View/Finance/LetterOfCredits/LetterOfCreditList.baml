   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5      B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 6I   C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity 5      ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  5	      K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity 5
      <    6Client.View.Finance.LetterOfCredits.LetterOfCreditList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6
Convertersclr-namespace:Client.Converters     5      >my/clr-namespace:Utility.Controls;assembly=Utility     6I   =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     5      ;
baseClient$clr-namespace:Client.Base.BaseClient     5	      J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     5
      0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$;  5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��5       � Language 6f   5  /Infralution.Localization.Wpf.UICultureExtension   N� Title 5   @     *	LoCList+ � 	Resources 5      '   !Client.Converters.LCPorSConverter   LCPorSConverter)   #Client.Converters.LCStatusConverter  LCStatusConverter  ListEdit  
ListDelete  ListActions �� DataType �� Orientation   ResxName
   Key��%Y  &	        &	      &	 &     &	 9     &	 L     7  7    5   
   6%     5   
   6'   �� 5   
   6+   �� 5   
   6-   �� 5   
   $ DBEntity:LetterOfCredit��6+   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��
btListEdit��6   8��  ��6+     $! Client.Properties.Resources��$
 Edit����5      �� *Id+{�69   �� *AutoGenGeneratedCanOperation+6n   �� 5      $��btListDelete��6   8�� ��6-     $! Client.Properties.Resources��$ Delete����5      �� *Id+{�69   �� *AutoGenGeneratedCanOperation+6n   5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [ 5      5   7     5   
   -   5        #	 [ 5      5   9   .��5!      �� $
��Auto=�6   $
��Auto=�68   $	��0,0q�6[   $
��Left=�5"      .��5#   
   � -   5        
 �Name$
 rootGrid��5#      .+�5$      �� -   5        $��lbTitle��5$   -   $��32��6<   $
��Left=�6H   $��6,6,0,0q�6c   $
��auto��6t   $	��Top=�5%      $
��Bold"�6,   $��16(�6>   ��5$        *	LoCList+5%   >   $  Utility.Controls.PagingControl  5'      -   5          Name$ 	pagerList��5'      $��6,40,0,0q�62   $	��Top=�6D   $
��Left=�6\   &   System.Windows.Controls.DataGrid  5(      -   5          Name$ listGrid��5(   )   $��6,77,0,0q�6      AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[ 6o     DataGridRowStyle   RowStyle# [ 6�      
IsReadOnly . $	��Top=�5)   I   $
��Left=�6a      Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,	  &System.Windows.Controls.DataGridColumn 	  Header 6)     $! Client.Properties.Resources��$ LoCNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6i   �� *LCNo+  5,      $ 	批次号��6)    66   �� *Quota.QuotaNo+  5-       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	IssueBank�� 6�   �� *
Bank1.Name+  5.       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
InformBank�� 6�   �� *	Bank.Name+  5/       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ ApplyBP�� 6�   �� *BusinessPartner.ShortName+  50       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	BenefitBP�� 6�   �� *BusinessPartner1.ShortName+  51       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	LoCStatus�� 52   )   �� *
LCStatus+ �� 	Converter# [   53       6)     $! Client.Properties.Resources��$ 	LoCAmount�� 6m   �� *IssueAmount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z   54      $ 交单金额��6)    67   �� *PresentAmount+# Z   55       6)     $! Client.Properties.Resources��$ Currency�� 6l   �� *Currency.Name+  56       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
IssuingQty�� 6�   �� *IssueQuantity+   STR_QUANTITY# Z   57       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ AcceptanceDueDate�� 58   )   �� *AcceptanceExpiryDate+$ 
yyyy-MM-dd��  59       6)     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ LoCType�� 5:   )   �� *Id+# [  4  .System.Windows.Controls.DataGridTemplateColumn  5;       	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6q    	  CanUserSort .     CellTemplate# [ 5<   -    5;   -     $! Client.Properties.Resources��$ 	Operation��5<   [   5>      5?      5@      5A      