using api.Models;
using EF_DB_Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
        public dynamic findPost(string term="") 
        {
            return _context.Posts.Where(x=> x.Title.Contains(term) || 
                                            x.Author.Contains(term) || 
                                            x.Content.Contains(term) ).ToList();
        }

        [HttpGet]
        [Route("getPost")]
        public dynamic Get(int IdPost = 0) => _context.Posts.Where(x => x.Id == IdPost).FirstOrDefault();

        [HttpPost]
        public dynamic Post(Post post)
        {
            // Save or Create Post
            _context.Add(post);
            _context.SaveChanges();
            return post;
        }

        [HttpPut]
        public dynamic Put(Post post)
        {
            // Verify the Post Exists
            var postFound = _context.Posts.Where(x => x.Id == post.Id).FirstOrDefault();
            if (postFound == null)
            {
                return new
                {
                    success = false,
                    message = "The post do not exists",
                    result = "Error"
                };
            }

            // Update Post
            _context.Update<Post>(post);
            _context.SaveChanges();
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
            var postFound = _context.Posts.Where(x => x.Id == IdPost).FirstOrDefault();
            if (postFound == null)
            {
                return new
                {
                    success = false,
                    message = "The post do not exists",
                    result = "Error"
                };
            }

            // Delete Post
            _context.Remove(postFound);
            _context.SaveChanges();

            return new
            {
                success = true,
                message = "Post deleted",
                result = postFound
            };            
        }


    }
}