using System.Linq;
using DBEntity.EnumEntity;
using System.Collections.Generic;

namespace DBEntity
{
    partial class CommercialInvoice
    {
        private decimal _grossWeight;
        private decimal _netWeight;
        private string _brand;
        private decimal _packingQuantity;
        private string _origin;

        public string Origins
        {
            get
            {
                _origin = string.Empty;
                var listID = new List<int>();
                if (BaseCommercialInvoiceId == null)
                {
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        if (Deliveries != null && Deliveries.Count > 0)
                        {
                            int i = 0;
                            foreach (Delivery delivery in Deliveries)
                            {
                                foreach (DeliveryLine line in delivery.DeliveryLines)
                                {
                                    if (i == 0)
                                    {
                                        i++;
                                        if (line.Country != null)
                                        {
                                            _origin = line.Country.Name;
                                            listID.Add(line.Country.Id);
                                        }
                                    }
                                    else if (i > 0)
                                    {
                                        if (line.Country != null)
                                        {
                                            if (listID.Count > 0)
                                            {
                                                if (!listID.Contains(line.Country.Id))
                                                {
                                                    _origin += "/" + line.Country.Name;
                                                    listID.Add(line.Country.Id);
                                                }
                                            }
                                            else
                                            {
                                                _origin = line.Country.Name;
                                                listID.Add(line.Country.Id);
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    { 
                         //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            foreach(CommercialInvoice commercialInvoice in ProvisionalInvoices)
                            {
                                if (commercialInvoice.Deliveries != null && commercialInvoice.Deliveries.Count > 0)
                                {
                                    int i = 0;
                                    foreach (Delivery delivery in commercialInvoice.Deliveries)
                                    {
                                        foreach (DeliveryLine line in delivery.DeliveryLines)
                                        {
                                            if (i == 0)
                                            {
                                                i++;
                                                if (line.Country != null)
                                                {
                                                    _origin = line.Country.Name;
                                                    listID.Add(line.Country.Id);
                                                }
                                            }
                                            else if (i > 0)
                                            {
                                                if (line.Country != null)
                                                {
                                                    if (listID.Count > 0)
                                                    {
                                                        if (!listID.Contains(line.Country.Id))
                                                        {
                                                            _origin += "/" + line.Country.Name;
                                                            listID.Add(line.Country.Id);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        _origin = line.Country.Name;
                                                        listID.Add(line.Country.Id);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else//自动生成的单据
                {
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        if (BaseInvoice != null && BaseInvoice.Deliveries != null && BaseInvoice.Deliveries.Count > 0)
                        {
                            int i = 0;
                            foreach (Delivery delivery in BaseInvoice.Deliveries)
                            {
                                foreach (DeliveryLine line in delivery.DeliveryLines)
                                {
                                    if (i == 0)
                                    {
                                        i++;
                                        if (line.Country != null)
                                        {
                                            _origin = line.Country.Name;
                                            listID.Add(line.Country.Id);
                                        }
                                    }
                                    else if (i > 0)
                                    {
                                        if (line.Country != null)
                                        {
                                            if (listID.Count > 0)
                                            {
                                                if (!listID.Contains(line.Country.Id))
                                                {
                                                    _origin += "/" + line.Country.Name;
                                                    listID.Add(line.Country.Id);
                                                }
                                            }
                                            else
                                            {
                                                _origin = line.Country.Name;
                                                listID.Add(line.Country.Id);
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            foreach (CommercialInvoice commercialInvoice in ProvisionalInvoices)
                            {
                                if (commercialInvoice.BaseInvoice != null && commercialInvoice.BaseInvoice.Deliveries != null && commercialInvoice.BaseInvoice.Deliveries.Count > 0)
                                {
                                    int i = 0;
                                    foreach (Delivery delivery in commercialInvoice.BaseInvoice.Deliveries)
                                    {
                                        foreach (DeliveryLine line in delivery.DeliveryLines)
                                        {
                                            if (i == 0)
                                            {
                                                i++;
                                                if (line.Country != null)
                                                {
                                                    _origin = line.Country.Name;
                                                    listID.Add(line.Country.Id);
                                                }
                                            }
                                            else if (i > 0)
                                            {
                                                if (line.Country != null)
                                                {
                                                    if (listID.Count > 0)
                                                    {
                                                        if (!listID.Contains(line.Country.Id))
                                                        {
                                                            _origin += "/" + line.Country.Name;
                                                            listID.Add(line.Country.Id);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        _origin = line.Country.Name;
                                                        listID.Add(line.Country.Id);
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return _origin;
            }
        }

        public decimal TotalPackingQuantity
        {
            get
            {
                _packingQuantity = 0;
                if (BaseCommercialInvoiceId == null)
                {
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        //临时发票 
                        if (Deliveries != null && Deliveries.Count > 0)
                        {
                            foreach (Delivery delivery in Deliveries)
                            {
                                if (!delivery.IsDeleted)
                                {
                                    foreach (DeliveryLine line in delivery.DeliveryLines)
                                    {
                                        _packingQuantity += (line.PackingQuantity ?? 0);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            foreach (CommercialInvoice commercialInvoice in ProvisionalInvoices)
                            {
                                if (!commercialInvoice.IsDeleted)
                                {
                                    if (commercialInvoice.Deliveries != null && commercialInvoice.Deliveries.Count > 0)
                                    {
                                        foreach (Delivery delivery in commercialInvoice.Deliveries)
                                        {
                                            if (!delivery.IsDeleted)
                                            {
                                                foreach (DeliveryLine line in delivery.DeliveryLines)
                                                {
                                                    _packingQuantity += (line.PackingQuantity ?? 0);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        //临时发票 
                        if (BaseInvoice != null && BaseInvoice.Deliveries != null && BaseInvoice.Deliveries.Count > 0)
                        {
                            foreach (Delivery delivery in BaseInvoice.Deliveries)
                            {
                                if (!delivery.IsDeleted)
                                {
                                    foreach (DeliveryLine line in delivery.DeliveryLines)
                                    {
                                        _packingQuantity += (line.PackingQuantity ?? 0);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            foreach (CommercialInvoice commercialInvoice in ProvisionalInvoices)
                            {
                                if (!commercialInvoice.IsDeleted)
                                {
                                    //临时发票 
                                    if (commercialInvoice.BaseInvoice != null && commercialInvoice.BaseInvoice.Deliveries != null && commercialInvoice.BaseInvoice.Deliveries.Count > 0)
                                    {
                                        foreach (Delivery delivery in commercialInvoice.BaseInvoice.Deliveries)
                                        {
                                            if (!delivery.IsDeleted)
                                            {
                                                foreach (DeliveryLine line in delivery.DeliveryLines)
                                                {
                                                    _packingQuantity += (line.PackingQuantity ?? 0);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return _packingQuantity;
            }
        }

        public string Brands
        {
            get
            {
                _brand = string.Empty;
                var listID = new List<int>();
                if (BaseCommercialInvoiceId == null)
                {
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        if (Deliveries != null && Deliveries.Count > 0)
                        {
                            int i = 0;
                            foreach (Delivery delivery in Deliveries)
                            {
                                foreach (DeliveryLine line in delivery.DeliveryLines)
                                {
                                    if (i == 0)
                                    {
                                        i++;
                                        if (line.Brand != null)
                                        {
                                            _brand = line.Brand.Name;
                                            listID.Add(line.Brand.Id);
                                        }
                                    }
                                    else if (i > 0)
                                    {
                                        if (line.Brand != null)
                                        {
                                            if (listID.Count > 0)
                                            {
                                                if (!listID.Contains(line.Brand.Id))
                                                {
                                                    _brand += "/" + line.Brand.Name;
                                                    listID.Add(line.Brand.Id);
                                                }
                                            }
                                            else {
                                                _brand = line.Brand.Name;
                                                listID.Add(line.Brand.Id);
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            foreach (CommercialInvoice commercialInvoice in ProvisionalInvoices)
                            {
                                if (!commercialInvoice.IsDeleted)
                                {
                                    if (commercialInvoice.Deliveries != null && commercialInvoice.Deliveries.Count > 0)
                                    {
                                        int i = 0;
                                        foreach (Delivery delivery in commercialInvoice.Deliveries)
                                        {
                                            foreach (DeliveryLine line in delivery.DeliveryLines)
                                            {
                                                if (i == 0)
                                                {
                                                    i++;
                                                    if (line.Brand != null)
                                                    {
                                                        _brand = line.Brand.Name;
                                                        listID.Add(line.Brand.Id);
                                                    }
                                                }
                                                else if (i > 0)
                                                {
                                                    if (listID.Count > 0)
                                                    {
                                                        if (line.Brand != null)
                                                        {
                                                            if (!listID.Contains(line.Brand.Id))
                                                            {
                                                                _brand += "/" + line.Brand.Name;
                                                                listID.Add(line.Brand.Id);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        _brand = line.Brand.Name;
                                                        listID.Add(line.Brand.Id);
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else//自动生成的单据
                {
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        if (BaseInvoice != null && BaseInvoice.Deliveries != null && BaseInvoice.Deliveries.Count > 0)
                        {
                            int i = 0;
                            foreach (Delivery delivery in BaseInvoice.Deliveries)
                            {
                                foreach (DeliveryLine line in delivery.DeliveryLines)
                                {
                                    if (i == 0)
                                    {
                                        i++;
                                        if (line.Brand != null)
                                        {
                                            _brand = line.Brand.Name;
                                            listID.Add(line.Brand.Id);
                                        }
                                    }
                                    else if (i > 0)
                                    {
                                        if (line.Brand != null)
                                        {
                                            if (listID.Count > 0)
                                            {
                                                if (!listID.Contains(line.Brand.Id))
                                                {
                                                    _brand += "/" + line.Brand.Name;
                                                    listID.Add(line.Brand.Id);
                                                }
                                            }
                                            else
                                            {
                                                _brand = line.Brand.Name;
                                                listID.Add(line.Brand.Id);
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            foreach (CommercialInvoice commercialInvoice in ProvisionalInvoices)
                            {
                                if (commercialInvoice.BaseInvoice != null && commercialInvoice.BaseInvoice.Deliveries != null && commercialInvoice.BaseInvoice.Deliveries.Count > 0)
                                {
                                    int i = 0;
                                    foreach (Delivery delivery in commercialInvoice.BaseInvoice.Deliveries)
                                    {
                                        foreach (DeliveryLine line in delivery.DeliveryLines)
                                        {
                                            if (i == 0)
                                            {
                                                i++;
                                                if (line.Brand != null)
                                                {
                                                    _brand = line.Brand.Name;
                                                    listID.Add(line.Brand.Id);
                                                }
                                            }
                                            else if (i > 0)
                                            {
                                                if (line.Brand != null)
                                                {
                                                    if (listID.Count > 0)
                                                    {
                                                        if (!listID.Contains(line.Brand.Id))
                                                        {
                                                            _brand += "/" + line.Brand.Name;
                                                            listID.Add(line.Brand.Id);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        _brand = line.Brand.Name;
                                                        listID.Add(line.Brand.Id);
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return _brand;
            }
        }

        public decimal NetWeights
        {
            get
            {
                if (BaseCommercialInvoiceId == null)
                {
                    _netWeight = 0;
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        //临时发票 
                        if (Deliveries != null && Deliveries.Count > 0)
                        {
                            //foreach (Delivery delivery in Deliveries)
                            //{
                            //    if (delivery.IsDeleted == false)
                            //    {
                            //        _netWeight += (delivery.TotalNetWeight ?? 0);
                            //    }
                            //}

                            _netWeight += (decimal)Deliveries.Sum(o => o.TotalNetWeight);
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            //foreach (CommercialInvoice invoice in ProvisionalInvoices)
                            //{
                            //    if (invoice.IsDeleted == false)
                            //        _netWeight += invoice.NetWeights;
                            //}
                            _netWeight += ProvisionalInvoices.Where(o => !o.IsDeleted).Sum(o => o.NetWeights);
                        }
                    }

                    return _netWeight;
                }
                else
                {
                    _netWeight = 0;

                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        //临时发票 
                        if (BaseInvoice != null && BaseInvoice.Deliveries != null && BaseInvoice.Deliveries.Count > 0)
                        {
                            //foreach (Delivery delivery in BaseInvoice.Deliveries)
                            //{
                            //    if (delivery.IsDeleted == false)
                            //    {
                            //        _netWeight += (delivery.TotalNetWeight ?? 0);
                            //    }
                            //}
                            _netWeight += (decimal)BaseInvoice.Deliveries.Sum(o => o.TotalNetWeight);
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            //foreach (CommercialInvoice invoice in ProvisionalInvoices)
                            //{
                            //    if (invoice.IsDeleted == false)
                            //        _netWeight += invoice.NetWeights;
                            //}
                            _netWeight += ProvisionalInvoices.Where(o => !o.IsDeleted).Sum(o => o.NetWeights);
                        }
                    }

                    return _netWeight;

                }
            }
        }

        public decimal GrossWeights
        {
            get
            {
                if (BaseCommercialInvoiceId == null)
                {
                    _grossWeight = 0;
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        //临时发票
                        if (Deliveries != null && Deliveries.Count > 0)
                        {
                            //foreach (Delivery delivery in Deliveries)
                            //{
                            //    if (delivery.IsDeleted == false)
                            //    {
                            //        _grossWeight += (delivery.TotalGrossWeight ?? 0);
                            //    }
                            //}
                            _grossWeight += (decimal)Deliveries.Sum(o => o.TotalGrossWeight);
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            //foreach (CommercialInvoice invoice in ProvisionalInvoices)
                            //{
                            //    if (invoice.IsDeleted == false)
                            //        _grossWeight += invoice.GrossWeights;
                            //}
                            _grossWeight += ProvisionalInvoices.Where(o => !o.IsDeleted).Sum(o => o.GrossWeights);
                        }
                    }
                    return _grossWeight;
                }
                else
                {
                    _grossWeight = 0;
                    if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                    {
                        //临时发票
                        if (BaseInvoice != null && BaseInvoice.Deliveries != null && BaseInvoice.Deliveries.Count > 0)
                        {
                            //foreach (Delivery delivery in BaseInvoice.Deliveries)
                            //{
                            //    if (delivery.IsDeleted == false)
                            //    {
                            //        _grossWeight += (delivery.TotalGrossWeight ?? 0);
                            //    }
                            //}
                            _grossWeight += (decimal)BaseInvoice.Deliveries.Sum(o => o.TotalGrossWeight);
                        }
                    }
                    else
                    {
                        //最终发票
                        if (ProvisionalInvoices != null && ProvisionalInvoices.Count > 0)
                        {
                            //foreach (CommercialInvoice invoice in ProvisionalInvoices)
                            //{
                            //    if (invoice.IsDeleted == false)
                            //        _grossWeight += invoice.GrossWeights;
                            //}
                            _grossWeight += ProvisionalInvoices.Where(o => !o.IsDeleted).Sum(o => o.GrossWeights);
                        }
                    }
                    return _grossWeight;
                }
            }
        }

        private decimal _totleInterest;
        public decimal TotleInterest
        {
            get
            {
                _totleInterest = 0;
                if (InvoiceType == (int)CommercialInvoiceType.Provisional || InvoiceType == (int)CommercialInvoiceType.FinalCommercial)
                {
                    //临时发票
                    if (LCCIRels != null && LCCIRels.Count > 0)
                    {
                        foreach (var rel in LCCIRels)
                        {
                            if (rel.IsDeleted)
                                continue;
                            decimal presentAmount = rel.LetterOfCredit.PresentAmount ?? 0;
                            decimal lInterest = rel.LetterOfCredit.Interest ?? 0;
                            decimal lAllocationAmount = rel.AllocationAmount ?? 0;
                            if (presentAmount != 0 && lInterest != 0 && lAllocationAmount != 0)
                            {
                                _totleInterest += lInterest * lAllocationAmount / presentAmount;
                            }
                        }
                    }
                }
                return _totleInterest;
            }
            set { _totleInterest = value; }
        }

        public decimal PaymentRequestAmount 
        {
            get
            {
                decimal amount = 0;
                if (PaymentRequests != null)
                {
                    foreach (var paymentRequest in PaymentRequests)
                    {
                        if (paymentRequest.IsDeleted)
                            continue;
                        amount += paymentRequest.RequestAmount ?? 0;
                    }
                }
                return amount;
            }
        }

        public decimal ARAPAmount 
        {
            get
            {
                decimal amount = Amount ?? 0;
                if (InvoiceType == (int)CommercialInvoiceType.Final)
                { 
                    if(ProvisionalInvoices!=null)
                    {
                        decimal pInvoiceAmount = 0M;
                        foreach (var p in ProvisionalInvoices)
                        {
                            if (p.IsDeleted)
                                continue;
                            pInvoiceAmount += p.Amount ?? 0;
                        }
                        amount -= pInvoiceAmount;
                    }
                }
                return amount;
            }
        }
    }
}
