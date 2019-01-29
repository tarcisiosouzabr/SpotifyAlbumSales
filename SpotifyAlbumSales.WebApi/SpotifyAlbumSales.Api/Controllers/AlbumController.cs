using EasySoccer.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using SpotifyAlbumSales.Api.UoWs;
using System;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.Api.Controllers
{
    [Produces("application/json")]
    public class AlbumController : ApiBaseController
    {
        private AlbumUoW _uow;
        public AlbumController(AlbumUoW uow) : base(uow)
        {
            _uow = uow;
        }

        [Route("api/album/get"), HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]int? genreId, [FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            return Ok(await _uow.AlbumBLL.GetAsync(genreId, page, pageSize));
        }

        [Route("/{albumId}"), HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery]Guid albumId)
        {
            return Ok(await _uow.AlbumBLL.GetByIdAsync(albumId));
        }
    }
}