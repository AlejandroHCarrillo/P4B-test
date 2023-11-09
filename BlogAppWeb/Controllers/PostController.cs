using BlogAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogAppWeb.Controllers
{
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    public class PostController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7161/api");
        private readonly HttpClient _client;
        public PostController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        // GET: PostController
        public async Task<IActionResult> Index(int id)
        {
            Post post = new Post();
            var response = await _client.GetAsync(_client.BaseAddress + "/Blog/getPost?IdPost="+id);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                post = JsonConvert.DeserializeObject<Post>(data);
            }

            return View(post);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public async Task<IActionResult> Edit(int id)
        //public ActionResult Edit(int id)
        {
            Post post = new Post();
            var response = await _client.GetAsync(_client.BaseAddress + "/Blog/getPost?IdPost=" + id);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                post = JsonConvert.DeserializeObject<Post>(data);
            }

            return View(post);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
