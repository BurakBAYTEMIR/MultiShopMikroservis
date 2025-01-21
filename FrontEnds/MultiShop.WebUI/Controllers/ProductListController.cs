using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.categoryId = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.productId = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto,string id)
        {
            //createCommentDto.UserCommentImageUrl = "/image/nophoto.png";
            //createCommentDto.UserCommentRating = 2;
            //createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //createCommentDto.UserCommentStatus = false;
            //createCommentDto.ProductId = "67625f8d487fbff4fa60ba65";
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createCommentDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7262/api/Comments", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Default");
            //}
            return View();
        }
    }
}
