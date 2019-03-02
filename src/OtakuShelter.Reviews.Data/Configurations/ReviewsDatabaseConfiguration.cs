using Phema.Configuration;

namespace OtakuShelter.Reviews
{
	[Configuration]
	public class ReviewsDatabaseConfiguration
	{
		public string MigrationsTable { get; set; } = "migrations";
		public string Host { get; set; }
		public int Port { get; set; }
		public string Database { get; set; }
		public string UserId { get; set; }
		public string Password { get; set; }

		public string ConnectionString =>
			$"host={Host}; port={Port}; database={Database}; user id={UserId}; password={Password};";
	}
}