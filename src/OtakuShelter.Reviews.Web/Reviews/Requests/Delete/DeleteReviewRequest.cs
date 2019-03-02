using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Reviews
{
	public class DeleteReviewRequest
	{
		public int Id { get; set; }

		public async ValueTask Delete(ReviewsContext context, int accountId)
		{
			var review = await context.Reviews.FirstAsync(r => r.Id == Id && r.AccountId == accountId);

			context.Reviews.Remove(review);
		}
	}
}