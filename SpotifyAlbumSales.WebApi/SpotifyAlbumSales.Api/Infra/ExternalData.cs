using Newtonsoft.Json;
using SpotifyAlbumSales.Api.Infra.SpotifyResponse;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.Api.Infra
{
    public class ExternalData : IExternalData
    {
        public async Task<AuthResponse> AuthenticationAsync(HttpClient authClient)
        {
            var p = new Dictionary<string, string>();
            p.Add("grant_type", "client_credentials");
            var authResponse = await authClient.PostAsync("api/token", new FormUrlEncodedContent(p));
            var jsonString = await authResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthResponse>(jsonString);
        }

        public async Task<SearchAlbumResponse> SearchByGenreAsync(HttpClient searchClient, AuthResponse tokenResponse, string genre)
        {
            var authResponse = await searchClient.GetAsync("search?q=" + genre + "&type=album&limit=50");
            var jsonString = await authResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SearchAlbumResponse>(jsonString);
        }
    }
}
