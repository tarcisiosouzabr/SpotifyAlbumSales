using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL.Infra.Repositories;
using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.BLL
{
    public class AlbumBLL : IAlbumBLL
    {
        private IAlbumRepository _albumRepository;
        public AlbumBLL(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public Task<List<Album>> GetAsync(int? genreId, int page, int pageSize)
        {
            return _albumRepository.GetAsync(genreId, page, pageSize);
        }

        public Task<Album> GetByIdAsync(Guid id)
        {
            return _albumRepository.GetByIdAsync(id);
        }
    }
}
