using BlogAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlogAppWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7161/api");
        private readonly HttpClient _client;

        private readonly ILogger<HomeController> _logger;

        public BlogController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            List<Post> posts= new List<Post>();
            var response = await _client.GetAsync(_client.BaseAddress + "/Blog");
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                posts = JsonConvert.DeserializeObject<List<Post>>(data);
            }

            return View(posts);
        }
    }
}
