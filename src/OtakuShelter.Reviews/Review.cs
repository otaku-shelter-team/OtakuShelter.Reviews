using System;

namespace OtakuShelter.Reviews
{
	public class Review
	{
		public int Id { get; set; }
		public int AccountId { get; set; }
		public int MangaId { get; set; }
		public int Rating { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
	}
}