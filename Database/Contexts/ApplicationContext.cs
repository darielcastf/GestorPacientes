using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PruebaLaboratorio> PruebasLaboratorio { get; set; }
        public DbSet<ResultadoLaboratorio> ResultadosLaboratorio { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API

            #region table
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Medico>().ToTable("Medicos");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<ResultadoLaboratorio>().ToTable("ResultadosLaboratorio");
            modelBuilder.Entity<Cita>().ToTable("Citas");
            modelBuilder.Entity<PruebaLaboratorio>().ToTable("PruebasLaboratorio");
            modelBuilder.Entity<Consultorio>().ToTable("Consultorios");
            #endregion

            #region primary keys
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<Medico>().HasKey(p => p.Id);
            modelBuilder.Entity<Paciente>().HasKey(p => p.Id);
            modelBuilder.Entity<ResultadoLaboratorio>().HasKey(p => p.Id);
            modelBuilder.Entity<Cita>().HasKey(p => p.Id);
            modelBuilder.Entity<PruebaLaboratorio>().HasKey(p => p.Id);
            modelBuilder.Entity<Consultorio>().HasKey(p => p.Id);
            #endregion

            #region relationships

            // Configuración de Consultorio
            modelBuilder.Entity<Consultorio>()
                .HasMany(c => c.Medicos)
                .WithOne(m => m.Consultorio)
                .HasForeignKey(m => m.ConsultorioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consultorio>()
                .HasMany(c => c.Pacientes)
                .WithOne(p => p.Consultorio)
                .HasForeignKey(p => p.ConsultorioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consultorio>()
                .HasOne(c => c.User)
                .WithMany(u => u.Consultorios)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de Paciente
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.ResultadosLaboratorio)
                .WithOne(r => r.Paciente)
                .HasForeignKey(r => r.PacienteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Citas)
                .WithOne(c => c.Paciente)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuración de Medico
            modelBuilder.Entity<Medico>()
                .HasMany(m => m.Citas)
                .WithOne(c => c.Medico)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuración de PruebaLaboratorio
            modelBuilder.Entity<PruebaLaboratorio>()
                .HasMany(pl => pl.ResultadosLaboratorio)
                .WithOne(r => r.PruebaLaboratorio)
                .HasForeignKey(r => r.PruebaLaboratorioId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuración de ResultadoLaboratorio
            modelBuilder.Entity<ResultadoLaboratorio>()
                .HasOne(r => r.Consultorio)
                .WithMany()
                .HasForeignKey(r => r.ConsultorioId);

            // Configuración de Cita
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Consultorio)
                .WithMany()
                .HasForeignKey(c => c.ConsultorioId);

            // Configuracion User - Consultorio
            modelBuilder.Entity<Consultorio>()
                .HasOne(c => c.User)
                .WithMany(u => u.Consultorios)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region Configuracion User
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .HasMaxLength(15);

            modelBuilder.Entity<User>()
                .Property(u => u.TipoUsuario)
                .IsRequired();

            #endregion

        }
    }
}
