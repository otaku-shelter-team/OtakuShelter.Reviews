using Phema.Routing;

namespace OtakuShelter.Reviews
{
	public static class ReviewsControllerRoutes
	{
		public static IRoutingBuilder AddReviewsController(this IRoutingBuilder builder, ReviewsRoleConfiguration roles)
		{
			builder.AddController<ReviewsController>(controller =>
			{
				controller.AddRoute("reviews", c => c.Read(From.Query<FilterRequest>()))
					.HttpGet()
					.Authorize();

				controller.AddRoute("{mangaId}/reviews", c => c.ReadById(From.Route<int>(), From.Query<FilterRequest>()))
					.HttpGet();

				controller.AddRoute("{mangaId}/reviews", c => c.Create(From.Route<int>(), From.Body<CreateReviewRequest>()))
					.HttpPost()
					.Authorize();

				controller.AddRoute("reviews/{id}", c => c.Update(From.Route<int>(), From.Body<UpdateReviewRequest>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute("reviews/{id}", c => c.Delete(From.Route<DeleteReviewRequest>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin/reviews/{id}",
						c => c.AdminUpdateById(From.Route<int>(), From.Body<AdminUpdateByIdReviewRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/reviews/{id}", c => c.AdminDeleteById(From.Route<AdminDeleteByIdReviewRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}