using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Client.Base.BaseClientVM;
using Client.SystemParameterServiceReference;
using Client.WarehouseOutServiceReference;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Misc;
using Utility.ServiceManagement;
using Client.DeliveryServiceReference;

namespace Client.ViewModel.PrintTemplate.DomesticWarehouseOutTemplate
{
    public class PrintWarehouseOutTemplateVM : BaseVM
    {
        #region Member

        private List<WarehouseOutHeader> _headerList;
        private List<WarehouseLineList> _lineList;
        private string _pathName;

        #endregion

        #region Property

        public string PathName
        {
            get { return _pathName; }
            set
            {
                if (_pathName != value)
                {
                    _pathName = value;
                    Notify("PathName");
                }
            }
        }

        public List<WarehouseOutHeader> HeaderList
        {
            get { return _headerList; }
            set
            {
                if (_headerList != value)
                {
                    _headerList = value;
                    Notify("HeaderList");
                }
            }
        }

        public List<WarehouseLineList> LineList
        {
            get { return _lineList; }
            set
            {
                if (_lineList != value)
                {
                    _lineList = value;
                    Notify("LineList");
                }
            }
        }

        #endregion

        #region Contructor

        public PrintWarehouseOutTemplateVM(string printName, int warehouseOutID)
        {
            HeaderList = new List<WarehouseOutHeader>();
            LineList = new List<WarehouseLineList>();
            GetPath(warehouseOutID);

            if (printName == "出库")
            {
                GetValue(warehouseOutID);
            }
            else if (printName == "发货单")
            {
                GetDeliveryValue(warehouseOutID);
            }
        }

        #endregion

        #region Method

        public void GetPath(int warehouseOutID)
        {
            using (
                var systemParameterService =
                    SvcClientManager.GetSvcClient<SystemParameterServiceClient>(SvcType.SystemParameterSvc))
            {
                SystemParameter systemParameter = systemParameterService.GetAll()[0];

                if (systemParameter != null)
                {
                    string name =
                        EnumHelper.GetDescriptionByCulture(PrintTemplateType.DomesticWarehouseOutTemplate);
                    PathName = @"PrintTemplate\" + name + "\\" +
                               systemParameter.DomesticWarehouseOutTemplatePath;
                }
            }
        }

        public void GetValue(int warehouseOutID)
        {
            using (
                var warehouseOutService =
                    SvcClientManager.GetSvcClient<WarehouseOutServiceClient>(SvcType.WarehouseOutSvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> { warehouseOutID };

                List<WarehouseOut> list = warehouseOutService.Select(str, parameters,
                                                                     new List<string>
                                                                         {
                                                                             "WarehouseOutLines",
                                                                             "Quota",
                                                                             "Quota.Contract",
                                                                             "Quota.Commodity",
                                                                             "Quota.Contract.BusinessPartner",
                                                                             "Quota.Contract.InternalCustomer",
                                                                             "Warehouse",
                                                                             "WarehouseOutLines.WarehouseInLine",
                                                                             "WarehouseOutLines.WarehouseOutDeliveryPersons",
                                                                             "Quota.CommodityType",
                                                                             "WarehouseOutLines.Brand",
                                                                             "BusinessPartner"
                                                                         });

                if (list.Count > 0)
                {
                    WarehouseOut warehouseOut = list[0];
                    FilterDeleted(warehouseOut.WarehouseOutLines);
                    var header = new WarehouseOutHeader
                                     {
                                         Comment = warehouseOut.Comment,
                                         ContractNo = warehouseOut.WarehouseOutNo,
                                         InternalFax = warehouseOut.Quota.Contract.InternalCustomer.Fax,
                                         InternalName = warehouseOut.Quota.Contract.InternalCustomer.Name,
                                         InternalPhone = warehouseOut.Quota.Contract.InternalCustomer.ContactPhone,
                                         SignDate = warehouseOut.Quota.Contract.SignDate == null
                                                        ? ""
                                                        : string.Format("{0:d}",
                                                                        Convert.ToDateTime(
                                                                            warehouseOut.Quota.Contract.SignDate)),
                                         WarehouseAddress = warehouseOut.Warehouse.Address,
                                         WarehouseName = warehouseOut.Warehouse.Name,
                                         WarehousePhone = warehouseOut.Warehouse.Phone,
                                         DateForQW = warehouseOut.WarehouseOutDate == null
                                                    ? ""
                                                    : Convert.ToDateTime(warehouseOut.WarehouseOutDate).ToString(
                                                        "yyyy年M月d日",
                                                        DateTimeFormatInfo.InvariantInfo),
                                         Date = warehouseOut.WarehouseOutDate == null
                                                     ? ""
                                                     : Convert.ToDateTime(warehouseOut.WarehouseOutDate).ToString(
                                                         "yyyy.MM.dd",
                                                         DateTimeFormatInfo.InvariantInfo),
                                         BussinessPartnerName =
                                             warehouseOut.BusinessPartner == null
                                                 ? ""
                                                 : warehouseOut.BusinessPartner.Name
                                     };
                    if (header.InternalName == "全威（上海）有色金属有限公司")
                    {
                        PathName = @"PrintTemplate\\内贸出库单\\全威内贸出库单.rdlc";
                    }
                    if (warehouseOut.WarehouseOutLines.Count > 0)
                    {
                        var personList = new List<WarehouseOutDeliveryPerson>();
                        double allQtyTotal = 0;
                        int lineID = 0;
                        string persons = string.Empty;
                        foreach (WarehouseOutLine line in warehouseOut.WarehouseOutLines)
                        {
                            if (!line.IsDeleted)
                            {
                                if (lineID == 0)
                                {
                                    lineID = line.Id;
                                }

                                var lineList = new WarehouseLineList();

                                double qty = line.Quantity == null ? 0 : Convert.ToDouble(line.Quantity);
                                lineList.CommodityName = line.WarehouseOut.Quota.Commodity.Name;
                                lineList.CommodityTypeName = line.Brand == null ? "" : line.Brand.Name;
                                string convertQty =
                                    NumberChange.GetQuantityChange(qty.ToString(CultureInfo.InvariantCulture));
                                lineList.AllQty = qty.ToString(CultureInfo.InvariantCulture) + "（" + convertQty + "）";
                                lineList.LineNo = line.WarehouseInLine.PBNo;
                                lineList.Packing = line.PackingQuantity == null
                                                       ? ""
                                                       : Convert.ToDouble(line.PackingQuantity).ToString();
                                lineList.Unit = line.WarehouseOut.Quota.Commodity.SHFEUnit;
                                bool isPBClear = line.WarehouseInLine.IsPBCleared != null &&
                                                 (bool)line.WarehouseInLine.IsPBCleared;
                                if (isPBClear)
                                {
                                    lineList.VerifiedQuantity = line.VerifiedQuantity == null
                                                                    ? "0（清卡）"
                                                                    : Convert.ToDouble(line.VerifiedQuantity).ToString(
                                                                        CultureInfo.InvariantCulture) +
                                                                      "（清卡）";
                                }
                                else
                                {
                                    lineList.VerifiedQuantity = line.VerifiedQuantity == null
                                                                    ? "0"
                                                                    : Convert.ToDouble(line.VerifiedQuantity).ToString(
                                                                        CultureInfo.InvariantCulture);
                                }
                                allQtyTotal += qty;

                                if (line.WarehouseOutDeliveryPersons.Count > 0)
                                {
                                    List<WarehouseOutDeliveryPerson> deliveryPersonList =
                                           line.WarehouseOutDeliveryPersons.Where(person => !person.IsDeleted).ToList();
                                    personList.AddRange(deliveryPersonList);
                                }
                                LineList.Add(lineList);
                            }
                        }

                        int linecount = 0;
                        if (PathName == "PrintTemplate\\内贸出库单\\全威内贸出库单.rdlc")
                        {
                            linecount = 4;
                        }
                        else
                        {
                            linecount = 3;
                        }

                        if (LineList.Count < linecount)
                        {
                            if (LineList.Count > 0)
                            {
                                int count = LineList.Count;
                                for (int i = 0; i < linecount - count; i++)
                                {
                                    var line = new WarehouseLineList {Unit = LineList[0].Unit};
                                    LineList.Add(line);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < linecount; i++)
                                {
                                    LineList.Add(new WarehouseLineList());
                                }
                            }
                        }

                        if(personList.Count > 0)
                        {
                            WarehouseOutDeliveryPerson deliveryPerson = personList[0];
                            header.DeliveryPersonName = deliveryPerson.Name;
                            header.DeliveryPersonVehicleNo = deliveryPerson.VehicleNo;
                            if (!string.IsNullOrEmpty(deliveryPerson.IdentityCard))
                            {
                                header.IDCard1 = deliveryPerson.IdentityCard.Substring(0, 1);
                                header.IDCard2 = deliveryPerson.IdentityCard.Substring(1, 1);
                                header.IDCard3 = deliveryPerson.IdentityCard.Substring(2, 1);
                                header.IDCard4 = deliveryPerson.IdentityCard.Substring(3, 1);
                                header.IDCard5 = deliveryPerson.IdentityCard.Substring(4, 1);
                                header.IDCard6 = deliveryPerson.IdentityCard.Substring(5, 1);
                                header.IDCard7 = deliveryPerson.IdentityCard.Substring(6, 1);
                                header.IDCard8 = deliveryPerson.IdentityCard.Substring(7, 1);
                                header.IDCard9 = deliveryPerson.IdentityCard.Substring(8, 1);
                                header.IDCard10 = deliveryPerson.IdentityCard.Substring(9, 1);
                                header.IDCard11 = deliveryPerson.IdentityCard.Substring(10, 1);
                                header.IDCard12 = deliveryPerson.IdentityCard.Substring(11, 1);
                                header.IDCard13 = deliveryPerson.IdentityCard.Substring(12, 1);
                                header.IDCard14 = deliveryPerson.IdentityCard.Substring(13, 1);
                                header.IDCard15 = deliveryPerson.IdentityCard.Substring(14, 1);
                                if (deliveryPerson.IdentityCard.Length > 15)
                                {
                                    header.IDCard16 = deliveryPerson.IdentityCard.Substring(15, 1);
                                    header.IDCard17 = deliveryPerson.IdentityCard.Substring(16, 1);
                                    header.IDCard18 = deliveryPerson.IdentityCard.Substring(17, 1);
                                }
                            }

                            if (personList.Count > 1)
                            {
                                if (personList[1].Id != deliveryPerson.Id)
                                {
                                    header.Person1 = "   提货人姓名：" + personList[1].Name + "   身份证号：" +
                                       personList[1].IdentityCard + "   车辆编号：" + personList[1].VehicleNo;
                                }

                                if (personList.Count > 2)
                                {
                                    if (personList[2].Id != deliveryPerson.Id)
                                    {
                                        header.Person2 = "   提货人姓名：" + personList[2].Name + "   身份证号：" +
                                       personList[2].IdentityCard + "   车辆编号：" + personList[2].VehicleNo;
                                    }
                                }

                                if (personList.Count > 3)
                                {
                                    if (personList[3].Id != deliveryPerson.Id)
                                    {
                                        header.Person3 = "   提货人姓名：" + personList[3].Name + "   身份证号：" +
                                       personList[3].IdentityCard + "   车辆编号：" + personList[3].VehicleNo;
                                    }
                                }
                            }
                        }

                        persons += warehouseOut.Comment;
                        header.DeliveryPersons = persons;
                        string convertTotalQty =
                            NumberChange.GetQuantityChange(allQtyTotal.ToString(CultureInfo.InvariantCulture));
                        header.TotalAllQty = allQtyTotal.ToString(CultureInfo.InvariantCulture) + "（" + convertTotalQty +
                                             "）";
                        header.TotalQty = convertTotalQty;
                    }

                    HeaderList.Add(header);
                }
            }
        }

        public void GetDeliveryValue(int deliveryID)
        {
            using (
               var deliveryService =
                   SvcClientManager.GetSvcClient<DeliveryServiceClient>(SvcType.DeliverySvc))
            {
                const string str = "it.Id = @p1";
                var parameters = new List<object> {deliveryID};
                List<Delivery> deliverys = deliveryService.Select(str, parameters,
                                                                  new List<string>
                                                                      {
                                                                          "Quota.CommodityType",
                                                                          "Quota.Commodity",
                                                                          "Warehouse",
                                                                          "Quota.Contract",
                                                                          "Quota.Contract.BusinessPartner",
                                                                          "Quota.Contract.InternalCustomer",
                                                                          "DeliveryLines",
                                                                          "DeliveryLines.WarehouseOutDeliveryPersons",
                                                                          "DeliveryLines.Brand",
                                                                          "BusinessPartner"
                                                                      });
                if (deliverys.Count > 0)
                {
                    Delivery delivery = deliverys[0];
                    FilterDeleted(delivery.DeliveryLines);
                    var header = new WarehouseOutHeader
                    {
                        InternalName = delivery.Quota.Contract.InternalCustomer.Name,
                        InternalPhone = delivery.Quota.Contract.InternalCustomer.ContactPhone,
                        InternalFax = delivery.Quota.Contract.InternalCustomer.Fax,
                        BussinessPartnerName = delivery.BusinessPartner == null ? "" : delivery.BusinessPartner.Name,
                        //ContractNo = delivery.Quota.Contract.ContractNo,
                        ContractNo = delivery.DeliveryNo,
                        SignDate = delivery.Quota.Contract.SignDate == null
                                                            ? ""
                                                            : string.Format("{0:d}",
                                                                            Convert.ToDateTime(
                                                                                delivery.Quota.Contract.SignDate)),
                        WarehouseAddress = delivery.Warehouse.Address,
                        WarehouseName = delivery.Warehouse.Name,
                        WarehousePhone = delivery.Warehouse.Phone,
                        DateForQW = delivery.IssueDate == null
                                                        ? ""
                                                        : Convert.ToDateTime(delivery.IssueDate).ToString(
                                                            "yyyy年M月d日",
                                                            DateTimeFormatInfo.InvariantInfo),
                        Date = delivery.IssueDate == null ? ""  : Convert.ToDateTime(delivery.IssueDate).ToString("yyyy.MM.dd",DateTimeFormatInfo.InvariantInfo)

                    };
                    if (header.InternalName == "上海泰智有色金属有限公司")
                    {
                        header.TZTxt = "供货单位盖章处";
                    }
                    else
                    {
                        header.TZTxt = "发货单位盖章处";
                    }
                    if (delivery.DeliveryLines.Count > 0)
                    {
                        var personList = new List<WarehouseOutDeliveryPerson>();
                        double allQtyTotal = 0;

                        int lineID = 0;
                        string persons = string.Empty;
                        foreach (DeliveryLine line in delivery.DeliveryLines)
                        {
                            if (!line.IsDeleted)
                            {
                                if (lineID == 0)
                                {
                                    lineID = line.Id;
                                }
                                var lineList = new WarehouseLineList();

                                double qty = line.NetWeight == null ? 0 : Convert.ToDouble(line.NetWeight);
                                lineList.CommodityName = line.Delivery.Quota.Commodity.Name;
                                lineList.CommodityTypeName = line.Brand == null ? "" : line.Brand.Name;// line.Delivery.Quota.CommodityType.Name;
                                string convertQty =
                                    NumberChange.GetQuantityChange(qty.ToString(CultureInfo.InvariantCulture));
                                lineList.AllQty = qty.ToString(CultureInfo.InvariantCulture) + "（" + convertQty + "）";
                                lineList.LineNo = line.PBNo;
                                lineList.Packing = line.PackingQuantity == null
                                                       ? ""
                                                       : Convert.ToDouble(line.PackingQuantity).ToString();
                                lineList.Unit = line.Delivery.Quota.Commodity.SHFEUnit;

                                lineList.VerifiedQuantity = line.VerifiedWeight == null
                                                                ? "0"
                                                                : Convert.ToDouble(line.VerifiedWeight).ToString(
                                                                    CultureInfo.InvariantCulture);

                                allQtyTotal += qty;

                                if (line.WarehouseOutDeliveryPersons.Count > 0)
                                {
                                    List<WarehouseOutDeliveryPerson> deliveryPersonList =
                                           line.WarehouseOutDeliveryPersons.Where(person => !person.IsDeleted).ToList();
                                    personList.AddRange(deliveryPersonList);
                                }

                                LineList.Add(lineList);
                            }
                        }

                        int linecount = 0;
                        if (PathName == "PrintTemplate\\内贸出库单\\全威内贸出库单.rdlc")
                        {
                            linecount = 4;
                        }
                        else
                        {
                            linecount = 3;
                        }
                        if (header.InternalName == "上海泰智有色金属有限公司")
                        {
                            linecount = 4;
                        }

                        if (LineList.Count < linecount)
                        {
                            if (LineList.Count > 0)
                            {
                                int count = LineList.Count;
                                for (int i = 0; i < linecount - count; i++)
                                {
                                    var line = new WarehouseLineList {Unit = LineList[0].Unit};
                                    LineList.Add(line);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < linecount; i++)
                                {
                                    LineList.Add(new WarehouseLineList());
                                }
                            }
                        }

                        if (personList.Count > 0)
                        {
                            WarehouseOutDeliveryPerson deliveryPerson = personList[0];
                            header.DeliveryPersonName = deliveryPerson.Name;
                            header.DeliveryPersonVehicleNo = deliveryPerson.VehicleNo;
                            header.WarehousePhone = deliveryPerson.Tel;
                            if (!string.IsNullOrEmpty(deliveryPerson.IdentityCard))
                            {
                                header.IDCard1 = deliveryPerson.IdentityCard.Substring(0, 1);
                                header.IDCard2 = deliveryPerson.IdentityCard.Substring(1, 1);
                                header.IDCard3 = deliveryPerson.IdentityCard.Substring(2, 1);
                                header.IDCard4 = deliveryPerson.IdentityCard.Substring(3, 1);
                                header.IDCard5 = deliveryPerson.IdentityCard.Substring(4, 1);
                                header.IDCard6 = deliveryPerson.IdentityCard.Substring(5, 1);
                                header.IDCard7 = deliveryPerson.IdentityCard.Substring(6, 1);
                                header.IDCard8 = deliveryPerson.IdentityCard.Substring(7, 1);
                                header.IDCard9 = deliveryPerson.IdentityCard.Substring(8, 1);
                                header.IDCard10 = deliveryPerson.IdentityCard.Substring(9, 1);
                                header.IDCard11 = deliveryPerson.IdentityCard.Substring(10, 1);
                                header.IDCard12 = deliveryPerson.IdentityCard.Substring(11, 1);
                                header.IDCard13 = deliveryPerson.IdentityCard.Substring(12, 1);
                                header.IDCard14 = deliveryPerson.IdentityCard.Substring(13, 1);
                                header.IDCard15 = deliveryPerson.IdentityCard.Substring(14, 1);
                                if (deliveryPerson.IdentityCard.Length > 15)
                                {
                                    header.IDCard16 = deliveryPerson.IdentityCard.Substring(15, 1);
                                    header.IDCard17 = deliveryPerson.IdentityCard.Substring(16, 1);
                                    header.IDCard18 = deliveryPerson.IdentityCard.Substring(17, 1);
                                }
                            }

                            if (personList.Count > 1)
                            {
                                if (personList[1].Id != deliveryPerson.Id)
                                {
                                    header.Person1 = "   提货人姓名：" + personList[1].Name + "   身份证号：" +
                                       personList[1].IdentityCard + "   车辆编号：" + personList[1].VehicleNo + 
                                       "   联系电话：" + personList[1].Tel;
                                }

                                if(personList.Count > 2)
                                {
                                    if(personList[2].Id != deliveryPerson.Id)
                                    {
                                        header.Person2 = "   提货人姓名：" + personList[2].Name + "   身份证号：" +
                                       personList[2].IdentityCard + "   车辆编号：" + personList[2].VehicleNo +
                                       "   联系电话：" + personList[2].Tel;
                                    }
                                }

                                if(personList.Count > 3)
                                {
                                    if(personList[3].Id != deliveryPerson.Id)
                                    {
                                        header.Person3 = "   提货人姓名：" + personList[3].Name + "   身份证号：" +
                                       personList[3].IdentityCard + "   车辆编号：" + personList[3].VehicleNo +
                                       "   联系电话：" + personList[3].Tel;
                                    }
                                }
                            }
                        }

                        persons += delivery.Comment;

                        header.DeliveryPersons = persons;
                        string convertTotalQty =
                            NumberChange.GetQuantityChange(allQtyTotal.ToString(CultureInfo.InvariantCulture));
                        header.TotalAllQty = allQtyTotal.ToString(CultureInfo.InvariantCulture) + "（" + convertTotalQty +
                                             "）";
                        header.TotalQty = convertTotalQty;
                    }
                    header.Comment = delivery.Comment;
                    HeaderList.Add(header);
                }
            }
        }

        #endregion
    }

    public class WarehouseOutHeader
    {
        public string InternalName { get; set; }
        public string InternalPhone { get; set; }
        public string InternalFax { get; set; }
        public string BussinessPartnerName { get; set; }
        public string ContractNo { get; set; }
        public string SignDate { get; set; }
        public string TotalQty { get; set; }
        public string TotalAllQty { get; set; }
        public string WarehouseName { get; set; }
        public string WarehousePhone { get; set; }
        public string WarehouseAddress { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string DateForQW { get; set; }
        public string DeliveryPersonName { get; set; }
        public string DeliveryPersonVehicleNo { get; set; }
        public string DeliveryPersons { get; set; }
        public string IDCard1 { get; set; }
        public string IDCard2 { get; set; }
        public string IDCard3 { get; set; }
        public string IDCard4 { get; set; }
        public string IDCard5 { get; set; }
        public string IDCard6 { get; set; }
        public string IDCard7 { get; set; }
        public string IDCard8 { get; set; }
        public string IDCard9 { get; set; }
        public string IDCard10 { get; set; }
        public string IDCard11 { get; set; }
        public string IDCard12 { get; set; }
        public string IDCard13 { get; set; }
        public string IDCard14 { get; set; }
        public string IDCard15 { get; set; }
        public string IDCard16 { get; set; }
        public string IDCard17 { get; set; }
        public string IDCard18 { get; set; }
        public string Person1 { get; set; }
        public string Person2 { get; set; }
        public string Person3 { get; set; }
        public string TZTxt { get; set; }
    }

    public class WarehouseLineList
    {
        public string LineNo { get; set; }
        public string CommodityName { get; set; }
        public string AllQty { get; set; }
        public string Unit { get; set; }
        public string Packing { get; set; }
        public string VerifiedQuantity { get; set; }
        public string DeliveryPersons { get; set; }
        public string CommodityTypeName { get; set; }
    }
}