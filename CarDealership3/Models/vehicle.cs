namespace CarDealership3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vehicle
    {
        public int vehicleId { get; set; }

        public int? makeId { get; set; }

        public int? modelId { get; set; }

        public int? year { get; set; }

        public decimal? price { get; set; }

        public decimal? cost { get; set; }

        [Column(TypeName = "date")]
        public DateTime? soldDate { get; set; }

        public virtual make make { get; set; }

        public virtual model model { get; set; }
    }
}
