using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpotifyAlbumSales.Entities
{
    public class SaleItens
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AlbumId { get; set; }

        [Required]
        public Guid SaleId { get; set; }

        [Required]
        public decimal Cashback { get; set; }

        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }

        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }
    }
}
