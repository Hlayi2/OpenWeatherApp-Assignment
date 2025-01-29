using Newtonsoft.Json; 
using OpenWeather.Models;  


namespace OpenWeather.Services  
{
    // Static WeatherService class responsible for interacting with the OpenWeather API
    public static class WeatherService
    {
        
        public static async Task<WeatherModel> GetWeather(double latitude, double longitude)
        {
            var httpClient = new HttpClient();  
           
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=8546560722ae6dee1b4dc12184720fed", latitude, longitude));

           
            return JsonConvert.DeserializeObject<WeatherModel>(response);
        }

        // Method to get weather data based on the city name
        public static async Task<WeatherModel> GetWeatheByCity(string city)
        {
            var httpClient = new HttpClient();  

            
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid=8546560722ae6dee1b4dc12184720fed", city));

            
            return JsonConvert.DeserializeObject<WeatherModel>(response);
        }
    }
}
