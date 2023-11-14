using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
				List<SearchLocationIdViewModel> model = new List<SearchLocationIdViewModel>();
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
					Headers =
	{
		{ "X-RapidAPI-Key", "f28ba327a9msh7e3e4b72fb94db3p129fabjsn23dc15b70611" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					model = JsonConvert.DeserializeObject<List<SearchLocationIdViewModel>>(body);
					return View(model);
				}
			}
            else
            {
				List<SearchLocationIdViewModel> model = new List<SearchLocationIdViewModel>();
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),
					Headers =
	{
		{ "X-RapidAPI-Key", "f28ba327a9msh7e3e4b72fb94db3p129fabjsn23dc15b70611" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					model = JsonConvert.DeserializeObject<List<SearchLocationIdViewModel>>(body);
					return View(model);
				}
			}
			
			
        }
    }
}
