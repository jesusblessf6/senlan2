using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Client.ViewModel.Finance.LetterOfCredits;
using DBEntity;
using DBEntity.EnumEntity;
using Infralution.Localization.Wpf;
using Utility.Controls;
using Utility.ErrorManagement;

namespace Client.View.Finance.LetterOfCredits
{
    /// <summary>
    /// LetterOfCreditList.xaml 的交互逻辑
    /// </summary>
    public sealed partial class LetterOfCreditList
    {
        #region Member

        private const int PerPage = 10;

        #endregion

        #region Property

        public LetterOfCreditListVM VM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            listGrid.ItemsSource = VM.LetterOfCredits;
        }

        #endregion

        public LetterOfCreditList(string moduleName, LetterOfCreditListVM vm)
        {
            InitializeComponent();
            ModuleName = moduleName;
            if (vm == null)
                return;
            VM = vm;
            pagerList.OnNewPage += pagerList_OnNewPage;
            pagerList.Init(VM.ListTotleCount, PerPage);
            BindData();
        }

        private void pagerList_OnNewPage(object sender, PagingEventArgs e)
        {
            VM.ListFrom = e.From;
            VM.ListTo = e.To;
            VM.LoadList();
            listGrid.ItemsSource = VM.LetterOfCredits;
            listGrid.Items.Refresh();
        }

        private void ListEditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ListDeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ListEditExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            LetterOfCredit lc = VM.GetLetterOfCreditById(id);
            if (lc != null)
            {
                if (lc.PorS == 1)
                {
                    var frm = new IssueLCDetail(id, PageMode.EditMode);
                    RedirectTo(frm);
                }
                else if (lc.PorS == 2)
                {
                    var frm = new PresentationDetail(id, PageMode.EditMode);
                    RedirectTo(frm);
                }
            }
        }

        private void ListDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            try
            {
                MessageBoxResult result = MessageBox.Show(Properties.Resources.NullifyConfirm, ResLetterOfCredit.NullifyLoC, MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    VM.Remove(id);
                    MessageBox.Show(Properties.Resources.NullifySuccessfully);
                    RedirectTo(new LetterOfCreditHome());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsgManager.GetClientErrMsg(ex, CultureManager.UICulture));
            }
        }

        private void ListGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (pagerList.CurPageNo - 1)*10 + e.Row.GetIndex() + 1;
        }
    }
}