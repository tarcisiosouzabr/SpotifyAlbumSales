using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Infra.Repositories
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAsync (int? genreId, int page, int pageSize);
        Task<Album> GetByIdAsync(Guid id);
        Task AddAsync(Album album);
    }
}