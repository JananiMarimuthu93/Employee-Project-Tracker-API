using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee_Project_Tracker_API.Models
{
    public class EmployeeProjectTrackerContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        public EmployeeProjectTrackerContext()
        {

        }

        // Called during execution
        public EmployeeProjectTrackerContext(DbContextOptions<EmployeeProjectTrackerContext> options) : base(options)
        {

        }

        // Uncomment and configure this method if you want to setup your DB connection here
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KDJ-LAPTOP\\SQLEXPRESS;database=WebAPI;Integrated Security=True;TrustServerCertificate=True;");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Project configuration
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.ProjectId);// Primary Key

                entity.Property(p => p.ProjectCode)
                .IsRequired()
                .HasMaxLength(10);
                entity.HasIndex(p => p.ProjectCode).IsUnique();

                entity.Property(p => p.ProjectName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(p => p.StartDate)
                .IsRequired();

                //nullable
                entity.Property(p => p.EndDate)
                .IsRequired(false);

                entity.Property(p => p.Budget)
                .IsRequired();

                //one - to - many relationship between Project and Employee,
                //Starts from Project (the "one" side).
                //Says: A Project has many Employees, and each Employee has one Project.
                //Valid and works fine — usually placed in the Project entity configuration.


                //entity.HasMany(p => p.Employees)
                //      .WithOne(e => e.Project)
                //      .HasForeignKey(e => e.ProjectId)
                //      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasData(
                      new Project
                      {
                          ProjectId = 1,
                          ProjectCode = "PRJ001",
                          ProjectName = "AI Development",
                          StartDate = new DateTime(2025, 1, 15),
                          EndDate = null,
                          Budget = 100000
                      },
                      new Project
                      {
                          ProjectId = 2,
                          ProjectCode = "PRJ002",
                          ProjectName = "Web Revamp",
                          StartDate = new DateTime(2025, 2, 1),
                          EndDate = new DateTime(2025, 6, 15),
                          Budget = 50000
                      }
                  );
            });

            // Employee configuration
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeCode)
                      .IsRequired()
                      .HasMaxLength(8);
                entity.HasIndex(e => e.EmployeeCode)
                      .IsUnique();

                entity.Property(e => e.FullName)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.Email)
                      .IsRequired();
                entity.HasIndex(e => e.Email)
                      .IsUnique();

                entity.Property(e => e.Designation)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Salary)
                      .IsRequired();

                //one-to-many relationship between Project and Employee
                //Starts from Employee(the "many" side).
                //Says: An Employee belongs to one Project, and a Project has many Employees.
                //Usually used in the Employee entity configuration.
                //Easier to read because you immediately see the foreign key location(Employee.ProjectId).

                entity.HasOne(e => e.Project)              // Employee has one Project
                      .WithMany(p => p.Employees)          // Project has many Employees
                      .HasForeignKey(e => e.ProjectId)     // FK in Employee table
                      .OnDelete(DeleteBehavior.Cascade);   // Cascade delete

                //Rule of Thumb
                //If you’re inside EmployeeConfiguration → use HasOne → WithMany.
                //If you’re inside ProjectConfiguration → use HasMany → WithOne.

                entity.HasData(
                    new Employee
                    {
                        EmployeeId = 1,
                        EmployeeCode = "EMP001",
                        FullName = "Janani M",
                        Email = "jananiem02@gmail.com",
                        Designation = "Developer",
                        Salary = 60000,
                        ProjectId = 1
                    },
                    new Employee
                    {
                        EmployeeId = 2,
                        EmployeeCode = "EMP002",
                        FullName = "Deepika M",
                        Email = "deepikaem99@gmail.com",
                        Designation = "Manager",
                        Salary = 80000,
                        ProjectId = 1
                    }
                );
            });


        }
    }
}