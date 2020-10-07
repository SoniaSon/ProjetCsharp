using Microsoft.EntityFrameworkCore;
using ProjetCSharp.GestionCampagne;

namespace ProjetCSharp.NEf
{
    public class Context : DbContext
    {
        //public ContextEf() : base("C_BdCampagne") { }
        //public DbSet<Campagne> CampagneEntities { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Campagne> Campagne { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=LAPTOP-439FKB32\SQLSERER_2017;Initial Catalog=BdCampagne;Integrated Security=SSPI");

    }
}
