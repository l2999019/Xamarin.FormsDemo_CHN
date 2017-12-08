using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FormsDemo_CHN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SheBeiInfoPage : ContentPage
    {
        List<dynamic> date = new List<dynamic>();
        public SheBeiInfoPage()
        {
            InitializeComponent();
            AddPhoneInfo();
            ItemsListView.ItemsSource = date;
        }

        public void AddPhoneInfo()
        {
            string model = CrossDeviceInfo.Current.Model;
            string Version = CrossDeviceInfo.Current.Version;
            string VersionNumber = CrossDeviceInfo.Current.VersionNumber.ToString();
            string Platform = CrossDeviceInfo.Current.Platform.ToString();
            date.Add(new { TextName = model, Name = "设备名称" });
            date.Add(new { TextName = Version, Name = "设备版本" });
            date.Add(new { TextName = VersionNumber, Name = "设备版本号" });
            date.Add(new { TextName = Platform, Name = "设备平台" });

        }

        
    }
}