using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Pds.ControleVendas.Api
{
	public class Startup
	{
		private const string SWAGGER_URI = "/swagger/v1/swagger.json";
		private IAmazonS3 awsS3Client;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			var options = Configuration.GetAWSOptions();
			awsS3Client = options.CreateServiceClient<IAmazonS3>();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddSwaggerGen(a =>
			{
				a.SwaggerDoc("v1", new Info()
				{
					Version = "v1",
					Contact = new Contact() { Email = "monica.bizzotto@hotmail.com" },
					Description = "POC Dropshipping - Api Controle Vendas",
					Title = "POC Dropshipping - Api Controle Vendas"
				});
			});

			services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
			services.AddAWSService<IAmazonS3>();
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

			app.UseSwagger();
			app.UseSwaggerUI(a =>
			{
				a.SwaggerEndpoint(SWAGGER_URI, "POC Dropshipping - Api Controle Vendas");
			});

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
