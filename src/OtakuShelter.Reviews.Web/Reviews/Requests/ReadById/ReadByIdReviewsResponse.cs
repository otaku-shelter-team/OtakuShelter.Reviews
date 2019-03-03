using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Reviews
{
	[DataContract]
	public class ReadByIdReviewsResponse
	{
		[DataMember(Name = "rating")]
		public double Rating { get; set; }
		
		[DataMember(Name = "reviews")]
		public ICollection<ReadByIdReviewsResponseItem> Reviews { get; set; }

		public async ValueTask ReadById(ReviewsContext context, FilterRequest filter, int mangaId)
		{
			Rating = await context.Reviews
				.Select(r => r.Rating)
				.AverageAsync();
			
			Reviews = await context.Reviews
				.AsNoTracking()
				.Where(review => review.MangaId == mangaId)
				.OrderByDescending(review => review.Created)
				.Skip(filter.Offset)
				.Take(filter.Limit)
				.Select(review => new ReadByIdReviewsResponseItem(review))
				.ToListAsync();
		}
	}
}