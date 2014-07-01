using Client.ViewModel.SystemSetting.DataDictSetting;
using DBEntity.EnumEntity;

namespace Client.View.SystemSetting.DataDictSetting
{
    /// <summary>
    /// Interaction logic for CountryDetail.xaml
    /// </summary>
    public sealed partial class CountryDetail
    {
        #region Constructor

        public CountryDetail()
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new CountryDetailVM();
            BindData();
        }

        public CountryDetail(PageMode pageMode)
            : base(pageMode, Properties.Resources.OriginCountry)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new CountryDetailVM();
            BindData();
        }

        public CountryDetail(int countryId, PageMode pageMode)
            : base(pageMode, Properties.Resources.OriginCountry)
        {
            InitializeComponent();
            ModuleName = "DataDictSetting";
            VM = new CountryDetailVM(countryId);
            BindData();
        }

        #endregion

        #region Method

        public override void BindData()
        {
            rootGrid.DataContext = VM;
        }

        #endregion
    }
}