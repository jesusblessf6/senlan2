using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DBEntity.EnumEntity;

namespace DBEntity
{
    partial class Delivery : IApprovable
    {
        private string _totalBrands;
        private decimal? _totalGrossWeight;
        private decimal? _totalNetWeight;
        private decimal? _totalQty;
        private decimal? _totalQuantity;
        private string _commodityTypeName;
        private string _brandName;
        private decimal? _totalPackingQty;
        private string _WarehouseName;

        [DataMember]
        public string WarehouseName
        {
            get
            {
                if (Warehouse != null)
                {
                    _WarehouseName = Warehouse.Name;
                }
                return _WarehouseName;
            }

            set { _WarehouseName = value; }
        }

        [DataMember]
        public decimal? TotalPackingQty
        {
            get
            {
                if (DeliveryLines != null && DeliveryLines.Count > 0)
                {
                    _totalPackingQty = DeliveryLines.Sum(c => c.PackingQuantity);
                }
                return _totalPackingQty;
            }
            set { _totalPackingQty = value; }
        }

        [DataMember]
        public string BrandName
        {
            get
            {
                if (DeliveryLines != null && DeliveryLines.Count > 0)
                {
                    DeliveryLine line = DeliveryLines.Where(c => c.BrandId != null).FirstOrDefault();
                    if (line != null && line.Brand != null)
                    {
                        _brandName = line.Brand.Name;
                    }
                }
                return _brandName;
            }
            set { _brandName = value; }
        }

        [DataMember]
        public string CommodityTypeName
        {
            get
            {
                if (DeliveryLines != null && DeliveryLines.Count > 0)
                {
                    DeliveryLine line = DeliveryLines.Where(c => c.CommodityTypeId != null).FirstOrDefault();
                    if (line != null && line.CommodityType != null)
                    {
                        _commodityTypeName = line.CommodityType.Name;
                    }
                }
                return _commodityTypeName;
            }
            set { _commodityTypeName = value; }
        }

        [DataMember]
        public int ProvisionalID { get; set; }

        [DataMember]
        public bool DlvIsVerified { get; set; }

        [DataMember]
        public decimal? TotalQuantity
        {
            get
            {
                if (DeliveryLines != null)
                {
                    _totalQuantity = DeliveryLines.Where(o => o.IsDeleted == false).Sum(o => o.VerifiedWeight);
                    return _totalQuantity;
                }

                return null;
            }
            set { _totalQuantity = value; }
        }

        [DataMember]
        public decimal? TotalGrossWeight
        {
            get
            {
                if (DeliveryLines != null && DeliveryLines.Count > 0)
                {
                    if (DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalTDBOL && IsDeleted && WarrantId.HasValue)
                    {
                        _totalGrossWeight = DeliveryLines.Sum(o => o.GrossWeight);
                    }
                    else
                    {
                        _totalGrossWeight = DeliveryLines.Where(o => o.IsDeleted == false).Sum(o => o.GrossWeight);
                    }
                }

                return _totalGrossWeight;
            }
            set { _totalGrossWeight = value; }
        }

        [DataMember]
        public decimal? TotalNetWeight
        {
            get
            {
                if (DeliveryLines != null && DeliveryLines.Count > 0)
                {
                    if (DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalTDBOL && IsDeleted && WarrantId.HasValue)
                    {
                        _totalNetWeight = DeliveryLines.Sum(o => o.NetWeight);
                    }
                    else
                    {
                        _totalNetWeight = DeliveryLines.Where(o => o.IsDeleted == false).Sum(o => o.NetWeight);
                    }
                }

                return _totalNetWeight;
            }
            set { _totalNetWeight = value; }
        }

        [DataMember]
        public decimal? TotalQty
        {
            get
            {
                if (DeliveryLines != null)
                {
                    if (DeliveryType == (int)EnumEntity.DeliveryType.InternalMDBOL ||
                        DeliveryType == (int)EnumEntity.DeliveryType.InternalMDWW ||
                        DeliveryType == (int)EnumEntity.DeliveryType.InternalTDBOL ||
                        DeliveryType == (int)EnumEntity.DeliveryType.InternalTDWW)
                    {
                        _totalQty = DeliveryLines.Where(o => o.IsDeleted == false).Sum(o => o.VerifiedWeight);
                    }
                    //else
                    //{
                    //    _totalQty = DeliveryLines.Where(o => o.IsDeleted == false).Sum(o => o.NetWeight);
                    //}
                    return _totalQty;
                }

                return null;
            }
            set { _totalQty = value; }
        }


        [DataMember]
        public string TotalBrands
        {
            get
            {
                if (DeliveryLines != null && DeliveryLines.Count > 0)
                {
                    string temp = string.Empty;
                    var brandsName = new List<string>();
                    foreach (DeliveryLine line in DeliveryLines)
                    {
                        if (line.Brand != null && line.IsDeleted == false)
                        {
                            if (brandsName.Contains(line.Brand.Name))
                                continue;

                            brandsName.Add(line.Brand.Name);
                        }
                    }
                    if (brandsName.Count > 0)
                    {
                        brandsName.ForEach(o => temp += "/" + o);
                    }
                    //DeliveryLines.Where(o => o.IsDeleted == false).ToList().ForEach(o => _totalBrands+="/"+o.Brand.Name);
                    if (!string.IsNullOrEmpty(temp) && temp.Length > 0)
                    {
                        _totalBrands = temp.Substring(1, temp.Length - 1);
                    }
                    return _totalBrands;
                }

                return string.Empty;
            }
            set { _totalBrands = value; }
        }

        [DataMember]
        public decimal AmountForApproval { get; set; }

        [DataMember]
        public int CurrencyIdForApproval { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        private bool _isSelected;

        public bool Printable
        {
            get
            {
                return DeliveryType == (int)EnumEntity.DeliveryType.InternalMDBOL ||
                       DeliveryType == (int)EnumEntity.DeliveryType.InternalMDWW;
            }
        }

        public string IsPrintControlsVisible
        {
            get
            {
                if (Quota.Contract.ContractType == (int)ContractType.Purchase)
                    return "Hidden";

                return "Visible";
            }
        }

        public string DeliveryNoStr
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DeliveryNo))
                {
                    return "销售明细";
                }
                else
                {
                    return DeliveryNo;
                }
            }
        }

        public bool IsTD
        {
            get
            {
                if (DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalTDBOL || DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalTDWW
                    || DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.InternalTDBOL || DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.InternalTDWW)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public bool IsMD
        {
            get
            {
                if (DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalMDBOL || DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalMDWW
                    || DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.InternalMDBOL || DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.InternalMDWW)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public bool CanConvertWR
        {
            get
            {
                if (DeliveryType == (int)DBEntity.EnumEntity.DeliveryType.ExternalTDBOL)
                {
                    if (WarrantId.HasValue)
                        return false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [DataMember]
        public bool CanEditEnable
        {
            get;
            set;
        }
    }
}
