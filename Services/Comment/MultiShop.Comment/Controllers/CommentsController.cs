﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var values = _context.UserComments.Find(id);
            _context.UserComments.Remove(values);
            _context.SaveChanges();
            return Ok("Yorum başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _context.UserComments.Find(id);
            return Ok(value);
        }

        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _context.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            var value = _context.UserComments.Where(x=>x.UserCommentStatus == true).Count();
            return Ok(value);
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            var value = _context.UserComments.Where(x => x.UserCommentStatus == false).Count();
            return Ok(value);
        }

        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            var value = _context.UserComments.Count();
            return Ok(value);
        }
    }
}
