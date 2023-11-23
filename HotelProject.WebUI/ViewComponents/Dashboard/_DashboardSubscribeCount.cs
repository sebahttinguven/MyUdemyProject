using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCount:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/murattycedag"),
				Headers =
	{
		{ "X-RapidAPI-Key", "f28ba327a9msh7e3e4b72fb94db3p129fabjsn23dc15b70611" },
		{ "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
				ViewBag.v1 = values.following;
				ViewBag.v2 = values.followers;
				
			}

			var client2 = new HttpClient();
			var request2 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=SebahattinGvn"),
				Headers =
	{
		{ "X-RapidAPI-Key", "f28ba327a9msh7e3e4b72fb94db3p129fabjsn23dc15b70611" },
		{ "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
	},
			};
			using (var response = await client2.SendAsync(request2))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body);
				ViewBag.v3 = values.data.user_info.followers_count;
				ViewBag.v4 = values.data.user_info.friends_count;

			}

			var client3 = new HttpClient();
			var request3 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fsebahattin-g%25C3%25BCven-2b80ab69%2F&include_skills=false"),
				Headers =
	{
		{ "X-RapidAPI-Key", "f28ba327a9msh7e3e4b72fb94db3p129fabjsn23dc15b70611" },
		{ "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
	},
			};
			using (var response = await client3.SendAsync(request3))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<ResultLinkedInFollowersDto>(body);
				ViewBag.v5 = value.data.connections_count;
				ViewBag.v6 = value.data.followers_count;
					
					
			}

			return View();
        }
    }
}
