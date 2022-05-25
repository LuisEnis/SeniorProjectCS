using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorProjectCS.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50)]
        public String Username { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        [StringLength(50)]
        public String Role { get; set; }

    }
}