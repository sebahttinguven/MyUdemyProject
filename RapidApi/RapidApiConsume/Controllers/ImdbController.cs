using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using RapidApiConsume.Models;
using Newtonsoft.Json;

namespace RapidApiConsume.Controllers
{
	public class ImdbController : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "X-RapidAPI-Key", "f28ba327a9msh7e3e4b72fb94db3p129fabjsn23dc15b70611" },
		{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
				return View(apiMovieViewModels);
			}
		}
	}
}
