namespace DBEntity
{
    partial class WarehouseInLine
    {
        private decimal? _onlyQty = 0;
        private decimal? _outQty = 0;
        private decimal? _packingQty = 0;
        private decimal? _onlyPackingQty = 0;

        public decimal? OnlyQuantity
        {
            get
            {
                _onlyQty = 0;
                _outQty = 0;
                foreach (WarehouseOutLine outLine in WarehouseOutLines)
                {
                    if (!outLine.IsDeleted)
                    {
                        decimal outLineQty = outLine.VerifiedQuantity == null ? 0 : (decimal)outLine.VerifiedQuantity;
                        _outQty += outLineQty;
                    }
                }

                _onlyQty = VerifiedQuantity - _outQty;
                return _onlyQty;
            }
        }

        public decimal? OnlyPackingQty
        {
            get
            {
                _packingQty = 0;
                foreach (WarehouseOutLine outLine in WarehouseOutLines)
                {
                    if (!outLine.IsDeleted)
                    {
                        decimal packingQty = outLine.PackingQuantity == null ? 0 : outLine.PackingQuantity.Value;
                        _packingQty += packingQty;
                    }
                }
                _onlyPackingQty = PackingQuantity - _packingQty;
                return _onlyPackingQty;
            }
        }
    }
}
