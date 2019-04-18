using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DbContext.Configuration
{
	internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
	{
		public void Configure(EntityTypeBuilder<Seller> builder)
		{
			builder.ToTable("seller");
			builder.HasKey(x => x.Id);
			builder.HasOne(s => s.Account).WithOne().HasForeignKey<Seller>(s => s.AccountId);
			builder.Property(s => s.AccountId).HasColumnName("id_account").IsRequired();
			builder.Property(x => x.PublicKey).HasColumnName("public_key").IsRequired();
		}
	}
}
