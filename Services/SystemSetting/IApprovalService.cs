using System.ServiceModel;
using DBEntity;
using Services.Base;
using System.Collections.Generic;

namespace Services.SystemSetting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IApprovalService" in both code and config file together.
    [ServiceContract]
    public interface IApprovalService : IService<Approval>
    {
        [OperationContract]
        List<Document> GetApprovableDocument();

        [OperationContract]
        Approval AddNewApproval(Approval approval, int userId);

        [OperationContract]
        Approval UpdateExistedApproval(Approval approval, int userId);

        [OperationContract]
        void DeleteApproval(int id, int userId);

        [OperationContract]
        List<ApprovalCondition> GetApprovalConditions(int approvalId, List<string> includes );

        [OperationContract]
        List<ApprovalStage> GetApprovalStages(int approvalId, List<string> includes );

        [OperationContract]
        bool ApproveQuota(int id, int userId);

        [OperationContract]
        bool RejectQuota(int id, string rejectReason, int userId);

        [OperationContract]
        bool CanEdit(int id);

        [OperationContract]
        bool CanDelete(int id);

        [OperationContract]
        bool ApprovePaymentRequest(int id, int userId);

        [OperationContract]
        bool RejectPaymentRequest(int id, string rejectReason, int userId);

        [OperationContract]
        bool ApproveVATInvoiceRequestLine(int id, int userId);

        [OperationContract]
        bool RejectVATInvoiceRequestLine(int id, string rejectReason, int userId);

	    [OperationContract]
	    bool ApproveBP(int id, int userId);

	    [OperationContract]
	    bool RejectBP(int id, string rejectReason, int userId);
    }
}
