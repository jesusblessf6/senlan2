using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Utility.Controls
{
    /// <summary>
    /// Interaction logic for PagingControl.xaml
    /// </summary>
    public partial class PagingControl
    {
        #region Member

        private readonly Button[] _pageBts;
        private int _curPageIdx = 1;
        public int CurPageNo = 1;
        private int _curPageOneNo = 1;
        public ICollection<object> Data;
        private int _pageCount = 1;
        public int RecCount;
        public int RecCountPerPage = 20;

        public event EventHandler<PagingEventArgs> OnNewPage;

        #endregion

        #region Property

        public int PageCount { get; set; }

        #endregion

        #region Constructor

        public PagingControl()
        {
            InitializeComponent();
            _pageBts = new[] {btPageOne, btPageTwo, btPageThree, btPageFour, btPageFive};
            ReDrawUI();
        }

        #endregion

        #region Method

        public void Init(int recCnt, int recPerPage)
        {
            RecCount = recCnt;
            RecCountPerPage = recPerPage;
            _pageCount = (RecCount%RecCountPerPage == 0) ? RecCount/RecCountPerPage : RecCount/RecCountPerPage + 1;
            
            MoveToPage(CurPageNo);
        }

        public void SetRecCount(int recCnt)
        {
            RecCount = recCnt;
            _pageCount = (RecCount%RecCountPerPage == 0) ? RecCount/RecCountPerPage : RecCount/RecCountPerPage + 1;
            MoveToPage(1);
        }

        public void Reset()
        {
            MoveToPage(1);
        }

        private void MoveToPage(int pageNo)
        {
            if (pageNo > _pageCount)
            {
                pageNo = _pageCount;
            }
            if (pageNo < 1)
            {
                pageNo = 1;
            }

            CurPageNo = pageNo;

            var e = new PagingEventArgs((pageNo - 1)*RecCountPerPage + 1, pageNo*RecCountPerPage);
            // Call our virtual method notifying our object that the event
            // occurred. If no type overrides this method, our object will
            // notify all the objects that registered interest in the event
            OnPageMoving(e);

            ReDrawUI();
        }

        private void ReDrawUI()
        {
            if (CurPageNo == 1 || CurPageNo == 2)
            {
                _curPageOneNo = 1;
            }
            else if (CurPageNo == _pageCount || CurPageNo == _pageCount - 1)
            {
                _curPageOneNo = _pageCount - 4;
                if (_curPageOneNo <= 0)
                    _curPageOneNo = 1;
            }
            else
            {
                _curPageOneNo = CurPageNo - 2;
            }

            int btPageNo = _curPageOneNo;
            foreach (Button bt in _pageBts)
            {
                if (btPageNo <= _pageCount)
                {
                    bt.IsEnabled = true;
                    bt.Visibility = Visibility.Visible;
                    bt.FontWeight = FontWeights.Normal;
                    bt.Content = btPageNo++;
                }
                else
                {
                    bt.Visibility = Visibility.Collapsed;
                }
            }

            if (CurPageNo == 1)
            {
                btPreviousPage.IsEnabled = false;
                btFirstPage.IsEnabled = false;
            }
            else
            {
                btPreviousPage.IsEnabled = true;
                btFirstPage.IsEnabled = true;
            }

            if (CurPageNo >= _pageCount)
            {
                btNextPage.IsEnabled = false;
                btLastPage.IsEnabled = false;
            }
            else
            {
                btNextPage.IsEnabled = true;
                btLastPage.IsEnabled = true;
            }

            _curPageIdx = CurPageNo - _curPageOneNo;
            _pageBts[_curPageIdx].FontWeight = FontWeights.Bold;
            _pageBts[_curPageIdx].IsEnabled = false;

            lblPageCount.Content = _pageCount;
        }

        #endregion

        #region Event

        protected virtual void OnPageMoving(PagingEventArgs e)
        {
            // Copy a reference to the delegate field now into a temporary field for thread safety
            EventHandler<PagingEventArgs> eh = Interlocked.CompareExchange(ref OnNewPage, null, null);
            // If any methods registered interest with our event, notify them
            if (eh != null)
            {
                eh(this, e);
            }
        }

        private void BtPageOneClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(_curPageOneNo);
        }

        private void BtPageTwoClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(_curPageOneNo + 1);
        }

        private void BtPageThreeClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(_curPageOneNo + 2);
        }

        private void BtPageFourClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(_curPageOneNo + 3);
        }

        private void BtPageFiveClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(_curPageOneNo + 4);
        }

        private void BtPreviousPageClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(CurPageNo - 1);
        }

        private void BtNextPageClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(CurPageNo + 1);
        }

        private void BtFirstPageClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(1);
        }

        private void BtLastPageClick(object sender, RoutedEventArgs e)
        {
            MoveToPage(_pageCount);
        }

        #endregion
    }

    // record number start from 1
    public class PagingEventArgs : EventArgs
    {
        private readonly int _mFrom, _mTo;

        public PagingEventArgs(int from, int to)
        {
            _mFrom = from;
            _mTo = to;
        }

        public int From
        {
            get { return _mFrom; }
        }

        public int To
        {
            get { return _mTo; }
        }
    }
}