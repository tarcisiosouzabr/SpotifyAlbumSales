using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Infra.Repositories
{
    public interface IGenreCashbackRepository
    {
        Task<decimal> GetCashBackAsync(int genreId, int DayOfWeek);
    }
}
