using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Repositories
{
    public class SaleItemRepository : RepositoryBase, ISaleItemRepository
    {
        public SaleItemRepository(ISpotifyAlbumSalesDbContext dbContext) : base(dbContext)
        {
        }

        public Task AddAsync(SaleItem saleItem)
        {
            return _dbContext.Add(saleItem);
        }
    }
}
