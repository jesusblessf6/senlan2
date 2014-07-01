using System;
using Client.Base.BaseClientVM;
using Client.ContractUDFServiceReference;
using Client.View.SystemSetting.DataDictSetting;
using DBEntity;
using Utility.ServiceManagement;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Client.ViewModel.SystemSetting.DataDictSetting
{
    public class ContractUDFDetailVM : BaseVM
    {
        #region Member

        private string _comment;
        private string _name;
        private bool _IsDefault;

        #endregion

        #region Property
        public bool IsDefault
        {
            get { return _IsDefault; }
            set { 
                if(_IsDefault != value)
                {
                    _IsDefault = value;
                    Notify("IsDefault");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Notify("Name");
                }
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    Notify("Comment");
                }
            }
        }

        #endregion

        #region Constructor

        public ContractUDFDetailVM()
        {
            ObjectId = 0;
            Initialize();
        }

        public ContractUDFDetailVM(int id)
        {
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        public void Initialize()
        {
            if (ObjectId > 0)
            {
                using (
                    var contractUDFService =
                        SvcClientManager.GetSvcClient<ContractUDFServiceClient>(SvcType.ContractUDFSvc))
                {
                    ContractUDF udf = contractUDFService.GetById(ObjectId);

                    if (udf != null)
                    {
                        Comment = udf.Comment;
                        Name = udf.Name;
                        IsDefault = udf.IsDefault;
                    }
                }
            }
        }

        protected override void Create()
        {
            var udf = new ContractUDF
                          {
                              Comment = Comment,
                              Name = Name,
                              IsDefault = IsDefault
                          };

            using (
                var contractUDFService = SvcClientManager.GetSvcClient<ContractUDFServiceClient>(SvcType.ContractUDFSvc)
                )
            {
                contractUDFService.AddNewContractUDF(udf, CurrentUser.Id);
            }
        }

        protected override void Update()
        {
            using (
                var contractUDFService = SvcClientManager.GetSvcClient<ContractUDFServiceClient>(SvcType.ContractUDFSvc)
                )
            {
                ContractUDF udf = contractUDFService.GetById(ObjectId);
                if (udf != null)
                {
                    udf.Comment = Comment;
                    udf.Name = Name;
                    udf.IsDefault = IsDefault;

                    contractUDFService.UpdateContractUDF(udf, CurrentUser.Id);
                }
                else
                {
                    throw new Exception(ResDataDictSetting.UDTNotFound);
                }
            }
        }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception(ResDataDictSetting.NameRequired);
            }

            if (IsDefault)
            {
                using (var contractUDFService = SvcClientManager.GetSvcClient<ContractUDFServiceClient>(SvcType.ContractUDFSvc))
                {
                    List<ContractUDF> allList = contractUDFService.GetAll();
                    if(allList != null && allList.Count > 0)
                    {
                        List<ContractUDF> defaultList = allList.Where(c => c.IsDefault).ToList();
                        if(defaultList != null && defaultList.Count > 0)
                        {
                            ContractUDF defualtContractUDF = defaultList.FirstOrDefault();
                            if(defualtContractUDF.Id != ObjectId)
                            {
                                if (MessageBox.Show("系统中已经存在默认的自定义类型，是否继续保存？", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                                {
                                    defualtContractUDF.IsDefault = false;
                                    contractUDFService.UpdateContractUDF(defualtContractUDF, CurrentUser.Id);
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        #endregion
    }
}