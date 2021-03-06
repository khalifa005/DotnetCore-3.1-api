﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Contract.V1;
using TweetBook.Contract.V1.Request;
using TweetBook.Contract.V1.Response;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public class PostService:IPostService
    {
        private readonly List<Post> _posts;
        public PostService()
        {
            _posts = new List<Post>();
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post() { Id = Guid.NewGuid(), Name = i.ToString() });
            }
        }
        public List<Post> GetPosts()
        {
            return _posts;
        }

        public Post GetPostById(Guid postId)
        {
            return _posts.SingleOrDefault(x => x.Id == postId);
        }

        public bool UpdatePost(Post postToUpdate)
        {
            var exist = GetPostById(postToUpdate.Id) != null;
            if (!exist)
                return false;
            var index = _posts.FindIndex(x => x.Id == postToUpdate.Id);
            _posts[index] = postToUpdate;

            return true;
        }

        public bool DeletePost(Guid postId)
        {
            var postToDelete = GetPostById(postId);
            if (postToDelete == null)
                return false;
            _posts.Remove(postToDelete);
            return true;
        }
    }
}
