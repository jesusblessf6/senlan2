using System;
using System.Linq;
using Client.Base.BaseClientVM;
using DBEntity;

namespace Client.ViewModel.Physical.ForeignDeliveryPools
{
    public class StorageFeeDateDetailVM : ObjectBaseVM
    {
        #region Members & Properties

        public ForeignDeliveryPoolDetailVM ParentVM { get; set; }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    Notify("StartDate");
                }
            }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    Notify("EndDate");
                }
            }
        }

        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    Notify("Comments");
                }
            }
        }

        #endregion

        #region Constructor

        public StorageFeeDateDetailVM(ForeignDeliveryPoolDetailVM parentVM)
        {
            ParentVM = parentVM;
            Initialize();
        }

        public StorageFeeDateDetailVM(ForeignDeliveryPoolDetailVM parentVM, int id)
        {
            ParentVM = parentVM;
            ObjectId = id;
            Initialize();
        }

        #endregion

        #region Method

        private void Initialize()
        {
            if (ObjectId != 0)
            {
                var storageDate = ParentVM.StorageDates.Single(o => o.Id == ObjectId);
                _startDate = storageDate.StartDate;
                _endDate = storageDate.EndDate;
                _comments = storageDate.Comment;
            }
        }

        protected override void Create()
        {
            var newLine = new FDPStorageFeeSEDate
                              {
                                  StartDate = StartDate,
                                  EndDate = EndDate,
                                  Comment = Comments,
                                  Id = -(ParentVM.StorageDates.Count + 1)
                              };
            ParentVM.StorageDates.Add(newLine);
            ParentVM.NewAddedStorageDateLines.Add(newLine);
        }

        protected override void Update()
        {
            var line = ParentVM.StorageDates.Single(o => o.Id == ObjectId);
            
            line.StartDate = StartDate;
            line.EndDate = EndDate;
            line.Comment = Comments;

            if (ObjectId > 0 && ParentVM.ModifiedStorageDateLines.All(o => o.Id != ObjectId))
            {
                ParentVM.ModifiedStorageDateLines.Add(line);
            }
        }

        public override bool Validate()
        {
            if (StartDate == null)
            {
                throw new Exception("请输入起始日期");
            }

            return true;
        }

        #endregion
    }
}
