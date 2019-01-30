using System.ComponentModel.DataAnnotations;

namespace SpotifyAlbumSales.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
