using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.ApplicationService.Implementation;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.DomainService;
using BookStore.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BookStore.Infrastructure.Data.Repositories;
using Newtonsoft.Json;
using BookStore.Core.ISecurity;
using BookStore.Infrastructure.Data.SecurityImplemintation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreDbContext
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region DB Settings Commented
            /*if (Environment.IsDevelopment())
            {
                services.AddDbContext<BookStoreDBContext>(
                    opt =>
                    {
                        opt.UseSqlite("Data Source = bookstore.db");
                    });
            }
            if (Environment.IsProduction())
            {
                services.AddDbContext<BookStoreDBContext>(
                    opt =>
                    {
                        opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                    });
            }*/
            #endregion

            #region DB DevOps
            services.AddDbContext<BookStoreDBContext>(
              opt =>
              {
                  opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
              });
            #endregion

            #region AddScoped
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookSQLRepository>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, GenreSQLRepository>();

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, AuthorSQLRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserSQLRepository>();

            services.AddTransient<IDataInitializer, DataInitializer>();
            #endregion

            #region Authentication

            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
            // Register the AuthenticationHelper in the helpers folder for dependency
            // injection. It must be registered as a singleton service. The AuthenticationHelper
            // is instantiated with a parameter. The parameter is the previously created
            // "secretBytes" array, which is used to generate a key for signing JWT tokens,
            services.AddSingleton<IAuthenticationHelper>(new
                AuthenticationHelper(secretBytes));
            #endregion

            #region CORS
            services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin()
                                                                                               .AllowAnyMethod()
                                                                                               .AllowAnyHeader()));
            #endregion

            #region Ignore Loops
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region DB Settings Commented
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using var scope = app.ApplicationServices.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<BookStoreDBContext>();
                var dataInitializer = scope.ServiceProvider.GetRequiredService<IDataInitializer>();

                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                dataInitializer.SeedDB(ctx);
            }
            else if (env.IsProduction())
            {
                using var scope = app.ApplicationServices.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<BookStoreDBContext>();
                var dataInitializer = scope.ServiceProvider.GetRequiredService<IDataInitializer>();

                ctx.Database.EnsureCreated();

                dataInitializer.SeedDB(ctx);
            }*/
            #endregion

            #region db DevOps
            using var scope = app.ApplicationServices.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<BookStoreDBContext>();
            var dataInitializer = scope.ServiceProvider.GetRequiredService<IDataInitializer>();

            ctx.Database.EnsureCreated();

            dataInitializer.SeedDB(ctx);
            #endregion

            app.UseCors("AllowEverything");

            app.UseAuthentication();

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
