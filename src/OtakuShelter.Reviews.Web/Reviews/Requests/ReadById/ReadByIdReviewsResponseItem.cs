using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Reviews
{
	public class ReadByIdReviewsResponseItem
	{
		public ReadByIdReviewsResponseItem(Review review)
		{
			Id = review.Id;
			AccountId = review.AccountId;
			Rating = review.Rating;
			Title = review.Title;
			Description = review.Description;
			Created = review.Created;
			Updated = review.Updated;
		}

		[DataMember(Name = "id")]
		public int Id { get; set; }
		
		[DataMember(Name = "accountId")]
		public int AccountId { get; set; }
		
		[DataMember(Name = "rating")]
		public int Rating { get; set; }
		
		[DataMember(Name = "title")]
		public string Title { get; set; }
		
		[DataMember(Name = "description")]
		public string Description { get; set; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; set; }
		
		[DataMember(Name = "updated")]
		public DateTime? Updated { get; set; }
	}
}