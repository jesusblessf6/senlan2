using System.Windows;

namespace Client.View.Futures.HedgeGroups
{
    /// <summary>
    /// Interaction logic for AssignedQuantityWindow.xaml
    /// </summary>
    public partial class AssignedQuantityWindow
    {
        public decimal AssignedQuantity { get; set; }

        public AssignedQuantityWindow(decimal available)
        {
            InitializeComponent();
            currencyTextBox1.Text = available.ToString("N2");
            currencyTextBox1.Focus();
            currencyTextBox1.SelectAll();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            AssignedQuantity = -1;
            Close();
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            decimal qty;
            if(!decimal.TryParse(currencyTextBox1.Text, out qty))
            {
                MessageBox.Show(ResHedgeGroup.InputError);
                return;
            }
            AssignedQuantity = qty;
            Close();
        }
    }
}
