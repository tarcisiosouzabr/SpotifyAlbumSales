using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Infra.Repositories
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAsync(DateTime? initialDate, DateTime? finalDate, int page, int pageSize);
        Task<Sale> GetByIdAsync(Guid id);
    }
}
