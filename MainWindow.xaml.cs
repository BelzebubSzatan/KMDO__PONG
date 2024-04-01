using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KMDO__PONG {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        DispatcherTimer timer;
        List<Ball> balls = new();
        Ball ball;
        PowerUp powerUp;
        Player mousePlayer, keyboardPlayer;
        public MainWindow() {
            InitializeComponent();
            ball = new(10, 10, MainCanavs);
            balls.Add(ball);
            powerUp = new(MainCanavs, ref balls);
            mousePlayer = new(MainCanavs, 10, 100, new SolidColorBrush(Colors.White), false);
            keyboardPlayer = new(MainCanavs, 10, 100, new SolidColorBrush(Colors.White), true);
            timer = new() {
                Interval = TimeSpan.FromMilliseconds(16)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e) {
            for (int i = 0; i < balls.Count; i++) {
                Ball item = balls[i];
                powerUp.CheckCollisionBetweenBallAndPowerUp();
                item.Move();
                if (item.X <= 0) {
                    mousePlayer.Points += 1;
                    UpdateScores();
                    if (item == ball)
                        item.Reset();
                    else {
                        balls.Remove(item);
                        MainCanavs.Children.Remove(item.Shape);
                    }
                }
                if (item.X >= item.Canvas.Width) {
                    keyboardPlayer.Points += 1;
                    UpdateScores();
                    if (item == ball)
                        item.Reset();
                    else {
                        balls.Remove(item);
                        MainCanavs.Children.Remove(item.Shape);
                    }
                }
                if (item.Y >= keyboardPlayer.Y && item.Y <= keyboardPlayer.Y + keyboardPlayer.Height && item.X - item.Width <= keyboardPlayer.X + keyboardPlayer.Width && item.X - item.Width >= keyboardPlayer.X) {
                    item.DirectionX *= -1;
                }
                if (item.Y >= mousePlayer.Y && item.Y <= mousePlayer.Y + mousePlayer.Height && item.X - item.Width >= mousePlayer.X - item.Width && item.X + item.Width - item.Width <= mousePlayer.X + mousePlayer.Width) {
                    item.DirectionX *= -1;
                }
            }
        }
        private void UpdateScores() {
            KeyboardPlayer.Content = keyboardPlayer.Points.ToString();
            MousePlayer.Content = mousePlayer.Points.ToString();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Escape:
                    this.Close();
                    break;
                case Key.W:
                    if (keyboardPlayer.Y <= 0)
                        return;
                    keyboardPlayer.Y -= 10;
                    keyboardPlayer.Draw();
                    break;
                case Key.S:
                    if (keyboardPlayer.Y + keyboardPlayer.Height >= MainCanavs.Height)
                        return;
                    keyboardPlayer.Y += 10;
                    keyboardPlayer.Draw();
                    break;
                case Key.R:
                    mousePlayer.Reset();
                    keyboardPlayer.Reset();
                    ball.Reset();
                    UpdateScores();
                    for (int i = 1; i < balls.Count; ++i) {
                        MainCanavs.Children.Remove(balls[i].Shape);
                        balls.Remove(balls[i]);
                    }
                    break;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e) {
            if (Mouse.GetPosition(this).Y + mousePlayer.Height >= MainCanavs.Height)
                return;
            mousePlayer.Y = Mouse.GetPosition(this).Y;
            mousePlayer.Draw();
        }
    }
}