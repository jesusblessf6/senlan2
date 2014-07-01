using System.Windows;
using Client.ViewModel.Futures.HedgeGroups;
using DBEntity.EnumEntity;

namespace Client.View.Futures.HedgeGroups
{
    /// <summary>
    /// Interaction logic for HedgeGroupHome.xaml
    /// </summary>
    public sealed partial class HedgeGroupHome
    {
        #region Property

        public HedgeGroupHomeVM VM { get; set; }

        #endregion

        #region Constructor

        public HedgeGroupHome()
        {
            InitializeComponent();
            ModuleName = "HedgeGroup";
            VM = new HedgeGroupHomeVM();
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion

        #region Event

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(new HedgeGroupDetail(PageMode.AddMode));
        }

        private void Button7Click(object sender, RoutedEventArgs e)
        {
            VM.Reset();
        }

        private void Button6Click(object sender, RoutedEventArgs e)
        {
            var c = VM.GetConditions(HedgeGroupSearchType.Free);
            RedirectTo(new HedgeGroupList(c));
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            var c = VM.GetConditions(HedgeGroupSearchType.CurrentMonth);
            RedirectTo(new HedgeGroupList(c));
        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            var c = VM.GetConditions(HedgeGroupSearchType.LastMonth);
            RedirectTo(new HedgeGroupList(c));
        }

        private void Button4Click(object sender, RoutedEventArgs e)
        {
            var c = VM.GetConditions(HedgeGroupSearchType.CurrentYear);
            RedirectTo(new HedgeGroupList(c));
        }

        private void Button5Click(object sender, RoutedEventArgs e)
        {
            var c = VM.GetConditions(HedgeGroupSearchType.LastYear);
            RedirectTo(new HedgeGroupList(c));
        }

        #endregion
    }
}
