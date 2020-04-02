using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json; // Needs to be added.
using Microsoft.EntityFrameworkCore; // Needs to be added.
using CurrencyTask.Repositories; // Needs to be added.
using CurrencyTask.Services; // Needs to be added.
using CurrencyTask.Models; // Needs to be added.

namespace CurrencyTask
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
			services.AddScoped<ICurrencyRepository, CurrencyRepository>();
			services.AddScoped<ICurrencyService, CurrencyService>();

			services.AddDbContext<DtbankdbContext>(option =>
			{
				// Here needs to be AzurePersonConnectionString. See appsettings.json
				option.UseSqlServer(Configuration.GetConnectionString("AzurePersonConnectionString"));
			});

			services.AddControllers();

			// Ignore JSON serialization
			services.AddMvc().AddNewtonsoftJson(json => json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			// MVC must be last service. Tässä muutos CompatibilityVersion.Version_3_0
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
