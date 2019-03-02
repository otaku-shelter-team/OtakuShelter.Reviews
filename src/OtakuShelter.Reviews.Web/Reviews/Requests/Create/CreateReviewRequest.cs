using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Reviews
{
	[DataContract]
	public class CreateReviewRequest
	{
		[DataMember(Name = "rating")]
		public int Rating { get; set; }
		
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "description")]
		public string Description { get; set; }

		public async ValueTask Create(ReviewsContext context, int accountId, int mangaId)
		{
			var review = new Review
			{
				Rating = Rating,
				Title = Title,
				Description = Description,
				AccountId = accountId,
				MangaId = mangaId,
				Created = DateTime.UtcNow
			};

			await context.Reviews.AddAsync(review);
		}
	}
}