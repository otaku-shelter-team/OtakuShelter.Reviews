using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Reviews
{
	[DataContract]
	public class AdminDeleteByIdReviewRequest
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		public async ValueTask DeleteById(ReviewsContext context)
		{
			var review = await context.Reviews.FirstAsync(r => r.Id == Id);

			context.Reviews.Remove(review);
		}
	}
}