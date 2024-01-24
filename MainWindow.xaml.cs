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

namespace KMDO__PONG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Player mousePlayer, keyboardPlayer;
        public MainWindow()
        {
            InitializeComponent();
            mousePlayer = new(MainCanavs, 10, 100, new SolidColorBrush(Colors.White), false);
            keyboardPlayer = new(MainCanavs, 10, 100, new SolidColorBrush(Colors.White), true);
            timer = new();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key) 
            {
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
                    if(keyboardPlayer.Y +keyboardPlayer.Height>=MainCanavs.Height) 
                        return;
                    keyboardPlayer.Y += 10;
                    keyboardPlayer.Draw();
                    break;
                case Key.R:
                    mousePlayer.Reset();
                    keyboardPlayer.Reset();
                    break;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.GetPosition(this).Y + mousePlayer.Height >= MainCanavs.Height)
                return;
            mousePlayer.Y = Mouse.GetPosition(this).Y;
            mousePlayer.Draw();
        }
    }
}