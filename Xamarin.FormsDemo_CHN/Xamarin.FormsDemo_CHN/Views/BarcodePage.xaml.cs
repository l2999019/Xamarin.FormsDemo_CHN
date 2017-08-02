using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Xamarin.FormsDemo_CHN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodePage : ContentPage
    {
        ZXingBarcodeImageView barcode;

        public BarcodePage(string CodeContext)
        {
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            ///this
            var date = barcode.BarcodeOptions.Hints.ContainsKey(ZXing.EncodeHintType.CHARACTER_SET);
            if (!date)
            {
                barcode.BarcodeOptions.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8");
            }
            ///End
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = CodeContext;

            Content = barcode;
        }
    }
}