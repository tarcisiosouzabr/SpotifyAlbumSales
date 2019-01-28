using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.BLL.Infra
{
    public interface ISaleBLL
    {
        Task<List<Sale>> GetAsync(DateTime? initialDate, DateTime? finalDate, int page, int pageSize);
        Task<Sale> GetByIdAsync(Guid id);
    }
}
