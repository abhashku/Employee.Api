using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Entities
{
    public class Employee
    {
        public Employee()
        {
            employeeProjects = new List<EmployeeProject>();
        }

        [Key]
        public Guid EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Url]
        public string picUrl { get; set; }

        [Required]
        public double salary { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public Guid departmentId { get; set; }

        public Department department { get; set; }
       
        [NotMapped]
        public List<Guid> ProjectId { get; set; }

        public List<EmployeeProject> employeeProjects { get; set; }

    }
}
