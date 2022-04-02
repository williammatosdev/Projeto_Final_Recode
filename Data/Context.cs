using CadastroElogin.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroElogin.Data
{
    public class Context : DbContext
    {
        public DbSet<Usuario> clientes { get; set; }

        public DbSet<Telefone> passagens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:pcdjobs.database.windows.net,1433;Initial Catalog=PCDjobs;Persist Security Info=False;User ID=knauer;Password=Squad52!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.ToTable("Usuario");
                tb.HasKey("Id_usuario");
                tb.Property("Nome").IsRequired().HasMaxLength(50);
                tb.Property("Sobrenome").IsRequired().HasMaxLength(50);
                tb.Property("Email").IsRequired().HasMaxLength(50);
                tb.Property("Sexo").HasMaxLength(9).IsRequired();
                tb.Property("Senha").HasMaxLength(12).IsRequired();
            });

            modelBuilder.Entity<Telefone>(tb => 
            {
                tb.ToTable("Telefone");
                tb.HasKey(t => t.Id_tel);
                tb.Property(t => t.Celeluar).IsRequired(false).HasColumnType("char(11)");
                tb.HasOne<Usuario>(u => u.Usuario).WithMany(t => t.telefones)
                .HasForeignKey(t => t.Id_usuario);  
            });
        }
    }
}
