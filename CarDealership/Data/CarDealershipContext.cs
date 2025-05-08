using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Data
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options) : base(options)
        {
        }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Concessionaria> Concessionarias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fabricante>(e =>
            {
                e.HasKey(f => f.Id);
            });

            builder.Entity<Veiculo>(v =>
            {
                v.HasKey(v => v.Id);

                //v.Property(e => e.Preco).HasPrecision(10, 2);

                v.HasOne(v => v.Fabricante)
                    .WithMany(f => f.Veiculos)
                    .HasForeignKey(v => v.FabricanteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Concessionaria>(c =>
            {
                c.HasKey(c => c.Id);
            });

            builder.Entity<Cliente>(c =>
            {
                c.HasKey(c => c.Id);
            });

            builder.Entity<Venda>(v =>
            {
                v.HasKey(v => v.Id);

                //v.Property(e => e.PrecoVenda).HasPrecision(10, 2);

                v.HasOne(v => v.Veiculo)
                    .WithMany()
                    .HasForeignKey(v => v.VeiculoId)
                    .OnDelete(DeleteBehavior.Restrict);

                v.HasOne(v => v.Concessionaria)
                    .WithMany(c => c.Vendas)
                    .HasForeignKey(v => v.ConcessionariaId)
                    .OnDelete(DeleteBehavior.Restrict);

                v.HasOne(v => v.Cliente)
                    .WithMany(c => c.Vendas) // necessario?
                    .HasForeignKey(v => v.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}
