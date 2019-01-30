using EasySoccer.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyAlbumSales.Api.Infra;
using SpotifyAlbumSales.Api.UoWs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.Api.Controllers
{
    [Produces("application/json")]
    public class AlbumController : ApiBaseController
    {
        private AlbumUoW _uow;
        private IHttpClientFactory _httpClientFactory;
        private IExternalData _externalData;

        public AlbumController(AlbumUoW uow, [FromServices]IHttpClientFactory httpClientFactory, IExternalData externalData) : base(uow)
        {
            _uow = uow;
            _httpClientFactory = httpClientFactory;
            _externalData = externalData;
        }

        [Route("api/album/get"), HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]int? genreId, [FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            return Ok(await _uow.AlbumBLL.GetAsync(genreId, page, pageSize));
        }

        [Route("api/album/getbyid"), HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery]Guid albumId)
        {
            return Ok(await _uow.AlbumBLL.GetByIdAsync(albumId));
        }

        [Route("api/album/filldata"), HttpPost]
        public async Task<IActionResult> PostFillDataAsync()
        {
            var authClient = _httpClientFactory.CreateClient("SpotifyHttpClientAuth");
            var authResponse = await _externalData.AuthenticationAsync(authClient);
            var queryClient = _httpClientFactory.CreateClient("SpotifyHttpClientSearch");
            queryClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + authResponse.access_token);
            var genres = await _uow.AlbumBLL.GetGenresAsync();
            foreach (var genre in genres)
            {
                var searchResponse = await _externalData.SearchByGenreAsync(queryClient, authResponse, genre.Name);
                await _uow.AlbumBLL.AddAlbunsAsync(searchResponse.albums.items.Select(x => x.name).ToList(), genre.Id);
            }
            return Ok();
        }
    }
}