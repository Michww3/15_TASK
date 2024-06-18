using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting.Contexts;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace _15_TASK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Connection_Button_Click(object sender, RoutedEventArgs e)
        {
            string stateText = stateTrack.Text;

            if (stateText == "Connection to the database has been established")
            {
                MessageBox.Show("Connection to DB is successfully");
                return;
            }

            stateTrack.Text = "Start conncetion to DB";

            Connection_Button.IsEnabled = false;
            Disconnet_Button.IsEnabled = false;
            await Task.Delay(5000);
            Connection_Button.IsEnabled = true;
            Disconnet_Button.IsEnabled = true;

            stateTrack.Text = "Connection to the database has been established";
            StartTimer();
        }

        private async void Disconnet_Button_Click(object sender, RoutedEventArgs e)
        {
            StopTimer();
            string stateText = stateTrack.Text;
            if (stateText == "Connect to DB to track connection state" || stateText == "Connection to the database has been closed")
            {
                MessageBox.Show("You are not have connection to DB");
                return;
            }

            stateTrack.Text = "Start disconnection from DB";

            Connection_Button.IsEnabled = false;
            Disconnet_Button.IsEnabled = false;
            await Task.Delay(5000);
            Connection_Button.IsEnabled = true;
            Disconnet_Button.IsEnabled = true;

            stateTrack.Text = "Connection to the database has been closed";
        }
        private void StartTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += TimerTick;
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            stateTrack.Text = "Data received";
        }
        private void StopTimer()
        {
            timer.Stop();
        }
    }
}
