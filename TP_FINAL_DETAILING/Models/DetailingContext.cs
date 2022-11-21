using Microsoft.EntityFrameworkCore;

namespace TP_FINAL_DETAILING.Models
{
    public class DetailingContext: DbContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Santi
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5MUUJS2\\SQLEXPRESS; Initial Catalog = ORTDetailingF; Integrated Security = true");
            
            //javier
            //optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=ORTDetailing; Integrated Security=true;");

        }



    }
}
