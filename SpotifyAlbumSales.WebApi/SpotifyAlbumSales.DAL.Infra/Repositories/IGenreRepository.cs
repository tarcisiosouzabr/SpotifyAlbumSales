using SpotifyAlbumSales.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.DAL.Infra.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenresToSearchAsync();
        Task AddAsync(Genre genre);
    }
}
