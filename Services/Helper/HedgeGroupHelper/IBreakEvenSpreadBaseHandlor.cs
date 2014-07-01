using DBEntity;

namespace Services.Helper.HedgeGroupHelper
{
    public interface IBreakEvenSpreadBaseHandlor
    {
        void Handle(HedgeGroup hg, SenLan2Entities ctx);
    }
}