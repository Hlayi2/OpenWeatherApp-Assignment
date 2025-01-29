using OpenWeather.Models;  
using OpenWeather.Services;  
using System.Security.Policy;  

namespace OpenWeather.Views; 
public partial class WeatherPage : ContentPage  
{
    // List to store weather data items that will be displayed
    public List<Models.List> WeatherList;

    private Double latitude;  
    private Double longitude; 
    private string response;  

    // Constructor for WeatherPage
    public WeatherPage()
    {
        InitializeComponent(); 
        WeatherList = new List<Models.List>();  
    }

    // Event handler for the "Search" button.
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
      
        response = await DisplayPromptAsync(title: "", message: "", placeholder: "Search weather by city", accept: "Search", cancel: "Cancel");

       
        if (!string.IsNullOrEmpty(response))
        {
            await GetWeatherDataByCity(response);  
        }
    }

    // Asynchronous method to get weather data for a specific city
    public async Task GetWeatherDataByCity(string city)
    {
        try
        {
           
            var result = await WeatherService.GetWeatheByCity(city);

            UpdateUI(result);
        }
        catch (Exception ex)
        {
            
            await DisplayAlert("Error", "Could not get weather data. Please try again.", "OK");
        }
    }

    // Method to update the UI with the fetched weather data
    public void UpdateUI(WeatherModel result)
    {
        WeatherList.Clear();  

        
        foreach (var item in result.list)
        {
            WeatherList.Add(item);  
        }

        // Reset the ItemsSource of the CollectionView to refresh the displayed data
        CvWeather.ItemsSource = null;
        CvWeather.ItemsSource = WeatherList; 


        // Update UI elements with the fetched data
        LblCity.Text = result.city.name; 
        LblWeatherDescription.Text = result.list[0].weather[0].description; 
        LblTemperature.Text = $"{result.list[0].main.temperature}°";  
        LblHumidity.Text = $"{result.list[0].main.humidity}%"; 
        LblWind.Text = $"{result.list[0].wind.speed}km/h"; 
        ImgWeatherIcon.Source = result.list[0].weather[0].customIcon;  
    }

    // Event handler for when the location is tapped to open the city search prompt again
    private async void OnLocationrTapped(object sender, TappedEventArgs e)
    {
       
        string response = await DisplayPromptAsync(title: "", message: "", placeholder: "Search weather by city", accept: "Search", cancel: "Cancel");

        
        if (!string.IsNullOrEmpty(response))
        {
            await GetWeatherDataByCity(response);  
        }
    }
}
