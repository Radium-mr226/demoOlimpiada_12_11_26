namespace demoOlimpiada_12_11_26.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class min_services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public min_services()
        {
            tarif = new HashSet<tarif>();
        }

        [Key]
        public int id_min_service { get; set; }

        public int add_min_quan { get; set; }

        public decimal add_min_cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarif> tarif { get; set; }
    }
}
