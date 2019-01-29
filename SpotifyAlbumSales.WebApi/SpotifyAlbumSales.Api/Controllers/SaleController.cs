using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasySoccer.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using SpotifyAlbumSales.Api.UoWs;

namespace SpotifyAlbumSales.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ApiBaseController
    {
        private SaleUoW _uow;
        public SaleController(SaleUoW uow) : base(uow)
        {
            _uow = uow;
        }

        [Route("/get"), HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]DateTime initialDate, [FromQuery]DateTime finalDate, [FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            return Ok(await _uow.SaleBLL.GetAsync(initialDate, finalDate, page, pageSize));
        }

        [Route("/{saleId}"), HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery]Guid saleId)
        {
            return Ok(await _uow.SaleBLL.GetByIdAsync(saleId));
        }

        [Route("/post"), HttpPost]
        public async Task<IActionResult> PostSaleAsync([FromBody]Guid[] albumId)
        {
            return Ok(await _uow.SaleBLL.SaleAsync(albumId));
        }

    }
}