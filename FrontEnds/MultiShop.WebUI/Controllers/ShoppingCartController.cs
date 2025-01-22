using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code , int discountRate,decimal totalNewPriceWithDiscount)
        {
            try
            {
                ViewBag.code = code;
                ViewBag.discountRate = discountRate;
                ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
                var values = await _basketService.GetBasket();
                ViewBag.total = values.TotalPrice;
                var taxPrice = values.TotalPrice / 100 * 10;
                var totalPriceWithTax = values.TotalPrice + taxPrice;
                ViewBag.totalPriceWithTax = totalPriceWithTax;
                ViewBag.taxPrice = taxPrice;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            try
            {
                var values = await _productService.GetByIdProductAsync(id);
                var items = new BasketItemDto
                {
                    ProductId = values.ProductId,
                    ProductName = values.ProductName,
                    Price = values.ProductPrice,
                    Quantity = 1,
                    ProductImageUrl = values.ProductImageUrl
                };
                await _basketService.AddBasketItem(items);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            try
            {
                await _basketService.RemoveBasketItem(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }
    }
}
