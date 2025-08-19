using Employee_Project_Tracker_API.Models;

namespace Employee_Project_Tracker_API.IAuthentication
{
    public interface ITokenGenerate
    {
        public string GenerateToken(User user);

    }
}
