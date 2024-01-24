using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        public bool IsPlayer { get; set; }
        public int Points { get; set; }
        public void Draw()
        {

        }
        public void Reset()
        {

        }
    }
}
