using Microsoft.Extensions.DependencyInjection;

using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Reviews
{
	public static class ReviewsRabbitMqExtensions
	{
		public static IServiceCollection AddReviewsRabbitMq(
			this IServiceCollection services,
			ReviewsRabbitMqConfiguration configuration)
		{
			services.AddPhemaJsonSerializer();
			
			var builder = services.AddPhemaRabbitMq(configuration.InstanceName,
				options =>
				{
					options.UserName = configuration.Username;
					options.Password = configuration.Password;
					options.Port = configuration.Port;
					options.HostName = configuration.Hostname;
					options.VirtualHost = configuration.VirtualHost;
				});
			
			builder.AddProducers(options =>
				options.AddProducer<ReviewsExceptionPayload>("amq.direct", "errors")
					.Mandatory());
			
			return services;
		}
	}
}