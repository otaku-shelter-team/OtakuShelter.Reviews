using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Reviews
{
	public class UpdateReviewRequest
	{
		public int Rating { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public async ValueTask Update(ReviewsContext context, int accountId, int id)
		{
			var review = await context.Reviews.FirstAsync(r => r.Id == id && r.AccountId == accountId);

			review.Rating = Rating;
			review.Title = Title;
			review.Description = Description;
			review.Updated = DateTime.UtcNow;
		}
	}
}