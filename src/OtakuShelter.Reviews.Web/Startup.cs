using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Reviews
{
	public class Startup : IStartup
	{
		private readonly ReviewsConfiguration configuration;

		public Startup(IOptions<ReviewsConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddReviewsSwagger()
				.AddReviewsExceptionHandling()
				.AddReviewsMvc(configuration.Roles)
				.AddReviewsDatabase(configuration.Database)
				.AddReviewsRabbitMq(configuration.RabbitMq)
				.AddReviewsAuthentication(configuration.Jwt)
				.AddReviewsHealthChecks(configuration.Database, configuration.RabbitMq)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();
			
			app.UseHealthChecks("/health");
			app.UseAuthentication();
			app.UseReviewsSwagger();
			app.UseMvc();
		}
	}
}