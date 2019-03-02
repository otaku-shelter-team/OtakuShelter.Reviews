using System.Runtime.Serialization;

namespace OtakuShelter.Reviews
{
	[DataContract]
	public class ReadVersionResponse
	{
		[DataMember(Name = "version")]
		public string Version { get; set; }

		public void Read(ReviewsConfiguration configuration)
		{
			Version = configuration.Version;
		}
	}
}