using BlogProject.Models;

namespace BlogProject.Repository
{
    public interface IAuthorRepository
    {
        void AddAuthor(AuthorDto authorDTO);
        void DeleteAuthor(AuthorDto authorDTO);

        List<AuthorDto> GetAllAuthors();
        AuthorDto GetAuthorById(int id);
       
    }
}
