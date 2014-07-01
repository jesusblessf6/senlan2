using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICollection = System.Collections.ICollection;
using System.Collections;
using ZedGraph;
using DBEntity;
using Utility.ServiceManagement;
using Client.InventoryServiceReference;
using Client.Base;
using System.Drawing;
using Client.BusinessPartnerServiceReference;
using DBEntity.EnumEntity;
using System.Data;

namespace Client.ViewModel.Physical.InventoryReportChart
{
    public class InventoryReprotChartVM : BaseVM
    {
        #region Member
        private int _InternalCustomerID;
        public List<BusinessPartner> _InternalCustomerList;
        #endregion
        #region Property
        public List<BusinessPartner> InternalCustomerList
        {
            get { return _InternalCustomerList; }
            set
            {
                if (_InternalCustomerList != value)
                {
                    _InternalCustomerList = value;
                    Notify("InternalCustomerList");
                }
            }
        }

        public int InternalCustomerID
        {
            get { return _InternalCustomerID; }
            set
            {
                if (_InternalCustomerID != value)
                {
                    _InternalCustomerID = value;
                    Notify("InternalCustomerID");
                }
            }
        }
        #endregion

        public InventoryReprotChartVM()
        {
            loadInternalCustomer();
        }

        private void loadInternalCustomer()
        {
            using (var bpartnerService = SvcClientManager.GetSvcClient<BusinessPartnerServiceClient>(SvcType.BusinessPartnerSvc))
            {
                int typeID = (int)BusinessPartnerType.InternalCustomer;
                string str = "it.CustomerType = @p1";
                List<object> parameters = new List<object>();
                parameters.Add(typeID);
                InternalCustomerList = bpartnerService.Query(str, parameters);
                if (InternalCustomerList.Count > 0)
                {
                    InternalCustomerID = InternalCustomerList[0].Id;
                }
            }
        }




        public void SortedOverlayBar(GraphPane myPane, ZedGraphControl zedGraphControl)
        {
            myPane = zedGraphControl.GraphPane;
            myPane.YAxis.Title.Text = "数量";
            myPane.XAxis.Title.Text = "金属";
            myPane.XAxis.Title.FontSpec.Size = 15.0F;
            myPane.YAxis.Title.FontSpec.Size = 15.0F;
            myPane.Title.Text = "库存图表";
            List<Inventory> inventoryList = new List<Inventory>();//库存
            List<DeliveryLine> internalTDList = new List<DeliveryLine>();//内贸
            List<DeliveryLine> externalTDList = new List<DeliveryLine>();//外贸
            List<Commodity> commodityList = new List<Commodity>();
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
            List<Commodity> cList = new List<Commodity>();
            foreach(Commodity commodity in commodityList)
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

            string[] labels = new string[cList.Count];
            double[] y = new double[cList.Count];
            double[] y2 = new double[cList.Count];
            double[] y3 = new double[cList.Count];
            int num = 0;
            if (cList.Count > 0)
            {
                foreach (Commodity c in cList)
                {
                    labels[num] = c.Name;
                    List<Inventory> list = inventoryList.Where(a => a.CommodityId == c.Id).ToList();
                    List<DeliveryLine> list1 = internalTDList.Where(d => d.Delivery.Quota.CommodityId == c.Id).ToList();
                    List<DeliveryLine> list2 = externalTDList.Where(o => o.Delivery.Quota.CommodityId == o.Id).ToList();
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
                        y2[num] = Convert.ToDouble(list1.Sum(a => a.VerifiedWeight));
                    }
                    else
                    {
                        y2[num] = 0;
                    }
                    if (list2.Count > 0)
                    {
                        y3[num] = Convert.ToDouble(list2.Sum(a => a.VerifiedWeight));
                    }
                    else
                    {
                        y3[num] = 0;
                    }
                    num++;
                }
            }

            CurveItem myCurve = myPane.AddBar("仓库库存", null, y, Color.Red);

            // Generate a blue bar with "Curve 2" in the legend
            myCurve = myPane.AddBar("内贸提单", null, y2, Color.Blue);

            // Generate a green bar with "Curve 3" in the legend
            myCurve = myPane.AddBar("外贸提单", null, y3, Color.Green);

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis to the ordinal type

            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Scale.FontSpec.Size = 15.0F;

            //types = ChartType.Bar;

            //const float shift = 5;

            //for (int i = 0; i < y.Length; i++)
            //{
            //    // format the label string to have 1 decimal place
            //    string lab = y3[i].ToString("F1");
            //    // create the text item (assumes the x axis is ordinal or text)
            //    // for negative bars, the label appears just above the zero value
            //    TextObj text = new TextObj(lab, (float)(i + 1), (float)(y3[i] + y2[i] + y[i]) + shift);//y3[i] < 0 ? 0.0 : y3[i]
            //    // tell Zedgraph to use user scale units for locating the TextObj
            //    text.Location.CoordinateFrame = CoordType.AxisXYScale;
            //    // AlignH the left-center of the text to the specified point
            //    text.Location.AlignH = AlignH.Left;
            //    text.Location.AlignV = AlignV.Center;
            //    text.FontSpec.Border.IsVisible = false;
            //    text.FontSpec.Fill.IsVisible = false;
            //    // rotate the text 90 degrees
            //    text.FontSpec.Angle = 90;
            //    // add the TextObj to the list
            //    myPane.GraphObjList.Add(text);
            //}

            // Indicate that the bars are overlay type, which are drawn on top of eachother
            myPane.BarSettings.Type = BarType.Overlay;

            // Fill the axis background with a color gradientC:\Documents and Settings\champioj\Desktop\ZedGraph-4.9-CVS\demo\ZedGraph.Demo\StepChartDemo.cs
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);

            zedGraphControl.AxisChange();

            // Add one step to the max scale value to leave room for the labels
            //myPane.YAxis.Scale.Max += myPane.YAxis.Scale.MajorStep;
        }

        public DataTable getInventoryTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("金属");
            dt.Columns.Add("仓库库存");
            dt.Columns.Add("内贸提单");
            dt.Columns.Add("外贸提单");
            dt.Columns.Add("总计");
            List<Inventory> inventoryList = new List<Inventory>();//库存
            List<DeliveryLine> internalTDList = new List<DeliveryLine>();//内贸
            List<DeliveryLine> externalTDList = new List<DeliveryLine>();//外贸
            List<Commodity> commodityList = new List<Commodity>();
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
            List<Commodity> cList = new List<Commodity>();
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
            decimal? total = 0;
            foreach (Commodity commodity in cList)
            {
                DataRow dr = dt.NewRow();
                dr["金属"] = commodity.Name;
                decimal? inventoryQty = inventoryList.Where(c => c.CommodityId == commodity.Id).Sum(c => c.Quantity);
                decimal? internalQty = internalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity.Id).Sum(c => c.VerifiedWeight);
                decimal? externalQty = externalTDList.Where(c => c.Delivery.Quota.CommodityId == commodity.Id).Sum(c => c.VerifiedWeight);
                inventoryTotal += inventoryQty;
                internalTotal += internalQty;
                externalTotal += externalTotal;
                dr["仓库库存"] = inventoryQty;
                dr["内贸提单"] = internalQty;
                dr["外贸提单"] = externalQty;
                dr["总计"] = inventoryQty + internalQty + externalQty ;
                dt.Rows.Add(dr);
            }
            total = inventoryTotal + internalTotal + externalTotal;

            DataRow drTotal = dt.NewRow();
            drTotal["金属"] = "总计";
            drTotal["仓库库存"] = inventoryTotal;
            drTotal["内贸提单"] = internalTotal;
            drTotal["外贸提单"] = externalTotal;
            drTotal["总计"] = total;
            dt.Rows.Add(drTotal);

            return dt;
        }


    }
}
