using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages/ProductImagesByProductId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
                if (values != null)
                {
                    return View(values);
                }
                else
                {
                    return View(new GetByIdProductImageDto
                    {
                        Image1 = "https://tesorogold.ru/local/templates/tesoro/images/no_photo.png",
                        Image2 = "https://tesorogold.ru/local/templates/tesoro/images/no_photo.png",
                        Image3 = "https://tesorogold.ru/local/templates/tesoro/images/no_photo.png",
                        Image4 = "https://tesorogold.ru/local/templates/tesoro/images/no_photo.png",
                        ProductId = id

                    });
                }
            }
            return View();
        }
    }
}
