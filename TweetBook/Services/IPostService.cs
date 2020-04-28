using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Contract.V1.Request;
using TweetBook.Contract.V1.Response;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IPostService
    {
        public List<Post> GetPosts();
        public Post GetPostById(Guid postId);
        bool UpdatePost(Post postToUpdate);
        bool DeletePost(Guid postId);
    }
}
