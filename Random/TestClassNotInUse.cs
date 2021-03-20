using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MyPlathsRecordingSoftware.Random
{
    public class TestClassNotInUse
    {
        public TestClassNotInUse()
        {
            Malakas.GetPosition();
        }

        void myMethod()
        {
            Rectangle exampleRectangle1 = new Rectangle();

            exampleRectangle1.Width = 150;

            exampleRectangle1.Height = 150;

            exampleRectangle1.RadiusX = 10;

            exampleRectangle1.RadiusY = 10;

            // Create a SolidColorBrush and use it to

            // paint the rectangle.

            SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);

            exampleRectangle1.Stroke = Brushes.Red;

            exampleRectangle1.StrokeThickness = 4;

            exampleRectangle1.Fill = myBrush;

            

        }
    }

    public class Malakas
    {
        public static void GetPosition()
        {
            throw new NotImplementedException();
        }
    }
}


