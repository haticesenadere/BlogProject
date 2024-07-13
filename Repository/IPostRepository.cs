using BlogProject.Models;

namespace BlogProject.Repository
{
	public interface IPostRepository
	{
		void AddPost(PostDto post);
		void UpdatePost(PostDto post);
		void DeletePost(PostDto post);

		List<PostDto> GetAllPosts();
		PostDto GetPostById(int id);
	}
}

