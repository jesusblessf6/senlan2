   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Client.ConvertersClient.Converters  5   @   B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls 5   	   G    AClient.View.SystemSetting.ApprovalSetting.ApprovalConditionDetail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -cclr-namespace:Client.Converters     6@   >my/clr-namespace:Utility.Controls;assembly=Utility     5   	   -   5        $	��250��5   	   $	��267��6     � WindowStartupLocation$  CenterScreen=�6:   0  *Infralution.Localization.Wpf.ResxExtension   DefaultResxName$B <Client.View.SystemSetting.ApprovalSetting.ResApprovalSetting��5   	    � Title 5   j     *ApprovalCondition+ � Language 5   	   5  /Infralution.Localization.Wpf.UICultureExtension   � 	Resources 5	      (   "Client.Converters.EmptyString2Null   
Empty2Null��%   &	          5
   
   62   5      .��5      � -   5        $��rootGrid��5      .+�5   
   �� -   5        $��lbTitle��5   k   $��32��63   $
��Left=�6?   $��6,6,0,0q�6Z   $��16(�6z   $	��Top=�6�   $
��Bold"�6�   ��6     *ApprovalCondition+6�   �� 5   
   -   5        $��label2��5   �   $��28��6T   $��60��6`   $��Right=�6k   $
��Left=�6�   $��	31,38,0,0q�6�   $	��Top=�6�   ��6        ResxName$! Client.Properties.Resources��
   Key$ Currency��6�   �� 5   
   -   5        $��	comboBox1��5   A   $
��Left=�6   $��	97,40,0,0q�6.   $	��Top=�6R    �� SelectedValuePath$ Id��6�    �� DisplayMemberPath$
 Name��6�   $	��120��6�   $��23��6�   ��6j   �� *
Currencies+	 �� SelectedItem	 6�   �� *
Currency+�� 5   
   -   5        $��label4��5   �   $��28��6'   $��60��63   $��Right=�6>   $
��Left=�6a   $��	31,70,0,0q�6|   $	��Top=�6�   ��6     *Floor+6�   &   Utility.Controls.CurrencyTextBox  5   
   -   5        $��textBox1��5   W   $��23��6   $
��Left=�6)   $��	97,72,0,0q�6D   $	��Top=�5      $	��120��65   
   Text
 6A   �� *
LowerLimit+ �� 	Converter# [  �� 5   
   -   5        $��label3��5   �   $��28��6)   $��60��65   $��Right=�6@   $
��Left=�6c   $��
31,102,0,0q�6~   $	��Top=�6�   ��6     *	Ceiling+6�     5   
   -	   5        $��textBox2��5   X   $��23��6   $
��Left=�6)   $��
97,104,0,0q�6D   $	��Top=�5      $	��120��65   
 6A   �� *
UpperLimit+# [  �� 5   
   -
   5        $��button1��5   �   $��25��6T   $
��Left=�6`   $��
56,152,0,0q�6{   $	��Top=�5      $��60��6)   ��5        $! Client.Properties.Resources��$ Confirm��5   4   �� 5   
   -   5        $��button2��5   �   $��25��6S   $
��Left=�6_   $��145,152,0,0q�6z   $	��Top=�5      $��60��6)   ��5        $! Client.Properties.Resources��$ Cancel��5   4   5      5      