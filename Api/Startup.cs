using Api.Service;
using Data.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Service.Implementation;
using Service.Interface;

namespace Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var cs = CreateConnectionString();

			services.AddDbContext<PaymentSystemContext>(options => 
				options.UseMySql(cs));

			services.AddScoped<ISellerService, SellerService>();
			services.AddScoped<IPlatformService, PlatformService>();
			services.AddScoped<IHashingService, HashingService>();
			services.AddScoped<IAccountProvider, AccountProvider>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		private string CreateConnectionString()
		{
			//todo(max): move to appsettings
			var sb = new MySqlConnectionStringBuilder();
			sb.Server = "localhost";
			sb.Database = "payment_system";
			sb.Password = "root";
			sb.UserID = "root";
			sb.Port = 3306;

			return sb.ConnectionString;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
