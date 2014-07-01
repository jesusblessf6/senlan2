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
using DBEntity.EnumEntity;
using DBEntity;
using Client.ViewModel.SystemSetting.WarehouseSetting;
using Utility.ErrorManagement;
using Infralution.Localization.Wpf;

namespace Client.View.SystemSetting.WarehouseSetting
{
    /// <summary>
    /// Interaction logic for StorageFeeDetail.xaml
    /// </summary>
    public sealed partial class StorageFeeDetail
    {
        #region Property
        public StorageFeeDetailVM SFVM { get; set; }
        #endregion

        public StorageFeeDetail(PageMode pageMode, List<StorageFeeRule> allStorageFeeRules, List<StorageFeeRule> addStorageFeeRules)
            : base(pageMode, "仓储费新增")
        {
            InitializeComponent();
            ModuleName = "WarehouseSetting";
            SFVM = new StorageFeeDetailVM(allStorageFeeRules, addStorageFeeRules);
            BindData();
        }

        public StorageFeeDetail(int id,PageMode pageMode, List<StorageFeeRule> allStorageFeeRules, List<StorageFeeRule> addStorageFeeRules, List<StorageFeeRule> updateStorageFeeRules)
            : base(pageMode, "仓储费更新")
        {
            InitializeComponent();
            ModuleName = "WarehouseSetting";
            SFVM = new StorageFeeDetailVM(id,allStorageFeeRules, addStorageFeeRules,updateStorageFeeRules);
            BindData();
        }

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = SFVM;
        }
        #endregion

        #region Event

        private void BtSave(object sender, RoutedEventArgs e)
        {
            try
            {
                SFVM.Save();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
    }
}
