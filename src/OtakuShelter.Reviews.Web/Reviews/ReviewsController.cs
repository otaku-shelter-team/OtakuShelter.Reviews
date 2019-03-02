using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace OtakuShelter.Reviews
{
	public class ReviewsController : ControllerBase
	{
		private readonly ReviewsContext context;

		public ReviewsController(ReviewsContext context)
		{
			this.context = context;
		}

		public async ValueTask Create(int mangaId, CreateReviewRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Create(context, accountId, mangaId);

			await context.SaveChangesAsync();
		}
		
		public async Task<ReadReviewsResponse> Read(FilterRequest filter)
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var response = new ReadReviewsResponse();

			await response.Read(context, filter, accountId);

			return response;
		}

		public async ValueTask<ReadByIdReviewsResponse> ReadById(int mangaId, FilterRequest filter)
		{
			var response = new ReadByIdReviewsResponse();

			await response.ReadById(context, filter, mangaId);

			return response;
		}

		public async ValueTask Update(int id, UpdateReviewRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Update(context, accountId, id);

			await context.SaveChangesAsync();
		}

		public async ValueTask Delete(DeleteReviewRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminUpdateById(int id, AdminUpdateByIdReviewRequest request)
		{
			await request.UpdateById(context, id);

			await context.SaveChangesAsync();
		}

		public async ValueTask AdminDeleteById(AdminDeleteByIdReviewRequest request)
		{
			await request.DeleteById(context);

			await context.SaveChangesAsync();
		}
	}
}