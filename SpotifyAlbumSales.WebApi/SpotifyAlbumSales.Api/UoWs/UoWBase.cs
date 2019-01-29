
using SpotifyAlbumSales.DAL.Infra;
using System;

namespace SpotifyAlbumSales.Api.UoWs
{
    public class UoWBase : IDisposable
    {
        private ISpotifyAlbumSalesDbContext _dbContext;
        public UoWBase(ISpotifyAlbumSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

