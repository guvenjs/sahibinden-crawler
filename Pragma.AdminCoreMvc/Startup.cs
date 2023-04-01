using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Pragma.AdminCore.Data;
using Pragma.AdminCore.Data.Models.Entities;
using Pragma.AdminCore.Data.Repository;
using Pragma.AdminCoreMvc.Helper;
using Pragma.AdminCoreMvc.Helper.Models;
using Pragma.AdminCoreMvc.Services;
using Pragma.AdminCoreMvc.Services.Settings;
using System;
using System.Globalization;
using System.IO;

namespace Pragma.AdminCoreMvc
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc(setupAction =>
            {
                setupAction.EnableEndpointRouting = false;
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<PanelInfo>(Configuration.GetSection("PanelInfo"));
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.Configure<UploadImageSettings>(Configuration.GetSection("UploadImageSettings"));
            services.AddTransient<UploadFileProcessor, UploadFileProcessor>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            var cultureInfo = new CultureInfo("tr-TR");
            cultureInfo.NumberFormat.CurrencySymbol = "₺";
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
                RequestPath = "/Uploads"
            });
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
