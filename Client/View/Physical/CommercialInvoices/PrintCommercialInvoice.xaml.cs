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
using Client.ViewModel.Physical.CommercialInvoices;
using DBEntity.EnumEntity;

namespace Client.View.Physical.CommercialInvoices
{
    /// <summary>
    /// Interaction logic for PrintCommercialInvoice.xaml
    /// </summary>
    public sealed partial class PrintCommercialInvoice
    {
        #region Property
        public PrintCommercialInvoiceVM PCVM { get; set; }
        #endregion

        #region Constructor
        public PrintCommercialInvoice(PageMode pageMode,string moduleName,int commercialInvoiceId, int commercialInvoiceType)
            : base(pageMode, "打印商业发票")
        {
            InitializeComponent();
            ModuleName = moduleName;
            PCVM = new PrintCommercialInvoiceVM(commercialInvoiceId, commercialInvoiceType);
            BindData();
        }
        #endregion
        public override void BindData()
        {
            rootGrid.DataContext = PCVM;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = comboBox1.Text.Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    PCVM.PrintCommercialInvoice(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
