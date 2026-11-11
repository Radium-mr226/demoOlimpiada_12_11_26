namespace demoOlimpiada_12_11_26.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            contracts = new HashSet<contracts>();
        }

        [Key]
        public int id_user { get; set; }

        [Required]
        [StringLength(150)]
        public string full_name { get; set; }

        [Required]
        [StringLength(10)]
        public string passport_number { get; set; }

        [Required]
        [StringLength(4)]
        public string passport_series { get; set; }

        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(200)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday_date { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string passport_issued_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime passport_issue_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contracts> contracts { get; set; }
    }
}
