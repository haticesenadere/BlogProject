
using BlogProject.Models;
using BlogProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;   

        public CategoryController(ICategoryRepository categoryRepository, IAuthorRepository authorRepository  )
        {
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;

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
