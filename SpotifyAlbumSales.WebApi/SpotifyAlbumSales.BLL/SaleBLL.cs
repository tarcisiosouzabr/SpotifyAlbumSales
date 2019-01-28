using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.BLL
{
    public class SaleBLL : ISaleBLL
    {
        private ISaleRepository _saleRepository;
        private IGenreCashbackRepository _genreCashbackRepository;
        private IAlbumRepository _albumRepository;
        private ISpotifyAlbumSalesDbContext _dbContext;
        private ISaleItemRepository _saleItemRepository;
        public SaleBLL
            (ISpotifyAlbumSalesDbContext dbContext, ISaleRepository saleRepository, 
            IGenreCashbackRepository genreCashbackRepository, IAlbumRepository albumRepository,
            ISaleItemRepository saleItemRepository)
        {
            _dbContext = dbContext;
            _saleRepository = saleRepository;
            _genreCashbackRepository = genreCashbackRepository;
            _albumRepository = albumRepository;
            _saleItemRepository = saleItemRepository;
        }
        public Task<List<Sale>> GetAsync(DateTime? initialDate, DateTime? finalDate, int page, int pageSize)
        {
            return _saleRepository.GetAsync(initialDate, finalDate, page, pageSize);
        }

        public Task<Sale> GetByIdAsync(Guid id)
        {
            return _saleRepository.GetByIdAsync(id);
        }

        public async Task<Sale> SaleAsync(Guid[] albunsId)
        {
            var sale = new Sale() {
                CreatedDate = DateTime.UtcNow,
                Id = Guid.NewGuid()
            };
            await _saleRepository.AddAsync(sale);
            foreach (var item in albunsId)
            {
                var album = await _albumRepository.GetByIdAsync(item);
                if (album == null)
                    throw new NullReferenceException("Album não encontrado");

                var cashbackPercentual = await _genreCashbackRepository.GetCashBackAsync(album.GenreId, (int)DateTime.UtcNow.DayOfWeek);
                var saleItem = new SaleItem() {
                    AlbumId = item,
                    SaleId = sale.Id,
                    Cashback = cashbackPercentual / album.Value 
                };
                await _saleItemRepository.AddAsync(saleItem);
            }
            await _dbContext.SaveChangesAsync();
            return sale;
        }
    }
}
