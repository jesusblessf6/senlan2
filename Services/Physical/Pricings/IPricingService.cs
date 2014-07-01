using System.Collections.Generic;
using System.ServiceModel;
using DBEntity.EnumEntity;
using Services.Base;
using DBEntity;
using System;
using System.Runtime.Serialization;

namespace Services.Physical.Pricings
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPricingService" in both code and config file together.
    [ServiceContract]
    public interface IPricingService : IService<Pricing>
    {
        [OperationContract]
        List<Pricing> GetPricingByQuotaId(int quotaId);

        [OperationContract]
        decimal GetAvgPricing(int quotaId);

        [OperationContract]
        Pricing AddNewManualPricing(Pricing pricing, int userId, bool isPricingComplete);

        [OperationContract]
        void UpdateManualPricing(Pricing obj, int userId, bool isPricingComplete);

        [OperationContract]
        Currency GetCurrencyByPricingBasis(PricingBasis pb);

        [OperationContract]
        decimal GetQtyByParameters(int commodityID, int internalCustomerID, DateTime? date, string type, int contractType, int userId);

        [OperationContract]
        List<ExposureChartClass> GetLine(DateTime? startDate, DateTime? endDate, int commodityID, int internalCustomerID, decimal? proportionValue, int userId);
    }

    [DataContract]
    public class ExposureChartClass
    {
        //当天现货采购
        [DataMember]
        public decimal? Qty1 { get; set; }
        //当天现货销售
        [DataMember]
        public decimal? Qty2 { get; set; }

        //LME当天买入数量
        [DataMember]
        public decimal? LmeQty3 { get; set; }
        //LME当天卖出数量
        [DataMember]
        public decimal? LmeQty4 { get; set; }
        //SHFE当天买入数量
        [DataMember]
        public decimal? ShfeQty3 { get; set; }
        //SHFE当天卖出数量
        [DataMember]
        public decimal? ShfeQty4 { get; set; }

        [DataMember]
        public double Y { get; set; }

        [DataMember]
        public string X { get; set; }

    }
}
