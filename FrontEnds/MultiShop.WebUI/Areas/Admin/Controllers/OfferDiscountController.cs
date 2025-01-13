using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.v1Title = "Özel Teklif Listesi";
                OfferDiscountViewbagList();

                var values = await _offerDiscountService.GetAllOfferDiscountAsync();
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            try
            {
                ViewBag.v1Title = "Yeni Özel Teklif Girişi";
                OfferDiscountViewbagList();

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            try
            {
                await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            try
            {
                await _offerDiscountService.DeleteOfferDiscountAsync(id);
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            try
            {
                ViewBag.v1Title = "Özel Teklif Güncelleme Sayfası";
                OfferDiscountViewbagList();

                var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            try
            {
                await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        void OfferDiscountViewbagList()
        {
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Özel Teklif";
            ViewBag.v4SubSectionName = "Özel Teklif İşlemleri";
        }
    }
}
