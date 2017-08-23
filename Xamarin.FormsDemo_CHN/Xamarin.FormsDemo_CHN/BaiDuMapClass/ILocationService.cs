using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.FormsDemo_CHN.BaiDuMapClass
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        //public Coordinate Coordinate { get; internal set; }
        public double Direction { get;  set; }
        public double Altitude { get;  set; }
        public double Accuracy { get;  set; }
        public int Satellites { get;  set; }
        public string Type { get;  set; }
    }

    public class LocationFailedEventArgs : EventArgs
    {
        public string Message { get; }
        public LocationFailedEventArgs(string message)
        {
            Message = message;
        }
    }

    public interface ILocationService
    {
        void Start();
        void Stop();

        event EventHandler<LocationUpdatedEventArgs> LocationUpdated;
        event EventHandler<LocationFailedEventArgs> Failed;
    }
}
