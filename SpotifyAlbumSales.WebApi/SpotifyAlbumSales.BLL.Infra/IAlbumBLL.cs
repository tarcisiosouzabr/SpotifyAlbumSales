using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.BLL.Infra
{
    public interface IAlbumBLL
    {
        Task<List<Album>> GetAsync(int? genreId, int page, int pageSize);
        Task<Album> GetByIdAsync(Guid id);
        Task<List<Genre>> GetGenresAsync();
        Task AddAlbunsAsync(List<string> albuns, int genreId);
    }
}
