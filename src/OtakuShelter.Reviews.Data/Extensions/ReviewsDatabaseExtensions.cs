using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Reviews
{
	public static class ReviewsDatabaseExtensions
	{
		public static IServiceCollection AddReviewsDatabase(
			this IServiceCollection services,
			ReviewsDatabaseConfiguration configuration)
		{
			services.AddDbContextPool<ReviewsContext>(options =>
				options.UseNpgsql(configuration.ConnectionString, builder =>
						builder.MigrationsHistoryTable(configuration.MigrationsTable))
					.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning)));

			return services;
		}
	}
}