using System.Runtime.Serialization;

namespace PriceDBEntity
{
    public class CurrentPrice
    {
        public CurrentPrice()
        {
            Price = -1;
            Currency = "CNY";
        }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Currency { get; set; }
    }
}
