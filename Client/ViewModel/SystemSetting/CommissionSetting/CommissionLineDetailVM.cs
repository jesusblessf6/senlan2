using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.CommissionLineServiceReference;
using Client.CommodityServiceReference;
using Client.View.SystemSetting.CommissionSetting;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;

namespace Client.ViewModel.SystemSetting.CommissionSetting
{
    public class CommissionLineDetailVM : BaseVM
    {
        #region Member

        private List<CommissionLine> _addCommissionLineList;
        private List<CommissionLine> _allCommissionLineList;
        private string _comment;
        private Dictionary<string, int> _commissionRuleTypes;
        private List<Commodity> _commodityList;
        private int _customerID;
        private DateTime? _endDate;
        private int _internalCustomerID;
        private bool _isDefault;
        private int _ruleTypeID;
        private decimal _ruleValue;
        private int _ruleTypeID2;
        private decimal _ruleValue2;
        private int _selectCommodityID;
        private DateTime? _startDate;
        private int? _carryDaysLimit;//调期头寸天数限制
        private bool? _inLimitIsOneLeg = false;//界限内是否收取一条头寸佣金
        private bool? _outLimitIsOneLeg = false;
        private int? _inLimitRuleTypeID1;//界限内头寸佣金规则1
        private decimal? _inLimitRuleValue1;//界限内头寸佣金规则1数值
        private int? _inLimitRuleTypeID2;
        private decimal? _inLimitRuleValue2;
        private int? _outLimitRuleTypeID1;
        private decimal? _outLimitRuleValue1;
        private int? _outLimitRuleTypeID2;
        private decimal? _outLimitRuleValue2;

        private List<CommissionLine> _updateCommissionLineList;

        #endregion

        #region Property
        public decimal? OutLimitRuleValue2
        {
            get { return _outLimitRuleValue2; }
            set
            {
                if (_outLimitRuleValue2 != value)
                {
                    _outLimitRuleValue2 = value;
                    Notify("OutLimitRuleValue2");
                }
            }
        }

        public int? OutLimitRuleTypeID2
        {
            get { return _outLimitRuleTypeID2; }
            set
            {
                if (_outLimitRuleTypeID2 != value)
                {
                    _outLimitRuleTypeID2 = value;
                    Notify("OutLimitRuleTypeID2");
                }
            }
        }

        public decimal? OutLimitRuleValue1
        {
            get { return _outLimitRuleValue1; }
            set
            {
                if (_outLimitRuleValue1 != value)
                {
                    _outLimitRuleValue1 = value;
                    Notify("OutLimitRuleValue1");
                }
            }
        }

        public int? OutLimitRuleTypeID1
        {
            get { return _outLimitRuleTypeID1; }
            set
            {
                if (_outLimitRuleTypeID1 != value)
                {
                    _outLimitRuleTypeID1 = value;
                    Notify("OutLimitRuleTypeID1");
                }
            }
        }

        public decimal? InLimitRuleValue2
        {
            get { return _inLimitRuleValue2; }
            set
            {
                if (_inLimitRuleValue2 != value)
                {
                    _inLimitRuleValue2 = value;
                    Notify("InLimitRuleValue2");
                }
            }
        }

        public int? InLimitRuleTypeID2
        {
            get { return _inLimitRuleTypeID2; }
            set
            {
                if (_inLimitRuleTypeID2 != value)
                {
                    _inLimitRuleTypeID2 = value;
                    Notify("InLimitRuleTypeID2");
                }
            }
        }

        public decimal? InLimitRuleValue1
        {
            get { return _inLimitRuleValue1; }
            set
            {
                if (_inLimitRuleValue1 != value)
                {
                    _inLimitRuleValue1 = value;
                    Notify("InLimitRuleValue1");
                }
            }
        }

        public int? InLimitRuleTypeID1
        {
            get { return _inLimitRuleTypeID1; }
            set
            {
                if (_inLimitRuleTypeID1 != value)
                {
                    _inLimitRuleTypeID1 = value;
                    Notify("InLimitRuleTypeID1");
                }
            }
        }

        public bool? OutLimitIsOneLeg
        {
            get { return _outLimitIsOneLeg; }
            set
            {
                if (_outLimitIsOneLeg != value)
                {
                    _outLimitIsOneLeg = value;
                    Notify("OutLimitIsOneLeg");
                }
            }
        }

        public bool? InLimitIsOneLeg
        {
            get { return _inLimitIsOneLeg; }
            set
            {
                if (_inLimitIsOneLeg != value)
                {
                    _inLimitIsOneLeg = value;
                    Notify("InLimitIsOneLeg");
                }
            }
        }

        public int? CarryDaysLimit
        {
            get { return _carryDaysLimit; }
            set
            {
                if (_carryDaysLimit != value)
                {
                    _carryDaysLimit = value;
                    Notify("CarryDaysLimit");
                }
            }
        }

        public decimal RuleValue2
        {
            get { return _ruleValue2; }
            set { 
                if(_ruleValue2 != value)
                {
                    _ruleValue2 = value;
                    Notify("RuleValue2");
                }
            }
        }

        public int RuleTypeID2
        {
            get { return _ruleTypeID2; }
            set { 
                if(_ruleTypeID2 != value)
                {
                    _ruleTypeID2 = value;
                    Notify("RuleTypeID2");
                }
            }
        }

        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                if (_customerID != value)
                {
                    _customerID = value;
                    Notify("CustomerID");
                }
            }
        }

        public int InternalCustomerID
        {
            get { return _internalCustomerID; }
            set
            {
                if (_internalCustomerID != value)
                {
                    _internalCustomerID = value;
                    Notify("InternalCustomerID");
                }
            }
        }

        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    Notify("IsDefault");
                }
            }
        }

        public int RuleTypeID
        {
            get { return _ruleTypeID; }
            set
            {
                if (_ruleTypeID != value)
                {
                    _ruleTypeID = value;
                    Notify("RuleTypeID");
                }
            }
        }

        public List<CommissionLine> AllCommissionLineList
        {
            get { return _allCommissionLineList; }
            set
            {
                if (_allCommissionLineList != value)
                {
                    _allCommissionLineList = value;
                    Notify("AllCommissionLineList");
                }
            }
        }

        public List<CommissionLine> UpdateCommissionLineList
        {
            get { return _updateCommissionLineList; }
            set
            {
                if (_updateCommissionLineList != value)
                {
                    _updateCommissionLineList = value;
                    Notify("UpdateCommissionLineList");
                }
            }
        }

        public List<CommissionLine> AddCommissionLineList
        {
            get { return _addCommissionLineList; }
            set
            {
                if (_addCommissionLineList != value)
                {
                    _addCommissionLineList = value;
                    Notify("AddCommissionLineList");
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

        public decimal RuleValue
        {
            get { return _ruleValue; }
            set
            {
                if (_ruleValue != value)
                {
                    _ruleValue = value;
                    Notify("RuleValue");
                }
            }
        }

        public Dictionary<string, int> CommissionRuleTypes
        {
            get { return _commissionRuleTypes; }
            set
            {
                if (_commissionRuleTypes != value)
                {
                    _commissionRuleTypes = value;
                    Notify("CommissionRuleTypes");
                }
            }
        }

        public int SelectCommodityID
        {
            get { return _selectCommodityID; }
            set
            {
                if (_selectCommodityID != value)
                {
                    _selectCommodityID = value;
                    Notify("SelectCommodityID");
                }
            }
        }

        public List<Commodity> CommodityList
        {
            get { return _commodityList; }
            set
            {
                if (_commodityList != value)
                {
                    _commodityList = value;
                    Notify("CommodityList");
                }
            }
        }

        #endregion

        #region Constructor

        public CommissionLineDetailVM(List<CommissionLine> addLines, List<CommissionLine> allLines, bool isDefault,
                                      int internalCustomerID, int customerID)
        {
            ObjectId = 0;
            IsDefault = isDefault;
            InternalCustomerID = internalCustomerID;
            CustomerID = customerID;
            AddCommissionLineList = addLines;
            AllCommissionLineList = allLines;
            LoadCommodity();
            LoadCommissionRuleType();
        }

        public CommissionLineDetailVM(int commissionLineID, List<CommissionLine> addLines, List<CommissionLine> allLines,
                                      List<CommissionLine> updateLines, bool isDefault, int internalCustomerID,
                                      int customerID)
        {
            ObjectId = commissionLineID;
            IsDefault = isDefault;
            InternalCustomerID = internalCustomerID;
            CustomerID = customerID;
            AddCommissionLineList = addLines;
            UpdateCommissionLineList = updateLines;
            AllCommissionLineList = allLines;
            LoadCommodity();
            LoadCommissionRuleType();
            LoadCommissionLine();
        }

        #endregion

        #region Method

        private void LoadCommodity()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commodityService.GetAll();
                if (CommodityList.Count > 0)
                {
                    if (SelectCommodityID <= 0)
                    {
                        SelectCommodityID = CommodityList[0].Id;
                    }
                }
            }
        }

        private void LoadCommissionRuleType()
        {
            CommissionRuleTypes = new Dictionary<string, int>();
            CommissionRuleTypes = EnumHelper.GetEnumDic<CommissionRuleType>(CommissionRuleTypes);
            RuleTypeID = (int) CommissionRuleType.Percent;
            RuleTypeID2 = (int)CommissionRuleType.Percent;
            InLimitRuleTypeID1 = (int)CommissionRuleType.Percent;
            InLimitRuleTypeID2 = (int)CommissionRuleType.Percent;
            OutLimitRuleTypeID1 = (int)CommissionRuleType.Percent;
            OutLimitRuleTypeID2 = (int)CommissionRuleType.Percent;
        }

        private void LoadCommissionLine()
        {
            if (ObjectId != 0)
            {
                List<CommissionLine> lines = AllCommissionLineList.Where(c => c.Id == ObjectId).ToList();
                if (lines.Count > 0)
                {
                    CommissionLine line = lines[0];
                    SelectCommodityID = line.CommodityId;
                    RuleValue = line.RuleValue == null ? 0 : (decimal) line.RuleValue;
                    RuleValue2 = line.RuleValue2 == null ? 0 : line.RuleValue2.Value;
                    RuleTypeID = line.RuleType;
                    RuleTypeID2 = line.RuleType2 == null ? 0 : line.RuleType2.Value;
                    CarryDaysLimit = line.CarryDaysLimit;
                    InLimitIsOneLeg = line.InLimitIsOneLeg;
                    InLimitRuleTypeID1 = line.InLimitRuleType1;
                    InLimitRuleValue1 = line.InLimitRuleValue1;
                    InLimitRuleTypeID2 = line.InLimitRuleType2;
                    InLimitRuleValue2 = line.InLimitRuleValue2;
                    OutLimitIsOneLeg = line.OutLimieIsOneLeg;
                    OutLimitRuleTypeID1 = line.OutLimitRuleType1;
                    OutLimitRuleValue1 = line.OutLimitRuleValue1;
                    OutLimitRuleTypeID2 = line.OutLimitRuleType2;
                    OutLimitRuleValue2 = line.OutLimitRuleValue2;
                    StartDate = line.StartDate;
                    EndDate = line.EndDate;
                    Comment = line.Comment;
                }
            }
        }

        protected override void Create()
        {
            var commissionLine = new CommissionLine();
            if (AllCommissionLineList.Count <= 0)
            {
                commissionLine.Id = -1;
            }
            else
            {
                var lineIdList = AllCommissionLineList.Select(line => Math.Abs(line.Id)).ToList();

                int maxID = lineIdList.Max();
                commissionLine.Id = -(maxID + 1);
            }

            commissionLine.Comment = Comment;
            commissionLine.CommodityId = SelectCommodityID;
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Commodity commodity = commodityService.GetById(SelectCommodityID);
                commissionLine.Commodity = commodity;
            }
            commissionLine.EndDate = EndDate;
            commissionLine.RuleType = RuleTypeID;
            commissionLine.RuleValue = Math.Round(RuleValue, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
            commissionLine.RuleType2 = RuleTypeID2;
            commissionLine.RuleValue2 = Math.Round(RuleValue2, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
            commissionLine.CarryDaysLimit = CarryDaysLimit;
            commissionLine.InLimitIsOneLeg = InLimitIsOneLeg;
            commissionLine.InLimitRuleType1 = InLimitRuleTypeID1;
            commissionLine.InLimitRuleValue1 = Math.Round(InLimitRuleValue1 == null ? 0 : InLimitRuleValue1.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
            commissionLine.InLimitRuleType2 = InLimitRuleTypeID2;
            commissionLine.InLimitRuleValue2 = Math.Round(InLimitRuleValue2 == null ? 0 : InLimitRuleValue2.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
            commissionLine.OutLimieIsOneLeg = OutLimitIsOneLeg;
            commissionLine.OutLimitRuleType1 = OutLimitRuleTypeID1;
            commissionLine.OutLimitRuleValue1 = Math.Round(OutLimitRuleValue1 == null ? 0 : OutLimitRuleValue1.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
            commissionLine.OutLimitRuleType2 = OutLimitRuleTypeID2;
            commissionLine.OutLimitRuleValue2 = Math.Round(OutLimitRuleValue2 == null ? 0 : OutLimitRuleValue2.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
            commissionLine.StartDate = StartDate;
            AddCommissionLineList.Add(commissionLine);
            AllCommissionLineList.Add(commissionLine);
        }

        protected override void Update()
        {
            var commissionLine = new CommissionLine();
            if (AllCommissionLineList.Count > 0)
            {
                List<CommissionLine> lines = AllCommissionLineList.Where(c => c.Id == ObjectId).ToList();
                if (lines.Count > 0)
                {
                    CommissionLine line = lines[0];
                    commissionLine.Id = line.Id;
                    commissionLine.Comment = Comment;
                    commissionLine.CommodityId = SelectCommodityID;
                    using (
                        var commodityService =
                            SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
                    {
                        Commodity commodity = commodityService.GetById(SelectCommodityID);
                        commissionLine.Commodity = commodity;
                    }
                    commissionLine.EndDate = EndDate;
                    commissionLine.RuleType = RuleTypeID;
                    commissionLine.RuleValue = Math.Round(RuleValue, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
                    commissionLine.RuleType2 = RuleTypeID2;
                    commissionLine.RuleValue2 = Math.Round(RuleValue2, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
                    commissionLine.CarryDaysLimit = CarryDaysLimit;
                    commissionLine.InLimitIsOneLeg = InLimitIsOneLeg;
                    commissionLine.InLimitRuleType1 = InLimitRuleTypeID1;
                    commissionLine.InLimitRuleValue1 = Math.Round(InLimitRuleValue1 == null ? 0 : InLimitRuleValue1.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
                    commissionLine.InLimitRuleType2 = InLimitRuleTypeID2;
                    commissionLine.InLimitRuleValue2 = Math.Round(InLimitRuleValue2 == null ? 0 : InLimitRuleValue2.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
                    commissionLine.OutLimieIsOneLeg = OutLimitIsOneLeg;
                    commissionLine.OutLimitRuleType1 = OutLimitRuleTypeID1;
                    commissionLine.OutLimitRuleValue1 = Math.Round(OutLimitRuleValue1 == null ? 0 : OutLimitRuleValue1.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
                    commissionLine.OutLimitRuleType2 = OutLimitRuleTypeID2;
                    commissionLine.OutLimitRuleValue2 = Math.Round(OutLimitRuleValue2 == null ? 0 : OutLimitRuleValue2.Value, RoundRules.LMECOMMISSION, MidpointRounding.AwayFromZero);
                    commissionLine.StartDate = StartDate;
                    if (line.Id < 0)
                    {
                        if (AddCommissionLineList.Count > 0)
                        {
                            List<CommissionLine> addLines = AddCommissionLineList.Where(c => c.Id == line.Id).ToList();
                            if (addLines.Count > 0)
                            {
                                CommissionLine addLine = addLines[0];
                                AddCommissionLineList.Remove(addLine);
                                AddCommissionLineList.Add(commissionLine);
                            }
                        }
                    }
                    else if (line.Id > 0)
                    {
                        commissionLine.CommissionId = line.CommissionId;
                        if (UpdateCommissionLineList.Count > 0)
                        {
                            List<CommissionLine> updateLines =
                                UpdateCommissionLineList.Where(c => c.Id == line.Id).ToList();
                            if (updateLines.Count > 0)
                            {
                                CommissionLine updateLine = updateLines[0];
                                UpdateCommissionLineList.Remove(updateLine);
                            }
                        }
                        UpdateCommissionLineList.Add(commissionLine);
                    }
                    AllCommissionLineList.Remove(line);
                    AllCommissionLineList.Add(commissionLine);
                }
            }
        }

        public override bool Validate()
        {
            if (StartDate == null)
            {
                throw new Exception(Properties.Resources.StartDateRequired);
            }

            if (EndDate == null)
            {
                throw new Exception(Properties.Resources.EndDateRequired);
            }

            if (StartDate > EndDate)
            {
                throw new Exception(Properties.Resources.DateLimitation);
            }

            List<CommissionLine> list =
                AllCommissionLineList.Where(
                    c =>
                    ((c.StartDate >= StartDate && c.EndDate <= EndDate) ||
                    (c.StartDate <= StartDate && c.EndDate >= EndDate) ||
                    (c.StartDate <= StartDate && c.EndDate >= StartDate) || (c.StartDate <= EndDate && c.EndDate >= EndDate)) && c.CommodityId == SelectCommodityID)
                    .ToList();

            if (list.Count > 0)
            {
                if (ObjectId == 0)
                {
                    throw new Exception(ResCommissionSetting.CommissionDateNotCollapsed);
                }
                
                if (list.Select(c => c.Id).Contains(ObjectId))
                {
                    if (list.Count > 1)
                    {
                        throw new Exception(ResCommissionSetting.CommissionDateNotCollapsed);
                    }
                }
            }
            using (
                var commissionLineService =
                    SvcClientManager.GetSvcClient<CommissionLineServiceClient>(SvcType.CommissionLineSvc))
            {
                string str = IsDefault
                                 ? "it.CommodityId == @p5 and it.Commission.InternalBPId == @p1 and it.Commission.IsDefaultRule == @p2 and ((it.StartDate >= @p3 and it.EndDate <= @p4) or (it.StartDate <= @p3 and it.EndDate >= @p3) or (it.StartDate < @p3 and it.EndDate > @p3) or (it.StartDate < @p4 and it.EndDate > @p4))"
                                 : "it.CommodityId == @p5 and it.Commission.InternalBPId == @p1 and it.Commission.IsDefaultRule == @p2 and it.Commission.BPId == @p5 and ((it.StartDate >= @p3 and it.EndDate <= @p4) or (it.StartDate <= @p3 and it.EndDate >= @p3) or (it.StartDate < @p3 and it.EndDate > @p3) or (it.StartDate < @p4 and it.EndDate > @p4))";
                var parameters = new List<object>
                                     {InternalCustomerID, IsDefault, StartDate, EndDate, CustomerID, SelectCommodityID};
                List<CommissionLine> lines = commissionLineService.Query(str, parameters);
                if (lines.Count > 0)
                {
                    if (ObjectId > 0)
                    {
                        if (lines.Select(c => c.Id).Contains(ObjectId))
                        {
                            if (lines.Count > 1)
                            {
                                throw new Exception(ResCommissionSetting.CommissionDateNotCollapsed);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(ResCommissionSetting.CommissionDateNotCollapsed);
                    }
                }
            }

            return true;
        }

        #endregion
    }
}