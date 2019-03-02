using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Reviews
{
	public class ReviewsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReviewsContext>
	{
		public ReviewsContext CreateDbContext(string[] args)
		{
			return new ServiceCollection()
				.AddReviewsDatabase(new ReviewsDatabaseConfiguration())
				.BuildServiceProvider()
				.GetRequiredService<ReviewsContext>();
		}
	}
}