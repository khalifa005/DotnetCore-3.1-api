using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contract.V1;
using TweetBook.Contract.V1.Request;
using TweetBook.Contract.V1.Response;
using TweetBook.Domain;
using TweetBook.Services;

namespace TweetBook.Controllers.V1
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _psoService;

        public PostsController(IPostService psoService)
        {
            _psoService = psoService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_psoService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult GetPost(Guid postId)
        {
            var post = _psoService.GetPostById(postId);
            if (post ==null)
               return NotFound();

            return Ok(post);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult UpdatePost(Guid postId, UpdatePostRequest request)
        {
            var post=new Post()
            {
                Id = postId,
                Name = request.Name
            };
            var updated=_psoService.UpdatePost(post);
            if (updated)
                return Ok(post);
            return NotFound();
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create(CreatePostRequest createPostRequest)
        {
            var post=new Post {Id = createPostRequest.Id};

            if(post.Id != Guid.Empty)
                post.Id=Guid.NewGuid();

            //_Posts.Add(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());
            var response=new PostResponse{Id = post.Id};
            return Created(locationUrl, response);
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public IActionResult Delete(Guid postId)
        {
            var deleted=_psoService.DeletePost(postId);
            if (deleted)
                return NoContent();

            return NotFound();
        }

    }
}