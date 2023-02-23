using D_B.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Infrastucture.Persistence.Contexts
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Citas> citas { get; set; }
        public DbSet<Medicos> medicos { get; set; }
        public DbSet<Pacientes> pacientes { get; set; }
        public DbSet<PruebaLaboratorio> pruebaLaboratirios { get; set; }
        public DbSet<Resultados_Laboratorio> resultados_Laboratorios { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region "Tables"

            modelBuilder.Entity<Citas>().ToTable("Citas");
            modelBuilder.Entity<Medicos>().ToTable("Medicos");
            modelBuilder.Entity<Pacientes>().ToTable("Pacientes");
            modelBuilder.Entity<PruebaLaboratorio>().ToTable("PruebaLaboratorios");
            modelBuilder.Entity<Resultados_Laboratorio>().ToTable("Resultados_Laboratorios");
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");

            #endregion


            #region "Primary Key"

            modelBuilder.Entity<Citas>().HasKey(C => C.Id);
            modelBuilder.Entity<Medicos>().HasKey(m => m.Id);
            modelBuilder.Entity<Pacientes>().HasKey(p => p.Id);
            modelBuilder.Entity<PruebaLaboratorio>().HasKey(pl => pl.Id);
            modelBuilder.Entity<Resultados_Laboratorio>().HasKey(rl => rl.Id);
            modelBuilder.Entity<Usuarios>().HasKey(u => u.Id);
            #endregion

            #region "RelationShips"


            //Medicos con citas
            modelBuilder.Entity<Medicos>()
                .HasMany<Citas>(m => m.citas)
                .WithOne(c => c.medico)
                .HasForeignKey(c => c.NombreDoctorID);

            //Pacientes con citas
            modelBuilder.Entity<Pacientes>()
             .HasMany<Citas>(p => p.citas)
             .WithOne(c => c.paciente)
             .HasForeignKey(c => c.NombrePacienteID);


            //Paciente con resultado de lab
            modelBuilder.Entity<Pacientes>()
             .HasMany<Resultados_Laboratorio>(p => p.resultados_Laboratorio)
             .WithOne(rl => rl.paciente)
             .HasForeignKey(p => p.PacienteID);

            //Resultado de lab con Pruebas de Lab
            modelBuilder.Entity<PruebaLaboratorio>()
             .HasMany<Resultados_Laboratorio>(r => r.resultados_Laboratorios)
             .WithOne(pl => pl.pruebaLaboratorio)
             .HasForeignKey(p => p.PruebaLab);


            #endregion


            #region "Property Configuration"
            modelBuilder.Entity<Usuarios>().Property(u => u.Id).IsRequired();
            modelBuilder.Entity<Medicos>().Property(m => m.Id).IsRequired();
            modelBuilder.Entity<PruebaLaboratorio>().Property(pl => pl.Id).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.Id).IsRequired();

            #endregion
        }

    }
}
