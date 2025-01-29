using OpenWeather.Views;

namespace OpenWeather.WelcomPage;

public partial class Welcome : ContentPage
{
	public Welcome()
	{
		InitializeComponent();
	}

    private void btnGetStarted_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new WeatherPage());
    }
}