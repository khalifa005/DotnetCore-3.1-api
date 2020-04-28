using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contract.V1;
using TweetBook.Domain;

namespace TweetBook.Controllers.V1
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        public List<Post> _Posts { get; set; }
        public PostsController()
        {
            _Posts = new List<Post>();
            for (var i = 0; i < 5; i++)
            {
                _Posts.Add(new Post(){Id = Guid.NewGuid().ToString()});
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_Posts);
        }
    }
}