using SpotifyAlbumSales.Api.Infra.SpotifyResponse;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.Api.Infra
{
    public interface IExternalData
    {
        Task<AuthResponse> AuthenticationAsync(HttpClient authClient);
        Task<SearchAlbumResponse> SearchByGenreAsync(HttpClient searchClient, AuthResponse tokenResponse, string genre);
    }
}
