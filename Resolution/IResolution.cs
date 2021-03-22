using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlathsRecordingSoftware.Resolution
{
   public interface IResolution
    {
        double ActualWidth { get; }
        double ActualHeight { get;  }
    }

    public interface IActualWidthAndHeight
    {
        event EventHandler<ResolutionEventArgs> WidthAndHeight;
    }


    public class ResolutionEventArgs : EventArgs
    {
        public ResolutionEventArgs(double width, double height)
        {
            ActualWidth = width;
            ActualHeight = height;
        }

        public double ActualWidth { get; set; }
        public double ActualHeight { get; set; }
    }
}
