   M S B A M L   `   `   `  ���� 
  Client    Client.View.Main   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.1.1.0, Culture=neutral, PublicKeyToken=547ccae517a004b5H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   0  *Infralution.Localization.Wpf.ResxExtension    DefaultResxName$  Client.View.ResMain��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � Language 5  /Infralution.Localization.Wpf.UICultureExtension   � Title   *Title+ � 	Resources    GoLogMessageList��%   &	        ��  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [  .��� -   $��rootGrid��.+�� -   $��gdTopBanner��$��68��$	��Top=�
�����F�.+��� -   $��image1��$��68��$
��Left=�$
��Fill=�$	��Top=�$	��150��$&�� /Client;component/Image/Logo.png���� -   $��btClose��$��X��$��23��$��Right=�$��0,6,6,0q�$	��Top=�$��23��$
��Bold"��� -   $��
btMinimize��$��-��$
��Bold"�$��23��$��Right=�$��0,6,64,0q�$	��Top=�$��23��$��13(��� -   $��
btMaximize��$��+��$
��Bold"�$��23��$��Right=�$��0,6,35,0q�$	��Top=�$��23��$��13(��� -	   $��tbWelcom��$��28��$��Right=�$��	0,9,132,0q�$	��Top=�$
��Auto�����	#FFE7E7E7$
��Bold"��� �  *	Welcome+ �� ��� *CurrentUser.Name+�� -
   $��button1��$��>��$��23��$��Right=�$��0,6,93,0q�$	��Top=�$��23��$
��Bold"�	 � ToolTip	   *Logout+�� -   $��
textBlock1��$��23��$��
0,39,132,0q�$	��Top=�$��Right=�$
��Auto��$y�Hidden=����� -   xxx���� 
��� ����  *UnreadMessageNumber+ �� 
��� ���
 �� Command#
 [  .�.��� ��� *UnreadLogCount+.�� -   $��grid2��$��
200,68,0,0q�.+� � -   $��fmMain��$
��Auto��$
��Auto��$��Stretch=�$��Stretch=�$��Stretch=�$��Stretch=�� -   $��grid3��$
��Left=�$��0,68,0,0q�$	��200��
�����F�.+��� $
��Auto=�$
��Auto=�$��0,0,0,0q�.���� -   $��stackPanel1��.+�9� -   $��expControlCenter��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  *	Console+.��� $
��Auto��.+��� -   $��spControlCenter��$
��auto��.+��� -   $��btDashboard��$��23��$��12(�$��Normal"�$��1q���     ResxName$0 *Client.View.Console.DashBoard.ResDashBoard��
   Key$ 	DashBoard���� -   $��btApprovalCenter��$��23��$��12(�$��Normal"�$��1q���  $: 4Client.View.Console.ApprovalCenter.ResApprovalCenter��$ ApprovalCenter���� -   $��btLogMessage��$��23��$��12(�$��Normal"�$��1q���  $3 -Client.View.Console.LogMessages.ResLogMessage��$ SubscribedLog���� -   $��btMonitorCenter��$��23��$��12(�$��Normal"�$��1q���  $8 2Client.View.Console.MonitorCenter.ResMonitorCenter��$ MonitorCenter��9� -   $��expPurchases��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  $! Client.Properties.Resources��$ Purchase��.��� $
��Auto��.+��� -   $��
spPurchase��$
��auto��.+��� -   $��btPurchaseContractHome��$��23��$��12(�$��Normal"�$��1q���  *PurchaseContract+�� -   $��btPurchaseDeliveryHome��$��23��$��12(�$��Normal"�$��1q���  *PurchaseDelivery+�� -   $%��btPurchaseCommercialInvoiceHome��$��12(�$��23��$��Normal"�$��1q���  $! Client.Properties.Resources��$ CommercialInvoice���� -   $��btPaymentRequestHome��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ PaymentRequest���� -   $��btForeignDeliveryPool��$��12(�$��23��$��外贸提/仓单池��$��Normal"�$��1q�9� -   $��expSales��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  $! Client.Properties.Resources��$ Sales��.��� $
��Auto��.+��� -   $��spSales��$
��auto��.+��� -    $��btSalesContractHome��$��23��$��12(�$��Normal"�$��1q���  *SalesContract+�� -!   $��btSalesDeliveryHome��$��23��$��12(�$��Normal"�$��1q���  *SalesDelivery+�� -"   $��btVATInvoiceRequestHome��$��23��$��12(�$��Normal"�$��1q���  *VATInvoiceRequest+�� -#   $!��btSaleCommercialInvoiceHome��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ CommercialInvoice��9� -$   $��
expPricing��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  $! Client.Properties.Resources��$ Pricing��.��� $
��Auto��.+��� -%   $��	spPricing��$
��Auto��.+��� -&   $��	btPricing��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ ManualPricing���� -'   $��btAveragePricing��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ AveragePricing��9� -(   $��expInventory��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  *	Inventory+.��� $
��Auto��.+��� -)   $��spInventory��$
��auto��.+��� -*   $��btWarehouseInHome��$��23��$��12(�$��Normal"�$��1q���  *WarehouseIn+�� -+   $��btWarehouseOutHome��$��23��$��12(�$��Normal"�$��1q���  *WarehouseOut+�� -,   $��btInventoryReportHome��$��23��$��12(�$��Normal"�$��1q���  *InventoryReport+9� --   $��
expFutures��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  *	Futures+.��� $
��Auto��.+��� -.   $��	spFutures��$
��auto��.+��� -/   $��
btSHFEHome��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ SHFEPosition���� -0   $��btLmePosition��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ LMEPosition��9� -1   $��expHedge��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  *Hedge+.��� $
��Auto��.+��� -2   $��btHedgeGroup��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ 
HedgeGroup��9� -3   $��expFinancial��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  *	Financial+.��� $
��Auto��.+��� -4   $��spFinancial��$
��auto��.+��� -5   $��btFundFlowHome��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ FundFlow���� -6   $��btLCHome��$��23��$��12(�$��Normal"�$��1q���  *LetterOfCredit+�� -7   $��btVATInvoice��$��23��$��12(�$��Normal"�$��1q���  *
VATInvoice+�� -8   $��btPaymentWorkbenchHome��$��23��$��12(�$��Normal"�$��1q���  *PaymentWorkbench+�� -9   $��btLCAllocationHome��$��23��$��12(�$��信用证分配��$��Normal"�$��1q�9� -:   $��	expReport��$
��Auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  $! Client.Properties.Resources��$ Reports��.��� $
��Auto��.+��� -;   $��spReport��$
��auto��.+��� -<   $��btLedger��$��23��$��12(�$��Normal"�$��1q���  *Ledger+�� -=   $��
btAPARHome��$��23��$��12(�$��Normal"�$��1q���  *ARAP+�� ->   $ ��btQuotaInvoiceDetailReport��$��23��$��12(�$��Normal"�$��1q���  *QuotaInvoiceDetailReport+�� -?   $ ��btPhysicalAndFuturesReport��$��23��$��12(�$��Normal"�$��1q���  *PhysicalAndFuturesReport+�� -@   $��btLMEPositionPL��$��23��$��12(�$��Normal"�$��1q���  *LMEPositionPLReport+�� -A   $��btSHFEPositionPLReport��$��23��$��12(�$��Normal"�$��1q���  *SHFEPositionPL+�� -B   $��btSHFEFundFlowReport��$��23��$��12(�$��SHFE出入金明细��$��Normal"�$��1q��� -C   $ ��btHedgeGroupFloatPNLReport��$��23��$��12(�$��分组保值盈亏明细��$��Normal"�$��1q��� -D   $��btLMEMarginReport��$��23��$��12(�$��Normal"�$��1q���  *LMEMarginReport+�� -E   $��btExposureChart��$��23��$��12(�$��Normal"�$��1q���  *ExposureChart+�� -F   $��btForwardPositionReport��$��23��$��12(�$��远期头寸分布��$��Normal"�$��1q��� -G   $!��btFDPStorageFeeDetailReport��$��23��$��12(�$��外贸仓单仓租明细��$��Normal"�$��1q��� -H   $$��btExternalDeliveryCirculReport��$��23��$��12(�$��Normal"�$��1q���  *ExternalDeliveryCirculReport+�� -I   $��btBPartnerContractOrder��$��23��$��12(�$��客户购销排行表��$��Normal"�$��1q��� -J   $��btQuotaStatusChange��$��23��$��12(�$��Normal"�$��1q���  *QuotaStatusChange+9� -K   $��expSystemSetting��$
��auto��$	��190��$��1q�
�������$
��Bold"�$��16(���  *SystemSetting+.��� $
��auto��.+��� -L   $��spSystemSetting��$
��auto��.+��� -M   $��btBusinessPartnerSetting��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ BP���� -N   $��btCommoditySetting��$��23��$��12(�$��Normal"�$��1q���  *CommoditySetting+�� -O   $��btWarehouseSetting��$��23��$��12(�$��Normal"�$��1q���  *WarehouseSetting+�� -P   $��btCommissionSetting��$��23��$��12(�$��Normal"�$��1q���  *CommissionSetting+�� -Q   $��btBankAccountSetting��$��23��$��12(�$��Normal"�$��1q���  *BankAccountSetting+�� -R   $��btCurrencyRateSetting��$��23��$��12(�$��Normal"�$��1q���  *CurrencyRateSetting+�� -S   $��btDataDictSetting��$��23��$��12(�$��Normal"�$��1q���  *DataDictSetting+�� -T   $��btFinancialAccountSetting��$��23��$��12(�$��Normal"�$��1q���  $! Client.Properties.Resources��$ FinancialAccount���� -U   $��btRoleSetting��$��23��$��12(�$��Normal"�$��1q���  *RoleSetting+�� -V   $��btUserSetting��$��23��$��12(�$��Normal"�$��1q���  *UserSetting+�� -W   $��btModuleSetting��$��23��$��12(�$��Normal"�$��1q���  *ModuleSetting+�� -X   $��btApprovalSetting��$��23��$��12(�$��Normal"�$��1q���  *ApproveSetting+�� -Y   $��btSystemParameterSetting��$��23��$��12(�$��Normal"�$��1q���  *SystemParameterSetting+�� -Z   $��btModifyPassword��$��23��$��12(�$��Normal"�$��1q���  *ModifyPassword+�� -[   $��btRegisterLog��$��23��$��12(�$��Normal"�$��1q���  *RegisterLog+