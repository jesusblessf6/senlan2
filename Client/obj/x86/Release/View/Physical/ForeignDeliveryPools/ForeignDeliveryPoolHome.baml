   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient  B >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls G    AClient.View.Physical.ForeignDeliveryPools.ForeignDeliveryPoolHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5base$clr-namespace:Client.Base.BaseClient     >my/clr-namespace:Utility.Controls;assembly=Utility       N� Title$  外贸提单池首页��.���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid��.+��� -   $��lbTitle��$��外贸提单池首页��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$
��Bold"�$��16(��� -   $��	groupBox1��$	��180��$
��Left=�$��	40,40,0,0q�$	��Top=�$	��250����0  *Infralution.Localization.Wpf.ResxExtension     ResxName$! Client.Properties.Resources��
   Key$	 Add��.��� .+��� -   $��label1��$��进口/转口提单��$��28��$
��Left=�$��	32,43,0,0q�$	��Top=��� -   $��button1��$��+��$��23��$
��Left=�$��
130,44,0,0q�$	��Top=�$��75���� -   $��label2��$��进口/转口仓单��$��28��$
��Left=�$��	32,83,0,0q�$	��Top=��� -   $��button2��$��+��$��23��$
��Left=�$��
130,84,0,0q�$	��Top=�$��75���� -   $��	groupBox3��$	��300��$
��Left=�$��
40,225,0,0q�$	��Top=�$	��540����  $! Client.Properties.Resources��$ Query��.��� .+��� -	   $��label6��$
��Bold"�$��28��$
��Left=�$��6,6,0,0q�$	��Top=���  $! Client.Properties.Resources��$ QueryShortcut���� -
   $��btnLasttMonthList��$��本月外贸提/仓单��$��23��$
��Left=�$��	30,40,0,0q�   
LinkButton#��[  $	��Top=�$
��auto���� -   $��label7��$
��Bold"�$��28��$
��Left=�$��6,70,0,0q�$	��Top=���  $! Client.Properties.Resources��$ AdvancedQuery���� -   $��label3��$��金属��$��28��$
��Left=�$��
42,103,0,0q�$	��Top=��� -   $��	comboBox1��$��23��$
��Left=�$��
82,104,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Commodities+ �� SelectedValue �� *SelectedCommodityId+�� -   $��label4��$��单据类型��$��28��$
��Left=�$��279,104,0,0q�$	��Top=��� -   $��	comboBox2��$��23��$
��Left=�$��343,104,0,0q�$	��Top=�$	��120��$
 Name��$ Id������ *DeliveryTypes+ �� *SelectedDeliveryTypeId+�� -   $��label5��$��起始日期��$��28��$
��Left=�$��
18,135,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��
82,136,0,0q�$	��Top=�$	��120��   SelectedDate �� *	StartDate+�� -   $��label8��$��结束日期��$��28��$
��Left=�$��279,135,0,0q�$	��Top=�  -   $��datePicker2��$��25��$
��Left=�$��343,136,0,0q�$	��Top=�$	��120�� �� *	EndDate+�� -   $��label9��$��	提单号��$��28��$
��Left=�$��
30,166,0,0q�$	��Top=��� -   $��textBox1��$��23��$
��Left=�$��
82,168,0,0q�$	��Top=�$	��120������ *
DeliveryNo+�� -   $��	checkBox1��$!��仅显示当前用户文档��$��16��$
��Left=�$��
82,203,0,0q�$	��Top=�$	��142�� d� 	IsChecked �� *OnlyCurrentUser+�� -   $��button3��$��查询��$��23��$
��Left=�$��301,200,0,0q�$	��Top=�$��75���� -   $��button4��$��重置��$��23��$��387,200,0,0q�$	��Top=�$
��Left=�$��75���� -   $��label10��$��净重��$��28��$
��Left=�$��300,166,0,0q�$	��Top=�&   Utility.Controls.CurrencyTextBox  -   $��textBox2��$��23��$
��Left=�$��343,168,0,0q�$	��Top=�$	��120��   Text �� *	NetWeight+