using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.FormsDemo_CHN.Models;

namespace Xamarin.FormsDemo_CHN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
       
        public UserPage()
        {
            InitializeComponent();
            Title = "用户信息";
            List<MuenModel> list = new List<MuenModel>();
            list.Add(new MuenModel { Name = "我的二维码", Url = "这里是中文" });
            list.Add(new MuenModel { Name = "我的钱包", Url = "sss" });
            list.Add(new MuenModel { Name = "我的记录", Url = "sss" });
            list.Add(new MuenModel { Name = "我的优惠", Url = "sss" });
            list.Add(new MuenModel { Name = "我的订单", Url = "sss" });
            listView.ItemsSource = list;
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MuenModel;
            if (item.Name.Equals("我的二维码"))
            {
              await  Navigation.PushAsync(new BarcodePage(item.Url));
            }
            else
            {

                var date = await DisplayAlert("提示", item.Name, "同意", "取消");
                await DisplayAlert("提示", "提示内容", date.ToString());
            }
        }
    }
}