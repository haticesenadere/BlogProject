using BlogProject.Models;
using BlogProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;   
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorDto author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.AddAuthor(author);
                return RedirectToAction("AddPost", "Post");
            }

            return View(author);
        }

        public IActionResult AuthorList()
        {

            var author = _authorRepository.GetAllAuthors();
            return View(author);
        }

        [HttpGet]
        public IActionResult DeleteAuthor(int id)
        {

            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            _authorRepository.DeleteAuthor(author);
            return RedirectToAction("CategoryList" , "Category");
        }
    }
}
