namespace DBEntity
{
	public partial class BusinessPartner : IApprovable
	{
		
		public decimal AmountForApproval { get; set; }
		public int CurrencyIdForApproval { get; set; }
		
		public string CustomerStrField1 { get; set; }
		public string CustomerStrField2 { get; set; }
	}
}
