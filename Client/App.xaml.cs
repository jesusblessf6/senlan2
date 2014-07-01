using System.Globalization;
using Infralution.Localization.Wpf;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            CultureManager.UICulture = new CultureInfo("zh-CN");
            base.OnStartup(e);
        }
    }
}