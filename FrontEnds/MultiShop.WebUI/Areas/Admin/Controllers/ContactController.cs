using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.v1Title = "Mesaj Listesi";
                ContactViewbagList();

                var values = await _contactService.GetAllContactAsync();
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("GetByIdContact/{id}")]
        public async Task<IActionResult> GetByIdContact(string id)
        {
            try
            {
                ViewBag.v1Title = "Mesaj Görüntüleme Sayfası";
                ContactViewbagList();

                var values = await _contactService.GetByIdContactAsync(id);
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        void ContactViewbagList()
        {
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Mesaj Alan";
            ViewBag.v4SubSectionName = "Mesaj İşlemleri";
        }
    }
}
