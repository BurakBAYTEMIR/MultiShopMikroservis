﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCode(code);
            var basketValues = await _basketService.GetBasket();
            var taxPrice = basketValues.TotalPrice / 100 * 10;
            var totalPriceWithTax = basketValues.TotalPrice + taxPrice;
            var discount = totalPriceWithTax / 100 * values.CouponRate;
            var totalNewPriceWithDiscount = totalPriceWithTax - discount;
            

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values.CouponRate, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
