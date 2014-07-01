using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.LogRegistrationServiceReference;
using DBEntity;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.LogRegister
{
    public class LogRegisterVM : BaseVM
    {
        #region Property

        //Quota Create
        private bool _isRegDeliveryCreate;
        private bool _isRegDeliveryDelete;
        private bool _isRegDeliveryUpdate;
        private bool _isRegQuotaApprove;
        private bool _isRegQuotaCreate;
        private bool _isRegQuotaDelete;
        private bool _isRegQuotaReject;

        //Quota Update
        private bool _isRegQuotaUpdate;

        public bool IsRegQuotaCreate
        {
            get { return _isRegQuotaCreate; }
            set
            {
                if (_isRegQuotaCreate != value)
                {
                    _isRegQuotaCreate = value;
                    Notify("IsRegQuotaCreate");
                }
            }
        }

        public bool IsRegQuotaUpdate
        {
            get { return _isRegQuotaUpdate; }
            set
            {
                if (_isRegQuotaUpdate != value)
                {
                    _isRegQuotaUpdate = value;
                    Notify("IsRegQuotaUpdate");
                }
            }
        }

        //Quota Delete

        public bool IsRegQuotaDelete
        {
            get { return _isRegQuotaDelete; }
            set
            {
                if (_isRegQuotaDelete != value)
                {
                    _isRegQuotaDelete = value;
                    Notify("IsRegQuotaDelete");
                }
            }
        }

        //Quota Approve

        public bool IsRegQuotaApprove
        {
            get { return _isRegQuotaApprove; }
            set
            {
                if (_isRegQuotaApprove != value)
                {
                    _isRegQuotaApprove = value;
                    Notify("IsRegQuotaApprove");
                }
            }
        }

        //Quota Reject

        public bool IsRegQuotaReject
        {
            get { return _isRegQuotaReject; }
            set
            {
                if (_isRegQuotaReject != value)
                {
                    _isRegQuotaReject = value;
                    Notify("IsRegQuotaReject");
                }
            }
        }

        //Delivery Create

        public bool IsRegDeliveryCreate
        {
            get { return _isRegDeliveryCreate; }
            set
            {
                if (_isRegDeliveryCreate != value)
                {
                    _isRegDeliveryCreate = value;
                    Notify("IsRegDeliveryCreate");
                }
            }
        }

        //Delivery Update

        public bool IsRegDeliveryUpdate
        {
            get { return _isRegDeliveryUpdate; }
            set
            {
                if (_isRegDeliveryUpdate != value)
                {
                    _isRegDeliveryUpdate = value;
                    Notify("IsRegDeliveryUpdate");
                }
            }
        }

        //Delivery Delete

        public bool IsRegDeliveryDelete
        {
            get { return _isRegDeliveryDelete; }
            set
            {
                if (_isRegDeliveryDelete != value)
                {
                    _isRegDeliveryDelete = value;
                    Notify("IsRegDeliveryDelete");
                }
            }
        }

        //Aggregate
        public List<RegistrationInfo> Infos { get; set; }

        #endregion

        #region Constructor

        public LogRegisterVM()
        {
            ObjectId = 0;
            Initialize();
        }

        #endregion

        #region Method

        public override void Save()
        {
            var regs = new List<LogRegistration>();
            foreach (RegistrationInfo r in Infos)
            {
                if ((bool) GetType().GetProperty(r.RegProperty).GetGetMethod().Invoke(this, null))
                {
                    var l = new LogRegistration
                                {
                                    Document = new Document {TableCode = r.TableCode},
                                    LogAction = new LogAction {Code = r.ActionCode},
                                    UserId = CurrentUser.Id
                                };
                    regs.Add(l);
                }
            }

            using (
                var regService = SvcClientManager.GetSvcClient<LogRegistrationServiceClient>(SvcType.LogRegistrationSvc)
                )
            {
                regService.UpdateUserRegistration(regs, CurrentUser.Id);
            }
        }

        //Initialize the VM
        private void Initialize()
        {
            Infos = new List<RegistrationInfo>
                        {
                            new RegistrationInfo
                                {ActionCode = "Create", TableCode = "Quota", RegProperty = "IsRegQuotaCreate"},
                            new RegistrationInfo
                                {ActionCode = "Update", TableCode = "Quota", RegProperty = "IsRegQuotaUpdate"},
                            new RegistrationInfo
                                {ActionCode = "Delete", TableCode = "Quota", RegProperty = "IsRegQuotaDelete"},
                            new RegistrationInfo
                                {ActionCode = "Approve", TableCode = "Quota", RegProperty = "IsRegQuotaApprove"},
                            new RegistrationInfo
                                {ActionCode = "Reject", TableCode = "Quota", RegProperty = "IsRegQuotaReject"},
                            new RegistrationInfo
                                {ActionCode = "Create", TableCode = "Delivery", RegProperty = "IsRegDeliveryCreate"},
                            new RegistrationInfo
                                {ActionCode = "Update", TableCode = "Delivery", RegProperty = "IsRegDeliveryUpdate"},
                            new RegistrationInfo
                                {ActionCode = "Delete", TableCode = "Delivery", RegProperty = "IsRegDeliveryDelete"}
                        };

            using (
                var regService = SvcClientManager.GetSvcClient<LogRegistrationServiceClient>(SvcType.LogRegistrationSvc)
                )
            {
                List<LogRegistration> regs = regService.GetRegsByUser(CurrentUser.Id);

                foreach (LogRegistration logRegistration in regs)
                {
                    LogRegistration registration = logRegistration;
                    List<string> properties = Infos.Where(
                        o =>
                        o.TableCode == registration.Document.TableCode &&
                        o.ActionCode == registration.LogAction.Code).Select(o => o.RegProperty).ToList();

                    foreach (string property in properties)
                    {
                        GetType().GetProperty(property).GetSetMethod().Invoke(this, new object[] {true});
                    }
                }
            }
        }

        #endregion
    }

    public class RegistrationInfo
    {
        public string TableCode { get; set; }
        public string ActionCode { get; set; }
        public string RegProperty { get; set; }
    }
}