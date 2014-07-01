using DBEntity;

namespace Services.Helper.Pricings
{
    public interface IPricingHandler
    {
        void Handle();
        void Create();
        void Update();
        void Recreate();

        Quota Quota { get; set; }
        SenLan2Entities CTX { get; set; }
    }
}
