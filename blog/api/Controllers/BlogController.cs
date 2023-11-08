using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{ "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPosts")]
        public IEnumerable<Post> Get()
        {
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
            // Update Post
            return post;
        }

        [HttpDelete]
        public bool Delete(int IdPost)
        {
            // Delete Post
            return true;
        }


    }
}