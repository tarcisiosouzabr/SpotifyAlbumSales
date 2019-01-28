using Microsoft.EntityFrameworkCore;
using SpotifyAlbumSales.DAL.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL
{
    public class SpotifyAlbumSalesDbContext : DbContext, ISpotifyAlbumSalesDbContext
    {
    //    public DbSet<User> User { get; set; }
    //    public IQueryable<User> UserQuery { get { return User; } }

        #region Infra

        public SpotifyAlbumSalesDbContext (DbContextOptions op) : base(op)
        {

        }

        public Task Delete<TEntity>(TEntity entity) where TEntity : class
        {
            return Task.Run(() =>
            {
                base.Remove(entity);
            });
        }

        public Task Edit<TEntity>(TEntity entity) where TEntity : class
        {
            return Task.Run(() =>
            {
                base.Update(entity);
            });
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public Task Add<TEntity>(TEntity entity) where TEntity : class
        {
            return Task.Run(() =>
            {
                base.Add(entity);
            });
        }
        #endregion
    }


}
