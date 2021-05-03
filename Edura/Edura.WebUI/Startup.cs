using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Repository.Abstract;
using Edura.WebUI.Repository.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Edura.WebUI
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
            //Middleware (Configure kısım aşağıda) işlemleri için aşağıdaki kodları ekliyoruz.
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<EduraContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefCon")));
            services.AddTransient<IProductRepository, EfProductRepository>(); 
            services.AddTransient<ICategoryRepository, EfCategoryRepository>(); 
            services.AddTransient<IUnitofWork, EfUnitOfWork>();

            services.AddMemoryCache(); //bunları perşembe günü yaptık
            services.AddSession();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,EduraContext context)
        {
            //Use ile başlayan işlemler middleware nin aktif edildiğini belirtir.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedData.EnsurePopulated(context);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"node_modules")),RequestPath=new PathString("/vendor") //node_modules ün ismini vendor olarak değitirmemizin sebebi sayfa kaynağında node_modules ü gizlemek.
            }); //wwwroot kısmını declare ediyor.
            
            app.UseCookiePolicy();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "products",
                    template: "products/{category?}",
                    defaults: new { controller="Product",action="List"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedData.EnsurePopulated(context);
        }
    }
}
