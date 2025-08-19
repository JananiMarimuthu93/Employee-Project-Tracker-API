using System.ComponentModel.DataAnnotations;

namespace Employee_Project_Tracker_API.Models
{
    public class User
    {
        //Primary key
        public int UserId { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String? Role {  get; set; }
    }
    
}
