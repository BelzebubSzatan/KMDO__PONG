using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace KMDO__PONG
{
    public class Player : ICanvasObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Canvas Canvas { get; set; }
        public Rectangle Shape { get; set; }
        public bool MousePlayer { get; set; }
        public int Points { get; set; }
        public Player(Canvas source, int width, int height, SolidColorBrush color, bool isPlayer = true)
        {
            Width = width;
            Height = height;
            Canvas = source;
            X = isPlayer ? 50 : Canvas.Width - 50 - width;
            Y = Canvas.Height / 2 - height / 2;
            Shape = new()
            {
                Width = width,
                Height = height,
                Fill = color,
            };
            Points = 0;
            Canvas.Children.Add(Shape);
            Draw();
        }
        public void Draw()
        {
            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
        }
        public void Reset()
        {
            X = MousePlayer ? 20 : Canvas.Width - 20 - Width;
            Y = Canvas.Height / 2 - Width / 2;
            Points = 0;
        }
    }
}
