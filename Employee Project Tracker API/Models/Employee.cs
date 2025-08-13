using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Project_Tracker_API.Models
{
    public class Employee
    {
        [Key] //Primary key
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(8)]
        public String EmployeeCode { get; set; }

        [Required]
        [MaxLength(150)]
        public String FullName { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        [MaxLength(50)]
        public String Designation { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]

        //Navigation Property
        public virtual Project? Project { get; set; }
    }
}

