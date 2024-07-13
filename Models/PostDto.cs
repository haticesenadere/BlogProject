namespace BlogProject.Models
{
	public class PostDto
	{

		public int PostId { get; set; }
		public string Title { get; set; }
		public string Summary { get; set; }
		public string Content { get; set; }
		public int CategoryId { get; set; }
		public int AuthorId { get; set; }
		public DateTime PublishedDate { get; set; }
		public CategoryDto? Category { get; set; }
		public AuthorDto? Author { get; set; }

	}
}
