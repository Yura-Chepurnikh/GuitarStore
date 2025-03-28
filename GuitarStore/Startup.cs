using GuitarStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Policy;

namespace GuitarStore.Models
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddSession();

			services.AddDbContext<GuitarStore.Models.Context>(options =>
				 options.UseNpgsql(Configuration.GetConnectionString("Context")));
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseSession();

			app.UseAuthentication();
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "Home",
					pattern: "{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "Home",
					pattern: "{controller=Home}/{action=Empty}/{id?}");

				endpoints.MapControllerRoute(
					name: "Home",
					pattern: "{controller=Home}/{action=Details}/{id?}");

				endpoints.MapControllerRoute(
					name: "Home",
					pattern: "{controller=Home}/{action=AboutUs}/{id?}");

				endpoints.MapControllerRoute(
					name: "Home",
					pattern: "{controller=Home}/{action=IndexIn}/{id?}");

				endpoints.MapControllerRoute(
					name: "Home",
					pattern: "{controller=Home}/{action=Exist}/{id?}");

				endpoints.MapControllerRoute(
					name: "Guitar",
					pattern: "{controller=Guitar}/{action=Create}/{id?}");
				endpoints.MapControllerRoute(
					name: "Guitar",
					pattern: "{controller=Guitar}/{action=Details}/{id?}");
		
				endpoints.MapControllerRoute(
					name: "Like",
					pattern: "{controller=Like}/{action=Like}/{id?}");

				endpoints.MapControllerRoute(
					name: "Like1",
					pattern: "{controller=Like}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "Category",
					pattern: "{controller=Category}/{action=Category}/{id?}");
		
				endpoints.MapControllerRoute(
					name: "Order",
					pattern: "{controller=Order}/{action=Order}/{id?}");

				endpoints.MapControllerRoute(
					name: "OrderSuccess",
					pattern: "{controller=Order}/{action=OrderSuccess}/{id?}");

				endpoints.MapControllerRoute(
					name: "Stock",
					pattern: "{controller=Stock}/{action=Stock}/{id?}");
	

				endpoints.MapControllerRoute(
					name: "Review",
					pattern: "{controller=Review}/{action=Index}/{id?}");


				endpoints.MapControllerRoute(
					name: "User",
					pattern: "{controller=User}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "Register/Register",
					pattern: "{controller=Register}/{action=Register}/{id?}");
				
				endpoints.MapControllerRoute(
					name: "Login",
					pattern: "{controller=Login}/{action=Login}/{id?}");

				endpoints.MapControllerRoute(
					name: "Login",
					pattern: "{controller=Login}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "Add",
					pattern: "{controller=AddToShoppingCart}/{action=Add}/{id?}");

				endpoints.MapControllerRoute(
					name: "Add2",
					pattern: "{controller=AddToShoppingCart}/{action=AddView}/{id?}");

				endpoints.MapControllerRoute(
					name: "RegisterSuccess",
					pattern: "Register/{action=RegisterSuccess}/{id?}",
					defaults: new { controller = "Register" });
			});
		}
	}
}