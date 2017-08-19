using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FormsDemo_CHN.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage (string url)
		{
			InitializeComponent ();
            
            Browser.Source = url;
            //LoadingProgress.Scale = 1;
           
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await LoadingProgress.ProgressTo(.9, 900, Easing.SpringIn);
        }
        private async  void Browser_Navigating(object sender, WebNavigatingEventArgs e)
        {
            LoadingProgress.IsVisible = true;
            await LoadingProgress.ProgressTo(.9, 900, Easing.SpringIn);
        }

        private void Browser_Navigated(object sender, WebNavigatedEventArgs e)
        {
            LoadingProgress.IsVisible = false;
            LoadingProgress.Progress = .2;
            
        }


       
    }
}