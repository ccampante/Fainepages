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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Template()
        {
            Atributo = new HashSet<Atributo>();
        }

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

        [Column(TypeName = "ntext")]
        public string FormularioCode { get; set; }

        public bool Analytics { get; set; }

        [Column(TypeName = "ntext")]
        public string AnalyticsCode { get; set; }

        public bool TagManager { get; set; }

        [Column(TypeName = "ntext")]
        public string TagManagerCode { get; set; }

        public bool Smartlook { get; set; }

        [Column(TypeName = "ntext")]
        public string SmartlookCode { get; set; }

        public DateTime DtCriacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Atributo> Atributo { get; set; }
    }
}
