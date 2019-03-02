using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Reviews
{
	public class ReviewsContext : DbContext
	{
		public ReviewsContext(DbContextOptions<ReviewsContext> options) : base(options)
		{
		}		
		
		public DbSet<Review> Reviews { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ReviewConfiguration());
		}
	}
}