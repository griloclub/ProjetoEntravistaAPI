using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjetoTesteDev.Model;

namespace ProjetoTesteDev.DataContext
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<MesaModel> Mesas { get; set; }
        public DbSet<ItemConsumidoModel> ItensConsumidos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Hashes gerados previamente
            string senhaAdminHash = BCrypt.Net.BCrypt.HashPassword("Senha@123");
            string senhaTiagoHash = BCrypt.Net.BCrypt.HashPassword("Qu@Dr@d0");


            // Seed para a tabela de Usuários
            modelBuilder.Entity<UsuarioModel>().HasData(
                new UsuarioModel
                {
                    Id = 1,
                    Nome = "Admin",
                    Email = "admin@teste.com",
                    SenhaHash = senhaAdminHash
                },
                new UsuarioModel
                {
                    Id = 2,
                    Nome = "Tiago",
                    Email = "tiago@teste.com",
                    SenhaHash = senhaTiagoHash
                }
            );

            // Seed para a tabela de Mesas
            modelBuilder.Entity<MesaModel>().HasData(
                new MesaModel
                {
                    Id = 1,
                    Numero = "M001",
                    Aberta = true,
                    HorarioAbertura = new DateTime(2025, 1, 1, 14, 30, 0) // Valor fixo
                },
                new MesaModel
                {
                    Id = 2,
                    Numero = "M002",
                    Aberta = false,
                    HorarioAbertura = new DateTime(2025, 1, 1, 12, 0, 0), // Valor fixo
                    HorarioFechamento = new DateTime(2025, 1, 1, 13, 0, 0) // Valor fixo
                }
            );

            // Seed para a tabela de Itens Consumidos
            modelBuilder.Entity<ItemConsumidoModel>().HasData(
                new ItemConsumidoModel
                {
                    Id = 1,
                    Nome = "Cerveja",
                    Valor = 10.5m,
                    MesaId = 1
                },
                new ItemConsumidoModel
                {
                    Id = 2,
                    Nome = "Petisco",
                    Valor = 25.0m,
                    MesaId = 1
                },
                new ItemConsumidoModel
                {
                    Id = 3,
                    Nome = "Refrigerante",
                    Valor = 7.0m,
                    MesaId = 2
                }
            );
        }
    }
}
