using System;
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

        //IQueryable<User> UserQuery { get; }
    }
}
