using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:52373/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            //id'ye göre servisten ilgili rezervasyonu çekip durumunu güncelliyorum.
            var value = new UpdateBookingDto();
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync($"http://localhost:52373/api/Booking/{id}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData1);

            }
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:52373/api/Booking/UpdateBooking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ApprovedReservation(int id)
        {
            //id'ye göre servisten ilgili rezervasyonu çekip durumunu güncelliyorum.
            var value = new ResultBookingDto();
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync($"http://localhost:52373/api/Booking/{id}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData1);
                value.Status = "Onaylandı";
                //Daha sonra dataları güncelleme metoduna gönderiyorum.
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(value);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:52373/api/Booking/UpdateBooking", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CanceledReservation(int id)
        {
            //id'ye göre servisten ilgili rezervasyonu çekip durumunu güncelliyorum.
            var value = new ResultBookingDto();
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync($"http://localhost:52373/api/Booking/{id}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData1);
                value.Status = "İptal Edildi";
                //Daha sonra dataları güncelleme metoduna gönderiyorum.
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(value);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:52373/api/Booking/UpdateBooking", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WaitedReservation(int id)
        {
            //id'ye göre servisten ilgili rezervasyonu çekip durumunu güncelliyorum.
            var value = new ResultBookingDto();
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync($"http://localhost:52373/api/Booking/{id}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData1);
                value.Status = "Müşteri Aranacak";
                //Daha sonra dataları güncelleme metoduna gönderiyorum.
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(value);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:52373/api/Booking/UpdateBooking", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
