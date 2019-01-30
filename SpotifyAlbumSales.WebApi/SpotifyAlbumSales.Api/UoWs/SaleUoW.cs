
using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL.Infra;

namespace SpotifyAlbumSales.Api.UoWs
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
