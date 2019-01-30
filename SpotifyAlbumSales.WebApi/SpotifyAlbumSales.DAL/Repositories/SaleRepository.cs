using Microsoft.EntityFrameworkCore;
using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Repositories
{
    public class SaleRepository : RepositoryBase, ISaleRepository
    {
        public SaleRepository(ISpotifyAlbumSalesDbContext dbContext) : base(dbContext)
        {
        }

        public Task AddAsync(Sale sale)
        {
            return _dbContext.Add(sale);
        }

        public Task<List<Sale>> GetAsync(DateTime? initialDate, DateTime? finalDate, int page, int pageSize)
        {
            return _dbContext.SaleQuery
                .Where(x => 
                    (initialDate == null || x.CreatedDate >= initialDate) && 
                    (finalDate == null || x.CreatedDate <= finalDate))
                .OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public Task<Sale> GetByIdAsync(Guid id)
        {
            return _dbContext.SaleQuery.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
