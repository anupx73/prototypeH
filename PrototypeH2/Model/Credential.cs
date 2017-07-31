namespace PrototypeH2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Credential
    {
        public short Id { get; set; }

        [StringLength(10)]
        public string usertype { get; set; }

        [Required]
        [StringLength(10)]
        public string username { get; set; }

        [Required]
        [StringLength(10)]
        public string userpwd { get; set; }
    }
}
