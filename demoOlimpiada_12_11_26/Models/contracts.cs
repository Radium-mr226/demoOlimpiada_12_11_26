namespace demoOlimpiada_12_11_26.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class contracts
    {
        [Key]
        public int id_contract { get; set; }

        public int tarif_id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string phone_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime contract_date { get; set; }

        public decimal total_cost { get; set; }

        public int extra_min { get; set; }

        public int extra_gb { get; set; }

        public int extra_sms { get; set; }

        public virtual tarif tarif { get; set; }

        public virtual users users { get; set; }
    }
}
