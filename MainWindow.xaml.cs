using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Windows.Controls.Primitives;

namespace _15_TASK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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
            //Parallel.Invoke(ConnectionToDB, SetPing);

            stateTrack.Text = "Start conncetion to DB";

            Connection_Button.IsEnabled = false;
            Disconnet_Button.IsEnabled = false;
            await Task.Delay(5000);
            Connection_Button.IsEnabled = true;
            Disconnet_Button.IsEnabled = true;
            //Thread.Sleep(5000);

            stateTrack.Text = "Connection to the database has been established";
        }

        private async void Disconnet_Button_Click(object sender, RoutedEventArgs e)
        {
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




        //void SetPing()
        //{
        //    Thread.Sleep(5000);
        //}
        //void ConnectionToDB()
        //{
        //    MessageBox.Show($"Start connecting to DB");
        //}
    }
}
