namespace demoOlimpiada_12_11_26.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tarif")]
    public partial class tarif
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tarif()
        {
            contracts = new HashSet<contracts>();
        }

        [Key]
        public int id_tarif { get; set; }

        [Required]
        [StringLength(50)]
        public string tarif_name { get; set; }

        public int min_quantity { get; set; }

        public int gb_quantity { get; set; }

        public int sms_quantity { get; set; }

        public int min_service_id { get; set; }

        public int gb_service_id { get; set; }

        public int sms_service_id { get; set; }

        public decimal cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contracts> contracts { get; set; }

        public virtual gb_services gb_services { get; set; }

        public virtual min_services min_services { get; set; }

        public virtual sms_services sms_services { get; set; }
    }
}
