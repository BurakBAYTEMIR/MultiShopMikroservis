using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [Route("CargoCompanyList")]
        public async Task<IActionResult> CargoCompanyList()
        {
            try
            {
                ViewBag.v1Title = "Kargo Firması Listesi";
                CargoViewbagList();

                var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("CreateCargoCompany")]
        public IActionResult CreateCargoCompany()
        {
            try
            {
                ViewBag.v1Title = "Yeni Kargo Firması Girişi";
                CargoViewbagList();

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            try
            {
                await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
                return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            try
            {
                await _cargoCompanyService.DeleteCargoCompanyAsync(id);
                return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            try
            {
                ViewBag.v1Title = "Kargo Firması Güncelleme Sayfası";
                CargoViewbagList();

                var values = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            try
            {
                await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
                return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }


        void CargoViewbagList()
        {
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Kargo";
            ViewBag.v4SubSectionName = "Kargo İşlemleri";
        }
    }
}
