using System.Collections.Generic;
using Client.AttachmentServiceReference;
using Client.Base.BaseClientVM;
using Client.DocumentServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.Contracts
{
    public class AttachmentListVM : BaseVM
    {
        #region Member

        private List<Attachment> _attachments;
        private int _contractId;

        #endregion

        #region Property

        public int ContractId
        {
            get { return _contractId; }
            set
            {
                if (_contractId != value)
                {
                    _contractId = value;
                    Notify("ContractId");
                }
            }
        }

        public List<Attachment> Attachments
        {
            get { return _attachments; }
            set
            {
                if (_attachments != value)
                {
                    _attachments = value;
                    Notify("Attachments");
                }
            }
        }

        #endregion

        #region Constructor

        public AttachmentListVM(int contractId)
        {
            ContractId = contractId;
            BindData();
        }

        public AttachmentListVM(int id,string code)
        {
            LoadAttachment(id, code);
        }

        #endregion

        #region Method

        public void BindData()
        {
            LoadAttachment(ContractId);
        }

        public Attachment GetAttachmentById(int id)
        {
            Attachment attachment;
            using (var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc)
                )
            {
                attachment = attachmentService.GetById(id);
            }
            return attachment;
        }

        public void LoadAttachment(int quotaId)
        {
            int id = GetDocumentId("Contract");
            using (var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc)
                )
            {
                string queryStr = "it.RecordId = @p1 and it.DocumentId= " + id;
                var parameters = new List<object> {quotaId};
                _attachments = attachmentService.Query(queryStr, parameters);
                Attachments=attachmentService.ChangeAttachmentName(_attachments);
            }
        }

        public void LoadAttachment(int itemId,string code)
        {
            int id = GetDocumentId(code);
            using (var attachmentService = SvcClientManager.GetSvcClient<AttachmentServiceClient>(SvcType.AttachmentSvc)
                )
            {
                string queryStr = "it.RecordId = @p1 and it.DocumentId= " + id;
                var parameters = new List<object> { itemId };
                _attachments = attachmentService.Query(queryStr, parameters);
                Attachments= attachmentService.ChangeAttachmentName(_attachments);
            }
        }

        private int GetDocumentId(string code)
        {
            int id;
            using (var documentService = SvcClientManager.GetSvcClient<DocumentServiceClient>(SvcType.DocumentSvc))
            {
                id = documentService.GetByTableCode(code).Id;
            }
            return id;
        }

        
        #endregion
    }
}