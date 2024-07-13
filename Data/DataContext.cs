using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base (options) { }

		public DbSet<Post> Posts { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Category> Categorys { get; set; }
	}
}
