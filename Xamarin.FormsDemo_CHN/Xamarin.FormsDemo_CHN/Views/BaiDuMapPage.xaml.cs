using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.FormsDemo_CHN.Forms;

namespace Xamarin.FormsDemo_CHN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaiDuMapPage : ContentPage
    {
        public BaiDuMapPage()
        {
            InitializeComponent();
            
        }

        private void btnTrack_Clicked(object sender, EventArgs e)
        {
            if (map.ShowUserLocation)
            {
                map.UserTrackingMode = UserTrackingMode.None;
                map.ShowUserLocation = false;
            }
            else
            {
                map.UserTrackingMode = UserTrackingMode.Follow;
                map.ShowUserLocation = true;
            }
            //map.Width  = "1545"
        }
    }
}