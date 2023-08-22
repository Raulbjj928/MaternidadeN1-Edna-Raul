using MaternidadeN1_Edna_Raul.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MaternidadeN1_Edna_Raul.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MaeModel> Mae { get; set; }
        public DbSet<RecemNascidoModel> Bebe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Mapeamento da relação 1 para N entre genero e musica
            modelBuilder.Entity<RecemNascidoModel>()
                .HasOne(m => m.Mae)
                .WithMany()
                .HasForeignKey(m => m.MaeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
