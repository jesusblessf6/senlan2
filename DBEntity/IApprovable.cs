namespace DBEntity
{
    public interface IApprovable : IDraftable
    {
        int? DocumentId { get; }

        decimal AmountForApproval { get; set; }

        int CurrencyIdForApproval { get; set; }

        int? ApproveStatus { get; set; }

        int? ApprovalStageIndex { get; set; }

        int? ApprovalId { get; set; }

        Approval Approval { get; set; }

        string RejectReason { get; set; }
    }
}
