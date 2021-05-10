//using Flash.Park.Data;
using AutoMapper;
using Flash.Park.Data;
using Flash.Park.Mappers;
using Flash.Park.Repositories;
using Flash.Park.Repositories.Abstractions;
using Flash.Park.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Flash.Park
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
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<LocationMapper>());
            services.AddSingleton(config.CreateMapper());
            services.AddControllersWithViews(options => options.SuppressAsyncSuffixInActionNames = false)
                .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );
            services.AddMvc()
           .AddMvcOptions(options =>
           {
               options.AllowEmptyInputInBodyModelBinding = true;
               options.EnableEndpointRouting = false;
           })
           .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
           .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddDbContext<FlashParkContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("SqlConnection")));

            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ISlotService, SlotService>();
            services.AddTransient<ISlotRepository, SlotRepository>();
            services.AddTransient<IFloorRepository, FloorRepository>();
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", GetOpenApiInfo());
            });
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "Coding Exercise API");
                options.RoutePrefix = "/swagger";
            });

            app.UseSpa(spa =>
            {               
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private static OpenApiInfo GetOpenApiInfo()
        {
            return new OpenApiInfo()
            {
                Title = "Parking Coding Challenge API",
                Version = $"version: {GetAssemblyVersion()}",
                Description = "This provides restful endpoints for CRUD operations for a parking company.",
            };
        }

        private static string GetAssemblyVersion()
        {
            return typeof(Startup).Assembly.GetName().Version.ToString();
        }
    }
}
