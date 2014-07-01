using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client.ViewModel.Physical.Contracts;
using DBEntity.EnumEntity;

namespace Client.View.Physical.Contracts
{
    /// <summary>
    /// Interaction logic for MoreBrandsList.xaml
    /// </summary>
    public sealed partial class MoreBrandsList
    {
        #region Property

        public MoreBrandsVM VM { get; set; }

        #endregion

        #region Constructor

        public MoreBrandsList(int id, string moduleName)
            : base(PageMode.ViewMode)
        {
            InitializeComponent();
            ModuleName = moduleName;
            VM = new MoreBrandsVM(id);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion
    }
}
