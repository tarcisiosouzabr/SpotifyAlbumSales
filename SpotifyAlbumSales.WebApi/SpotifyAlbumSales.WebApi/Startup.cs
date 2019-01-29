using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using SpotifyAlbumSales.BLL;
using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL;
using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using SpotifyAlbumSales.DAL.Repositories;
using SpotifyAlbumSales.WebApi.UoWs;
using Swashbuckle.AspNetCore.Swagger;

namespace SpotifyAlbumSales.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ISpotifyAlbumSalesDbContext, SpotifyAlbumSalesDbContext>(
                        x => x.UseSqlServer("Data Source=DESKTOP-VKO2HQV\\SQLEXPRESS;Initial Catalog=Spotify;Integrated Security=True"));

            #region UoW's
            services.AddScoped<AlbumUoW, AlbumUoW>();
            services.AddScoped<SaleUoW, SaleUoW>();
            #endregion

            #region BLL's
            services.AddScoped<IAlbumBLL, AlbumBLL>();
            services.AddScoped<ISaleBLL, SaleBLL>();
            #endregion

            #region Repositories
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IGenreCashbackRepository, GenreCashbackRepository>();
            services.AddScoped<ISaleItemRepository, SaleItemRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Spotify Album Sales Documentation",
                        Version = PlatformServices.Default.Application.ApplicationVersion,
                        Description = "Documentation",
                        Contact = new Contact
                        {
                            Name = "Tarcisio Vitor",
                            Email = "tarcisiosouzabr@gmail.com"
                        }
                    });
                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Spotify Album Sales Documentation");
            });
        }
    }
}
