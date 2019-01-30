using EasySoccer.WebApi.UoWs;
using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL.Infra;

namespace SpotifyAlbumSales.WebApi.UoWs
{
    public class AlbumUoW : UoWBase
    {
        public IAlbumBLL AlbumBLL { get; set; }
        public AlbumUoW(ISpotifyAlbumSalesDbContext dbContext, IAlbumBLL albumBLL) : base(dbContext)
        {
            AlbumBLL = albumBLL;
        }
    }
}
