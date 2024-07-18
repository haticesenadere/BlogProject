
using BlogProject.Models;
using BlogProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;   
        private readonly IPostRepository _postRepository;   

        public CategoryController(ICategoryRepository categoryRepository, IAuthorRepository authorRepository, IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _postRepository = postRepository;

        }

        [HttpGet]
        public IActionResult AddCategory()
        {

          return View();    
        }
      

        [HttpPost]

        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(categoryDto);
                return RedirectToAction("AddPost" , "Post");
            }

            return View(categoryDto);
        }

        public IActionResult CategoryList()
        {
            ViewBag.Author = _authorRepository.GetAllAuthors();
            ViewBag.CategoryName = _categoryRepository.GetAllCategories().ToDictionary(c => c.CategoryId, c => c.Name);
            ViewBag.AuthorName = _authorRepository.GetAllAuthors().ToDictionary(a => a.AuthorId, a => a.Name);
            var blogs = _postRepository.GetAllPosts();

            var authorPostCounts = blogs
                .GroupBy(b => b.AuthorId)
                .Select(g => new { AuthorId = g.Key, PostCount = g.Count() })
                .ToDictionary(a => a.AuthorId, a => a.PostCount);


            var categoryCounts = blogs
                .GroupBy(b => b.CategoryId)
                .Select(g => new { CategoryID = g.Key, PostCount = g.Count() })
                .ToDictionary(a => a.CategoryID, a => a.PostCount);

            ViewBag.CategoryCounts = categoryCounts;
            ViewBag.AuthorPostCounts = authorPostCounts;

            var category = _categoryRepository.GetAllCategories();
            return View(category);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {

            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.DeleteCategory(category);
            return RedirectToAction("CategoryList");
        }

    }
}
