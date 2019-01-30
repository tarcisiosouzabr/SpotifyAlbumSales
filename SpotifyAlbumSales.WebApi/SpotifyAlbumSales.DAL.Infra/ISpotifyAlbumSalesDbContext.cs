using SpotifyAlbumSales.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Infra
{
    public interface ISpotifyAlbumSalesDbContext : IDisposable
    {
        #region Infra
        Task<int> SaveChangesAsync();
        Task Add<TEntity>(TEntity entity) where TEntity : class;
        Task Edit<TEntity>(TEntity entity) where TEntity : class;
        Task Delete<TEntity>(TEntity entity) where TEntity : class;
        #endregion

        IQueryable<Genre> GenreQuery { get; }
        IQueryable<GenreCashback> GenreCashbackQuery { get; }
        IQueryable<Album> AlbumQuery { get; }
        IQueryable<Sale> SaleQuery { get; }
        IQueryable<SaleItem> SaleItemQuery { get; }
    }
}
