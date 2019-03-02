using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Phema.ExceptionHandling;
using Phema.RabbitMq;

namespace OtakuShelter.Reviews
{
	public class ReviewsExceptionHandler : IExceptionHandler<Exception>
	{
		private readonly IHttpContextAccessor accessor;
		private readonly IRabbitMqProducer<ReviewsExceptionPayload> producer;
		private readonly ReviewsConfiguration configuration;

		public ReviewsExceptionHandler(
			IRabbitMqProducer<ReviewsExceptionPayload> producer,
			IOptions<ReviewsConfiguration> configuration,
			IHttpContextAccessor accessor)
		{
			this.producer = producer;
			this.configuration = configuration.Value;
			this.accessor = accessor;
		}
		
		public async ValueTask<IActionResult> Handle(Exception exception)
		{
			var message = new ReviewsExceptionPayload
			{
				TraceId = accessor.HttpContext.TraceIdentifier,
				Type = exception.GetType().ToString(),
				Project = configuration.Name,
				Message = exception.Message,
				StackTrace = exception.StackTrace,
				Created = DateTime.UtcNow
			};

			await producer.Produce(message);
			
			return new BadRequestObjectResult(new {traceId = message.TraceId});
		}
	}
}