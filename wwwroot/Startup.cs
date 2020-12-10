using Difi.Sjalvdeklaration.Database;
using Difi.Sjalvdeklaration.Database.DbContext;
using Difi.Sjalvdeklaration.Log;
using Difi.Sjalvdeklaration.Shared.Interface;
using Difi.Sjalvdeklaration.wwwroot.Business;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
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
using System;
using System.Globalization;
using System.IO;
using Cache;
using Swashbuckle.AspNetCore.Swagger;

namespace Difi.Sjalvdeklaration.wwwroot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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

            services.ConfigureExternalCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
            });

            services.AddAntiforgery(options =>
            {
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            services.AddDbContext<ApplicationDbContext>(optionsBuilder1 => optionsBuilder1.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), optionsBuilder2 => optionsBuilder2.MigrationsAssembly("Difi.Sjalvdeklaration.wwwroot")));
            services.AddDbContext<LogDbContext>(optionsBuilder1 => optionsBuilder1.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), optionsBuilder2 => optionsBuilder2.MigrationsAssembly("Difi.Sjalvdeklaration.wwwroot")));

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IDeclarationRepository, DeclarationRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IValueListRepository, ValueListRepository>();

            if (Convert.ToBoolean(Configuration["Log:Active"]))
            {
                services.Decorate<IUserRepository, UserRepositoryLogDecorator>();
                services.Decorate<ICompanyRepository, CompanyRepositoryLogDecorator>();
                services.Decorate<IDeclarationRepository, DeclarationRepositoryLogDecorator>();
                services.Decorate<IRoleRepository, RoleRepositoryLogDecorator>();
                services.Decorate<IValueListRepository, ValueListRepositoryLogDecorator>();
            }

            services.Decorate<IDeclarationRepository, DeclarationRepositoryCacheDecorator>();
            services.Decorate<ICompanyRepository, CompanyRepositoryCacheDecorator>();

            services.AddScoped<IImageRepository, ImageRepository>();
            if (Convert.ToBoolean(Configuration["Log:Active"]))
            {
                services.Decorate<IImageRepository, ImageRepositoryLogDecorator>();
            }

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IApiHttpClient, ApiHttpClient>();
            services.AddScoped<IErrorHandler, ErrorHandler>();
            services.AddScoped<IExcelGenerator, ExcelGenerator>();

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
                    options.Cookie.SameSite = SameSiteMode.None;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
            });

            services.AddMemoryCache();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Difi - Egenkontroll", Version = "v1" });
                options.OperationFilter<ApiHeaderOperationFilter>();

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Difi.Sjalvdeklaration.Api.xml");
                options.IncludeXmlComments(xmlPath);
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
                new CultureInfo("nb-NO"),
                new CultureInfo("nn-NO"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("nb-NO"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Difi - Egenkontroll V1");
            });

            app.UseMvc();
        }
    }
}