   M S B A M L   `   `   `  ����B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  5   	   
 Client'   !Client.View.PopUpDialog.PopDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >my/clr-namespace:Utility.Controls;assembly=Utility     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $	��480��5   	   $
��Auto��6   $	��560��6'   $
��Auto��66     � WindowStartupLocation$  CenterScreen=�6C    � WindowStyle$ 
ToolWindow=�5   \    � SizeToContent$ WidthAndHeight=�5   y   .��5      � -   5         �Name$ rootGrid��5       � ColumnDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��364* �6   .+�5   
   �� -   5        $��label1��5   2   $��Label��6   $��12,6,0,0q�6    $
��Auto��6@   $��28��6M   $��Right=�6Y   $
��Left=�6|   $	��Top=�6�   �� 5   
   -   5        $��textBox1��5   K   $��1��6   $��9,8,0,0q�6"   $	��Top=�63   $
��Left=�6[   $	��120��6v   $��23��6�   �� 5   
   -   5        $��label2��5   �   $��Label��6   $��6,6,6,6q�6    $��Right=�61   $��Right=�6T   $��2��6p   $��28��6�   $��Center=�6�   6�   �� 5   
   -   5        $��textBox2��5   J   $��3��6   $	��0,8q�6"   $��Center=�6/   $	��120��6Z   $��23��6f   �� 5   
   -   5        $��	btnSearch��5   �   $��4��6R   $��7,8,0,9q�6b   $
��Left=�6s   $��60��6�   $��23��6�   $��Center=�6�   $y�Visible=�6�    �� 	IsDefault . ��6   0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ Query��6   �� 5   
   -   5        $��btnOK��5   �   $��确定��6   $��4��6   $��77,8,0,9q�6.   $
��Left=�6@   $��60��6[   $��23��6f   $��Center=�6r   6�   $   Utility.Controls.PagingControl  5   
   -	   5        $��pagingControl��5   j   $��5��6   $��1��6/   $
��Left=�6<   $��	12,10,0,0q�6W   $	��Top=�6   &   System.Windows.Controls.DataGrid  5   
   -
   5        	  Name$	 popDataGrid��5       $��2��6   
   CanUserAddRows
 .     
IsReadOnly .    AutoGenerateColumns .     SelectionMode$ Single=�5   ?   $
��Auto��6p   $
��Auto��6~   $��	12,6,12,0q�6�   $	��Top=�6�   $��5��6�   5      5      