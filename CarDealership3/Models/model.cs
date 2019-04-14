namespace CarDealership3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public model()
        {
            vehicles = new HashSet<vehicle>();
        }

        public int modelId { get; set; }

        public int? engineSize { get; set; }

        public int? doors { get; set; }

        [StringLength(30)]
        public string colour { get; set; }

        public int? vehicleTypeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(66)]
        public string name { get; set; }

        public string fullName
        {
            get
            {
                return this.name + " " + this.vehicleType.name;
            }
        }

        public virtual vehicleType vehicleType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehicle> vehicles { get; set; }
    }
}
