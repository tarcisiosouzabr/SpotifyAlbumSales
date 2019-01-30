using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotifyAlbumSales.Api.Controllers;
using SpotifyAlbumSales.Api.Infra;
using SpotifyAlbumSales.Api.UoWs;
using SpotifyAlbumSales.BLL;
using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL;
using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using SpotifyAlbumSales.DAL.Repositories;
using System;
using System.Net.Http.Headers;

namespace SpotifyAlbumSales.Api
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
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSingleton(Configuration);
            services.AddDbContext<ISpotifyAlbumSalesDbContext, SpotifyAlbumSalesDbContext>(
                        x => x.UseSqlServer(Configuration.GetConnectionString("SpotifyAlbumSalesDbContext")));

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

            services.AddScoped<IExternalData, ExternalData>();

            services.AddSwaggerDocument();

            services.AddHttpClient("SpotifyHttpClientAuth", client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));    
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("SpotifyApi:ClientId").Value + ":" + Configuration.GetSection("SpotifyApi:ClientSecret").Value);
                var clientIdSecretBase64 = System.Convert.ToBase64String(plainTextBytes);
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + clientIdSecretBase64);
                client.BaseAddress = new Uri(Configuration.GetSection("SpotifyApi:AuthUrl").Value);
            });

            services.AddHttpClient("SpotifyHttpClientSearch", client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(Configuration.GetSection("SpotifyApi:SearchUrl").Value);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseMvc();
        }
    }
}
