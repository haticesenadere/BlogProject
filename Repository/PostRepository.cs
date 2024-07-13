using BlogProject.Data;
using BlogProject.Models;

namespace BlogProject.Repository
{
	public class PostRepository : IPostRepository
	{
		private readonly DataContext _context;

		public PostRepository(DataContext context)
		{
			_context = context;
		}

		public void AddPost(PostDto postdto)
		{
			Post post = new Post
			{
				PostId = postdto.PostId,
				Title = postdto.Title,
				Summary = postdto.Summary,
				Content = postdto.Content,
				PublishedDate = postdto.PublishedDate,
				AuthorId = postdto.AuthorId,
				CategoryId = postdto.CategoryId,

			};

			_context.Posts.Add(post);
			_context.SaveChanges();
		}

		public void DeletePost(PostDto postdto)
		{
			var post = _context.Posts.Find(postdto.PostId);
			if (post != null)
			{
				_context.Posts.Remove(post);
				_context.SaveChanges();
			}
		}

		public List<PostDto> GetAllPosts()
		{
			List<Post> posts = _context.Posts.ToList();
			var postDto = new List<PostDto>();

			foreach (var post in posts)
			{
				postDto.Add(new PostDto
				{
				
                    PostId = post.PostId,
                    Title = post.Title,
                    Summary = post.Summary,
                    Content = post.Content,
                    PublishedDate = post.PublishedDate,
                    AuthorId = post.AuthorId,
                    CategoryId = post.CategoryId
                }

			 );
			}
			return postDto;
		}

		public PostDto GetPostById(int id)
		{
			var post = _context.Posts.FirstOrDefault(c=> c.PostId == id);
			if (post == null) return null;
			return new PostDto
			{
                PostId = post.PostId,
                Title = post.Title,
                Summary = post.Summary,
                Content = post.Content,
                PublishedDate = post.PublishedDate,
                AuthorId = post.AuthorId,
                CategoryId = post.CategoryId
            };
           
        }

		public void UpdatePost(PostDto postdto)
		{
			var post = _context.Posts.FirstOrDefault(p => p.PostId == postdto.PostId);
			if (post != null)
			{
				post.Title = postdto.Title;
				post.Summary = postdto.Summary;
				post.Content = postdto.Content;
				post.PublishedDate = postdto.PublishedDate;
				post.AuthorId = postdto.AuthorId;
				post.CategoryId = postdto.CategoryId;

				_context.Update(post);
                _context.SaveChanges();
			}
		}
	}
}
