
using CompanyWebSiteCore.Models;
using CompanyWebSiteCore.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using CompanyWebSiteCore.Models.Repositores;

namespace CompanyWebSiteCore
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
            services.AddDbContext<CompanyDbContext>(Options =>
            {
                Options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.AddMvc()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(CompanyDataResource).GetTypeInfo().Assembly.FullName);
                    return factory.Create("CompanyDataResource", assemblyName.Name);
                };

            });
           
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                  new CultureInfo("en"),
                  new CultureInfo("ar"),

                };
              
                options.DefaultRequestCulture = new RequestCulture("en");               
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

           

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton<LocalizationService>();
            services.AddScoped<IRepository<CompanyData>, CompanyDataRepository>();
            services.AddScoped<IRepository<ServicesData>, ServicesDataReository>();
            services.AddScoped<IRepository<ProductsData>, ProductsDataReository>();
            services.AddScoped<IRepository<CustomersData>, CustomersDataReository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            var requestlocalizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(requestlocalizationOptions.Value);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
