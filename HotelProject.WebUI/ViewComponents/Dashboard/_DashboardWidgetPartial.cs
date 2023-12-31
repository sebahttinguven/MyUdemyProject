﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:52373/api/DashboardWidget/GetStaffCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.StaffCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:52373/api/DashboardWidget/GetBookingCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.BookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:52373/api/DashboardWidget/GetAppUserCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.UserCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:52373/api/DashboardWidget/GetRoomCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.RoomCount = jsonData4;
            return View();
        }
    }
}
