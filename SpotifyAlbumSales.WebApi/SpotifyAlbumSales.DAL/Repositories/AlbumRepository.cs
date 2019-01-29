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
    public class AlbumRepository : RepositoryBase, IAlbumRepository
    {
        public AlbumRepository(ISpotifyAlbumSalesDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Album>> GetAsync(int? genreId, int page, int pageSize)
        {
            return _dbContext.AlbumQuery.Where(x => (genreId == null) || x.GenreId == genreId).OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        public Task<Album> GetByIdAsync(Guid id)
        {
            return _dbContext.AlbumQuery.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
