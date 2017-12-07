namespace Fainepages.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Atributo")]
    public partial class Atributo
    {
        public int AtributoId { get; set; }

        public int TemplateId { get; set; }

        [StringLength(250)]
        public string Texto { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public bool NovaGuia { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        public virtual Template Template { get; set; }
    }
}
