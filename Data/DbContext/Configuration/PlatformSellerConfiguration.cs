using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DbContext.Configuration
{
	internal class PlatformSellerConfiguration : IEntityTypeConfiguration<PlatformSeller>
	{
		public void Configure(EntityTypeBuilder<PlatformSeller> builder)
		{
			builder.ToTable("platform_seller");
			builder.HasKey(x => new { x.SellerId, x.PlatformId });
			builder.HasOne(x => x.Platform).WithMany(p => p.PlatformSellers);
			builder.HasOne(x => x.Seller).WithMany(p => p.PlatformSellers);
			builder.Property(x => x.PlatformId).HasColumnName("id_platform");
			builder.Property(x => x.SellerId).HasColumnName("id_seller");
		}
	}
}
