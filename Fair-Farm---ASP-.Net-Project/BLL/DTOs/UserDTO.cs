using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
   
        public string UserName { get; set; }
  
        public string UsersUserName { get; set; }
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one number, and be at least 8 characters long.")]
        public string Password { get; set; }
  
        public string UserPhoneNumber { get; set; }
    
        public DateTime UserDateOfBirth { get; set; }
   
        public string UserCity { get; set; }
  
        public string UserRegion { get; set; }
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string UserEmail { get; set; }

        public bool UserRedList { get; set; }

        public bool UserLogInValid { get; set; }

        public string UserType { get; set; }
    }
}
