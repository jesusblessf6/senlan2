using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBEntity
{
    partial class WarehouseOut
    {
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

        public bool Printable { get { return true; } }
    }
}
