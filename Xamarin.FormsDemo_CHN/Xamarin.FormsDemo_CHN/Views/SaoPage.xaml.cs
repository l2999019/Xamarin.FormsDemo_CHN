using Lamp.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.FormsDemo_CHN.Forms;
using Xamarin.FormsDemo_CHN.Helpers;
using ZXing.Net.Mobile.Forms;

namespace Xamarin.FormsDemo_CHN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaoPage : ContentPage
    {

        ZXingScannerView zxing;
        MyZXingOverlay overlay;
        bool CrossLampState = false;

        public SaoPage() : base()
        {
            //try
            //{

            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
           
            zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () =>
                {
                    zxing.IsAnalyzing = false;
                    zxing.IsScanning = false;
                    try
                    {

                        zxing.IsTorchOn = false;

                    }
                    catch (Exception)
                    {


                    }
                    if (ToolsClass.IsUrl(result.Text))
                    {
                        //Navigation.RemovePage(this);
                        await Navigation.PushAsync(new WebViewPage(result.Text));
                    }
                    else
                    {
                        await DisplayAlert("二维码的值为：", result.Text, "确定");
                    }
                    // Show an alert


                    // Navigate away
                    await Navigation.PopAsync();
                });

            overlay = new MyZXingOverlay
            {
                TopText = "请对准二维码",
                BottomText = "阴暗天气建议打开闪光灯",
                ShowFlashButton = true,
                ButtonText = "开灯"
            };
            overlay.FlashButtonClicked += (sender, e) =>
            {
                try
                {

                    if (!zxing.IsTorchOn)
                    {
                        sender.Text = "关灯";
                        //CrossLampState = true;
                        zxing.IsTorchOn = true;

                    }
                    else
                    {
                        sender.Text = "开灯";
                        zxing.IsTorchOn = false;
                    }

                }
                catch (Exception)
                {


                }

            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxing);
            grid.Children.Add(overlay);
            Content = grid;
        }

        private void Overlay_FlashButtonClicked(Button sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;

        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;
            zxing.IsTorchOn = false;

            base.OnDisappearing();
        }
    }
}
