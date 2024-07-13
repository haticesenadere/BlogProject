using BlogProject.Data;
using BlogProject.Models;

namespace BlogProject.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddCategory(CategoryDto categoryDTO)
        {
            Category category = new Category
            {
                CategoryId = categoryDTO.CategoryId,
                Name = categoryDTO.Name,
            };
            _dataContext.Categorys.Add(category);
            _dataContext.SaveChanges();
        }

        public void DeleteCategory(CategoryDto categoryDTO)
        {
            var category = _dataContext.Categorys.FirstOrDefault(category => category.CategoryId == categoryDTO.CategoryId);
            if (category != null)
            {
                _dataContext.Categorys.Remove(category);
                _dataContext.SaveChanges();
            }
        }

        public List<CategoryDto> GetAllCategories()
        {
            List<Category> categories = _dataContext.Categorys.ToList();
            var categoryDTO = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoryDTO.Add(new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                });
            }
            return categoryDTO;
        }
        public CategoryDto GetCategoryById(int id)
        {
            var category = _dataContext.Categorys.FirstOrDefault(c=> c.CategoryId == id);
            if (category == null) return null;
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };
        }

    }
}
