using System.Collections.Generic;
using System.Windows;
using Client.ViewModel.Physical.CommercialInvoices;
using DBEntity;

namespace Client.View.Physical.CommercialInvoices
{
    /// <summary>
    /// Interaction logic for LCDistribution.xaml
    /// </summary>
    public sealed partial class LCDistribution
    {
        public List<LCCIRel> AddRels { get; set; }
        public List<LCCIRel> DeleteRels { get; set; }

        public LetterOfCredit SelectLc { get; set; }

        public bool SaveStatus { get; set; }

        public LCDistributionVM VM { get; set; }

        public LCCIRel AddRel { get; set; }

        public LCDistribution(LetterOfCredit lc, List<LCCIRel> addRels, List<LCCIRel> deleteRels)
        {
            SelectLc = lc;
            AddRels = addRels;
            DeleteRels = deleteRels;
            InitializeComponent();
            VM = new LCDistributionVM(lc, addRels, deleteRels);
        }

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            if (VM.Amount > VM.AllowAmount)
            {
                MessageBox.Show("分配金额不能大于可用金额！");
                return;
            }
            if (VM.Amount <= 0)
            {
                MessageBox.Show("分配金额必须大于0！");
                return;
            }
            AddRel = new LCCIRel {AllocationAmount = VM.Amount, LCId = SelectLc.Id, LetterOfCredit = SelectLc};
            VM.SaveStatus = true;
            Close();
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            VM.SaveStatus = false;
            Close();
        }

        private void ObjectBaseWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ObjectBaseWindowLoaded(object sender, RoutedEventArgs e)
        {
            rootGrid.DataContext = VM;
            dataGrid1.ItemsSource = VM.DisplayLc;
            dataGrid1.Items.Refresh();
        }
    }
}
