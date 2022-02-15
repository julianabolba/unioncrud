using ProjSocial.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjSocial.Data

{
    public class Contexto : DbContext
    {
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Profissional>? Profissionais { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =CS\\SQLSERVER; Initial Catalog= ProjSocial; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(table =>
            {
                table.ToTable("Usuarios");
                table.HasKey(prop => prop.Id);

                table.Property(prop => prop.Nome).HasMaxLength(40).IsRequired(); //Requerido
                table.Property(prop => prop.CPF).HasMaxLength(14).IsRequired();
                table.Property(prop => prop.Cidade).HasMaxLength(30).IsRequired();
                table.Property(prop => prop.Telefone).HasMaxLength(15).IsRequired();
                table.Property(prop => prop.DataNasc).HasColumnType("date").IsRequired();
                table.Property(prop => prop.Orientacao).HasMaxLength(20).IsRequired();
                table.Property(prop => prop.Email).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.Senha).HasMaxLength(30).IsRequired();
            } 
                );

            modelBuilder.Entity<Profissional>(table =>
            {
                table.ToTable("Profissionais");
                table.HasKey(prop => prop.Id);

                table.Property(prop => prop.Nome).HasMaxLength(40).IsRequired(); //Requerido
                table.Property(prop => prop.CNPJ).HasMaxLength(18).IsRequired();
                table.Property(prop => prop.Registro).HasMaxLength(30).IsRequired();
                table.Property(prop => prop.Telefone).HasMaxLength(15).IsRequired();
                table.Property(prop => prop.DataNasc).HasColumnType("date").IsRequired();
                table.Property(prop => prop.Especialidade).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.Cidade).HasMaxLength(20).IsRequired();
                table.Property(prop => prop.Email).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.Senha).HasMaxLength(30).IsRequired();
            }

            );
        }
        
    }
}
