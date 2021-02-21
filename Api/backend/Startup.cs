using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.Context;
using Api.Service;
using Api.Service.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

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
			services.AddDbContextPool<JobAdderDemoContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("JobadderAppCon")));
			services.AddSingleton<MemoryCacheService, MemoryCacheService>();
			services.AddScoped<IJob, JobService>();
			services.AddScoped<ICandidate, CandidateService>();
			services.AddCors(c =>
			{
				c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});

			services.AddControllersWithViews();
			services.AddControllers();

			services.AddAuthentication("Basic")
				.AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Basic", null);

			services.AddSingleton<ICustomAuthenticationManager, CustomAuthenticationManagerService>();

			services.AddHttpClient<MatchingCandidatesService>(configureClient =>
			{
				configureClient.BaseAddress = new Uri("http://private-76432-jobadder1.apiary-mock.com");
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
