   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  
 Client'   !Client.View.PopUpDialog.PopDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >my/clr-namespace:Utility.Controls;assembly=Utility     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -   $	��480��$
��Auto��$	��560��$
��Auto��  � WindowStartupLocation$  CenterScreen=� � WindowStyle$ 
ToolWindow=� � SizeToContent$ WidthAndHeight=�.��� -    �Name$ rootGrid�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��364* �.+��� -   $��label1��$��Label��$��12,6,0,0q�$
��Auto��$��28��$��Right=�$
��Left=�$	��Top=��� -   $��textBox1��$��1��$��9,8,0,0q�$	��Top=�$
��Left=�$	��120��$��23���� -   $��label2��$��Label��$��6,6,6,6q�$��Right=�$��Right=�$��2��$��28��$��Center=��� -   $��textBox2��$��3��$	��0,8q�$��Center=�$	��120��$��23���� -   $��	btnSearch��$��4��$��7,8,0,9q�$
��Left=�$��60��$��23��$��Center=�$y�Visible=� �� 	IsDefault . ��0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$ Query���� -   $��btnOK��$��确定��$��4��$��77,8,0,9q�$
��Left=�$��60��$��23��$��Center=�$   Utility.Controls.PagingControl  -	   $��pagingControl��$��5��$��1��$
��Left=�$��	12,10,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -
   	  Name$	 popDataGrid��$��2��
   CanUserAddRows
 .     
IsReadOnly .    AutoGenerateColumns .     SelectionMode$ Single=�$
��Auto��$
��Auto��$��	12,6,12,0q�$	��Top=�$��5��