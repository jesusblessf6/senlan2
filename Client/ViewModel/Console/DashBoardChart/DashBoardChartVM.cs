using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using Client.Base.BaseClientVM;
using Client.BusinessPartnerServiceReference;
using Client.CommodityServiceReference;
using Client.CurrencyServiceReference;
using Client.InventoryServiceReference;
using Client.Properties;
using Client.QuotaServiceReference;
using Client.View.Console.DashBoard;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.ServiceManagement;
using ZedGraph;

namespace Client.ViewModel.Console.DashBoardChart
{
    public class DashBoardChartVM : BaseVM
    {
        #region Member

        private int _commodityID;
        private List<Commodity> _commodityList;
        private DataTable _dt;
        private DateTime? _endDate;
        private int _internalCustomerID;
        private int _internalCustomerID2;
        private int _internalCustomerID3;
        private List<BusinessPartner> _internalCustomerList;
        private DateTime? _startDate;

        #endregion

        #region Property

        public DataTable DT
        {
            get { return _dt; }
            set
            {
                if (_dt != value)
                {
                    _dt = value;
                    Notify("DT");
                }
            }
        }

        public int InternalCustomerID3
        {
            get { return _internalCustomerID3; }
            set
            {
                if (_internalCustomerID3 != value)
                {
                    _internalCustomerID3 = value;
                    Notify("InternalCustomerID3");
                }
            }
        }

        public int InternalCustomerID2
        {
            get { return _internalCustomerID2; }
            set
            {
                if (_internalCustomerID2 != value)
                {
                    _internalCustomerID2 = value;
                    Notify("InternalCustomerID2");
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

        public int CommodityID
        {
            get { return _commodityID; }
            set
            {
                if (_commodityID != value)
                {
                    _commodityID = value;
                    Notify("CommodityID");
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

        #endregion

        public DashBoardChartVM()
        {
            LoadInternalCustomer();
            LoadCommodityList();
        }

        private void LoadInternalCustomer()
        {
            using (
                var bpartnerService =
                    SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                InternalCustomerList = bpartnerService.GetInternalCustomersByUser(CurrentUser.Id);
                if (InternalCustomerList.Count > 0)
                {
                    InternalCustomerID = InternalCustomerList[0].Id;
                    InternalCustomerID2 = InternalCustomerList[0].Id;
                    InternalCustomerID3 = InternalCustomerList[0].Id;
                }
            }
        }

        private void LoadCommodityList()
        {
            using (var commodityService = SvcClientManager.GetSvcClient<CommodityServiceClient>(SvcType.CommoditySvc))
            {
                CommodityList = commodityService.GetAll();
                if (CommodityList.Count > 0)
                {
                    if (CommodityID <= 0)
                    {
                        CommodityID = CommodityList[0].Id;
                    }
                }
            }
        }

        public bool SearchValidate()
        {
            if (StartDate == null)
            {
                throw new Exception(Resources.StartDateRequired);
            }

            if (EndDate == null)
            {
                throw new Exception(Resources.EndDateRequired);
            }

            if (StartDate > EndDate)
            {
                throw new Exception(Resources.DateLimitation);
            }

            return true;
        }

        #region 库存图表

        public void SortedOverlayBar(ZedGraphControl zedGraphControl)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.YAxis.Title.Text = Resources.Quantity;
            myPane.XAxis.Title.Text = Resources.Commodity;
            myPane.XAxis.Title.FontSpec.Size = 16.0F;
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 16.0F;
            myPane.YAxis.Title.FontSpec.IsBold = false;
            myPane.Title.Text = ResDashBoard.InventoryChart;
            List<Inventory> inventoryList; //库存
            List<DeliveryLine> internalTDList; //内贸
            List<DeliveryLine> externalTDList; //外贸
            var commodityList = new List<Commodity>();
            using (var inventoryService = SvcClientManager.GetSvcClient<InventoryServiceClient>(SvcType.InventorySvc))
            {
                inventoryList = inventoryService.GetInventoriesByInternalCustomer(CurrentUser.Id, InternalCustomerID);
                internalTDList = inventoryService.GetInternalTDList(null, InternalCustomerID, CurrentUser.Id);
                externalTDList = inventoryService.GetExternalTDList(null, InternalCustomerID, CurrentUser.Id);
            }
            if (inventoryList.Count > 0)
            {
                commodityList.AddRange(inventoryList.Select(c => c.Commodity).ToList());
            }
            if (internalTDList.Count > 0)
            {
                commodityList.AddRange(internalTDList.Select(c => c.Delivery.Quota.Commodity).ToList());
            }
            if (externalTDList.Count > 0)
            {
                commodityList.AddRange(externalTDList.Select(c => c.Delivery.Quota.Commodity).ToList());
            }
            var cList = new List<Commodity>();
            foreach (Commodity commodity in commodityList)
            {
                if (cList.Count > 0)
                {
                    if (!cList.Select(c => c.Id).Contains(commodity.Id))
                    {
                        cList.Add(commodity);
                    }
                }
                else
                {
                    cList.Add(commodity);
                }
            }

            var labels = new string[cList.Count];
            var y = new double[cList.Count];
            var y2 = new double[cList.Count];
            var y3 = new double[cList.Count];
            int num = 0;
            if (cList.Count > 0)
            {
                foreach (Commodity c in cList)
                {
                    labels[num] = c.Name;
                    List<Inventory> list = inventoryList.Where(a => a.CommodityId == c.Id).ToList();
                    List<DeliveryLine> list1 = internalTDList.Where(d => d.Delivery.Quota.CommodityId == c.Id).ToList();
                    List<DeliveryLine> list2 = externalTDList.Where(o => o.Delivery.Quota.CommodityId == c.Id).ToList();
                    if (list.Count > 0)
                    {
                        y[num] = Convert.ToDouble(list.Sum(a => a.Quantity));
                    }
                    else
                    {
                        y[num] = 0;
                    }
                    if (list1.Count > 0)
                    {
                        decimal? warehouseInQty = list1.Sum(a => a.WarehouseInLines.Sum(o => o.VerifiedQuantity));
                        decimal? allQty = list1.Sum(a => a.VerifiedWeight);
                        y2[num] = Convert.ToDouble(allQty - warehouseInQty);
                    }
                    else
                    {
                        y2[num] = 0;
                    }
                    if (list2.Count > 0)
                    {
                        decimal? warehouseInQty = list2.Sum(a => a.WarehouseInLines.Sum(o => o.VerifiedQuantity));
                        decimal? allQty = list2.Sum(a => a.NetWeight);
                        y3[num] = Convert.ToDouble(allQty - warehouseInQty);
                    }
                    else
                    {
                        y3[num] = 0;
                    }
                    num++;
                }
            }

            myPane.AddBar(ResDashBoard.WarehouseInventory, null, y, Color.Red);

            // Generate a blue bar with "Curve 2" in the legend
            myPane.AddBar(Resources.DomesticBL, null, y2, Color.Blue);

            // Generate a green bar with "Curve 3" in the legend
            myPane.AddBar(Resources.ForeignDelivery, null, y3, Color.Green);

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            // Set the XAxis to the ordinal type

            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Scale.FontSpec.Size = 16.0F;

            // Indicate that the bars are Stack type, which are drawn on top of eachother
            myPane.BarSettings.Type = BarType.Stack;

            // Fill the axis background with a color gradientC:\Documents and Settings\champioj\Desktop\ZedGraph-4.9-CVS\demo\ZedGraph.Demo\StepChartDemo.cs
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);

            zedGraphControl.AxisChange();
        }

        public DataTable GetInventoryTable()
        {
            var dt = new DataTable();
            dt.Columns.Add(Resources.Commodity);
            dt.Columns.Add(ResDashBoard.WarehouseInventory);
            dt.Columns.Add(Resources.DomesticBL);
            dt.Columns.Add(Resources.ForeignDelivery);
            dt.Columns.Add(Resources.Summary);
            List<Inventory> inventoryList; //库存
            List<DeliveryLine> internalTDList; //内贸
            List<DeliveryLine> externalTDList; //外贸
            var commodityList = new List<Commodity>();
            using (var inventoryService = SvcClientManager.GetSvcClient<InventoryServiceClient>(SvcType.InventorySvc))
            {
                inventoryList = inventoryService.GetInventoriesByInternalCustomer(CurrentUser.Id, InternalCustomerID);
                internalTDList = inventoryService.GetInternalTDList(null, InternalCustomerID, CurrentUser.Id);
                externalTDList = inventoryService.GetExternalTDList(null, InternalCustomerID, CurrentUser.Id);
            }
            if (inventoryList.Count > 0)
            {
                commodityList.AddRange(inventoryList.Select(c => c.Commodity).ToList());
            }
            if (internalTDList.Count > 0)
            {
                commodityList.AddRange(internalTDList.Select(c => c.Delivery.Quota.Commodity).ToList());
            }
            if (externalTDList.Count > 0)
            {
                commodityList.AddRange(externalTDList.Select(c => c.Delivery.Quota.Commodity).ToList());
            }
            var cList = new List<Commodity>();
            foreach (Commodity commodity in commodityList)
            {
                if (cList.Count > 0)
                {
                    if (!cList.Select(c => c.Id).Contains(commodity.Id))
                    {
                        cList.Add(commodity);
                    }
                }
                else
                {
                    cList.Add(commodity);
                }
            }

            decimal? inventoryTotal = 0;
            decimal? internalTotal = 0;
            decimal? externalTotal = 0;
            foreach (Commodity commodity in cList)
            {
                DataRow dr = dt.NewRow();
                dr[Resources.Commodity] = commodity.Name;
                Commodity commodity1 = commodity;
                decimal? inventoryQty = inventoryList.Where(c => c.CommodityId == commodity1.Id).Sum(c => c.Quantity);
                //decimal? warehouseInQty =
                //    internalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity1.Id).Sum(
                //        a => a.WarehouseInLines.Sum(o => o.VerifiedQuantity));
                //decimal? allQty =
                //    internalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity1.Id).Sum(a => a.VerifiedWeight);
                //decimal? internalQty = allQty - warehouseInQty;
                //decimal? warehouseInQty1 =
                //    externalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity1.Id).Sum(
                //        a => a.WarehouseInLines.Sum(o => o.VerifiedQuantity));
                //decimal? allQty1 =
                //    externalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity1.Id).Sum(a => a.NetWeight);

                //decimal? externalQty = allQty1 - warehouseInQty1;
                decimal? internalQty = internalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity1.Id).Sum(a => a.OnlyVerfiedQty);
                decimal? externalQty = externalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity1.Id).Sum(a => a.OnlyQty);
                inventoryTotal += inventoryQty;
                internalTotal += internalQty;
                externalTotal += externalQty;
                dr[ResDashBoard.WarehouseInventory] = Math.Round(inventoryQty == null ? 0 : inventoryQty.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                dr[Resources.DomesticBL] = Math.Round(internalQty == null ? 0 : internalQty.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                dr[Resources.ForeignDelivery] = Math.Round(externalQty == null ? 0 : externalQty.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                decimal? all = inventoryQty + internalQty + externalQty;
                dr[Resources.Summary] = Math.Round(all == null ? 0 : all.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
                dt.Rows.Add(dr);
            }
            decimal? total = inventoryTotal + internalTotal + externalTotal;

            DataRow drTotal = dt.NewRow();
            drTotal[Resources.Commodity] = Resources.Summary;
            drTotal[ResDashBoard.WarehouseInventory] = Math.Round(inventoryTotal == null ? 0 : inventoryTotal.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
            drTotal[Resources.DomesticBL] = Math.Round(internalTotal == null ? 0 : internalTotal.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
            drTotal[Resources.ForeignDelivery] = Math.Round(externalTotal == null ? 0 : externalTotal.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
            drTotal[Resources.Summary] = Math.Round(total == null ? 0 : total.Value, RoundRules.QUANTITY, MidpointRounding.AwayFromZero);
            dt.Rows.Add(drTotal);

            return dt;
        }

        #endregion

        #region 现货销售额和采购额

        public void GetAmount(ZedGraphControl zedGraphControl, DateTime? startDate, DateTime? endDate,
                              int internalCustomerID)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.Text = ResDashBoard.PhysicalAmount;
            myPane.XAxis.Title.Text = Resources.Commodity;
            myPane.YAxis.Title.Text = Resources.Amount;
            myPane.XAxis.Title.FontSpec.Size = 16.0F;
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 16.0F;
            myPane.YAxis.Title.FontSpec.IsBold = false;

            var dt = new DataTable();
            dt.Columns.Add(ResDashBoard.SPAmount);

            var commodityList = new List<Commodity>();
            List<Quota> quotaList;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quotaList = quotaService.GetPurchaseAmount(startDate, endDate, internalCustomerID);
            }

            List<int?> currencyIDList = quotaList.Select(c => c.PricingCurrencyId).Distinct().ToList();
            foreach (Quota quota in quotaList)
            {
                if (commodityList.Count > 0)
                {
                    if (!commodityList.Select(c => c.Id).Contains(quota.CommodityId ?? 0))
                    {
                        commodityList.Add(quota.Commodity);
                    }
                }
                else
                {
                    commodityList.Add(quota.Commodity);
                }
            }

            var x = new string[commodityList.Count];
            int num = 0;
            foreach (Commodity c in commodityList)
            {
                dt.Columns.Add(c.Name);
                x[num] = c.Name;
                num++;
            }
            DataRow dr3 = dt.NewRow();
            DataRow dr4 = dt.NewRow();
            dr3[ResDashBoard.SPAmount] = Resources.PurchaseQty;
            dr4[ResDashBoard.SPAmount] = Resources.SalesQty;
            foreach (var currencyID in currencyIDList)
            {
                DataRow dr = dt.NewRow();
                DataRow dr2 = dt.NewRow();
                int i = 0;
                var yPurchase = new double[commodityList.Count]; //采购额
                var ySale = new double[commodityList.Count]; //销售额
                using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                {
                    Currency currency = currencyService.GetById((int) currencyID);
                    dr[ResDashBoard.SPAmount] = ResDashBoard.PurchaseAmount + "（" + currency.Name + "）";
                    dr2[ResDashBoard.SPAmount] = ResDashBoard.SalesAmount + "（" + currency.Name + "）";
                    foreach (Commodity c in commodityList)
                    {
                        if (quotaList.Count > 0)
                        {
                            List<Quota> listByCommodity =
                                quotaList.Where(o => o.CommodityId == c.Id && o.PricingCurrencyId == currency.Id).ToList();
                            List<Quota> listPID = listByCommodity.Where(o => o.Contract.ContractType == (int)ContractType.Purchase).Select(a => a).ToList();
                            List<Quota> listSID = listByCommodity.Where(o => o.Contract.ContractType == (int)ContractType.Sales).Select(a => a).ToList();
                            decimal amountPurchase = 0;
                            decimal amountSale = 0;
                            using (
                                var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                            {
                                amountPurchase +=
                                   quotaService.GetQuotaAmountsByQuota(listPID, CurrentUser.Id);
                                amountSale +=
                                    quotaService.GetQuotaAmountsByQuota(listSID, CurrentUser.Id);
                            }
                            yPurchase[i] = Convert.ToDouble(amountPurchase);
                            ySale[i] = Convert.ToDouble(amountSale);
                            dr[c.Name] = string.Format("{0:#,##0.00}", amountPurchase);
                            dr2[c.Name] = string.Format("{0:#,##0.00}", amountSale);
                        }
                        i++;
                    }


                    var randomNumFirst = new Random((int) DateTime.Now.Ticks);

                    Thread.Sleep(randomNumFirst.Next(50));
                    var randomNumSencond = new Random((int) DateTime.Now.Ticks);


                    int intRed = randomNumFirst.Next(256);
                    int intGreen = randomNumSencond.Next(256);
                    int intBlue = (intRed + intGreen > 400) ? 0 : 400 - intRed - intGreen;
                    intBlue = (intBlue > 255) ? 255 : intBlue;


                    myPane.AddBar(ResDashBoard.PurchaseAmount + "（" + currency.Name + "）", null, yPurchase,
                                  Color.FromArgb(intRed, intGreen, intBlue));

                    var randomNumFirst1 = new Random((int) DateTime.Now.Ticks);

                    Thread.Sleep(randomNumFirst1.Next(50));
                    var randomNumSencond1 = new Random((int) DateTime.Now.Ticks);


                    int intRed1 = randomNumFirst1.Next(256);
                    int intGreen1 = randomNumSencond1.Next(256);
                    int intBlue1 = (intRed1 + intGreen1 > 400) ? 0 : 400 - intRed1 - intGreen1;
                    intBlue1 = (intBlue1 > 255) ? 255 : intBlue1;
                    myPane.AddBar(ResDashBoard.SalesAmount + "（" + currency.Name + "）", null, ySale,
                                  Color.FromArgb(intRed1, intGreen1, intBlue1));
                }
                dt.Rows.Add(dr);
                dt.Rows.Add(dr2);
            }

            #region 计算采购销售数量

            foreach (Commodity c in commodityList)
            {
                Commodity c1 = c;
                decimal quantityP = 0;
                decimal quantityS = 0;
                if (quotaList.Count > 0)
                {
                    quantityP += quotaList.Where(o => o.Contract.ContractType == (int)ContractType.Purchase && o.CommodityId == c1.Id).Sum(
                        o => o.VerifiedQuantity);

                    quantityS += quotaList.Where(o => o.Contract.ContractType == (int)ContractType.Sales && o.CommodityId == c1.Id).Sum(
                        o => o.VerifiedQuantity);
                }
                dr3[c1.Name] = string.Format("{0:#,##0.0000}", quantityP);
                dr4[c1.Name] = string.Format("{0:#,##0.0000}", quantityS);
            }

            #endregion

            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);

            DT = dt;
            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            myPane.XAxis.Scale.TextLabels = x;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);

            zedGraphControl.AxisChange();
        }

        public void GetAmountNew(ZedGraphControl zedGraphControl, DateTime? startDate, DateTime? endDate, int internalCustomerID)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.Text = ResDashBoard.PhysicalAmount;
            myPane.XAxis.Title.Text = Resources.Commodity;
            myPane.YAxis.Title.Text = Resources.Amount;
            myPane.XAxis.Title.FontSpec.Size = 16.0F;
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 16.0F;
            myPane.YAxis.Title.FontSpec.IsBold = false;

            var currencyList=new List<Currency>();
            var commodityList=new List<Commodity>();
            var totals = new List<DashBoardTotalClass>();

            using (var quotaService=SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                List<DashBoardClass> list = quotaService.GetDashBoard(startDate, endDate, internalCustomerID,
                    CurrentUser.Id, ref currencyList, ref commodityList, ref totals);

                var dt = new DataTable();
                dt.Columns.Add(ResDashBoard.SPAmount);

                var x = new string[commodityList.Count];
                int num = 0;
                foreach (Commodity c in commodityList)
                {
                    dt.Columns.Add(c.Name);
                    x[num] = c.Name;
                    num++;
                }
                DataRow dr3 = dt.NewRow();
                DataRow dr4 = dt.NewRow();
                dr3[ResDashBoard.SPAmount] = Resources.PurchaseQty;
                dr4[ResDashBoard.SPAmount] = Resources.SalesQty;

                foreach (var currency in currencyList)
                {
                    DataRow dr = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    int i = 0;
                    var yPurchase = new double[commodityList.Count]; //采购额
                    var ySale = new double[commodityList.Count]; //销售额

                    dr[ResDashBoard.SPAmount] = ResDashBoard.PurchaseAmount + "（" + currency.Name + "）";
                    dr2[ResDashBoard.SPAmount] = ResDashBoard.SalesAmount + "（" + currency.Name + "）";

                    foreach (Commodity c in commodityList)
                    {
                        DashBoardClass dashBoardClass = list.FirstOrDefault(o => o.CurrencyId == currency.Id && o.CommodityId == c.Id);
                        double amountPurchase = 0;
                        double amountSale = 0;

                        if (dashBoardClass != null)
                        {
                            amountPurchase =Convert.ToDouble(dashBoardClass.PurchaseAmount);
                            amountSale = Convert.ToDouble(dashBoardClass.SaleAmount);
                        }

                        yPurchase[i] = amountPurchase;
                        ySale[i] = amountSale;
                        dr[c.Name] = string.Format("{0:#,##0.00}", amountPurchase);
                        dr2[c.Name] = string.Format("{0:#,##0.00}", amountSale);
                        i++;
                    }

                    var randomNumFirst = new Random((int)DateTime.Now.Ticks);

                    Thread.Sleep(randomNumFirst.Next(50));
                    var randomNumSencond = new Random((int)DateTime.Now.Ticks);


                    int intRed = randomNumFirst.Next(256);
                    int intGreen = randomNumSencond.Next(256);
                    int intBlue = (intRed + intGreen > 400) ? 0 : 400 - intRed - intGreen;
                    intBlue = (intBlue > 255) ? 255 : intBlue;


                    myPane.AddBar(ResDashBoard.PurchaseAmount + "（" + currency.Name + "）", null, yPurchase,
                                  Color.FromArgb(intRed, intGreen, intBlue));

                    var randomNumFirst1 = new Random((int)DateTime.Now.Ticks);

                    Thread.Sleep(randomNumFirst1.Next(50));
                    var randomNumSencond1 = new Random((int)DateTime.Now.Ticks);


                    int intRed1 = randomNumFirst1.Next(256);
                    int intGreen1 = randomNumSencond1.Next(256);
                    int intBlue1 = (intRed1 + intGreen1 > 400) ? 0 : 400 - intRed1 - intGreen1;
                    intBlue1 = (intBlue1 > 255) ? 255 : intBlue1;
                    myPane.AddBar(ResDashBoard.SalesAmount + "（" + currency.Name + "）", null, ySale,
                                  Color.FromArgb(intRed1, intGreen1, intBlue1));

                    dt.Rows.Add(dr);
                    dt.Rows.Add(dr2);
                }
                foreach (DashBoardTotalClass t in totals)
                {
                    dr3[t.CommodityName] = string.Format("{0:#,##0.0000}", t.PurchaseQty);
                    dr4[t.CommodityName] = string.Format("{0:#,##0.0000}", t.SaleQty);
                }
                dt.Rows.Add(dr3);
                dt.Rows.Add(dr4);

                DT = dt;
                myPane.XAxis.MajorTic.IsBetweenLabels = true;
                myPane.XAxis.Scale.TextLabels = x;

                // Set the XAxis to Text type
                myPane.XAxis.Type = AxisType.Text;

                // Fill the axis background with a color gradient
                myPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0F);

                zedGraphControl.AxisChange();
            }
        }

        public DataTable GetAmountTable(DateTime? startDate, DateTime? endDate, int internalCustomerID)
        {
            var dt = new DataTable();
            dt.Columns.Add(ResDashBoard.SPAmount);

            var commodityList = new List<Commodity>();
            List<Quota> quotaList;
            using (var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
            {
                quotaList = quotaService.GetPurchaseAmount(startDate, endDate, internalCustomerID);
            }

            foreach (Quota quota in quotaList)
            {
                if (commodityList.Count > 0)
                {
                    if (!commodityList.Select(c => c.Id).Contains(quota.CommodityId ?? 0))
                    {
                        commodityList.Add(quota.Commodity);
                    }
                }
                else
                {
                    commodityList.Add(quota.Commodity);
                }
            }
            List<int?> currencyIDList = quotaList.Select(c => c.PricingCurrencyId).Distinct().ToList();

            foreach (Commodity c in commodityList)
            {
                dt.Columns.Add(c.Name);
            }
            DataRow dr3 = dt.NewRow();
            dr3[ResDashBoard.SPAmount] = Resources.Quantity;
            foreach (var currencyID in currencyIDList)
            {
                DataRow dr = dt.NewRow();
                DataRow dr2 = dt.NewRow();
                using (var currencyService = SvcClientManager.GetSvcClient<CurrencyServiceClient>(SvcType.CurrencySvc))
                {
                    var commodityDictionary = new Dictionary<string, decimal>();
                    Currency currency = currencyService.GetById((int) currencyID);
                    dr[ResDashBoard.SPAmount] = ResDashBoard.PurchaseAmount + "（" + currency.Name + "）";
                    dr2[ResDashBoard.SPAmount] = ResDashBoard.SalesAmount + "（" + currency.Name + "）";
                    foreach (Commodity c in commodityList)
                    {
                        if (quotaList.Count > 0)
                        {
                            List<Quota> listByCommodity =
                                quotaList.Where(o => o.CommodityId == c.Id && o.PricingCurrencyId == currency.Id).ToList
                                    ();
                            List<Quota> listP =
                                listByCommodity.Where(o => o.Contract.ContractType == (int) ContractType.Purchase).
                                    ToList();
                            List<Quota> listS =
                                listByCommodity.Where(o => o.Contract.ContractType == (int) ContractType.Sales).ToList();
                            decimal amountPurchase = 0;
                            decimal amountSale = 0;
                            decimal qty = 0;
                            decimal avgPrice = 0;
                            decimal quantity = 0;
                            using (
                                var quotaService = SvcClientManager.GetSvcClient<QuotaServiceClient>(SvcType.QuotaSvc))
                            {
                                amountPurchase +=
                                    listP.Sum(
                                        quota =>
                                        quotaService.GetQuotaAmount(quota, ref commodityDictionary, ref qty,ref avgPrice,
                                                                    CurrentUser.Id, true, false,false));
                                amountSale +=
                                    listS.Sum(
                                        quota =>
                                        quotaService.GetQuotaAmount(quota, ref commodityDictionary, ref qty, ref avgPrice,
                                                                    CurrentUser.Id, true, false,false));
                                quantity +=listByCommodity.Sum(quota => quota.VerifiedQuantity);
                            }
                            dr[c.Name] = string.Format("{0:#,##0.00}", amountPurchase);
                            dr2[c.Name] = string.Format("{0:#,##0.00}", amountSale);
                            dr3[c.Name] = string.Format("{0:#,##0.0000}", quantity);
                        }
                    }
                }
                dt.Rows.Add(dr);
                dt.Rows.Add(dr2);
            }
            dt.Rows.Add(dr3);

            return dt;
        }

        #endregion
    }
}