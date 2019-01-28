using SpotifyAlbumSales.BLL.Infra;
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
        public SaleBLL(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public Task<List<Sale>> GetAsync(DateTime? initialDate, DateTime? finalDate, int page, int pageSize)
        {
            return _saleRepository.GetAsync(initialDate, finalDate, page, pageSize);
        }

        public Task<Sale> GetByIdAsync(Guid id)
        {
            return _saleRepository.GetByIdAsync(id);
        }
    }
}
