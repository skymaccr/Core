using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Data;

namespace OdeToFood
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
            //le da la conexion al db context
            services.AddDbContextPool<OdeToFoodDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            });

            //hace la inyeccion de dependencias. Cuando alguien pregunte por un IRestaurant dele un SQLRestaurantData
            services.AddScoped<IRestaurantData, SQLRestaurantData>();


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.Use(SayHelloMiddleware);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env); //para activar que la aplicacion lea y vea el folder node_modules
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private RequestDelegate SayHelloMiddleware(RequestDelegate arg)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/hola"))
                    await ctx.Response.WriteAsync("Hola mundo");
                else
                    await arg(ctx);
            };                 
        }
    }
}
