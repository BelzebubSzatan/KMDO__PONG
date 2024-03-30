using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KMDO__PONG {
    public class PowerUp {
        public Canvas Canvas { get; set; }
        private Ellipse? shape = null;
        private List<Ball> Balls;
        private Ball mainBall;
        double X { get; set; }
        double Y { get; set; }
        public bool alreadyAdded { get; set; }
        public PowerUp(Canvas canvas, ref List<Ball> balls) {
            Canvas = canvas;
            Balls = balls;
            mainBall = balls[0];
            alreadyAdded = false;
            RelocateShape();
        }

        public void Draw() {
            shape = new Ellipse() {
                Width = 100,
                Height = 100,
                Fill = new SolidColorBrush(Colors.Aqua)
            };
            Canvas.SetLeft(shape, X - 50);
            Canvas.SetTop(shape, Y - 50);
            Canvas.Children.Add(shape);
        }
        private void RelocateShape() {
            Random r = new();
            X = r.Next(200, (int)Canvas.Width - 200);
            Y = r.Next(100, (int)Canvas.Height - 100);
            Draw();
        }
        public async void CheckCollisionBetweenBallAndPowerUp() {
            if (CheckDistanceBetweenBallAndPowerUp(mainBall.X, mainBall.Y, 10, X, Y, 50) && shape is not null) {
                if (!alreadyAdded) {
                    Balls.Add(new Ball(10, 10, Canvas));
                    alreadyAdded = true;
                    Canvas.Children.Remove(shape);
                    shape = null;
                    await Task.Delay(5000);
                    RelocateShape();
                }
            } else {
                alreadyAdded = false;
            }
        }
        private static bool CheckDistanceBetweenBallAndPowerUp(double x1, double y1, double r1, double x2, double y2, double r2) {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) < r1 + r2;
        }
    }
}
