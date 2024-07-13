using BlogProject.Data;
using BlogProject.Models;
using BlogProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;

        public PostController(IPostRepository postRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            ViewBag.Authors = _authorRepository.GetAllAuthors();
            ViewBag.Categories = _categoryRepository.GetAllCategories();


            return View();
        }
        [HttpPost]

        public IActionResult AddPost(PostDto post)
        {
            ViewBag.Authors = _authorRepository.GetAllAuthors();
            ViewBag.Categories = _categoryRepository.GetAllCategories();

            post.PublishedDate = DateTime.Now;  

            if (ModelState.IsValid)
            {
                post.Category = _categoryRepository.GetCategoryById(post.CategoryId);
                _postRepository.AddPost(post);
                return RedirectToAction("PostList");
            }
            return View(post);
        }

        public IActionResult PostList()
        {
            ViewBag.Authors = _authorRepository.GetAllAuthors();
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.CategoryName = _categoryRepository.GetAllCategories().ToDictionary(c => c.CategoryId, c => c.Name);
            ViewBag.AuthorName = _authorRepository.GetAllAuthors().ToDictionary(a => a.AuthorId, a => a.Name);

            var post = _postRepository.GetAllPosts();
            return View(post);
        }

        [HttpGet]
        public IActionResult UpdatePost(int id)
        {
            ViewBag.Authors = _authorRepository.GetAllAuthors();
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.CategoryName = _categoryRepository.GetAllCategories().ToDictionary(c => c.CategoryId, c => c.Name);
            ViewBag.AuthorName = _authorRepository.GetAllAuthors().ToDictionary(a => a.AuthorId, a => a.Name);
           
            var post = _postRepository.GetPostById(id);
            if (post == null)
            {
                return NotFound();

            }
            return View(post);

        }
        [HttpPost]
        public IActionResult UpdatePost(PostDto post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.UpdatePost(post);
                return RedirectToAction("PostList");
            }
            return View(post);
        }


        public IActionResult DeletePost(int id)
        {

            var post = _postRepository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            _postRepository.DeletePost(post);
            return RedirectToAction("PostList");
        }
       
    }
}
