using BlogProject.Data;
using BlogProject.Models;

namespace BlogProject.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _dataContext;

        public AuthorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddAuthor(AuthorDto authorDTO)
        {
            Author author = new Author
            {   AuthorId = authorDTO.AuthorId,
                Name = authorDTO.Name,
            };
            _dataContext.Authors.Add(author);
            _dataContext.SaveChanges();
        }

        public void DeleteAuthor(AuthorDto authorDTO)
        {
            var author = _dataContext.Authors.FirstOrDefault(author => author.AuthorId == authorDTO.AuthorId);
            if (author != null)
            {
                _dataContext.Authors.Remove(author);
                _dataContext.SaveChanges();
            }
        }

        public List<AuthorDto> GetAllAuthors()
        {
            List<Author> authors = _dataContext.Authors.ToList();
            var authorDto = new List<AuthorDto>();

            foreach (var category in authors)
            {
                authorDto.Add(new AuthorDto
                {
                    AuthorId = category.AuthorId,
                    Name = category.Name,
                });
            }
            return authorDto;
        }

        public AuthorDto GetAuthorById(int id)
        {
            var author = _dataContext.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null) return null;
            return new AuthorDto
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
            };
        }
    }
}
