using SpotifyAlbumSales.Entities;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Infra.Repositories
{
    public interface ISaleItemRepository
    {
        Task AddAsync(SaleItem saleItem);
    }
}
