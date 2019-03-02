using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
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

		public static IApplicationBuilder UseReviewsHealthchecks(this IApplicationBuilder app)
		{
			return app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
		}
	}
}