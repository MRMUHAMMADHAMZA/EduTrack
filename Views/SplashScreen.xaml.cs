using System;
using System.Threading.Tasks;
using System.Windows;

namespace EduTrack.Views
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            Loaded += SplashScreen_Loaded;
        }

        private async void SplashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            // Wait for 3 seconds
            await Task.Delay(3000);

            // Open Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Show();

            // Close Splash
            this.Close();
        }
    }
}
