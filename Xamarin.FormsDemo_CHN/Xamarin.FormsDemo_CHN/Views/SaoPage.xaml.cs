using Lamp.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.FormsDemo_CHN.Forms;
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

                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    zxing.IsAnalyzing = false;
                    zxing.IsScanning = false;
                    try
                    {

                       CrossLamp.Current.TurnOff();

                    }
                    catch (Exception)
                    {


                    }
                    // Show an alert
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");

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
                //  DisplayAlert("提示", "按钮事件", "确定");
                try
                {

                    if (!CrossLampState)
                    {
                        sender.Text = "关灯";
                        CrossLampState = true;
                        CrossLamp.Current.TurnOn();

                    }
                    else
                    {
                        sender.Text = "开灯";
                        CrossLampState = false;
                        CrossLamp.Current.TurnOff();
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

            //// The root page of your application
            Content = grid;

            //}
            //catch (Exception ex)
            //{

            //  // throw;

            //}
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
          

            base.OnDisappearing();
        }
    }
}
