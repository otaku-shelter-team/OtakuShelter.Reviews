using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Reviews
{
	public static class ReviewsHealthChecksExtensions
	{
		public static IServiceCollection AddReviewsHealthChecks(
			this IServiceCollection services,
			ReviewsDatabaseConfiguration database,
			ReviewsRabbitMqConfiguration rabbitMq)
		{
			services.AddHealthChecks()
				.AddNpgSql(database.ConnectionString)
				.AddRabbitMQ(rabbitMq.ConnectionString);
			
			return services;
		}
	}
}