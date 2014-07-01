using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Physical.Deliveries;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.ErrorManagement;

namespace Client.View.Physical.Deliveries
{
    /// <summary>
    ///     DeliveryLine.xaml 的交互逻辑
    /// </summary>
    public sealed partial class DeliveryLineDetail
    {
        #region Member

        private bool _saveStatus;

        #endregion

        #region Property

        public DeliveryType DeliveryType { get; set; }

        public new DeliveryLineVM VM { get; set; }

        public bool SaveStatus
        {
            get { return _saveStatus; }
            set { _saveStatus = value; }
        }

        #endregion

        #region Constructor

        public DeliveryLineDetail()
        {
            InitializeComponent();
        }

        public DeliveryLineDetail(DeliveryLine dLine, string moduleName, PageMode pageMode, Commodity commodity,
                                  DeliveryType deliveryType)
            : base(pageMode, Properties.Resources.LineInfo)
        {
            InitializeComponent();
            ModuleName = moduleName;
            DeliveryType = deliveryType;
            VM = new DeliveryLineVM(dLine, commodity);
            BindData();
            ShowOrHideComponent(deliveryType);
        }

        public DeliveryLineDetail(string moduleName, PageMode pageMode, Commodity commodity, CommodityType commodityType,
                                  Brand brand, Specification specification, DeliveryType deliveryType,
                                  List<DeliveryLine> deliveryLines, List<DeliveryLine> addDeliveryLines,decimal? qty)
            : base(pageMode, Properties.Resources.LineInfo)
        {
            InitializeComponent();
            ModuleName = moduleName;
            DeliveryType = deliveryType;
            VM = new DeliveryLineVM(commodity, commodityType, brand, specification, deliveryLines, addDeliveryLines,
                                    DeliveryType,qty);
            BindData();
            ShowOrHideComponent(deliveryType);
        }

        public DeliveryLineDetail(int id, string moduleName, PageMode pageMode, Commodity commodity,
                                  DeliveryType deliveryType, List<DeliveryLine> deliveryLines,
                                  List<DeliveryLine> addDeliveryLines,
                                  List<DeliveryLine> updatedDeliveryLines,bool convertedWr = false)
            : base(pageMode, Properties.Resources.LineInfo)
        {
            InitializeComponent();
            ModuleName = moduleName;
            DeliveryType = deliveryType;
            VM = new DeliveryLineVM(id, commodity, deliveryLines, addDeliveryLines,
                                    updatedDeliveryLines, DeliveryType);
            BindData();
            ShowOrHideComponent(deliveryType, convertedWr);
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            dataGrid1.DataContext = VM.AllDeliveryPersonList.Where(c => c.IsDeleted == false).ToList();
            dataGrid1.Items.Refresh();
        }

        /// <summary>
        ///     根据提单类型显示或隐藏页面控件
        /// </summary>
        /// <param name="deliveryType"></param>
        private void ShowOrHideComponent(DeliveryType deliveryType, bool convertedWr = false)
        {
            //隐藏“原产地”，显示“数量已确认”
            label11.Visibility = Visibility.Collapsed;
            cbCountry.Visibility = Visibility.Collapsed;
            checkBox1.Visibility = Visibility.Visible;
            //数量、净重
            label12.Visibility = Visibility.Collapsed;
            label3.Visibility = Visibility.Visible;
            //显示“实际数量”，隐藏“毛重”
            label4.Visibility = Visibility.Visible;
            textBox3.Visibility = Visibility.Visible;
            label13.Visibility = Visibility.Collapsed;
            textBox7.Visibility = Visibility.Collapsed;
            textBox7.IsReadOnly = true;

            if (deliveryType != DeliveryType.InternalMDBOL)
            {
                label15.Visibility = Visibility.Collapsed;
                button1.Visibility = Visibility.Collapsed;
                dataGrid1.Visibility = Visibility.Collapsed;
            }

            switch (deliveryType)
            {
                case DeliveryType.InternalTDBOL: //内贸提单
                    break;
                case DeliveryType.InternalTDWW: //内贸仓单
                    break;
                case DeliveryType.ExternalTDBOL: //外贸提单
                    //隐藏卡号
                    label2.Visibility = Visibility.Collapsed;
                    textBox1.Visibility = Visibility.Collapsed;
                    //显示“原产地”，隐藏“数量已确认”
                    label11.Visibility = Visibility.Visible;
                    cbCountry.Visibility = Visibility.Visible;
                    checkBox1.Visibility = Visibility.Collapsed;
                    //数量、净重
                    label12.Visibility = Visibility.Visible;
                    label3.Visibility = Visibility.Collapsed;
                    //隐藏“实际数量”，显示“毛重”
                    label4.Visibility = Visibility.Collapsed;
                    textBox3.Visibility = Visibility.Collapsed;
                    textBox3.IsReadOnly = true;
                    label13.Visibility = Visibility.Visible;
                    textBox7.Visibility = Visibility.Visible;
                    textBox7.IsReadOnly = false;
                    labelTempUnitPrice.Visibility = Visibility.Collapsed;
                    currencyTextBoxTempUnitPrice.Visibility = Visibility.Collapsed;
                    break;
                case DeliveryType.ExternalTDWW: //外贸仓单
                    //显示“原产地”，隐藏“数量已确认”
                    label11.Visibility = Visibility.Visible;
                    cbCountry.Visibility = Visibility.Visible;
                    checkBox1.Visibility = Visibility.Collapsed;
                    //数量、净重
                    label12.Visibility = Visibility.Visible;
                    label3.Visibility = Visibility.Collapsed;
                    //隐藏“实际数量”，显示“毛重”
                    label4.Visibility = Visibility.Collapsed;
                    textBox3.Visibility = Visibility.Collapsed;
                    textBox3.IsReadOnly = true;
                    label13.Visibility = Visibility.Visible;
                    textBox7.Visibility = Visibility.Visible;
                    textBox7.IsReadOnly = false;
                    labelTempUnitPrice.Visibility = Visibility.Collapsed;
                    currencyTextBoxTempUnitPrice.Visibility = Visibility.Collapsed;
                    break;
                case DeliveryType.InternalMDBOL: //内贸发货单 - 提单
                    //显示“原产地”，隐藏“数量已确认”
                    label11.Visibility = Visibility.Collapsed;
                    cbCountry.Visibility = Visibility.Collapsed;
                    checkBox1.Visibility = Visibility.Visible;
                    //数量、净重
                    label12.Visibility = Visibility.Collapsed;
                    label3.Visibility = Visibility.Visible;
                    break;
                case DeliveryType.InternalMDWW: //内贸发货单 - 仓单
                    //显示“原产地”，隐藏“数量已确认”
                    label11.Visibility = Visibility.Collapsed;
                    cbCountry.Visibility = Visibility.Collapsed;
                    checkBox1.Visibility = Visibility.Visible;
                    //数量、净重
                    label12.Visibility = Visibility.Collapsed;
                    label3.Visibility = Visibility.Visible;
                    break;
                case DeliveryType.ExternalMDBOL: //外贸发货单 - 提单
                    //显示“原产地”，隐藏“数量已确认”
                    //隐藏卡号
                    label2.Visibility = Visibility.Collapsed;
                    textBox1.Visibility = Visibility.Collapsed;
                    label11.Visibility = Visibility.Visible;
                    cbCountry.Visibility = Visibility.Visible;
                    checkBox1.Visibility = Visibility.Collapsed;
                    //数量、净重
                    label12.Visibility = Visibility.Visible;
                    label13.Visibility = Visibility.Visible;
                    label3.Visibility = Visibility.Collapsed;
                    label4.Visibility = Visibility.Collapsed;

                    //隐藏“实际数量”，显示“毛重”
                    label4.Visibility = Visibility.Collapsed;
                    textBox3.Visibility = Visibility.Collapsed;
                    textBox3.IsReadOnly = true;
                    label13.Visibility = Visibility.Visible;
                    textBox7.Visibility = Visibility.Visible;
                    textBox7.IsReadOnly = false;
                    labelTempUnitPrice.Visibility = Visibility.Collapsed;
                    currencyTextBoxTempUnitPrice.Visibility = Visibility.Collapsed;
                    break;
                default: //外贸发货单 - 仓单
                    //显示“原产地”，隐藏“数量已确认”

                    label11.Visibility = Visibility.Visible;
                    cbCountry.Visibility = Visibility.Visible;
                    checkBox1.Visibility = Visibility.Collapsed;
                    //数量、净重
                    label12.Visibility = Visibility.Visible;
                    label13.Visibility = Visibility.Visible;
                    label3.Visibility = Visibility.Collapsed;
                    label4.Visibility = Visibility.Collapsed;

                    //隐藏“实际数量”，显示“毛重”
                    label4.Visibility = Visibility.Collapsed;
                    textBox3.Visibility = Visibility.Collapsed;
                    textBox3.IsReadOnly = true;
                    label13.Visibility = Visibility.Visible;
                    textBox7.Visibility = Visibility.Visible;
                    textBox7.IsReadOnly = false;
                    labelTempUnitPrice.Visibility = Visibility.Collapsed;
                    currencyTextBoxTempUnitPrice.Visibility = Visibility.Collapsed;
                    break;
            }

            if (convertedWr)
            {
                //提单转仓单
                //货运状态
                comboBox1.IsEnabled = false;
                //金属类型
                cbCmmodityType.IsEnabled = false;
                //金属品牌
                cbBrand.IsEnabled = false;
                //规格
                cbSpecification.IsEnabled = false;
                //净重
                textBox2.IsEnabled = false;
                //毛重
                textBox7.IsEnabled = false;
                //原产地
                cbCountry.IsEnabled = false;
                //捆数
                textBox5.IsEnabled = false;
                //备注
                textBox6.IsEnabled = false;
            }
        }

        private void CbCmmodityTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.LoadBrandAndSpecification();
        }


        protected override void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.Save();
                _saveStatus = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        #endregion

        #region 提货人Event

        private void DeliveryPersonCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void DeliveryPersonEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            var pd = new DeliveryPersonMsg(id, VM.AllDeliveryPersonList, VM.AddDeliveryPersonList,
                                           VM.UpdateDeliveryPersonList, PageMode.AddMode, ModuleName);
            pd.ShowDialog();
            Refresh();
        }

        private void DeliveryPersonDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            if (id != 0 &&
                MessageBox.Show(Properties.Resources.DeleteConfirmation, Properties.Resources.Delete,
                                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    VM.DelDeliveryPerson(id);
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

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            var pd = new DeliveryPersonMsg(VM.AllDeliveryPersonList, VM.AddDeliveryPersonList, PageMode.AddMode,
                                           ModuleName);
            pd.ShowDialog();
            Refresh();
        }

        public override void Refresh()
        {
            dataGrid1.DataContext = VM.AllDeliveryPersonList.Where(c => c.IsDeleted == false).ToList();
            dataGrid1.Items.Refresh();
        }

        #endregion
    }
}