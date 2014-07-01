using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Base.BaseClientVM;
using DBEntity;

namespace Client.ViewModel.Physical.Deliveries
{
    public class NewImportDeliveryEditVM : BaseVM
    {
        #region Member
        private decimal? _totalNetWeight;
        private decimal? _totalGrossWeight;
        private decimal? _totalPacking;
        private decimal? _totalOldNetWeight;
        private decimal? _totalOldGrossWeight;
        private decimal? _totalOldPacking;

        private List<DeliveryLine> _AddLineList;
        private List<Delivery> _DeliveryList;
        private int _PDeliveryID;
        //public List<DeliveryLine> _UpdateLineList;
        //public List<DeliveryLine> _DeleteLineList;
        #endregion

        #region Property
        public decimal? TotalOldPacking
        {
            get { return _totalOldPacking; }
            set { 
                if(_totalOldPacking != value)
                {
                    _totalOldPacking = value;
                    Notify("TotalOldPacking");
                }
            }
        }

        public decimal? TotalOldGrossWeight
        {
            get { return _totalOldGrossWeight; }
            set { 
                if(_totalOldGrossWeight != value)
                {
                    _totalOldGrossWeight = value;
                    Notify("TotalOldGrossWeight");
                }
            }
        }

        public decimal? TotalOldNetWeight
        {
            get { return _totalOldNetWeight; }
            set { 
                if(_totalOldNetWeight != value)
                {
                    _totalOldNetWeight = value;
                    Notify("TotalOldNetWeight");
                }
            }
        }

        public int PDeliveyID
        {
            get { return _PDeliveryID; }
            set { 
                if(_PDeliveryID != value)
                {
                    _PDeliveryID = value;
                    Notify("PDeliveyID");
                }
            }
        }

        public List<Delivery> DeliveryList
        {
            get { return _DeliveryList; }
            set { 
                if(_DeliveryList != value)
                {
                    _DeliveryList = value;
                    Notify("DeliveryList");
                }
            }
        }

        public List<DeliveryLine> AddLineList
        {
            get { return _AddLineList; }
            set { 
                if(_AddLineList != value)
                {
                    _AddLineList = value;
                    Notify("AddLineList");
                }
            }
        }

        public decimal? TotalPacking
        {
            get { return _totalPacking; }
            set { 
                if(_totalPacking != value)
                {
                    _totalPacking = value;
                    Notify("TotalPacking");
                }
            }
        }

        public decimal? TotalGorssWeight
        {
            get { return _totalGrossWeight; }
            set
            {
                if (_totalGrossWeight != value)
                {
                    _totalGrossWeight = value;
                    Notify("TotalGorssWeight");
                }
            }
        }

        public decimal? TotalNetWeight
        {
            get { return _totalNetWeight; }
            set { 
                if(_totalNetWeight != value)
                {
                    _totalNetWeight = value;
                    Notify("TotalNetWeight");
                }
            }
        }
        #endregion

        #region Contructor
        public NewImportDeliveryEditVM(int pDeliveryID, List<DeliveryLine> addLineList, List<Delivery> deliveryList)
        {
            AddLineList = addLineList;
            DeliveryList = deliveryList;
            PDeliveyID = pDeliveryID;
            ObjectId = 0;
            SetData();
        }
        #endregion

        #region Method
        public void SetData()
        {
            if (DeliveryList != null && DeliveryList.Count > 0)
            {
                List<Delivery> list = DeliveryList.Where(c => c.ProvisionalID == PDeliveyID).ToList();
                if (list.Count > 0)
                {
                    Delivery d = list.FirstOrDefault();
                    TotalGorssWeight = d.TotalGrossWeight;
                    TotalNetWeight = d.TotalNetWeight;
                    TotalPacking = d.TotalPackingQty;
                    TotalOldGrossWeight = d.TotalGrossWeight;
                    TotalOldNetWeight = d.TotalNetWeight;
                    TotalOldPacking = d.TotalPackingQty;
                }
            }
        }

        protected override void Create()
        {
            #region 先把原始Delivery删除 加添加更新后的
            if (DeliveryList != null && DeliveryList.Count > 0)
            {
                List<Delivery> list = DeliveryList.Where(c => c.ProvisionalID == PDeliveyID && c.Id != 0).ToList();
                if (list.Count > 0)
                {
                    Delivery d = list.FirstOrDefault();
                    DeliveryList.Remove(d);
                    d.TotalGrossWeight = TotalGorssWeight;
                    d.TotalNetWeight = TotalNetWeight;
                    d.TotalPackingQty = TotalPacking;
                    d.CanEditEnable = false;
                    DeliveryList.Add(d);
                }
            }
            #endregion

            if (AddLineList != null && AddLineList.Count > 0)
            {
                List<DeliveryLine> lineList = AddLineList.Where(c => c.DeliveryPID == PDeliveyID).ToList();
                //从原始List中先删除
                foreach(DeliveryLine line in lineList)
                {
                    AddLineList.Remove(line);
                }
                decimal? neiWeight = (TotalOldNetWeight ?? 0) - ( TotalNetWeight ?? 0);//计算更改后的与原始的差值
                decimal? grossWeight = (TotalOldGrossWeight ?? 0) - (TotalGorssWeight ?? 0);
                decimal? packing = (TotalOldPacking ?? 0) - (TotalPacking ?? 0);
                List<DeliveryLine> delLineList = new List<DeliveryLine>();
                lineList.ForEach(c => delLineList.Add(c));
                //List<DeliveryLine> delLineList = lineList.Where(c => c.NetWeight < neiWeight && c.GrossWeight < grossWeight && c.PackingQuantity < packing).ToList();
                foreach (DeliveryLine delLine in delLineList)
                {
                    //如果存在所有数据都比差值小的 直接删除
                    if (delLine.NetWeight <= neiWeight && delLine.GrossWeight <= grossWeight && delLine.PackingQuantity <= packing)
                    {
                        lineList.Remove(delLine);
                        //差值减去已删除的数值——剩余差值
                        neiWeight = neiWeight - delLine.NetWeight;
                        grossWeight = grossWeight - delLine.GrossWeight;
                        packing = packing - delLine.PackingQuantity;
                    }
                }
                if(lineList.Count > 0)
                {
                    List<DeliveryLine> lineUpdateList = lineList.Where(c => c.NetWeight >= neiWeight && c.GrossWeight >= grossWeight && c.PackingQuantity >= packing).ToList();
                    if(lineUpdateList.Count > 0)
                    {
                        DeliveryLine updateLine = lineUpdateList.FirstOrDefault();
                        lineList.Remove(updateLine);
                        updateLine.GrossWeight = updateLine.GrossWeight - grossWeight;
                        updateLine.NetWeight = updateLine.NetWeight - neiWeight;
                        updateLine.PackingQuantity = updateLine.PackingQuantity - packing;
                        lineList.Add(updateLine);
                    }

                }
                foreach(DeliveryLine finalLine in lineList)
                {
                    AddLineList.Add(finalLine);
                }

            }
        }

        public override bool Validate()
        {
            if(TotalGorssWeight > TotalOldGrossWeight || TotalNetWeight > TotalOldNetWeight || TotalPacking > TotalOldPacking)
            {
                throw new Exception("更改的数值不符合实际情况 请重新修改");
            }
            return true;
        }
        #endregion
    }
}
