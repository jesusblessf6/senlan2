using System;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel.Futures.LME;
using DBEntity;
using DBEntity.EnumEntity;
using Utility.Controls;

namespace Client.View.Futures.LME
{
    /// <summary>
    /// LMEPositionList.xaml 的交互逻辑
    /// </summary>
    public sealed partial class LMEPositionList
    {
        #region Member

        private const int PerPage = 20;

        #endregion

        #region Property

        public LMEPositionListVM VM { get; set; }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
            listGrid.ItemsSource = VM.LMEPositions;
            ControlShow();
        }

        public void ControlShow()
        {
            if (VM.IsLMEAgent)
            {
                listGrid.Columns[7].Visibility = Visibility.Visible;
                listGrid.Columns[8].Visibility = Visibility.Visible;
                listGrid.Columns[9].Visibility = Visibility.Visible;
            }
            else
            {
                listGrid.Columns[7].Visibility = Visibility.Hidden;
                listGrid.Columns[8].Visibility = Visibility.Hidden;
                listGrid.Columns[9].Visibility = Visibility.Hidden;
            }
        }

        #endregion

        public LMEPositionList(string moduleName, LMEPositionListVM vm)
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
            listGrid.ItemsSource = VM.LMEPositions;
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
            LMEPosition ld = VM.GetLMEPositionById(id);
            if (ld != null)
            {
                if (ld.CarryPositionId != null || ld.CarryPositionId > 0)
                {
                    var frm = new LMECarryPositionDetail(id, PageMode.EditMode);
                    RedirectTo(frm);
                }
                else
                {
                    var frm = new LMEPositionDetail(id, PageMode.EditMode);
                    RedirectTo(frm);
                }
            }
        }

        private void ListDeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int id = e.Parameter is int ? (int) e.Parameter : 0;
            LMEPosition ld = VM.GetLMEPositionById(id);
            try
            {
                MessageBoxResult result = MessageBox.Show(Properties.Resources.NullifyConfirm, Properties.Resources.LMEPosition, MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    if (ld.CarryPositionId != null || ld.CarryPositionId > 0)
                    {
                        VM.RemoveCarryPosition(id);
                    }
                    else
                    {
                        VM.Remove(id);
                    }
                    MessageBox.Show(Properties.Resources.NullifySuccessfully);
                }


                RedirectTo(new LMEPositionHome());
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.NullifyFailed);
            }
        }
    }
}