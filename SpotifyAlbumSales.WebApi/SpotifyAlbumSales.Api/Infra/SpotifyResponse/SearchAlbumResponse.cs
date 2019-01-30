using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyAlbumSales.Api.Infra.SpotifyResponse
{
    public class SearchAlbumResponse
    {
        public Albums albums { get; set; }

    }
    public class Albums
    {
        public Item[] items { get; set; }
    }
    public class Item
    {
        public string name { get; set; }
    }
}
