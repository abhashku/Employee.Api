using EmployeeApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeApi.Contexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EmployeeProject>()
                .HasOne<Employee>(e => e.employee)
                .WithMany(e => e.employeeProjects)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne<Project>(ep => ep.project)
                .WithMany(p => p.employeeProjects)
                .HasForeignKey(ep => ep.ProjectId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.department);

            modelBuilder.Entity<Employee>().HasData(

                    new Employee
                    {
                        EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                        FirstName = "test1FirstName",
                        LastName = "test1LastName",
                        MiddleName = "test1MiddleName",
                        Email = "test1@gmail.com",
                        PhoneNumber = "01200012010",
                        picUrl = "http://test1.com",
                        salary = 5000,
                        DateOfBirth = new DateTime(1964, 7, 5),
                        departmentId = Guid.Parse("12345677-2ba9-473a-a40f-e38cb54f9b35")
                    },
                    new Employee
                    {
                        EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                        FirstName = "test2FirstName",
                        LastName = "test2LastName",
                        MiddleName = "test2MiddleName",
                        Email = "test2@gmail.com",
                        PhoneNumber = "01200012010",
                        picUrl = "http://test2.com",
                        salary = 8000,
                        DateOfBirth = new DateTime(1977, 7, 1),
                        departmentId = Guid.Parse("12345678-2ba9-473a-a40f-e38cb54f9b35")
                    },
                    new Employee
                    {
                        EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                        FirstName = "test3FirstName",
                        LastName = "test3LastName",
                        MiddleName = "test3MiddleName",
                        Email = "test3@gmail.com",
                        PhoneNumber = "01200012010",
                        picUrl = "http://test3.com",
                        salary = 4000,
                        DateOfBirth = new DateTime(1989, 1, 4),
                        departmentId = Guid.Parse("12345677-2ba9-473a-a40f-e38cb54f9b35")
                    },
                    new Employee
                    {
                        EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b38"),
                        FirstName = "test4FirstName",
                        LastName = "test4LastName",
                        MiddleName = "test4MiddleName",
                        Email = "test4@gmail.com",
                        PhoneNumber = "01200012010",
                        picUrl = "http://test4.com",
                        salary = 2000,
                        DateOfBirth = new DateTime(1978, 4, 5),
                        departmentId = Guid.Parse("12345678-2ba9-473a-a40f-e38cb54f9b35")
                    }
                );

            modelBuilder.Entity<Project>().HasData(

                    new Project
                    {
                        ProjectId = Guid.Parse("d28888e9-1111-1111-a401-e38cb54f9b36"),
                        ProjectName = "E-commerce",
                        Budget = 50000,
                        Profit = 10000
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("d28888e9-1111-1111-a402-e38cb54f9b36"),
                        ProjectName = "Database design",
                        Budget = 8000,
                        Profit = 1500
                    }
              );

            modelBuilder.Entity<Department>().HasData(

                    new Department
                    {
                        DepartmentId = Guid.Parse("12345677-2ba9-473a-a40f-e38cb54f9b35"),
                        ManagerId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                        DepartmentName = "Distribution department",
                        Headquarter = "Alexandria"
                    },
                    new Department
                    {
                        DepartmentId = Guid.Parse("12345678-2ba9-473a-a40f-e38cb54f9b35"),
                        ManagerId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                        DepartmentName = "Marketing department",
                        Headquarter = "Cairo"
                    }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                    EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ProjectId = Guid.Parse("d28888e9-1111-1111-a401-e38cb54f9b36")
                },
                new EmployeeProject
                {
                    Id = Guid.Parse("00000002-0000-0000-0000-000000000000"),
                    EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ProjectId = Guid.Parse("d28888e9-1111-1111-a402-e38cb54f9b36")
                },
                new EmployeeProject
                {
                    Id = Guid.Parse("00000003-0000-0000-0000-000000000000"),
                    EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                    ProjectId = Guid.Parse("d28888e9-1111-1111-a402-e38cb54f9b36")
                },
                new EmployeeProject
                {
                    Id = Guid.Parse("00000004-0000-0000-0000-000000000000"),
                    EmployeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b37"),
                    ProjectId = Guid.Parse("d28888e9-1111-1111-a402-e38cb54f9b36")
                }
            );

        }

    }
}
