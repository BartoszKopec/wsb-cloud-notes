using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.API.Services;
using System;

namespace Notes.API
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			string dbConnectionString = Environment.GetEnvironmentVariable(Constants.ENV_VAR_CONNECTION_STRING);
			services.AddDbContext<NotesDbContext>(opt =>
			{
				opt.UseSqlServer(dbConnectionString);
			});

			services.AddControllers().AddJsonOptions((config) =>
			{
				config.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
