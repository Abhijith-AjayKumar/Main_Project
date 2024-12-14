using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class admin_ProductList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "invalid name")]
        public string Title { get; set; }
        [Required]
        public int ISBN { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "invalid name")]
        public string Author { get; set; }
        [Required]
        [StringLength(maximumLength:1000 ,MinimumLength = 2, ErrorMessage = "invalid name")]
        public string Description { get; set; }
        [Required]
        public float ListPrice { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float Price50 { get; set; }
        [Required]
        public float Price100 { get; set; }
        [Required]
        public int Cover_TypeID { get; set; }
        [ForeignKey("Cover_TypeID")]
        public virtual admin_CoverType CoverType { get; set; }
        [Required]
        public int Catergory_Id { get; set; }
        [ForeignKey("Catergory_Id")]
        public virtual Admin_Categories Categories { get; set; }
        [Required]
        public string Photo { get; set; } 
        [NotMapped]
        public IFormFile ProfileImage { get; set; }

    }
}
