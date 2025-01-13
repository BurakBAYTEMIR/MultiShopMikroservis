using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.v1Title = "Öne Çıkan Resim Listesi";
                FeatureSliderViewbagList();

                var values = await _featureSliderService.GetAllFeatureSliderAsync();
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            try
            {
                ViewBag.v1Title = "Yeni Öne Çıkan Resim Girişi";
                FeatureSliderViewbagList();

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            try
            {
                await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            try
            {
                await _featureSliderService.DeleteFeatureSliderAsync(id);
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            try
            {
                ViewBag.v1Title = "Öne Çıkan Resim Güncelleme Sayfası";
                FeatureSliderViewbagList();

                var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            try
            {
                await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        void FeatureSliderViewbagList()
        {
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Öne Çıkan Resimler";
            ViewBag.v4SubSectionName = "Öne Çıkan Resim İşlemleri";
        }
    }
}
