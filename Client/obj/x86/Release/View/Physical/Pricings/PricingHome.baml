   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  /    )Client.View.Physical.Pricings.PricingHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$.  (Client.View.Physical.Pricings.ResPricing�� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   N� Title   *ManualPricingHome+ � 	Resources    PartialPricingList  CompletedPricingList  UnpricedPricingList��%-   &	        &	      &	 
     �� �� ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [ .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(���  *ManualPricingHome+�� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����  *
AddPricing+.��� .+��� -   $��label1��$��28��$	��100��$��Right=�$
��Left=�$��6,46,0,0q�$	��Top=���     ResxName$! Client.Properties.Resources��
   Key$ ManualPricing���� -   $��button1��$��+��$��23��$
��Left=�$��
120,47,0,0q�$	��Top=�$��75���� -	   $��label2��$��28��$	��100��$��Right=�$
��Left=�$��6,80,0,0q�$	��Top=���  *PricingDefer+�� -
   $��button2��$��+��$��23��$
��Left=�$��
120,81,0,0q�$	��Top=�$��75���� -   $��	groupBox2��$	��180��$
��Left=�$��
330,40,0,0q�$	��Top=�$	��250��$y�Hidden=���  $! Client.Properties.Resources��$ Reports��.��� .+��� -   $��
textBlock1��$��23��$
��auto��$
��Left=�$��	27,23,0,0q�$	��Top=��� .�.��� �  *PricingDetail+�� -   $��	groupBox3��$	��270��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.��� .+��� -   $��label3��$��28��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ QueryShortcut���� -   $��
textBlock4��$��23��$
��Left=�$��	42,40,0,0q�$	��Top=�$��90����  �� Command# [ .�.��� �  *UnpricedQuota+�� -   $��
textBlock2��$��23��$
��Left=�$��
171,40,0,0q�$
��Auto��$	��Top=��� # [  .�.��� �  *PartialPricedQuota+�� -   $��
textBlock3��$��23��$��90��$
��Left=�$��
300,40,0,0q�$	��Top=��� # [ .�.��� �  *PricedQuota+�� -   $��label4��$��28��$
��Left=�$��6,70,0,0q�$	��Top=�$
��Bold"���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��label5��$��28��$	��100��$��Right=�$
��Left=�$��1,98,0,0q�$	��Top=���  $! Client.Properties.Resources��$ Quota���� -   $��textBox1��$��23��$��107,100,0,0q�$	��Top=�$
��Left=�$	��120��{�.  ���� *	QuotaNo+�� -   $��button3��$	��...��$��23��$
��Left=�$��231,100,0,0q�$	��Top=�$��25���� -   $��label6��$��28��$	��100��$��Right=�$
��Left=�$��
267,98,0,0q�$	��Top=���  $! Client.Properties.Resources��$ BP���� -   $��textBox2��$��23��$
��Left=�{�.  $��373,100,0,0q�$	��Top=�$	��120������ *BPName+�� -   $��button4��$	��...��$��23��$
��Left=�$��497,100,0,0q�$	��Top=�$��25���� -   $��label7��$��28��$	��100��$��Right=�$
��Left=�$��	1,130,0,0q�$	��Top=���  $! Client.Properties.Resources��$ PricingSide���� -   $��	comboBox1��$��23��$
��Left=�$��107,132,0,0q�$	��Top=�$	��120��	 �� SelectedValuePath$	 Id��
 �� DisplayMemberPath$

 Name������ *PricingSides+ �� SelectedValue �� *SelectedPricingSideId+�� -   $��button5��$��23��$
��Left=�$��188,173,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Query���� -    ��Name$ button6��$��23��$
��Left=�$��292,173,0,0q�$	��Top=�$��75����  $! Client.Properties.Resources��$ Reset���� -   $��	checkBox1��$!��仅显示当前用户文档��$��16��$
��Left=�$��373,135,0,0q�$	��Top=� d� 	IsChecked �� *ContainCurrentUser+