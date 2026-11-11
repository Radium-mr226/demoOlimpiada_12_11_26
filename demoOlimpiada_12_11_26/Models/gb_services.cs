namespace demoOlimpiada_12_11_26.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class gb_services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gb_services()
        {
            tarif = new HashSet<tarif>();
        }

        [Key]
        public int id_gb_service { get; set; }

        public int add_gb_quan { get; set; }

        public decimal add_gb_cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarif> tarif { get; set; }
    }
}
