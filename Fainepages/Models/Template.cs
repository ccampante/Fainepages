namespace Fainepages.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Template")]
    public partial class Template
    {
        public int TemplateId { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(150)]
        public string Url { get; set; }

        [Column(TypeName = "ntext")]
        public string MetaDescricao { get; set; }

        [Column(TypeName = "ntext")]
        public string PalavrasChaves { get; set; }

        public bool Formulario { get; set; }

        public bool Analytics { get; set; }

        public bool TagManager { get; set; }

        public bool Smartlook { get; set; }

        public DateTime DtCriacao { get; set; }
    }
}
