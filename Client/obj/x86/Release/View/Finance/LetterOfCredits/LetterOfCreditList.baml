   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity ?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  K3clr-namespace:DBEntity.EnumEntity;assembly=DBEntityDBEntity.EnumEntity <    6Client.View.Finance.LetterOfCredits.LetterOfCreditList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6
Convertersclr-namespace:Client.Converters     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     J
enumEntity3clr-namespace:DBEntity.EnumEntity;assembly=DBEntity     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$;  5Client.View.Finance.LetterOfCredits.ResLetterOfCredit�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *	LoCList+ � 	Resources '   !Client.Converters.LCPorSConverter   LCPorSConverter)   #Client.Converters.LCStatusConverter  LCStatusConverter  ListEdit  
ListDelete  ListActions �� DataType �� Orientation   ResxName
   Key��%�  &	        &	      &	 
     &	      &	      7  7      �� �� �� $ DBEntity:LetterOfCredit��.R��� $ 
Horizontal=�.+��� $��
btListEdit��8��  ��  $! Client.Properties.Resources��$
 Edit������ *Id+{��� *AutoGenGeneratedCanOperation+�� $��btListDelete��8�� ��  $! Client.Properties.Resources��$ Delete������ *Id+{��� *AutoGenGeneratedCanOperation+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -   	   Command#	 [   -   #	 [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -   
 �Name$
 rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(���  *	LoCList+$  Utility.Controls.PagingControl  -     Name$ 	pagerList��$��6,40,0,0q�$	��Top=�$
��Left=�&   System.Windows.Controls.DataGrid  -     Name$ listGrid��$��6,77,0,0q�   AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[   DataGridRowStyle   RowStyle# [    
IsReadOnly . $	��Top=�$
��Left=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header   $! Client.Properties.Resources��$ LoCNo��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *LCNo+  $ 	批次号�� �� *Quota.QuotaNo+     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	IssueBank�� �� *
Bank1.Name+     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
InformBank�� �� *	Bank.Name+     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ ApplyBP�� �� *BusinessPartner.ShortName+     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	BenefitBP�� �� *BusinessPartner1.ShortName+     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 	LoCStatus�� �� *
LCStatus+ �� 	Converter# [      $! Client.Properties.Resources��$ 	LoCAmount�� �� *IssueAmount+$  DBEntity.EnumEntity.RoundRules   
STR_AMOUNT �� StringFormat# Z   $ 交单金额�� �� *PresentAmount+# Z      $! Client.Properties.Resources��$ Currency�� �� *Currency.Name+     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ 
IssuingQty�� �� *IssueQuantity+   STR_QUANTITY# Z      $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ AcceptanceDueDate�� �� *AcceptanceExpiryDate+$ 
yyyy-MM-dd��     $; 5Client.View.Finance.LetterOfCredits.ResLetterOfCredit��$ LoCType�� �� *Id+# [  4  .System.Windows.Controls.DataGridTemplateColumn   	  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto  	  CanUserSort .     CellTemplate# [    $! Client.Properties.Resources��$ 	Operation��