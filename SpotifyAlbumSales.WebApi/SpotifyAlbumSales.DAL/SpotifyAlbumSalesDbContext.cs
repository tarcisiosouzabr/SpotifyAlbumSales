using Microsoft.EntityFrameworkCore;
using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL
{
    public class SpotifyAlbumSalesDbContext : DbContext, ISpotifyAlbumSalesDbContext
    {
        public DbSet<Genre> Genre { get; set; }
        public IQueryable<Genre> GenreQuery { get { return Genre; } }

        public DbSet<GenreCashback> GenreCashback { get; set; }
        public IQueryable<GenreCashback> GenreCashbackQuery { get { return GenreCashback; } }

        public DbSet<Album> Album { get; set; }
        public IQueryable<Album> AlbumQuery { get { return Album; } }

        public DbSet<Sale> Sale { get; set; }
        public IQueryable<Sale> SaleQuery { get { return Sale; } }

        public DbSet<SaleItens> SaleItens { get; set; }
        public IQueryable<SaleItens> SaleItensQuery { get { return SaleItens; } }

        #region Infra

        public SpotifyAlbumSalesDbContext(DbContextOptions op) : base(op)
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
