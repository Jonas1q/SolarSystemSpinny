using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace SolarSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Planet Earth;
        Planet Mars;
        Planet Venus;
        Planet Mercury;
        Planet Sun;
        private static Timer otherTimer;


        public MainWindow()
        {
            InitializeComponent();
            
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(10);
            
        }

        //for DispatcherTimer that I commented out above
        public void MoveEarth(object sender, EventArgs e)
        {
            Earth.MovePlanet();
        }
        public void MoveMars(object sender, EventArgs e)
        {
            Mars.MovePlanet();
        }

        public void MoveVenus(object sender, EventArgs e)
        {
            Venus.MovePlanet();
        }
        public void MoveMercury(object sender, EventArgs e)
        {
            Mercury.MovePlanet();
        }

        public void MoveSun(object sender, EventArgs e)
        {
            Sun.MovePlanet();
        }


        //For SystemTimer
        public void MoveEarthTimer(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Earth.MovePlanet();
            });
        }

        public void MoveVenusTimer(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Venus.MovePlanet();
            });
        }
        public void MoveMercuryTimer(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Mercury.MovePlanet();
            });
        }


        public void MoveMarsTimer(object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Mars.MovePlanet();
            });
        }

        public void MoveSunTimer(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Sun.MovePlanet();
            });
        }

        private void Starter_Click(object sender, RoutedEventArgs e)
        {
            Earth = new Planet(6, 150, Brushes.Blue, Space);
            Mars = new Planet(30, 227, Brushes.Brown, Space);
            Venus = new Planet(15, 125, Brushes.Wheat, Space);
            Mercury = new Planet(24, 75, Brushes.Silver, Space);
            Sun = new Planet(50, 0, Brushes.Yellow, Space);

            otherTimer = new Timer();
            otherTimer.Elapsed += MoveEarthTimer;
            otherTimer.Elapsed += MoveMarsTimer;
            otherTimer.Elapsed += MoveVenusTimer;
            otherTimer.Elapsed += MoveMercuryTimer;
            otherTimer.Elapsed += MoveSunTimer;
            otherTimer.Interval = 1;

            otherTimer.Enabled = true;

        }

        private void Stopper_Click(object sender, RoutedEventArgs e)
        {
            otherTimer.Stop();
            otherTimer.Dispose();
            otherTimer.Close();

            for (int i = Space.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = Space.Children[i];
                if (Child is Ellipse)
                    Space.Children.Remove(Child);
            }

        }
    }
}
