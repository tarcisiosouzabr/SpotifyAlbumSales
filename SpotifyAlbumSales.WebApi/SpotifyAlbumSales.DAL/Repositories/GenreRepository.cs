using Microsoft.EntityFrameworkCore;
using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using SpotifyAlbumSales.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Repositories
{
    public class GenreRepository : RepositoryBase, IGenreRepository
    {
        public GenreRepository(ISpotifyAlbumSalesDbContext dbContext) : base(dbContext)
        {
        }

        public Task AddAsync(Genre genre)
        {
            return _dbContext.Add(genre);
        }

        public async Task<List<Genre>> GetGenresToSearchAsync()
        {
            return await _dbContext.GenreQuery.ToListAsync();
        }


    }
}
