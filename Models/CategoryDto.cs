using Microsoft.Extensions.Hosting;

namespace BlogProject.Models
{
	public class CategoryDto

	{
		public int CategoryId { get; set; }
		public string Name { get; set; }

        public List<PostDto>? Posts { get; set; }
    }
}
