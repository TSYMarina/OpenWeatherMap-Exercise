using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace OpenWeatherMap_Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create an instance of the HttpClient Class called client
            var client = new HttpClient();

            // TODO: Ask for the users API Key and store that in a variable called "api_Key"
            var api_key = "9c66bcc327698beda7b8c13b268ef769";

            // TODO: Ask the user for their city name and store that in a variable called "city_name"
            Console.Write("\nWhat is the name of the city in which you would like to check the weather:    ");
            var city_name = Console.ReadLine();

            // TODO: Create a variable to store the URL (use String Interpolation for the {city_name} and {api_Key}  HINT: Make sure to use the "imperial" measurement endpoint
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={api_key}&units=imperial";

            // TODO: Create a variable to store the response from your GET request to that URL from above  HINT: Don't forget to call .Result 
            var weatherResponse = client.GetStringAsync(weatherURL).Result;

            // TODO: Create a variable to store the formattedResponse after you JObject.Parse() the response from above
            var formattedResponse = JObject.Parse(weatherResponse).GetValue("main").ToString();


            // TODO: Write out the current temperature in degrees Fahrenheit

            var temp = JObject.Parse(formattedResponse).GetValue("temp").ToString();
            double numTemp;
            var ifNum = Double.TryParse(temp, out numTemp);

            if (numTemp < 37)
            {
                Console.WriteLine($"\n\nCurrent temperature in {city_name} is currently {numTemp} degrees F! Too cold for me!\nThanks for stopping by!\n");
            }

            else if (numTemp < 60 && numTemp >= 37)
            {
                Console.WriteLine($"\n\nCurrent temperature in {city_name} is currently {numTemp} degrees F! A bit Chilly!\nThanks for stopping by!\n");
            }
            else if (numTemp >= 60 && numTemp <= 88)
            {
                Console.WriteLine($"\n\nCurrent temperature in {city_name} is currently {numTemp} degrees F! Nice and warm!\nThanks for stopping by!\n");
            }
            else
            {
                Console.WriteLine($"\n\nCurrent temperature in {city_name} is currently {numTemp} degrees F! Sounds hot.\nThanks for stopping by!\n");
            }
        }
    }
}
