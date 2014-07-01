using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace Utility.ServiceManagement
{
    public class SvcClientManager
    {
        private static readonly string HostAddr;
        private static readonly Uri HostUri;
        private static readonly BasicHttpBinding Binding;
        private static readonly Dictionary<SvcType, string> ServiceUris;

        static SvcClientManager()
        {
            ServiceUris = new Dictionary<SvcType, string>
                              {
                                  {SvcType.UserSvc, "/SystemSetting/UserService.svc"},
                                  {SvcType.CategorySvc, "/SystemSetting/CategoryService.svc"},
                                  {SvcType.ModuleSvc, "/SystemSetting/ModuleService.svc"},
                                  {SvcType.RoleSvc, "/SystemSetting/RoleService.svc"},
                                  {SvcType.BankSvc, "/SystemSetting/BankService.svc"},
                                  {SvcType.BankAccountSvc, "/SystemSetting/BankAccountService.svc"},
                                  {SvcType.CurrencySvc, "/SystemSetting/CurrencyService.svc"},
                                  {SvcType.RateSvc, "/SystemSetting/RateService.svc"},
                                  {SvcType.WarehouseSvc, "/SystemSetting/WarehouseService.svc"},
                                  {SvcType.CommoditySvc, "/SystemSetting/CommodityService.svc"},
                                  {SvcType.CommodityTypeSvc, "/SystemSetting/CommodityTypeService.svc"},
                                  {SvcType.BrandSvc, "/SystemSetting/BrandService.svc"},
                                  {SvcType.SpecificationSvc, "/SystemSetting/SpecificationService.svc"},
                                  {SvcType.CountrySvc, "/SystemSetting/CountryService.svc"},
                                  {SvcType.BusinessPartnerSvc, "/SystemSetting/BusinessPartnerService.svc"},
                                  {SvcType.MarketPriceSvc, "/MarketPrice/MarketPriceService.svc"},
                                  {SvcType.PortSvc, "/SystemSetting/PortService.svc"},
                                  {SvcType.PaymentMeanSvc, "/SystemSetting/PaymentMeanService.svc"},
                                  {SvcType.VATRateSvc, "/SystemSetting/VATRateService.svc"},
                                  {SvcType.ContractSvc, "/Physical/Contracts/ContractService.svc"},
                                  {SvcType.SystemParameterSvc, "/SystemSetting/SystemParameterService.svc"},
                                  {SvcType.PaymentUsageSvc, "/SystemSetting/PaymentUsageService.svc"},
                                  {SvcType.DeliverySvc, "/Physical/Deliveries/DeliveryService.svc"},
                                  {SvcType.WarehouseInSvc, "/Physical/WarehouseIns/WarehouseInService.svc"},
                                  {SvcType.ApprovalSvc, "/SystemSetting/ApprovalService.svc"},
                                  {SvcType.FinancialAccountSvc, "/SystemSetting/FinancialAccountService.svc"},
                                  {SvcType.FundFlowSvc, "/Finance/FundFlows/FundFlowService.svc"},
                                  {SvcType.QuotaSvc, "/Physical/Contracts/QuotaService.svc"},
                                  {SvcType.DeliveryLineSvc, "/Physical/Deliveries/DeliveryLineService.svc"},
                                  {SvcType.WarehouseInLineSvc, "/Physical/WarehouseIns/WarehouseInLineService.svc"},
                                  {SvcType.AttachmentSvc, "/Attachments/AttachmentService.svc"},
                                  {SvcType.UploadSvc, "/Attachments/UploadService.svc"},
                                  {SvcType.WarehouseOutSvc, "/Physical/WarehouseOuts/WarehouseOutService.svc"},
                                  {SvcType.PaymentRequestSvc, "/Physical/Payments/PaymentRequestService.svc"},
                                  {SvcType.LetterOfCreditSvc, "/Finance/LetterOfCredits/LetterOfCreditService.svc"},
                                  {SvcType.PricingSvc, "/Physical/Pricings/PricingService.svc"},
                                  {SvcType.VATInvoiceRequestSvc, "/Physical/VATInvoices/VATInvoiceRequestService.svc"},
                                  {SvcType.VATInvoiceRequestLineSvc,"/Physical/VATInvoices/VATInvoicedRequestLineService.svc"},
                                  {SvcType.InventorySvc, "/Physical/Inventories/InventoryService.svc"},
                                  {SvcType.WarehouseOutLineSvc, "/Physical/WarehouseOuts/WarehouseOutLineService.svc"},
                                  {SvcType.UnpricingSvc, "/Physical/Pricings/UnpricingService.svc"},
                                  {SvcType.CommercialInvoiceSvc,"/Physical/CommercialInvoices/CommercialInvoiceService.svc"},
                                  {SvcType.VATInvoiceSvc, "/Physical/VATInvoices/VATInvoiceService.svc"},
                                  {SvcType.VATInvoiceLineSvc, "/Physical/VATInvoices/VATInvoiceLineService.svc"},
                                  {SvcType.DocumentSvc, "/SystemSetting/DocumentService.svc"},
                                  {SvcType.CommissionSvc, "/SystemSetting/CommissionService.svc"},
                                  {SvcType.CommissionLineSvc, "/SystemSetting/CommissionLineService.svc"},
                                  {SvcType.LMEPositionSvc, "/Futures/LME/LMEPositionService.svc"},
                                  {SvcType.LogRegistrationSvc, "/SystemSetting/LogRegistrationService.svc"},
                                  {SvcType.LogMessageSvc, "/SystemSetting/LogMessageService.svc"},
                                  {SvcType.SHFEPositionSvc, "/Futures/SHFE/SHFEPositionService.svc"},
                                  {SvcType.SHFESvc, "/Futures/SHFE/SHFEService.svc"},
                                  {SvcType.HedgeGroupSvc, "/Futures/Hedge/HedgeGroupService.svc"},
                                  {SvcType.ContractUDFSvc, "/SystemSetting/ContractUDFService.svc"},
                                  {SvcType.SHFEFundFlowSvc, "/Futures/SHFE/SHFEFundFlowService.svc"},
                                  {SvcType.PSQuotaRelSvc, "/Physical/WarehouseOuts/PSQuotaRelService.svc"},
                                  {SvcType.DeliveryPersonSvc, "/SystemSetting/DeliveryPersonService.svc"},
                                  {SvcType.ForeignDeliveryPoolSvc, "/Physical/Deliveries/ForeignDeliveryPoolService.svc"},
                                  {SvcType.ForeignDeliveryPoolLineSvc, "/Physical/Deliveries/ForeignDeliveryPoolLineService.svc"},
                                  {SvcType.LCAllocationSvc, "/Finance/LetterOfCredits/LCAllocationService.svc"}
                              };

            HostAddr = (ConfigurationManager.AppSettings["ServiceHost"]);
            HostUri = new Uri(HostAddr);
            //binding = new BasicHttpBinding(BasicHttpSecurityMode.Message);
            Binding = new BasicHttpBinding(BasicHttpSecurityMode.None)
                          {
                              MaxReceivedMessageSize = int.MaxValue,
                              MaxBufferSize = int.MaxValue,
                              OpenTimeout = new TimeSpan(0, 10, 0),
                              CloseTimeout = new TimeSpan(0, 10, 0),
                              ReceiveTimeout = new TimeSpan(0, 10, 0),
                              SendTimeout = new TimeSpan(0, 10, 0),
                              ReaderQuotas =
                                  new XmlDictionaryReaderQuotas
                                      {
                                          MaxArrayLength = Int32.MaxValue,
                                          MaxBytesPerRead = Int32.MaxValue,
                                          MaxDepth = Int32.MaxValue,
                                          MaxNameTableCharCount = Int32.MaxValue,
                                          MaxStringContentLength = Int32.MaxValue
                                      }
                          };
            //binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
        }

        public static TSvcClient GetSvcClient<TSvcClient>(SvcType serviceType) where TSvcClient : class
        {
            string host = HostUri.DnsSafeHost;

            var paras = new object[2];
            paras[0] = Binding;
            
            paras[1] = new EndpointAddress(new Uri(HostAddr + ServiceUris[serviceType]),
                                           EndpointIdentity.CreateDnsIdentity(host));
            var types = new Type[2];
            types[0] = typeof (Binding);
            types[1] = typeof (EndpointAddress);
            ConstructorInfo constructor = typeof (TSvcClient).GetConstructor(types);

            TSvcClient instance = null;
            if (constructor != null)
            {
                instance = (TSvcClient) constructor.Invoke(paras);
                /*
				PropertyInfo prop = instance.GetType().GetProperty("ClientCredentials", 
					BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);               
				ClientCredentials clientCredentials = (ClientCredentials)prop.GetValue(instance, null);
				clientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My,
					X509FindType.FindBySubjectName, host);
				clientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine, StoreName.My, 
					X509FindType.FindBySubjectName, host);
				clientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None; 
				 * */
                
            }

            if (instance != null)
            {
                var channel =
                    instance.GetType().GetProperty("ChannelFactory").GetValue(instance, null) as ChannelFactory;
                if (channel != null && channel.Endpoint != null && channel.Endpoint.Contract != null && channel.Endpoint.Contract.Operations != null)
                {
                    var operations = channel.Endpoint.Contract.Operations;
                    foreach (var op in operations)
                    {
                        var dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>();
                        if (dataContractBehavior != null)
                        {
                            dataContractBehavior.MaxItemsInObjectGraph = 2147483647;
                        }
                    }
                }

            }

            return instance;
        }

        public static object GetSvcClient(Type svcClient, SvcType serviceType)
        {
            string host = HostUri.DnsSafeHost;
            var paras = new object[2];
            paras[0] = Binding;
            paras[1] = new EndpointAddress(new Uri(HostAddr + ServiceUris[serviceType]),
                                           EndpointIdentity.CreateDnsIdentity(host));

            var types = new Type[2];
            types[0] = typeof (Binding);
            types[1] = typeof (EndpointAddress);
            ConstructorInfo constructor = svcClient.GetConstructor(types);

            object instance = null;
            if (constructor != null)
            {
                instance = constructor.Invoke(paras);
                /*
                PropertyInfo prop = instance.GetType().GetProperty("ClientCredentials", 
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);               
                ClientCredentials clientCredentials = (ClientCredentials)prop.GetValue(instance, null);
                clientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My,
                    X509FindType.FindBySubjectName, host);
                clientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine, StoreName.My, 
                    X509FindType.FindBySubjectName, host);
                clientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None; 
                 * */
            }

            return instance;
        }
    }
}