using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class UserCart_Tb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public virtual admin_ProductList Admin_ProductList { get; set; }
        [Required]
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual Register Register { get; set; }
     
        public int Count { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
