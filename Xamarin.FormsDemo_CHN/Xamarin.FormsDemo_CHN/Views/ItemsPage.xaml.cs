using System;

using Xamarin.FormsDemo_CHN.Models;
using Xamarin.FormsDemo_CHN.ViewModels;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using ZXing.Mobile;
using System.Collections.Generic;

namespace Xamarin.FormsDemo_CHN.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //  await Navigation.PushAsync(new NewItemPage());

            //var scanPage = new ZXingScannerPage() { DefaultOverlayBottomText = "asdasd",
            //    DefaultOverlayShowFlashButton = true,
            //    DefaultOverlayTopText = "asdasd",
            //    BackgroundColor = Color.Red,

            //};
            //scanPage.OnScanResult += (result) => {
            //    // Stop scanning
            //    scanPage.IsScanning = false;

            //    // Pop the page and show the result
            //    Device.BeginInvokeOnMainThread(() => {
            //        Navigation.PopAsync();
            //        DisplayAlert("扫出来的内容", result.Text, "好");
            //    });
            //};

            //// Navigate to our scanner page
            //await Navigation.PushAsync(scanPage);

            //var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            //options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
            //        ZXing.BarcodeFormat.QR_CODE,
                   
            //    };


            //var scanPage = new ZXingScannerPage(options) {
            //    DefaultOverlayTopText = "asdsad",
            //    DefaultOverlayBottomText = "asdasdsss"

            //};

            //scanPage.OnScanResult += (result) => {
            //    // Stop scanning
            //    scanPage.IsScanning = false;

            //    // Pop the page and show the result
            //    Device.BeginInvokeOnMainThread(() => {
            //        DisplayAlert("Scanned Barcode", result.Text, "OK");
            //    });
            //};

            await Navigation.PushAsync(new SaoPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
