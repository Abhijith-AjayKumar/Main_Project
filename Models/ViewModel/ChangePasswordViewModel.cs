using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ViewModel
{
        public class ChangePasswordViewModel
        {
            [Required(ErrorMessage = "Current password is required")]
            public string CurrentPassword { get; set; }

            [Required(ErrorMessage = "New password is required")]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [Required(ErrorMessage = "Confirm password is required")]
            [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
            public string ConfirmPassword { get; set; }
        }

    
}
