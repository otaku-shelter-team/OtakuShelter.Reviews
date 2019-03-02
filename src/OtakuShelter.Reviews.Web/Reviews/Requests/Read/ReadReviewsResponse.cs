using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Reviews
{
	[DataContract]
	public class ReadReviewsResponse
	{
		[DataMember(Name = "reviews")]
		public ICollection<ReadReviewsResponseItem> Reviews { get; set; }

		public async ValueTask Read(ReviewsContext context, FilterRequest filter, int accountId)
		{
			Reviews = await context.Reviews
				.AsNoTracking()
				.Where(review => review.AccountId == accountId)
				.OrderByDescending(review => review.Created)
				.Skip(filter.Offset)
				.Take(filter.Limit)
				.Select(review => new ReadReviewsResponseItem(review))
				.ToListAsync();
		}
	}
}