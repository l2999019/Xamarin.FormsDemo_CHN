
using Xamarin.Forms;

namespace Xamarin.FormsDemo_CHN.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new WebViewPage("http://www.cnblogs.com/GuZhenYin/"));
        }
    }
}
