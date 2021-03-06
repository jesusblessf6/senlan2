﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using DBEntity.ApprovalPlace;


namespace DBEntity
{
    public partial class SenLan2Entities : ObjectContext
    {
        //public const string ConnectionString = "name=SenLan2Entities";
        //public const string ContainerName = "SenLan2Entities";
    	public int UserId;
    
        #region Constructors
    
        public SenLan2Entities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
    	public SenLan2Entities(int userId)
            : base(ConnectionString, ContainerName)
        {
            Initialize();
    		UserId = userId;
        }
    
        public SenLan2Entities(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public SenLan2Entities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += HandleObjectMaterialized;
    		SavingChanges += FillActionTime;
        }
    
    	private void FillActionTime(object sender, EventArgs e)
        {
            var x = ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified).ToList();
            foreach (ObjectStateEntry en in x)
            {
                if (en.State == EntityState.Added)
                {
                    int createdOrdinal = en.CurrentValues.GetOrdinal("Created");
                    if (createdOrdinal >= 0)
                    {
                        en.CurrentValues.SetDateTime(createdOrdinal, DateTime.Now);
                    }
    
    				int createdByOrdinal = en.CurrentValues.GetOrdinal("CreatedBy");
    				if (createdByOrdinal >= 0)
                    {
                        en.CurrentValues.SetInt32(createdByOrdinal, UserId);
                    }
                }
                else
                {
                    int updatedOrdinal = en.CurrentValues.GetOrdinal("Updated");
                    if (updatedOrdinal >= 0)
                    {
                        en.CurrentValues.SetDateTime(updatedOrdinal, DateTime.Now);
                    }
    
    				int updatedByOrdinal = en.CurrentValues.GetOrdinal("UpdatedBy");
    				if (updatedByOrdinal >= 0)
                    {
                        en.CurrentValues.SetInt32(updatedByOrdinal, UserId);
                    }
                }
    
    			var entity = en.Entity;
                if(entity is IApprovable)
                {
                    ApprovalManager.Handle((IApprovable) entity, this);
                }
            }
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Role> Roles
        {
            get { return _roles  ?? (_roles = CreateObjectSet<Role>("Roles")); }
        }
        private ObjectSet<Role> _roles;
    
        public ObjectSet<User> Users
        {
            get { return _users  ?? (_users = CreateObjectSet<User>("Users")); }
        }
        private ObjectSet<User> _users;
    
        public ObjectSet<Category> Categories
        {
            get { return _categories  ?? (_categories = CreateObjectSet<Category>("Categories")); }
        }
        private ObjectSet<Category> _categories;
    
        public ObjectSet<Module> Modules
        {
            get { return _modules  ?? (_modules = CreateObjectSet<Module>("Modules")); }
        }
        private ObjectSet<Module> _modules;
    
        public ObjectSet<BusinessPartner> BusinessPartners
        {
            get { return _businessPartners  ?? (_businessPartners = CreateObjectSet<BusinessPartner>("BusinessPartners")); }
        }
        private ObjectSet<BusinessPartner> _businessPartners;
    
        public ObjectSet<Function> Functions
        {
            get { return _functions  ?? (_functions = CreateObjectSet<Function>("Functions")); }
        }
        private ObjectSet<Function> _functions;
    
        public ObjectSet<RoleFunctionLink> RoleFunctionLinks
        {
            get { return _roleFunctionLinks  ?? (_roleFunctionLinks = CreateObjectSet<RoleFunctionLink>("RoleFunctionLinks")); }
        }
        private ObjectSet<RoleFunctionLink> _roleFunctionLinks;
    
        public ObjectSet<Bank> Banks
        {
            get { return _banks  ?? (_banks = CreateObjectSet<Bank>("Banks")); }
        }
        private ObjectSet<Bank> _banks;
    
        public ObjectSet<BankAccount> BankAccounts
        {
            get { return _bankAccounts  ?? (_bankAccounts = CreateObjectSet<BankAccount>("BankAccounts")); }
        }
        private ObjectSet<BankAccount> _bankAccounts;
    
        public ObjectSet<Currency> Currencies
        {
            get { return _currencies  ?? (_currencies = CreateObjectSet<Currency>("Currencies")); }
        }
        private ObjectSet<Currency> _currencies;
    
        public ObjectSet<Rate> Rates
        {
            get { return _rates  ?? (_rates = CreateObjectSet<Rate>("Rates")); }
        }
        private ObjectSet<Rate> _rates;
    
        public ObjectSet<Warehouse> Warehouses
        {
            get { return _warehouses  ?? (_warehouses = CreateObjectSet<Warehouse>("Warehouses")); }
        }
        private ObjectSet<Warehouse> _warehouses;
    
        public ObjectSet<Commodity> Commodities
        {
            get { return _commodities  ?? (_commodities = CreateObjectSet<Commodity>("Commodities")); }
        }
        private ObjectSet<Commodity> _commodities;
    
        public ObjectSet<CommodityType> CommodityTypes
        {
            get { return _commodityTypes  ?? (_commodityTypes = CreateObjectSet<CommodityType>("CommodityTypes")); }
        }
        private ObjectSet<CommodityType> _commodityTypes;
    
        public ObjectSet<Country> Countries
        {
            get { return _countries  ?? (_countries = CreateObjectSet<Country>("Countries")); }
        }
        private ObjectSet<Country> _countries;
    
        public ObjectSet<Brand> Brands
        {
            get { return _brands  ?? (_brands = CreateObjectSet<Brand>("Brands")); }
        }
        private ObjectSet<Brand> _brands;
    
        public ObjectSet<Specification> Specifications
        {
            get { return _specifications  ?? (_specifications = CreateObjectSet<Specification>("Specifications")); }
        }
        private ObjectSet<Specification> _specifications;
    
        public ObjectSet<Port> Ports
        {
            get { return _ports  ?? (_ports = CreateObjectSet<Port>("Ports")); }
        }
        private ObjectSet<Port> _ports;
    
        public ObjectSet<PaymentMean> PaymentMeans
        {
            get { return _paymentMeans  ?? (_paymentMeans = CreateObjectSet<PaymentMean>("PaymentMeans")); }
        }
        private ObjectSet<PaymentMean> _paymentMeans;
    
        public ObjectSet<VATRate> VATRates
        {
            get { return _vATRates  ?? (_vATRates = CreateObjectSet<VATRate>("VATRates")); }
        }
        private ObjectSet<VATRate> _vATRates;
    
        public ObjectSet<UserICLink> UserICLinks
        {
            get { return _userICLinks  ?? (_userICLinks = CreateObjectSet<UserICLink>("UserICLinks")); }
        }
        private ObjectSet<UserICLink> _userICLinks;
    
        public ObjectSet<UserCommodityLink> UserCommodityLinks
        {
            get { return _userCommodityLinks  ?? (_userCommodityLinks = CreateObjectSet<UserCommodityLink>("UserCommodityLinks")); }
        }
        private ObjectSet<UserCommodityLink> _userCommodityLinks;
    
        public ObjectSet<Quota> Quotas
        {
            get { return _quotas  ?? (_quotas = CreateObjectSet<Quota>("Quotas")); }
        }
        private ObjectSet<Quota> _quotas;
    
        public ObjectSet<SHFE> SHFEs
        {
            get { return _sHFEs  ?? (_sHFEs = CreateObjectSet<SHFE>("SHFEs")); }
        }
        private ObjectSet<SHFE> _sHFEs;
    
        public ObjectSet<SystemParameter> SystemParameters
        {
            get { return _systemParameters  ?? (_systemParameters = CreateObjectSet<SystemParameter>("SystemParameters")); }
        }
        private ObjectSet<SystemParameter> _systemParameters;
    
        public ObjectSet<Approval> Approvals
        {
            get { return _approvals  ?? (_approvals = CreateObjectSet<Approval>("Approvals")); }
        }
        private ObjectSet<Approval> _approvals;
    
        public ObjectSet<ApprovalCondition> ApprovalConditions
        {
            get { return _approvalConditions  ?? (_approvalConditions = CreateObjectSet<ApprovalCondition>("ApprovalConditions")); }
        }
        private ObjectSet<ApprovalCondition> _approvalConditions;
    
        public ObjectSet<ApprovalStage> ApprovalStages
        {
            get { return _approvalStages  ?? (_approvalStages = CreateObjectSet<ApprovalStage>("ApprovalStages")); }
        }
        private ObjectSet<ApprovalStage> _approvalStages;
    
        public ObjectSet<Delivery> Deliveries
        {
            get { return _deliveries  ?? (_deliveries = CreateObjectSet<Delivery>("Deliveries")); }
        }
        private ObjectSet<Delivery> _deliveries;
    
        public ObjectSet<DeliveryLine> DeliveryLines
        {
            get { return _deliveryLines  ?? (_deliveryLines = CreateObjectSet<DeliveryLine>("DeliveryLines")); }
        }
        private ObjectSet<DeliveryLine> _deliveryLines;
    
        public ObjectSet<Document> Documents
        {
            get { return _documents  ?? (_documents = CreateObjectSet<Document>("Documents")); }
        }
        private ObjectSet<Document> _documents;
    
        public ObjectSet<Inventory> Inventories
        {
            get { return _inventories  ?? (_inventories = CreateObjectSet<Inventory>("Inventories")); }
        }
        private ObjectSet<Inventory> _inventories;
    
        public ObjectSet<Log> Logs
        {
            get { return _logs  ?? (_logs = CreateObjectSet<Log>("Logs")); }
        }
        private ObjectSet<Log> _logs;
    
        public ObjectSet<LogAction> LogActions
        {
            get { return _logActions  ?? (_logActions = CreateObjectSet<LogAction>("LogActions")); }
        }
        private ObjectSet<LogAction> _logActions;
    
        public ObjectSet<FinancialAccount> FinancialAccounts
        {
            get { return _financialAccounts  ?? (_financialAccounts = CreateObjectSet<FinancialAccount>("FinancialAccounts")); }
        }
        private ObjectSet<FinancialAccount> _financialAccounts;
    
        public ObjectSet<PaymentUsage> PaymentUsages
        {
            get { return _paymentUsages  ?? (_paymentUsages = CreateObjectSet<PaymentUsage>("PaymentUsages")); }
        }
        private ObjectSet<PaymentUsage> _paymentUsages;
    
        public ObjectSet<WarehouseInLine> WarehouseInLines
        {
            get { return _warehouseInLines  ?? (_warehouseInLines = CreateObjectSet<WarehouseInLine>("WarehouseInLines")); }
        }
        private ObjectSet<WarehouseInLine> _warehouseInLines;
    
        public ObjectSet<WarehouseOut> WarehouseOuts
        {
            get { return _warehouseOuts  ?? (_warehouseOuts = CreateObjectSet<WarehouseOut>("WarehouseOuts")); }
        }
        private ObjectSet<WarehouseOut> _warehouseOuts;
    
        public ObjectSet<WarehouseOutLine> WarehouseOutLines
        {
            get { return _warehouseOutLines  ?? (_warehouseOutLines = CreateObjectSet<WarehouseOutLine>("WarehouseOutLines")); }
        }
        private ObjectSet<WarehouseOutLine> _warehouseOutLines;
    
        public ObjectSet<WarehouseTransfer> WarehouseTransfers
        {
            get { return _warehouseTransfers  ?? (_warehouseTransfers = CreateObjectSet<WarehouseTransfer>("WarehouseTransfers")); }
        }
        private ObjectSet<WarehouseTransfer> _warehouseTransfers;
    
        public ObjectSet<WarehouseTransferLine> WarehouseTransferLines
        {
            get { return _warehouseTransferLines  ?? (_warehouseTransferLines = CreateObjectSet<WarehouseTransferLine>("WarehouseTransferLines")); }
        }
        private ObjectSet<WarehouseTransferLine> _warehouseTransferLines;
    
        public ObjectSet<FundFlow> FundFlows
        {
            get { return _fundFlows  ?? (_fundFlows = CreateObjectSet<FundFlow>("FundFlows")); }
        }
        private ObjectSet<FundFlow> _fundFlows;
    
        public ObjectSet<WarehouseIn> WarehouseIns
        {
            get { return _warehouseIns  ?? (_warehouseIns = CreateObjectSet<WarehouseIn>("WarehouseIns")); }
        }
        private ObjectSet<WarehouseIn> _warehouseIns;
    
        public ObjectSet<Attachment> Attachments
        {
            get { return _attachments  ?? (_attachments = CreateObjectSet<Attachment>("Attachments")); }
        }
        private ObjectSet<Attachment> _attachments;
    
        public ObjectSet<CommercialInvoice> CommercialInvoices
        {
            get { return _commercialInvoices  ?? (_commercialInvoices = CreateObjectSet<CommercialInvoice>("CommercialInvoices")); }
        }
        private ObjectSet<CommercialInvoice> _commercialInvoices;
    
        public ObjectSet<VATInvoice> VATInvoices
        {
            get { return _vATInvoices  ?? (_vATInvoices = CreateObjectSet<VATInvoice>("VATInvoices")); }
        }
        private ObjectSet<VATInvoice> _vATInvoices;
    
        public ObjectSet<VATInvoiceLine> VATInvoiceLines
        {
            get { return _vATInvoiceLines  ?? (_vATInvoiceLines = CreateObjectSet<VATInvoiceLine>("VATInvoiceLines")); }
        }
        private ObjectSet<VATInvoiceLine> _vATInvoiceLines;
    
        public ObjectSet<VATInvoiceRequest> VATInvoiceRequests
        {
            get { return _vATInvoiceRequests  ?? (_vATInvoiceRequests = CreateObjectSet<VATInvoiceRequest>("VATInvoiceRequests")); }
        }
        private ObjectSet<VATInvoiceRequest> _vATInvoiceRequests;
    
        public ObjectSet<PaymentRequest> PaymentRequests
        {
            get { return _paymentRequests  ?? (_paymentRequests = CreateObjectSet<PaymentRequest>("PaymentRequests")); }
        }
        private ObjectSet<PaymentRequest> _paymentRequests;
    
        public ObjectSet<Pricing> Pricings
        {
            get { return _pricings  ?? (_pricings = CreateObjectSet<Pricing>("Pricings")); }
        }
        private ObjectSet<Pricing> _pricings;
    
        public ObjectSet<Unpricing> Unpricings
        {
            get { return _unpricings  ?? (_unpricings = CreateObjectSet<Unpricing>("Unpricings")); }
        }
        private ObjectSet<Unpricing> _unpricings;
    
        public ObjectSet<VATInvoiceRequestLine> VATInvoiceRequestLines
        {
            get { return _vATInvoiceRequestLines  ?? (_vATInvoiceRequestLines = CreateObjectSet<VATInvoiceRequestLine>("VATInvoiceRequestLines")); }
        }
        private ObjectSet<VATInvoiceRequestLine> _vATInvoiceRequestLines;
    
        public ObjectSet<Commission> Commissions
        {
            get { return _commissions  ?? (_commissions = CreateObjectSet<Commission>("Commissions")); }
        }
        private ObjectSet<Commission> _commissions;
    
        public ObjectSet<CommissionLine> CommissionLines
        {
            get { return _commissionLines  ?? (_commissionLines = CreateObjectSet<CommissionLine>("CommissionLines")); }
        }
        private ObjectSet<CommissionLine> _commissionLines;
    
        public ObjectSet<SHFECapitalDetail> SHFECapitalDetails
        {
            get { return _sHFECapitalDetails  ?? (_sHFECapitalDetails = CreateObjectSet<SHFECapitalDetail>("SHFECapitalDetails")); }
        }
        private ObjectSet<SHFECapitalDetail> _sHFECapitalDetails;
    
        public ObjectSet<SHFEHoldingPosition> SHFEHoldingPositions
        {
            get { return _sHFEHoldingPositions  ?? (_sHFEHoldingPositions = CreateObjectSet<SHFEHoldingPosition>("SHFEHoldingPositions")); }
        }
        private ObjectSet<SHFEHoldingPosition> _sHFEHoldingPositions;
    
        public ObjectSet<SHFEPosition> SHFEPositions
        {
            get { return _sHFEPositions  ?? (_sHFEPositions = CreateObjectSet<SHFEPosition>("SHFEPositions")); }
        }
        private ObjectSet<SHFEPosition> _sHFEPositions;
    
        public ObjectSet<LogMessage> LogMessages
        {
            get { return _logMessages  ?? (_logMessages = CreateObjectSet<LogMessage>("LogMessages")); }
        }
        private ObjectSet<LogMessage> _logMessages;
    
        public ObjectSet<LogRegistration> LogRegistrations
        {
            get { return _logRegistrations  ?? (_logRegistrations = CreateObjectSet<LogRegistration>("LogRegistrations")); }
        }
        private ObjectSet<LogRegistration> _logRegistrations;
    
        public ObjectSet<LMEPosition> LMEPositions
        {
            get { return _lMEPositions  ?? (_lMEPositions = CreateObjectSet<LMEPosition>("LMEPositions")); }
        }
        private ObjectSet<LMEPosition> _lMEPositions;
    
        public ObjectSet<HedgeGroup> HedgeGroups
        {
            get { return _hedgeGroups  ?? (_hedgeGroups = CreateObjectSet<HedgeGroup>("HedgeGroups")); }
        }
        private ObjectSet<HedgeGroup> _hedgeGroups;
    
        public ObjectSet<HedgeLineLMEPosition> HedgeLineLMEPositions
        {
            get { return _hedgeLineLMEPositions  ?? (_hedgeLineLMEPositions = CreateObjectSet<HedgeLineLMEPosition>("HedgeLineLMEPositions")); }
        }
        private ObjectSet<HedgeLineLMEPosition> _hedgeLineLMEPositions;
    
        public ObjectSet<HedgeLineQuota> HedgeLineQuotas
        {
            get { return _hedgeLineQuotas  ?? (_hedgeLineQuotas = CreateObjectSet<HedgeLineQuota>("HedgeLineQuotas")); }
        }
        private ObjectSet<HedgeLineQuota> _hedgeLineQuotas;
    
        public ObjectSet<HedgeLineSHFEPosition> HedgeLineSHFEPositions
        {
            get { return _hedgeLineSHFEPositions  ?? (_hedgeLineSHFEPositions = CreateObjectSet<HedgeLineSHFEPosition>("HedgeLineSHFEPositions")); }
        }
        private ObjectSet<HedgeLineSHFEPosition> _hedgeLineSHFEPositions;
    
        public ObjectSet<WarehouseOutDeliveryPerson> WarehouseOutDeliveryPersons
        {
            get { return _warehouseOutDeliveryPersons  ?? (_warehouseOutDeliveryPersons = CreateObjectSet<WarehouseOutDeliveryPerson>("WarehouseOutDeliveryPersons")); }
        }
        private ObjectSet<WarehouseOutDeliveryPerson> _warehouseOutDeliveryPersons;
    
        public ObjectSet<TDCapitalDetail> TDCapitalDetails
        {
            get { return _tDCapitalDetails  ?? (_tDCapitalDetails = CreateObjectSet<TDCapitalDetail>("TDCapitalDetails")); }
        }
        private ObjectSet<TDCapitalDetail> _tDCapitalDetails;
    
        public ObjectSet<TDHoldingPosition> TDHoldingPositions
        {
            get { return _tDHoldingPositions  ?? (_tDHoldingPositions = CreateObjectSet<TDHoldingPosition>("TDHoldingPositions")); }
        }
        private ObjectSet<TDHoldingPosition> _tDHoldingPositions;
    
        public ObjectSet<TDPosition> TDPositions
        {
            get { return _tDPositions  ?? (_tDPositions = CreateObjectSet<TDPosition>("TDPositions")); }
        }
        private ObjectSet<TDPosition> _tDPositions;
    
        public ObjectSet<ContractUDF> ContractUDFs
        {
            get { return _contractUDFs  ?? (_contractUDFs = CreateObjectSet<ContractUDF>("ContractUDFs")); }
        }
        private ObjectSet<ContractUDF> _contractUDFs;
    
        public ObjectSet<Contract> Contracts
        {
            get { return _contracts  ?? (_contracts = CreateObjectSet<Contract>("Contracts")); }
        }
        private ObjectSet<Contract> _contracts;
    
        public ObjectSet<HedgeLineTDPosition> HedgeLineTDPositions
        {
            get { return _hedgeLineTDPositions  ?? (_hedgeLineTDPositions = CreateObjectSet<HedgeLineTDPosition>("HedgeLineTDPositions")); }
        }
        private ObjectSet<HedgeLineTDPosition> _hedgeLineTDPositions;
    
        public ObjectSet<LetterOfCredit> LetterOfCredits
        {
            get { return _letterOfCredits  ?? (_letterOfCredits = CreateObjectSet<LetterOfCredit>("LetterOfCredits")); }
        }
        private ObjectSet<LetterOfCredit> _letterOfCredits;
    
        public ObjectSet<QuotaBrandRel> QuotaBrandRels
        {
            get { return _quotaBrandRels  ?? (_quotaBrandRels = CreateObjectSet<QuotaBrandRel>("QuotaBrandRels")); }
        }
        private ObjectSet<QuotaBrandRel> _quotaBrandRels;
    
        public ObjectSet<SHFEFundFlow> SHFEFundFlows
        {
            get { return _sHFEFundFlows  ?? (_sHFEFundFlows = CreateObjectSet<SHFEFundFlow>("SHFEFundFlows")); }
        }
        private ObjectSet<SHFEFundFlow> _sHFEFundFlows;
    
        public ObjectSet<PSQuotaRel> PSQuotaRels
        {
            get { return _pSQuotaRels  ?? (_pSQuotaRels = CreateObjectSet<PSQuotaRel>("PSQuotaRels")); }
        }
        private ObjectSet<PSQuotaRel> _pSQuotaRels;
    
        public ObjectSet<LCCIRel> LCCIRels
        {
            get { return _lCCIRels  ?? (_lCCIRels = CreateObjectSet<LCCIRel>("LCCIRels")); }
        }
        private ObjectSet<LCCIRel> _lCCIRels;
    
        public ObjectSet<DeliveryPerson> DeliveryPersons
        {
            get { return _deliveryPersons  ?? (_deliveryPersons = CreateObjectSet<DeliveryPerson>("DeliveryPersons")); }
        }
        private ObjectSet<DeliveryPerson> _deliveryPersons;
    
        public ObjectSet<StorageFeeRule> StorageFeeRules
        {
            get { return _storageFeeRules  ?? (_storageFeeRules = CreateObjectSet<StorageFeeRule>("StorageFeeRules")); }
        }
        private ObjectSet<StorageFeeRule> _storageFeeRules;
    
        public ObjectSet<ForeignDeliveryPool> ForeignDeliveryPools
        {
            get { return _foreignDeliveryPools  ?? (_foreignDeliveryPools = CreateObjectSet<ForeignDeliveryPool>("ForeignDeliveryPools")); }
        }
        private ObjectSet<ForeignDeliveryPool> _foreignDeliveryPools;
    
        public ObjectSet<ForeignDeliveryPoolLine> ForeignDeliveryPoolLines
        {
            get { return _foreignDeliveryPoolLines  ?? (_foreignDeliveryPoolLines = CreateObjectSet<ForeignDeliveryPoolLine>("ForeignDeliveryPoolLines")); }
        }
        private ObjectSet<ForeignDeliveryPoolLine> _foreignDeliveryPoolLines;
    
        public ObjectSet<FDPStorageFeeSEDate> FDPStorageFeeSEDates
        {
            get { return _fDPStorageFeeSEDates  ?? (_fDPStorageFeeSEDates = CreateObjectSet<FDPStorageFeeSEDate>("FDPStorageFeeSEDates")); }
        }
        private ObjectSet<FDPStorageFeeSEDate> _fDPStorageFeeSEDates;
    
        public ObjectSet<LCAllocation> LCAllocations
        {
            get { return _lCAllocations  ?? (_lCAllocations = CreateObjectSet<LCAllocation>("LCAllocations")); }
        }
        private ObjectSet<LCAllocation> _lCAllocations;
    
        public ObjectSet<WeixinAlert> WeixinAlerts
        {
            get { return _weixinAlerts  ?? (_weixinAlerts = CreateObjectSet<WeixinAlert>("WeixinAlerts")); }
        }
        private ObjectSet<WeixinAlert> _weixinAlerts;

        #endregion

    }
}
