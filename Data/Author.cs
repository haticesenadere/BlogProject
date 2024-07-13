using System.ComponentModel.DataAnnotations;

namespace BlogProject.Data
{
	public class Author
	{
		[Key]
		public int AuthorId { get; set; }
		public string Name { get; set; }
	}
}
