using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Reviews
{
	public static class ReviewsExceptionHandlingExtensions
	{
		public static IServiceCollection AddReviewsExceptionHandling(this IServiceCollection services)
		{
			return services.AddPhemaExceptionHandling(options =>
					options.AddExceptionHandler<Exception, ReviewsExceptionHandler>(e => true))
				.AddHttpContextAccessor();
		}
	}
}