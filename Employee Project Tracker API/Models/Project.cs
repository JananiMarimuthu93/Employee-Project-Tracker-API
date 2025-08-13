using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee_Project_Tracker_API.Models
{
    public class Project
    {
        [Key]//Primary Key
        public int ProjectId {  get; set; }

        [Required]
        [MaxLength(10)]
        public string ProjectCode {  get; set; }

        [Required]
        [MaxLength(100)]
        public string ProjectName {  get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } //nullable

        [Required]
        public decimal Budget {  get; set; }
        
        //Navigation Property
        public IList<Employee>? Employees { get; set; }
    }
}
