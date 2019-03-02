namespace OtakuShelter.Reviews
{
	public class ReviewsConfiguration
	{
		public string Name { get; set; }
		
		public ReviewsDatabaseConfiguration Database { get; set; }
		public ReviewsJwtConfiguration Jwt { get; set; }
		public ReviewsRabbitMqConfiguration RabbitMq { get; set; }
		public ReviewsRoleConfiguration Roles { get; set; }
	}
}