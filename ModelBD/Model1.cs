using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ABC.ModelBD
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.GenderCode)
                .IsFixedLength();
        }
    }
}
