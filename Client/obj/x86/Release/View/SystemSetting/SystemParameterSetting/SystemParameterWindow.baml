   M S B A M L   `   `   `  ���� B  >Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:Utility.Controls;assembly=UtilityUtility.Controls  A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Client.Base.BaseClientClient.Base.BaseClient L   FClient.View.SystemSetting.SystemParameterSetting.SystemParameterWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >my/clr-namespace:Utility.Controls;assembly=Utility     ;
baseClient$clr-namespace:Client.Base.BaseClient     0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$P  JClient.View.SystemSetting.SystemParameterSetting.ResSystemParameterSetting�� N� Title$ 系统参数��$
��Auto��$
��Auto��$��Stretch=�$��Stretch=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension  .���� $
��Auto=�$
��Auto=�.��� -   $��rootGrid�� � ColumnDefinitions �� $	��500 ��� $
��500* � � RowDefinitions �� $��50 ��� $��10 ��� $��1 ��� $	��180 ��� $��10 ��� $��1 ��� $	��110 ��� $��10 ��� $��1 ��� $	��100 ��� $	��420 �.+��� -   $��lbTitle��$��系统参数设置��$��32��$
��Left=�$��6,6,0,0q�$
��auto��$	��Top=�$
��Bold"�$��16(��� -   $��button1��$��23��$
��Left=�$��
119,10,0,0q�$	��Top=�$��60����     ResxName$! Client.Properties.Resources��
   Key$
 Save���� -   $��	groupBox1��$��货运状态参数配置��$	��177��$
��Left=�$��74,1,0,0q�$	��Top=�$	��392��$��3��.��� -   $��grid1��.+��� -   $��label2��$$��批次货运状态参数配置��$��28��$
��Left=�$��6,4,0,0q�$	��Top=�&    Utility.Controls.CurrencyTextBox  -   $��textBox1��$��23��$
��Left=�$��	154,6,0,0q�$	��Top=�$	��120��   Text �� *Delivery2Quota+�� -   $��label3��$��%��$��28��$��Right=�$��0,5,70,0q�$	��Top=�$��35���� -	   $��
textBlock1��$��34��$
��Left=�$��	10,40,0,0q�$����说明:当批次对应的提单数量和与批次数量的误差在±参数范围内,批次的货运状态置为完成,该批次将不再参与后续的物流业务。��$	��Top=�$	��367��$
��Wrap=��� -
   $��label6��$7��1报关提单/内贸提单货运状态参数配置��$��28��$
��Left=�$��6,85,0,0q�$	��Top=�  -   $��textBox2��$��23��$
��Left=�$��
231,87,0,0q�$	��Top=�$	��120�� �� *Inventory2Delivery+�� -   $��label7��$��%��$��28��$
��Left=�$��
351,87,0,0q�$	��Top=��� -   $��
textBlock2��$��39��$
��Left=�$��
10,121,0,0q�$����说明:当提单对应的出入库和发货单数量与提单数量的误差在±参数范围内,提单的货运状态自动置为完成,该提单将不参与后续的物流业务。��$	��Top=�$
��Wrap=�$	��366���� -   $��	groupBox3��$��点价数量误差参数��$	��109��$
��Left=�$��37,1,0,0q�$	��Top=�$	��392��$��1��$��6��.��� -   $��grid3��$��88��.+��� -   $��label13��$��点价数量误差参数��$��28��$
��Left=�$��3,4,0,0q�$	��Top=�$	��110��$��Right=�  -   $��textBox3��$��23��$
��Left=�$��	119,6,0,0q�$	��Top=�$	��120�� �� *Pricing2Quota+�� -   $��label14��$��%��$��28��$
��Left=�$��	240,6,0,0q�$	��Top=��� -   $��
textBlock3��$��42��$
��Left=�$��	10,40,0,0q�$����当点价数量与批次数量的误差在±参数范围内，系统认为该批次已经完成点价，将不再参与点价流程。��$	��Top=�$	��366��$
��Wrap=��� -   $��	groupBox4��$��点价到期预警��$	��110��$
��Left=�$��74,0,0,0q�$	��Top=�$	��392��$��6��.��� $	��380��.+��� -   $��label1��$��点价到期预警天数��$��28��$
��Left=�$��3,15,0,0q�$	��Top=�$	��110��$��Right=��� -   $��label4��$T��N点价到期日前预警天数内，预警中心将显示即将到期的点价��$��28��$
��Left=�$��	13,49,0,0q�$	��Top=�$	��358��  -   $��currencyTextBox1��$��23��$
��Left=�$��
119,17,0,0q�$	��Top=�$	��120�� �� *PricingAlert+�� -   $��	groupBox5��$��LME头寸配置开关��$	��100��$
��Left=�$��38,0,0,0q�$	��Top=�$	��392��$��9��$��1��.��� .+��� -   $��label5��$��代客理财��$��28��$
��Left=�$��	63,26,0,0q�$	��Top=�$	��110��$��Right=��� -   $��	checkBox4��$��打开��$��16��$
��Left=�$��
179,32,0,0q�$	��Top=� d� 	IsChecked �� *
IsLMEAgent+�� -   $��	groupBox2��$��单据审批开关��$	��177��$
��Left=�$��37,1,0,0q�$	��Top=�$	��392��$��3��$��1��.��� -   $��grid2��.+��� -   $��label10��$��合同/批次审批��$��28��$	��110��$��Right=�$
��Left=�$��	91,37,0,0q�$	��Top=��� -   $��label11��$��增值税发票申请��$��28��$
��Left=�$��	91,64,0,0q�$	��110��$��Right=�$	��Top=��� -   $��label12��$��28��$
��Left=�$��	91,91,0,0q�$	��110��$��Right=�$	��Top=���  $! Client.Properties.Resources��$ PaymentRequest���� -    $��	checkBox1��$��打开��$��16��$
��Left=�$��
207,42,0,0q�$	��Top=� �� *QuotaApprove+�� -!   $��	checkBox2��$��打开��$��16��$
��Left=�$��
207,69,0,0q�$	��Top=� �� *VATInvoiceApprove+�� -"   $��	checkBox3��$��打开��$��16��$
��Left=�$��
207,96,0,0q�$	��Top=� �� *PaymentRequestApprove+�� -#   $��	groupBox6��$��单据打印模板配置��$	��282��$
��Left=�$��74,1,0,0q�$	��Top=�$	��392��$��9��$��2��.��� -$   $��grid5��.+��� -%   $��label8��$��内贸合同��$��28��$
��Left=�$��	50,15,0,0q�$	��Top=�$	��110��$��Right=��� -&   $��label9��$��外贸合同��$��28��$
��Left=�$��	50,47,0,0q�$	��Top=�$	��110��$��Right=��� -'   $��label15��$��28��$
��Left=�$��	50,79,0,0q�$	��Top=�$	��110��$��Right=���  $! Client.Properties.Resources��$ PaymentRequest���� -(   $��label16��$��内贸出库单��$��28��$
��Left=�$��
50,111,0,0q�$	��Top=�$	��110��$��Right=��� -)   $��label17��$��28��$
��Left=�$��
50,143,0,0q�$	��Top=�$	��110��$��Right=���  $! Client.Properties.Resources��$ ProvisionalInvoice���� -*   $��label18��$��28��$
��Left=�$��
50,175,0,0q�$	��Top=�$	��110��$��Right=���  $! Client.Properties.Resources��$ FinalInvoice���� -+   $��	comboBox1��$��23��$
��Left=�$��
166,17,0,0q�$	��Top=�$	��120������ *" DomesticContractTemplatePathList+	 �� SelectedItem	 �� *DomesticContractTemplatePath+�� -,   $��	comboBox2��$��23��$
��Left=�$��
166,49,0,0q�$	��Top=�$	��120������ *'%InternationalContractTemplatePathList+	 �� *#!InternationalContractTemplatePath+�� --   $��	comboBox3��$��23��$
��Left=�$��
166,81,0,0q�$	��Top=�$	��120������ * PaymentRequestTemplatePathList+	 �� *PaymentRequestTemplatePath+�� -.   $��	comboBox4��$��23��$
��Left=�$��166,113,0,0q�$	��Top=�$	��120������ *&$DomesticWarehouseOutTemplatePathList+	 �� *" DomesticWarehouseOutTemplatePath+�� -/   $��	comboBox5��$��23��$
��Left=�$��166,145,0,0q�$	��Top=�$	��120������ *$"ProvisionalInvoiceTemplatePathList+	 �� * ProvisionalInvoiceTemplatePath+�� -0   $��	comboBox6��$��23��$
��Left=�$��166,177,0,0q�$	��Top=�$	��120������ *FinalInvoiceTemplatePathList+	 �� *FinalInvoiceTemplatePath+�� -1   $��label20��$��点价确认单��$��28��$
��Left=�$��
50,207,0,0q�$	��Top=�$	��110��$��Right=��� -2   $��	comboBox7��$��23��$
��Left=�$��166,209,0,0q�$	��Top=�$	��120������ *%#PricingConfirmationTemplatePathList+	 �� *!PricingConfirmationTemplatePath+�� -3   $��	groupBox7��$��出库编号��$	��152��$
��Left=�$��	38,30,0,0q�$	��Top=�$	��392��$��10��$��1��.��� -4   $��grid7��$	��114��$	��378��$��1��$��10��$
��Left=�$	��Top=�.+��� -5   $��label19��$��出库编号��$��28��$
��Left=�$��	50,60,0,0q�$	��Top=�$	��110��$��Right=��� -6   $��textBox4��$��23��$
��Left=�$��
168,62,0,0q�$	��Top=�$	��120������ *WarehouseOutNo+�� -7   $��label24��$��编号规则��$��28��$
��Left=�$��	50,28,0,0q�$	��Top=�$	��110��$��Right=��� -8   $��	comboBox8��$��23��
 �� DisplayMemberPath$	
 Key��$
��Left=�$��
168,30,0,0q�$	��Top=�$	��120�� �� SelectedValuePath$ Value������ *DeliveryNoFormulas+ �� SelectedValue �� *SelectDeliveryNoFormula+�� -9   $��	groupBox8��$'��!信用证分配完成误差参数��$	��100��$
��Left=�$��
38,191,0,0q�$	��Top=�$	��392��$��10��$��1��.��� .+��� -:   $��label21��$'��!信用证分配完成误差参数��$��28��$
��Left=�$��	10,10,0,0q�$	��Top=��� -;   $��textBox5��$��23��$
��Left=�$��
150,10,0,0q�$	��Top=�$��70������ *LCFinanceStatusParameter+�� -<   $��label22��$��%��$��23��$
��Left=�$��
222,10,0,0q�$	��Top=��� -=   $��label23��$����信用证交单金额和分配给商业发票金额的误差在±参数范围内，信用证的财务状态自动变更成完成。��$
��auto��$
��Left=�$
��Wrap=�$��	15,35,0,0q�$	��Top=�$	��360���� ->   $��	groupBox9��$��多品牌配置开关��$	��100��$
��Left=�$��
74,191,0,0q�$	��Top=�$	��392��$��10��.��� .+��� -?   $��	lblBrands��$��合同短单多品牌��$��28��$
��Left=�$��	98,26,0,0q�$	��Top=�$	��110��$��Right=��� -@   $��	checkBox5��$��打开��$��16��$
��Left=�$��
214,32,0,0q�$	��Top=� �� *IsUseMultipleBrands+�� -A   $��
groupBox10��$��上传文件路径配置��$	��100��$
��Left=�$��
74,300,0,0q�$	��Top=�$	��392��$��10��.��� .+��� -B   $��label25��$��保存盘符��$��28��$
��Left=�$��	35,17,0,0q�$	��Top=�$	��110��$��Right=��� -C   $��	comboBox9��$��23��$
��Left=�$��
155,19,0,0q�$	��Top=�$��60������ *DiskNameList+	 �� *SelectedDiskName+�� $E��?上传附件将保存在选择盘符下的Upload文件夹中。��$
��Left=�$��	30,54,0,0q�$
��Wrap=�$	��Top=�