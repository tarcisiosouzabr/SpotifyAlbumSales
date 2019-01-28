using System;
using System.ComponentModel.DataAnnotations;

namespace SpotifyAlbumSales.Entities
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
