using Infra.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<AvaliacaoCliente> AvaliacaoCliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;;Database=DbAvaliacao;Integrated Security=False;Persist Security Info=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario = 1,
                    Nome = "Administrador",
                    Senha = "123",
                    Email = "adm@adm.com.br"
                });


            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    IdCliente = 1,
                    NomeResponsavel = "Arthur",
                    RazaoSocial = "Arthur e Geraldo Eletrônica ME",
                    Cnpj = "24.573.802/0001-59",
                    DataCadastro = DateTime.Now,
                    IdUsuario = 1
                },
                new Cliente
                {
                    IdCliente = 2,
                    NomeResponsavel = "Roberto",
                    RazaoSocial = "Roberto e Tânia Assessoria Jurídica Ltda",
                    Cnpj = "21.062.238/0001-11",
                    DataCadastro = DateTime.Now,
                    IdUsuario = 1
                },
                new Cliente
                {
                    IdCliente = 3,
                    NomeResponsavel = "Allana",
                    RazaoSocial = "Allana e Diogo Transportes Ltda",
                    Cnpj = "34.202.824/0001-66",
                    DataCadastro = DateTime.Now,
                    IdUsuario = 1
                },
                new Cliente
                {
                    IdCliente = 4,
                    NomeResponsavel = "Igor",
                    RazaoSocial = "Igor e Fernando Consultoria Financeira ME",
                    Cnpj = "84.234.045/0001-10",
                    DataCadastro = DateTime.Now,
                    IdUsuario = 1
                }
                );

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(t => t.GetForeignKeys())
                                        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

        }
    }
}
