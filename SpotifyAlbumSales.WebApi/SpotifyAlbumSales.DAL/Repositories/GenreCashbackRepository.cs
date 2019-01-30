using Microsoft.EntityFrameworkCore;
using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Repositories
{
    public class GenreCashbackRepository : RepositoryBase, IGenreCashbackRepository
    {
        public GenreCashbackRepository(ISpotifyAlbumSalesDbContext dbContext) : base(dbContext)
        {
        }

        public Task<decimal> GetCashBackAsync(int genreId, int dayOfWeek)
        {
            return _dbContext.GenreCashbackQuery.Where(x => x.GenreId == genreId && x.DayOfWeek == dayOfWeek).Select(x => x.Cashback).FirstOrDefaultAsync();
        }
    }
}
