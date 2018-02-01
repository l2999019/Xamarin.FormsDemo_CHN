using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FormsDemo_CHN.CustomCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutgoingViewCell : ViewCell
    {
        public OutgoingViewCell()
        {
            InitializeComponent();
        }
    }
}