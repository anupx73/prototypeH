namespace PrototypeH2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(10)]
        public string customerph { get; set; }

        [StringLength(10)]
        public string cutomername { get; set; }

        [Required]
        [StringLength(10)]
        public string roomno { get; set; }

        [Column(TypeName = "date")]
        public DateTime checkout { get; set; }
    }
}
