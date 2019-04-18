using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DbContext.Configuration
{
	internal class SecretKeyConfiguration : IEntityTypeConfiguration<SecretKey>
	{
		public void Configure(EntityTypeBuilder<SecretKey> builder)
		{
			builder.ToTable("secret_key");
			builder.HasKey(x => x.AccountId);
			builder.HasOne(s => s.Account).WithOne(a=>a.SecretKey).HasForeignKey<SecretKey>(s => s.AccountId);
			builder.Property(s => s.AccountId).HasColumnName("id_account").IsRequired();
			builder.Property(s => s.Value).HasColumnName("value").IsRequired();
		}
	}
}
	
