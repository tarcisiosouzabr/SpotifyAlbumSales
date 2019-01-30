using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using SpotifyAlbumSales.Api.Controllers;
using SpotifyAlbumSales.Api.Infra;
using SpotifyAlbumSales.Api.UoWs;
using SpotifyAlbumSales.BLL;
using SpotifyAlbumSales.DAL;
using SpotifyAlbumSales.DAL.Repositories;
using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotifyAlbumSales.WebApi.Test
{
    public class AlbumControllerTest
    {

        public AlbumControllerTest()
        {
            InitContext();
        }

        private SpotifyAlbumSalesDbContext _dbContext;

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<SpotifyAlbumSalesDbContext>()
                .UseInMemoryDatabase();

            var context = new SpotifyAlbumSalesDbContext(builder.Options);
            var albuns = Enumerable.Range(1, 10)
                .Select(i => new Album { Id = Guid.NewGuid(), Name = $"Teste Album {i}", GenreId = 1, Value = 10.00M });
            var genres = Enumerable.Range(1, 10)
                    .Select(i => new Genre { Id = i, Name = $"Teste Genero {i}" });

            context.Genre.AddRange(genres);
            context.Album.AddRange(albuns);
            int changed = context.SaveChanges();
            _dbContext = context;
        }

        [Fact]
        private async Task GetAll()
        {
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var controller = new AlbumController(
                new AlbumUoW(_dbContext, new AlbumBLL(new AlbumRepository(_dbContext), new GenreRepository(_dbContext), _dbContext))
                , httpClientFactoryMock, new ExternalData());
            var result = await controller.GetAsync(1);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var albuns = okResult.Value.Should().BeAssignableTo<List<Album>>().Subject;
            albuns.Count.Should().BeGreaterThan(1);
        }
    }
}
