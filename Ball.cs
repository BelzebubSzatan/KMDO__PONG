using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KMDO__PONG
{
    public class Ball : ICanvasObject
    {
        public double X { get ; set ; }
        public double Y { get ; set ; }
        public int Width { get ; set ; }
        public int Height { get ; set ; }
        public Canvas Canvas { get ; set ; }
        public double Angle { get; set; }
        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
        public double Speed { get; set; }
        public Ellipse Shape { get; set; }

        public Ball(int width, int height, Canvas canvas)
        {
            Width = width;
            Height = height;
            Canvas = canvas;
            Shape = new()
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(Colors.White)
            };
            Speed = 3f;
            DirectionX = 1;
            DirectionY = 1;
            Random r = new();
            Angle = r.Next(30, 60) * Math.PI / 180;
            Canvas.Children.Add(Shape);
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
