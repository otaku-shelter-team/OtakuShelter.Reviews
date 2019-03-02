using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Reviews
{
	[DataContract]
	public class AdminUpdateByIdReviewRequest
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "description")]
		public string Description { get; set; }

		public async ValueTask UpdateById(ReviewsContext context, int id)
		{
			var review = await context.Reviews.FirstAsync(r => r.Id == id);

			review.Title = Title;
			review.Description = Description;
		}
	}
}