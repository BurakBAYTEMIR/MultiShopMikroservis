using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public ProductController(IHttpClientFactory httpClientFactory, ICategoryService categoryService, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
            _productService = productService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1Title = "Ürün Listesi";

            try
            {
                var values = await _productService.GetAllProductAsync();
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1Title = "Ürün Listesi";
            ProductListWithCategoryViewbag();

            try
            {
                var values = await _productService.GetProductWithCategoryAsync();
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }


        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1Title = "Yeni Ürün Girişi";
            ProductListWithCategoryViewbag();
            try
            {
                var values = await _categoryService.GetAllCategoryAsync();
                List<SelectListItem> categoryValues = (from x in values
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId
                                                       }).ToList();
                ViewBag.CategoryValues = categoryValues;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            try
            {
                await _productService.CreateProductAsync(createProductDto);
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1Title = "Ürün Güncelleme Sayfası";
            ProductListWithCategoryViewbag();

            try
            {
                var values1 = await _categoryService.GetAllCategoryAsync();
                List<SelectListItem> categoryValues = (from x in values1
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId
                                                       }).ToList();
                ViewBag.CategoryValues = categoryValues;
                var values = await _productService.GetByIdProductAsync(id);
                return View(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            try
            {
                await _productService.UpdateProductAsync(updateProductDto);
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View();
            }
        }

        void ProductListWithCategoryViewbag()
        {
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Kategoriler";
            ViewBag.v4SubSectionName = "Ürün İşlemleri";
        }
    }
}
