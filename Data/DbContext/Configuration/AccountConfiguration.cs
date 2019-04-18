using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DbContext.Configuration
{
	internal class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.ToTable("account");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(256).IsRequired();
			builder.Property(x => x.PasswordHash).HasColumnName("password_hash").HasMaxLength(256).IsRequired();
			builder.Property(x => x.DateVerified).HasColumnName("date_verified");
		}
	}
}
