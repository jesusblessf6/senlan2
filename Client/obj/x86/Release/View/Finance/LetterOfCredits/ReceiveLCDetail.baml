   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  C ?DBEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DBEntity;assembly=DBEntityDBEntity A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient <   6Client.View.Finance.LetterOfCredits.PresentationDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     =DBEntity(clr-namespace:DBEntity;assembly=DBEntity     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$;  5Client.View.Finance.LetterOfCredits.ResLetterOfCredit�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *
LoCRelease+ � 	Resources  �� 
TargetType   
LabelStyle �� Property �� Value(  "System.Windows.Controls.DatePicker  CommercialInvoiceDelete  DeliveryDelete  AttachmentDownLoad  AttachmentDelete  CommercialInvoiceActions �� DataType �� Orientation	   ResxName

   Key  DeliveryActions  AttachmentActions��%+  &	        '�� �     '�� �     '  �     &	 .    &	 3    &	 8    &	 =    &	 B    7  &	 �    7  &	 �    7  7  �� " ��.���  � ��$ 28����  � ��$ 28����  � ��$	 110����  � ��$	 110����  � ��$ Right=��� " ��.���  � ��$ 23����  � ��$	 120���� " ��.���  � ��$ 23����  � ��$	 120���� "  .���  � ��$ 23����  � ��$	 120���� �� �� �� �� $  DBEntity:CommercialInvoice��.R��� $ 
Horizontal=�.+��� $��btCommercialInvoiceDelete��8��  ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+�� $ DBEntity:Delivery��.R��� $ 
Horizontal=�.+��� $��btDeliveryDelete��8��  ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+�� $ DBEntity:Attachment��.R��� $ 
Horizontal=�.+��� $��btAttachmentDownLoad��8��  ��  $!	 Client.Properties.Resources��$
 Download������ *Id+�� $��btAttachmentDelete��8�� ��  $!	 Client.Properties.Resources��$
 Delete������ *Id+ J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [   -   # [ .���� $
��Auto=�$
��Auto=�$	��0,0q�$
��Left=�.��� -   $��rootGrid�� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Left=�$��
122,40,0,0q� �� TextWrapping$
 Wrap=�$	��Top=����� *LCNo+�� -    �� DisplayMemberPath$	 Key��$
��Left=�$��
122,72,0,0q� �� SelectedValuePath$ Value��$	��Top=����� *	LCTypes+ �� SelectedValue �� *LCType+�� $	 Key��$
��Left=�$��411,104,0,0q�$ Value��$	��Top=����� *
LCStatus+ �� *
LCStatusId+�� -   $��button1��$	��...��$
��Left=�$��246,168,0,0q�$	��Top=�$��25��$��23��{��� *
IsBPEnable+�� $ 	ShortName��$
��Left=�$��411,168,0,0q�$ Id��$	��Top=����� *Beneficiaries+ �� *BeneficiaryId+{��� *IsInternalCustomerEnable+�� $
 Name��$
��Left=�$��411,200,0,0q�$ Id��$	��Top=����� *
Currencies+ �� *
CurrencyId+�� -   $��button3��$	��...��$
��Left=�$��
535,40,0,0q�$	��Top=�$��25��$��23��{��� *IsQuotaEnable+&    Utility.Controls.CurrencyTextBox  -	   $��
ctxtLCDays��$��23��$
��Left=�$��
411,72,0,0q�$	��Top=�$��35��   Text �� *LCDays+�� -
   $��cbxPromptBasis��$	 Key��$
��Left=�$��
486,72,0,0q�$ Value��$	��Top=�$��74������ *PromptBasis+ �� *PromptBasisId+�� $
 Name��$
��Left=�$��122,136,0,0q�$ Id��$	��Top=����� *Banks+ �� *AdvisingBankId+�� $
 Name��$
��Left=�$��411,136,0,0q�$ Id��$	��Top=����� *Banks+ �� *IssueBankId+  -   $��currencyTextBox2��$��23��$
��Left=�$��122,200,0,0q�$	��Top=�$	��120�� �� *Amount+  $
��Left=�$��122,232,0,0q�$	��Top=�   SelectedDate �� *	IssueDate+  -   $��currencyTextBox7��$��23��$
��Left=�$��411,232,0,0q�$	��Top=�$	��120�� �� *IssueQuantity+  $
��Left=�$��122,264,0,0q�$	��Top=� �� *AcceptanceExpiryDate+  $
��Left=�$��411,264,0,0q�$	��Top=� �� *LCExpiryDate+  -   $��currencyTextBox1��$��23��$
��Left=�$��122,296,0,0q�$	��Top=�$	��120�� �� *PresentAmount+{��� *IsPresentAmountCanEdit+  $
��Left=�$��411,296,0,0q�$	��Top=� �� *PresentDate+  $
��Left=�$��122,328,0,0q�$	��Top=�$	��120�� �� *LatestShippmentDate+  $
��Left=�$��411,328,0,0q�$	��Top=� �� *ActualAcceptanceDate+�� -   $��	groupBox4��$��贴现利息��$
��Left=�$��35,2,0,0q�$	��Top=�$	��505��$��60��$��1��.��� .+�  -   $��ctxtDiscountRate��$��23��$
��Left=�$��92,9,0,0q�$	��Top=�$	��120�� �� *DiscountRate+  -   $��ctxtDiscountInterest��$��23��$
��Left=�$��	350,9,0,0q�$	��Top=�$	��120�� �� *DiscountInterest+�� -   $��lblDiscountRate��$
��Left=�#��[  $��	-24,7,0,0q�$	��Top=���  *DiscountInterestRate+�� -   $��lblDiscountInterest��$
��Left=�#��[  $��	237,7,0,0q�$	��Top=���  *DiscountInterest+�� -   $��lblDiscountRateC��$��%��$
��Left=�$��23��$��20��$��	212,9,0,0q�$	��Top=��� -   $��	groupBox3��$
��Left=�$��	35,71,0,7q�$	��Top=�$��1��$	��505����  $!	 Client.Properties.Resources��$
 
LCInterest��.��� .+��� -   $��cbxIC��$ Value��$
��Left=�$��92,9,0,0q�$	 Key��$	��Top=����� *LendingRates+ �� *
IBORType+  -   $��ctxtIBORValue��$��23��$
��Left=�$��	350,9,0,0q�$	��Top=�$	��120�� �� *	IBORValue+  -   $��	ctxtFloat��$��23��$
��Left=�$��	92,41,0,0q�$	��Top=�$	��120�� �� *Float+  -   $��ctxtInterest��$��23��$
��Left=�$��
350,41,0,0q�$	��Top=�$	��120�� �� *
Interest+�� -   $��lblIC��$
��Left=�$��85��$��28��$��Right=�$��1,7,0,0q�$	��Top=���  *	LIBORType+�� -   $��lblVlaue��$
��Left=�#��[  $��	235,7,0,0q�$	��Top=���  *InterestRate+�� -   $��lblFloat��$
��Left=�#��[  $��
-24,39,0,0q�$	��Top=���  *Float+�� -   $��lblInterest��$
��Left=�#��[  $��
236,39,0,0q�$	��Top=���  *
Interest+�� -   $��	lblVlaueC��$��%��$
��Left=�$��23��$��20��$��	470,9,0,0q�$	��Top=��� -   $��	lblFloatC��$��%��$
��Left=�$��23��$��20��$��
212,40,0,0q�$	��Top=��� -   $��button4��$
��Left=�$��	122,2,0,0q�{�.  $	��Top=�$��45��$��23��$��2����  $!	 Client.Properties.Resources��$
 AddWithSymbol�� � ToolTip   *
AddInvoice+�� -    $��button2��$
��Left=�$��	340,2,0,0q�$	��Top=�$��45��$��23��$��2����  $!	 Client.Properties.Resources��$
 AddWithSymbol��   *AddBL+�� -!   $��button5��$��23��$
��Left=�$��122,183,0,0q�$	��Top=�$��45��$��2����  $!	 Client.Properties.Resources��$
 AddWithSymbol���� -"   $��textBox6�� �� AcceptsReturn .  �� 
AcceptsTab .  $	��100��$��	122,2,0,0q� �� 	MaxLength$	 255��$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$	��392��$
��Left=�$	��Top=�$��3������ *	Comment+�� -#   $
��Left=�$��210,130,0,0q�$	��Top=�$��60��$��23��$��3����  $!	 Client.Properties.Resources��$

 Save���� $
��Left=�$��432,130,0,0q�$	��Top=�$��60��$��23��$y�Hidden=�$��3����  $!	 Client.Properties.Resources��$
 SaveAsDraft���� -$   $
��Left=�$��305,130,0,0q�$	��Top=�$��60��$��23��$��3����  $!	 Client.Properties.Resources��$
 Cancel���� -%   $��lbTitle��$
��Left=�$��6,6,0,0q�$��32��$	��Top=�$
��Bold"�$��16(���  *
LoCRelease+�� #��[  $��6,38,0,0q�$	��Top=�$
��Left=�
���<����  $!	 Client.Properties.Resources��$
 LoCNo���� #��[  $��
295,38,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 Quota���� $��
411,40,0,0q�$
��Left=�$	��Top=�{�.  ���� *	QuotaNo+�� #��[  $��6,70,0,0q�$
��Left=�$	��Top=�
���<����  *	LoCType+�� -&   $��	lblLCDays��#��[  $��
295,70,0,0q�$
��Left=�$	��Top=���  *LoCDeadline+�� -'   $��lbAft��$��after��$
��Left=�$��28��$��
447,70,0,0q�$	��Top=��� #��[  $��	6,102,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 Status���� $
��Left=� �� 
IsReadOnly . $��122,104,0,0q�$�� ��$	��Top=��� #��[  $��295,102,0,0q�$
��Left=�$	��Top=�
���<����  *	LoCStatus+�� #��[  $��	6,134,0,0q�$
��Left=�$	��Top=���  *
InformBank+�� #��[  $��295,134,0,0q�$
��Left=�$	��Top=���  *	IssueBank+�� #��[  $��	6,166,0,0q�$
��Left=�$	��Top=�
���<����  *	ApplyBP+�� $
��Left=�{�.  $��122,168,0,0q�$	��Top=����� *ApplicantName+�� #��[  $��295,166,0,0q�$
��Left=�$	��Top=�
���<����  *	BenefitBP+�� #��[  $��	6,198,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 	LoCAmount���� #��[  $��295,198,0,0q�$
��Left=�$	��Top=�
���<����  $!	 Client.Properties.Resources��$
 LoCCurrency���� #��[  $��	6,230,0,0q�$
��Left=�$	��Top=���  $!	 Client.Properties.Resources��$
 IssuingDate���� #��[  $��295,230,0,0q�$
��Left=�$	��Top=���  *
IssuingQty+�� #��[  $��	6,262,0,0q�$
��Left=�$	��Top=���  *AcceptanceDueDate+�� #��[  $��295,262,0,0q�$
��Left=�$	��Top=���  *
LoCDueDate+�� #��[  $��	6,294,0,0q�$
��Left=�$	��Top=���  *ReleaseAmount+�� #��[  $��295,294,0,0q�$
��Left=�$	��Top=���  *ReleaseDate+�� #��[  $��	6,326,0,0q�$
��Left=�$	��Top=���  *LatestShipDate+�� #��[  $��295,326,0,0q�$
��Left=�$	��Top=���  *AcceptanceDateInAdvance+�� $��	6,358,0,0q�$
��Left=�$	��Top=�#��[  $��2����  $!	 Client.Properties.Resources��$
 FinancialStatus���� $��122,360,0,7q�$
��Left=�$	��Top=�$ Value��$	 Key������ *StatusTypes+ �� *FinanceStatus+&   System.Windows.Controls.DataGrid  -(   $��	dataGrid2��   AutoGenerateColumns .  $��
122,34,0,0q�$	��140��   
IsReadOnly . $	��172��$	��Top=�$
��Left=�$��2������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .    Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *	InvoiceNo+    Header    $!	 Client.Properties.Resources��$
 CommInvoiceNo��4  .System.Windows.Controls.DataGridTemplateColumn   .  !   CellTemplate#! [ $
 Auto	     $!	 Client.Properties.Resources��$
 	Operation��$   Utility.Controls.PagingControl  -)   $��pagingControl1��$
��Left=�$��	294,2,0,0q�$	��Top=�$	��327��$y�Hidden=�$��2��  -*   $��pagingControl2��$
��Left=�$	��Top=�$	��327��$y�Hidden=�$��0,1,0,0q�$��2���� $��28��$
��Left=�#��[  $��	6,181,0,0q�$	��Top=�$��2����  $!	 Client.Properties.Resources��$
 
Attachment��  -+   $��dataGridAttachment�� .  "   CanUserAddRows" .  $
��Left=� . $��122,215,0,7q�$
��auto��$
��auto��$	��Top=�$��2��    �� *Name+    $!	 Client.Properties.Resources��$
 AttachmentName��   .  #! [     $!	 Client.Properties.Resources��$
 	Operation���� $
��Left=�#��[  $��6,0,0,0q�$	��Top=�$��3����  $!	 Client.Properties.Resources��$
 Comments���� -,   $��label2��$��28��$
��Left=�#��[  $��6,0,0,0q�$	��Top=�$��2����  $!	 Client.Properties.Resources��$
 CommercialInvoice���� --   $��label3��$��28��$
��Left=�$��Right=�$��40��$��	294,0,0,0q�$	��Top=�$��2����  $!	 Client.Properties.Resources��$
 BL��  -.   $��	dataGrid1�� .  $	��140�� . $
��auto��$��
340,34,0,0q�$	��Top=�$
��Left=�$��2������     . $
 Auto	  �� *
DeliveryNo+    $!	 Client.Properties.Resources��$

 BLNo��   . $
 Auto	  �� *OnBoardDate+# �� StringFormat$# 
yyyy-MM-dd��    $!	 Client.Properties.Resources��$
 ShipDate��   . $
 Auto	  �� *	IssueDate+$# 
yyyy-MM-dd��    $!	 Client.Properties.Resources��$
 IssuingDate��   .  #! [ $
 Auto	     $!	 Client.Properties.Resources��$
 	Operation���� -/   $��	checkBox1��$!��该批次已完成收付款��$��16��$
��Left=�$��411,364,0,0q�$	��Top=�$ d� 	IsChecked$ �� *IsLCFinished+