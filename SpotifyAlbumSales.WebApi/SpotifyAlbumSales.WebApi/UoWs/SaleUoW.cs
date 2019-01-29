using EasySoccer.WebApi.UoWs;
using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL.Infra;

namespace SpotifyAlbumSales.WebApi.UoWs
{
    public class SaleUoW : UoWBase
    {
        public ISaleBLL SaleBLL { get; set; }
        public SaleUoW(ISpotifyAlbumSalesDbContext dbContext, ISaleBLL saleBLL) : base(dbContext)
        {
            SaleBLL = saleBLL;
        }
    }
}
