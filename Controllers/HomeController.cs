using BlogProject.Models;
using BlogProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;

        public HomeController(ILogger<HomeController> logger,IPostRepository postRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _logger = logger;
        }


      

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Blog()
		{
            ViewBag.CategoryName = _categoryRepository.GetAllCategories().ToDictionary(c => c.CategoryId, c => c.Name);
            ViewBag.AuthorName = _authorRepository.GetAllAuthors().ToDictionary(a => a.AuthorId, a => a.Name);

            var post = _postRepository.GetAllPosts();
            return View(post);
            
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
