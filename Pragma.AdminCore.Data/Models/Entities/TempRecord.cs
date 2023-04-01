using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pragma.AdminCore.Data.Models.Entities
{
    [Table("TempRecord")]
    public class TempRecord : BaseEntity
    {
        public Guid ProcessId { get; set; }

        [StringLength(450)]
        public string SahibindenId { get; set; }
        public string IsActive { get; set; }
        public string ThumbnailImage { get; set; }
        public DateTime LastCheckDate { get; set; }
        public string Brand { get; set; }
        public string Serie { get; set; }
        public string Model { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string KM { get; set; }
        public string Color { get; set; }
        public string ListingDate { get; set; }
        public string District { get; set; }
        public string Url { get; set; }
        public int LivePrice { get; set; }
        public int FilterId { get; set; }

        [ForeignKey("FilterId")]
        public virtual Filter Filter { get; set; }
    }
}
