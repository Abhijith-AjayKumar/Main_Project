﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Admin_CompanyDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "invalid name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"\b[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "invalid email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{10}$", ErrorMessage = "invalid Number")]
        [Display(Name = "Phone No")]
        public int Phone_No { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Pin { get; set; }
    }
}
