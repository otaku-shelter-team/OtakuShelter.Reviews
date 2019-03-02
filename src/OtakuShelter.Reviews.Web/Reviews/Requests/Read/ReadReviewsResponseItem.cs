using System;
using System.Runtime.Serialization;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OtakuShelter.Reviews
{
	[DataContract]
	public class ReadReviewsResponseItem
	{
		public ReadReviewsResponseItem(Review review)
		{
			Id = review.Id;
			MangaId = review.MangaId;
			Rating = review.Rating;
			Title = review.Title;
			Description = review.Description;
			Created = review.Created;
			Updated = review.Updated;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
		
		[DataMember(Name = "mangaId")]
		public int MangaId { get; set; }
		
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