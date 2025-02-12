using Microsoft.EntityFrameworkCore;
using System;


namespace EmployeeVacationSystem.Entities
{
    public class VacationSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //My server's connection string.
            optionsBuilder.UseSqlServer("Server=DESKTOP-R6A26BO\\SQLEXPRESS;Database=CompanyVacationSystem;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting up Primary keys.
            //Other constraints as Data Annotation.

            modelBuilder.Entity<Department>().HasKey(d => d.ID);
            modelBuilder.Entity<Employee>().HasKey(e => e.number);
            modelBuilder.Entity<Position>().HasKey(p => p.ID);

            modelBuilder.Entity<RequestState>().HasKey(r => r.ID);
            modelBuilder.Entity<VacationRequest>().HasKey(v => v.ID);
            modelBuilder.Entity<VacationType>().HasKey(vt => vt.code);

        //**********************Relations*********************************************.

          // 1- Employee Relations:

            // Many Employees in one Department
            modelBuilder.Entity<Employee>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(e => e.departmentID)
                .OnDelete(DeleteBehavior.Restrict);
                
            //Many Employees may have same Position (Every employee has one position)
            modelBuilder.Entity<Employee>()
                .HasOne<Position>()
                .WithMany()
                .HasForeignKey(e => e.positionID)
                .OnDelete(DeleteBehavior.Restrict);
            //Employee as manager to other Employees
            modelBuilder.Entity<Employee>()
              .HasOne<Employee>()
              .WithMany()
              .HasForeignKey(e => e.reportedToEmployeeNumber)
              .OnDelete(DeleteBehavior.Restrict);

            // 2- VacationRequest relations:

            //many VacationRequests are owned by one employee
            modelBuilder.Entity<VacationRequest>()
            .HasOne<Employee>()
            .WithMany()
            .HasForeignKey(v => v.employeeNumber)
            .OnDelete(DeleteBehavior.Restrict);

            //every VacationRequest has one type

            modelBuilder.Entity<VacationRequest>()
                .HasOne<VacationType>()
                .WithMany()
                .HasForeignKey( v => v.vacationTypeCode)
                .OnDelete(DeleteBehavior.Restrict);

            //every VacationRequest has one state
            modelBuilder.Entity<VacationRequest>()
                .HasOne<RequestState>()
                .WithMany()
                .HasForeignKey(v => v.requestStateID)
                .OnDelete(DeleteBehavior.Restrict);

            //Delete behavior is better to be restrict for data safety.

        }
        public DbSet<Department> departments { get; set; }

        public DbSet<Employee> employees { get; set; }    
         
        public DbSet<Position> positions { get; set; }

        public DbSet<RequestState>  requestStates { get; set; }

        public DbSet<VacationRequest> vacationRequests { get; set; }

        public DbSet<VacationType> vacationTypes { get; set; }

    }
}
