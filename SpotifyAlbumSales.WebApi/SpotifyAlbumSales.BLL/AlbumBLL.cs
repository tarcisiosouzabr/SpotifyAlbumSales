using SpotifyAlbumSales.BLL.Infra;
using SpotifyAlbumSales.DAL.Infra;
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
        private IGenreRepository _genreRepository;
        private ISpotifyAlbumSalesDbContext _dbContext;
        public AlbumBLL(IAlbumRepository albumRepository, IGenreRepository genreRepository, ISpotifyAlbumSalesDbContext dbContext)
        {
            _albumRepository = albumRepository;
            _genreRepository = genreRepository;
            _dbContext = dbContext;
        }

        public async Task AddAlbunsAsync(List<string> albuns, int genreId)
        {
            var rnd = new Random();
            foreach (var item in albuns)
            {
                await _albumRepository.AddAsync(new Album {
                    Id = Guid.NewGuid(),
                    GenreId = genreId,
                    Name = item,
                    Value = rnd.Next(5, 25)
                });
            }
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Album>> GetAsync(int? genreId, int page, int pageSize)
        {
            return _albumRepository.GetAsync(genreId, page, pageSize);
        }

        public Task<Album> GetByIdAsync(Guid id)
        {
            return _albumRepository.GetByIdAsync(id);
        }

        public Task<List<Genre>> GetGenresAsync()
        {
            return _genreRepository.GetGenresToSearchAsync();
        }
    }
}
