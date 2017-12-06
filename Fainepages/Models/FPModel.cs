namespace Fainepages.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FPModel : DbContext
    {
        public FPModel()
            : base("name=FPModel")
        {
        }

        public virtual DbSet<Template> Template { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Template>()
                .Property(e => e.Url)
                .IsUnicode(false);
        }
    }
}
