
using Microsoft.AspNetCore.Mvc;
using SpotifyAlbumSales.Api.UoWs;

namespace EasySoccer.Api.Controllers.Base
{
    public class ApiBaseController : Controller
    {
        private UoWBase _uow;
        public ApiBaseController(UoWBase uow)
        {
            _uow = uow;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
                _uow.Dispose();
        }
    }
}
