namespace SpotifyAlbumSales.DAL.Infra.Repositories
{
    public abstract class RepositoryBase
    {
        protected ISpotifyAlbumSalesDbContext _dbContext;
        public RepositoryBase(ISpotifyAlbumSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
