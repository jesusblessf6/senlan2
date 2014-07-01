using System;
using System.Collections.Generic;
using Client.Base.BaseClientVM;
using Client.CommodityServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.QueryManagement;
using Utility.ServiceManagement;

namespace Client.ViewModel.Physical.ForeignDeliveryPools
{
    public class ForeignDeliveryPoolHomeVM : HomeBaseVM
    {
    	#region Query Type Enum

    	public enum ForeignDeliveryPoolQueryType
    	{
    		Free = 1,
    		CurrentMonth = 2
    	}

    	#endregion

    	#region Members & Properties
        private string _markNo;
        public string MarkNo
        {
            get { return _markNo; }
            set { 
                if(_markNo != value)
                {
                    _markNo = value;
                    Notify("MarkNo");
                }
            }
        }

    	private List<Commodity> _commodities;
    	public List<Commodity> Commodities
    	{
    		get { return _commodities; }
    		set
    		{
    			_commodities = value;
    			Notify("Commodities");
    		}
    	}

    	private int _selectedCommodityId;
    	public int SelectedCommodityId
    	{
    		get { return _selectedCommodityId; }
    		set
    		{
    			if(_selectedCommodityId != value)
    			{
    				_selectedCommodityId = value;
    				Notify("SelectedCommodityId");
    			}
    		}
    	}

        private List<EnumItem> _deliveryTypes;
        public List<EnumItem> DeliveryTypes
        {
            get { return _deliveryTypes; }
            set
            {
                _deliveryTypes = value;
                Notify("DeliveryTypes");
            }
        }

        private int _selectedDeliveryTypeId;
        public int SelectedDeliveryTypeId
        {
            get { return _selectedDeliveryTypeId; }
            set
            {
                if (_selectedDeliveryTypeId != value)
                {
                    _selectedDeliveryTypeId = value;
                    Notify("SelectedDeliveryTypeId");
                }
            }
        }

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

        private string _deliveryNo;
        public string DeliveryNo
        {
            get { return _deliveryNo; }
            set
            {
                if (_deliveryNo != value)
                {
                    _deliveryNo = value;
                    Notify("DeliveryNo");
                }
            }
        }

        private bool _onlyCurrentUser;
        public bool OnlyCurrentUser
        {
            get { return _onlyCurrentUser; }
            set
            {
                if (_onlyCurrentUser != value)
                {
                    _onlyCurrentUser = value;
                    Notify("OnlyCurrentUser");
                }
            }
        }

        private decimal? _netWeight;
        public decimal? NetWeight
        {
            get { return _netWeight; }
            set
            {
                if (_netWeight != value)
                {
                    _netWeight = value;
                    Notify("NetWeight");
                }
            }
        }

    	#endregion

        #region Construtor

        public ForeignDeliveryPoolHomeVM()
        {
            Initialize();
        }

        #endregion

        #region Method

        public override List<QueryElement> GetQueryElements(object queryType = null)
        {
            var type = queryType == null ? ForeignDeliveryPoolQueryType.Free : (ForeignDeliveryPoolQueryType) queryType;
            var result = new List<QueryElement>();

            switch (type)
            {
                case ForeignDeliveryPoolQueryType.CurrentMonth:
                    var beginOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    var endOfCurrentMonth = beginOfCurrentMonth.AddMonths(1).AddDays(-1);
                    result.Add(new QueryElement
                                   {
                                       FieldName = "IssueDate",
                                       Operator = Operator.GreaterEqualThan,
                                       Value = beginOfCurrentMonth
                                   });
                    result.Add(new QueryElement
                                   {
                                       FieldName = "IssueDate",
                                       Operator = Operator.LessEqualThan,
                                       Value = endOfCurrentMonth
                                   });
                    break;

                case ForeignDeliveryPoolQueryType.Free:
                    if (SelectedCommodityId > 0)
                    {
                        result.Add(new QueryElement
                                       {
                                           FieldName = "CommodityId",
                                           Operator = Operator.Equal,
                                           Value = SelectedCommodityId
                                       });
                    }

                    if (SelectedDeliveryTypeId > 0)
                    {
                        result.Add(new QueryElement
                                       {
                                           FieldName = "DeliveryType",
                                           Operator = Operator.Equal,
                                           Value = SelectedDeliveryTypeId
                                       });
                    }

                    if (StartDate != null)
                    {
                        result.Add(new QueryElement
                                       {
                                           FieldName = "IssueDate",
                                           Operator = Operator.GreaterEqualThan,
                                           Value = StartDate
                                       });
                    }

                    if (EndDate != null)
                    {
                        result.Add(new QueryElement
                                       {
                                           FieldName = "IssueDate",
                                           Operator = Operator.LessEqualThan,
                                           Value = EndDate
                                       });
                    }

                    if (!string.IsNullOrWhiteSpace(DeliveryNo))
                    {
                        result.Add(new QueryElement
                                       {
                                           FieldName = "DeliveryNo",
                                           Operator = Operator.Like,
                                           Value = DeliveryNo
                                       });
                    }

                    if (OnlyCurrentUser)
                    {
                        result.Add(new QueryElement
                                       {
                                           FieldName = "CreatedBy",
                                           Operator = Operator.Equal,
                                           Value = CurrentUser.Id
                                       });
                    }

                    if (NetWeight.HasValue)
                    {
                        result.Add(new QueryElement
                        {
                            FieldName = "TotalNetWeight",
                            Operator = Operator.Equal,
                            Value = NetWeight.Value
                        });
                    }

                    if(!string.IsNullOrEmpty(MarkNo))
                    {
                        result.Add(new QueryElement { 
                            FieldName = "MarkNo",
                            Operator = Operator.Like,
                            Value = MarkNo
                        }
                        );
                    }
                    break;
            }

            return result;
        }

        private void Initialize()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                _commodities = commService.GetCommoditiesByUser(CurrentUser.Id);
                _commodities.Insert(0, new Commodity());
            }

            _deliveryTypes = new List<EnumItem>
                                 {
                                     new EnumItem(),
                                     EnumHelper.GetEnumItem<DeliveryType>((int) DeliveryType.ExternalTDBOL),
                                     EnumHelper.GetEnumItem<DeliveryType>((int) DeliveryType.ExternalTDWW)
                                 };

            _startDate = null;
            _endDate = null;

            _onlyCurrentUser = true;
        }

        public override void Reset()
        {
            SelectedCommodityId = 0;
            SelectedDeliveryTypeId = 0;
            StartDate = null;
            EndDate = null;
            DeliveryNo = null;
            OnlyCurrentUser = true;
            NetWeight = null;
        }

        #endregion
    }
}
