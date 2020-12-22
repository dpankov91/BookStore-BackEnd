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
            #region DBSettings
            if (Environment.IsDevelopment())
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
            }
            #endregion

            #region AddScoped
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookSQLRepository>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, GenreSQLRepository>();

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, AuthorSQLRepository>();

            services.AddTransient<IDataInitializer, DataInitializer>();
            #endregion

            #region CORS
            services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin()
                                                                                               .AllowAnyMethod()
                                                                                               .AllowAnyHeader()));
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region DBSettings
            if (env.IsDevelopment())
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
            }
            #endregion

            app.UseCors("AllowEverything");

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
