namespace PrototypeH2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string type { get; set; }

        [Required]
        [StringLength(10)]
        public string beds { get; set; }

        public bool? ac { get; set; }

        public int rate { get; set; }
    }
}
