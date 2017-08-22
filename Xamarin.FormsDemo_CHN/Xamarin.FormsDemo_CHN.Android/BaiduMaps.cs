using Android.App;
using Com.Baidu.Mapapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Xamarin
{
    public class BaiduMaps
    {
        public static void Init(string APIKey)
        {
            SDKInitializer.Initialize(Application.Context);
        }
    }
}
