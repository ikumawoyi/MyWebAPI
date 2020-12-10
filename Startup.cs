using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using MyWebAPI.Repositories;
using MyWebAPI.ProductsRepo;

namespace MyWebAPI
{
	public class Startup
	{
		private readonly IConfiguration Configuration;
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		//public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();


			services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDbConnection")));

			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IProductsService, ProductsService>();
			services.AddScoped<IDoctorsRepository, DoctorsRepository>();
			services.AddScoped<INursesRepository, NursesRepository>();
			services.AddScoped<IPatientsRepository, PatientsRepository>();
			services.AddScoped<IRoomsRepository, RoomsRepository>();
			services.AddScoped<IUsersRepository, UsersRepository>();
			services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
			services.AddScoped<IRoastersRepository, RoastersRepository>();
			services.AddScoped<IFacilitatorRepository, FacilitatorsRepository>();
			services.AddScoped<ICoursesRepository, CoursesRepository>();
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
