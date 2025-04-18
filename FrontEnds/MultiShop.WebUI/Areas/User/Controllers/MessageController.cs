﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> InBox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInBoxMessageAsync(user.Id);
            return View(values);
        }

        public async Task<IActionResult> SendBox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSendBoxMessageAsync(user.Id);
            return View(values);
        }
    }
}
