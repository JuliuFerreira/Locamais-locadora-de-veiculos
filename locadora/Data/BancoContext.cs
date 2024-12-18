using LocaMais.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LocaMais.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasKey(j => j.Id);
            modelBuilder.Entity<Cliente>().ToTable("Cliente");



        }

    }
}