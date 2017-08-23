using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            map.ShowCompass = true;
            map.Loaded += Map_Loaded;
         
        }

        private void Map_Loaded(object sender, EventArgs e)
        {
            InitLocationService();
        }

        public void InitLocationService()
        {
            //map.LocationService.LocationUpdated += (_, e) => {
            //    Debug.WriteLine("LocationUpdated: " + e.Direction);
            //    //if (!moved)
            //    //{
            //    //    map.Center = e.Coordinate;
            //    //    moved = true;
            //    //}
            //};

            //map.LocationService.Failed += (_, e) => {
            //    Debug.WriteLine("Location failed: " + e.Message);
            //};

            map.LocationService.Start();
        }
        private void btnTrack_Clicked(object sender, EventArgs e)
        {
            map.CompassPosition = new Point(10, 10);
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