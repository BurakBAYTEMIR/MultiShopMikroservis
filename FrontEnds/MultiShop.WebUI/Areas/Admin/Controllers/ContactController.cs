using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Contact")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1Title = "Mesaj Listesi";
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Mesaj";
            ViewBag.v4SubSectionName = "Mesaj İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("GetByIdContact/{id}")]
        public async Task<IActionResult> GetByIdContact(string id)
        {
            ViewBag.v1Title = "Mesaj Görüntüleme Sayfası";
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Mesaj Alan";
            ViewBag.v4SubSectionName = "Mesaj İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Contacts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
