using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorProjectCS.ViewModels
{
    public class LoginFormViewModel
    {

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50)]
        public String Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public String Password { get; set; }

    }
}