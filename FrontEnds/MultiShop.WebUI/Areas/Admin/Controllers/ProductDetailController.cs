using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("ProductDetailAddOrUpdate/{id}")]
        public async Task<IActionResult> ProductDetailAddOrUpdate(string id)
        {
            ViewBag.v1Title = "Ürün Detayları Güncelleme Sayfası";
            ViewBag.v2PageName = "Ana Sayfa";
            ViewBag.v3SectionName = "Ürünler";
            ViewBag.v4SubSectionName = "Ürün İşlemleri";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values ?? new UpdateProductDetailDto { ProductId = id });
            }
            return View();
        }

        [HttpPost]
        [Route("ProductDetailAddOrUpdate/{id}")]
        public async Task<IActionResult> ProductDetailAddOrUpdate(UpdateProductDetailDto updateProductDetailDto, CreateProductDetailDto createProductDetailDto)
        {
            if (updateProductDetailDto.ProductDetailId == null)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7070/api/ProductDetails", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
                return View();
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductDetails/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
                return View();
            }
        }
    }
}
