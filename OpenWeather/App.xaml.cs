using OpenWeather.Views;
using OpenWeather.WelcomPage;

namespace OpenWeather
{
    public partial class App : Application
    {
        public App()
        {
            
            InitializeComponent();
            VersionTracking.Track();
            if(VersionTracking.IsFirstLaunchEver == true ) 
            {
                MainPage = new Welcome();

            }
            else
            {
                MainPage = new Welcome();
            }

           
        }
    }
}
