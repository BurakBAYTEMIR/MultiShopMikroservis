using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerService;
using MultiShop.WebUI.Services.UserIdentityServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserIdentityService userIdentityServices, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityServices;
            _cargoCustomerService = cargoCustomerService;
        }

        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            try
            {
                ViewBag.v1Title = "Kullanıcı Listesi";
                UserViewbagList();

                var values = await _userIdentityService.GetAllUserListAsync();
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [Route("UserAddressInfo/{id}")]
        public async Task<IActionResult> UserAddressInfo(string id)
        {
            try
            {
                ViewBag.v1Title = "Kullanıcı Adres Bilgisi";
                UserViewbagList();

                var values = await _cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
            
        }

        void UserViewbagList()
        {
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Kullanıcı";
            ViewBag.v4SubSectionName = "Kullanıcı İşlemleri";
        }
    }
}
