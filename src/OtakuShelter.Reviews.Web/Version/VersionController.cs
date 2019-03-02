using Microsoft.Extensions.Options;

namespace OtakuShelter.Reviews
{
	public class VersionController
	{
		private readonly ReviewsConfiguration configuration;

		public VersionController(IOptions<ReviewsConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public ReadVersionResponse Version()
		{
			var response = new ReadVersionResponse();

			response.Read(configuration);

			return response;
		}
	}
}