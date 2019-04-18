using Data.DbContext.Configuration;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using SecretKey = Data.Model.SecretKey;

namespace Data.DbContext
{
	public class PaymentSystemContext: Microsoft.EntityFrameworkCore.DbContext
	{
		public PaymentSystemContext(DbContextOptions<PaymentSystemContext> options)
		  : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AccountConfiguration());
			modelBuilder.ApplyConfiguration(new SellerConfiguration());
			modelBuilder.ApplyConfiguration(new PlatformConfiguration());
			modelBuilder.ApplyConfiguration(new SecretKeyConfiguration());
			modelBuilder.ApplyConfiguration(new PlatformConfiguration());
	
			modelBuilder.ApplyConfiguration(new PlatformSellerConfiguration());		
		}

		public DbSet<Account> Accounts { get; set; }
		public DbSet<Seller> Sellers { get; set; }
		public DbSet<Platform> Platforms { get; set; }
		public DbSet<SecretKey> SecretKeys { get; set; }
	}
}
