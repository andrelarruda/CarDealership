using CarDealership.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Data
{
    public class CarDealershipContext : IdentityDbContext<Usuario>
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

            var administrador = new IdentityRole("administrador");
            administrador.NormalizedName = "ADMINISTRADOR";
            administrador.Id = "5965a736-bd6f-4625-b8d3-dfef2161b8af";

            var vendedor = new IdentityRole("vendedor");
            vendedor.NormalizedName = "VENDEDOR";
            vendedor.Id = "6559a392-fcd0-4aec-b134-422a0812c276";

            var gerente = new IdentityRole("gerente");
            gerente.NormalizedName = "GERENTE";
            gerente.Id = "f652f91e-65e8-485e-9a5f-5af01c89fb36";

            builder.Entity<IdentityRole>().HasData(administrador, vendedor, gerente);

            base.OnModelCreating(builder);
        }
    }
}
