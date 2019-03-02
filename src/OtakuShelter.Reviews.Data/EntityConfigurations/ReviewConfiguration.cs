using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OtakuShelter.Reviews
{
	internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.ToTable("reviews");

			builder.Property(r => r.Id)
				.HasColumnName("id")
				.UseNpgsqlIdentityColumn();
			
			builder.Property(r => r.AccountId)
				.HasColumnName("account_id")
				.IsRequired();

			builder.Property(r => r.MangaId)
				.HasColumnName("manga_id")
				.IsRequired();

			builder.HasIndex(r => new {r.AccountId, r.MangaId})
				.HasName("UQ_account_id_manga_id")
				.IsUnique();
			
			builder.Property(r => r.Rating)
				.HasColumnName("rating")
				.IsRequired();

			builder.Property(r => r.Title)
				.HasColumnName("title")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(r => r.Description)
				.HasColumnName("description")
				.HasMaxLength(5000)
				.IsRequired();

			builder.Property(r => r.Created)
				.HasColumnName("created")
				.IsRequired();

			builder.Property(r => r.Updated)
				.HasColumnName("updated");
		}
	}
}