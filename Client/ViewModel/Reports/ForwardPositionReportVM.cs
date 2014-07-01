using System;
using System.Collections.Generic;
using System.Linq;
using Client.Base.BaseClientVM;
using DBEntity;
using Utility.ServiceManagement;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using DBEntity.EnumEntity;
using ZedGraph;
using Client.SHFEPositionServiceReference;
using System.Drawing;
using Client.LMEPositionServiceReference;
using System.Globalization;
namespace Client.ViewModel.Reports
{
    public class ForwardPositionReportVM : BaseVM
    {
        #region Member
        private List<Commodity> _commodityList;
        private List<BusinessPartner> _internalCustomerList;
        private List<BusinessPartner> _brokerList;
        private List<ForwardPositionReportClass> _shfeList;
        private List<LMEExposureDetailLine> _lmeList;
        private int _selectedInternalID;
        private int _selectedBrokerID;
        private int _selectedCommodityID;
        private int _selectedInternalID1;
        private int _selectedBrokerID1;
        private int _selectedCommodityID1;
        #endregion

        #region Property
        public List<LMEExposureDetailLine> LMEList
        {
            get { return _lmeList; }
            set
            {
                if (_lmeList != value)
                {
                    _lmeList = value;
                    Notify("LMEList");
                }
            }
        }

        public int SelectedCommodityID1
        {
            get { return _selectedCommodityID1; }
            set
            {
                if (_selectedCommodityID1 != value)
                {
                    _selectedCommodityID1 = value;
                    Notify("SelectedCommodityID1");
                }
            }
        }

        public int SelectedBrokerID1
        {
            get { return _selectedBrokerID1; }
            set
            {
                if (_selectedBrokerID1 != value)
                {
                    _selectedBrokerID1 = value;
                    Notify("SelectedBrokerID1");
                }
            }
        }

        public int SelectedInternalID1
        {
            get { return _selectedInternalID1; }
            set
            {
                if (_selectedInternalID1 != value)
                {
                    _selectedInternalID1 = value;
                    Notify("SelectedInternalID1");
                }
            }
        }

        public int SelectedCommodityID
        {
            get { return _selectedCommodityID; }
            set
            {
                if (_selectedCommodityID != value)
                {
                    _selectedCommodityID = value;
                    Notify("SelectedCommodityID");
                }
            }
        }

        public int SelectedBrokerID
        {
            get { return _selectedBrokerID; }
            set
            {
                if (_selectedBrokerID != value)
                {
                    _selectedBrokerID = value;
                    Notify("SelectedBrokerID");
                }
            }
        }

        public int SelectedInternalID
        {
            get { return _selectedInternalID; }
            set
            {
                if (_selectedInternalID != value)
                {
                    _selectedInternalID = value;
                    Notify("SelectedInternalID");
                }
            }
        }

        public List<ForwardPositionReportClass> SHFEList
        {
            get { return _shfeList; }
            set
            {
                if (_shfeList != value)
                {
                    _shfeList = value;
                    Notify("SHFEList");
                }
            }
        }

        public List<BusinessPartner> BrokerList
        {
            get { return _brokerList; }
            set
            {
                if (_brokerList != value)
                {
                    _brokerList = value;
                    Notify("BrokerList");
                }
            }
        }

        public List<BusinessPartner> InternalCustomerList
        {
            get { return _internalCustomerList; }
            set
            {
                if (_internalCustomerList != value)
                {
                    _internalCustomerList = value;
                    Notify("InternalCustomerList");
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

        #region Contruct
        public ForwardPositionReportVM()
        {
            LoadInternalCustomer();
            LoadBrokerList();
            LoadCommodity();
        }
        #endregion

        #region Method
        public void LoadInternalCustomer()
        {
            using (var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalCustomerList = busService.GetInternalCustomersByUser(CurrentUser.Id);
                InternalCustomerList.Insert(0, new BusinessPartner { Id = 0, Name = string.Empty });
            }
        }

        public void LoadBrokerList()
        {
            using (var busService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                BrokerList = busService.GetBusinessPartnersByType(BusinessPartnerType.Broker);
                BrokerList.Insert(0, new BusinessPartner { Id = 0, Name = string.Empty });
            }
        }

        private void LoadCommodity()
        {
            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commService.GetCommoditiesByUser(CurrentUser.Id);
            }
            CommodityList.Insert(0, new Commodity { Id = 0, Name = string.Empty });
        }

        public void GetLMELine(ZedGraphControl zedGraphControl, int commodityID, int internalCustomerID, int brokerID)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.IsVisible = true;
            myPane.XAxis.IsVisible = true;
            myPane.YAxis.IsVisible = true;
            myPane.YAxis.Title.Text = "手数";
            myPane.XAxis.Title.Text = "到期日";
            myPane.XAxis.Title.FontSpec.Size = 15.0F;
            myPane.YAxis.Title.FontSpec.Size = 15.0F;
            myPane.Title.Text = "LME远期头寸分布";

            LMEList = new List<LMEExposureDetailLine>();
            var lineList = new List<LMEExposureDetailLine>();
            using (var lmePositionService = SvcClientManager.GetSvcClient<LMEPositionServiceClient>(SvcType.LMEPositionSvc))
            {
                List<LMEExposureDetailLine> lmeList = lmePositionService.GetLMEExposureLines(SelectedCommodityID, SelectedInternalID, SelectedBrokerID);
                if (lmeList.Count > 0)
                {
                    var groups = lmeList.GroupBy(c => c.PromptDate);
                    foreach(var group in groups)
                    {
                        List<LMEExposureDetailLine> list = group.ToList();
                        if(list.Count > 0)
                        {
                            DateTime? promptDate = list[0].PromptDate;                            
                            decimal? qty = list.Sum(c => c.LotNumber);
                            decimal? price = list.Sum(c => c.Price * c.LotNumber) / qty;
                            var titleItem = new LMEExposureDetailLine
                            {
                                Title = "-1",
                                PromptDate = promptDate,
                                Price = price,
                                LotNumber = qty
                            };
                            LMEList.Add(titleItem);
                            lineList.Add(titleItem);

                            foreach(var item in list)
                            {
                                item.Title = "0";
                                LMEList.Add(item);
                            }
                        }
                    }
                }
            }

            var x = new string[lineList.Count];
            var y = new double[lineList.Count];

            if (lineList.Count > 0)
            {
                for (int i = 0; i < lineList.Count; i++)
                {
                    x[i] = lineList[i].PromptDate == null ? "" : lineList[i].PromptDate.Value.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
                    y[i] = lineList[i].LotNumber == null ? 0 : Convert.ToDouble(lineList[i].LotNumber.Value);
                }
            }

            myPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            LineItem myCurve = myPane.AddCurve("头寸手数", null, y, Color.Blue);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Display the Y axis grid lines
            myPane.XAxis.MajorTic.IsOpposite = true;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = x;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = true;

        }

        public void GetSHFELine(ZedGraphControl zedGraphControl, int commodityID, int internalCustomerID, int brokerID)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.IsVisible = true;
            myPane.XAxis.IsVisible = true;
            myPane.YAxis.IsVisible = true;
            myPane.YAxis.Title.Text = "手数";
            myPane.XAxis.Title.Text = "合约";
            myPane.XAxis.Title.FontSpec.Size = 15.0F;
            myPane.YAxis.Title.FontSpec.Size = 15.0F;
            myPane.Title.Text = "SHFE远期头寸分布";

            var aliasMonth = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };//合约
            DateTime nowDate = DateTime.Now;
            string commCode;
            bool isNextYear = false;
            int firstMonth = 0;
            if (nowDate.Day < 15)
            {
                if (nowDate.DayOfWeek == DayOfWeek.Saturday)//判断当前天是不是周六周日以及跟15号的大小关系
                {
                    if (nowDate.Day + 2 < 15)
                    {
                        firstMonth = nowDate.Month;
                    }
                    else
                    {
                        //判断下一个月是不是下一年的1月
                        if (nowDate.Month + 1 > 12)
                        {
                            isNextYear = true;
                            firstMonth = 1;
                        }
                        else
                        {
                            firstMonth = nowDate.Month + 1;
                        }
                    }
                }
            }
            else
            {
                //判断下一个月是不是下一年的1月
                if (nowDate.Month + 1 > 12)
                {
                    isNextYear = true;
                    firstMonth = 1;
                }
                else
                {
                    firstMonth = nowDate.Month + 1;
                }
            }

            using (var commService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                Commodity commodity = commService.GetById(commodityID);
                commCode = commodity.Code;
            }
            var x = new string[12];//横轴 合约
            var y = new double[12]; //纵轴 多头
            var y2 = new double[12]; // 纵轴 空头
            int year = Convert.ToInt32(nowDate.Year.ToString(CultureInfo.InvariantCulture).Substring(2, 2));
            for (int i = 0; i < 12; i++)
            {
                if (isNextYear)
                {
                    if (aliasMonth[i] < 10)
                    {
                        x[i] = commCode + (year + 1).ToString(CultureInfo.InvariantCulture) + "0" + aliasMonth[i].ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        x[i] = commCode + (year + 1).ToString(CultureInfo.InvariantCulture) + aliasMonth[i].ToString(CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    if (aliasMonth[i] < firstMonth)
                    {
                        if (aliasMonth[i] < 10)
                        {
                            x[i] = commCode + (year + 1).ToString(CultureInfo.InvariantCulture) + "0" + aliasMonth[i].ToString(CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            x[i] = commCode + (year + 1).ToString(CultureInfo.InvariantCulture) + aliasMonth[i].ToString(CultureInfo.InvariantCulture);
                        }
                    }
                    else
                    {
                        if (aliasMonth[i] < 10)
                        {
                            x[i] = commCode + year.ToString(CultureInfo.InvariantCulture) + "0" + aliasMonth[i].ToString(CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            x[i] = commCode + year.ToString(CultureInfo.InvariantCulture) + aliasMonth[i].ToString(CultureInfo.InvariantCulture);
                        }
                    }
                }
            }

            using (var shfePositionService = SvcClientManager.GetSvcClient<SHFEPositionServiceClient>(SvcType.SHFEPositionSvc))
            {
                List<ForwardPositionReportClass> list = shfePositionService.GetData(internalCustomerID, brokerID, commodityID, CurrentUser.Id);
                SHFEList = new List<ForwardPositionReportClass>();
                for (int i = 0; i < x.Length; i++)
                {
                    if (list.Select(c => c.Alias).Contains(x[i]))
                    {
                        List<ForwardPositionReportClass> listPosition = list.Where(c => c.Alias == x[i]).ToList();
                        SHFEList.AddRange(listPosition);
                        y[i] = listPosition.Where(c => c.PositionDerection == (int)PositionDirection.Long).Sum(c => c.Qty == null ? 0 : Convert.ToDouble(c.Qty.Value));
                        y2[i] = listPosition.Where(c => c.PositionDerection == (int)PositionDirection.Short).Sum(c => c.Qty == null ? 0 : Convert.ToDouble(c.Qty.Value));
                    }
                    else
                    {
                        y[i] = 0;
                        y2[i] = 0;
                    }
                }
            }

            myPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            // Generate a red curve with "Curve 1" in the legend
            LineItem myCurve = myPane.AddCurve("多头", null, y, Color.Red);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            myCurve = myPane.AddCurve("空头", null, y2, Color.Blue);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Display the Y axis grid lines
            myPane.XAxis.MajorTic.IsOpposite = true;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = x;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = true;

        }

        public bool Validate1()
        {
            if (SelectedCommodityID == 0)
            {
                throw new Exception("金属不能为空");
            }

            return true;
        }

        public bool Validate2()
        {
            if (SelectedCommodityID1 == 0)
            {
                throw new Exception("金属不能为空");
            }

            return true;
        }
        #endregion
    }
}
