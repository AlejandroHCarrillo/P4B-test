using api.Models;
using EF_DB_Blog;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private BlogContext _context;

        public BlogController(BlogContext context, ILogger<BlogController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetPosts")]
        public dynamic Get() => _context.Posts.ToList();

        [HttpGet]
        [Route("find")]
        public dynamic findPost(string term="") {
            return Enumerable.Range(1, 5).Select(index => new Post
            {
                Id = index,
                Title = "XXXX",
                PublishDate = new DateTime(),
                Content = "Lorem..."
            })
            .ToArray();

        }

        [HttpGet]
        [Route("getPost")]
        public Post Get(int IdPost = 0)
        {
            return new Post{
                Id = IdPost,
                Title = "Dummy Post Found",
                PublishDate = new DateTime(),
                Content = "Lorem..."
            };
        }

        [HttpPost]
        public Post Post(Post post)
        {
            // Save or Create Post
            return post;
        }

        [HttpPut]
        public Post Put(Post post)
        {
            // Verify the Post Exists

            // Update Post
            return post;
        }

        [HttpDelete]
        public dynamic Delete(int IdPost)
        {
            // Verify Authorization to Delete it
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            if (token != "King") {
                return new
                {
                    success = false,
                    message = "Not authorized to delete items",
                    result = IdPost.ToString()
                };
            }
            // Verify the Post Exists
            Post post = new Post { Id = 9, Author = "yo", Title = "dummy find", Content = "Lorem..." };

            // Delete Post
            return new
            {
                success = true,
                message = "Post deleted",
                result = post
            };
            ;
        }


    }
}