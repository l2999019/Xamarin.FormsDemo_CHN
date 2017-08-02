using Xamarin.FormsDemo_CHN.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamarin.FormsDemo_CHN
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new MasterDetailPage
            {
                Master = new NavigationPage(new UserPage())
                {
                    Title = "用户信息",
                    Icon = Device.OnPlatform("tab_about.png", null, null)
                } ,
                Detail = new NavigationPage(new ItemsPage())
                {
                    Title = "列表",
                    Icon = Device.OnPlatform("tab_feed.png", null, null)
                }
            };
        }
    }
}
