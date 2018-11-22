using System;
using System.Globalization;
using Difi.Sjalvdeklaration.Database;
using Difi.Sjalvdeklaration.Shared.Interface;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Log;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Difi.Sjalvdeklaration.wwwroot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var test = new FineUploaderAzureServer();

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(optionsBuilder1 => optionsBuilder1.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), optionsBuilder2 => optionsBuilder2.MigrationsAssembly("Difi.Sjalvdeklaration.wwwroot")));
            services.AddDbContext<LogDbContext>(optionsBuilder1 => optionsBuilder1.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), optionsBuilder2 => optionsBuilder2.MigrationsAssembly("Difi.Sjalvdeklaration.wwwroot")));

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.AddScoped<IUserRepository, UserRepository>();
            services.Decorate<IUserRepository, UserRepositoryLogDecorator>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.Decorate<ICompanyRepository, CompanyRepositoryLogDecorator>();

            services.AddScoped<IDeclarationRepository, DeclarationRepository>();
            services.Decorate<IDeclarationRepository, DeclarationRepositoryLogDecorator>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.Decorate<IRoleRepository, RoleRepositoryLogDecorator>();

            services.AddScoped<IValueListRepository, ValueListRepository>();
            services.Decorate<IValueListRepository, ValueListRepositoryLogDecorator>();

            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IApiHttpClient, ApiHttpClient>();

            services.AddDistributedMemoryCache();

            services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/");
                    options.AccessDeniedPath = new PathString("/error?unauth");
                    options.ExpireTimeSpan = TimeSpan.FromDays(60);
                    options.SlidingExpiration = true;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("no"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("no-NB"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}