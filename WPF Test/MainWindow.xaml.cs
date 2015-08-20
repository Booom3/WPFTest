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
using System.Windows.Threading;

namespace WPF_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //The dick factory
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            //Dicks are made here
            for (int i = 0; i < Math.Max((int) Math.Ceiling( goodTimerCounter / 200f), 1); i++)
            {
                StringBuilder strng = new StringBuilder(DickSelection.SelectedValue.ToString());
                strng[rnd.Next(strng.Length)] = (char)('a' + rnd.Next(26));
                strng.Append(" ");
                if (rnd.Next(101) < 60)
                {
                    StringBuilder fullstr = new StringBuilder(Dicksbox.Text);
                    fullstr.Insert(rnd.Next(fullstr.Length), strng);
                    Dicksbox.Text = fullstr.ToString();
                }
                else
                    Dicksbox.Text += strng;
            }
        }

        //Don't tell anyone about this function ok?
        private int secretCounter = 0;
        private void SecretButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("shhhhhh");
            DicksMessage.Text += (secretCounter > 0 ? "h" : "s");
            secretCounter++;
        }

        private void BadButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                TerribleBox.Text = i.ToString();
                System.Threading.Thread.Sleep(1);
            }
        }

        //Good, bad, I'm just a timer
        private int goodTimerCounter = 0;
        const int goodTimerMax = 1000;
        private DispatcherTimer goodTimer;
        private void GoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (goodTimer != null)
            {
                if (goodTimerCounter < goodTimerMax)
                {
                    if (goodTimer.IsEnabled)
                        goodTimer.Stop();
                    else
                        goodTimer.Start();
                    return;
                }
            }

            goodTimerCounter = 0;
            goodTimer = new DispatcherTimer();
            goodTimer.Interval = TimeSpan.FromMilliseconds(20);
            goodTimer.Tick += GoodButtonTimer;
            goodTimer.Start();
        }

        void GoodButtonTimer(object sender, EventArgs e)
        {
            goodTimerCounter++;
            GoodBox.Text = goodTimerCounter.ToString();
            if (goodTimerCounter >= goodTimerMax)
                goodTimer.Stop();
        }
    }
}
