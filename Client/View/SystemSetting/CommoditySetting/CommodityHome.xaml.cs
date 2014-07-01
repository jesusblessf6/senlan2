using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.SystemSetting.CommoditySetting;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using System;
using Utility.ErrorManagement;

namespace Client.View.SystemSetting.CommoditySetting
{
    /// <summary>
    /// CommodityHome.xaml 的交互逻辑
    /// </summary>
    public partial class CommodityHome
    {
        #region Member

        private const int BrandHomePerPage = 10;
        private const int CommodityHomePerPage = 10;
        private const int CommodityTpeyHomePerPage = 10;
        private const int SpecificationHomePerPage = 10;
        private readonly bool _canAdd;
        private readonly bool _canEdit;
        private readonly bool _canDelete;
        private readonly bool _canView;

        #endregion

        #region Property

        public CommodityHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public CommodityHome()
        {
            InitializeComponent();
            ModuleName = "CommoditySetting";
            VM = new CommodityHomeVM();

            _canAdd = CheckPerm(PageMode.AddMode);
            _canEdit = CheckPerm(PageMode.EditMode);
            _canDelete = CheckPerm(PageMode.DeleteMode);
            _canView = CheckPerm(PageMode.ViewMode);

            pagingControl1.OnNewPage += pagingControl1_OnNewPage;
            pagingControl1.Init(VM.CommodityCount, CommodityHomePerPage);

            button2.IsEnabled = _canAdd;
            pagingControl2.OnNewPage += pagingControl2_OnNewPage;
            pagingControl2.Init(VM.CommodityTypeCount, CommodityTpeyHomePerPage);

            button3.IsEnabled = _canAdd;
            pagingControl3.OnNewPage += pagingControl3_OnNewPage;
            pagingControl3.Init(VM.BrandCount, BrandHomePerPage);

            button4.IsEnabled = _canAdd;
            pagingControl4.OnNewPage += pagingControl4_OnNewPage;
            pagingControl4.Init(VM.SpecificationCount, SpecificationHomePerPage);
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;

            comboBox1.ItemsSource = VM.SearchCommodities;
            comboBox2.ItemsSource = VM.SearchCommodityTypes;
            comboBox3.ItemsSource = VM.SearchCommodities;
            comboBox4.ItemsSource = VM.SearchCommodities;
            comboBox5.ItemsSource = VM.SearchCommodityTypes;

            comboBox1.Items.Refresh();
            comboBox2.Items.Refresh();
            comboBox3.Items.Refresh();
            comboBox4.Items.Refresh();
            comboBox5.Items.Refresh();

        }

        public override void Refresh()
        {
            if(tabControl1.SelectedIndex == 0)
            {
                VM.LoadCommodityCount();
                pagingControl1.Init(VM.CommodityCount, CommodityHomePerPage);
                BindData();
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                VM.SearchCommodityId = null;
                VM.LoadCommodityTypeCount();
                pagingControl2.Init(VM.CommodityTypeCount, CommodityTpeyHomePerPage);
                BindData();
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                VM.LoadBrandCount();
                VM.SearchCommodityId = null;
                VM.SearchCommodityTypeId = null;
                pagingControl3.Init(VM.BrandCount, BrandHomePerPage);
                BindData();
            }
            else if(tabControl1.SelectedIndex == 3)
            {
                VM.SearchCommodityId = null;
                VM.SearchCommodityTypeId = null;
                VM.LoadSpecificationCount();
                pagingControl4.Init(VM.SpecificationCount, SpecificationHomePerPage);
                BindData();
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// CommodityType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommodityTypeEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void CommodityTypeEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var commodityTypeId = (int)e.Parameter;
            var cd = new CommodityTypeDetail(commodityTypeId, PageMode.EditMode);
            cd.Show();
            e.Handled = true;
        }

        private void CommodityTypeDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void CommodityTypeDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteCommodityType(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;

        }

        /// <summary>
        /// Brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrandEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void BrandEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var brandId = (int) e.Parameter;
            var bd = new BrandDetail(brandId, PageMode.EditMode);
            bd.Show();
            e.Handled = true;
        }

        private void BrandDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void BrandDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteBrand(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// Specification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecificationEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canEdit;
            e.Handled = true;
        }

        private void SpecificationEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var specificationId = (int) e.Parameter;
            var sd = new SpecificationDetail(specificationId, PageMode.EditMode);
            sd.Show();
            e.Handled = true;
        }

        private void SpecificationDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canDelete;
            e.Handled = true;
        }

        private void SpecificationDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int)e.Parameter : 0;
            if (id != 0 && MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DeleteSpecification(id);
                    MessageBox.Show(Properties.Resources.DeleteSucessfully);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
                    return;
                }
            }
            e.Handled = true;
        }


        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var cd = new CommodityTypeDetail(PageMode.AddMode);
            cd.Show();
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var bd = new BrandDetail(PageMode.AddMode);
            bd.Show();
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            var sd = new SpecificationDetail(PageMode.AddMode);
            sd.Show();
        }

        private void DataGrid1LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl1.CurPageNo - 1) * CommodityHomePerPage + e.Row.GetIndex() + 1;
        }

        private void DataGrid2LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl2.CurPageNo - 1) * CommodityTpeyHomePerPage + e.Row.GetIndex() + 1;
        }

        private void DataGrid3LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl3.CurPageNo - 1) * BrandHomePerPage + e.Row.GetIndex() + 1;
        }

        private void DataGrid4LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagingControl4.CurPageNo - 1) * SpecificationHomePerPage + e.Row.GetIndex() + 1;
        }

        private void CommodityTypeViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void CommodityTypeViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var bd = new CommodityTypeDetail(id, PageMode.ViewMode);
            bd.Show();
            e.Handled = true;
        }

        private void BrandViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void BrandViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var bd = new BrandDetail(id, PageMode.ViewMode);
            bd.Show();
            e.Handled = true;
        }

        private void SpecificationViewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _canView;
            e.Handled = true;
        }

        private void SpecificationViewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var id = (int)e.Parameter;
            var bd = new SpecificationDetail(id, PageMode.ViewMode);
            bd.Show();
            e.Handled = true;
        }

        private void pagingControl1_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.CommodityFrom = e.From;
            VM.CommodityTo = e.To;
            VM.LoadCommodity();
            dataGrid1.ItemsSource = VM.Commodities;
            dataGrid1.Items.Refresh();
        }

        private void pagingControl2_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.CommodityTypeFrom = e.From;
            VM.CommodityTypeTo = e.To;
            VM.LoadCommodityType();
            dataGrid2.ItemsSource = VM.CommodityTypes;
            dataGrid2.Items.Refresh();
        }

        private void pagingControl3_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.BrandFrom = e.From;
            VM.BrandTo = e.To;
            VM.LoadBrand();
            dataGrid3.ItemsSource = VM.Brands;
            dataGrid3.Items.Refresh();
        }

        private void pagingControl4_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.SpecificationFrom = e.From;
            VM.SpecificationTo = e.To;
            VM.LoadSpecification();
            dataGrid4.ItemsSource = VM.Specifications;
            dataGrid4.Items.Refresh();
        }

        private void TabControl1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.OriginalSource is TabControl)
            {
                Refresh();
                e.Handled = true;
            }
            else 
            {
                e.Handled = false;
            }
        }

        private void CbxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VM != null)
            {
                comboBox2.ItemsSource = VM.SearchCommodityTypes;
                comboBox2.Items.Refresh();
                comboBox5.ItemsSource = VM.SearchCommodityTypes;
                comboBox5.Items.Refresh();
            }
        }


        private void ButtonSearchClick(object sender, RoutedEventArgs e)
        {
            VM.LoadCommodityTypeCount();
            pagingControl2.Init(VM.CommodityTypeCount, CommodityTpeyHomePerPage);
            VM.LoadBrandCount();
            pagingControl3.Init(VM.BrandCount, BrandHomePerPage);
            VM.LoadSpecificationCount();
            pagingControl4.Init(VM.SpecificationCount, SpecificationHomePerPage);


            VM.LoadBrand();
            VM.LoadCommodityType();
            VM.LoadSpecification();
            dataGrid2.ItemsSource = VM.CommodityTypes;
            dataGrid2.Items.Refresh();
            dataGrid3.ItemsSource = VM.Brands;
            dataGrid3.Items.Refresh();
            dataGrid4.ItemsSource = VM.Specifications;
            dataGrid4.Items.Refresh();
        }
        #endregion
    }
}