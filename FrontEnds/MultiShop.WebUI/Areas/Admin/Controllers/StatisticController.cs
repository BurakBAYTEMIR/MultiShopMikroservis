using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IMessageStatisticService messageStatisticService, IDiscountStatisticService discountStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _messageStatisticService = messageStatisticService;
            _discountStatisticService = discountStatisticService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.v1Title = "İstatistik Listesi";
                StatisticViewbagList();

                //Catalog
                var getBrandCount = await _catalogStatisticService.GetBrandCount();
                ViewBag.getBrandCount = getBrandCount;

                var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
                ViewBag.getCategoryCount = getCategoryCount;

                var getProductCount = await _catalogStatisticService.GetProductCount();
                ViewBag.getProductCount = getProductCount;

                var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
                ViewBag.getProductAvgPrice = getProductAvgPrice;

                var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
                ViewBag.getMaxPriceProductName = getMaxPriceProductName;

                var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
                ViewBag.getMinPriceProductName = getMinPriceProductName;

                //Comment
                var getTotalCommentCount = await _commentStatisticService.GetTotalCommentCount();
                ViewBag.getTotalCommentCount = getTotalCommentCount;

                var getActiveCommentCount = await _commentStatisticService.GetActiveCommentCount();
                ViewBag.getActiveCommentCount = getActiveCommentCount;

                var getPassiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();
                ViewBag.getPassiveCommentCount = getPassiveCommentCount;

                //Message
                var getTotalMessageCount = await _messageStatisticService.GetTotalMessageCount();
                ViewBag.getTotalMessageCount = getTotalMessageCount;

                //User
                var getUserCount = await _userStatisticService.GetUserCount();
                ViewBag.getUserCount = getUserCount;

                //Discount
                var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();
                ViewBag.getDiscountCouponCount = getDiscountCouponCount;

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        void StatisticViewbagList()
        {
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "İstatistik";
            ViewBag.v4SubSectionName = "İstatistik İşlemleri";
        }
    }
}
