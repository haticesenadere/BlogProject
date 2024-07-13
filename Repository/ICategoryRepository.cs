using BlogProject.Models;

namespace BlogProject.Repository
{
    public interface ICategoryRepository
    {
        void AddCategory(CategoryDto categoryDTO);
        void DeleteCategory(CategoryDto categoryDTO);
        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);
    }
}
